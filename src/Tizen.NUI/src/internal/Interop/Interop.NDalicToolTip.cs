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

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class NDalicToolTip
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_CONTENT_get")]
            public static extern int TooltipContentGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_LAYOUT_get")]
            public static extern int TooltipLayoutGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_WAIT_TIME_get")]
            public static extern int TooltipWaitTimeGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_BACKGROUND_get")]
            public static extern int TooltipBackgroundGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_TAIL_get")]
            public static extern int TooltipTailGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_POSITION_get")]
            public static extern int TooltipPositionGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_HOVER_POINT_OFFSET_get")]
            public static extern int TooltipHoverPointOffsetGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_MOVEMENT_THRESHOLD_get")]
            public static extern int TooltipMovementThresholdGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_DISAPPEAR_ON_MOVEMENT_get")]
            public static extern int TooltipDisappearOnMovementGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_BACKGROUND_VISUAL_get")]
            public static extern int TooltipBackgroundVisualGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_BACKGROUND_BORDER_get")]
            public static extern int TooltipBackgroundBorderGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_TAIL_VISIBILITY_get")]
            public static extern int TooltipTailVisibilityGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_TAIL_ABOVE_VISUAL_get")]
            public static extern int TooltipTailAboveVisualGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_TAIL_BELOW_VISUAL_get")]
            public static extern int TooltipTailBelowVisualGet();
        }
    }
}
