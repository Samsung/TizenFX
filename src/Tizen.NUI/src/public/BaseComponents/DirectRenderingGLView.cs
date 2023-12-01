using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// DirectRenderingGLView allows drawing with OpenGL. You can render to a Window directly.
    /// DirectRenderingGLView creates a context.
    /// </summary>
    /// <since_tizen> 11 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DirectRenderingGLView : View
    {
        /// <summary>
        /// The parameter of the RenderFrame Callback.
        /// It has data to render directly.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public class RenderCallbackInput
        {
            Matrix mvp;
            Matrix projection;
            Size2D size;
            Rectangle clippingBox;
            ReadOnlyCollection<int> textureBindings;

            public RenderCallbackInput(Matrix mvp, Matrix projection, Size2D size, Rectangle clippingBox, int[] textureBindings)
            {
                this.mvp = mvp;
                this.projection = projection;
                this.size = size;
                this.clippingBox = clippingBox;
                this.textureBindings = new ReadOnlyCollection<int>(textureBindings);
            }

            /// <summary>
            /// MVP matrix
            /// </summary>
            public Matrix Mvp
            {
                get { return mvp; }
            }

            /// <summary>
            /// Projection matrix
            /// </summary>
            public Matrix Projection
            {
                get { return projection; }
            }

            /// <summary>
            /// The size of the DirectRenderingGLView
            /// </summary>
            public Size2D Size
            {
                get { return size; }
            }

            /// <summary>
            /// The area of DirectRenderingGLView. You can use this for glScissor()
            /// </summary>
            public Rectangle ClippingBox
            {
                get { return clippingBox; }
            }

            /// <summary>
            /// Texture bindings
            /// </summary>
            public ReadOnlyCollection<int> TextureBindings
            {
                get { return textureBindings; }
            }
        }

        private GLInitializeDelegate glInitializeCallback;
        private GLRenderFrameDelegate glRenderFrameCallback;
        private GLTerminateDelegate glTerminateCallback;
        private InternalGLRenderFrameDelegate internalRenderFrameCallback;

        /// <summary>
        /// Type of callback to initialize OpenGLES.
        /// </summary>
        public delegate void GLInitializeDelegate();

        /// <summary>
        /// Type of callback to render the frame with OpenGLES APIs.
        /// If the return value of this callback is not 0, the eglSwapBuffers() will be called.
        /// </summary>
        /// <returns>The return value is not 0, the eglSwapBuffers() will be called.</returns>
        public delegate int GLRenderFrameDelegate(in RenderCallbackInput input);

        private delegate int InternalGLRenderFrameDelegate(global::System.IntPtr cPtr);

        /// <summary>
        /// Type of callback to clean up GL resource.
        /// </summary>
        public delegate void GLTerminateDelegate();

        internal DirectRenderingGLView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Creates an initialized DirectRenderingGLView.
        /// </summary>
        /// <param name="colorFormat">The format of the color buffer</param>
        public DirectRenderingGLView(ColorFormat colorFormat) : this(Interop.GLView.New(0, (int)colorFormat), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Enumeration for the color format of the color buffer
        /// </summary>
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
        /// Gets or sets the rendering mode of the DirectRenderingGLView.
        /// </summary>
        public GLRenderingMode RenderingMode
        {
            [SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations", Justification = "SWIG boilerplate, no exceptions are expected")]
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

        /// <summary>
        /// Binds textures to own context.
        /// You can get the bind IDs in RenderCallbackInput in the glRenderFrame callback.
        /// </summary>
        /// <param name="textures">List of Textures</param>
        /// <exception cref="OverflowException"> Thrown when length of textures list is overflow. </exception>
        public void BindTextureResources(List<Texture> textures)
        {
            unsafe
            {
                
                if (textures != null)
                {
                    int count = textures.Count;
                    int intptrBytes = checked(sizeof(IntPtr) * count);
                    if (intptrBytes>0)
                    {
                        IntPtr unmanagedPointer = Marshal.AllocHGlobal(intptrBytes);
                        IntPtr[] texturesArray = new IntPtr[count];
                        for (int i = 0; i < count; i++)
                        {
                            texturesArray[i] = HandleRef.ToIntPtr(Texture.getCPtr(textures[i]));
                        }
                        Marshal.Copy(texturesArray, 0, unmanagedPointer, count);

                        Interop.GLView.GlViewBindTextureResources(SwigCPtr, unmanagedPointer, count);
                        Marshal.FreeHGlobal(unmanagedPointer);
                    }
                }
            }
        }

        /// <summary>
        /// Sets graphics configuration for the DirectRenderingGLView
        /// </summary>
        /// <param name="depth">The flag of depth buffer. When the value is true, 24bit depth buffer is enabled.</param>
        /// <param name="stencil">The flag of stencil. When the value is true, 8bit stencil buffer is enabled.</param>
        /// <param name="msaa">The bit of MSAA</param>
        /// <param name="version">The GLES version</param>
        /// <returns>True if the config was successfully set, false otherwise.</returns>
        public bool SetGraphicsConfig(bool depth, bool stencil, int msaa, GLESVersion version)
        {
            bool ret = Interop.GLView.GlViewSetGraphicsConfig(SwigCPtr, depth, stencil, msaa, (int)version);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Renders once more, even when paused.
        /// </summary>
        public void RenderOnce()
        {
            Interop.GLView.GlViewRenderOnce(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private int OnRenderFrame(global::System.IntPtr cPtr)
        {
            if (glRenderFrameCallback != null)
            {
                Matrix mvp = Matrix.GetMatrixFromPtr(Interop.GLView.GlViewGetRednerCallbackInputMvp(cPtr));
                Matrix projection = Matrix.GetMatrixFromPtr(Interop.GLView.GlViewGetRednerCallbackInputProjection(cPtr));
                Size2D size = Size2D.GetSize2DFromPtr(Interop.GLView.GlViewGetRednerCallbackInputSize(cPtr));
                Rectangle clippingBox = Rectangle.GetRectangleFromPtr(Interop.GLView.GlViewGetRednerCallbackInputClipplingBox(cPtr));
                int[] textureBindings = GetTextureBindings(cPtr);

                RenderCallbackInput input = new RenderCallbackInput(mvp, projection, size, clippingBox, textureBindings);

                return glRenderFrameCallback(input);
            }
            return 0;
        }

        private static int[] GetTextureBindings(global::System.IntPtr cPtr)
        {
            int bindingSize = 0;
            global::System.IntPtr arrayPtr = Interop.GLView.GlViewGetRednerCallbackInputTextureBindings(cPtr, ref bindingSize);
            if (bindingSize != 0)
            {
                int[] result = new int[bindingSize];
                System.Runtime.InteropServices.Marshal.Copy(arrayPtr, result, 0, bindingSize);
                return result;
            }
            else
            {
                return Array.Empty<int>();
            }
        }
    }
}
