using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class KeyboardResizedSignalType
        {
            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_KeyboardResizedSignalType_Empty")]
            public static extern bool KeyboardResizedSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_KeyboardResizedSignalType_GetConnectionCount")]
            public static extern uint KeyboardResizedSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_KeyboardResizedSignalType_Connect")]
            public static extern void KeyboardResizedSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_KeyboardResizedSignalType_Disconnect")]
            public static extern void KeyboardResizedSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_KeyboardResizedSignalType_Emit")]
            public static extern void KeyboardResizedSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_KeyboardResizedSignalType")]
            public static extern global::System.IntPtr new_KeyboardResizedSignalType();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_KeyboardResizedSignalType")]
            public static extern void delete_KeyboardResizedSignalType(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
