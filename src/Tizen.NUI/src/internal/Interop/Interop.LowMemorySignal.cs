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
            public static extern bool LowMemorySignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_LowMemorySignalType_GetConnectionCount")]
            public static extern uint LowMemorySignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_LowMemorySignalType_Connect")]
            public static extern void LowMemorySignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_LowMemorySignalType_Disconnect")]
            public static extern void LowMemorySignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_LowMemorySignalType_Emit")]
            public static extern void LowMemorySignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_new_LowMemorySignalType")]
            public static extern global::System.IntPtr new_LowMemorySignalType();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_delete_LowMemorySignalType")]
            public static extern void delete_LowMemorySignalType(global::System.Runtime.InteropServices.HandleRef jarg1);

        }
    }
}
