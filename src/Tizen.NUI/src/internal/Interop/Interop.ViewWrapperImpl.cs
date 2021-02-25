/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class ViewWrapperImpl
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewWrapperImpl_SWIGUpcast")]
            public static extern global::System.IntPtr Upcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewWrapperImpl_CONTROL_BEHAVIOUR_FLAG_COUNT_get")]
            public static extern int ControlBehaviourFlagCountGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ViewWrapperImpl")]
            public static extern global::System.IntPtr NewViewWrapperImpl(int jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewWrapperImpl_New")]
            public static extern global::System.IntPtr New(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ViewWrapperImpl")]
            public static extern void DeleteViewWrapperImpl(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewWrapperImpl_director_connect")]
            public static extern void DirectorConnect(global::System.Runtime.InteropServices.HandleRef jarg1,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_0 delegate0, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_1 delegate1,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_2 delegate2, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_3 delegate3,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_4 delegate4, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_5 delegate5,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_6 delegate6, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_9 delegate9,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_11 delegate11,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_12 delegate12, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_13 delegate13,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_14 delegate14, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_15 delegate15,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_16 delegate16, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_17 delegate17,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_18 delegate18, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_19 delegate19,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_20 delegate20, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_21 delegate21,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_24 delegate24, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_25 delegate25,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_26 delegate26,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_28 delegate28, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_29 delegate29,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_30 delegate30, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_31 delegate31,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_32 delegate32, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_33 delegate33,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_34 delegate34, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_35 delegate35,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_36 delegate36, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_37 delegate37,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_38 delegate38, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_39 delegate39,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_40 delegate40);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_RelayoutRequest")]
            public static extern void RelayoutRequest(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_GetHeightForWidthBase")]
            public static extern float GetHeightForWidthBase(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_GetWidthForHeightBase")]
            public static extern float GetWidthForHeightBase(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_CalculateChildSizeBase")]
            public static extern float CalculateChildSizeBase(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_0")]
            public static extern bool RelayoutDependentOnChildrenBase(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_1")]
            public static extern bool RelayoutDependentOnChildrenBase(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_RegisterVisual__SWIG_0")]
            public static extern void RegisterVisual(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_RegisterVisual__SWIG_1")]
            public static extern void RegisterVisual(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, bool jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_UnregisterVisual")]
            public static extern void UnregisterVisual(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_GetVisual")]
            public static extern global::System.IntPtr GetVisual(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_EnableVisual")]
            public static extern void EnableVisual(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, bool jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_IsVisualEnabled")]
            public static extern bool IsVisualEnabled(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_CreateTransition")]
            public static extern global::System.IntPtr CreateTransition(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_EmitKeyInputFocusSignal")]
            public static extern void EmitKeyInputFocusSignal(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewWrapperImpl_ApplyThemeStyle")]
            public static extern void ApplyThemeStyle(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetControlWrapperImpl__SWIG_0")]
            public static extern global::System.IntPtr GetControlWrapperImpl(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
