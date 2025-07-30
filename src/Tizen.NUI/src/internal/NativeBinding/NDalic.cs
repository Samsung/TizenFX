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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    internal class NDalic
    {
        public static readonly int VisualPropertyTransform = Interop.Visual.TransformGet();
        public static readonly int VisualPropertyPremultipliedAlpha = Interop.Visual.PremultipliedAlphaGet();
        public static readonly int VisualPropertyMixColor = Interop.Visual.MixColorGet();
        public static readonly int ImageVisualBorder = Interop.Visual.ImageVisualBorderGet();

        public static float GetRangedEpsilon(float a, float b)
        {
            float ret = Interop.NDalic.GetRangedEpsilon(a, b);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static bool Equals(float a, float b)
        {
            bool ret = Interop.NDalic.Equals(a, b);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static readonly int VisualPropertyType = Interop.NDalicVisual.VisualPropertyTypeGet();
        internal static readonly int VisualPropertyShader = Interop.NDalicVisual.VisualPropertyShaderGet();

        internal static readonly int VisualShaderVertex = Interop.NDalicVisual.VisualShaderVertexGet();
        internal static readonly int VisualShaderFragment = Interop.NDalicVisual.VisualShaderFragmentGet();
        internal static readonly int VisualShaderSubdivideGridX = Interop.NDalicVisual.VisualShaderSubdivideGridXGet();
        internal static readonly int VisualShaderSubdivideGridY = Interop.NDalicVisual.VisualShaderSubdivideGridYGet();
        internal static readonly int VisualShaderHints = Interop.NDalicVisual.VisualShaderHintsGet();

        internal static readonly int BorderVisualColor = Interop.NDalicBorderVisual.ColorGet();
        internal static readonly int BorderVisualSize = Interop.NDalicBorderVisual.SizeGet();
        internal static readonly int BorderVisualAntiAliasing = Interop.NDalicBorderVisual.AntiAliasingGet();

        internal static readonly int ColorVisualMixColor = Interop.NDalicColorVisual.ColorVisualMixColorGet();

        internal static readonly int GradientVisualStartPosition = Interop.NDalicGradientVisual.GradientVisualStartPositionGet();
        internal static readonly int GradientVisualEndPosition = Interop.NDalicGradientVisual.GradientVisualEndPositionGet();
        internal static readonly int GradientVisualCenter = Interop.NDalicGradientVisual.GradientVisualCenterGet();
        internal static readonly int GradientVisualRadius = Interop.NDalicGradientVisual.GradientVisualRadiusGet();
        internal static readonly int GradientVisualStopOffset = Interop.NDalicGradientVisual.GradientVisualStopOffsetGet();
        internal static readonly int GradientVisualStopColor = Interop.NDalicGradientVisual.GradientVisualStopColorGet();
        internal static readonly int GradientVisualUnits = Interop.NDalicGradientVisual.GradientVisualUnitsGet();
        internal static readonly int GradientVisualSpreadMethod = Interop.NDalicGradientVisual.GradientVisualSpreadMethodGet();
        internal static readonly int GradientVisualStartOffset = Interop.NDalicGradientVisual.GradientVisualStartOffsetGet();
        internal static readonly int GradientVisualStartAngle = Interop.NDalicGradientVisual.GradientVisualStartAngleGet();

        internal static readonly int ImageVisualUrl = Interop.NDalicImageVisual.ImageVisualUrlGet();
        internal static readonly int ImageVisualAlphaMaskUrl = Interop.NDalicImageVisual.ImageVisualAlphaMaskUrlGet();
        internal static readonly int ImageVisualFittingMode = Interop.NDalicImageVisual.ImageVisualFittingModeGet();
        internal static readonly int ImageVisualSamplingMode = Interop.NDalicImageVisual.ImageVisualSamplingModeGet();
        internal static readonly int ImageVisualDesiredWidth = Interop.NDalicImageVisual.ImageVisualDesiredWidthGet();
        internal static readonly int ImageVisualDesiredHeight = Interop.NDalicImageVisual.ImageVisualDesiredHeightGet();
        internal static readonly int ImageVisualSynchronousLoading = Interop.NDalicImageVisual.ImageVisualSynchronousLoadingGet();
        internal static readonly int ImageVisualBorderOnly = Interop.NDalicImageVisual.ImageVisualBorderOnlyGet();
        internal static readonly int ImageVisualPixelArea = Interop.NDalicImageVisual.ImageVisualPixelAreaGet();
        internal static readonly int ImageVisualWrapModeU = Interop.NDalicImageVisual.ImageVisualWrapModeUGet();
        internal static readonly int ImageVisualWrapModeV = Interop.NDalicImageVisual.ImageVisualWrapModeVGet();
        internal static readonly int ImageVisualBatchSize = Interop.NDalicImageVisual.ImageVisualBatchSizeGet();
        internal static readonly int ImageVisualCacheSize = Interop.NDalicImageVisual.ImageVisualCacheSizeGet();
        internal static readonly int ImageVisualFrameDelay = Interop.NDalicImageVisual.ImageVisualFrameDelayGet();
        internal static readonly int ImageVisualLoopCount = Interop.NDalicImageVisual.ImageVisualLoopCountGet();
        internal static readonly int ImageVisualMaskContentScale = Interop.NDalicImageVisual.ImageVisualMaskContentScaleGet();
        internal static readonly int ImageVisualCropToMask = Interop.NDalicImageVisual.ImageVisualCropToMaskGet();
        internal static readonly int ImageVisualReleasePolicy = Interop.NDalicImageVisual.ImageVisualReleasePolicyGet();
        internal static readonly int ImageVisualLoadPolicy = Interop.NDalicImageVisual.ImageVisualLoadPolicyGet();
        internal static readonly int ImageVisualOrientationCorrection = Interop.NDalicImageVisual.ImageVisualOrientationCorrectionGet();
        internal static readonly int ImageVisualAuxiliaryImageUrl = Interop.NDalicImageVisual.ImageVisualAuxiliaryImageUrlGet();
        internal static readonly int ImageVisualAuxiliaryImageAlpha = Interop.NDalicImageVisual.ImageVisualAuxiliaryImageAlphaGet();

        internal static readonly int MeshVisualObjectUrl = Interop.NDalicMeshVisual.MeshVisualObjectUrlGet();
        internal static readonly int MeshVisualMaterialUrl = Interop.NDalicMeshVisual.MeshVisualMaterialUrlGet();
        internal static readonly int MeshVisualTexturesPath = Interop.NDalicMeshVisual.MeshVisualTexturesPathGet();
        internal static readonly int MeshVisualShadingMode = Interop.NDalicMeshVisual.MeshVisualShadingModeGet();
        internal static readonly int MeshVisualUseMipmapping = Interop.NDalicMeshVisual.MeshVisualUseMipmappingGet();
        internal static readonly int MeshVisualUseSoftNormals = Interop.NDalicMeshVisual.MeshVisualUseSoftNormalsGet();
        internal static readonly int MeshVisualLightPosition = Interop.NDalicMeshVisual.MeshVisualLightPositionGet();

        internal static readonly int PrimitiveVisualShape = Interop.NdalicPrimitive.PrimitiveVisualShapeGet();
        internal static readonly int PrimitiveVisualMixColor = Interop.NdalicPrimitive.PrimitiveVisualMixColorGet();
        internal static readonly int PrimitiveVisualSlices = Interop.NdalicPrimitive.PrimitiveVisualSlicesGet();
        internal static readonly int PrimitiveVisualStacks = Interop.NdalicPrimitive.PrimitiveVisualStacksGet();
        internal static readonly int PrimitiveVisualScaleTopRadius = Interop.NdalicPrimitive.PrimitiveVisualScaleTopRadiusGet();
        internal static readonly int PrimitiveVisualScaleBottomRadius = Interop.NdalicPrimitive.PrimitiveVisualScaleBottomRadiusGet();
        internal static readonly int PrimitiveVisualScaleHeight = Interop.NdalicPrimitive.PrimitiveVisualScaleHeightGet();
        internal static readonly int PrimitiveVisualScaleRadius = Interop.NdalicPrimitive.PrimitiveVisualScaleRadiusGet();
        internal static readonly int PrimitiveVisualScaleDimensions = Interop.NdalicPrimitive.PrimitiveVisualScaleDimensionsGet();
        internal static readonly int PrimitiveVisualBevelPercentage = Interop.NdalicPrimitive.PrimitiveVisualBevelPercentageGet();
        internal static readonly int PrimitiveVisualBevelSmoothness = Interop.NdalicPrimitive.PrimitiveVisualBevelSmoothnessGet();
        internal static readonly int PrimitiveVisualLightPosition = Interop.NdalicPrimitive.PrimitiveVisualLightPositionGet();

        internal static readonly int TextVisualText = Interop.NDalicText.TextVisualTextGet();
        internal static readonly int TextVisualFontFamily = Interop.NDalicText.TextVisualFontFamilyGet();
        internal static readonly int TextVisualFontStyle = Interop.NDalicText.TextVisualFontStyleGet();
        internal static readonly int TextVisualPointSize = Interop.NDalicText.TextVisualPointSizeGet();
        internal static readonly int TextVisualMultiLine = Interop.NDalicText.TextVisualMultiLineGet();
        internal static readonly int TextVisualHorizontalAlignment = Interop.NDalicText.TextVisualHorizontalAlignmentGet();
        internal static readonly int TextVisualVerticalAlignment = Interop.NDalicText.TextVisualVerticalAlignmentGet();
        internal static readonly int TextVisualTextColor = Interop.NDalicText.TextVisualTextColorGet();
        internal static readonly int TextVisualEnableMarkup = Interop.NDalicText.TextVisualEnableMarkupGet();

        internal static readonly int TooltipContent = Interop.NDalicToolTip.TooltipContentGet();
        internal static readonly int TooltipLayout = Interop.NDalicToolTip.TooltipLayoutGet();
        internal static readonly int TooltipWaitTime = Interop.NDalicToolTip.TooltipWaitTimeGet();
        internal static readonly int TooltipBackground = Interop.NDalicToolTip.TooltipBackgroundGet();
        internal static readonly int TooltipTail = Interop.NDalicToolTip.TooltipTailGet();
        internal static readonly int TooltipPosition = Interop.NDalicToolTip.TooltipPositionGet();
        internal static readonly int TooltipHoverPointOffset = Interop.NDalicToolTip.TooltipHoverPointOffsetGet();
        internal static readonly int TooltipMovementThreshold = Interop.NDalicToolTip.TooltipMovementThresholdGet();
        internal static readonly int TooltipDisappearOnMovement = Interop.NDalicToolTip.TooltipDisappearOnMovementGet();

        internal static readonly int TooltipBackgroundVisual = Interop.NDalicToolTip.TooltipBackgroundVisualGet();
        internal static readonly int TooltipBackgroundBorder = Interop.NDalicToolTip.TooltipBackgroundBorderGet();

        internal static readonly int TooltipTailVisibility = Interop.NDalicToolTip.TooltipTailVisibilityGet();
        internal static readonly int TooltipTailAboveVisual = Interop.NDalicToolTip.TooltipTailAboveVisualGet();
        internal static readonly int TooltipTailBelowVisual = Interop.NDalicToolTip.TooltipTailBelowVisualGet();


        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use ImageVisualUrl instead.")]
        internal static readonly int IMAGE_VISUAL_URL = Interop.NDalicImageVisual.ImageVisualUrlGet();
        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use ImageVisualAlphaMaskUrl instead.")]
        internal static readonly int IMAGE_VISUAL_ALPHA_MASK_URL = Interop.NDalicImageVisual.ImageVisualAlphaMaskUrlGet();
        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use ImageVisualAuxiliaryImageUrl instead.")]
        internal static readonly int IMAGE_VISUAL_AUXILIARY_IMAGE_URL = Interop.NDalicImageVisual.ImageVisualAuxiliaryImageUrlGet();
    }
}
