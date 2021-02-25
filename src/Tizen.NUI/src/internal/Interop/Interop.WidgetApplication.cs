using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class WidgetApplication
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetApplication_New")]
            public static extern global::System.IntPtr New(int jarg1, string jarg2, string jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WidgetApplication__SWIG_0")]
            public static extern global::System.IntPtr NewWidgetApplication();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WidgetApplication__SWIG_1")]
            public static extern global::System.IntPtr NewWidgetApplication(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetApplication_Assign")]
            public static extern global::System.IntPtr Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WidgetApplication")]
            public static extern void DeleteWidgetApplication(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetApplication_RegisterWidgetCreatingFunction")]
            public static extern void RegisterWidgetCreatingFunction(global::System.Runtime.InteropServices.HandleRef jarg1, ref string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);
        }
    }
}
