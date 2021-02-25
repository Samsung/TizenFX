using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class PageFactory
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_PageFactory")]
            public static extern void DeletePageFactory(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PageFactory_GetNumberOfPages")]
            public static extern uint GetNumberOfPages(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PageFactory_NewPage")]
            public static extern global::System.IntPtr NewPage(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);
        }
    }
}
