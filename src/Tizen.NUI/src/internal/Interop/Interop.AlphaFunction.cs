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
            public static extern global::System.IntPtr new_AlphaFunction__SWIG_0();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AlphaFunction__SWIG_1")]
            public static extern global::System.IntPtr new_AlphaFunction__SWIG_1(int jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AlphaFunction__SWIG_2")]
            public static extern global::System.IntPtr new_AlphaFunction__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AlphaFunction__SWIG_3")]
            public static extern global::System.IntPtr new_AlphaFunction__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AlphaFunction_GetBezierControlPoints")]
            public static extern global::System.IntPtr AlphaFunction_GetBezierControlPoints(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AlphaFunction_GetCustomFunction")]
            public static extern global::System.IntPtr AlphaFunction_GetCustomFunction(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AlphaFunction_GetBuiltinFunction")]
            public static extern int AlphaFunction_GetBuiltinFunction(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AlphaFunction_GetMode")]
            public static extern int AlphaFunction_GetMode(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_AlphaFunction")]
            public static extern void delete_AlphaFunction(global::System.Runtime.InteropServices.HandleRef jarg1);

        }
    }
}
