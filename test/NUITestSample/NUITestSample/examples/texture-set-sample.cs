using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace TextureSetSample
{
    class Example: NUIApplication
    {
		[StructLayout(LayoutKind.Sequential)]
        public struct Vec2
        {
            float x;
            float y;
            public Vec2(float xIn, float yIn)
            {
                x = xIn;
                y = yIn;
            }
        }

        public struct Vertex
        {
            public Vec2 position;
            public Vec2 texCoord;
            public Vertex(Vec2 p, Vec2 t)
            {
                position = p;
                texCoord = t;
            }
        };

        private List<string> Image_Path = new List<string>();
        private string ResourcePath = "/home/owner/apps_rw/NUISamples/res/";


        public Example() : base()
        {
            Tizen.Log.Fatal("NUISamples", "TextureSetSample constructor");
        }

        protected override void OnCreate()
        {
            Tizen.Log.Fatal("NUISamples", "TextureSetSample OnCreate");
            base.OnCreate();
            Initialize();
        }
		public static byte[] Struct2Bytes(Vertex[] obj)
		{
			int size = Marshal.SizeOf(obj);
			byte[] bytes = new byte[size];
			IntPtr ptr = Marshal.AllocHGlobal(size);
			Marshal.StructureToPtr(obj, ptr, false);
			Marshal.Copy(ptr, bytes, 0, size);
			Marshal.FreeHGlobal(ptr);
			return bytes;
		}

        public void Initialize()
        {
            const string VERTEX_SHADER = "" +
                "attribute mediump vec2 aPosition;\n" +
                "attribute   highp vec2 aTexCoord;\n" +
                "varying   mediump vec2 vTexCoord;\n" +
                "uniform   mediump mat4 uMvpMatrix;\n" +
                "uniform   mediump vec3 uSize;\n" +
                "uniform   lowp    vec4 uFadeColor;\n" +
                "\n" +
                "void main()\n" +
                "{\n" +
                    "mediump vec4 vertexPosition = vec4(aPosition, 0.0, 1.0);\n" +
                    "vertexPosition.xyz *= uSize;\n" +
                    "vertexPosition = uMvpMatrix * vertexPosition;\n" +
                    "vTexCoord = aTexCoord;\n" +
                    "gl_Position = vertexPosition;\n" +
                "}\n";

            const string FRAGMENT_SHADER =
                "varying mediump vec2 vTexCoord;\n" +
                "uniform    lowp vec4 uColor;\n" +
                "uniform    sampler2D sTexture;\n" +
                "uniform    lowp vec4 uFadeColor;\n" +
                "\n" +
                "void main()\n" +
                "{\n" +
                    "gl_FragColor = texture2D(sTexture, vTexCoord) * uColor * uFadeColor;\n" +
                "}\n";

            Tizen.Log.Fatal("NUISamples", "TextureSetSample Initialize");
            Image_Path.Add(ResourcePath + "/images/gallery-0.jpg");
            Image_Path.Add(ResourcePath + "/images/gallery-1.jpg");
            Image_Path.Add(ResourcePath + "/images/gallery-2.jpg");
            Image_Path.Add(ResourcePath + "/images/gallery-3.jpg");
            Image_Path.Add(ResourcePath + "/images/gallery-4.jpg");
            Image_Path.Add(ResourcePath + "/images/gallery-5.jpg");

            Vertex vertex1 = new Vertex(new Vec2(-0.5f, -0.5f), new Vec2(0.0f, 0.0f));
            Vertex vertex2 = new Vertex(new Vec2(0.5f, -0.5f), new Vec2(1.0f, 0.0f));
            Vertex vertex3 = new Vertex(new Vec2(-0.5f, 0.5f), new Vec2(0.0f, 1.0f));
            Vertex vertex4 = new Vertex(new Vec2(0.5f, 0.5f), new Vec2(1.0f, 1.0f));

            Vertex[] texturedQuadData = new Vertex[4] { vertex1, vertex2, vertex3, vertex4 };

            int length = Marshal.SizeOf(vertex1);
            IntPtr pA = Marshal.AllocHGlobal(length * 4);
            for (int i = 0; i < 4; i++)
            {
                Marshal.StructureToPtr(texturedQuadData[i], pA + i * length, true);
            }

            PropertyMap vertexFormat = new PropertyMap();
            vertexFormat.Add("aPosition", new PropertyValue((int)PropertyType.Vector2));
            vertexFormat.Add("aTexCoord", new PropertyValue((int)PropertyType.Vector2));

            PropertyBuffer vertexBuffer = new PropertyBuffer(vertexFormat);
            vertexBuffer.SetData(pA, 4u);

            /* Create geometry */
            Geometry geometry = new Geometry();
            geometry.AddVertexBuffer(vertexBuffer);
            geometry.SetType(Geometry.Type.TRIANGLE_STRIP);

            Shader shader = new Shader(VERTEX_SHADER, FRAGMENT_SHADER);

            Renderer renderer =  CreateRenderer(0, geometry, shader);

            //Create the actor
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            View view = new View()
            {
                Size2D = new Size2D(800, 800),
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                BackgroundColor = Color.Black,
            };
            view.AddRenderer(renderer);
            window.Add(view);
        }

        private Renderer CreateRenderer(int index, Geometry geometry, Shader shader)
        {
            Renderer renderer = new Renderer(geometry, shader);
            string imagePath = Image_Path[index];
            Size2D size = new Size2D(500, 500);

            PixelBuffer pb =  ImageLoading.LoadImageFromFile(imagePath, size, FittingModeType.ShrinkToFit, SamplingModeType.Box);

            Tizen.Log.Fatal("NUISamples", "width: "+ pb.GetWidth() + ", height: " + pb.GetHeight());
            Texture texture = new Texture(TextureType.TEXTURE_2D, pb.GetPixelFormat(), pb.GetWidth(), pb.GetHeight());
            PixelData pd = PixelBuffer.Convert(pb);
            texture.Upload(pd);

            TextureSet textureSet = new TextureSet();
            textureSet.SetTexture(0u, texture);
            renderer.SetTextures(textureSet);
            renderer.DepthIndex = 0;
            renderer.BlendMode = 0;
            //renderer.SetProperty(Renderer.Property.BLEND_MODE, new Tizen.NUI.PropertyValue(false));
            return renderer;
        }
    }
}
