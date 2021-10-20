using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Tizen.NUI.Binding;
using Tizen.NUI;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// GLView allows drawing with OpenGL.
    /// GLView creates a context, a surface, and a render thread.
    /// The render thread invokes user's callbacks.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class GLView : View
    {
        private GLInitializeDelegate glInitializeCallback;
        private GLRenderFrameDelegate glRenderFrameCallback;
        private GLTerminateDelegate glTerminateCallback;
        private ViewResizeDelegate viewResizeCallback;
        private ViewResizeDelegate internalResizeCallback;

        /// <summary>
        /// Type of callback to initialize OpenGLES.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void GLInitializeDelegate();

        /// <summary>
        /// Type of callback to render the frame with OpenGLES APIs.
        /// If the return value of this callback is not 0, the eglSwapBuffers() will be called.
        /// </summary>
        /// <returns>The return value is not 0, the eglSwapBuffers() will be called.</returns>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate int GLRenderFrameDelegate();

        /// <summary>
        /// Type of callback to clean up GL resource.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void GLTerminateDelegate();

        /// <summary>
        /// Type of resize callback
        /// </summary>
        /// <param name="w">The resized width size of the GLView</param>
        /// <param name="h">The resized height size of the GLView</param>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void ViewResizeDelegate(int w, int h);

        internal GLView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Creates an initialized GLView.
        /// </summary>
        /// <param name="colorFormat">The format of the color buffer</param>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GLView(ColorFormat colorFormat) : this(Interop.GLView.New((int)colorFormat), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Enumeration for the color format of the color buffer
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ColorFormat
        {
            /// <summary>
            /// 8 red bits, 8 green bits, 8 blue bits
            /// </summary>
            /// <since_tizen> 9 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            RGB888 = 0,

            /// <summary>
            /// 8 red bits, 8 green bits, 8 blue bits, alpha 8 bits
            /// </summary>
            /// <since_tizen> 9 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            RGBA8888
        }

        /// <summary>
        /// Gets or sets the rendering mode of the GLView.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GLRenderingMode RenderingMode
        {
            get
            {
                GLRenderingMode ret = (GLRenderingMode)Interop.GLView.GlViewGetRenderingMode(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            set
            {
                Interop.GLView.GlViewSetRenderingMode(SwigCPtr, (int)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Registers GL callback functions to render with OpenGL ES
        /// </summary>
        /// <param name="glInit">The callback function for GL initialization</param>
        /// <param name="glRenderFrame">The callback function to render the frame</param>
        /// <param name="glTerminate">The callback function to clean up GL resources</param>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterGLCallbacks(GLInitializeDelegate glInit, GLRenderFrameDelegate glRenderFrame, GLTerminateDelegate glTerminate)
        {
            glInitializeCallback = glInit;
            HandleRef InitHandleRef = new HandleRef(this, Marshal.GetFunctionPointerForDelegate<Delegate>(glInitializeCallback));

            glRenderFrameCallback = glRenderFrame;
            HandleRef RenderHandlerRef = new HandleRef(this, Marshal.GetFunctionPointerForDelegate<Delegate>(glRenderFrameCallback));

            glTerminateCallback = glTerminate;
            HandleRef TerminateHandlerRef = new HandleRef(this, Marshal.GetFunctionPointerForDelegate<Delegate>(glTerminateCallback));

            Interop.GLView.GlViewRegisterGlCallbacks(SwigCPtr, InitHandleRef, RenderHandlerRef, TerminateHandlerRef);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private void OnResized(int width, int height)
        {
            if (viewResizeCallback != null)
            {
                viewResizeCallback(width, height);
            }
        }

        /// <summary>
        /// Sets the resize callback to the GLView.
        /// When GLView is resized, the callback is invoked and it passes the width and height.
        /// </summary>
        /// <param name="callback">The resize callback function</param>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetResizeCallback(ViewResizeDelegate callback)
        {
            viewResizeCallback = callback;

            internalResizeCallback = OnResized;
            Interop.GLView.GlViewSetResizeCallback(SwigCPtr, new HandleRef(this, Marshal.GetFunctionPointerForDelegate<Delegate>(internalResizeCallback)));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets graphics configuration for the GLView
        /// </summary>
        /// <param name="depth">The flag of depth buffer. When the value is true, 24bit depth buffer is enabled.</param>
        /// <param name="stencil">The flag of stencil. When the value is true, 8bit stencil buffer is enabled.</param>
        /// <param name="msaa">The bit of MSAA</param>
        /// <param name="version">The GLES version</param>
        /// <returns>True if the config was successfully set, false otherwise.</returns>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SetGraphicsConfig(bool depth, bool stencil, int msaa, GLESVersion version)
        {
            bool ret = Interop.GLView.GlViewSetGraphicsConfig(SwigCPtr, depth, stencil, msaa, (int)version);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Renders once more, even when paused.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RenderOnce()
        {
            Interop.GLView.GlViewRenderOnce(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}