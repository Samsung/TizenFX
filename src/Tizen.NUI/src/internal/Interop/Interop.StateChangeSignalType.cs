using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class StateChangeSignalType
        {

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_StateChangedSignalType_Empty")]
            public static extern bool StateChangedSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_StateChangedSignalType_GetConnectionCount")]
            public static extern uint StateChangedSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_StateChangedSignalType_Connect")]
            public static extern void StateChangedSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_StateChangedSignalType_Disconnect")]
            public static extern void StateChangedSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_StateChangedSignalType_Emit")]
            public static extern void StateChangedSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_StateChangedSignalType")]
            public static extern global::System.IntPtr new_StateChangedSignalType();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_StateChangedSignalType")]
            public static extern void delete_StateChangedSignalType(global::System.Runtime.InteropServices.HandleRef jarg1);

        }
    }
}
