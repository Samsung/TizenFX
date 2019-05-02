using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class PageTurnView
        {

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PageTurnView_SWIGUpcast")]
            public static extern global::System.IntPtr PageTurnView_SWIGUpcast(global::System.IntPtr jarg1);
                       


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PageTurnView_Property_PAGE_SIZE_get")]
            public static extern int PageTurnView_Property_PAGE_SIZE_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PageTurnView_Property_CURRENT_PAGE_ID_get")]
            public static extern int PageTurnView_Property_CURRENT_PAGE_ID_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PageTurnView_Property_SPINE_SHADOW_get")]
            public static extern int PageTurnView_Property_SPINE_SHADOW_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_PageTurnView_Property")]
            public static extern global::System.IntPtr new_PageTurnView_Property();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_PageTurnView_Property")]
            public static extern void delete_PageTurnView_Property(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_PageTurnView__SWIG_0")]
            public static extern global::System.IntPtr new_PageTurnView__SWIG_0();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_PageTurnView__SWIG_1")]
            public static extern global::System.IntPtr new_PageTurnView__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PageTurnView_Assign")]
            public static extern global::System.IntPtr PageTurnView_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_PageTurnView")]
            public static extern void delete_PageTurnView(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PageTurnView_DownCast")]
            public static extern global::System.IntPtr PageTurnView_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PageTurnView_PageTurnStartedSignal")]
            public static extern global::System.IntPtr PageTurnView_PageTurnStartedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PageTurnView_PageTurnFinishedSignal")]
            public static extern global::System.IntPtr PageTurnView_PageTurnFinishedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PageTurnView_PagePanStartedSignal")]
            public static extern global::System.IntPtr PageTurnView_PagePanStartedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PageTurnView_PagePanFinishedSignal")]
            public static extern global::System.IntPtr PageTurnView_PagePanFinishedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        }
    }
}
