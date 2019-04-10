using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class StringValuePair
        {
            static StringValuePair()
            {
                Tizen.Log.Error("NUI", "StringValuePair");
            }


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_StringValuePair__SWIG_0")]
            public static extern global::System.IntPtr new_StringValuePair__SWIG_0();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_StringValuePair__SWIG_1")]
            public static extern global::System.IntPtr new_StringValuePair__SWIG_1(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_StringValuePair__SWIG_2")]
            public static extern global::System.IntPtr new_StringValuePair__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_StringValuePair_first_set")]
            public static extern void StringValuePair_first_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_StringValuePair_first_get")]
            public static extern string StringValuePair_first_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_StringValuePair_second_set")]
            public static extern void StringValuePair_second_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_StringValuePair_second_get")]
            public static extern global::System.IntPtr StringValuePair_second_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_StringValuePair")]
            public static extern void delete_StringValuePair(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
