using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class StageSignal
        {
            static StageSignal()
            {
                Tizen.Log.Error("NUI", "StageSignal");
            }

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Stage_KeyEventSignal")]
            public static extern global::System.IntPtr Stage_KeyEventSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Stage_EventProcessingFinishedSignal")]
            public static extern global::System.IntPtr Stage_EventProcessingFinishedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Stage_TouchSignal")]
            public static extern global::System.IntPtr Stage_TouchSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Stage_WheelEventSignal")]
            public static extern global::System.IntPtr Stage_WheelEventSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Stage_ContextLostSignal")]
            public static extern global::System.IntPtr Stage_ContextLostSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Stage_ContextRegainedSignal")]
            public static extern global::System.IntPtr Stage_ContextRegainedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Stage_SceneCreatedSignal")]
            public static extern global::System.IntPtr Stage_SceneCreatedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        }
    }
}
