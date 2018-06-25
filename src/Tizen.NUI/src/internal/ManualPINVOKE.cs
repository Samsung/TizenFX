/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd.
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
    class NDalicManualPINVOKE
    {
        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_new_KeyboardFocusManager")]
        public static extern global::System.IntPtr new_FocusManager();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_delete_KeyboardFocusManager")]
        public static extern void delete_FocusManager(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_KeyboardFocusManager_Get")]
        public static extern global::System.IntPtr FocusManager_Get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_KeyboardFocusManager_SetCurrentFocusActor")]
        public static extern bool FocusManager_SetCurrentFocusActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_KeyboardFocusManager_GetCurrentFocusActor")]
        public static extern global::System.IntPtr FocusManager_GetCurrentFocusActor(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_KeyboardFocusManager_MoveFocus")]
        public static extern bool FocusManager_MoveFocus(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_KeyboardFocusManager_ClearFocus")]
        public static extern void FocusManager_ClearFocus(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_KeyboardFocusManager_SetFocusGroupLoop")]
        public static extern void FocusManager_SetFocusGroupLoop(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_KeyboardFocusManager_GetFocusGroupLoop")]
        public static extern bool FocusManager_GetFocusGroupLoop(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_KeyboardFocusManager_SetAsFocusGroup")]
        public static extern void FocusManager_SetAsFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, bool jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_KeyboardFocusManager_IsFocusGroup")]
        public static extern bool FocusManager_IsFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_KeyboardFocusManager_GetFocusGroup")]
        public static extern global::System.IntPtr FocusManager_GetFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_KeyboardFocusManager_SetFocusIndicatorActor")]
        public static extern void FocusManager_SetFocusIndicatorActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_KeyboardFocusManager_GetFocusIndicatorActor")]
        public static extern global::System.IntPtr FocusManager_GetFocusIndicatorActor(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_KeyboardFocusManager_MoveFocusBackward")]
        public static extern void FocusManager_MoveFocusBackward(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_KeyboardFocusManager_PreFocusChangeSignal")]
        public static extern global::System.IntPtr FocusManager_PreFocusChangeSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_KeyboardFocusManager_FocusChangedSignal")]
        public static extern global::System.IntPtr FocusManager_FocusChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_KeyboardFocusManager_FocusGroupChangedSignal")]
        public static extern global::System.IntPtr FocusManager_FocusGroupChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_KeyboardFocusManager_FocusedActorEnterKeySignal")]
        public static extern global::System.IntPtr FocusManager_FocusedActorEnterKeySignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_KeyboardPreFocusChangeSignal_Empty")]
        public static extern bool PreFocusChangeSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_KeyboardPreFocusChangeSignal_GetConnectionCount")]
        public static extern uint PreFocusChangeSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_KeyboardPreFocusChangeSignal_Connect")]
        public static extern void PreFocusChangeSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, FocusManager.PreFocusChangeEventCallback delegate1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_KeyboardPreFocusChangeSignal_Disconnect")]
        public static extern void PreFocusChangeSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_KeyboardPreFocusChangeSignal_Emit")]
        public static extern global::System.IntPtr PreFocusChangeSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, int jarg4);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_new_KeyboardPreFocusChangeSignal")]
        public static extern global::System.IntPtr new_PreFocusChangeSignal();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_delete_KeyboardPreFocusChangeSignal")]
        public static extern void delete_PreFocusChangeSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_KeyboardFocusManager_SWIGUpcast")]
        public static extern global::System.IntPtr FocusManager_SWIGUpcast(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ViewWrapperImpl_CONTROL_BEHAVIOUR_FLAG_COUNT_get")]
        public static extern int ViewWrapperImpl_CONTROL_BEHAVIOUR_FLAG_COUNT_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_ViewWrapperImpl")]
        public static extern global::System.IntPtr new_ViewWrapperImpl(int jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ViewWrapperImpl_New")]
        public static extern global::System.IntPtr ViewWrapperImpl_New(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_ViewWrapperImpl")]
        public static extern void delete_ViewWrapperImpl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ViewWrapperImpl_director_connect")]
        public static extern void ViewWrapperImpl_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, ViewWrapperImpl.DelegateViewWrapperImpl_0 delegate0, ViewWrapperImpl.DelegateViewWrapperImpl_1 delegate1, ViewWrapperImpl.DelegateViewWrapperImpl_2 delegate2, ViewWrapperImpl.DelegateViewWrapperImpl_3 delegate3, ViewWrapperImpl.DelegateViewWrapperImpl_4 delegate4, ViewWrapperImpl.DelegateViewWrapperImpl_5 delegate5, ViewWrapperImpl.DelegateViewWrapperImpl_6 delegate6, ViewWrapperImpl.DelegateViewWrapperImpl_7 delegate7, ViewWrapperImpl.DelegateViewWrapperImpl_8 delegate8, ViewWrapperImpl.DelegateViewWrapperImpl_9 delegate9, ViewWrapperImpl.DelegateViewWrapperImpl_10 delegate10, ViewWrapperImpl.DelegateViewWrapperImpl_11 delegate11, ViewWrapperImpl.DelegateViewWrapperImpl_12 delegate12, ViewWrapperImpl.DelegateViewWrapperImpl_13 delegate13, ViewWrapperImpl.DelegateViewWrapperImpl_14 delegate14, ViewWrapperImpl.DelegateViewWrapperImpl_15 delegate15, ViewWrapperImpl.DelegateViewWrapperImpl_16 delegate16, ViewWrapperImpl.DelegateViewWrapperImpl_17 delegate17, ViewWrapperImpl.DelegateViewWrapperImpl_18 delegate18, ViewWrapperImpl.DelegateViewWrapperImpl_19 delegate19, ViewWrapperImpl.DelegateViewWrapperImpl_20 delegate20, ViewWrapperImpl.DelegateViewWrapperImpl_21 delegate21, ViewWrapperImpl.DelegateViewWrapperImpl_22 delegate22, ViewWrapperImpl.DelegateViewWrapperImpl_23 delegate23, ViewWrapperImpl.DelegateViewWrapperImpl_24 delegate24, ViewWrapperImpl.DelegateViewWrapperImpl_25 delegate25, ViewWrapperImpl.DelegateViewWrapperImpl_26 delegate26, ViewWrapperImpl.DelegateViewWrapperImpl_27 delegate27, ViewWrapperImpl.DelegateViewWrapperImpl_28 delegate28, ViewWrapperImpl.DelegateViewWrapperImpl_29 delegate29, ViewWrapperImpl.DelegateViewWrapperImpl_30 delegate30, ViewWrapperImpl.DelegateViewWrapperImpl_31 delegate31, ViewWrapperImpl.DelegateViewWrapperImpl_32 delegate32, ViewWrapperImpl.DelegateViewWrapperImpl_33 delegate33, ViewWrapperImpl.DelegateViewWrapperImpl_34 delegate34, ViewWrapperImpl.DelegateViewWrapperImpl_35 delegate35, ViewWrapperImpl.DelegateViewWrapperImpl_36 delegate36, ViewWrapperImpl.DelegateViewWrapperImpl_37 delegate37, ViewWrapperImpl.DelegateViewWrapperImpl_38 delegate38, ViewWrapperImpl.DelegateViewWrapperImpl_39 delegate39, ViewWrapperImpl.DelegateViewWrapperImpl_40 delegate40);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GetControlWrapperImpl__SWIG_0")]
        public static extern global::System.IntPtr GetControlWrapperImpl__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ViewWrapper_New")]
        public static extern global::System.IntPtr ViewWrapper_New(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_ViewWrapper__SWIG_0")]
        public static extern global::System.IntPtr new_ViewWrapper__SWIG_0();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_ViewWrapper")]
        public static extern void delete_ViewWrapper(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_ViewWrapper__SWIG_1")]
        public static extern global::System.IntPtr new_ViewWrapper__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ViewWrapper_Assign")]
        public static extern global::System.IntPtr ViewWrapper_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ViewWrapper_DownCast")]
        public static extern global::System.IntPtr ViewWrapper_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ViewWrapperImpl_SWIGUpcast")]
        public static extern global::System.IntPtr ViewWrapperImpl_SWIGUpcast(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ViewWrapper_SWIGUpcast")]
        public static extern global::System.IntPtr ViewWrapper_SWIGUpcast(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_ViewWrapperImpl_RelayoutRequest")]
        public static extern void ViewWrapperImpl_RelayoutRequest(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_ViewWrapperImpl_GetHeightForWidthBase")]
        public static extern float ViewWrapperImpl_GetHeightForWidthBase(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_ViewWrapperImpl_GetWidthForHeightBase")]
        public static extern float ViewWrapperImpl_GetWidthForHeightBase(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_ViewWrapperImpl_CalculateChildSizeBase")]
        public static extern float ViewWrapperImpl_CalculateChildSizeBase(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_0")]
        public static extern bool ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_1")]
        public static extern bool ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_ViewWrapperImpl_RegisterVisual__SWIG_0")]
        public static extern void ViewWrapperImpl_RegisterVisual__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_ViewWrapperImpl_RegisterVisual__SWIG_1")]
        public static extern void ViewWrapperImpl_RegisterVisual__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, bool jarg4);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_ViewWrapperImpl_UnregisterVisual")]
        public static extern void ViewWrapperImpl_UnregisterVisual(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_ViewWrapperImpl_GetVisual")]
        public static extern global::System.IntPtr ViewWrapperImpl_GetVisual(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_ViewWrapperImpl_EnableVisual")]
        public static extern void ViewWrapperImpl_EnableVisual(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, bool jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_ViewWrapperImpl_IsVisualEnabled")]
        public static extern bool ViewWrapperImpl_IsVisualEnabled(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_ViewWrapperImpl_CreateTransition")]
        public static extern global::System.IntPtr ViewWrapperImpl_CreateTransition(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_View_GetVisualResourceStatus")]
        public static extern int View_GetVisualResourceStatus(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_View_CreateTransition")]
        public static extern global::System.IntPtr View_CreateTransition(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_View_DoAction")]
        public static extern void View_DoAction(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);


        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_ViewWrapperImpl_EmitKeyInputFocusSignal")]
        public static extern void ViewWrapperImpl_EmitKeyInputFocusSignal(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ViewWrapperImpl_ApplyThemeStyle")]
        public static extern void ViewWrapperImpl_ApplyThemeStyle(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_EventThreadCallback")]
        public static extern global::System.IntPtr new_EventThreadCallback(EventThreadCallback.CallbackDelegate delegate1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_EventThreadCallback")]
        public static extern void delete_EventThreadCallback(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_EventThreadCallback_Trigger")]
        public static extern void EventThreadCallback_Trigger(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Actor_Property_SIBLING_ORDER_get")]
        public static extern int Actor_Property_SIBLING_ORDER_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Actor_Property_OPACITY_get")]
        public static extern int Actor_Property_OPACITY_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Actor_Property_SCREEN_POSITION_get")]
        public static extern int Actor_Property_SCREEN_POSITION_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Actor_Property_POSITION_USES_ANCHOR_POINT_get")]
        public static extern int Actor_Property_POSITION_USES_ANCHOR_POINT_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_View_Property_TOOLTIP_get")]
        public static extern int View_Property_TOOLTIP_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_View_Property_STATE_get")]
        public static extern int View_Property_STATE_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_View_Property_SUB_STATE_get")]
        public static extern int View_Property_SUB_STATE_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_View_Property_LEFT_FOCUSABLE_ACTOR_ID_get")]
        public static extern int View_Property_LEFT_FOCUSABLE_ACTOR_ID_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_View_Property_RIGHT_FOCUSABLE_ACTOR_ID_get")]
        public static extern int View_Property_RIGHT_FOCUSABLE_ACTOR_ID_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_View_Property_UP_FOCUSABLE_ACTOR_ID_get")]
        public static extern int View_Property_UP_FOCUSABLE_ACTOR_ID_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_View_Property_DOWN_FOCUSABLE_ACTOR_ID_get")]
        public static extern int View_Property_DOWN_FOCUSABLE_ACTOR_ID_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_ItemView_Property_LAYOUT_get")]
        public static extern int ItemView_Property_LAYOUT_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Button_Property_UNSELECTED_VISUAL_get")]
        public static extern int Button_Property_UNSELECTED_VISUAL_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Button_Property_SELECTED_VISUAL_get")]
        public static extern int Button_Property_SELECTED_VISUAL_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Button_Property_DISABLED_SELECTED_VISUAL_get")]
        public static extern int Button_Property_DISABLED_SELECTED_VISUAL_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Button_Property_DISABLED_UNSELECTED_VISUAL_get")]
        public static extern int Button_Property_DISABLED_UNSELECTED_VISUAL_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Button_Property_UNSELECTED_BACKGROUND_VISUAL_get")]
        public static extern int Button_Property_UNSELECTED_BACKGROUND_VISUAL_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Button_Property_SELECTED_BACKGROUND_VISUAL_get")]
        public static extern int Button_Property_SELECTED_BACKGROUND_VISUAL_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Button_Property_DISABLED_UNSELECTED_BACKGROUND_VISUAL_get")]
        public static extern int Button_Property_DISABLED_UNSELECTED_BACKGROUND_VISUAL_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Button_Property_DISABLED_SELECTED_BACKGROUND_VISUAL_get")]
        public static extern int Button_Property_DISABLED_SELECTED_BACKGROUND_VISUAL_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Button_Property_LABEL_RELATIVE_ALIGNMENT_get")]
        public static extern int Button_Property_LABEL_RELATIVE_ALIGNMENT_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Button_Property_LABEL_PADDING_get")]
        public static extern int Button_Property_LABEL_PADDING_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Button_Property_VISUAL_PADDING_get")]
        public static extern int Button_Property_VISUAL_PADDING_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Visual_Property_TRANSFORM_get")]
        public static extern int Visual_Property_TRANSFORM_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Visual_Property_PREMULTIPLIED_ALPHA_get")]
        public static extern int Visual_Property_PREMULTIPLIED_ALPHA_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Visual_Property_MIX_COLOR_get")]
        public static extern int Visual_Property_MIX_COLOR_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Image_Visual_BORDER_get")]
        public static extern int Image_Visual_BORDER_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_NativeVersionCheck")]
        public static extern bool NativeVersionCheck(ref int ver1, ref int ver2, ref int ver3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GrabKeyTopmost")]
        public static extern bool GrabKeyTopmost(System.IntPtr Window, int DaliKey);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_UngrabKeyTopmost")]
        public static extern bool UngrabKeyTopmost(System.IntPtr Window, int DaliKey);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GrabKey")]
        public static extern bool GrabKey(System.IntPtr Window, int DaliKey, int GrabMode);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_UngrabKey")]
        public static extern bool UngrabKey(System.IntPtr Window, int DaliKey);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GetNativeWindowHandler")]
        public static extern System.IntPtr GetNativeWindowHandler(System.IntPtr Window);

        //////////////////////InputMethodContext

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_SWIGUpcast")]
        public static extern global::System.IntPtr InputMethodContext_SWIGUpcast(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_InputMethodContext_EventData__SWIG_0")]
        public static extern global::System.IntPtr new_InputMethodContext_EventData__SWIG_0();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_InputMethodContext_EventData__SWIG_1")]
        public static extern global::System.IntPtr new_InputMethodContext_EventData__SWIG_1(int jarg1, string jarg2, int jarg3, int jarg4);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_EventData_predictiveString_set")]
        public static extern void InputMethodContext_EventData_predictiveString_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_EventData_predictiveString_get")]
        public static extern string InputMethodContext_EventData_predictiveString_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_EventData_eventName_set")]
        public static extern void InputMethodContext_EventData_eventName_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_EventData_eventName_get")]
        public static extern int InputMethodContext_EventData_eventName_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_EventData_cursorOffset_set")]
        public static extern void InputMethodContext_EventData_cursorOffset_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_EventData_cursorOffset_get")]
        public static extern int InputMethodContext_EventData_cursorOffset_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_EventData_numberOfChars_set")]
        public static extern void InputMethodContext_EventData_numberOfChars_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_EventData_numberOfChars_get")]
        public static extern int InputMethodContext_EventData_numberOfChars_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_InputMethodContext_EventData")]
        public static extern void delete_InputMethodContext_EventData(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_InputMethodContext_CallbackData__SWIG_0")]
        public static extern global::System.IntPtr new_InputMethodContext_CallbackData__SWIG_0();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_InputMethodContext_CallbackData__SWIG_1")]
        public static extern global::System.IntPtr new_InputMethodContext_CallbackData__SWIG_1(bool jarg1, int jarg2, string jarg3, bool jarg4);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_currentText_set")]
        public static extern void InputMethodContext_CallbackData_currentText_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_currentText_get")]
        public static extern string InputMethodContext_CallbackData_currentText_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_cursorPosition_set")]
        public static extern void InputMethodContext_CallbackData_cursorPosition_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_cursorPosition_get")]
        public static extern int InputMethodContext_CallbackData_cursorPosition_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_update_set")]
        public static extern void InputMethodContext_CallbackData_update_set(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_update_get")]
        public static extern bool InputMethodContext_CallbackData_update_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_preeditResetRequired_set")]
        public static extern void InputMethodContext_CallbackData_preeditResetRequired_set(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_preeditResetRequired_get")]
        public static extern bool InputMethodContext_CallbackData_preeditResetRequired_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_InputMethodContext_CallbackData")]
        public static extern void delete_InputMethodContext_CallbackData(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_Finalize")]
        public static extern void InputMethodContext_Finalize(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_InputMethodContext__SWIG_0")]
        public static extern global::System.IntPtr new_InputMethodContext__SWIG_0();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_InputMethodContext")]
        public static extern void delete_InputMethodContext(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_New")]
        public static extern global::System.IntPtr InputMethodContext_New();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_InputMethodContext__SWIG_1")]
        public static extern global::System.IntPtr new_InputMethodContext__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_Assign")]
        public static extern global::System.IntPtr InputMethodContext_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_DownCast")]
        public static extern global::System.IntPtr InputMethodContext_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_Activate")]
        public static extern void InputMethodContext_Activate(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_Deactivate")]
        public static extern void InputMethodContext_Deactivate(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_RestoreAfterFocusLost")]
        public static extern bool InputMethodContext_RestoreAfterFocusLost(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_SetRestoreAfterFocusLost")]
        public static extern void InputMethodContext_SetRestoreAfterFocusLost(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_Reset")]
        public static extern void InputMethodContext_Reset(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_NotifyCursorPosition")]
        public static extern void InputMethodContext_NotifyCursorPosition(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_SetCursorPosition")]
        public static extern void InputMethodContext_SetCursorPosition(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_GetCursorPosition")]
        public static extern uint InputMethodContext_GetCursorPosition(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_SetSurroundingText")]
        public static extern void InputMethodContext_SetSurroundingText(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_GetSurroundingText")]
        public static extern string InputMethodContext_GetSurroundingText(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_NotifyTextInputMultiLine")]
        public static extern void InputMethodContext_NotifyTextInputMultiLine(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_GetTextDirection")]
        public static extern int InputMethodContext_GetTextDirection(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_GetInputMethodArea")]
        public static extern global::System.IntPtr InputMethodContext_GetInputMethodArea(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_ApplyOptions")]
        public static extern void InputMethodContext_ApplyOptions(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_SetInputPanelUserData")]
        public static extern void InputMethodContext_SetInputPanelUserData(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_GetInputPanelUserData")]
        public static extern void InputMethodContext_GetInputPanelUserData(global::System.Runtime.InteropServices.HandleRef jarg1, out string jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_GetInputPanelState")]
        public static extern int InputMethodContext_GetInputPanelState(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_SetReturnKeyState")]
        public static extern void InputMethodContext_SetReturnKeyState(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_AutoEnableInputPanel")]
        public static extern void InputMethodContext_AutoEnableInputPanel(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_ShowInputPanel")]
        public static extern void InputMethodContext_ShowInputPanel(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_HideInputPanel")]
        public static extern void InputMethodContext_HideInputPanel(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_GetKeyboardType")]
        public static extern int InputMethodContext_GetKeyboardType(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_GetInputPanelLocale")]
        public static extern string InputMethodContext_GetInputPanelLocale(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_ActivatedSignal")]
        public static extern global::System.IntPtr InputMethodContext_ActivatedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_EventReceivedSignal")]
        public static extern global::System.IntPtr InputMethodContext_EventReceivedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_StatusChangedSignal")]
        public static extern global::System.IntPtr InputMethodContext_StatusChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_ResizedSignal")]
        public static extern global::System.IntPtr InputMethodContext_ResizedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_LanguageChangedSignal")]
        public static extern global::System.IntPtr InputMethodContext_LanguageChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodContext_KeyboardTypeChangedSignal")]
        public static extern global::System.IntPtr InputMethodContext_KeyboardTypeChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


        ////////////////////// InputMethodContext signals
        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ActivatedSignalType_Empty")]
        public static extern bool ActivatedSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ActivatedSignalType_GetConnectionCount")]
        public static extern uint ActivatedSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ActivatedSignalType_Connect")]
        public static extern void ActivatedSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ActivatedSignalType_Disconnect")]
        public static extern void ActivatedSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ActivatedSignalType_Emit")]
        public static extern void ActivatedSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_ActivatedSignalType")]
        public static extern global::System.IntPtr new_ActivatedSignalType();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_ActivatedSignalType")]
        public static extern void delete_ActivatedSignalType(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_KeyboardEventSignalType_Empty")]
        public static extern bool KeyboardEventSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_KeyboardEventSignalType_GetConnectionCount")]
        public static extern uint KeyboardEventSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_KeyboardEventSignalType_Connect")]
        public static extern void KeyboardEventSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_KeyboardEventSignalType_Disconnect")]
        public static extern void KeyboardEventSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_KeyboardEventSignalType_Emit")]
        public static extern global::System.IntPtr KeyboardEventSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_KeyboardEventSignalType")]
        public static extern global::System.IntPtr new_KeyboardEventSignalType();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_KeyboardEventSignalType")]
        public static extern void delete_KeyboardEventSignalType(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_VoidSignalType")]
        public static extern global::System.IntPtr new_VoidSignalType();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_VoidSignalType")]
        public static extern void delete_VoidSignalType(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VoidSignalType_Empty")]
        public static extern bool VoidSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VoidSignalType_GetConnectionCount")]
        public static extern uint VoidSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VoidSignalType_Connect__SWIG_0")]
        public static extern void VoidSignalType_Connect__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VoidSignalType_Disconnect")]
        public static extern void VoidSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VoidSignalType_Connect__SWIG_4")]
        public static extern void VoidSignalType_Connect__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VoidSignalType_Emit")]
        public static extern void VoidSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_StatusSignalType_Empty")]
        public static extern bool StatusSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_StatusSignalType_GetConnectionCount")]
        public static extern uint StatusSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_StatusSignalType_Connect")]
        public static extern void StatusSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_StatusSignalType_Disconnect")]
        public static extern void StatusSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_StatusSignalType_Emit")]
        public static extern void StatusSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_StatusSignalType")]
        public static extern global::System.IntPtr new_StatusSignalType();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_StatusSignalType")]
        public static extern void delete_StatusSignalType(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_KeyboardTypeSignalType_Empty")]
        public static extern bool KeyboardTypeSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_KeyboardTypeSignalType_GetConnectionCount")]
        public static extern uint KeyboardTypeSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_KeyboardTypeSignalType_Connect")]
        public static extern void KeyboardTypeSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_KeyboardTypeSignalType_Disconnect")]
        public static extern void KeyboardTypeSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_KeyboardTypeSignalType_Emit")]
        public static extern void KeyboardTypeSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_KeyboardTypeSignalType")]
        public static extern global::System.IntPtr new_KeyboardTypeSignalType();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_KeyboardTypeSignalType")]
        public static extern void delete_KeyboardTypeSignalType(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LanguageChangedSignalType_Empty")]
        public static extern bool LanguageChangedSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LanguageChangedSignalType_GetConnectionCount")]
        public static extern uint LanguageChangedSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LanguageChangedSignalType_Connect")]
        public static extern void LanguageChangedSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LanguageChangedSignalType_Disconnect")]
        public static extern void LanguageChangedSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LanguageChangedSignalType_Emit")]
        public static extern void LanguageChangedSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_LanguageChangedSignalType")]
        public static extern global::System.IntPtr new_LanguageChangedSignalType();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_LanguageChangedSignalType")]
        public static extern void delete_LanguageChangedSignalType(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_KeyboardResizedSignalType_Empty")]
        public static extern bool KeyboardResizedSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_KeyboardResizedSignalType_GetConnectionCount")]
        public static extern uint KeyboardResizedSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_KeyboardResizedSignalType_Connect")]
        public static extern void KeyboardResizedSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_KeyboardResizedSignalType_Disconnect")]
        public static extern void KeyboardResizedSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_KeyboardResizedSignalType_Emit")]
        public static extern void KeyboardResizedSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_KeyboardResizedSignalType")]
        public static extern global::System.IntPtr new_KeyboardResizedSignalType();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_KeyboardResizedSignalType")]
        public static extern void delete_KeyboardResizedSignalType(global::System.Runtime.InteropServices.HandleRef jarg1);

        //////////////////////InputMethodOptions

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_InputMethodOptions")]
        public static extern global::System.IntPtr new_InputMethodOptions();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodOptions_IsPassword")]
        public static extern bool InputMethodOptions_IsPassword(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodOptions_ApplyProperty")]
        public static extern void InputMethodOptions_ApplyProperty(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodOptions_RetrieveProperty")]
        public static extern void InputMethodOptions_RetrieveProperty(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_InputMethodOptions_CompareAndSet")]
        public static extern bool InputMethodOptions_CompareAndSet(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_InputMethodOptions")]
        public static extern void delete_InputMethodOptions(global::System.Runtime.InteropServices.HandleRef jarg1);


        /////////////////////////////////////////////////////////////
        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextEditor_Property_SMOOTH_SCROLL_get")]
        public static extern int TextEditor_Property_SMOOTH_SCROLL_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextEditor_Property_SMOOTH_SCROLL_DURATION_get")]
        public static extern int TextEditor_Property_SMOOTH_SCROLL_DURATION_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextEditor_Property_ENABLE_SCROLL_BAR_get")]
        public static extern int TextEditor_Property_ENABLE_SCROLL_BAR_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextEditor_Property_SCROLL_BAR_SHOW_DURATION_get")]
        public static extern int TextEditor_Property_SCROLL_BAR_SHOW_DURATION_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextEditor_Property_SCROLL_BAR_FADE_DURATION_get")]
        public static extern int TextEditor_Property_SCROLL_BAR_FADE_DURATION_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextEditor_Property_PIXEL_SIZE_get")]
        public static extern int TextEditor_Property_PIXEL_SIZE_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextEditor_Property_LINE_COUNT_get")]
        public static extern int TextEditor_Property_LINE_COUNT_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextEditor_Property_PLACEHOLDER_TEXT_get")]
        public static extern int TextEditor_Property_PLACEHOLDER_TEXT_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextEditor_Property_PLACEHOLDER_TEXT_COLOR_get")]
        public static extern int TextEditor_Property_PLACEHOLDER_TEXT_COLOR_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextEditor_Property_ENABLE_SELECTION_get")]
        public static extern int TextEditor_Property_ENABLE_SELECTION_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextEditor_Property_PLACEHOLDER_get")]
        public static extern int TextEditor_Property_PLACEHOLDER_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextEditor_Property_LINE_WRAP_MODE_get")]
        public static extern int TextEditor_Property_LINE_WRAP_MODE_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextField_Property_HIDDEN_INPUT_SETTINGS_get")]
        public static extern int TextField_Property_HIDDEN_INPUT_SETTINGS_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextField_Property_PIXEL_SIZE_get")]
        public static extern int TextField_Property_PIXEL_SIZE_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextField_Property_ENABLE_SELECTION_get")]
        public static extern int TextField_Property_ENABLE_SELECTION_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextField_Property_PLACEHOLDER_get")]
        public static extern int TextField_Property_PLACEHOLDER_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextField_Property_ELLIPSIS_get")]
        public static extern int TextField_Property_ELLIPSIS_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextLabel_Property_PIXEL_SIZE_get")]
        public static extern int TextLabel_Property_PIXEL_SIZE_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextLabel_Property_ELLIPSIS_get")]
        public static extern int TextLabel_Property_ELLIPSIS_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextLabel_Property_AUTO_SCROLL_STOP_MODE_get")]
        public static extern int TextLabel_Property_AUTO_SCROLL_STOP_MODE_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextLabel_Property_AUTO_SCROLL_LOOP_DELAY_get")]
        public static extern int TextLabel_Property_AUTO_SCROLL_LOOP_DELAY_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextLabel_Property_LINE_COUNT_get")]
        public static extern int TextLabel_Property_LINE_COUNT_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextLabel_Property_LINE_WRAP_MODE_get")]
        public static extern int TextLabel_Property_LINE_WRAP_MODE_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextLabel_Property_TEXT_DIRECTION_get")]
        public static extern int TextLabel_Property_TEXT_DIRECTION_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextLabel_Property_VERTICAL_LINE_ALIGNMENT_get")]
        public static extern int TextLabel_Property_VERTICAL_LINE_ALIGNMENT_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_HIDDENINPUT_PROPERTY_MODE_get")]
        public static extern int HIDDENINPUT_PROPERTY_MODE_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_HIDDENINPUT_PROPERTY_SUBSTITUTE_CHARACTER_get")]
        public static extern int HIDDENINPUT_PROPERTY_SUBSTITUTE_CHARACTER_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_HIDDENINPUT_PROPERTY_SUBSTITUTE_COUNT_get")]
        public static extern int HIDDENINPUT_PROPERTY_SUBSTITUTE_COUNT_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_HIDDENINPUT_PROPERTY_SHOW_LAST_CHARACTER_DURATION_get")]
        public static extern int HIDDENINPUT_PROPERTY_SHOW_LAST_CHARACTER_DURATION_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TtsPlayer_SWIGUpcast")]
        public static extern global::System.IntPtr TtsPlayer_SWIGUpcast(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_TtsPlayer__SWIG_0")]
        public static extern global::System.IntPtr new_TtsPlayer__SWIG_0();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TtsPlayer_Get__SWIG_0")]
        public static extern global::System.IntPtr TtsPlayer_Get__SWIG_0(int jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TtsPlayer_Get__SWIG_1")]
        public static extern global::System.IntPtr TtsPlayer_Get__SWIG_1();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_TtsPlayer")]
        public static extern void delete_TtsPlayer(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_TtsPlayer__SWIG_1")]
        public static extern global::System.IntPtr new_TtsPlayer__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TtsPlayer_Assign")]
        public static extern global::System.IntPtr TtsPlayer_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TtsPlayer_Play")]
        public static extern void TtsPlayer_Play(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TtsPlayer_Stop")]
        public static extern void TtsPlayer_Stop(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TtsPlayer_Pause")]
        public static extern void TtsPlayer_Pause(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TtsPlayer_Resume")]
        public static extern void TtsPlayer_Resume(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TtsPlayer_GetState")]
        public static extern int TtsPlayer_GetState(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TtsPlayer_StateChangedSignal")]
        public static extern global::System.IntPtr TtsPlayer_StateChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_StateChangedSignalType_Empty")]
        public static extern bool StateChangedSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_StateChangedSignalType_GetConnectionCount")]
        public static extern uint StateChangedSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_StateChangedSignalType_Connect")]
        public static extern void StateChangedSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_StateChangedSignalType_Disconnect")]
        public static extern void StateChangedSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_StateChangedSignalType_Emit")]
        public static extern void StateChangedSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_StateChangedSignalType")]
        public static extern global::System.IntPtr new_StateChangedSignalType();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_StateChangedSignalType")]
        public static extern void delete_StateChangedSignalType(global::System.Runtime.InteropServices.HandleRef jarg1);

        //manual pinvoke for text-editor ScrollStateChangedSignal
        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TextEditor_ScrollStateChangedSignal")]
        public static extern global::System.IntPtr TextEditor_ScrollStateChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollStateChangedSignal_Empty")]
        public static extern bool ScrollStateChangedSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollStateChangedSignal_GetConnectionCount")]
        public static extern uint ScrollStateChangedSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollStateChangedSignal_Connect")]
        public static extern void ScrollStateChangedSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollStateChangedSignal_Disconnect")]
        public static extern void ScrollStateChangedSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollStateChangedSignal_Emit")]
        public static extern void ScrollStateChangedSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_ScrollStateChangedSignal")]
        public static extern global::System.IntPtr new_ScrollStateChangedSignal();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_ScrollStateChangedSignal")]
        public static extern void delete_ScrollStateChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        // For windows resized signal
        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Window_ResizedSignal")]
        public static extern global::System.IntPtr Window_ResizedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ResizedSignal_Empty")]
        public static extern bool ResizedSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ResizedSignal_GetConnectionCount")]
        public static extern uint ResizedSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ResizedSignal_Connect")]
        public static extern void ResizedSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ResizedSignal_Disconnect")]
        public static extern void ResizedSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ResizedSignal_Emit")]
        public static extern void ResizedSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_ResizedSignal")]
        public static extern global::System.IntPtr new_ResizedSignal();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_ResizedSignal")]
        public static extern void delete_ResizedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Window_SetSize")]
        public static extern void SetSize(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Window_GetSize")]
        public static extern global::System.IntPtr GetSize(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Window_SetPosition")]
        public static extern void SetPosition(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Window_GetPosition")]
        public static extern global::System.IntPtr GetPosition(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Window_SetTransparency")]
        public static extern global::System.IntPtr SetTransparency(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Window_FeedKeyEvent")]
        public static extern void Window_FeedKeyEvent(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_MakeCallback")]
        public static extern global::System.IntPtr MakeCallback(global::System.Runtime.InteropServices.HandleRef jarg1);

        //for widget view
        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_Property_WIDGET_ID_get")]
        public static extern int WidgetView_Property_WIDGET_ID_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_Property_INSTANCE_ID_get")]
        public static extern int WidgetView_Property_INSTANCE_ID_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_Property_CONTENT_INFO_get")]
        public static extern int WidgetView_Property_CONTENT_INFO_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_Property_TITLE_get")]
        public static extern int WidgetView_Property_TITLE_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_Property_UPDATE_PERIOD_get")]
        public static extern int WidgetView_Property_UPDATE_PERIOD_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_Property_PREVIEW_get")]
        public static extern int WidgetView_Property_PREVIEW_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_Property_LOADING_TEXT_get")]
        public static extern int WidgetView_Property_LOADING_TEXT_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_Property_WIDGET_STATE_FAULTED_get")]
        public static extern int WidgetView_Property_WIDGET_STATE_FAULTED_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_Property_PERMANENT_DELETE_get")]
        public static extern int WidgetView_Property_PERMANENT_DELETE_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_Property_RETRY_TEXT_get")]
        public static extern int WidgetView_Property_RETRY_TEXT_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_Property_EFFECT_get")]
        public static extern int WidgetView_Property_EFFECT_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_WidgetView_Property")]
        public static extern global::System.IntPtr new_WidgetView_Property();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_WidgetView_Property")]
        public static extern void delete_WidgetView_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_New")]
        public static extern global::System.IntPtr WidgetView_New(string jarg1, string jarg2, int jarg3, int jarg4, float jarg5);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_DownCast")]
        public static extern global::System.IntPtr WidgetView_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_WidgetView__SWIG_0")]
        public static extern global::System.IntPtr new_WidgetView__SWIG_0();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_WidgetView__SWIG_1")]
        public static extern global::System.IntPtr new_WidgetView__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_Assign")]
        public static extern global::System.IntPtr WidgetView_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_WidgetView")]
        public static extern void delete_WidgetView(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_PauseWidget")]
        public static extern bool WidgetView_PauseWidget(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_ResumeWidget")]
        public static extern bool WidgetView_ResumeWidget(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_CancelTouchEvent")]
        public static extern bool WidgetView_CancelTouchEvent(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_ActivateFaultedWidget")]
        public static extern void WidgetView_ActivateFaultedWidget(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_TerminateWidget")]
        public static extern bool WidgetView_TerminateWidget(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_WidgetAddedSignal")]
        public static extern global::System.IntPtr WidgetView_WidgetAddedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_WidgetDeletedSignal")]
        public static extern global::System.IntPtr WidgetView_WidgetDeletedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_WidgetCreationAbortedSignal")]
        public static extern global::System.IntPtr WidgetView_WidgetCreationAbortedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_WidgetContentUpdatedSignal")]
        public static extern global::System.IntPtr WidgetView_WidgetContentUpdatedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_WidgetUpdatePeriodChangedSignal")]
        public static extern global::System.IntPtr WidgetView_WidgetUpdatePeriodChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_WidgetFaultedSignal")]
        public static extern global::System.IntPtr WidgetView_WidgetFaultedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetViewSignal_Empty")]
        public static extern bool WidgetViewSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetViewSignal_GetConnectionCount")]
        public static extern uint WidgetViewSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetViewSignal_Connect")]
        public static extern void WidgetViewSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetViewSignal_Disconnect")]
        public static extern void WidgetViewSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetViewSignal_Emit")]
        public static extern void WidgetViewSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_WidgetViewSignal")]
        public static extern global::System.IntPtr new_WidgetViewSignal();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_WidgetViewSignal")]
        public static extern void delete_WidgetViewSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_SWIGUpcast")]
        public static extern global::System.IntPtr WidgetView_SWIGUpcast(global::System.IntPtr jarg1);

        // For widget view manager
        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetViewManager_New")]
        public static extern global::System.IntPtr WidgetViewManager_New(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetViewManager_DownCast")]
        public static extern global::System.IntPtr WidgetViewManager_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_WidgetViewManager__SWIG_0")]
        public static extern global::System.IntPtr new_WidgetViewManager__SWIG_0();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_WidgetViewManager__SWIG_1")]
        public static extern global::System.IntPtr new_WidgetViewManager__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetViewManager_Assign")]
        public static extern global::System.IntPtr WidgetViewManager_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_WidgetViewManager")]
        public static extern void delete_WidgetViewManager(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetViewManager_AddWidget")]
        public static extern global::System.IntPtr WidgetViewManager_AddWidget(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, string jarg3, int jarg4, int jarg5, float jarg6);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetViewManager_SWIGUpcast")]
        public static extern global::System.IntPtr WidgetViewManager_SWIGUpcast(global::System.IntPtr jarg1);


        //For Adaptor
        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_New__SWIG_0")]
        public static extern global::System.IntPtr Adaptor_New__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_New__SWIG_1")]
        public static extern global::System.IntPtr Adaptor_New__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_New__SWIG_2")]
        public static extern global::System.IntPtr Adaptor_New__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_New__SWIG_3")]
        public static extern global::System.IntPtr Adaptor_New__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_Adaptor")]
        public static extern void delete_Adaptor(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_Start")]
        public static extern void Adaptor_Start(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_Pause")]
        public static extern void Adaptor_Pause(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_Resume")]
        public static extern void Adaptor_Resume(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_Stop")]
        public static extern void Adaptor_Stop(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_AddIdle")]
        public static extern bool Adaptor_AddIdle(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_RemoveIdle")]
        public static extern void Adaptor_RemoveIdle(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_ReplaceSurface")]
        public static extern void Adaptor_ReplaceSurface(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_GetSurface")]
        public static extern global::System.IntPtr Adaptor_GetSurface(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_GetNativeWindowHandle")]
        public static extern global::System.IntPtr Adaptor_GetNativeWindowHandle(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_ReleaseSurfaceLock")]
        public static extern void Adaptor_ReleaseSurfaceLock(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_SetRenderRefreshRate")]
        public static extern void Adaptor_SetRenderRefreshRate(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_SetUseHardwareVSync")]
        public static extern void Adaptor_SetUseHardwareVSync(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_Get")]
        public static extern global::System.IntPtr Adaptor_Get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_IsAvailable")]
        public static extern bool Adaptor_IsAvailable();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_NotifySceneCreated")]
        public static extern void Adaptor_NotifySceneCreated(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_NotifyLanguageChanged")]
        public static extern void Adaptor_NotifyLanguageChanged(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_SetMinimumPinchDistance")]
        public static extern void Adaptor_SetMinimumPinchDistance(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_FeedTouchPoint")]
        public static extern void Adaptor_FeedTouchPoint(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_FeedWheelEvent")]
        public static extern void Adaptor_FeedWheelEvent(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_FeedKeyEvent")]
        public static extern void Adaptor_FeedKeyEvent(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_SceneCreated")]
        public static extern void Adaptor_SceneCreated(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_SetViewMode")]
        public static extern void Adaptor_SetViewMode(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_SetStereoBase")]
        public static extern void Adaptor_SetStereoBase(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_ResizedSignal")]
        public static extern global::System.IntPtr Adaptor_ResizedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_LanguageChangedSignal")]
        public static extern global::System.IntPtr Adaptor_LanguageChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        //Adaptor Signal Type
        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AdaptorSignalType_Empty")]
        public static extern bool AdaptorSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AdaptorSignalType_GetConnectionCount")]
        public static extern uint AdaptorSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AdaptorSignalType_Connect")]
        public static extern void AdaptorSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AdaptorSignalType_Disconnect")]
        public static extern void AdaptorSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_AdaptorSignalType_Emit")]
        public static extern void AdaptorSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_AdaptorSignalType")]
        public static extern global::System.IntPtr new_AdaptorSignalType();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_AdaptorSignalType")]
        public static extern void delete_AdaptorSignalType(global::System.Runtime.InteropServices.HandleRef jarg1);

        //For widget

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Widget_SWIGUpcast")]
        public static extern global::System.IntPtr Widget_SWIGUpcast(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetImpl_SWIGUpcast")]
        public static extern global::System.IntPtr WidgetImpl_SWIGUpcast(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Widget_New__SWIG_0")]
        public static extern global::System.IntPtr Widget_New__SWIG_0();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Widget_New__SWIG_1")]
        public static extern global::System.IntPtr Widget_New__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);


        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_Widget")]
        public static extern global::System.IntPtr new_Widget();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Widget_Assign")]
        public static extern global::System.IntPtr Widget_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_Widget")]
        public static extern void delete_Widget(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetImpl_New")]
        public static extern global::System.IntPtr WidgetImpl_New();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetImpl_OnCreate")]
        public static extern void WidgetImpl_OnCreate(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetImpl_OnCreateSwigExplicitWidgetImpl")]
        public static extern void WidgetImpl_OnCreateSwigExplicitWidgetImpl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetImpl_OnTerminate")]
        public static extern void WidgetImpl_OnTerminate(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetImpl_OnTerminateSwigExplicitWidgetImpl")]
        public static extern void WidgetImpl_OnTerminateSwigExplicitWidgetImpl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetImpl_OnPause")]
        public static extern void WidgetImpl_OnPause(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetImpl_OnPauseSwigExplicitWidgetImpl")]
        public static extern void WidgetImpl_OnPauseSwigExplicitWidgetImpl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetImpl_OnResume")]
        public static extern void WidgetImpl_OnResume(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetImpl_OnResumeSwigExplicitWidgetImpl")]
        public static extern void WidgetImpl_OnResumeSwigExplicitWidgetImpl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetImpl_OnResize")]
        public static extern void WidgetImpl_OnResize(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetImpl_OnResizeSwigExplicitWidgetImpl")]
        public static extern void WidgetImpl_OnResizeSwigExplicitWidgetImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetImpl_OnUpdate")]
        public static extern void WidgetImpl_OnUpdate(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetImpl_OnUpdateSwigExplicitWidgetImpl")]
        public static extern void WidgetImpl_OnUpdateSwigExplicitWidgetImpl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetImpl_SignalConnected")]
        public static extern void WidgetImpl_SignalConnected(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetImpl_SignalConnectedSwigExplicitWidgetImpl")]
        public static extern void WidgetImpl_SignalConnectedSwigExplicitWidgetImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetImpl_SignalDisconnected")]
        public static extern void WidgetImpl_SignalDisconnected(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetImpl_SignalDisconnectedSwigExplicitWidgetImpl")]
        public static extern void WidgetImpl_SignalDisconnectedSwigExplicitWidgetImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetImpl_SetContentInfo")]
        public static extern void WidgetImpl_SetContentInfo(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetImpl_SetImpl")]
        public static extern void WidgetImpl_SetImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetImpl_director_connect")]
        public static extern void WidgetImpl_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, WidgetImpl.SwigDelegateWidgetImpl_0 delegate0, WidgetImpl.SwigDelegateWidgetImpl_1 delegate1, WidgetImpl.SwigDelegateWidgetImpl_2 delegate2, WidgetImpl.SwigDelegateWidgetImpl_3 delegate3, WidgetImpl.SwigDelegateWidgetImpl_4 delegate4, WidgetImpl.SwigDelegateWidgetImpl_5 delegate5, WidgetImpl.SwigDelegateWidgetImpl_6 delegate6, WidgetImpl.SwigDelegateWidgetImpl_7 delegate7);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Widget_GetImplementation__SWIG_0")]
        public static extern global::System.IntPtr Widget_GetImplementation__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetApplication_New")]
        public static extern global::System.IntPtr WidgetApplication_New(int jarg1, string jarg2, string jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_WidgetApplication__SWIG_0")]
        public static extern global::System.IntPtr new_WidgetApplication__SWIG_0();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_WidgetApplication__SWIG_1")]
        public static extern global::System.IntPtr new_WidgetApplication__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetApplication_Assign")]
        public static extern global::System.IntPtr WidgetApplication_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_WidgetApplication")]
        public static extern void delete_WidgetApplication(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetApplication_RegisterWidgetCreatingFunction")]
        public static extern void WidgetApplication_RegisterWidgetCreatingFunction(global::System.Runtime.InteropServices.HandleRef jarg1, ref string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);
        // End widget

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Actor_Property_INHERIT_LAYOUT_DIRECTION_get")]
        public static extern int Actor_Property_INHERIT_LAYOUT_DIRECTION_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Actor_Property_LAYOUT_DIRECTION_get")]
        public static extern int Actor_Property_LAYOUT_DIRECTION_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LayoutDirectionChangedSignal")]
        public static extern global::System.IntPtr LayoutDirectionChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ViewLayoutDirectionChangedSignal_Empty")]
        public static extern bool ViewLayoutDirectionChangedSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ViewLayoutDirectionSignal_GetConnectionCount")]
        public static extern uint ViewLayoutDirectionChangedSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ViewLayoutDirectionSignal_Connect")]
        public static extern void ViewLayoutDirectionChangedSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ViewLayoutDirectionSignal_Disconnect")]
        public static extern void ViewLayoutDirectionChangedSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ViewLayoutDirectionSignal_Emit")]
        public static extern void ViewLayoutDirectionChangedSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_View_SetLayout")]
        public static extern void View_SetLayout(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_View_GetLayout")]
        public static extern global::System.IntPtr View_GetLayout(global::System.Runtime.InteropServices.HandleRef jarg1);


        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_ViewLayoutDirectionSignal")]
        public static extern global::System.IntPtr new_ViewLayoutDirectionChangedSignal();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_ViewLayoutDirectionSignal")]
        public static extern void delete_ViewLayoutDirectionChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Adaptor_RenderOnce")]
        public static extern void Window_RenderOnce(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Window_New_Root_Layout")]
        public static extern global::System.IntPtr Window_NewRootLayout();

        //for watch
        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_WatchTime")]
        public static extern global::System.IntPtr new_WatchTime();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_WatchTime")]
        public static extern void delete_WatchTime(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchTime_GetHour")]
        public static extern int WatchTime_GetHour(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchTime_GetHour24")]
        public static extern int WatchTime_GetHour24(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchTime_GetMinute")]
        public static extern int WatchTime_GetMinute(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchTime_GetSecond")]
        public static extern int WatchTime_GetSecond(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchTime_GetMillisecond")]
        public static extern int WatchTime_GetMillisecond(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchTime_GetYear")]
        public static extern int WatchTime_GetYear(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchTime_GetMonth")]
        public static extern int WatchTime_GetMonth(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchTime_GetDay")]
        public static extern int WatchTime_GetDay(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchTime_GetDayOfWeek")]
        public static extern int WatchTime_GetDayOfWeek(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchTime_GetUtcTime")]
        public static extern global::System.IntPtr WatchTime_GetUtcTime(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchTime_GetUtcTimeStamp")]
        public static extern global::System.IntPtr WatchTime_GetUtcTimeStamp(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchTime_GetTimeZone")]
        public static extern string WatchTime_GetTimeZone(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchTime_GetDaylightSavingTimeStatus")]
        public static extern bool WatchTime_GetDaylightSavingTimeStatus(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchApplication_New__SWIG_0")]
        public static extern global::System.IntPtr WatchApplication_New__SWIG_0();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchApplication_New__SWIG_1")]
        public static extern global::System.IntPtr WatchApplication_New__SWIG_1(int jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchApplication_New__SWIG_2")]
        public static extern global::System.IntPtr WatchApplication_New__SWIG_2(int jarg1, string jarg2, string jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_WatchApplication__SWIG_0")]
        public static extern global::System.IntPtr new_WatchApplication__SWIG_0();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_WatchApplication__SWIG_1")]
        public static extern global::System.IntPtr new_WatchApplication__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchApplication_Assign")]
        public static extern global::System.IntPtr WatchApplication_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_WatchApplication")]
        public static extern void delete_WatchApplication(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchApplication_TimeTickSignal")]
        public static extern global::System.IntPtr WatchApplication_TimeTickSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchApplication_AmbientTickSignal")]
        public static extern global::System.IntPtr WatchApplication_AmbientTickSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchApplication_AmbientChangedSignal")]
        public static extern global::System.IntPtr WatchApplication_AmbientChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        //for watch signal
        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchTimeSignal_Empty")]
        public static extern bool WatchTimeSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchTimeSignal_GetConnectionCount")]
        public static extern uint WatchTimeSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchTimeSignal_Connect")]
        public static extern void WatchTimeSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchTimeSignal_Disconnect")]
        public static extern void WatchTimeSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchTimeSignal_Emit")]
        public static extern void WatchTimeSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_WatchTimeSignal")]
        public static extern global::System.IntPtr new_WatchTimeSignal();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_WatchTimeSignal")]
        public static extern void delete_WatchTimeSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchBoolSignal_Empty")]
        public static extern bool WatchBoolSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchBoolSignal_GetConnectionCount")]
        public static extern uint WatchBoolSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchBoolSignal_Connect")]
        public static extern void WatchBoolSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchBoolSignal_Disconnect")]
        public static extern void WatchBoolSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WatchBoolSignal_Emit")]
        public static extern void WatchBoolSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, bool jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_WatchBoolSignal")]
        public static extern global::System.IntPtr new_WatchBoolSignal();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_WatchBoolSignal")]
        public static extern void delete_WatchBoolSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        //for FontClient
        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_SWIGUpcast")]
        public static extern global::System.IntPtr FontClient_SWIGUpcast(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontWidthName_get")]
        public static extern global::System.IntPtr FontWidthName_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontWeightName_get")]
        public static extern global::System.IntPtr FontWeightName_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontSlantName_get")]
        public static extern global::System.IntPtr FontSlantName_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_FontDescription")]
        public static extern global::System.IntPtr new_FontDescription();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_FontDescription")]
        public static extern void delete_FontDescription(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontDescription_path_set")]
        public static extern void FontDescription_path_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontDescription_path_get")]
        public static extern string FontDescription_path_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontDescription_family_set")]
        public static extern void FontDescription_family_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontDescription_family_get")]
        public static extern string FontDescription_family_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontDescription_width_set")]
        public static extern void FontDescription_width_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontDescription_width_get")]
        public static extern int FontDescription_width_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontDescription_weight_set")]
        public static extern void FontDescription_weight_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontDescription_weight_get")]
        public static extern int FontDescription_weight_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontDescription_slant_set")]
        public static extern void FontDescription_slant_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontDescription_slant_get")]
        public static extern int FontDescription_slant_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_FontMetrics__SWIG_0")]
        public static extern global::System.IntPtr new_FontMetrics__SWIG_0();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_FontMetrics__SWIG_1")]
        public static extern global::System.IntPtr new_FontMetrics__SWIG_1(float jarg1, float jarg2, float jarg3, float jarg4, float jarg5);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontMetrics_ascender_set")]
        public static extern void FontMetrics_ascender_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontMetrics_ascender_get")]
        public static extern float FontMetrics_ascender_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontMetrics_descender_set")]
        public static extern void FontMetrics_descender_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontMetrics_descender_get")]
        public static extern float FontMetrics_descender_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontMetrics_height_set")]
        public static extern void FontMetrics_height_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontMetrics_height_get")]
        public static extern float FontMetrics_height_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontMetrics_underlinePosition_set")]
        public static extern void FontMetrics_underlinePosition_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontMetrics_underlinePosition_get")]
        public static extern float FontMetrics_underlinePosition_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontMetrics_underlineThickness_set")]
        public static extern void FontMetrics_underlineThickness_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontMetrics_underlineThickness_get")]
        public static extern float FontMetrics_underlineThickness_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_FontMetrics")]
        public static extern void delete_FontMetrics(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LINE_MUST_BREAK_get")]
        public static extern int LINE_MUST_BREAK_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LINE_ALLOW_BREAK_get")]
        public static extern int LINE_ALLOW_BREAK_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LINE_NO_BREAK_get")]
        public static extern int LINE_NO_BREAK_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WORD_BREAK_get")]
        public static extern int WORD_BREAK_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WORD_NO_BREAK_get")]
        public static extern int WORD_NO_BREAK_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VectorBlob_r_set")]
        public static extern void VectorBlob_r_set(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VectorBlob_r_get")]
        public static extern byte VectorBlob_r_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VectorBlob_g_set")]
        public static extern void VectorBlob_g_set(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VectorBlob_g_get")]
        public static extern byte VectorBlob_g_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VectorBlob_b_set")]
        public static extern void VectorBlob_b_set(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VectorBlob_b_get")]
        public static extern byte VectorBlob_b_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VectorBlob_a_set")]
        public static extern void VectorBlob_a_set(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VectorBlob_a_get")]
        public static extern byte VectorBlob_a_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_VectorBlob")]
        public static extern global::System.IntPtr new_VectorBlob();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_VectorBlob")]
        public static extern void delete_VectorBlob(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_GlyphInfo__SWIG_0")]
        public static extern global::System.IntPtr new_GlyphInfo__SWIG_0();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_GlyphInfo__SWIG_1")]
        public static extern global::System.IntPtr new_GlyphInfo__SWIG_1(uint jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GlyphInfo_fontId_set")]
        public static extern void GlyphInfo_fontId_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GlyphInfo_fontId_get")]
        public static extern uint GlyphInfo_fontId_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GlyphInfo_index_set")]
        public static extern void GlyphInfo_index_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GlyphInfo_index_get")]
        public static extern uint GlyphInfo_index_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GlyphInfo_width_set")]
        public static extern void GlyphInfo_width_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GlyphInfo_width_get")]
        public static extern float GlyphInfo_width_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GlyphInfo_height_set")]
        public static extern void GlyphInfo_height_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GlyphInfo_height_get")]
        public static extern float GlyphInfo_height_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GlyphInfo_xBearing_set")]
        public static extern void GlyphInfo_xBearing_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GlyphInfo_xBearing_get")]
        public static extern float GlyphInfo_xBearing_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GlyphInfo_yBearing_set")]
        public static extern void GlyphInfo_yBearing_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GlyphInfo_yBearing_get")]
        public static extern float GlyphInfo_yBearing_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GlyphInfo_advance_set")]
        public static extern void GlyphInfo_advance_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GlyphInfo_advance_get")]
        public static extern float GlyphInfo_advance_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GlyphInfo_scaleFactor_set")]
        public static extern void GlyphInfo_scaleFactor_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GlyphInfo_scaleFactor_get")]
        public static extern float GlyphInfo_scaleFactor_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_GlyphInfo")]
        public static extern void delete_GlyphInfo(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_DEFAULT_POINT_SIZE_get")]
        public static extern uint FontClient_DEFAULT_POINT_SIZE_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_FontClient_GlyphBufferData")]
        public static extern global::System.IntPtr new_FontClient_GlyphBufferData();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_FontClient_GlyphBufferData")]
        public static extern void delete_FontClient_GlyphBufferData(global::System.Runtime.InteropServices.HandleRef jarg1);
        /*
                [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FontClient_GlyphBufferData_buffer_set")]
                public static extern void FontClient_GlyphBufferData_buffer_set(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)]byte[] jarg2);

                [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FontClient_GlyphBufferData_buffer_get")]
                public static extern byte[] FontClient_GlyphBufferData_buffer_get(global::System.Runtime.InteropServices.HandleRef jarg1);
        */
        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_width_set")]
        public static extern void FontClient_GlyphBufferData_width_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_width_get")]
        public static extern uint FontClient_GlyphBufferData_width_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_height_set")]
        public static extern void FontClient_GlyphBufferData_height_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_height_get")]
        public static extern uint FontClient_GlyphBufferData_height_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_format_set")]
        public static extern void FontClient_GlyphBufferData_format_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_GlyphBufferData_format_get")]
        public static extern int FontClient_GlyphBufferData_format_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_Get")]
        public static extern global::System.IntPtr FontClient_Get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_FontClient__SWIG_0")]
        public static extern global::System.IntPtr new_FontClient__SWIG_0();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_FontClient")]
        public static extern void delete_FontClient(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_FontClient__SWIG_1")]
        public static extern global::System.IntPtr new_FontClient__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_Assign")]
        public static extern global::System.IntPtr FontClient_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_SetDpi")]
        public static extern void FontClient_SetDpi(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_GetDpi")]
        public static extern void FontClient_GetDpi(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_GetDefaultFontSize")]
        public static extern int FontClient_GetDefaultFontSize(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_ResetSystemDefaults")]
        public static extern void FontClient_ResetSystemDefaults(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_GetDefaultFonts")]
        public static extern void FontClient_GetDefaultFonts(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_GetDefaultPlatformFontDescription")]
        public static extern void FontClient_GetDefaultPlatformFontDescription(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_GetSystemFonts")]
        public static extern void FontClient_GetSystemFonts(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_GetDescription")]
        public static extern void FontClient_GetDescription(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_GetPointSize")]
        public static extern uint FontClient_GetPointSize(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_IsCharacterSupportedByFont")]
        public static extern bool FontClient_IsCharacterSupportedByFont(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_FindDefaultFont__SWIG_0")]
        public static extern uint FontClient_FindDefaultFont__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3, bool jarg4);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_FindDefaultFont__SWIG_1")]
        public static extern uint FontClient_FindDefaultFont__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_FindDefaultFont__SWIG_2")]
        public static extern uint FontClient_FindDefaultFont__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_FindFallbackFont__SWIG_0")]
        public static extern uint FontClient_FindFallbackFont__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, uint jarg4, bool jarg5);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_FindFallbackFont__SWIG_1")]
        public static extern uint FontClient_FindFallbackFont__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, uint jarg4);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_FindFallbackFont__SWIG_2")]
        public static extern uint FontClient_FindFallbackFont__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_0")]
        public static extern uint FontClient_GetFontId__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, uint jarg3, uint jarg4);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_1")]
        public static extern uint FontClient_GetFontId__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, uint jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_2")]
        public static extern uint FontClient_GetFontId__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_3")]
        public static extern uint FontClient_GetFontId__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3, uint jarg4);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_4")]
        public static extern uint FontClient_GetFontId__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_GetFontId__SWIG_5")]
        public static extern uint FontClient_GetFontId__SWIG_5(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_IsScalable__SWIG_0")]
        public static extern bool FontClient_IsScalable__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_IsScalable__SWIG_1")]
        public static extern bool FontClient_IsScalable__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_GetFixedSizes__SWIG_0")]
        public static extern void FontClient_GetFixedSizes__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_GetFixedSizes__SWIG_1")]
        public static extern void FontClient_GetFixedSizes__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_GetFontMetrics")]
        public static extern void FontClient_GetFontMetrics(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_GetGlyphIndex")]
        public static extern uint FontClient_GetGlyphIndex(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_GetGlyphMetrics__SWIG_0")]
        public static extern bool FontClient_GetGlyphMetrics__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3, int jarg4, bool jarg5);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_GetGlyphMetrics__SWIG_1")]
        public static extern bool FontClient_GetGlyphMetrics__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3, int jarg4);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_CreateBitmap__SWIG_0")]
        public static extern void FontClient_CreateBitmap__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, int jarg5);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_CreateBitmap__SWIG_1")]
        public static extern global::System.IntPtr FontClient_CreateBitmap__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3, int jarg4);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_CreateVectorBlob")]
        public static extern void FontClient_CreateVectorBlob(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5, global::System.Runtime.InteropServices.HandleRef jarg6, global::System.Runtime.InteropServices.HandleRef jarg7);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_GetEllipsisGlyph")]
        public static extern global::System.IntPtr FontClient_GetEllipsisGlyph(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_IsColorGlyph")]
        public static extern bool FontClient_IsColorGlyph(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FontClient_AddCustomFontDirectory")]
        public static extern bool FontClient_AddCustomFontDirectory(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextField_Property_ENABLE_SHIFT_SELECTION_get")]
        public static extern int TextField_Property_ENABLE_SHIFT_SELECTION_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextEditor_Property_ENABLE_SHIFT_SELECTION_get")]
        public static extern int TextEditor_Property_ENABLE_SHIFT_SELECTION_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_ImageView_IMAGE_VISUAL_ACTION_RELOAD_get")]
        public static extern int ImageView_IMAGE_VISUAL_ACTION_RELOAD_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_ImageView_IMAGE_VISUAL_ACTION_PLAY_get")]
        public static extern int ImageView_IMAGE_VISUAL_ACTION_PLAY_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_ImageView_IMAGE_VISUAL_ACTION_PAUSE_get")]
        public static extern int ImageView_IMAGE_VISUAL_ACTION_PAUSE_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_ImageView_IMAGE_VISUAL_ACTION_STOP_get")]
        public static extern int ImageView_IMAGE_VISUAL_ACTION_STOP_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_NUI_InternalAPIVersionCheck")]
        public static extern bool InternalAPIVersionCheck(ref int ver1, ref int ver2, ref int ver3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GetLayout__SWIG_0")]
        public static extern global::System.IntPtr GetLayout__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GetLayout__SWIG_1")]
        public static extern global::System.IntPtr GetLayout__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_SetLayout__SWIG_0")]
        public static extern void SetLayout__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_SetLayout__SWIG_1")]
        public static extern void SetLayout__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Touch_GetMouseButton")]
        public static extern int Touch_GetMouseButton(global::System.Runtime.InteropServices.HandleRef jarg1, ulong jarg2);

    }
}
