using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class VectorFloat
        {
            static VectorFloat()
            {
                Tizen.Log.Error("NUI", "VectorFloat");
            }

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VectorFloat_BaseType_get")]
            public static extern int VectorFloat_BaseType_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_VectorFloat__SWIG_0")]
            public static extern global::System.IntPtr new_VectorFloat__SWIG_0();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_VectorFloat")]
            public static extern void delete_VectorFloat(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_VectorFloat__SWIG_1")]
            public static extern global::System.IntPtr new_VectorFloat__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VectorFloat_Assign")]
            public static extern global::System.IntPtr VectorFloat_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VectorFloat_Begin")]
            public static extern global::System.IntPtr VectorFloat_Begin(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VectorFloat_End")]
            public static extern global::System.IntPtr VectorFloat_End(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VectorFloat_ValueOfIndex__SWIG_0")]
            public static extern global::System.IntPtr VectorFloat_ValueOfIndex__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VectorFloat_PushBack")]
            public static extern void VectorFloat_PushBack(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VectorFloat_Insert__SWIG_0")]
            public static extern void VectorFloat_Insert__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VectorFloat_Insert__SWIG_1")]
            public static extern void VectorFloat_Insert__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VectorFloat_Reserve")]
            public static extern void VectorFloat_Reserve(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VectorFloat_Resize__SWIG_0")]
            public static extern void VectorFloat_Resize__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VectorFloat_Resize__SWIG_1")]
            public static extern void VectorFloat_Resize__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, float jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VectorFloat_Erase__SWIG_0")]
            public static extern global::System.IntPtr VectorFloat_Erase__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VectorFloat_Erase__SWIG_1")]
            public static extern global::System.IntPtr VectorFloat_Erase__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VectorFloat_Remove")]
            public static extern void VectorFloat_Remove(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VectorFloat_Swap")]
            public static extern void VectorFloat_Swap(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VectorFloat_Clear")]
            public static extern void VectorFloat_Clear(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VectorFloat_Release")]
            public static extern void VectorFloat_Release(global::System.Runtime.InteropServices.HandleRef jarg1);

        }
    }
}
