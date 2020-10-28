using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class ushortp
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ushortp")]
            public static extern global::System.IntPtr new_ushortp();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ushortp")]
            public static extern void delete_ushortp(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ushortp_assign")]
            public static extern void ushortp_assign(global::System.Runtime.InteropServices.HandleRef jarg1, ushort jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ushortp_value")]
            public static extern ushort ushortp_value(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ushortp_cast")]
            public static extern global::System.IntPtr ushortp_cast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ushortp_frompointer")]
            public static extern global::System.IntPtr ushortp_frompointer(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}