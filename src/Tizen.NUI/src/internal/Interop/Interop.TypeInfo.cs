using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class TypeInfo
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TypeInfo_SWIGUpcast")]
            public static extern global::System.IntPtr Upcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TypeInfo__SWIG_0")]
            public static extern global::System.IntPtr NewTypeInfo();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TypeInfo")]
            public static extern void DeleteTypeInfo(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TypeInfo__SWIG_1")]
            public static extern global::System.IntPtr NewTypeInfo(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TypeInfo_Assign")]
            public static extern global::System.IntPtr Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TypeInfo_GetName")]
            public static extern string GetName(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TypeInfo_GetBaseName")]
            public static extern string GetBaseName(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TypeInfo_CreateInstance")]
            public static extern global::System.IntPtr CreateInstance(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TypeInfo_GetActionCount")]
            public static extern uint GetActionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TypeInfo_GetActionName")]
            public static extern string GetActionName(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TypeInfo_GetSignalCount")]
            public static extern uint GetSignalCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TypeInfo_GetSignalName")]
            public static extern string GetSignalName(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TypeInfo_GetPropertyCount")]
            public static extern uint GetPropertyCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TypeInfo_GetPropertyIndices")]
            public static extern void GetPropertyIndices(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TypeInfo_GetPropertyName")]
            public static extern string GetPropertyName(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);
        }
    }
}
