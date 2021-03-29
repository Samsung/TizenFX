/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
                Tizen.NUI.PropertyValue pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.DepthIndex);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.DepthIndex, temp);
                temp.Dispose();
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
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.FaceCullingMode);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.FaceCullingMode, temp);
                temp.Dispose();
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
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.BlendMode);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.BlendMode, temp);
                temp.Dispose();
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
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.BlendEquationRgb);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.BlendEquationRgb, temp);
                temp.Dispose();
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
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.BlendEquationAlpha);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.BlendEquationAlpha, temp);
                temp.Dispose();
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
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.BlendFactorSrcRgb);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.BlendFactorSrcRgb, temp);
                temp.Dispose();
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
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.BlendFactorDestRgb);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.BlendFactorDestRgb, temp);
                temp.Dispose();
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
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.BlendFactorSrcAlpha);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.BlendFactorSrcAlpha, temp);
                temp.Dispose();
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
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.BlendFactorDestAlpha);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.BlendFactorDestAlpha, temp);
                temp.Dispose();
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
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.BlendColor);
                pValue.Get(temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.BlendColor, temp);
                temp.Dispose();
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
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.BlendPreMultipliedAlpha);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.BlendPreMultipliedAlpha, temp);
                temp.Dispose();
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
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.IndexRangeFirst);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.IndexRangeFirst, temp);
                temp.Dispose();
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
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.IndexRangeCount);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.IndexRangeCount, temp);
                temp.Dispose();
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
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.DepthWriteMode);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.DepthWriteMode, temp);
                temp.Dispose();
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
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.DepthFunction);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.DepthFunction, temp);
                temp.Dispose();
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
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.DepthTestMode);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.DepthTestMode, temp);
                temp.Dispose();
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
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.RenderMode);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.RenderMode, temp);
                temp.Dispose();
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
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.StencilFunction);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.StencilFunction, temp);
                temp.Dispose();
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
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.StencilFunctionMask);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.StencilFunctionMask, temp);
                temp.Dispose();
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
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.StencilFunctionReference);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.StencilFunctionReference, temp);
                temp.Dispose();
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
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.StencilMask);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.StencilMask, temp);
                temp.Dispose();
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
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.StencilOperationOnFail);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.StencilOperationOnFail, temp);
                temp.Dispose();
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
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.StencilOperationOnZFail);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.StencilOperationOnZFail, temp);
                temp.Dispose();
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
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.StencilOperationOnZPass);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.StencilOperationOnZPass, temp);
                temp.Dispose();
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

        internal Renderer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
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



            [Obsolete("Please do not use this! Deprecated in API9, will be removed in API11! Please use ForegroundEffect instead!")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>")]
            public static readonly int FOREGROUND_EFFECT = Interop.Renderer.RangesForegroundEffectGet();

            [Obsolete("Please do not use this! Deprecated in API9, will be removed in API11! Please use BackgroundEffect instead!")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>")]
            public static readonly int BACKGROUND_EFFECT = Interop.Renderer.RangesBackgroundEffectGet();
        }

        /// <summary>
        /// Enumeration for instances of properties belonging to the Renderer class.
        /// </summary>
        internal class Property
        {
            internal static readonly int DepthIndex = Interop.Renderer.DepthIndexGet();
            internal static readonly int FaceCullingMode = Interop.Renderer.FaceCullingModeGet();
            internal static readonly int BlendMode = Interop.Renderer.BlendModeGet();
            internal static readonly int BlendEquationRgb = Interop.Renderer.BlendEquationRgbGet();
            internal static readonly int BlendEquationAlpha = Interop.Renderer.BlendEquationAlphaGet();
            internal static readonly int BlendFactorSrcRgb = Interop.Renderer.BlendFactorSrcRgbGet();
            internal static readonly int BlendFactorDestRgb = Interop.Renderer.BlendFactorDestRgbGet();
            internal static readonly int BlendFactorSrcAlpha = Interop.Renderer.BlendFactorSrcAlphaGet();
            internal static readonly int BlendFactorDestAlpha = Interop.Renderer.BlendFactorDestAlphaGet();
            internal static readonly int BlendColor = Interop.Renderer.BlendColorGet();
            internal static readonly int BlendPreMultipliedAlpha = Interop.Renderer.BlendPreMultipliedAlphaGet();
            internal static readonly int IndexRangeFirst = Interop.Renderer.IndexRangeFirstGet();
            internal static readonly int IndexRangeCount = Interop.Renderer.IndexRangeCountGet();
            internal static readonly int DepthWriteMode = Interop.Renderer.DepthWriteModeGet();
            internal static readonly int DepthFunction = Interop.Renderer.DepthFunctionGet();
            internal static readonly int DepthTestMode = Interop.Renderer.DepthTestModeGet();
            internal static readonly int RenderMode = Interop.Renderer.RenderModeGet();
            internal static readonly int StencilFunction = Interop.Renderer.StencilFunctionGet();
            internal static readonly int StencilFunctionMask = Interop.Renderer.StencilFunctionMaskGet();
            internal static readonly int StencilFunctionReference = Interop.Renderer.StencilFunctionReferenceGet();
            internal static readonly int StencilMask = Interop.Renderer.StencilMaskGet();
            internal static readonly int StencilOperationOnFail = Interop.Renderer.StencilOperationOnFailGet();
            internal static readonly int StencilOperationOnZFail = Interop.Renderer.StencilOperationOnZFailGet();
            internal static readonly int StencilOperationOnZPass = Interop.Renderer.StencilOperationOnZPassGet();
        }
    }
}
