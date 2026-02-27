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
        internal static partial class NDalicToolTip
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_CONTENT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TooltipContentGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_LAYOUT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TooltipLayoutGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_WAIT_TIME_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TooltipWaitTimeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_BACKGROUND_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TooltipBackgroundGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_TAIL_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TooltipTailGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_POSITION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TooltipPositionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_HOVER_POINT_OFFSET_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TooltipHoverPointOffsetGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_MOVEMENT_THRESHOLD_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TooltipMovementThresholdGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_DISAPPEAR_ON_MOVEMENT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TooltipDisappearOnMovementGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_BACKGROUND_VISUAL_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TooltipBackgroundVisualGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_BACKGROUND_BORDER_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TooltipBackgroundBorderGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_TAIL_VISIBILITY_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TooltipTailVisibilityGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_TAIL_ABOVE_VISUAL_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TooltipTailAboveVisualGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TOOLTIP_TAIL_BELOW_VISUAL_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TooltipTailBelowVisualGet();
        }
    }
}





