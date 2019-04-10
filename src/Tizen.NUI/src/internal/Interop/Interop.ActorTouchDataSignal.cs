using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class ActorTouchDataSignal
        {
            static ActorTouchDataSignal()
            {
                Tizen.Log.Error("NUI", "ActorTouchDataSignal");
            }

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ActorTouchDataSignal_Empty")]
            public static extern bool ActorTouchDataSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ActorTouchDataSignal_GetConnectionCount")]
            public static extern uint ActorTouchDataSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ActorTouchDataSignal_Connect")]
            public static extern void ActorTouchDataSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ActorTouchDataSignal_Disconnect")]
            public static extern void ActorTouchDataSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ActorTouchDataSignal_Emit")]
            public static extern bool ActorTouchDataSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_ActorTouchDataSignal")]
            public static extern global::System.IntPtr new_ActorTouchDataSignal();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_ActorTouchDataSignal")]
            public static extern void delete_ActorTouchDataSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        }
    }
}
