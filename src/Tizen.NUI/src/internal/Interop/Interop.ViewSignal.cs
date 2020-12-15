using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class ViewSignal
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_KeyEventSignal")]
            public static extern global::System.IntPtr KeyEventSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_KeyInputFocusGainedSignal")]
            public static extern global::System.IntPtr KeyInputFocusGainedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_KeyInputFocusLostSignal")]
            public static extern global::System.IntPtr KeyInputFocusLostSignal(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
