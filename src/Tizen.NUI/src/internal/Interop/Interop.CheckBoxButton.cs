using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class CheckBoxButton
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_CheckBoxButton__SWIG_0")]
            public static extern global::System.IntPtr NewCheckBoxButton();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_CheckBoxButton__SWIG_1")]
            public static extern global::System.IntPtr NewCheckBoxButton(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CheckBoxButton_Assign")]
            public static extern global::System.IntPtr CheckBoxButtonAssign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_CheckBoxButton")]
            public static extern void DeleteCheckBoxButton(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CheckBoxButton_New")]
            public static extern global::System.IntPtr CheckBoxButtonNew();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CheckBoxButton_DownCast")]
            public static extern global::System.IntPtr CheckBoxButtonDownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CheckBoxButton_SWIGUpcast")]
            public static extern global::System.IntPtr CheckBoxButtonUpcast(global::System.IntPtr jarg1);
        }
    }
}