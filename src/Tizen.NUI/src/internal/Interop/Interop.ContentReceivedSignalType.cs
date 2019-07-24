using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class ContentReceivedSignalType
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ContentReceivedSignalType_Empty")]
            public static extern bool ContentReceivedSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ContentReceivedSignalType_GetConnectionCount")]
            public static extern uint ContentReceivedSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ContentReceivedSignalType_Connect")]
            public static extern void ContentReceivedSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ContentReceivedSignalType_Disconnect")]
            public static extern void ContentReceivedSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ContentReceivedSignalType_Emit")]
            public static extern void ContentReceivedSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, string jarg3, string jarg4);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ContentReceivedSignalType")]
            public static extern global::System.IntPtr new_ContentReceivedSignalType();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ContentReceivedSignalType")]
            public static extern void delete_ContentReceivedSignalType(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
