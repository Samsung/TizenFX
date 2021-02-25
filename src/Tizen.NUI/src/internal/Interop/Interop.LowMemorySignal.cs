using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class LowMemorySignalType
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_LowMemorySignalType_Empty")]
            public static extern bool Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_LowMemorySignalType_GetConnectionCount")]
            public static extern uint GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_LowMemorySignalType_Connect")]
            public static extern void Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_LowMemorySignalType_Disconnect")]
            public static extern void Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_LowMemorySignalType_Emit")]
            public static extern void Emit(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_new_LowMemorySignalType")]
            public static extern global::System.IntPtr NewLowMemorySignalType();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_delete_LowMemorySignalType")]
            public static extern void DeleteLowMemorySignalType(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
