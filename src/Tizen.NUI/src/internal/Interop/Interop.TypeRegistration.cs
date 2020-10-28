﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class TypeRegistration
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TypeRegistration__SWIG_0")]
            public static extern global::System.IntPtr new_TypeRegistration__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TypeRegistration__SWIG_1")]
            public static extern global::System.IntPtr new_TypeRegistration__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, bool jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TypeRegistration__SWIG_2")]
            public static extern global::System.IntPtr new_TypeRegistration__SWIG_2(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TypeRegistration_RegisteredName")]
            public static extern string TypeRegistration_RegisteredName(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TypeRegistration_RegisterControl")]
            public static extern void TypeRegistration_RegisterControl(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TypeRegistration_RegisterProperty")]
            public static extern void TypeRegistration_RegisterProperty(string jarg1, string jarg2, int jarg3, int jarg4, global::System.Runtime.InteropServices.HandleRef jarg5, global::System.Runtime.InteropServices.HandleRef jarg6);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TypeRegistration")]
            public static extern void delete_TypeRegistration(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}