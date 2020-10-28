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
            public static extern global::System.IntPtr new_DaliException(string jarg1, string jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DaliException_location_set")]
            public static extern void DaliException_location_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DaliException_location_get")]
            public static extern string DaliException_location_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DaliException_condition_set")]
            public static extern void DaliException_condition_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DaliException_condition_get")]
            public static extern string DaliException_condition_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_DaliException")]
            public static extern void delete_DaliException(global::System.Runtime.InteropServices.HandleRef jarg1);


        }
    }
}
