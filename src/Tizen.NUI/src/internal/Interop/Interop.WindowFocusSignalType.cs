using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class WindowFocusSignalType
        {
            static WindowFocusSignalType()
            {
                Tizen.Log.Error("NUI", "WindowFocusSignalType");
            }

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WindowFocusSignalType_Empty")]
            public static extern bool WindowFocusSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WindowFocusSignalType_GetConnectionCount")]
            public static extern uint WindowFocusSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WindowFocusSignalType_Connect")]
            public static extern void WindowFocusSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WindowFocusSignalType_Disconnect")]
            public static extern void WindowFocusSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WindowFocusSignalType_Emit")]
            public static extern void WindowFocusSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_WindowFocusSignalType")]
            public static extern global::System.IntPtr new_WindowFocusSignalType();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_WindowFocusSignalType")]
            public static extern void delete_WindowFocusSignalType(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
