using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class PageFactory
        {
            static PageFactory()
            {
                Tizen.Log.Error("NUI", "PageFactory");
            }


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_PageFactory")]
            public static extern void delete_PageFactory(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_PageFactory_GetNumberOfPages")]
            public static extern uint PageFactory_GetNumberOfPages(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_PageFactory_NewPage")]
            public static extern global::System.IntPtr PageFactory_NewPage(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        }
    }
}
