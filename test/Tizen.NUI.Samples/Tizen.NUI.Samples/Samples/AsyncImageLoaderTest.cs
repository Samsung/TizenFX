using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    public class AsyncImageLoaderTest : IExample
    {
        static readonly string VERTEX_SHADER =
        "//@name AsyncImageLoaderTest.vert\n" +
        "\n" +
        "//@version 100\n" +
        "\n" +
        "precision highp float;\n" +
        "INPUT highp vec2 aPosition;\n" +
        "OUTPUT highp vec2 vTexCoord;\n" +
        "\n" +
        "UNIFORM_BLOCK VertBlock\n" +
        "{\n" +
        "  UNIFORM highp mat4 uMvpMatrix;\n" +
        "  UNIFORM highp vec3 uSize;\n" +
        "};\n" +
        "void main()\n" +
        "{\n" +
        "    vec4 pos = vec4(aPosition, 0.0, 1.0) * vec4(uSize, 1.0);\n" +
        "    vTexCoord = aPosition + vec2(0.5);\n" +
        "    gl_Position = uMvpMatrix * pos;\n" +
        "}\n";

        static readonly string FRAGMENT_SHADER =
        "//@name AsyncImageLoaderTest.frag\n" +
        "\n" +
        "//@version 100\n" +
        "\n" +
        "precision highp float;\n" +
        "\n" +
        "INPUT highp vec2 vTexCoord;\n" +
        "UNIFORM sampler2D sTexture;\n" +
        "UNIFORM_BLOCK FragBlock\n" +
        "{\n" +
        "  UNIFORM lowp vec4 uColor;\n" +
        "};\n" +
        "\n" +
        "void main()\n" +
        "{\n" +
        "    gl_FragColor = TEXTURE( sTexture, vTexCoord ) * uColor;\n" +
        "}\n";

        struct SimpleQuadVertex
        {
            public UIVector2 position;
        }

        private PropertyBuffer CreateQuadPropertyBuffer()
        {
            /* Create Property buffer */
            PropertyMap vertexFormat = new PropertyMap();
            vertexFormat.Add("aPosition", (int)PropertyType.Vector2);

            PropertyBuffer vertexBuffer = new PropertyBuffer(vertexFormat);
            
            SimpleQuadVertex vertex1 = new SimpleQuadVertex();
            SimpleQuadVertex vertex2 = new SimpleQuadVertex();
            SimpleQuadVertex vertex3 = new SimpleQuadVertex();
            SimpleQuadVertex vertex4 = new SimpleQuadVertex();
            vertex1.position = new UIVector2(-0.5f, -0.5f);
            vertex2.position = new UIVector2(-0.5f, 0.5f);
            vertex3.position = new UIVector2(0.5f, -0.5f);
            vertex4.position = new UIVector2(0.5f, 0.5f);

            SimpleQuadVertex[] texturedQuadVertexData = new SimpleQuadVertex[4] { vertex1, vertex2, vertex3, vertex4 };

            int size = Marshal.SizeOf(vertex1);
            IntPtr pA = Marshal.AllocHGlobal(checked(size * texturedQuadVertexData.Length));

            try
            {
                for (int i = 0; i < texturedQuadVertexData.Length; i++)
                {
                    Marshal.StructureToPtr(texturedQuadVertexData[i], pA + i * size, true);
                }

                vertexBuffer.SetData(pA, (uint)texturedQuadVertexData.Length);
            }
            catch(Exception e)
            {
                Tizen.Log.Error("NUI", "Exception in CreateQuadPropertyBuffer : " + e.Message);
            }
            finally
            {
                // Free AllocHGlobal memory after call PropertyBuffer.SetData()
                Marshal.FreeHGlobal(pA);
            }

            vertexFormat.Dispose();

            return vertexBuffer;
        }

        private Window win;
        private View root;
        private View paletteInfoRoot;

        private static uint numberOfLoaderType = 4u;
        private static uint numberOfImagesPerEachType = 12u;
        private static uint totalSubViewCounts = numberOfLoaderType * numberOfImagesPerEachType;

        private static Geometry geometry;
        private static Shader shader;

        // Per each view
        private View[] subView = new View[totalSubViewCounts];
        private Renderable[] subViewRenderable = new Renderable[totalSubViewCounts];
        private Texture[] subViewTexture = new Texture[totalSubViewCounts];
        private TextureSet[] subViewTextureSet = new TextureSet[totalSubViewCounts];
        private uint[] subViewLoadId = new uint[totalSubViewCounts];

        // Per each image loader
        private uint[] subViewUrlIndex = new uint[numberOfLoaderType];
        private AsyncImageLoader[] imageLoader = new AsyncImageLoader[numberOfLoaderType];

        private static uint InvalidLoadId = 0u;

        private static string DEMO_IMAGE_DIR = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/";

        private static readonly string[] ImageUrlList = {
            DEMO_IMAGE_DIR + "Dali/ContactCard/gallery-small-2.jpg",
            DEMO_IMAGE_DIR + "Dali/ContactCard/gallery-small-3.jpg",
            DEMO_IMAGE_DIR + "Dali/ContactCard/contact-cards-mask.png", /// RGBA8888
            DEMO_IMAGE_DIR + "AGIF/dali-logo-anim.gif",                 /// Animated image, but will be loaded as single frame.
            "invalid.jpg",                                              /// Invalid image
        };

        public void Activate()
        {
            win = NUIApplication.GetDefaultWindow();
            win.KeyEvent += WindowKeyEvent;

            root = new View()
            {
                Name = "root",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };
            win.Add(root);

            AddViews();
            string infoText = "1'st : ImageLoaded event.\n" +
            "2'nd : PixelBufferLoaded event.\n" +
            "3'rd : PixelBufferLoaded event and change it's own logic.\n" +
            "4'th : PixelBufferLoaded event and get color picks from Palette class.\n" +
            "\n" +
            "Press 1~4 key to load each images.\n" +
            "Press 0 key to load whole images\n";
            var infoLabel = new TextLabel()
            {
                Text = infoText,
                MultiLine = true,

                BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.8f),
            };
            root.Add(infoLabel);

            for(uint i = 0u; i < numberOfLoaderType; ++i)
            {
                imageLoader[i] = new AsyncImageLoader();
            }

            imageLoader[0].ImageLoaded += OnImageLoaded;
            imageLoader[1].PixelBufferLoaded += OnPixelBufferLoaded;
            imageLoader[2].PixelBufferLoaded += OnPixelBufferLoadedWithCustom;
            imageLoader[3].PixelBufferLoaded += OnPixelBufferLoadedWithColorPalette;
        }

        public void Deactivate()
        {
            for(uint i = 0u; i < numberOfLoaderType; ++i)
            {
                imageLoader[i]?.Dispose();
            }
            root?.Unparent();
            root?.DisposeRecursively();

            for(uint i = 0u; i < totalSubViewCounts; ++i)
            {
                subViewRenderable[i]?.Dispose();
                subViewTexture[i]?.Dispose();
                subViewTextureSet[i]?.Dispose();
            }

            win.KeyEvent -= WindowKeyEvent;
        }

        private void WindowKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                try
                {
                    if (e.Key.KeyPressedName == "0" || e.Key.KeyPressedName == "1")
                    {
                        RequestLoad(0);
                    }
                    if (e.Key.KeyPressedName == "0" || e.Key.KeyPressedName == "2")
                    {
                        RequestLoad(1);
                    }
                    if (e.Key.KeyPressedName == "0" || e.Key.KeyPressedName == "3")
                    {
                        RequestLoad(2);
                    }
                    if (e.Key.KeyPressedName == "0" || e.Key.KeyPressedName == "4")
                    {
                        RequestLoad(3);
                    }
                }
                catch(Exception ex)
                {
                    Tizen.Log.Error("NUI", "Exception in RequestLoad : " + ex.Message);
                }
            }
        }

        private void AddViews()
        {
            for (uint i = 0u; i < numberOfLoaderType; ++i)
            {
                for (uint j = 0u; j < numberOfImagesPerEachType; ++j)
                {
                    View view = new View()
                    {
                        Name = $"subView{i}x{j}",
                        BackgroundColor = Color.Red,
                        SizeWidth = 100.0f,
                        SizeHeight = 100.0f,
                        PositionX = j * 100.0f,
                        PositionY = i * 110.0f + 10.0f,
                    };

                    var renderable = GenerateRenderable();

                    view.AddRenderable(renderable);
                    root.Add(view);

                    uint viewIndex = i * numberOfImagesPerEachType + j;

                    subViewRenderable[viewIndex] = renderable;

                    subView[viewIndex] = view;
                    subViewTextureSet[viewIndex] = renderable.TextureSet;
                    subViewTexture[viewIndex] = renderable.TextureSet.GetTexture(0u);
                    subViewLoadId[viewIndex] = InvalidLoadId;
                }
                subViewUrlIndex[i] = (uint)(ImageUrlList.Length - 1);
            }
        }

        private void RequestLoad(uint loaderIndex)
        {
            if (loaderIndex >= numberOfLoaderType)
            {
                throw new ArgumentException($"Invalid subViewIndex comes! {loaderIndex}");
            }

            if (imageLoader[loaderIndex] == null)
            {
                Tizen.Log.Info("NUITest", $"Image loader Disposed!\n");
                return;
            }

            for (uint j = 0u; j < numberOfImagesPerEachType; ++j)
            {
                uint viewIndex = loaderIndex * numberOfImagesPerEachType + j;
                if (subViewLoadId[viewIndex] != InvalidLoadId)
                {
                    Tizen.Log.Info("NUITest", $"Cancel {viewIndex}'th loadId {subViewLoadId[viewIndex]}\n");
                    imageLoader[loaderIndex].Cancel(subViewLoadId[viewIndex]);
                    subViewLoadId[viewIndex] = InvalidLoadId;
                }
            }

            subViewUrlIndex[loaderIndex] = (uint)((subViewUrlIndex[loaderIndex] + 1u) % ImageUrlList.Length);

            for (uint j = 0u; j < numberOfImagesPerEachType; ++j)
            {
                uint viewIndex = loaderIndex * numberOfImagesPerEachType + j;
                subViewLoadId[viewIndex] = imageLoader[loaderIndex].Load(ImageUrlList[subViewUrlIndex[loaderIndex]]);
                Tizen.Log.Info("NUITest", $"Load {viewIndex}'th loadId {subViewLoadId[viewIndex]}\n");
            }
        }

        private void OnImageLoaded(object o, AsyncImageLoader.ImageLoadedEventArgs e)
        {
            uint viewIndex = 0u;
            for (uint j = 0u; j < numberOfImagesPerEachType; ++j)
            {
                viewIndex = 0u * numberOfImagesPerEachType + j;
                if (subViewLoadId[viewIndex] == e.LoadingTaskId)
                {
                    break;
                }
            }

            if (subViewLoadId[viewIndex] != e.LoadingTaskId)
            {
                // Should never comes here!
                Tizen.Log.Error("NUITest", $"{viewIndex}'th loadId not matched with callback input {e.LoadingTaskId}!!\n");
                return;
            }
            if (e.PixelData == null)
            {
                Tizen.Log.Info("NUITest", $"Load Fail {viewIndex}'th loadId {subViewLoadId[viewIndex]}\n");

                subViewLoadId[viewIndex] = InvalidLoadId;
                return;
            }

            var width = e.PixelData.GetWidth();
            var height = e.PixelData.GetHeight();
            var pixelFormat = e.PixelData.GetPixelFormat();
            Tizen.Log.Info("NUITest", $"Load Complete {viewIndex}'th loadId {subViewLoadId[viewIndex]} : {width}x{height} with format {pixelFormat}\n");

            subViewLoadId[viewIndex] = InvalidLoadId;

            Texture texture = new Texture(TextureType.TEXTURE_2D, pixelFormat, width, height);
            texture.Upload(e.PixelData);

            subViewTexture[viewIndex]?.Dispose();
            subViewTextureSet[viewIndex].SetTexture(0u, texture);
            subViewTexture[viewIndex] = texture;
        }

        private void OnPixelBufferLoaded(object o, AsyncImageLoader.PixelBufferLoadedEventArgs e)
        {
            uint viewIndex = 0u;
            for (uint j = 0u; j < numberOfImagesPerEachType; ++j)
            {
                viewIndex = 1u * numberOfImagesPerEachType + j;
                if (subViewLoadId[viewIndex] == e.LoadingTaskId)
                {
                    break;
                }
            }

            if (subViewLoadId[viewIndex] != e.LoadingTaskId)
            {
                // Should never comes here!
                Tizen.Log.Error("NUITest", $"{viewIndex}'th loadId {subViewLoadId[viewIndex]} not matched with callback input {e.LoadingTaskId}!!\n");
                return;
            }
            if (e.PixelBuffers == null || e.PixelBuffers.Count == 0 || e.PixelBuffers[0] == null)
            {
                Tizen.Log.Info("NUITest", $"Load Fail {viewIndex}'th loadId {subViewLoadId[viewIndex]}\n");

                subViewLoadId[viewIndex] = InvalidLoadId;
                return;
            }

            PixelData pixelData = PixelBuffer.Convert(e.PixelBuffers[0]);

            var width = pixelData.GetWidth();
            var height = pixelData.GetHeight();
            var pixelFormat = pixelData.GetPixelFormat();
            Tizen.Log.Info("NUITest", $"Complete {viewIndex}'th loadId {subViewLoadId[viewIndex]} : {width}x{height} with format {pixelFormat}\n");

            subViewLoadId[viewIndex] = InvalidLoadId;

            Texture texture = new Texture(TextureType.TEXTURE_2D, pixelFormat, width, height);
            texture.Upload(pixelData);

            subViewTexture[viewIndex]?.Dispose();
            subViewTextureSet[viewIndex].SetTexture(0u, texture);
            subViewTexture[viewIndex] = texture;
        }

        private void OnPixelBufferLoadedWithCustom(object o, AsyncImageLoader.PixelBufferLoadedEventArgs e)
        {
            uint viewIndex = 0u;
            for (uint j = 0u; j < numberOfImagesPerEachType; ++j)
            {
                viewIndex = 2u * numberOfImagesPerEachType + j;
                if (subViewLoadId[viewIndex] == e.LoadingTaskId)
                {
                    break;
                }
            }

            if (subViewLoadId[viewIndex] != e.LoadingTaskId)
            {
                // Should never comes here!
                Tizen.Log.Error("NUITest", $"{viewIndex}'th loadId {subViewLoadId[viewIndex]} not matched with callback input {e.LoadingTaskId}!!\n");
                return;
            }
            if (e.PixelBuffers == null || e.PixelBuffers.Count == 0 || e.PixelBuffers[0] == null)
            {
                Tizen.Log.Info("NUITest", $"Load Fail {viewIndex}'th loadId {subViewLoadId[viewIndex]}\n");

                subViewLoadId[viewIndex] = InvalidLoadId;
                return;
            }

            PixelBuffer pixelBuffer = e.PixelBuffers[0];

            // Do something custom actions for this pixelBuffer.
            pixelBuffer.Rotate(new Degree((float)viewIndex * 20.0f));

            PixelData pixelData = PixelBuffer.Convert(pixelBuffer);

            var width = pixelData.GetWidth();
            var height = pixelData.GetHeight();
            var pixelFormat = pixelData.GetPixelFormat();
            Tizen.Log.Info("NUITest", $"Complete {viewIndex}'th loadId {subViewLoadId[viewIndex]} : {width}x{height} with format {pixelFormat}\n");

            subViewLoadId[viewIndex] = InvalidLoadId;

            Texture texture = new Texture(TextureType.TEXTURE_2D, pixelFormat, width, height);
            texture.Upload(pixelData);

            subViewTexture[viewIndex]?.Dispose();
            subViewTextureSet[viewIndex].SetTexture(0u, texture);
            subViewTexture[viewIndex] = texture;
        }

        private void OnPixelBufferLoadedWithColorPalette(object o, AsyncImageLoader.PixelBufferLoadedEventArgs e)
        {
            uint viewIndex = 0u;
            bool colorPick = false;
            for (uint j = 0u; j < numberOfImagesPerEachType; ++j)
            {
                viewIndex = 3u * numberOfImagesPerEachType + j;
                if (subViewLoadId[viewIndex] == e.LoadingTaskId)
                {
                    if (j == 0u)
                    {
                        colorPick = true;
                    }
                    break;
                }
            }

            if (subViewLoadId[viewIndex] != e.LoadingTaskId)
            {
                // Should never comes here!
                Tizen.Log.Error("NUITest", $"{viewIndex}'th loadId {subViewLoadId[viewIndex]} not matched with callback input {e.LoadingTaskId}!!\n");
                return;
            }
            if (e.PixelBuffers == null || e.PixelBuffers.Count == 0 || e.PixelBuffers[0] == null)
            {
                Tizen.Log.Info("NUITest", $"Load Fail {viewIndex}'th loadId {subViewLoadId[viewIndex]}\n");

                subViewLoadId[viewIndex] = InvalidLoadId;
                return;
            }

            PixelBuffer pixelBuffer = e.PixelBuffers[0];

            // Copy the pixelData if we need to color picking.
            PixelData pixelData = colorPick ? pixelBuffer.CreatePixelData() : PixelBuffer.Convert(pixelBuffer);

            var width = pixelData.GetWidth();
            var height = pixelData.GetHeight();
            var pixelFormat = pixelData.GetPixelFormat();
            Tizen.Log.Info("NUITest", $"Complete {viewIndex}'th loadId {subViewLoadId[viewIndex]} : {width}x{height} with format {pixelFormat}\n");

            subViewLoadId[viewIndex] = InvalidLoadId;

            Texture texture = new Texture(TextureType.TEXTURE_2D, pixelFormat, width, height);
            texture.Upload(pixelData);

            subViewTexture[viewIndex]?.Dispose();
            subViewTextureSet[viewIndex].SetTexture(0u, texture);
            subViewTexture[viewIndex] = texture;

            if(colorPick)
            {
                // We need to create new class due to the PixelBuffer become invalidated after callback finished.
                RequestPaletteGeneration(new PixelBuffer(pixelBuffer));
            }
        }

        private async void RequestPaletteGeneration(PixelBuffer pixelBuffer)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Task<Palette> task = Palette.GenerateAsync(pixelBuffer);
            var palette = await task;
            timer.Stop();
            Tizen.Log.Info("NUITest", $"Palette time spend {timer.ElapsedMilliseconds} ms\n");

            ShowPaletteInfo(palette);
        }

        private void ShowPaletteInfo(Palette palette)
        {
            paletteInfoRoot?.DisposeRecursively();
            paletteInfoRoot = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    CellPadding = new Size2D(10, 10),
                },
                PivotPoint = Position.PivotPointBottomLeft,
                ParentOrigin = Position.ParentOriginBottomLeft,
                PositionUsesPivotPoint = true,

                BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.8f),
            };

            CreateSwatchLabel("Dominant", palette.GetDominantSwatch());
            CreateSwatchLabel("LightVibrant", palette.GetLightVibrantSwatch());
            CreateSwatchLabel("Vibrant", palette.GetVibrantSwatch());
            CreateSwatchLabel("DarkVibrant", palette.GetDarkVibrantSwatch());
            CreateSwatchLabel("LightMuted", palette.GetLightMutedSwatch());
            CreateSwatchLabel("Muted", palette.GetMutedSwatch());
            CreateSwatchLabel("DarkMuted", palette.GetDarkMutedSwatch());

            root.Add(paletteInfoRoot);
        }

        private void CreateSwatchLabel(string title, Palette.Swatch swatch)
        {
            var swatchInfo = new View()
            {
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    CellPadding = new Size2D(5, 5),
                },
            };

            var titleLabel = new TextLabel()
            {
                Text = title,
            };
            swatchInfo.Add(titleLabel);

            var bodyLabel = new TextLabel()
            {
                Text = " Invalid",
            };
            swatchInfo.Add(bodyLabel);

            if (swatch != null)
            {
                Color color = swatch.GetRgb();
                Color titleColor = swatch.GetTitleTextColor();
                Color bodyColor = swatch.GetBodyTextColor();
                bodyLabel.Text = " RGB(" + (int)(color.R * 255) + " " + (int)(color.G * 255) + " " + (int)(color.B * 255) + ")";

                swatchInfo.BackgroundColor = color;
                titleLabel.TextColor = titleColor;
                bodyLabel.TextColor = bodyColor;
            }

            paletteInfoRoot.Add(swatchInfo);
        }

        private Geometry GenerateGeometry()
        {
            if (geometry == null)
            {
                using PropertyBuffer vertexBuffer = CreateQuadPropertyBuffer();
                geometry = new Geometry();
                geometry.AddVertexBuffer(vertexBuffer);
                geometry.SetType(Geometry.Type.TRIANGLE_STRIP);
            }

            return geometry;
        }

        private Shader GenerateShader()
        {
            if (shader == null)
            {
                shader = new Shader(VERTEX_SHADER, FRAGMENT_SHADER, "AsyncImageLoaderTest");
            }
            return shader;
        }

        private Renderable GenerateRenderable()
        {
            Renderable renderable = new Renderable()
            {
                Geometry = GenerateGeometry(),
                Shader = GenerateShader(),
                TextureSet = new TextureSet(),
            };

            // Set some invalid texture so we can ignore rendering.
            Texture texture = new Texture(TextureType.TEXTURE_2D, PixelFormat.RGBA8888, 1u, 1u);
            renderable.TextureSet.SetTexture(0u, texture);

            return renderable;
        }
    }
}
