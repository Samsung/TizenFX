using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class TapGestureDetectedSignal
        {
            static TapGestureDetectedSignal()
            {
                Tizen.Log.Error("NUI", "TapGestureDetectedSignal");
            }


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TapGestureDetectedSignal_Empty")]
            public static extern bool TapGestureDetectedSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TapGestureDetectedSignal_GetConnectionCount")]
            public static extern uint TapGestureDetectedSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TapGestureDetectedSignal_Connect")]
            public static extern void TapGestureDetectedSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TapGestureDetectedSignal_Disconnect")]
            public static extern void TapGestureDetectedSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TapGestureDetectedSignal_Emit")]
            public static extern void TapGestureDetectedSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_TapGestureDetectedSignal")]
            public static extern global::System.IntPtr new_TapGestureDetectedSignal();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_TapGestureDetectedSignal")]
            public static extern void delete_TapGestureDetectedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
