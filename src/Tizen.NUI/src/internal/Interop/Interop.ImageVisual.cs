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

using global::System;
using global::System.Runtime.InteropServices;
using global::System.Runtime.InteropServices.Marshalling;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class NDalicImageVisual
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IMAGE_VISUAL_URL_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageVisualUrlGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IMAGE_VISUAL_ALPHA_MASK_URL_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageVisualAlphaMaskUrlGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IMAGE_VISUAL_FITTING_MODE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageVisualFittingModeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IMAGE_VISUAL_SAMPLING_MODE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageVisualSamplingModeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IMAGE_VISUAL_DESIRED_WIDTH_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageVisualDesiredWidthGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IMAGE_VISUAL_DESIRED_HEIGHT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageVisualDesiredHeightGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IMAGE_VISUAL_SYNCHRONOUS_LOADING_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageVisualSynchronousLoadingGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IMAGE_VISUAL_BORDER_ONLY_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageVisualBorderOnlyGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IMAGE_VISUAL_PIXEL_AREA_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageVisualPixelAreaGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IMAGE_VISUAL_WRAP_MODE_U_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageVisualWrapModeUGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IMAGE_VISUAL_WRAP_MODE_V_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageVisualWrapModeVGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IMAGE_VISUAL_BATCH_SIZE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageVisualBatchSizeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IMAGE_VISUAL_CACHE_SIZE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageVisualCacheSizeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IMAGE_VISUAL_FRAME_DELAY_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageVisualFrameDelayGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IMAGE_VISUAL_LOOP_COUNT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageVisualLoopCountGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IMAGE_VISUAL_MASK_CONTENT_SCALE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageVisualMaskContentScaleGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IMAGE_VISUAL_CROP_TO_MASK_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageVisualCropToMaskGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IMAGE_VISUAL_RELEASE_POLICY_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageVisualReleasePolicyGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IMAGE_VISUAL_LOAD_POLICY_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageVisualLoadPolicyGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IMAGE_VISUAL_ORIENTATION_CORRECTION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageVisualOrientationCorrectionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IMAGE_VISUAL_AUXILIARY_IMAGE_URL_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageVisualAuxiliaryImageUrlGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IMAGE_VISUAL_AUXILIARY_IMAGE_ALPHA_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageVisualAuxiliaryImageAlphaGet();
        }
    }
}





