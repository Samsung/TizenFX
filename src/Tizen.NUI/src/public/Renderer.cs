/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    /// <summary>
    /// Renderer is a handle to an object used to show content by combining a Geometry, a TextureSet and a shader.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Renderer : Animatable
    {

        /// <summary>
        /// Create an instance of Renderer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Renderer(Geometry geometry, Shader shader) : this(Interop.Renderer.Renderer_New(Geometry.getCPtr(geometry), Shader.getCPtr(shader)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// Gets and Sets DepthIndex property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int DepthIndex
        {
            get
            {
                int temp = 0;
                Tizen.NUI.Object.GetProperty(swigCPtr, Renderer.Property.DEPTH_INDEX).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Renderer.Property.DEPTH_INDEX, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets and Sets FaceCullingMode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int FaceCullingMode
        {
            get
            {
                int temp = 0;
                Tizen.NUI.Object.GetProperty(swigCPtr, Renderer.Property.FACE_CULLING_MODE).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Renderer.Property.FACE_CULLING_MODE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets and Sets BlendMode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int BlendMode
        {
            get
            {
                int temp = 0;
                Tizen.NUI.Object.GetProperty(swigCPtr, Renderer.Property.BLEND_MODE).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Renderer.Property.BLEND_MODE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets and Sets BlendEquationRgb.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int BlendEquationRgb
        {
            get
            {
                int temp = 0;
                Tizen.NUI.Object.GetProperty(swigCPtr, Renderer.Property.BLEND_EQUATION_RGB).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Renderer.Property.BLEND_EQUATION_RGB, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets and Sets BlendEquationAlpha.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int BlendEquationAlpha
        {
            get
            {
                int temp = 0;
                Tizen.NUI.Object.GetProperty(swigCPtr, Renderer.Property.BLEND_EQUATION_ALPHA).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Renderer.Property.BLEND_EQUATION_ALPHA, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets and Sets BlendFactorSrcRgb.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int BlendFactorSrcRgb
        {
            get
            {
                int temp = 0;
                Tizen.NUI.Object.GetProperty(swigCPtr, Renderer.Property.BLEND_FACTOR_SRC_RGB).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Renderer.Property.BLEND_FACTOR_SRC_RGB, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets and Sets BlendFactorDestRgb.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int BlendFactorDestRgb
        {
            get
            {
                int temp = 0;
                Tizen.NUI.Object.GetProperty(swigCPtr, Renderer.Property.BLEND_FACTOR_DEST_RGB).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Renderer.Property.BLEND_FACTOR_DEST_RGB, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets and Sets BlendFactorSrcAlpha.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int BlendFactorSrcAlpha
        {
            get
            {
                int temp = 0;
                Tizen.NUI.Object.GetProperty(swigCPtr, Renderer.Property.BLEND_FACTOR_SRC_ALPHA).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Renderer.Property.BLEND_FACTOR_SRC_ALPHA, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets and Sets BlendFactorDestAlpha.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int BlendFactorDestAlpha
        {
            get
            {
                int temp = 0;
                Tizen.NUI.Object.GetProperty(swigCPtr, Renderer.Property.BLEND_FACTOR_DEST_ALPHA).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Renderer.Property.BLEND_FACTOR_DEST_ALPHA, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets and Sets BlendColor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 BlendColor
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                Tizen.NUI.Object.GetProperty(swigCPtr, Renderer.Property.BLEND_COLOR).Get(temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Renderer.Property.BLEND_COLOR, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets and Sets BlendPreMultipliedAlpha.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool BlendPreMultipliedAlpha
        {
            get
            {
                bool temp = false;
                Tizen.NUI.Object.GetProperty(swigCPtr, Renderer.Property.BLEND_PRE_MULTIPLIED_ALPHA).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Renderer.Property.BLEND_PRE_MULTIPLIED_ALPHA, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets and Sets IndexRangeFirst.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int IndexRangeFirst
        {
            get
            {
                int temp = 0;
                Tizen.NUI.Object.GetProperty(swigCPtr, Renderer.Property.INDEX_RANGE_FIRST).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Renderer.Property.INDEX_RANGE_FIRST, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets and Sets IndexRangeCount.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int IndexRangeCount
        {
            get
            {
                int temp = 0;
                Tizen.NUI.Object.GetProperty(swigCPtr, Renderer.Property.INDEX_RANGE_COUNT).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Renderer.Property.INDEX_RANGE_COUNT, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets and Sets DepthWriteMode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int DepthWriteMode
        {
            get
            {
                int temp = 0;
                Tizen.NUI.Object.GetProperty(swigCPtr, Renderer.Property.DEPTH_WRITE_MODE).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Renderer.Property.DEPTH_WRITE_MODE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets and Sets DepthFunction.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int DepthFunction
        {
            get
            {
                int temp = 0;
                Tizen.NUI.Object.GetProperty(swigCPtr, Renderer.Property.DEPTH_FUNCTION).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Renderer.Property.DEPTH_FUNCTION, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets and Sets DepthTestMode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int DepthTestMode
        {
            get
            {
                int temp = 0;
                Tizen.NUI.Object.GetProperty(swigCPtr, Renderer.Property.DEPTH_TEST_MODE).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Renderer.Property.DEPTH_TEST_MODE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets and Sets RenderMode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int RenderMode
        {
            get
            {
                int temp = 0;
                Tizen.NUI.Object.GetProperty(swigCPtr, Renderer.Property.RENDER_MODE).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Renderer.Property.RENDER_MODE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets and Sets StencilFunction.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int StencilFunction
        {
            get
            {
                int temp = 0;
                Tizen.NUI.Object.GetProperty(swigCPtr, Renderer.Property.STENCIL_FUNCTION).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Renderer.Property.STENCIL_FUNCTION, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets and Sets StencilFunctionMask.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int StencilFunctionMask
        {
            get
            {
                int temp = 0;
                Tizen.NUI.Object.GetProperty(swigCPtr, Renderer.Property.STENCIL_FUNCTION_MASK).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Renderer.Property.STENCIL_FUNCTION_MASK, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets and Sets StencilFunctionReference.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int StencilFunctionReference
        {
            get
            {
                int temp = 0;
                Tizen.NUI.Object.GetProperty(swigCPtr, Renderer.Property.STENCIL_FUNCTION_REFERENCE).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Renderer.Property.STENCIL_FUNCTION_REFERENCE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets and Sets StencilMask.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int StencilMask
        {
            get
            {
                int temp = 0;
                Tizen.NUI.Object.GetProperty(swigCPtr, Renderer.Property.STENCIL_MASK).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Renderer.Property.STENCIL_MASK, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets and Sets StencilOperationOnFail.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int StencilOperationOnFail
        {
            get
            {
                int temp = 0;
                Tizen.NUI.Object.GetProperty(swigCPtr, Renderer.Property.STENCIL_OPERATION_ON_FAIL).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Renderer.Property.STENCIL_OPERATION_ON_FAIL, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets and Sets StencilOperationOnZFail.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int StencilOperationOnZFail
        {
            get
            {
                int temp = 0;
                Tizen.NUI.Object.GetProperty(swigCPtr, Renderer.Property.STENCIL_OPERATION_ON_Z_FAIL).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Renderer.Property.STENCIL_OPERATION_ON_Z_FAIL, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets and Sets StencilOperationOnZPass property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int StencilOperationOnZPass
        {
            get
            {
                int temp = 0;
                Tizen.NUI.Object.GetProperty(swigCPtr, Renderer.Property.STENCIL_OPERATION_ON_Z_PASS).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Renderer.Property.STENCIL_OPERATION_ON_Z_PASS, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Sets the geometry to be used by this renderer.
        /// </summary>
        /// <param name="geometry">The geometry to be used by this renderer.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetGeometry(Geometry geometry)
        {
            Interop.Renderer.Renderer_SetGeometry(swigCPtr, Geometry.getCPtr(geometry));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the geometry used by this renderer.
        /// </summary>
        /// <returns>The geometry used by the renderer.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Geometry GetGeometry()
        {
            //to fix memory leak issue, match the handle count with native side.
            System.IntPtr cPtr = Interop.Renderer.Renderer_GetGeometry(swigCPtr);
            Geometry ret = this.GetInstanceSafely<Geometry>(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets effective range of indices to draw from bound index buffer.
        /// </summary>
        /// <param name="firstElement">The First element to draw.</param>
        /// <param name="elementsCount">The number of elements to draw.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetIndexRange(int firstElement, int elementsCount)
        {
            Interop.Renderer.Renderer_SetIndexRange(swigCPtr, firstElement, elementsCount);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the texture set to be used by this renderer.
        /// </summary>
        /// <param name="textureSet">The texture set to be used by this renderer.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetTextures(TextureSet textureSet)
        {
            Interop.Renderer.Renderer_SetTextures(swigCPtr, TextureSet.getCPtr(textureSet));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the texture set used by this renderer.
        /// </summary>
        /// <returns>The texture set used by the renderer.</returns>
        /// <since_tizen> 3 </since_tizen>
        public TextureSet GetTextures()
        {
            //to fix memory leak issue, match the handle count with native side.
            System.IntPtr cPtr = Interop.Renderer.Renderer_GetTextures(swigCPtr);
            HandleRef CPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            TextureSet ret = Registry.GetManagedBaseHandleFromNativePtr(CPtr.Handle) as TextureSet;
            if (cPtr != null && ret == null)
            {
                ret = new TextureSet(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            Interop.BaseHandle.delete_BaseHandle(CPtr);
            CPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the shader used by this renderer.
        /// </summary>
        /// <param name="shader">The shader to be used by this renderer.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetShader(Shader shader)
        {
            Interop.Renderer.Renderer_SetShader(swigCPtr, Shader.getCPtr(shader));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the shader used by this renderer.
        /// </summary>
        /// <returns>The shader used by the renderer.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Shader GetShader()
        {
            //to fix memory leak issue, match the handle count with native side.
            System.IntPtr cPtr = Interop.Renderer.Renderer_GetShader(swigCPtr);
            Shader ret = this.GetInstanceSafely<Shader>(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Renderer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal Renderer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.Renderer.Renderer_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Renderer.delete_Renderer(swigCPtr);
        }


        /// <since_tizen> 6.0 </since_tizen>
        /// This will be changed internal API after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class Ranges
        {
            /// <since_tizen> 6.0 </since_tizen>
            /// This will be changed internal API after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int BACKGROUND_EFFECT = Interop.Renderer.Renderer_Ranges_BACKGROUND_EFFECT_get();

            /// <since_tizen> 6.0 </since_tizen>
            /// This will be changed internal API after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int BACKGROUND = Interop.Renderer.Renderer_Ranges_BACKGROUND_get();

            /// <since_tizen> 6.0 </since_tizen>
            /// This will be changed internal API after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int CONTENT = Interop.Renderer.Renderer_Ranges_CONTENT_get();

            /// <since_tizen> 6.0 </since_tizen>
            /// This will be changed internal API after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int DECORATION = Interop.Renderer.Renderer_Ranges_DECORATION_get();

            /// <since_tizen> 6.0 </since_tizen>
            /// This will be changed internal API after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int FOREGROUND_EFFECT = Interop.Renderer.Renderer_Ranges_FOREGROUND_EFFECT_get();
        }

        /// <summary>
        /// Enumeration for instances of properties belonging to the Renderer class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Deprecated in API6; Will be removed in API9.")]
        public class Property
        {
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int DEPTH_INDEX = Interop.Renderer.Renderer_Property_DEPTH_INDEX_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int FACE_CULLING_MODE = Interop.Renderer.Renderer_Property_FACE_CULLING_MODE_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int BLEND_MODE = Interop.Renderer.Renderer_Property_BLEND_MODE_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int BLEND_EQUATION_RGB = Interop.Renderer.Renderer_Property_BLEND_EQUATION_RGB_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int BLEND_EQUATION_ALPHA = Interop.Renderer.Renderer_Property_BLEND_EQUATION_ALPHA_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int BLEND_FACTOR_SRC_RGB = Interop.Renderer.Renderer_Property_BLEND_FACTOR_SRC_RGB_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int BLEND_FACTOR_DEST_RGB = Interop.Renderer.Renderer_Property_BLEND_FACTOR_DEST_RGB_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int BLEND_FACTOR_SRC_ALPHA = Interop.Renderer.Renderer_Property_BLEND_FACTOR_SRC_ALPHA_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int BLEND_FACTOR_DEST_ALPHA = Interop.Renderer.Renderer_Property_BLEND_FACTOR_DEST_ALPHA_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int BLEND_COLOR = Interop.Renderer.Renderer_Property_BLEND_COLOR_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int BLEND_PRE_MULTIPLIED_ALPHA = Interop.Renderer.Renderer_Property_BLEND_PRE_MULTIPLIED_ALPHA_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int INDEX_RANGE_FIRST = Interop.Renderer.Renderer_Property_INDEX_RANGE_FIRST_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int INDEX_RANGE_COUNT = Interop.Renderer.Renderer_Property_INDEX_RANGE_COUNT_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int DEPTH_WRITE_MODE = Interop.Renderer.Renderer_Property_DEPTH_WRITE_MODE_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int DEPTH_FUNCTION = Interop.Renderer.Renderer_Property_DEPTH_FUNCTION_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int DEPTH_TEST_MODE = Interop.Renderer.Renderer_Property_DEPTH_TEST_MODE_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int RENDER_MODE = Interop.Renderer.Renderer_Property_RENDER_MODE_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int STENCIL_FUNCTION = Interop.Renderer.Renderer_Property_STENCIL_FUNCTION_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int STENCIL_FUNCTION_MASK = Interop.Renderer.Renderer_Property_STENCIL_FUNCTION_MASK_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int STENCIL_FUNCTION_REFERENCE = Interop.Renderer.Renderer_Property_STENCIL_FUNCTION_REFERENCE_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int STENCIL_MASK = Interop.Renderer.Renderer_Property_STENCIL_MASK_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int STENCIL_OPERATION_ON_FAIL = Interop.Renderer.Renderer_Property_STENCIL_OPERATION_ON_FAIL_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int STENCIL_OPERATION_ON_Z_FAIL = Interop.Renderer.Renderer_Property_STENCIL_OPERATION_ON_Z_FAIL_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int STENCIL_OPERATION_ON_Z_PASS = Interop.Renderer.Renderer_Property_STENCIL_OPERATION_ON_Z_PASS_get();
        }
    }
}
