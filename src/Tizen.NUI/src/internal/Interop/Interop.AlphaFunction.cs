using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class AlphaFunction
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AlphaFunction__SWIG_0")]
            public static extern global::System.IntPtr NewAlphaFunction();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AlphaFunction__SWIG_1")]
            public static extern global::System.IntPtr NewAlphaFunction(int jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AlphaFunction__SWIG_2")]
            public static extern global::System.IntPtr NewAlphaFunction(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AlphaFunction__SWIG_3")]
            public static extern global::System.IntPtr NewAlphaFunction(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AlphaFunction_GetBezierControlPoints")]
            public static extern global::System.IntPtr GetBezierControlPoints(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AlphaFunction_GetCustomFunction")]
            public static extern global::System.IntPtr GetCustomFunction(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AlphaFunction_GetBuiltinFunction")]
            public static extern int GetBuiltinFunction(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AlphaFunction_GetMode")]
            public static extern int GetMode(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_AlphaFunction")]
            public static extern void DeleteAlphaFunction(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
