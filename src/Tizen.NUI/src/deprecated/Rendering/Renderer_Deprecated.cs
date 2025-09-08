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
        private Geometry CurrentGeometry;
        private Shader CurrentShader;

        /// <summary>
        /// Create an instance of Renderer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Renderer(Geometry geometry, Shader shader) : this(Interop.Renderer.New(Geometry.getCPtr(geometry), Shader.getCPtr(shader)), true)
        {
            CurrentGeometry = geometry;
            CurrentShader = shader;

            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// <summary>
        /// Create an instance of Renderer without Geometry or Shader.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Renderer() : this(Interop.Renderer.New(), true)
        {
            NDalicPINVOKE.ThrowExceptionIfExists();
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
                return (int)InternalFaceCullingMode;
            }
            set
            {
                InternalFaceCullingMode = (FaceCullingModeType)value;
            }
        }

        /// <summary>
        /// Gets and Sets FaceCullingMode by FaceCullingModeType enum.
        /// </summary>
        private FaceCullingModeType InternalFaceCullingMode
        {
            get
            {
                return (FaceCullingModeType)Object.InternalGetPropertyInt(SwigCPtr, Renderer.Property.FaceCullingMode);
            }
            set
            {
                Object.InternalSetPropertyInt(SwigCPtr, Renderer.Property.FaceCullingMode, (int)value);
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
                return (int)InternalBlendMode;
            }
            set
            {
                InternalBlendMode = (BlendModeType)value;
            }
        }

        /// <summary>
        /// Gets and Sets BlendMode by BlendModeType enum.
        /// </summary>
        private BlendModeType InternalBlendMode
        {
            get
            {
                return (BlendModeType)Object.InternalGetPropertyInt(SwigCPtr, Renderer.Property.BlendMode);
            }
            set
            {
                Object.InternalSetPropertyInt(SwigCPtr, Renderer.Property.BlendMode, (int)value);
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
                return (int)InternalBlendEquationRgb;
            }
            set
            {
                InternalBlendEquationRgb = (BlendEquationType)value;
            }
        }

        /// <summary>
        /// Gets and Sets BlendEquationRgb by BlendEquationType enum.
        /// </summary>
        private BlendEquationType InternalBlendEquationRgb
        {
            get
            {
                return (BlendEquationType)Object.InternalGetPropertyInt(SwigCPtr, Renderer.Property.BlendEquationRgb);
            }
            set
            {
                Object.InternalSetPropertyInt(SwigCPtr, Renderer.Property.BlendEquationRgb, (int)value);
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
                return (int)InternalBlendEquationAlpha;
            }
            set
            {
                InternalBlendEquationAlpha = (BlendEquationType)value;
            }
        }

        /// <summary>
        /// Gets and Sets BlendEquationRgb by BlendEquationType enum.
        /// </summary>
        private BlendEquationType InternalBlendEquationAlpha
        {
            get
            {
                return (BlendEquationType)Object.InternalGetPropertyInt(SwigCPtr, Renderer.Property.BlendEquationAlpha);
            }
            set
            {
                Object.InternalSetPropertyInt(SwigCPtr, Renderer.Property.BlendEquationAlpha, (int)value);
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
                return (int)InternalBlendFactorSrcRgb;
            }
            set
            {
                InternalBlendFactorSrcRgb = (BlendFactorType)value;
            }
        }

        /// <summary>
        /// Gets and Sets BlendFactorSrcRgb by BlendFactorType enum.
        /// </summary>
        private BlendFactorType InternalBlendFactorSrcRgb
        {
            get
            {
                return (BlendFactorType)Object.InternalGetPropertyInt(SwigCPtr, Renderer.Property.BlendFactorSrcRgb);
            }
            set
            {
                Object.InternalSetPropertyInt(SwigCPtr, Renderer.Property.BlendFactorSrcRgb, (int)value);
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
                return (int)InternalBlendFactorDestRgb;
            }
            set
            {
                InternalBlendFactorDestRgb = (BlendFactorType)value;
            }
        }

        /// <summary>
        /// Gets and Sets BlendFactorDestRgb by BlendFactorType enum.
        /// </summary>
        private BlendFactorType InternalBlendFactorDestRgb
        {
            get
            {
                return (BlendFactorType)Object.InternalGetPropertyInt(SwigCPtr, Renderer.Property.BlendFactorDestRgb);
            }
            set
            {
                Object.InternalSetPropertyInt(SwigCPtr, Renderer.Property.BlendFactorDestRgb, (int)value);
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
                return (int)InternalBlendFactorSrcAlpha;
            }
            set
            {
                InternalBlendFactorSrcAlpha = (BlendFactorType)value;
            }
        }

        /// <summary>
        /// Gets and Sets BlendFactorSrcAlpha by BlendFactorType enum.
        /// </summary>
        private BlendFactorType InternalBlendFactorSrcAlpha
        {
            get
            {
                return (BlendFactorType)Object.InternalGetPropertyInt(SwigCPtr, Renderer.Property.BlendFactorSrcAlpha);
            }
            set
            {
                Object.InternalSetPropertyInt(SwigCPtr, Renderer.Property.BlendFactorSrcAlpha, (int)value);
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
                return (int)InternalBlendFactorDestAlpha;
            }
            set
            {
                InternalBlendFactorDestAlpha = (BlendFactorType)value;
            }
        }

        /// <summary>
        /// Gets and Sets BlendFactorDestAlpha by BlendFactorType enum.
        /// </summary>
        private BlendFactorType InternalBlendFactorDestAlpha
        {
            get
            {
                return (BlendFactorType)Object.InternalGetPropertyInt(SwigCPtr, Renderer.Property.BlendFactorDestAlpha);
            }
            set
            {
                Object.InternalSetPropertyInt(SwigCPtr, Renderer.Property.BlendFactorDestAlpha, (int)value);
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
                return (int)InternalDepthWriteMode;
            }
            set
            {
                InternalDepthWriteMode = (DepthWriteModeType)value;
            }
        }

        /// <summary>
        /// Gets and Sets DepthWriteMode by DepthWriteModeType enum.
        /// </summary>
        private DepthWriteModeType InternalDepthWriteMode
        {
            get
            {
                return (DepthWriteModeType)Object.InternalGetPropertyInt(SwigCPtr, Renderer.Property.DepthWriteMode);
            }
            set
            {
                Object.InternalSetPropertyInt(SwigCPtr, Renderer.Property.DepthWriteMode, (int)value);
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
                return (int)InternalDepthFunction;
            }
            set
            {
                InternalDepthFunction = (DepthFunctionType)value;
            }
        }

        /// <summary>
        /// Gets and Sets DepthFunction by DepthFunctionType enum.
        /// </summary>
        private DepthFunctionType InternalDepthFunction
        {
            get
            {
                return (DepthFunctionType)Object.InternalGetPropertyInt(SwigCPtr, Renderer.Property.DepthFunction);
            }
            set
            {
                Object.InternalSetPropertyInt(SwigCPtr, Renderer.Property.DepthFunction, (int)value);
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
                return (int)InternalDepthTestMode;
            }
            set
            {
                InternalDepthTestMode = (DepthTestModeType)value;
            }
        }

        /// <summary>
        /// Gets and Sets DepthTestMode by DepthTestModeType enum.
        /// </summary>
        private DepthTestModeType InternalDepthTestMode
        {
            get
            {
                return (DepthTestModeType)Object.InternalGetPropertyInt(SwigCPtr, Renderer.Property.DepthTestMode);
            }
            set
            {
                Object.InternalSetPropertyInt(SwigCPtr, Renderer.Property.DepthTestMode, (int)value);
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
                return (int)InternalRenderMode;
            }
            set
            {
                InternalRenderMode = (RenderModeType)value;
            }
        }

        /// <summary>
        /// Gets and Sets RenderMode by RenderModeType enum.
        /// </summary>
        private RenderModeType InternalRenderMode
        {
            get
            {
                return (RenderModeType)Object.InternalGetPropertyInt(SwigCPtr, Renderer.Property.RenderMode);
            }
            set
            {
                Object.InternalSetPropertyInt(SwigCPtr, Renderer.Property.RenderMode, (int)value);
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
                return (int)InternalStencilFunction;
            }
            set
            {
                InternalStencilFunction = (StencilFunctionType)value;
            }
        }

        /// <summary>
        /// Gets and Sets StencilFunction by StencilFunctionType enum.
        /// </summary>
        private StencilFunctionType InternalStencilFunction
        {
            get
            {
                return (StencilFunctionType)Object.InternalGetPropertyInt(SwigCPtr, Renderer.Property.StencilFunction);
            }
            set
            {
                Object.InternalSetPropertyInt(SwigCPtr, Renderer.Property.StencilFunction, (int)value);
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
                return (int)InternalStencilOperationOnFail;
            }
            set
            {
                InternalStencilOperationOnFail = (StencilOperationType)value;
            }
        }

        /// <summary>
        /// Gets and Sets StencilOperationOnFail by StencilOperationType enum.
        /// </summary>
        private StencilOperationType InternalStencilOperationOnFail
        {
            get
            {
                return (StencilOperationType)Object.InternalGetPropertyInt(SwigCPtr, Renderer.Property.StencilOperationOnFail);
            }
            set
            {
                Object.InternalSetPropertyInt(SwigCPtr, Renderer.Property.StencilOperationOnFail, (int)value);
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
                return (int)InternalStencilOperationOnZFail;
            }
            set
            {
                InternalStencilOperationOnZFail = (StencilOperationType)value;
            }
        }


        /// <summary>
        /// Gets and Sets StencilOperationOnZFail by StencilOperationType enum.
        /// </summary>
        private StencilOperationType InternalStencilOperationOnZFail
        {
            get
            {
                return (StencilOperationType)Object.InternalGetPropertyInt(SwigCPtr, Renderer.Property.StencilOperationOnZFail);
            }
            set
            {
                Object.InternalSetPropertyInt(SwigCPtr, Renderer.Property.StencilOperationOnZFail, (int)value);
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
                return (int)InternalStencilOperationOnZPass;
            }
            set
            {
                InternalStencilOperationOnZPass = (StencilOperationType)value;
            }
        }

        /// <summary>
        /// Gets and Sets StencilOperationOnZPass property by StencilOperationType enum.
        /// </summary>
        private StencilOperationType InternalStencilOperationOnZPass
        {
            get
            {
                return (StencilOperationType)Object.InternalGetPropertyInt(SwigCPtr, Renderer.Property.StencilOperationOnZPass);
            }
            set
            {
                Object.InternalSetPropertyInt(SwigCPtr, Renderer.Property.StencilOperationOnZPass, (int)value);
            }
        }

        /// <summary>
        /// Gets and Sets extents of partial update area.
        /// </summary>
        /// <remarks>
        /// Extents the area - the position and the size - used for the attached View's partial update area calculation.
        /// This value be appended after calculate all update area, like visual offset.
        /// Change  <see cref="Tizen.NUI.BaseComponents.View.UpdateAreaHint"/> value if you want to change View's partial update area.
        /// Warning : Only 0u ~ 65535u integer values are allowed for each parameters.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UIExtents UpdateArea
        {
            get
            {
                // TODO : Clean up below logics
                using Extents temp = new Extents();
                using var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Renderer.Property.UpdateAreaExtents);
                pValue.Get(temp);

                if (temp == null)
                {
                    return new UIExtents(0.0f);
                }
                UIExtents result = new UIExtents((float)temp.Start, (float)temp.End, (float)temp.Top, (float)temp.Bottom);
                return result;
            }
            set
            {
                using var temp = new Tizen.NUI.PropertyValue((Extents)value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Renderer.Property.UpdateAreaExtents, temp);
            }
        }

        /// <summary>
        /// Sets the geometry to be used by this renderer.
        /// </summary>
        /// <param name="geometry">The geometry to be used by this renderer.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetGeometry(Geometry geometry)
        {
            Interop.Renderer.SetGeometry(SwigCPtr, Geometry.getCPtr(CurrentGeometry = geometry));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the geometry used by this renderer.
        /// </summary>
        /// <returns>The geometry used by the renderer.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Geometry GetGeometry()
        {
            return CurrentGeometry;
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
            global::System.IntPtr cPtr = Interop.Renderer.GetTextures(SwigCPtr);
            TextureSet ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as TextureSet;
            if (ret != null)
            {
                Interop.BaseHandle.DeleteBaseHandle(new global::System.Runtime.InteropServices.HandleRef(this, cPtr));
                NDalicPINVOKE.ThrowExceptionIfExists();
                return ret;
            }
            else
            {
                ret = new TextureSet(cPtr, true);
                return ret;
            }
        }

        /// <summary>
        /// Sets the shader used by this renderer.
        /// </summary>
        /// <param name="shader">The shader to be used by this renderer.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetShader(Shader shader)
        {
            Interop.Renderer.SetShader(SwigCPtr, Shader.getCPtr(CurrentShader = shader));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the shader used by this renderer.
        /// </summary>
        /// <returns>The shader used by the renderer.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Shader GetShader()
        {
            return CurrentShader;
        }

        internal Renderer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// you can override it to clean-up your own resources.
        /// </summary>
        /// <param name="type">DisposeTypes</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.

                CurrentGeometry = null;
                CurrentShader = null;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Renderer.DeleteRenderer(swigCPtr);
        }

        /// This will be opened API after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public sealed class Ranges
        {
            /// This will be opened API after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int BackgroundEffect = Interop.Renderer.RangesBackgroundEffectGet();

            /// This will be opened API after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int Background = Interop.Renderer.RangesBackgroundGet();

            /// This will be opened API after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int Content = Interop.Renderer.RangesContentGet();

            /// This will be opened API after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int Decoration = Interop.Renderer.RangesDecorationGet();

            /// This will be opened API after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ForegroundEffect = Interop.Renderer.RangesForegroundEffectGet();



            [Obsolete("Do not use this, that is deprecated in API9 and will be removed in API11. Use BackgroundEffect instead.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>")]
            public static readonly int BACKGROUND_EFFECT = Interop.Renderer.RangesBackgroundEffectGet();

            [Obsolete("Do not use this, that is deprecated in API13 and will be removed in API15. Use Background instead.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int BACKGROUND = Interop.Renderer.RangesBackgroundGet();

            [Obsolete("Do not use this, that is deprecated in API13 and will be removed in API15. Use Content instead.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int CONTENT = Interop.Renderer.RangesContentGet();

            [Obsolete("Do not use this, that is deprecated in API13 and will be removed in API15. Use Decoration instead.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int DECORATION = Interop.Renderer.RangesDecorationGet();

            [Obsolete("Do not use this, that is deprecated in API9 and will be removed in API11. Use ForegroundEffect instead.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>")]
            public static readonly int FOREGROUND_EFFECT = Interop.Renderer.RangesForegroundEffectGet();
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
            internal static readonly int MixColor = Interop.Renderer.MixColorGet();
            internal static readonly int MixColorRed = Interop.Renderer.MixColorRedGet();
            internal static readonly int MixColorGreen = Interop.Renderer.MixColorGreenGet();
            internal static readonly int MixColorBlue = Interop.Renderer.MixColorBlueGet();
            internal static readonly int MixColorOpacity = Interop.Renderer.MixColorOpacityGet();
            internal static readonly int RenderingBehavior = Interop.Renderer.RenderingBehaviorGet();
            internal static readonly int BlendEquation = Interop.Renderer.BlendEquationGet();
            internal static readonly int VertexRangeFirst = Interop.Renderer.IndexRangeFirstGet();
            internal static readonly int VertexRangeCount = Interop.Renderer.IndexRangeCountGet();
            internal static readonly int InstanceCount = Interop.Renderer.InstanceCountGet();
            internal static readonly int UpdateAreaExtents = Interop.Renderer.UpdateAreaExtentsGet();
        }
    }
}
