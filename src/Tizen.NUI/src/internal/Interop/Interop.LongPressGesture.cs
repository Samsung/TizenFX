using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class LongPressGesture
        {
            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_LongPressGesture__SWIG_0")]
            public static extern global::System.IntPtr new_LongPressGesture__SWIG_0(int jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_LongPressGesture__SWIG_1")]
            public static extern global::System.IntPtr new_LongPressGesture__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LongPressGesture_Assign")]
            public static extern global::System.IntPtr LongPressGesture_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_LongPressGesture")]
            public static extern void delete_LongPressGesture(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LongPressGesture_numberOfTouches_set")]
            public static extern void LongPressGesture_numberOfTouches_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LongPressGesture_numberOfTouches_get")]
            public static extern uint LongPressGesture_numberOfTouches_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LongPressGesture_screenPoint_set")]
            public static extern void LongPressGesture_screenPoint_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LongPressGesture_screenPoint_get")]
            public static extern global::System.IntPtr LongPressGesture_screenPoint_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LongPressGesture_localPoint_set")]
            public static extern void LongPressGesture_localPoint_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LongPressGesture_localPoint_get")]
            public static extern global::System.IntPtr LongPressGesture_localPoint_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LongPressGesture_SWIGUpcast")]
            public static extern global::System.IntPtr LongPressGesture_SWIGUpcast(global::System.IntPtr jarg1);

        }
    }
}
