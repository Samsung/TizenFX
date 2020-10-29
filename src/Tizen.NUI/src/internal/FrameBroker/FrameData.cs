/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
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
 */

using System;
using Tizen.NUI.BaseComponents;
using Tizen.Applications;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    /// <summary>
    /// Represents the Frame Data.
    /// </summary>
    internal class FrameData
    {
        private const string LogTag = "NUI";
        private readonly IntPtr _frame;
        private int _fd = -1;
        private uint _size = 0;
        private ImageView _image = null;

        private Renderer renderer;
        private TextureSet textureSet;

        internal FrameData(IntPtr frame)
        {
            _frame = frame;
        }

        private Shader CreateShader()
        {
            string vertex_shader =
                "attribute mediump vec2 aPosition;\n" +
                "varying mediump vec2 vTexCoord;\n" +
                "uniform highp mat4 uMvpMatrix;\n" +
                "uniform mediump vec3 uSize;\n" +
                "varying mediump vec2 sTexCoordRect;\n" +
                "void main()\n" +
                "{\n" +
                "gl_Position = uMvpMatrix * vec4(aPosition * uSize.xy, 0.0, 1.0);\n" +
                "vTexCoord = aPosition + vec2(0.5);\n" +
                "}\n";

            string fragment_shader =
                "#extension GL_OES_EGL_image_external:require\n" +
                "uniform lowp vec4 uColor;\n" +
                "varying mediump vec2 vTexCoord;\n" +
                "uniform samplerExternalOES sTexture;\n" +
                "void main()\n" +
                "{\n" +
                "gl_FragColor = texture2D(sTexture, vTexCoord) * uColor;\n" +
                "}\n";

            return new Shader(vertex_shader, fragment_shader);
        }

        [StructLayout(LayoutKind.Sequential)]
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

        private IntPtr RectangleDataPtr()
        {
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

            return pA;
        }

        private Geometry CreateQuadGeometry()
        {
            /* Create Property buffer */
            PropertyMap vertexFormat = new PropertyMap();
            vertexFormat.Add("aPosition", new PropertyValue((int)PropertyType.Vector2));

            PropertyBuffer vertexBuffer = new PropertyBuffer(vertexFormat);
            vertexBuffer.SetData(RectangleDataPtr(), 4);


            Geometry geometry = new Geometry();
            geometry.AddVertexBuffer(vertexBuffer);
            geometry.SetType(Geometry.Type.TRIANGLE_STRIP);

            return geometry;
        }

        /// <summary>
        /// Gets the image view.
        /// </summary>
        internal ImageView Image
        {
            get
            {
                if (_image == null)
                {
                    _image = new ImageView();
                    renderer = new Renderer(CreateQuadGeometry(), CreateShader());
                    textureSet = new TextureSet();
                }
                switch (Type)
                {
                    case FrameType.RemoteSurfaceTbmSurface:
                        if (TbmSurface == null)
                        {
                            return null;
                        }
                        textureSet.SetTexture(0, new Texture(TbmSurface));
                        renderer.SetTextures(textureSet);
                        _image.AddRenderer(renderer);
                        break;
                    default:
                        break;
                }

                return _image;
            }
        }

        /// <summary>
        /// Checks whether the direction of the frame is forward or not.
        /// </summary>
        internal bool DirectionForward
        {
            get
            {
                Interop.FrameBroker.FrameDirection direction = Interop.FrameBroker.FrameDirection.Backward + 1;
                Interop.FrameBroker.ErrorCode err = Interop.FrameBroker.GetDirection(_frame, out direction);
                if (err != Interop.FrameBroker.ErrorCode.None)
                {
                    Log.Error(LogTag, "Failed to get direction");
                }
                return (direction == Interop.FrameBroker.FrameDirection.Forward);
            }
        }

        /// <summary>
        /// Gets the extra data.
        /// </summary>
        internal Bundle Extra
        {
            get
            {
                SafeBundleHandle safeBundle;
                Interop.FrameBroker.ErrorCode err = Interop.FrameBroker.GetExtraData(_frame, out safeBundle);
                if (err != Interop.FrameBroker.ErrorCode.None)
                {
                    Log.Error(LogTag, "Failed to get extra data");
                    return null;
                }
                return new Bundle(safeBundle);
            }
        }

        /// <summary>
        /// Enumeration for the frame type.
        /// </summary>
        internal enum FrameType
        {
            /// <summary>
            /// The tbm surface of the remote surface.
            /// </summary>
            RemoteSurfaceTbmSurface,

            /// <summary>
            /// The image file of the remote surface.
            /// </summary>
            RemoteSurfaceImageFile,

            /// <summary>
            /// The image of the splash screen.
            /// </summary>
            SplashScreenImage,

            /// <summary>
            /// The edje of the splash screen.
            /// </summary>
            SPlashScreenEdje,
        }

        /// <summary>
        /// Enumeration for the direction of the frame.
        /// </summary>
        internal enum FrameDirection
        {
            /// <summary>
            /// The direction that is from the caller to the other application.
            /// </summary>
            Forward,

            /// <summary>
            /// The direction that is from the other application to the caller.
            /// </summary>
            Backward,
        }

        /// <summary>
        /// Gets the tbm surface of the remote surface.
        /// </summary>
        /// <value>
        /// The TbmSurface type is tbm_surface_h.
        /// </value>
        internal IntPtr TbmSurface
        {
            get
            {
                IntPtr tbmSurface = IntPtr.Zero;
                Interop.FrameBroker.ErrorCode err = Interop.FrameBroker.GetTbmSurface(_frame, out tbmSurface);

                if (err != Interop.FrameBroker.ErrorCode.None)
                {
                    Log.Error(LogTag, "Failed to get tbm surface");
                }
                return tbmSurface;
            }
        }

        /// <summary>
        /// Gets the file descriptor of the image file of the remote surface.
        /// </summary>
        internal int Fd
        {
            get
            {
                if (_fd != -1)
                    return _fd;

                Interop.FrameBroker.ErrorCode err = Interop.FrameBroker.GetImageFile(_frame, out _fd, out _size);
                if (err != Interop.FrameBroker.ErrorCode.None)
                {
                    Log.Error(LogTag, "Failed to get fd of image file");
                }
                return _fd;
            }
        }

        /// <summary>
        /// Gets the size of the image file of the remote surface.
        /// </summary>
        internal uint Size
        {
            get
            {
                if (_size != 0)
                    return _size;

                Interop.FrameBroker.ErrorCode err = Interop.FrameBroker.GetImageFile(_frame, out _fd, out _size);
                if (err != Interop.FrameBroker.ErrorCode.None)
                {
                    Log.Error(LogTag, "Failed to get size of image file");
                }
                return _size;
            }
        }

        /// <summary>
        /// Gets the file path.
        /// </summary>
        internal string FilePath
        {
            get
            {
                string filePath = string.Empty;
                Interop.FrameBroker.ErrorCode err = Interop.FrameBroker.GetFilePath(_frame, out filePath);
                if (err != Interop.FrameBroker.ErrorCode.None)
                {
                    Log.Error(LogTag, "Failed to get file path");
                }
                return filePath;
            }
        }

        /// <summary>
        /// Gets the file group.
        /// </summary>
        internal string FileGroup
        {
            get
            {
                string fileGroup = string.Empty;
                Interop.FrameBroker.ErrorCode err = Interop.FrameBroker.GetFileGroup(_frame, out fileGroup);
                if (err != Interop.FrameBroker.ErrorCode.None)
                {
                    Log.Error(LogTag, "Failed to get file group");
                }
                return fileGroup;
            }
        }

        /// <summary>
        /// Gets the type of the frame.
        /// </summary>
        internal FrameType Type
        {
            get
            {
                Interop.FrameBroker.FrameType type = Interop.FrameBroker.FrameType.SplashScreenImage + 1;
                Interop.FrameBroker.ErrorCode err = Interop.FrameBroker.GetType(_frame, out type);
                if (err != Interop.FrameBroker.ErrorCode.None)
                {
                    Log.Error(LogTag, "Failed to get frame type");
                }
                return (FrameType)type;
            }
        }

        /// <summary>
        /// Gets the position X.
        /// </summary>
        internal int PositionX
        {
            get
            {
                int x = -1;
                Interop.FrameBroker.ErrorCode err = Interop.FrameBroker.GetPositionX(_frame, out x);
                if (err != Interop.FrameBroker.ErrorCode.None)
                {
                    Log.Error(LogTag, "Failed to get position X");
                }
                return x;
            }
        }

        /// <summary>
        /// Gets the position Y.
        /// </summary>
        internal int PositionY
        {
            get
            {
                int y = -1;
                Interop.FrameBroker.ErrorCode err = Interop.FrameBroker.GetPositionY(_frame, out y);
                if (err != Interop.FrameBroker.ErrorCode.None)
                {
                    Log.Error(LogTag, "Failed to get position Y");
                }
                return y;
            }
        }
    }
}
