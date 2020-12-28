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
using System.Diagnostics.CodeAnalysis;
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
        public Renderer(Geometry geometry, Shader shader) : this(Interop.Renderer.New(Geometry.getCPtr(geometry), Shader.getCPtr(shader)), true)
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
                Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.DepthIndex).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.DepthIndex, new Tizen.NUI.PropertyValue(value));
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
                Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.FaceCullingMode).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.FaceCullingMode, new Tizen.NUI.PropertyValue(value));
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
                Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.BlendMode).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.BlendMode, new Tizen.NUI.PropertyValue(value));
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
                Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.BlendEquationRgb).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.BlendEquationRgb, new Tizen.NUI.PropertyValue(value));
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
                Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.BlendEquationAlpha).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.BlendEquationAlpha, new Tizen.NUI.PropertyValue(value));
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
                Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.BlendFactorSrcRgb).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.BlendFactorSrcRgb, new Tizen.NUI.PropertyValue(value));
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
                Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.BlendFactorDestRgb).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.BlendFactorDestRgb, new Tizen.NUI.PropertyValue(value));
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
                Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.BlendFactorSrcAlpha).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.BlendFactorSrcAlpha, new Tizen.NUI.PropertyValue(value));
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
                Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.BlendFactorDestAlpha).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.BlendFactorDestAlpha, new Tizen.NUI.PropertyValue(value));
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
                Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.BlendColor).Get(temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.BlendColor, new Tizen.NUI.PropertyValue(value));
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
                Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.BlendPreMultipliedAlpha).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.BlendPreMultipliedAlpha, new Tizen.NUI.PropertyValue(value));
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
                Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.IndexRangeFirst).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.IndexRangeFirst, new Tizen.NUI.PropertyValue(value));
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
                Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.IndexRangeCount).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.IndexRangeCount, new Tizen.NUI.PropertyValue(value));
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
                Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.DepthWriteMode).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.DepthWriteMode, new Tizen.NUI.PropertyValue(value));
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
                Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.DepthFunction).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.DepthFunction, new Tizen.NUI.PropertyValue(value));
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
                Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.DepthTestMode).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.DepthTestMode, new Tizen.NUI.PropertyValue(value));
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
                Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.RenderMode).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.RenderMode, new Tizen.NUI.PropertyValue(value));
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
                Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.StencilFunction).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.StencilFunction, new Tizen.NUI.PropertyValue(value));
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
                Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.StencilFunctionMask).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.StencilFunctionMask, new Tizen.NUI.PropertyValue(value));
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
                Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.StencilFunctionReference).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.StencilFunctionReference, new Tizen.NUI.PropertyValue(value));
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
                Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.StencilMask).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.StencilMask, new Tizen.NUI.PropertyValue(value));
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
                Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.StencilOperationOnFail).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.StencilOperationOnFail, new Tizen.NUI.PropertyValue(value));
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
                Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.StencilOperationOnZFail).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.StencilOperationOnZFail, new Tizen.NUI.PropertyValue(value));
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
                Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.StencilOperationOnZPass).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.StencilOperationOnZPass, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Sets the geometry to be used by this renderer.
        /// </summary>
        /// <param name="geometry">The geometry to be used by this renderer.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetGeometry(Geometry geometry)
        {
            Interop.Renderer.SetGeometry(SwigCPtr, Geometry.getCPtr(geometry));
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
            System.IntPtr cPtr = Interop.Renderer.GetGeometry(SwigCPtr);
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
            Interop.Renderer.SetIndexRange(SwigCPtr, firstElement, elementsCount);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the texture set to be used by this renderer.
        /// </summary>
        /// <param name="textureSet">The texture set to be used by this renderer.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetTextures(TextureSet textureSet)
        {
            Interop.Renderer.SetTextures(SwigCPtr, TextureSet.getCPtr(textureSet));
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
            System.IntPtr cPtr = Interop.Renderer.GetTextures(SwigCPtr);
            HandleRef CPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            TextureSet ret = Registry.GetManagedBaseHandleFromNativePtr(CPtr.Handle) as TextureSet;
            if (cPtr != null && ret == null)
            {
                ret = new TextureSet(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            Interop.BaseHandle.DeleteBaseHandle(CPtr);
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
            Interop.Renderer.SetShader(SwigCPtr, Shader.getCPtr(shader));
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
            System.IntPtr cPtr = Interop.Renderer.GetShader(SwigCPtr);
            Shader ret = this.GetInstanceSafely<Shader>(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Renderer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal Renderer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.Renderer.Upcast(cPtr), cMemoryOwn)
        {
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Renderer.DeleteRenderer(swigCPtr);
        }

        /// <since_tizen> 6.0 </since_tizen>
        /// This will be changed internal API after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public sealed class Ranges
        {
            /// <since_tizen> 6.0 </since_tizen>
            /// This will be changed internal API after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int BackgroundEffect = Interop.Renderer.RangesBackgroundEffectGet();

            /// <since_tizen> 6.0 </since_tizen>
            /// This will be changed internal API after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int BACKGROUND = Interop.Renderer.RangesBackgroundGet();

            /// <since_tizen> 6.0 </since_tizen>
            /// This will be changed internal API after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int CONTENT = Interop.Renderer.RangesContentGet();

            /// <since_tizen> 6.0 </since_tizen>
            /// This will be changed internal API after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int DECORATION = Interop.Renderer.RangesDecorationGet();

            /// <since_tizen> 6.0 </since_tizen>
            /// This will be changed internal API after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ForegroundEffect = Interop.Renderer.RangesForegroundEffectGet();
        }

        /// <summary>
        /// Enumeration for instances of properties belonging to the Renderer class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Deprecated in API6; Will be removed in API9.")]
#pragma warning disable CA1716, CA1052, CA1034 // Identifiers should not match keywords
        public class Property
#pragma warning restore CA1716, CA1052, CA1034 // Identifiers should not match keywords
        {
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int DepthIndex = Interop.Renderer.DepthIndexGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int FaceCullingMode = Interop.Renderer.FaceCullingModeGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int BlendMode = Interop.Renderer.BlendModeGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int BlendEquationRgb = Interop.Renderer.BlendEquationRgbGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int BlendEquationAlpha = Interop.Renderer.BlendEquationAlphaGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int BlendFactorSrcRgb = Interop.Renderer.BlendFactorSrcRgbGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int BlendFactorDestRgb = Interop.Renderer.BlendFactorDestRgbGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int BlendFactorSrcAlpha = Interop.Renderer.BlendFactorSrcAlphaGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int BlendFactorDestAlpha = Interop.Renderer.BlendFactorDestAlphaGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int BlendColor = Interop.Renderer.BlendColorGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int BlendPreMultipliedAlpha = Interop.Renderer.BlendPreMultipliedAlphaGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int IndexRangeFirst = Interop.Renderer.IndexRangeFirstGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int IndexRangeCount = Interop.Renderer.IndexRangeCountGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int DepthWriteMode = Interop.Renderer.DepthWriteModeGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int DepthFunction = Interop.Renderer.DepthFunctionGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int DepthTestMode = Interop.Renderer.DepthTestModeGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int RenderMode = Interop.Renderer.RenderModeGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int StencilFunction = Interop.Renderer.StencilFunctionGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int StencilFunctionMask = Interop.Renderer.StencilFunctionMaskGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int StencilFunctionReference = Interop.Renderer.StencilFunctionReferenceGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int StencilMask = Interop.Renderer.StencilMaskGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int StencilOperationOnFail = Interop.Renderer.StencilOperationOnFailGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int StencilOperationOnZFail = Interop.Renderer.StencilOperationOnZFailGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int StencilOperationOnZPass = Interop.Renderer.StencilOperationOnZPassGet();
        }
    }
}
