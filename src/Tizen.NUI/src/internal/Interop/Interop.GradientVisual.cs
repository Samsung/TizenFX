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
        internal static partial class NDalicGradientVisual
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GRADIENT_VISUAL_START_POSITION_get")]
            public static extern int GradientVisualStartPositionGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GRADIENT_VISUAL_END_POSITION_get")]
            public static extern int GradientVisualEndPositionGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GRADIENT_VISUAL_CENTER_get")]
            public static extern int GradientVisualCenterGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GRADIENT_VISUAL_RADIUS_get")]
            public static extern int GradientVisualRadiusGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GRADIENT_VISUAL_STOP_OFFSET_get")]
            public static extern int GradientVisualStopOffsetGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GRADIENT_VISUAL_STOP_COLOR_get")]
            public static extern int GradientVisualStopColorGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GRADIENT_VISUAL_UNITS_get")]
            public static extern int GradientVisualUnitsGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GRADIENT_VISUAL_SPREAD_METHOD_get")]
            public static extern int GradientVisualSpreadMethodGet();
        }
    }
}
