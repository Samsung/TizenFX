﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class ViewWrapperImpl
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewWrapperImpl_SWIGUpcast")]
            public static extern global::System.IntPtr ViewWrapperImpl_SWIGUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewWrapperImpl_CONTROL_BEHAVIOUR_FLAG_COUNT_get")]
            public static extern int ViewWrapperImpl_CONTROL_BEHAVIOUR_FLAG_COUNT_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ViewWrapperImpl")]
            public static extern global::System.IntPtr new_ViewWrapperImpl(int jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewWrapperImpl_New")]
            public static extern global::System.IntPtr ViewWrapperImpl_New(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ViewWrapperImpl")]
            public static extern void delete_ViewWrapperImpl(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewWrapperImpl_director_connect")]
            public static extern void ViewWrapperImpl_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_0 delegate0, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_1 delegate1,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_2 delegate2, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_3 delegate3,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_4 delegate4, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_5 delegate5,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_6 delegate6, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_7 delegate7,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_8 delegate8, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_9 delegate9, 
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_10 delegate10, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_11 delegate11,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_12 delegate12, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_13 delegate13,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_14 delegate14, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_15 delegate15,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_16 delegate16, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_17 delegate17,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_18 delegate18, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_19 delegate19,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_20 delegate20, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_21 delegate21,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_24 delegate24, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_25 delegate25,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_26 delegate26, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_27 delegate27,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_28 delegate28, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_29 delegate29,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_30 delegate30, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_31 delegate31,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_32 delegate32, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_33 delegate33,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_34 delegate34, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_35 delegate35,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_36 delegate36, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_37 delegate37,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_38 delegate38, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_39 delegate39,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_40 delegate40);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_RelayoutRequest")]
            public static extern void ViewWrapperImpl_RelayoutRequest(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_GetHeightForWidthBase")]
            public static extern float ViewWrapperImpl_GetHeightForWidthBase(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_GetWidthForHeightBase")]
            public static extern float ViewWrapperImpl_GetWidthForHeightBase(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_CalculateChildSizeBase")]
            public static extern float ViewWrapperImpl_CalculateChildSizeBase(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_0")]
            public static extern bool ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_1")]
            public static extern bool ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_RegisterVisual__SWIG_0")]
            public static extern void ViewWrapperImpl_RegisterVisual__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_RegisterVisual__SWIG_1")]
            public static extern void ViewWrapperImpl_RegisterVisual__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, bool jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_UnregisterVisual")]
            public static extern void ViewWrapperImpl_UnregisterVisual(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_GetVisual")]
            public static extern global::System.IntPtr ViewWrapperImpl_GetVisual(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_EnableVisual")]
            public static extern void ViewWrapperImpl_EnableVisual(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, bool jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_IsVisualEnabled")]
            public static extern bool ViewWrapperImpl_IsVisualEnabled(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_CreateTransition")]
            public static extern global::System.IntPtr ViewWrapperImpl_CreateTransition(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_EmitKeyInputFocusSignal")]
            public static extern void ViewWrapperImpl_EmitKeyInputFocusSignal(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewWrapperImpl_ApplyThemeStyle")]
            public static extern void ViewWrapperImpl_ApplyThemeStyle(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetControlWrapperImpl__SWIG_0")]
            public static extern global::System.IntPtr GetControlWrapperImpl__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}