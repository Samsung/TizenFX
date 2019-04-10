using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class StatusSignalType
        {

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_StatusSignalType_Empty")]
            public static extern bool StatusSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_StatusSignalType_GetConnectionCount")]
            public static extern uint StatusSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_StatusSignalType_Connect")]
            public static extern void StatusSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_StatusSignalType_Disconnect")]
            public static extern void StatusSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_StatusSignalType_Emit")]
            public static extern void StatusSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_StatusSignalType")]
            public static extern global::System.IntPtr new_StatusSignalType();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_StatusSignalType")]
            public static extern void delete_StatusSignalType(global::System.Runtime.InteropServices.HandleRef jarg1);

        }
    }
}
