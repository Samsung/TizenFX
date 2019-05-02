using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class InputMethodOptions
        {
            //////////////////////InputMethodOptions
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_InputMethodOptions")]
            public static extern global::System.IntPtr new_InputMethodOptions();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodOptions_IsPassword")]
            public static extern bool InputMethodOptions_IsPassword(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodOptions_ApplyProperty")]
            public static extern void InputMethodOptions_ApplyProperty(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodOptions_RetrieveProperty")]
            public static extern void InputMethodOptions_RetrieveProperty(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodOptions_CompareAndSet")]
            public static extern bool InputMethodOptions_CompareAndSet(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_InputMethodOptions")]
            public static extern void delete_InputMethodOptions(global::System.Runtime.InteropServices.HandleRef jarg1);

        }
    }
}
