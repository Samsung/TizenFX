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
        internal static partial class NDalicGradientVisual
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GRADIENT_VISUAL_START_POSITION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GradientVisualStartPositionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GRADIENT_VISUAL_END_POSITION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GradientVisualEndPositionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GRADIENT_VISUAL_CENTER_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GradientVisualCenterGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GRADIENT_VISUAL_RADIUS_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GradientVisualRadiusGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GRADIENT_VISUAL_STOP_OFFSET_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GradientVisualStopOffsetGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GRADIENT_VISUAL_STOP_COLOR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GradientVisualStopColorGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GRADIENT_VISUAL_UNITS_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GradientVisualUnitsGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GRADIENT_VISUAL_SPREAD_METHOD_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GradientVisualSpreadMethodGet();
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GRADIENT_VISUAL_START_OFFSET_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GradientVisualStartOffsetGet();
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GRADIENT_VISUAL_START_ANGLE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GradientVisualStartAngleGet();
        }
    }
}





