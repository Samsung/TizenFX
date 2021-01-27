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
            public static extern global::System.IntPtr New(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetViewManager_DownCast")]
            public static extern global::System.IntPtr DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WidgetViewManager__SWIG_0")]
            public static extern global::System.IntPtr NewWidgetViewManager();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WidgetViewManager__SWIG_1")]
            public static extern global::System.IntPtr NewWidgetViewManager(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetViewManager_Assign")]
            public static extern global::System.IntPtr Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WidgetViewManager")]
            public static extern void DeleteWidgetViewManager(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetViewManager_AddWidget")]
            public static extern global::System.IntPtr AddWidget(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, string jarg3, int jarg4, int jarg5, float jarg6);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetViewManager_RemoveWidget")]
            public static extern bool RemoveWidget(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetViewManager_SWIGUpcast")]
            public static extern global::System.IntPtr Upcast(global::System.IntPtr jarg1);


            [Obsolete("Please do not use this! Deprecated in API9, will be removed in API11! Please use WidgetViewManager.New(...) instead!")]
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetViewManager_New")]
            public static extern global::System.IntPtr WidgetViewManager_New(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [Obsolete("Please do not use this! Deprecated in API9, will be removed in API11! Please use WidgetViewManager.AddWidget(...) instead!")]
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetViewManager_AddWidget")]
            public static extern global::System.IntPtr WidgetViewManager_AddWidget(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, string jarg3, int jarg4, int jarg5, float jarg6);
        }
    }
}
