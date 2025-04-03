/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
    /// Renderable is a handle to an object used to show content by combining a Geometry, a TextureSet and a shader.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class Renderable : Animatable
    {
        private Geometry geometry;
        private Shader shader;

        /// <summary>
        /// Create an instance of Renderable without Geometry or Shader.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Renderable() : this(Interop.Renderer.New(), true)
        {
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// <summary>
        /// Gets and Sets DepthIndex property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int DepthIndex
        {
            get
            {
                int temp = 0;
                Tizen.NUI.PropertyValue pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, RendererProperty.DepthIndex);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, RendererProperty.DepthIndex, temp);
                temp.Dispose();
            }
        }

        /// <summary>
        /// Gets and Sets FaceCullingMode to define which face is culled or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FaceCullingMode FaceCullingMode
        {
            get => (FaceCullingMode)Object.InternalGetPropertyInt(SwigCPtr, RendererProperty.FaceCullingMode);
            set => Object.InternalSetPropertyInt(SwigCPtr, RendererProperty.FaceCullingMode, (int)value);
        }

        /// <summary>
        /// Gets and Sets BlendMode.
        /// BlendMode defines how source and destination colors are blended.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BlendMode BlendMode
        {
            get => (BlendMode)Object.InternalGetPropertyInt(SwigCPtr, RendererProperty.BlendMode);
            set => Object.InternalSetPropertyInt(SwigCPtr, RendererProperty.BlendMode, (int)value);
        }

        /// <summary>
        /// Gets and Sets BlendEquation method for RGB channel.
        /// BlendEquation specifies the mathematical operation for blending.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BlendEquation BlendEquationRgb
        {
            get => RenderableUtility.ConvertBlendEquationTypeFromUtilityProperty((RenderableUtility.BlendEquationType)Object.InternalGetPropertyInt(SwigCPtr, RendererProperty.BlendEquationRgb));
            set => Object.InternalSetPropertyInt(SwigCPtr, RendererProperty.BlendEquationRgb, (int)RenderableUtility.ConvertBlendEquationTypeToUtilityProperty(value));
        }

        /// <summary>
        /// Gets and Sets BlendEquation method for Alpha channel.
        /// BlendEquation specifies the mathematical operation for blending.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BlendEquation BlendEquationAlpha
        {
            get => RenderableUtility.ConvertBlendEquationTypeFromUtilityProperty((RenderableUtility.BlendEquationType)Object.InternalGetPropertyInt(SwigCPtr, RendererProperty.BlendEquationAlpha));
            set => Object.InternalSetPropertyInt(SwigCPtr, RendererProperty.BlendEquationAlpha, (int)RenderableUtility.ConvertBlendEquationTypeToUtilityProperty(value));
        }

        /// <summary>
        /// Gets and Sets BlendFactor for Rgb channel of Source.
        /// BlendFactor determines the weight of source and destination colors.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BlendFactor BlendFactorSrcRgb
        {
            get => RenderableUtility.ConvertBlendFactorTypeFromUtilityProperty((RenderableUtility.BlendFactorType)Object.InternalGetPropertyInt(SwigCPtr, RendererProperty.BlendFactorSrcRgb));
            set => Object.InternalSetPropertyInt(SwigCPtr, RendererProperty.BlendFactorSrcRgb, (int)RenderableUtility.ConvertBlendFactorTypeToUtilityProperty(value));
        }

        /// <summary>
        /// Gets and Sets BlendFactor for Rgb channel of Destination.
        /// BlendFactor determines the weight of source and destination colors.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BlendFactor BlendFactorDestRgb
        {
            get => RenderableUtility.ConvertBlendFactorTypeFromUtilityProperty((RenderableUtility.BlendFactorType)Object.InternalGetPropertyInt(SwigCPtr, RendererProperty.BlendFactorDestRgb));
            set => Object.InternalSetPropertyInt(SwigCPtr, RendererProperty.BlendFactorDestRgb, (int)RenderableUtility.ConvertBlendFactorTypeToUtilityProperty(value));
        }

        /// <summary>
        /// Gets and Sets BlendFactor for Alpha channel of Source.
        /// BlendFactor determines the weight of source and destination colors.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BlendFactor BlendFactorSrcAlpha
        {
            get => RenderableUtility.ConvertBlendFactorTypeFromUtilityProperty((RenderableUtility.BlendFactorType)Object.InternalGetPropertyInt(SwigCPtr, RendererProperty.BlendFactorSrcAlpha));
            set => Object.InternalSetPropertyInt(SwigCPtr, RendererProperty.BlendFactorSrcAlpha, (int)RenderableUtility.ConvertBlendFactorTypeToUtilityProperty(value));
        }

        /// <summary>
        /// Gets and Sets BlendFactor for Alpha channel of Destination.
        /// BlendFactor determines the weight of source and destination colors.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BlendFactor BlendFactorDestAlpha
        {
            get => RenderableUtility.ConvertBlendFactorTypeFromUtilityProperty((RenderableUtility.BlendFactorType)Object.InternalGetPropertyInt(SwigCPtr, RendererProperty.BlendFactorDestAlpha));
            set => Object.InternalSetPropertyInt(SwigCPtr, RendererProperty.BlendFactorDestAlpha, (int)RenderableUtility.ConvertBlendFactorTypeToUtilityProperty(value));
        }

        /// <summary>
        /// Gets and Sets BlendColor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 BlendColor
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, RendererProperty.BlendColor);
                pValue.Get(temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, RendererProperty.BlendColor, temp);
                temp.Dispose();
            }
        }

        /// <summary>
        /// Gets and Sets BlendPreMultipliedAlpha.
        /// If it is true, it denotes the RGB color values are aleady multiplied by the alpha value.
        /// It improves blending accuracy and avoidng artifacts in transparent areas.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool BlendPreMultipliedAlpha
        {
            get
            {
                bool temp = false;
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, RendererProperty.BlendPreMultipliedAlpha);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, RendererProperty.BlendPreMultipliedAlpha, temp);
                temp.Dispose();
            }
        }

        /// <summary>
        /// Gets and Sets first index to define effective range of indices to draw from bound index buffer.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int FirstIndex
        {
            get
            {
                int temp = 0;
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, RendererProperty.IndexRangeFirst);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, RendererProperty.IndexRangeFirst, temp);
                temp.Dispose();
            }
        }

        /// <summary>
        /// Gets and Sets index count of effective range of indices to draw from bound index buffer.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int IndexCount
        {
            get
            {
                int temp = 0;
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, RendererProperty.IndexRangeCount);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, RendererProperty.IndexRangeCount, temp);
                temp.Dispose();
            }
        }

        /// <summary>
        /// Gets and Sets DepthWriteMode.
        /// This property controls wheter depth buffer writing is enabled.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DepthWriteMode DepthWriteMode
        {
            get => (DepthWriteMode)Object.InternalGetPropertyInt(SwigCPtr, RendererProperty.DepthWriteMode);
            set => Object.InternalSetPropertyInt(SwigCPtr, RendererProperty.DepthWriteMode, (int)value);
        }

        /// <summary>
        /// Gets and Sets DepthFunction.
        /// This property defines the comparison function for depth testing
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DepthFunction DepthFunction
        {
            get => (DepthFunction)Object.InternalGetPropertyInt(SwigCPtr, RendererProperty.DepthFunction);
            set => Object.InternalSetPropertyInt(SwigCPtr, RendererProperty.DepthFunction, (int)value);
        }

        /// <summary>
        /// Gets and Sets DepthTestMode.
        /// This property specifies how depth testing is applied to fragments.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DepthTestMode DepthTestMode
        {
            get => (DepthTestMode)Object.InternalGetPropertyInt(SwigCPtr, RendererProperty.DepthTestMode);
            set => Object.InternalSetPropertyInt(SwigCPtr, RendererProperty.DepthTestMode, (int)value);
        }

        /// <summary>
        /// Gets and Sets RenderMode.
        /// This property specifies what aspects of rendering are enabled.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RenderMode RenderMode
        {
            get => (RenderMode)Object.InternalGetPropertyInt(SwigCPtr, RendererProperty.RenderMode);
            set => Object.InternalSetPropertyInt(SwigCPtr, RendererProperty.RenderMode, (int)value);
        }

        /// <summary>
        /// Gets and Sets Stencil Function.
        /// This property specifies the test function for stencil buffering
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StencilFunction StencilFunction
        {
            get => (StencilFunction)Object.InternalGetPropertyInt(SwigCPtr, RendererProperty.StencilFunction);
            set => Object.InternalSetPropertyInt(SwigCPtr, RendererProperty.StencilFunction, (int)value);
        }

        /// <summary>
        /// Gets and Sets StencilFunctionMask.
        /// A bitmask applied to the stencil test function
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int StencilFunctionMask
        {
            get
            {
                int temp = 0;
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, RendererProperty.StencilFunctionMask);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, RendererProperty.StencilFunctionMask, temp);
                temp.Dispose();
            }
        }

        /// <summary>
        /// Gets and Sets StencilFunctionReference.
        /// The reference value used in the stencil test.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int StencilFunctionReference
        {
            get
            {
                int temp = 0;
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, RendererProperty.StencilFunctionReference);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, RendererProperty.StencilFunctionReference, temp);
                temp.Dispose();
            }
        }

        /// <summary>
        /// Gets and Sets StencilMask.
        /// This property controls which bits of the stencil buffer can be modified.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int StencilMask
        {
            get
            {
                int temp = 0;
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, RendererProperty.StencilMask);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, RendererProperty.StencilMask, temp);
                temp.Dispose();
            }
        }

        /// <summary>
        /// Gets and Sets StencilOperationOnFail.
        /// Action when the stencil test fails.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StencilOperation StencilOperationOnFail
        {
            get => (StencilOperation)Object.InternalGetPropertyInt(SwigCPtr, RendererProperty.StencilOperationOnFail);
            set => Object.InternalSetPropertyInt(SwigCPtr, RendererProperty.StencilOperationOnFail, (int)value);
        }

        /// <summary>
        /// Gets and Sets StencilOperationOnZFail.
        /// Action when the depth test fails but the stencil test passed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StencilOperation StencilOperationOnZFail
        {
            get => (StencilOperation)Object.InternalGetPropertyInt(SwigCPtr, RendererProperty.StencilOperationOnZFail);
            set => Object.InternalSetPropertyInt(SwigCPtr, RendererProperty.StencilOperationOnZFail, (int)value);
        }

        /// <summary>
        /// Gets and Sets StencilOperationOnZPass property.
        /// Action when both stencil and depth tests pass.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StencilOperation StencilOperationOnZPass
        {
            get => (StencilOperation)Object.InternalGetPropertyInt(SwigCPtr, RendererProperty.StencilOperationOnZPass);
            set => Object.InternalSetPropertyInt(SwigCPtr, RendererProperty.StencilOperationOnZPass, (int)value);
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
                // TODO : Clean up below logics after implement Object.InternalGetPropertyExtents
                using Extents temp = new Extents();
                using var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, RendererProperty.UpdateAreaExtents);
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
                // TODO : Clean up below logics after implement Object.InternalSetPropertyExtents
                using var temp = new Tizen.NUI.PropertyValue((Extents)value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, RendererProperty.UpdateAreaExtents, temp);
            }
        }

        /// <summary>
        /// Gets and Sets Geometry of this Renderable.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Geometry Geometry
        {
            get => geometry;
            set => SetGeometry(value);
        }

        /// <summary>
        /// Gets and Sets Shader of this Renderable.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Shader Shader
        {
            get => shader;
            set => SetShader(value);
        }

        /// <summary>
        /// Gets and Sets Textures of this Renderable.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextureSet TextureSet
        {
            get => GetTextures();
            set => SetTextures(value);
        }

        /// <summary>
        /// Sets the geometry to be used by this renderer.
        /// </summary>
        /// <param name="geometry">The geometry to be used by this renderer.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void SetGeometry(Geometry geometry)
        {
            this.geometry = geometry;
            Interop.Renderer.SetGeometry(SwigCPtr, Geometry.getCPtr(this.geometry));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the shader used by this renderer.
        /// </summary>
        /// <param name="shader">The shader to be used by this renderer.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void SetShader(Shader shader)
        {
            this.shader = shader;
            Interop.Renderer.SetShader(SwigCPtr, Shader.getCPtr(this.shader));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the texture set to be used by this renderer.
        /// </summary>
        /// <param name="textureSet">The texture set to be used by this renderer.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void SetTextures(TextureSet textureSet)
        {
            Interop.Renderer.SetTextures(SwigCPtr, TextureSet.getCPtr(textureSet));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the texture set used by this renderer.
        /// </summary>
        /// <returns>The texture set used by the renderer.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private TextureSet GetTextures()
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

        internal Renderable(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Renderer.DeleteRenderer(swigCPtr);
        }
    }
}
