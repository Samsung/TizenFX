using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class doublep
        {

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_doublep")]
            public static extern global::System.IntPtr new_doublep();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_doublep")]
            public static extern void delete_doublep(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_doublep_assign")]
            public static extern void doublep_assign(global::System.Runtime.InteropServices.HandleRef jarg1, double jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_doublep_value")]
            public static extern double doublep_value(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_doublep_cast")]
            public static extern global::System.IntPtr doublep_cast(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_doublep_frompointer")]
            public static extern global::System.IntPtr doublep_frompointer(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
