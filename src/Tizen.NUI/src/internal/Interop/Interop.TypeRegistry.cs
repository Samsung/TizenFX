using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class TypeRegistry
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TypeRegistry_Get")]
            public static extern global::System.IntPtr TypeRegistry_Get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TypeRegistry__SWIG_0")]
            public static extern global::System.IntPtr new_TypeRegistry__SWIG_0();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TypeRegistry")]
            public static extern void delete_TypeRegistry(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TypeRegistry__SWIG_1")]
            public static extern global::System.IntPtr new_TypeRegistry__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TypeRegistry_Assign")]
            public static extern global::System.IntPtr TypeRegistry_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TypeRegistry_GetTypeInfo__SWIG_0")]
            public static extern global::System.IntPtr TypeRegistry_GetTypeInfo__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TypeRegistry_GetTypeInfo__SWIG_1")]
            public static extern global::System.IntPtr TypeRegistry_GetTypeInfo__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TypeRegistry_GetTypeNameCount")]
            public static extern uint TypeRegistry_GetTypeNameCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TypeRegistry_GetTypeName")]
            public static extern string TypeRegistry_GetTypeName(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TypeRegistry_SWIGUpcast")]
            public static extern global::System.IntPtr TypeRegistry_SWIGUpcast(global::System.IntPtr jarg1);
        }
    }
}