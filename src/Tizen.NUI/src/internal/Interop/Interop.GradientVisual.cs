using System;
using System.Collections.Generic;
using System.Text;

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
