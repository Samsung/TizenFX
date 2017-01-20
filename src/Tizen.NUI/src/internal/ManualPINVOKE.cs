/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd.
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

namespace NUI
{
    class NDalicManualPINVOKE
    {
        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_new_KeyboardFocusManager")]
        public static extern global::System.IntPtr new_FocusManager();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_delete_KeyboardFocusManager")]
        public static extern void delete_FocusManager(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_KeyboardFocusManager_Get")]
        public static extern global::System.IntPtr FocusManager_Get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_KeyboardFocusManager_SetCurrentFocusActor")]
        public static extern bool FocusManager_SetCurrentFocusActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_KeyboardFocusManager_GetCurrentFocusActor")]
        public static extern global::System.IntPtr FocusManager_GetCurrentFocusActor(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_KeyboardFocusManager_MoveFocus")]
        public static extern bool FocusManager_MoveFocus(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_KeyboardFocusManager_ClearFocus")]
        public static extern void FocusManager_ClearFocus(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_KeyboardFocusManager_SetFocusGroupLoop")]
        public static extern void FocusManager_SetFocusGroupLoop(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_KeyboardFocusManager_GetFocusGroupLoop")]
        public static extern bool FocusManager_GetFocusGroupLoop(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_KeyboardFocusManager_SetAsFocusGroup")]
        public static extern void FocusManager_SetAsFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, bool jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_KeyboardFocusManager_IsFocusGroup")]
        public static extern bool FocusManager_IsFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_KeyboardFocusManager_GetFocusGroup")]
        public static extern global::System.IntPtr FocusManager_GetFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_KeyboardFocusManager_SetFocusIndicatorActor")]
        public static extern void FocusManager_SetFocusIndicatorActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_KeyboardFocusManager_GetFocusIndicatorActor")]
        public static extern global::System.IntPtr FocusManager_GetFocusIndicatorActor(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_KeyboardFocusManager_PreFocusChangeSignal")]
        public static extern global::System.IntPtr FocusManager_PreFocusChangeSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_KeyboardFocusManager_FocusChangedSignal")]
        public static extern global::System.IntPtr FocusManager_FocusChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_KeyboardFocusManager_FocusGroupChangedSignal")]
        public static extern global::System.IntPtr FocusManager_FocusGroupChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_KeyboardFocusManager_FocusedActorEnterKeySignal")]
        public static extern global::System.IntPtr FocusManager_FocusedActorEnterKeySignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_KeyboardPreFocusChangeSignal_Empty")]
        public static extern bool PreFocusChangeSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_KeyboardPreFocusChangeSignal_GetConnectionCount")]
        public static extern uint PreFocusChangeSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_KeyboardPreFocusChangeSignal_Connect")]
        public static extern void PreFocusChangeSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, FocusManager.PreFocusChangeEventCallback delegate1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_KeyboardPreFocusChangeSignal_Disconnect")]
        public static extern void PreFocusChangeSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_KeyboardPreFocusChangeSignal_Emit")]
        public static extern global::System.IntPtr PreFocusChangeSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, int jarg4);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_new_KeyboardPreFocusChangeSignal")]
        public static extern global::System.IntPtr new_PreFocusChangeSignal();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_delete_KeyboardPreFocusChangeSignal")]
        public static extern void delete_PreFocusChangeSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_KeyboardFocusManager_SWIGUpcast")]
        public static extern global::System.IntPtr FocusManager_SWIGUpcast(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewWrapperImpl_CONTROL_BEHAVIOUR_FLAG_COUNT_get")]
        public static extern int ViewWrapperImpl_CONTROL_BEHAVIOUR_FLAG_COUNT_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ViewWrapperImpl")]
        public static extern global::System.IntPtr new_ViewWrapperImpl(int jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewWrapperImpl_New")]
        public static extern global::System.IntPtr ViewWrapperImpl_New(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ViewWrapperImpl")]
        public static extern void delete_ViewWrapperImpl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewWrapperImpl_director_connect")]
        public static extern void ViewWrapperImpl_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, ViewWrapperImpl.DelegateViewWrapperImpl_0 delegate0, ViewWrapperImpl.DelegateViewWrapperImpl_1 delegate1, ViewWrapperImpl.DelegateViewWrapperImpl_2 delegate2, ViewWrapperImpl.DelegateViewWrapperImpl_3 delegate3, ViewWrapperImpl.DelegateViewWrapperImpl_4 delegate4, ViewWrapperImpl.DelegateViewWrapperImpl_5 delegate5, ViewWrapperImpl.DelegateViewWrapperImpl_6 delegate6, ViewWrapperImpl.DelegateViewWrapperImpl_7 delegate7, ViewWrapperImpl.DelegateViewWrapperImpl_8 delegate8, ViewWrapperImpl.DelegateViewWrapperImpl_9 delegate9, ViewWrapperImpl.DelegateViewWrapperImpl_10 delegate10, ViewWrapperImpl.DelegateViewWrapperImpl_11 delegate11, ViewWrapperImpl.DelegateViewWrapperImpl_12 delegate12, ViewWrapperImpl.DelegateViewWrapperImpl_13 delegate13, ViewWrapperImpl.DelegateViewWrapperImpl_14 delegate14, ViewWrapperImpl.DelegateViewWrapperImpl_15 delegate15, ViewWrapperImpl.DelegateViewWrapperImpl_16 delegate16, ViewWrapperImpl.DelegateViewWrapperImpl_17 delegate17, ViewWrapperImpl.DelegateViewWrapperImpl_18 delegate18, ViewWrapperImpl.DelegateViewWrapperImpl_19 delegate19, ViewWrapperImpl.DelegateViewWrapperImpl_20 delegate20, ViewWrapperImpl.DelegateViewWrapperImpl_21 delegate21, ViewWrapperImpl.DelegateViewWrapperImpl_22 delegate22, ViewWrapperImpl.DelegateViewWrapperImpl_23 delegate23, ViewWrapperImpl.DelegateViewWrapperImpl_24 delegate24, ViewWrapperImpl.DelegateViewWrapperImpl_25 delegate25, ViewWrapperImpl.DelegateViewWrapperImpl_26 delegate26, ViewWrapperImpl.DelegateViewWrapperImpl_27 delegate27, ViewWrapperImpl.DelegateViewWrapperImpl_28 delegate28, ViewWrapperImpl.DelegateViewWrapperImpl_29 delegate29, ViewWrapperImpl.DelegateViewWrapperImpl_30 delegate30, ViewWrapperImpl.DelegateViewWrapperImpl_31 delegate31, ViewWrapperImpl.DelegateViewWrapperImpl_32 delegate32, ViewWrapperImpl.DelegateViewWrapperImpl_33 delegate33, ViewWrapperImpl.DelegateViewWrapperImpl_34 delegate34, ViewWrapperImpl.DelegateViewWrapperImpl_35 delegate35, ViewWrapperImpl.DelegateViewWrapperImpl_36 delegate36, ViewWrapperImpl.DelegateViewWrapperImpl_37 delegate37, ViewWrapperImpl.DelegateViewWrapperImpl_38 delegate38, ViewWrapperImpl.DelegateViewWrapperImpl_39 delegate39, ViewWrapperImpl.DelegateViewWrapperImpl_40 delegate40);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GetControlWrapperImpl__SWIG_0")]
        public static extern global::System.IntPtr GetControlWrapperImpl__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewWrapper_New")]
        public static extern global::System.IntPtr ViewWrapper_New(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ViewWrapper__SWIG_0")]
        public static extern global::System.IntPtr new_ViewWrapper__SWIG_0();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ViewWrapper")]
        public static extern void delete_ViewWrapper(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ViewWrapper__SWIG_1")]
        public static extern global::System.IntPtr new_ViewWrapper__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewWrapper_Assign")]
        public static extern global::System.IntPtr ViewWrapper_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewWrapper_DownCast")]
        public static extern global::System.IntPtr ViewWrapper_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewWrapperImpl_SWIGUpcast")]
        public static extern global::System.IntPtr ViewWrapperImpl_SWIGUpcast(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewWrapper_SWIGUpcast")]
        public static extern global::System.IntPtr ViewWrapper_SWIGUpcast(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_ViewWrapperImpl_RelayoutRequest")]
        public static extern void ViewWrapperImpl_RelayoutRequest(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_ViewWrapperImpl_GetHeightForWidthBase")]
        public static extern float ViewWrapperImpl_GetHeightForWidthBase(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_ViewWrapperImpl_GetWidthForHeightBase")]
        public static extern float ViewWrapperImpl_GetWidthForHeightBase(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_ViewWrapperImpl_CalculateChildSizeBase")]
        public static extern float ViewWrapperImpl_CalculateChildSizeBase(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_0")]
        public static extern bool ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_1")]
        public static extern bool ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_ViewWrapperImpl_RegisterVisual__SWIG_0")]
        public static extern void ViewWrapperImpl_RegisterVisual__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_ViewWrapperImpl_RegisterVisual__SWIG_1")]
        public static extern void ViewWrapperImpl_RegisterVisual__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, bool jarg4);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_ViewWrapperImpl_UnregisterVisual")]
        public static extern void ViewWrapperImpl_UnregisterVisual(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_ViewWrapperImpl_GetVisual")]
        public static extern global::System.IntPtr ViewWrapperImpl_GetVisual(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_ViewWrapperImpl_EnableVisual")]
        public static extern void ViewWrapperImpl_EnableVisual(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, bool jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_ViewWrapperImpl_IsVisualEnabled")]
        public static extern bool ViewWrapperImpl_IsVisualEnabled(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_ViewWrapperImpl_CreateTransition")]
        public static extern global::System.IntPtr ViewWrapperImpl_CreateTransition(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_ViewWrapperImpl_EmitKeyInputFocusSignal")]
        public static extern void ViewWrapperImpl_EmitKeyInputFocusSignal(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewWrapperImpl_ApplyThemeStyle")]
        public static extern void ViewWrapperImpl_ApplyThemeStyle(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_MakeCallback")]
        public static extern global::System.IntPtr MakeCallback(global::System.Runtime.InteropServices.HandleRef jarg1);

    }
}
