using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class CircularText : IExample
    {
        private string VERSION_3_ES = "#version 300 es\n";

        private static readonly string VERTEX_SHADER =
                        "precision mediump float;\n"+
                        "in vec2 aPosition;\n"+
                        "in vec2 aTexCoord;\n"+
                        "out vec2 vUV;\n"+
                        "uniform vec3 uSize;\n"+
                        "uniform mat4 uMvpMatrix;\n"+
                        "void main()\n"+
                        "{\n"+
                        "  vec4 vertexPosition = vec4(aPosition, 0.0, 1.0);\n"+
                        "  vertexPosition.xyz *= uSize;\n"+
                        "  gl_Position = uMvpMatrix * vertexPosition;\n"+
                        "  vUV = aTexCoord;\n"+
                        "}\n";

        private static readonly string FRAGMENT_SHADER =
                        "precision mediump float;\n"+
                        "in vec2 vUV;\n"+
                        "out vec4 FragColor;\n"+
                        "uniform sampler2D sAlbedo;\n"+
                        "uniform vec4 uColor;\n"+
                        "void main()\n"+
                        "{\n"+
                        "  vec4 color = texture( sAlbedo, vUV );\n"+
                        "  FragColor = vec4( color.rgb, uColor.a * color.a );\n"+
                        "}\n";

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

        private struct TexturedQuadVertex
        {
            public Vec2 position;
            public Vec2 texCoord;
        };

        private Renderer CreateRenderer()
        {
            TexturedQuadVertex vertex1 = new TexturedQuadVertex();
            TexturedQuadVertex vertex2 = new TexturedQuadVertex();
            TexturedQuadVertex vertex3 = new TexturedQuadVertex();
            TexturedQuadVertex vertex4 = new TexturedQuadVertex();
            vertex1.position = new Vec2(-0.5f, -0.5f);
            vertex2.position = new Vec2( 0.5f, -0.5f);
            vertex3.position = new Vec2(-0.5f,  0.5f);
            vertex4.position = new Vec2( 0.5f,  0.5f);
            vertex1.texCoord = new Vec2( 0.0f,  0.0f);
            vertex2.texCoord = new Vec2( 1.0f,  0.0f);
            vertex3.texCoord = new Vec2( 0.0f,  1.0f);
            vertex4.texCoord = new Vec2( 1.0f,  1.0f);

            TexturedQuadVertex[] texturedQuadVertexData = new TexturedQuadVertex[4] { vertex1, vertex2, vertex3, vertex4 };

            PropertyMap property = new PropertyMap();
            property.Add("aPosition", new PropertyValue((int)PropertyType.Vector2));
            property.Add("aTexCoord", new PropertyValue((int)PropertyType.Vector2));
            PropertyBuffer vertexBuffer = new PropertyBuffer(property);

            const int vertexCount = 4;
            unsafe
            {
                float* pc = (float*)Marshal.UnsafeAddrOfPinnedArrayElement(texturedQuadVertexData, 0);
                IntPtr pA = new IntPtr(pc);
                vertexBuffer.SetData(pA, vertexCount);
            }

            Geometry geometry = new Geometry();
            geometry.AddVertexBuffer(vertexBuffer);
            geometry.SetType(Geometry.Type.TRIANGLE_STRIP);

            // Create the shader
            Shader shader = new Shader( VERSION_3_ES + VERTEX_SHADER, VERSION_3_ES + FRAGMENT_SHADER );

            // Create the renderer
            Renderer renderer = new Renderer( geometry, shader );

            return renderer;
        }

        private uint GetBytesPerPixel(PixelFormat pixelFormat)
        {
            switch (pixelFormat)
            {
                case PixelFormat.L8:
                case PixelFormat.A8:
                {
                return 1;
                }

                case PixelFormat.LA88:
                case PixelFormat.RGB565:
                case PixelFormat.RGBA4444:
                case PixelFormat.RGBA5551:
                case PixelFormat.BGR565:
                case PixelFormat.BGRA4444:
                case PixelFormat.BGRA5551:
                {
                return 2;
                }

                case PixelFormat.RGB888:
                {
                return 3;
                }

                case PixelFormat.RGB8888:
                case PixelFormat.BGR8888:
                case PixelFormat.RGBA8888:
                case PixelFormat.BGRA8888:
                {
                return 4;
                }
                default:
                return 4;
            }
            return 0;
        }

        TextureSet CreateTextureSet( RendererParameters textParameters, List<string> embeddedItems )
        {
            EmbeddedItemInfo[] embeddedItemLayout = new EmbeddedItemInfo[0];
            PixelBuffer pixelBuffer = TextUtils.Render( textParameters,  ref embeddedItemLayout );

            uint dstWidth = pixelBuffer.GetWidth();
            uint dstHeight = pixelBuffer.GetHeight();

            int index = 0;
            int length = embeddedItemLayout.Length;
            for(int i = 0; i < length; i++)
            {
                EmbeddedItemInfo itemLayout = embeddedItemLayout[i];
                int width = (int)itemLayout.Size.Width;
                int height = (int)itemLayout.Size.Height;

                int x = (int)itemLayout.Position.X;
                int y = (int)itemLayout.Position.Y;

                PixelBuffer itemPixelBuffer = ImageLoader.LoadImageFromFile(embeddedItems[index++]);

                if( itemPixelBuffer == null ) continue;

                itemPixelBuffer.Resize( (ushort)width, (ushort)height );
                itemPixelBuffer.Rotate( itemLayout.Angle );


                width = (int)itemPixelBuffer.GetWidth();
                height = (int)itemPixelBuffer.GetHeight();

                PixelFormat itemPixelFormat = itemPixelBuffer.GetPixelFormat();

                // Check if the item is out of the buffer.
                if( ( x + width < 0 ) ||
                    ( x > dstWidth ) ||
                    ( y < 0 ) ||
                    ( y - height > dstHeight ) )
                {
                    // The embedded item is completely out of the buffer.
                    continue;
                }

                // Crop if it exceeds the boundaries of the destination buffer.
                int layoutX = 0;
                int layoutY = 0;
                int cropX = 0;
                int cropY = 0;
                int newWidth = width;
                int newHeight = height;

                bool crop = false;

                if( 0 > x )
                {
                    newWidth += x;
                    cropX = Math.Abs( x );
                    crop = true;
                }
                else
                {
                    layoutX = x;
                }

                if( cropX + newWidth > dstWidth )
                {
                    crop = true;
                    newWidth -= (int)( ( cropX + newWidth ) - dstWidth );
                }

                layoutY = y;
                if( 0 > layoutY )
                {
                    newHeight += layoutY;
                    cropY = Math.Abs(layoutY);
                    crop = true;
                }

                if( cropY + newHeight > dstHeight )
                {
                    crop = true;
                    newHeight -= (int)( ( cropY + newHeight ) - dstHeight );
                }

                int uiCropX = cropX;
                int uiCropY = cropY;
                int uiNewWidth = newWidth;
                int uiNewHeight = newHeight;

                if( crop )
                {
                    itemPixelBuffer.Crop( (ushort)uiCropX, (ushort)uiCropY, (ushort)uiNewWidth, (ushort)uiNewHeight );
                }

                // Blend the item pixel buffer with the text's color according its blending mode.
                if( ColorBlendingMode.Multiply == itemLayout.ColorBlendingMode )
                {
                    PixelBuffer buffer = new PixelBuffer( (uint)uiNewWidth, (uint)uiNewHeight, itemPixelFormat );

                    IntPtr bufferIntPtr = buffer.GetBuffer();
                    IntPtr itemBufferIntPtr = itemPixelBuffer.GetBuffer();

                    uint bytesPerPixel = GetBytesPerPixel(itemPixelFormat);
                    uint size = (uint)(uiNewWidth * uiNewHeight * bytesPerPixel);


                    unsafe {
                        byte *bufferPtr = (byte *)bufferIntPtr.ToPointer();
                        byte *itemBufferPtr = (byte *)itemBufferIntPtr.ToPointer();

                        for (uint j = 0; j < size; j += bytesPerPixel)
                        {
                            *(bufferPtr + 0) = (byte)( ( *(itemBufferPtr + 0u) ) * textParameters.TextColor.R );
                            *(bufferPtr + 1) = (byte)( ( *(itemBufferPtr + 1u) ) * textParameters.TextColor.G );
                            *(bufferPtr + 2) = (byte)( ( *(itemBufferPtr + 2u) ) * textParameters.TextColor.B );
                            *(bufferPtr + 3) = (byte)( ( *(itemBufferPtr + 3u) ) * textParameters.TextColor.A );

                            itemBufferPtr += bytesPerPixel;
                            bufferPtr += bytesPerPixel;
                        }
                    }

                    itemPixelBuffer = buffer;
                }

                TextUtils.UpdateBuffer(itemPixelBuffer, pixelBuffer, (uint)layoutX, (uint)layoutY, true);
            }

            PixelData pixelData = PixelBuffer.Convert( pixelBuffer );

            Texture texture = new Texture( TextureType.TEXTURE_2D,
                                            pixelData.GetPixelFormat(),
                                            pixelData.GetWidth(),
                                            pixelData.GetHeight() );
            texture.Upload(pixelData);

            TextureSet textureSet = new TextureSet();
            textureSet.SetTexture( 0u, texture );

            return textureSet;

        }



        private View root;
        static string DEMO_IMAGE_DIR = CommonResource.GetDaliResourcePath() + "DaliDemo/";
        static string IMAGE1 = DEMO_IMAGE_DIR + "application-icon-1.png";
        static string IMAGE2 = DEMO_IMAGE_DIR + "application-icon-6.png";

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            root = new View()
            {
                Size = window.Size,
                BackgroundColor = Color.Yellow,
                ParentOrigin = ParentOrigin.TopLeft,
                PivotPoint = PivotPoint.TopLeft,
                PositionUsesPivotPoint = true,
            };
            window.Add(root);

            string image1 = "<item 'width'=26 'height'=26 'url'='" + IMAGE1 + "'/>";
            string image2 = "<item 'width'=26 'height'=26/>";

            RendererParameters textParameters = new RendererParameters();
            textParameters.Text = "Hello " + image1 + " world " + image2 + " this " + image1 + " is " + image2 + " a " + image1 + " demo " + image2 + " of " + image1 + " circular " + image2 + " text " + image1 + " width " + image2 + " icons.";
            textParameters.HorizontalAlignment = HorizontalAlignment.Center;
            textParameters.VerticalAlignment = VerticalAlignment.Center;
            textParameters.CircularAlignment = CircularAlignment.Center;
            textParameters.FontFamily = "SamsungUI";
            textParameters.FontWeight = "";
            textParameters.FontWidth = "";
            textParameters.FontSlant = "";
            textParameters.Layout = TextLayout.Circular;
            textParameters.TextColor = Color.Black;
            textParameters.FontSize = 25;
            textParameters.TextWidth = 360u;
            textParameters.TextHeight = 360u;
            textParameters.Radius = 180u;
            textParameters.BeginAngle = 15;
            textParameters.IncrementAngle = 360;
            textParameters.EllipsisEnabled = true;
            textParameters.MarkupEnabled = true;

            List<string> embeddedItems = new List<string>();
            embeddedItems.Add(IMAGE2);
            embeddedItems.Add(IMAGE2);
            embeddedItems.Add(IMAGE2);
            embeddedItems.Add(IMAGE2);
            embeddedItems.Add(IMAGE2);

            TextureSet textureSet = CreateTextureSet( textParameters, embeddedItems );
            Renderer renderer = CreateRenderer();
            renderer.SetTextures( textureSet );

            View actor = new View();
            actor.PivotPoint = PivotPoint.TopLeft;
            actor.ParentOrigin = ParentOrigin.TopLeft;
            actor.Position = new Position(0, 0, 0);
            actor.Size = new Size( 360, 360 );
            actor.Color = Color.White;

            actor.AddRenderer( renderer );
            root.Add(actor);
        }


        public void Deactivate()
        {
            if (root != null)
            {
                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
            }
        }
    }
}