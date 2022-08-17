using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Tizen.NUI.Binding;
using Tizen.NUI;
using System.Collections.Generic;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// DrawableView allows drawing with OpenGL. You can render to a Window directly.
    /// DrawableView creates a context, a surface, and a render thread.
    /// The render thread invokes user's callbacks.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DrawableView : View
    {
        public struct RenderCallbackInput
        {
            public Matrix mvp;
            public Matrix projection;
            public Size2D size;
            public Rectangle clippingBox;
            public int[] textureBindings;
        }

        private GLInitializeDelegate glInitializeCallback;
        private GLRenderFrameDelegate glRenderFrameCallback;
        private GLTerminateDelegate glTerminateCallback;
        private InternalGLRenderFrameDelegate internalRenderFrameCallback;
        private RenderCallbackInput renderCallbackInput = new RenderCallbackInput();

        /// <summary>
        /// Type of callback to initialize OpenGLES.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public delegate void GLInitializeDelegate();

        /// <summary>
        /// Type of callback to render the frame with OpenGLES APIs.
        /// If the return value of this callback is not 0, the eglSwapBuffers() will be called.
        /// </summary>
        /// <returns>The return value is not 0, the eglSwapBuffers() will be called.</returns>
        /// <since_tizen> 10 </since_tizen>
        public delegate int GLRenderFrameDelegate(RenderCallbackInput input);

        private delegate int InternalGLRenderFrameDelegate(global::System.IntPtr cPtr);

        /// <summary>
        /// Type of callback to clean up GL resource.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public delegate void GLTerminateDelegate();

        internal DrawableView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Creates an initialized GLView.
        /// </summary>
        /// <param name="colorFormat">The format of the color buffer</param>
        /// <since_tizen> 10 </since_tizen>
        public DrawableView(ColorFormat colorFormat) : this(Interop.GLView.New(0, (int)colorFormat), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Enumeration for the color format of the color buffer
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public enum ColorFormat
        {
            /// <summary>
            /// 8 red bits, 8 green bits, 8 blue bits
            /// </summary>
            RGB888 = 0,

            /// <summary>
            /// 8 red bits, 8 green bits, 8 blue bits, alpha 8 bits
            /// </summary>
            RGBA8888
        }

        /// <summary>
        /// Gets or sets the rendering mode of the GLView.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
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
        /// <since_tizen> 10 </since_tizen>
        public void RegisterGLCallbacks(GLInitializeDelegate glInit, GLRenderFrameDelegate glRenderFrame, GLTerminateDelegate glTerminate)
        {
            glInitializeCallback = glInit;
            HandleRef InitHandleRef = new HandleRef(this, Marshal.GetFunctionPointerForDelegate<Delegate>(glInitializeCallback));

            glRenderFrameCallback = glRenderFrame;
            internalRenderFrameCallback = OnRenderFrame;
            HandleRef RenderHandlerRef = new HandleRef(this, Marshal.GetFunctionPointerForDelegate<Delegate>(internalRenderFrameCallback));

            glTerminateCallback = glTerminate;
            HandleRef TerminateHandlerRef = new HandleRef(this, Marshal.GetFunctionPointerForDelegate<Delegate>(glTerminateCallback));

            Interop.GLView.GlViewRegisterGlCallbacks(SwigCPtr, InitHandleRef, RenderHandlerRef, TerminateHandlerRef);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private int OnRenderFrame(global::System.IntPtr cPtr)
        {
            if (glRenderFrameCallback != null)
            {
                renderCallbackInput.size = Size2D.GetSize2DFromPtr(Interop.GLView.GlViewGetRednerCallbackInputSize(cPtr));
                renderCallbackInput.mvp = Matrix.GetMatrixFromPtr(Interop.GLView.GlViewGetRednerCallbackInputMvp(cPtr));
                renderCallbackInput.projection = Matrix.GetMatrixFromPtr(Interop.GLView.GlViewGetRednerCallbackInputProjection(cPtr));
                renderCallbackInput.clippingBox = Rectangle.GetRectangleFromPtr(Interop.GLView.GlViewGetRednerCallbackInputClipplingBox(cPtr));
                SetTextureBindings(cPtr);

                return glRenderFrameCallback(renderCallbackInput);
            }
            return 0;
        }

        private void SetTextureBindings(global::System.IntPtr cPtr)
        {
            int bindingSize = 0;
            global::System.IntPtr arrayPtr = Interop.GLView.GlViewGetRednerCallbackInputTextureBindings(cPtr, ref bindingSize);
            if (bindingSize != 0)
            {
                int[] result = new int[bindingSize];
                System.Runtime.InteropServices.Marshal.Copy(arrayPtr, result, 0, bindingSize);
                renderCallbackInput.textureBindings = result;
            }
            else
            {
                renderCallbackInput.textureBindings = new int[0];
            }
        }

        public void BindTextureResources(List<Texture> textures)
        {
            unsafe
            {
                IntPtr unmanagedPointer = Marshal.AllocHGlobal(sizeof(IntPtr) * textures.Count);
                IntPtr[] texturesArray = new IntPtr[textures.Count];
                for (int i = 0; i < textures.Count; i++)
                {
                    texturesArray[i] = HandleRef.ToIntPtr(Texture.getCPtr(textures[i]));
                }
                System.Runtime.InteropServices.Marshal.Copy(texturesArray, 0, unmanagedPointer, textures.Count);

                Interop.GLView.GlViewBindTextureResources(SwigCPtr, unmanagedPointer, textures.Count);
                Marshal.FreeHGlobal(unmanagedPointer);
            }
        }

        /// <summary>
        /// Sets graphics configuration for the DrawableView
        /// </summary>
        /// <param name="depth">The flag of depth buffer. When the value is true, 24bit depth buffer is enabled.</param>
        /// <param name="stencil">The flag of stencil. When the value is true, 8bit stencil buffer is enabled.</param>
        /// <param name="msaa">The bit of MSAA</param>
        /// <param name="version">The GLES version</param>
        /// <returns>True if the config was successfully set, false otherwise.</returns>
        /// <since_tizen> 10 </since_tizen>
        public bool SetGraphicsConfig(bool depth, bool stencil, int msaa, GLESVersion version)
        {
            bool ret = Interop.GLView.GlViewSetGraphicsConfig(SwigCPtr, depth, stencil, msaa, (int)version);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Renders once more, even when paused.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public void RenderOnce()
        {
            Interop.GLView.GlViewRenderOnce(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
