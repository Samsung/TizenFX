using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class ClampState2D
        {
            static ClampState2D()
            {
                Tizen.Log.Error("NUI", "ClampState2D");
            }
            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ClampState2D_x_set")]
            public static extern void ClampState2D_x_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ClampState2D_x_get")]
            public static extern int ClampState2D_x_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ClampState2D_y_set")]
            public static extern void ClampState2D_y_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ClampState2D_y_get")]
            public static extern int ClampState2D_y_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_ClampState2D")]
            public static extern global::System.IntPtr new_ClampState2D();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_ClampState2D")]
            public static extern void delete_ClampState2D(global::System.Runtime.InteropServices.HandleRef jarg1);




        }
    }
}
