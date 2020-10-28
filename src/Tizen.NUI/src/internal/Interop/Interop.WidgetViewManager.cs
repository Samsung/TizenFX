using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class WidgetViewManager
        {
            // For widget view manager
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetViewManager_New")]
            public static extern global::System.IntPtr WidgetViewManager_New(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetViewManager_DownCast")]
            public static extern global::System.IntPtr WidgetViewManager_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WidgetViewManager__SWIG_0")]
            public static extern global::System.IntPtr new_WidgetViewManager__SWIG_0();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WidgetViewManager__SWIG_1")]
            public static extern global::System.IntPtr new_WidgetViewManager__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetViewManager_Assign")]
            public static extern global::System.IntPtr WidgetViewManager_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WidgetViewManager")]
            public static extern void delete_WidgetViewManager(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetViewManager_AddWidget")]
            public static extern global::System.IntPtr WidgetViewManager_AddWidget(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, string jarg3, int jarg4, int jarg5, float jarg6);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetViewManager_SWIGUpcast")]
            public static extern global::System.IntPtr WidgetViewManager_SWIGUpcast(global::System.IntPtr jarg1);
        }
    }
}