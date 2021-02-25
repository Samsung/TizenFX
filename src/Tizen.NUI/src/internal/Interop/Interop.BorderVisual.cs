using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class NDalicBorderVisual
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BORDER_VISUAL_COLOR_get")]
            public static extern int ColorGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BORDER_VISUAL_SIZE_get")]
            public static extern int SizeGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BORDER_VISUAL_ANTI_ALIASING_get")]
            public static extern int AntiAliasingGet();
        }
    }
}
