using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class AuthenticationSignalType
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AuthenticationSignalType_Empty")]
            public static extern bool AuthenticationSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AuthenticationSignalType_GetConnectionCount")]
            public static extern uint AuthenticationSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AuthenticationSignalType_Connect")]
            public static extern void AuthenticationSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AuthenticationSignalType_Disconnect")]
            public static extern void AuthenticationSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AuthenticationSignalType_Emit")]
            public static extern void AuthenticationSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AuthenticationSignalType")]
            public static extern global::System.IntPtr new_AuthenticationSignalType();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_AuthenticationSignalType")]
            public static extern void delete_AuthenticationSignalType(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}