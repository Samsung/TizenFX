using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class LayoutController
        {
            // LayoutController
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_LayoutController")]
            public static extern global::System.IntPtr New();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_LayoutController")]
            public static extern global::System.IntPtr DeleteLayoutController(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LayoutController_SetCallback")]
            public static extern void SetCallback(global::System.Runtime.InteropServices.HandleRef jarg1, Tizen.NUI.LayoutController.Callback jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LayoutController_GetId")]
            public static extern int GetId(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
