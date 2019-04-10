using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class ViewSignal
        {
            static ViewSignal()
            {
                Tizen.Log.Error("NUI", "ViewSignal");
            }

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_View_KeyEventSignal")]
            public static extern global::System.IntPtr View_KeyEventSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_View_KeyInputFocusGainedSignal")]
            public static extern global::System.IntPtr View_KeyInputFocusGainedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_View_KeyInputFocusLostSignal")]
            public static extern global::System.IntPtr View_KeyInputFocusLostSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        }
    }
}
