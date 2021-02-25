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
        internal static partial class ViewImpl
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_New")]
            public static extern global::System.IntPtr New();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_SetStyleName")]
            public static extern void SetStyleName(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_GetStyleName")]
            public static extern string GetStyleName(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_SetBackgroundColor")]
            public static extern void SetBackgroundColor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_GetBackgroundColor")]
            public static extern global::System.IntPtr GetBackgroundColor(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_SetBackground")]
            public static extern void SetBackground(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_ClearBackground")]
            public static extern void ClearBackground(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_EnableGestureDetection")]
            public static extern void EnableGestureDetection(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_DisableGestureDetection")]
            public static extern void DisableGestureDetection(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_GetPinchGestureDetector")]
            public static extern global::System.IntPtr GetPinchGestureDetector(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_GetPanGestureDetector")]
            public static extern global::System.IntPtr GetPanGestureDetector(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_GetTapGestureDetector")]
            public static extern global::System.IntPtr GetTapGestureDetector(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_GetLongPressGestureDetector")]
            public static extern global::System.IntPtr GetLongPressGestureDetector(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_SetKeyboardNavigationSupport")]
            public static extern void SetKeyboardNavigationSupport(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_IsKeyboardNavigationSupported")]
            public static extern bool IsKeyboardNavigationSupported(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_SetKeyInputFocus")]
            public static extern void SetKeyInputFocus(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_HasKeyInputFocus")]
            public static extern bool HasKeyInputFocus(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_ClearKeyInputFocus")]
            public static extern void ClearKeyInputFocus(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_SetAsKeyboardFocusGroup")]
            public static extern void SetAsKeyboardFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_IsKeyboardFocusGroup")]
            public static extern bool IsKeyboardFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_AccessibilityActivate")]
            public static extern void AccessibilityActivate(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_KeyboardEnter")]
            public static extern void KeyboardEnter(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_GetNaturalSize")]
            public static extern global::System.IntPtr GetNaturalSize(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_GetNaturalSizeSwigExplicitViewImpl")]
            public static extern global::System.IntPtr GetNaturalSizeSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_CalculateChildSize")]
            public static extern float CalculateChildSize(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_CalculateChildSizeSwigExplicitViewImpl")]
            public static extern float CalculateChildSizeSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_GetHeightForWidth")]
            public static extern float GetHeightForWidth(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_GetHeightForWidthSwigExplicitViewImpl")]
            public static extern float GetHeightForWidthSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_GetWidthForHeight")]
            public static extern float GetWidthForHeight(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_GetWidthForHeightSwigExplicitViewImpl")]
            public static extern float GetWidthForHeightSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_RelayoutDependentOnChildren__SWIG_0")]
            public static extern bool RelayoutDependentOnChildren(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_RelayoutDependentOnChildrenSwigExplicitViewImpl__SWIG_0")]
            public static extern bool RelayoutDependentOnChildrenSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_RelayoutDependentOnChildren__SWIG_1")]
            public static extern bool RelayoutDependentOnChildren(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_RelayoutDependentOnChildrenSwigExplicitViewImpl__SWIG_1")]
            public static extern bool RelayoutDependentOnChildrenSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_GetNextKeyboardFocusableActor")]
            public static extern global::System.IntPtr GetNextKeyboardFocusableActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, bool jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_GetNextKeyboardFocusableActorSwigExplicitViewImpl")]
            public static extern global::System.IntPtr GetNextKeyboardFocusableActorSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, bool jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_director_connect")]
            public static extern void DirectorConnect(global::System.Runtime.InteropServices.HandleRef jarg1,
                Tizen.NUI.ViewImpl.SwigDelegateViewImpl_0 delegate0, Tizen.NUI.ViewImpl.SwigDelegateViewImpl_1 delegate1,
                Tizen.NUI.ViewImpl.SwigDelegateViewImpl_2 delegate2, Tizen.NUI.ViewImpl.SwigDelegateViewImpl_3 delegate3,
                Tizen.NUI.ViewImpl.SwigDelegateViewImpl_4 delegate4, Tizen.NUI.ViewImpl.SwigDelegateViewImpl_5 delegate5,
                Tizen.NUI.ViewImpl.SwigDelegateViewImpl_6 delegate6, Tizen.NUI.ViewImpl.SwigDelegateViewImpl_9 delegate9,
                Tizen.NUI.ViewImpl.SwigDelegateViewImpl_11 delegate11,
                Tizen.NUI.ViewImpl.SwigDelegateViewImpl_12 delegate12, Tizen.NUI.ViewImpl.SwigDelegateViewImpl_13 delegate13,
                Tizen.NUI.ViewImpl.SwigDelegateViewImpl_14 delegate14, Tizen.NUI.ViewImpl.SwigDelegateViewImpl_15 delegate15,
                Tizen.NUI.ViewImpl.SwigDelegateViewImpl_16 delegate16, Tizen.NUI.ViewImpl.SwigDelegateViewImpl_17 delegate17,
                Tizen.NUI.ViewImpl.SwigDelegateViewImpl_18 delegate18, Tizen.NUI.ViewImpl.SwigDelegateViewImpl_19 delegate19,
                Tizen.NUI.ViewImpl.SwigDelegateViewImpl_20 delegate20, Tizen.NUI.ViewImpl.SwigDelegateViewImpl_21 delegate21,
                Tizen.NUI.ViewImpl.SwigDelegateViewImpl_24 delegate24, Tizen.NUI.ViewImpl.SwigDelegateViewImpl_25 delegate25,
                Tizen.NUI.ViewImpl.SwigDelegateViewImpl_26 delegate26,
                Tizen.NUI.ViewImpl.SwigDelegateViewImpl_28 delegate28, Tizen.NUI.ViewImpl.SwigDelegateViewImpl_29 delegate29,
                Tizen.NUI.ViewImpl.SwigDelegateViewImpl_30 delegate30, Tizen.NUI.ViewImpl.SwigDelegateViewImpl_31 delegate31,
                Tizen.NUI.ViewImpl.SwigDelegateViewImpl_32 delegate32, Tizen.NUI.ViewImpl.SwigDelegateViewImpl_33 delegate33,
                Tizen.NUI.ViewImpl.SwigDelegateViewImpl_34 delegate34, Tizen.NUI.ViewImpl.SwigDelegateViewImpl_35 delegate35,
                Tizen.NUI.ViewImpl.SwigDelegateViewImpl_36 delegate36, Tizen.NUI.ViewImpl.SwigDelegateViewImpl_37 delegate37,
                Tizen.NUI.ViewImpl.SwigDelegateViewImpl_38 delegate38, Tizen.NUI.ViewImpl.SwigDelegateViewImpl_39 delegate39,
                Tizen.NUI.ViewImpl.SwigDelegateViewImpl_40 delegate40);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewImpl_SWIGUpcast")]
            public static extern global::System.IntPtr Upcast(global::System.IntPtr jarg1);
        }
    }
}
