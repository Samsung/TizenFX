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
            public static extern global::System.IntPtr LayoutController_New();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_LayoutController")]
            public static extern global::System.IntPtr delete_LayoutController(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LayoutController_SetCallback")]
            public static extern void LayoutController_SetCallback(global::System.Runtime.InteropServices.HandleRef jarg1, Tizen.NUI.LayoutController.Callback jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LayoutController_GetId")]
            public static extern int LayoutController_GetId(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}