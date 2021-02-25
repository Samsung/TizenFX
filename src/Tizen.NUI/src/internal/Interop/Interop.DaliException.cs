using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class DaliException
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_DaliException")]
            public static extern global::System.IntPtr NewDaliException(string jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DaliException_location_set")]
            public static extern void LocationSet(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DaliException_location_get")]
            public static extern string LocationGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DaliException_condition_set")]
            public static extern void ConditionSet(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DaliException_condition_get")]
            public static extern string ConditionGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_DaliException")]
            public static extern void DeleteDaliException(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
