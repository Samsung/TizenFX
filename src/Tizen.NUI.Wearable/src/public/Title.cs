/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Use it to set the title. this has a fadeout effect.
    /// You can also set the color of the fadeout.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Title : TextLabel
    {
        private const string VERTEX_SHADER =
                        "attribute mediump vec2 aPosition;\n" +
                        "varying mediump vec2 vTexCoord;\n" +
                        "uniform highp mat4 uMvpMatrix;\n" +
                        "uniform mediump vec3 uSize;\n" +
                        "varying mediump vec2 sTexCoordRect;\n" +
                        "void main()\n" +
                        "{\n" +
                        "   gl_Position = uMvpMatrix * vec4(aPosition * uSize.xy, 0.0, 1.0);\n" +
                        "   vTexCoord = aPosition + vec2(0.5);\n" +
                        "}\n";

        private const string FRAGMENT_SHADER =
                        "uniform lowp vec4 uColor;\n" +
                        "varying mediump vec2 vTexCoord;\n" +
                        "uniform sampler2D sTexture;\n" +
                        "void main()\n" +
                        "{\n" +
                        "   gl_FragColor = texture2D(sTexture, vTexCoord) * uColor;\n" +
                        "}\n";

        private ImageView leftImage = null;
        private ImageView rightImage = null;
        private Geometry geometry = null;
        private Shader shader = null;
        private Renderer leftRenderer = null;
        private Renderer rightRenderer = null;
        private Color fadeOutColor;
        private bool isFadeOutColorSet = false;
        private int fadeOutWidth = 32; // default size

        /// <summary>
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        static Title() { }

        /// <summary>
        /// Construct Title with null.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Title() : base()
        {
            Initialize();
        }

        /// <summary>
        /// The constructor of the Title class with specific Style.
        /// </summary>
        /// <param name="textLabelStyle">Construct Style</param>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Title(TextLabelStyle textLabelStyle) : base(textLabelStyle)
        {
            Initialize();
        }

        /// <summary>
        /// Constructor of the Title class with special style.
        /// </summary>
        /// <param name="style"> style name </param>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Title(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Sets the start and end color of the fadeout.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color FadeOutColor
        {
            get
            {
                return fadeOutColor;
            }
            set
            {
                fadeOutColor = value;
                isFadeOutColorSet = true;
                UpdateImage();
            }
        }

        /// <summary>
        /// Gets or Sets the width of the fadeout effect.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int FadeOutWidth
        {
            get
            {
                return fadeOutWidth;
            }
            set
            {
                fadeOutWidth = value;
                UpdateImage();
            }
        }

        /// <summary>
        /// Dispose Title.
        /// </summary>
        /// <param name="type">dispose types.</param>
        /// <since_tizen> 8 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (null != leftImage)
                {
                    leftImage.Unparent();
                    leftImage.Dispose();
                    leftImage = null;
                }
                if (null != rightImage)
                {
                    rightImage.Unparent();
                    rightImage.Dispose();
                    rightImage = null;
                }
            }
            base.Dispose(type);
        }

        private void UpdateImage()
        {
            leftImage.SizeWidth = fadeOutWidth;
            rightImage.SizeWidth = fadeOutWidth;

            if (fadeOutWidth > 0)
            {
                Color startColor = new Color(fadeOutColor.R, fadeOutColor.G, fadeOutColor.B, 0.6F);
                Color endColor = new Color(fadeOutColor.R, fadeOutColor.G, fadeOutColor.B, 0.0F);

                TextureSet leftTextureSet = CreateTexture(startColor, endColor);
                TextureSet rightTextureSet = CreateTexture(endColor, startColor);

                leftImage.RemoveRenderer(leftRenderer);
                rightImage.RemoveRenderer(rightRenderer);

                if (this.EnableAutoScroll)
                {
                    leftRenderer.SetTextures(leftTextureSet);
                    rightRenderer.SetTextures(rightTextureSet);

                    leftImage.AddRenderer(leftRenderer);
                    rightImage.AddRenderer(rightRenderer);
                }
                else if (this.TextDirection == TextDirection.LeftToRight)
                {
                    rightRenderer.SetTextures(rightTextureSet);
                    rightImage.AddRenderer(rightRenderer);
                }
                else
                {
                    leftRenderer.SetTextures(leftTextureSet);
                    leftImage.AddRenderer(leftRenderer);
                }
            }

            this.Ellipsis = false;
            this.HorizontalAlignment = HorizontalAlignment.Center;
            this.VerticalAlignment = VerticalAlignment.Center;
        }

        private void Initialize()
        {
            leftImage = new ImageView();
            leftImage.PositionUsesPivotPoint = true;
            leftImage.ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft;
            leftImage.PivotPoint = Tizen.NUI.PivotPoint.TopLeft;
            leftImage.WidthResizePolicy = ResizePolicyType.FillToParent;
            leftImage.HeightResizePolicy = ResizePolicyType.FillToParent;
            this.Add(leftImage);

            rightImage = new ImageView();
            rightImage.PositionUsesPivotPoint = true;
            rightImage.ParentOrigin = Tizen.NUI.ParentOrigin.TopRight;
            rightImage.PivotPoint = Tizen.NUI.PivotPoint.TopRight;
            rightImage.WidthResizePolicy = ResizePolicyType.FillToParent;
            rightImage.HeightResizePolicy = ResizePolicyType.FillToParent;
            this.Add(rightImage);

            geometry = CreateQuadGeometry();

            shader = new Shader(VERTEX_SHADER, FRAGMENT_SHADER);

            leftRenderer = new Renderer(geometry, shader);

            rightRenderer = new Renderer(geometry, shader);

            fadeOutColor = this.BackgroundColor;

            PropertyChanged += TitlePropertyChanged;

            UpdateImage();
        }

        private void TitlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (isFadeOutColorSet == false  && e.PropertyName.Equals("BackgroundColor") )
            {
                fadeOutColor = this.BackgroundColor;
                UpdateImage();
            }
        }

        private TextureSet CreateTexture(Vector4 color1, Vector4 color2)
        {
            TextureSet textureSet = new TextureSet();
            const int width = 2;
            const int height = 1;
            uint size = width * height * 4;
            byte[] pixelBuffer = new byte[size];
            pixelBuffer[0] = (byte)(0xFF * color1.X);
            pixelBuffer[1] = (byte)(0xFF * color1.Y);
            pixelBuffer[2] = (byte)(0xFF * color1.Z);
            pixelBuffer[3] = (byte)(0xFF * color1.W);
            pixelBuffer[4] = (byte)(0xFF * color2.X);
            pixelBuffer[5] = (byte)(0xFF * color2.Y);
            pixelBuffer[6] = (byte)(0xFF * color2.Z);
            pixelBuffer[7] = (byte)(0xFF * color2.W);

            PixelData pixelData = new PixelData(pixelBuffer, size, width, height, PixelFormat.RGBA8888, PixelData.ReleaseFunction.DeleteArray );
            Texture texture = new Texture(TextureType.TEXTURE_2D, PixelFormat.RGBA8888, width, height);
            texture.Upload(pixelData);

            textureSet.SetTexture(0u, texture);
            return textureSet;
        }

        private PropertyBuffer CreatePropertyBuffer()
        {
            PropertyMap vertexFormat = new PropertyMap();
            vertexFormat.Add("aPosition", new PropertyValue((int)PropertyType.Vector2));
            PropertyBuffer vertexBuffer = new PropertyBuffer(vertexFormat);
            return vertexBuffer;
        }

        private struct Vec2
        {
            float x;
            float y;
            public Vec2(float xIn, float yIn)
            {
                x = xIn;
                y = yIn;
            }
        }

        private struct TexturedQuadVertex
        {
            public Vec2 position;
        };

        private byte[] Struct2Bytes(TexturedQuadVertex[] obj)
        {
            int size = Marshal.SizeOf(obj);
            byte[] bytes = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(obj, ptr, false);
            Marshal.Copy(ptr, bytes, 0, size);
            Marshal.FreeHGlobal(ptr);
            return bytes;
        }

        private Geometry CreateQuadGeometry()
        {
            PropertyBuffer vertexData = CreatePropertyBuffer();

            TexturedQuadVertex vertex1 = new TexturedQuadVertex();
            TexturedQuadVertex vertex2 = new TexturedQuadVertex();
            TexturedQuadVertex vertex3 = new TexturedQuadVertex();
            TexturedQuadVertex vertex4 = new TexturedQuadVertex();
            vertex1.position = new Vec2(-0.5f, -0.5f);
            vertex2.position = new Vec2(-0.5f, 0.5f);
            vertex3.position = new Vec2(0.5f, -0.5f);
            vertex4.position = new Vec2(0.5f, 0.5f);


            TexturedQuadVertex[] texturedQuadVertexData = new TexturedQuadVertex[4] { vertex1, vertex2, vertex3, vertex4 };

            int lenght = Marshal.SizeOf(vertex1);
            IntPtr pA = Marshal.AllocHGlobal(lenght * 4);

            for (int i = 0; i < 4; i++)
            {
                Marshal.StructureToPtr(texturedQuadVertexData[i], pA + i * lenght, true);
            }
            vertexData.SetData(pA, 4);

            Geometry geometry = new Geometry();
            geometry.AddVertexBuffer(vertexData);
            geometry.SetType(Geometry.Type.TRIANGLE_STRIP);
            return geometry;
        }

    }
}
