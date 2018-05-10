/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Runtime.InteropServices;

namespace ElmSharp
{
    /// <summary>
    /// This group discusses the functions that are used to do OpenGL rendering on Evas.
    /// Evas allows you use OpenGL to render to specially set up image objects (which act as render target surfaces).
    /// By default, Evas GL will use an OpenGL-ES 2.0 context and API set.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class EvasGL : IDisposable
    {
        /// <summary>
        /// EvasGL Config Struct
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public struct Config
        {
            /// <summary>
            /// Surface Color Format
            /// </summary>
            public ColorFormat ColorFormat;

            /// <summary>
            /// Surface Depth Bits
            /// </summary>
            public DepthBits DepthBits;

            /// <summary>
            /// Surface Stencil Bits
            /// </summary>
            public StencilBits StencilBits;

            /// <summary>
            /// Extra Surface Options
            /// </summary>
            public OptionsBits OptionsBits;

            /// <summary>
            /// Optional Surface MSAA Bits
            /// </summary>
            public MultisampleBits MultisampleBits;

            /// <summary>
            /// Special flag for OpenGL-ES 1.1 indirect rendering surfaces
            /// </summary>
            public ContextVersion GLESVersion;
        }

        /// <summary>
        /// Enumeration ColorFormat for EvasGL Config
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public enum ColorFormat
        {
            /// <summary>
            /// Opaque RGB surface
            /// </summary>
            Rgb888 = 0,

            /// <summary>
            /// RGBA surface with alpha
            /// </summary>
            Rgba8888 = 1,

            /// <summary>
            /// Special value for creating PBuffer surfaces without any attached buffer
            /// </summary>
            No_Fbo = 2
        }

        /// <summary>
        /// Enumeration DepthBits for EvasGL Config
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public enum DepthBits
        {
            /// <summary>
            /// None
            /// </summary>
            None = 0,

            /// <summary>
            /// 8 bits precision surface depth
            /// </summary>
            Bit8 = 1,

            /// <summary>
            /// 16 bits precision surface depth
            /// </summary>
            Bit16 = 2,

            /// <summary>
            /// 24 bits precision surface depth
            /// </summary>
            Bit24 = 3,

            /// <summary>
            /// 32 bits precision surface depth
            /// </summary>
            Bit32 = 4
        }

        /// <summary>
        /// Enumeration StencilBits for EvasGL Config
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public enum StencilBits
        {
            /// <summary>
            /// None
            /// </summary>
            None = 0,

            /// <summary>
            /// 1 bit precision for stencil buffer
            /// </summary>
            Bit1 = 1,

            /// <summary>
            /// 2 bit precision for stencil buffer
            /// </summary>
            Bit2 = 2,

            /// <summary>
            /// 4 bit precision for stencil buffer
            /// </summary>
            Bit4 = 3,

            /// <summary>
            /// 8 bit precision for stencil buffer
            /// </summary>
            Bit8 = 4,

            /// <summary>
            /// 16 bit precision for stencil buffer
            /// </summary>
            Bit16 = 5
        }

        /// <summary>
        /// Enumeration OptionsBits for EvasGL Config
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public enum OptionsBits
        {
            /// <summary>
            /// No extra options
            /// </summary>
            None = 0,

            /// <summary>
            /// Optional hint to allow rendering directly to the Evas window if possible
            /// </summary>
            Direct = (1 << 0),

            /// <summary>
            /// Force direct rendering even if the canvas is rotated.
            /// In that case, it is the application's role to rotate the contents of the Evas_GL view. @see evas_gl_rotation_get.
            /// </summary>
            ClientSideRotation = (1 << 1),

            /// <summary>
            /// If enabled, Evas GL pixel callback will be called by another thread instead of main thread.
            /// This option can enhance performance because Evas GL is worked with aynchronized call,
            /// but user must guarantee synchronization with pixel callback and main loop when using this flag.
            /// </summary>
            Thread = (1 << 2)
        }

        /// <summary>
        /// Enumeration MultisampleBits for EvasGL Config
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public enum MultisampleBits
        {
            /// <summary>
            /// No multisample rendering
            /// </summary>
            None = 0,

            /// <summary>
            /// MSAA with minimum number of samples
            /// </summary>
            Low = 1,

            /// <summary>
            /// MSAA with half the maximum number of samples
            /// </summary>
            Med = 2,

            /// <summary>
            /// MSAA with maximum allowed samples
            /// </summary>
            High = 3
        }

        /// <summary>
        /// Enumeration ContextVersion for EvasGL Config
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public enum ContextVersion
        {
            /// <summary>
            /// OpenGL-ES 1.x
            /// </summary>
            GLES1x = 1,

            /// <summary>
            /// OpenGL-ES 2.x is the default
            /// </summary>
            GLES2x = 2,

            /// <summary>
            /// OpenGL-ES 3.x (@b Since: 2.4)
            /// </summary>
            GLES3x = 3,

            /// <summary>
            /// Enable debug mode on this context (See GL_KHR_debug) (@b Since 4.0)
            /// </summary>
            Debug = 0x1000
        }

        IntPtr _evasGL = IntPtr.Zero;
        IntPtr _glContext = IntPtr.Zero;
        IntPtr _glConfig = IntPtr.Zero;
        IntPtr _glSurface = IntPtr.Zero;
        bool _isDisposed = false;

        /// <summary>
        /// Creates and initializes a new instance of the EvasGL class.
        /// </summary>
        /// <param name="parent">EvasObject parent that have Evas canvas to use</param>
        /// <since_tizen> 5 </since_tizen>
        public EvasGL(EvasObject parent)
        {
            _evasGL = Interop.Evas.evas_gl_new(Interop.Evas.evas_object_evas_get(parent.Handle));
            _glContext = Interop.Evas.evas_gl_context_create(_evasGL, IntPtr.Zero);
        }

        /// <summary>
        /// Destructor for the EvasGL class.
        /// </summary>
        /// /// <since_tizen> 5 </since_tizen>
        ~EvasGL()
        {
            Dispose(false);
        }

        /// <summary>
        /// Destroys the current object.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all the resources currently used by this instance.
        /// </summary>
        /// <param name="disposing">
        /// true if the managed resources should be disposed,
        /// otherwise false.
        /// </param>
        /// <since_tizen> 5 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
                return;

            DestroySurface();

            if (_evasGL != IntPtr.Zero)
            {
                if (_glContext != IntPtr.Zero)
                {
                    Interop.Evas.evas_gl_context_destroy(_evasGL, _glContext);
                    _glContext = IntPtr.Zero;
                }

                Interop.Evas.evas_gl_free(_evasGL);
                _evasGL = IntPtr.Zero;
            }

            _isDisposed = true;
        }

        /// <summary>
        /// Creates a new EvasGL Surface object for GL Rendering
        /// </summary>
        /// <param name="config">The pixel format and configuration of the rendering surface</param>
        /// <param name="w">The width of the surface</param>
        /// <param name="h">The height of the surface</param>
        /// <since_tizen> 5 </since_tizen>
        public void CreateSurface(Config config, int w, int h)
        {
            if (_glConfig != IntPtr.Zero || _glSurface != IntPtr.Zero)
            {
                DestroySurface();
            }

            _glConfig = Marshal.AllocHGlobal(Marshal.SizeOf(config));
            Marshal.StructureToPtr(config, _glConfig, false);

            _glSurface = Interop.Evas.evas_gl_surface_create(_evasGL, _glConfig, w, h);
        }

        /// <summary>
        /// Destroys an Evas GL Surface
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void DestroySurface()
        {
            if (_glConfig != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_glConfig);
                _glConfig = IntPtr.Zero;
            }

            if (_glSurface != IntPtr.Zero)
            {
                Interop.Evas.evas_gl_surface_destroy(_evasGL, _glSurface);
                _glSurface = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Fills in the Native Surface information from a given Evas GL surface
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public IntPtr GetNativeSurface()
        {
            if (_evasGL != IntPtr.Zero && _glSurface != IntPtr.Zero)
            {
                IntPtr ns = IntPtr.Zero;
                Interop.Evas.evas_gl_native_surface_get(_evasGL, _glSurface, out ns);
                return ns;
            }

            return IntPtr.Zero;
        }

        /// <summary>
        /// Sets the given context as the current context for the given surface
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public bool MakeCurrent()
        {
            if (_evasGL != IntPtr.Zero && _glSurface != IntPtr.Zero && _glContext != IntPtr.Zero)
            {
                return Interop.Evas.evas_gl_make_current(_evasGL, _glSurface, _glContext);
            }

            return false;
        }
    }
}