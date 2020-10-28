using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class floatp
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_floatp")]
            public static extern global::System.IntPtr new_floatp();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_floatp")]
            public static extern void delete_floatp(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_floatp_assign")]
            public static extern void floatp_assign(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_floatp_value")]
            public static extern float floatp_value(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_floatp_cast")]
            public static extern global::System.IntPtr floatp_cast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_floatp_frompointer")]
            public static extern global::System.IntPtr floatp_frompointer(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}