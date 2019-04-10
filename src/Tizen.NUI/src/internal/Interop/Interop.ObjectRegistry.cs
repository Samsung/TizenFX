using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class ObjectRegistry
        {

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ObjectRegistry_SWIGUpcast")]
            public static extern global::System.IntPtr ObjectRegistry_SWIGUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_ObjectRegistry__SWIG_0")]
            public static extern global::System.IntPtr new_ObjectRegistry__SWIG_0();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_ObjectRegistry")]
            public static extern void delete_ObjectRegistry(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_ObjectRegistry__SWIG_1")]
            public static extern global::System.IntPtr new_ObjectRegistry__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ObjectRegistry_Assign")]
            public static extern global::System.IntPtr ObjectRegistry_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ObjectRegistry_ObjectCreatedSignal")]
            public static extern global::System.IntPtr ObjectRegistry_ObjectCreatedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ObjectRegistry_ObjectDestroyedSignal")]
            public static extern global::System.IntPtr ObjectRegistry_ObjectDestroyedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


        }
    }
}
