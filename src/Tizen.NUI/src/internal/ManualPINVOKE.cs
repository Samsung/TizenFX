/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
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
        public static extern global::System.IntPtr ViewWrapperImpl_New(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ViewWrapperImpl")]
        public static extern void delete_ViewWrapperImpl(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewWrapperImpl_director_connect")]
        public static extern void ViewWrapperImpl_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, ViewWrapperImpl.DelegateViewWrapperImpl_0 delegate0, ViewWrapperImpl.DelegateViewWrapperImpl_1 delegate1, ViewWrapperImpl.DelegateViewWrapperImpl_2 delegate2, ViewWrapperImpl.DelegateViewWrapperImpl_3 delegate3, ViewWrapperImpl.DelegateViewWrapperImpl_4 delegate4, ViewWrapperImpl.DelegateViewWrapperImpl_5 delegate5, ViewWrapperImpl.DelegateViewWrapperImpl_6 delegate6, ViewWrapperImpl.DelegateViewWrapperImpl_7 delegate7, ViewWrapperImpl.DelegateViewWrapperImpl_8 delegate8, ViewWrapperImpl.DelegateViewWrapperImpl_9 delegate9, ViewWrapperImpl.DelegateViewWrapperImpl_10 delegate10, ViewWrapperImpl.DelegateViewWrapperImpl_11 delegate11, ViewWrapperImpl.DelegateViewWrapperImpl_12 delegate12, ViewWrapperImpl.DelegateViewWrapperImpl_13 delegate13, ViewWrapperImpl.DelegateViewWrapperImpl_14 delegate14, ViewWrapperImpl.DelegateViewWrapperImpl_15 delegate15, ViewWrapperImpl.DelegateViewWrapperImpl_16 delegate16, ViewWrapperImpl.DelegateViewWrapperImpl_17 delegate17, ViewWrapperImpl.DelegateViewWrapperImpl_18 delegate18, ViewWrapperImpl.DelegateViewWrapperImpl_19 delegate19, ViewWrapperImpl.DelegateViewWrapperImpl_20 delegate20, ViewWrapperImpl.DelegateViewWrapperImpl_21 delegate21, ViewWrapperImpl.DelegateViewWrapperImpl_22 delegate22, ViewWrapperImpl.DelegateViewWrapperImpl_23 delegate23, ViewWrapperImpl.DelegateViewWrapperImpl_24 delegate24, ViewWrapperImpl.DelegateViewWrapperImpl_25 delegate25, ViewWrapperImpl.DelegateViewWrapperImpl_26 delegate26, ViewWrapperImpl.DelegateViewWrapperImpl_27 delegate27, ViewWrapperImpl.DelegateViewWrapperImpl_28 delegate28, ViewWrapperImpl.DelegateViewWrapperImpl_29 delegate29, ViewWrapperImpl.DelegateViewWrapperImpl_30 delegate30, ViewWrapperImpl.DelegateViewWrapperImpl_31 delegate31, ViewWrapperImpl.DelegateViewWrapperImpl_32 delegate32, ViewWrapperImpl.DelegateViewWrapperImpl_33 delegate33, ViewWrapperImpl.DelegateViewWrapperImpl_34 delegate34, ViewWrapperImpl.DelegateViewWrapperImpl_35 delegate35, ViewWrapperImpl.DelegateViewWrapperImpl_36 delegate36, ViewWrapperImpl.DelegateViewWrapperImpl_37 delegate37, ViewWrapperImpl.DelegateViewWrapperImpl_38 delegate38, ViewWrapperImpl.DelegateViewWrapperImpl_39 delegate39, ViewWrapperImpl.DelegateViewWrapperImpl_40 delegate40);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GetControlWrapperImpl__SWIG_0")]
        public static extern global::System.IntPtr GetControlWrapperImpl__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewWrapper_New")]
        public static extern global::System.IntPtr ViewWrapper_New(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

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

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_CreateTransition")]
        public static extern global::System.IntPtr View_CreateTransition(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_ViewWrapperImpl_EmitKeyInputFocusSignal")]
        public static extern void ViewWrapperImpl_EmitKeyInputFocusSignal(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewWrapperImpl_ApplyThemeStyle")]
        public static extern void ViewWrapperImpl_ApplyThemeStyle(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_EventThreadCallback")]
        public static extern global::System.IntPtr new_EventThreadCallback(EventThreadCallback.CallbackDelegate delegate1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_EventThreadCallback")]
        public static extern void delete_EventThreadCallback(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_EventThreadCallback_Trigger")]
        public static extern void EventThreadCallback_Trigger(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Actor_Property_SIBLING_ORDER_get")]
        public static extern int Actor_Property_SIBLING_ORDER_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Actor_Property_OPACITY_get")]
        public static extern int Actor_Property_OPACITY_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Actor_Property_SCREEN_POSITION_get")]
        public static extern int Actor_Property_SCREEN_POSITION_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Actor_Property_POSITION_USES_ANCHOR_POINT_get")]
        public static extern int Actor_Property_POSITION_USES_ANCHOR_POINT_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_View_Property_TOOLTIP_get")]
        public static extern int View_Property_TOOLTIP_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_View_Property_STATE_get")]
        public static extern int View_Property_STATE_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_View_Property_SUB_STATE_get")]
        public static extern int View_Property_SUB_STATE_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_View_Property_LEFT_FOCUSABLE_ACTOR_ID_get")]
        public static extern int View_Property_LEFT_FOCUSABLE_ACTOR_ID_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_View_Property_RIGHT_FOCUSABLE_ACTOR_ID_get")]
        public static extern int View_Property_RIGHT_FOCUSABLE_ACTOR_ID_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_View_Property_UP_FOCUSABLE_ACTOR_ID_get")]
        public static extern int View_Property_UP_FOCUSABLE_ACTOR_ID_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_View_Property_DOWN_FOCUSABLE_ACTOR_ID_get")]
        public static extern int View_Property_DOWN_FOCUSABLE_ACTOR_ID_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_ItemView_Property_LAYOUT_get")]
        public static extern int ItemView_Property_LAYOUT_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Button_Property_UNSELECTED_VISUAL_get")]
        public static extern int Button_Property_UNSELECTED_VISUAL_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Button_Property_SELECTED_VISUAL_get")]
        public static extern int Button_Property_SELECTED_VISUAL_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Button_Property_DISABLED_SELECTED_VISUAL_get")]
        public static extern int Button_Property_DISABLED_SELECTED_VISUAL_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Button_Property_DISABLED_UNSELECTED_VISUAL_get")]
        public static extern int Button_Property_DISABLED_UNSELECTED_VISUAL_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Button_Property_UNSELECTED_BACKGROUND_VISUAL_get")]
        public static extern int Button_Property_UNSELECTED_BACKGROUND_VISUAL_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Button_Property_SELECTED_BACKGROUND_VISUAL_get")]
        public static extern int Button_Property_SELECTED_BACKGROUND_VISUAL_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Button_Property_DISABLED_UNSELECTED_BACKGROUND_VISUAL_get")]
        public static extern int Button_Property_DISABLED_UNSELECTED_BACKGROUND_VISUAL_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Button_Property_DISABLED_SELECTED_BACKGROUND_VISUAL_get")]
        public static extern int Button_Property_DISABLED_SELECTED_BACKGROUND_VISUAL_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Button_Property_LABEL_RELATIVE_ALIGNMENT_get")]
        public static extern int Button_Property_LABEL_RELATIVE_ALIGNMENT_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Button_Property_LABEL_PADDING_get")]
        public static extern int Button_Property_LABEL_PADDING_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Button_Property_VISUAL_PADDING_get")]
        public static extern int Button_Property_VISUAL_PADDING_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Visual_Property_TRANSFORM_get")]
        public static extern int Visual_Property_TRANSFORM_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Visual_Property_PREMULTIPLIED_ALPHA_get")]
        public static extern int Visual_Property_PREMULTIPLIED_ALPHA_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Visual_Property_MIX_COLOR_get")]
        public static extern int Visual_Property_MIX_COLOR_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Image_Visual_BORDER_get")]
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




        ///////////////////////////////////////////////////////////
        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ActivatedSignalType_Empty")]
        public static extern bool ActivatedSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ActivatedSignalType_GetConnectionCount")]
        public static extern uint ActivatedSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ActivatedSignalType_Connect")]
        public static extern void ActivatedSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ActivatedSignalType_Disconnect")]
        public static extern void ActivatedSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ActivatedSignalType_Emit")]
        public static extern void ActivatedSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_ActivatedSignalType")]
        public static extern global::System.IntPtr new_ActivatedSignalType();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_ActivatedSignalType")]
        public static extern void delete_ActivatedSignalType(global::System.Runtime.InteropServices.HandleRef jarg1);


        ///////////////////////////////////////////////////////////
        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfEventSignalType_Empty")]
        public static extern bool ImfEventSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfEventSignalType_GetConnectionCount")]
        public static extern uint ImfEventSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfEventSignalType_Connect")]
        public static extern void ImfEventSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfEventSignalType_Disconnect")]
        public static extern void ImfEventSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfEventSignalType_Emit")]
        public static extern void ImfEventSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2, bool jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_ImfEventSignalType")]
        public static extern global::System.IntPtr new_ImfEventSignalType();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_ImfEventSignalType")]
        public static extern void delete_ImfEventSignalType(global::System.Runtime.InteropServices.HandleRef jarg1);


        ///////////////////////////////////////////////////////////
        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfVoidSignalType_Empty")]
        public static extern bool ImfVoidSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfVoidSignalType_GetConnectionCount")]
        public static extern uint ImfVoidSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfVoidSignalType_Connect")]
        public static extern void ImfVoidSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfVoidSignalType_Disconnect")]
        public static extern void ImfVoidSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfVoidSignalType_Emit")]
        public static extern void ImfVoidSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_ImfVoidSignalType")]
        public static extern global::System.IntPtr new_ImfVoidSignalType();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_ImfVoidSignalType")]
        public static extern void delete_ImfVoidSignalType(global::System.Runtime.InteropServices.HandleRef jarg1);


        ///////////////////////////////////////////////////////////
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



        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_ImfManager_ImfEventData__SWIG_0")]
        public static extern global::System.IntPtr new_ImfManager_ImfEventData__SWIG_0();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_ImfManager_ImfEventData__SWIG_1")]
        public static extern global::System.IntPtr new_ImfManager_ImfEventData__SWIG_1(int jarg1, string jarg2, int jarg3, int jarg4);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_ImfEventData_predictiveString_set")]
        public static extern void ImfManager_ImfEventData_predictiveString_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_ImfEventData_predictiveString_get")]
        public static extern string ImfManager_ImfEventData_predictiveString_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_ImfEventData_eventName_set")]
        public static extern void ImfManager_ImfEventData_eventName_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_ImfEventData_eventName_get")]
        public static extern int ImfManager_ImfEventData_eventName_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_ImfEventData_cursorOffset_set")]
        public static extern void ImfManager_ImfEventData_cursorOffset_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_ImfEventData_cursorOffset_get")]
        public static extern int ImfManager_ImfEventData_cursorOffset_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_ImfEventData_numberOfChars_set")]
        public static extern void ImfManager_ImfEventData_numberOfChars_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_ImfEventData_numberOfChars_get")]
        public static extern int ImfManager_ImfEventData_numberOfChars_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_ImfManager_ImfEventData")]
        public static extern void delete_ImfManager_ImfEventData(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_ImfManager_ImfCallbackData__SWIG_0")]
        public static extern global::System.IntPtr new_ImfManager_ImfCallbackData__SWIG_0();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_ImfManager_ImfCallbackData__SWIG_1")]
        public static extern global::System.IntPtr new_ImfManager_ImfCallbackData__SWIG_1(bool jarg1, int jarg2, string jarg3, bool jarg4);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_ImfCallbackData_currentText_set")]
        public static extern void ImfManager_ImfCallbackData_currentText_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_ImfCallbackData_currentText_get")]
        public static extern string ImfManager_ImfCallbackData_currentText_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_ImfCallbackData_cursorPosition_set")]
        public static extern void ImfManager_ImfCallbackData_cursorPosition_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_ImfCallbackData_cursorPosition_get")]
        public static extern int ImfManager_ImfCallbackData_cursorPosition_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_ImfCallbackData_update_set")]
        public static extern void ImfManager_ImfCallbackData_update_set(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_ImfCallbackData_update_get")]
        public static extern bool ImfManager_ImfCallbackData_update_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_ImfCallbackData_preeditResetRequired_set")]
        public static extern void ImfManager_ImfCallbackData_preeditResetRequired_set(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_ImfCallbackData_preeditResetRequired_get")]
        public static extern bool ImfManager_ImfCallbackData_preeditResetRequired_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_ImfManager_ImfCallbackData")]
        public static extern void delete_ImfManager_ImfCallbackData(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_Get")]
        public static extern global::System.IntPtr ImfManager_Get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_Activate")]
        public static extern void ImfManager_Activate(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_Deactivate")]
        public static extern void ImfManager_Deactivate(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_RestoreAfterFocusLost")]
        public static extern bool ImfManager_RestoreAfterFocusLost(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_SetRestoreAfterFocusLost")]
        public static extern void ImfManager_SetRestoreAfterFocusLost(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_Reset")]
        public static extern void ImfManager_Reset(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_NotifyCursorPosition")]
        public static extern void ImfManager_NotifyCursorPosition(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_SetCursorPosition")]
        public static extern void ImfManager_SetCursorPosition(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_GetCursorPosition")]
        public static extern uint ImfManager_GetCursorPosition(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_SetSurroundingText")]
        public static extern void ImfManager_SetSurroundingText(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_GetSurroundingText")]
        public static extern string ImfManager_GetSurroundingText(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_NotifyTextInputMultiLine")]
        public static extern void ImfManager_NotifyTextInputMultiLine(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_GetTextDirection")]
        public static extern int ImfManager_GetTextDirection(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_GetInputMethodArea")]
        public static extern global::System.IntPtr ImfManager_GetInputMethodArea(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_ApplyOptions")]
        public static extern void ImfManager_ApplyOptions(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_SetInputPanelUserData")]
        public static extern void ImfManager_SetInputPanelUserData(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_GetInputPanelUserData")]
        public static extern void ImfManager_GetInputPanelUserData(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_GetInputPanelState")]
        public static extern int ImfManager_GetInputPanelState(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_SetReturnKeyState")]
        public static extern void ImfManager_SetReturnKeyState(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_AutoEnableInputPanel")]
        public static extern void ImfManager_AutoEnableInputPanel(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_ShowInputPanel")]
        public static extern void ImfManager_ShowInputPanel(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_HideInputPanel")]
        public static extern void ImfManager_HideInputPanel(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_ActivatedSignal")]
        public static extern global::System.IntPtr ImfManager_ActivatedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_EventReceivedSignal")]
        public static extern global::System.IntPtr ImfManager_EventReceivedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_StatusChangedSignal")]
        public static extern global::System.IntPtr ImfManager_StatusChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_ResizedSignal")]
        public static extern global::System.IntPtr ImfManager_ResizedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_LanguageChangedSignal")]
        public static extern global::System.IntPtr ImfManager_LanguageChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_ImfManager__SWIG_0")]
        public static extern global::System.IntPtr new_ImfManager__SWIG_0();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_ImfManager")]
        public static extern void delete_ImfManager(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_ImfManager__SWIG_1")]
        public static extern global::System.IntPtr new_ImfManager__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ImfManager_SWIGUpcast")]
        public static extern global::System.IntPtr ImfManager_SWIGUpcast(global::System.IntPtr jarg1);

        /////////////////////////////////////////////////////////////
        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_TextEditor_Property_SMOOTH_SCROLL_get")]
        public static extern int TextEditor_Property_SMOOTH_SCROLL_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_TextEditor_Property_SMOOTH_SCROLL_DURATION_get")]
        public static extern int TextEditor_Property_SMOOTH_SCROLL_DURATION_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_TextEditor_Property_ENABLE_SCROLL_BAR_get")]
        public static extern int TextEditor_Property_ENABLE_SCROLL_BAR_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_TextEditor_Property_SCROLL_BAR_SHOW_DURATION_get")]
        public static extern int TextEditor_Property_SCROLL_BAR_SHOW_DURATION_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_TextEditor_Property_SCROLL_BAR_FADE_DURATION_get")]
        public static extern int TextEditor_Property_SCROLL_BAR_FADE_DURATION_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_TextEditor_Property_PIXEL_SIZE_get")]
        public static extern int TextEditor_Property_PIXEL_SIZE_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_TextEditor_Property_LINE_COUNT_get")]
        public static extern int TextEditor_Property_LINE_COUNT_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_TextEditor_Property_PLACEHOLDER_TEXT_get")]
        public static extern int TextEditor_Property_PLACEHOLDER_TEXT_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_TextEditor_Property_PLACEHOLDER_TEXT_COLOR_get")]
        public static extern int TextEditor_Property_PLACEHOLDER_TEXT_COLOR_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_TextField_Property_HIDDEN_INPUT_SETTINGS_get")]
        public static extern int TextField_Property_HIDDEN_INPUT_SETTINGS_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_TextField_Property_PIXEL_SIZE_get")]
        public static extern int TextField_Property_PIXEL_SIZE_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_TextLabel_Property_PIXEL_SIZE_get")]
        public static extern int TextLabel_Property_PIXEL_SIZE_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_TextLabel_Property_ELLIPSIS_get")]
        public static extern int TextLabel_Property_ELLIPSIS_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextLabel_Property_AUTO_SCROLL_STOP_MODE_get")]
        public static extern int TextLabel_Property_AUTO_SCROLL_STOP_MODE_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_TextLabel_Property_AUTO_SCROLL_LOOP_DELAY_get")]
        public static extern int TextLabel_Property_AUTO_SCROLL_LOOP_DELAY_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_HIDDENINPUT_PROPERTY_MODE_get")]
        public static extern int HIDDENINPUT_PROPERTY_MODE_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_HIDDENINPUT_PROPERTY_SUBSTITUTE_CHARACTER_get")]
        public static extern int HIDDENINPUT_PROPERTY_SUBSTITUTE_CHARACTER_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_HIDDENINPUT_PROPERTY_SUBSTITUTE_COUNT_get")]
        public static extern int HIDDENINPUT_PROPERTY_SUBSTITUTE_COUNT_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_HIDDENINPUT_PROPERTY_SHOW_DURATION_get")]
        public static extern int HIDDENINPUT_PROPERTY_SHOW_DURATION_get();
        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TtsPlayer_SWIGUpcast")]
        public static extern global::System.IntPtr TtsPlayer_SWIGUpcast(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TtsPlayer__SWIG_0")]
        public static extern global::System.IntPtr new_TtsPlayer__SWIG_0();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TtsPlayer_Get__SWIG_0")]
        public static extern global::System.IntPtr TtsPlayer_Get__SWIG_0(int jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TtsPlayer_Get__SWIG_1")]
        public static extern global::System.IntPtr TtsPlayer_Get__SWIG_1();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TtsPlayer")]
        public static extern void delete_TtsPlayer(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TtsPlayer__SWIG_1")]
        public static extern global::System.IntPtr new_TtsPlayer__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TtsPlayer_Assign")]
        public static extern global::System.IntPtr TtsPlayer_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TtsPlayer_Play")]
        public static extern void TtsPlayer_Play(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TtsPlayer_Stop")]
        public static extern void TtsPlayer_Stop(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TtsPlayer_Pause")]
        public static extern void TtsPlayer_Pause(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TtsPlayer_Resume")]
        public static extern void TtsPlayer_Resume(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TtsPlayer_GetState")]
        public static extern int TtsPlayer_GetState(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TtsPlayer_StateChangedSignal")]
        public static extern global::System.IntPtr TtsPlayer_StateChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StateChangedSignalType_Empty")]
        public static extern bool StateChangedSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StateChangedSignalType_GetConnectionCount")]
        public static extern uint StateChangedSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StateChangedSignalType_Connect")]
        public static extern void StateChangedSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StateChangedSignalType_Disconnect")]
        public static extern void StateChangedSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StateChangedSignalType_Emit")]
        public static extern void StateChangedSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_StateChangedSignalType")]
        public static extern global::System.IntPtr new_StateChangedSignalType();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_StateChangedSignalType")]
        public static extern void delete_StateChangedSignalType(global::System.Runtime.InteropServices.HandleRef jarg1);

        //manual pinvoke for text-editor ScrollStateChangedSignal
        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_ScrollStateChangedSignal")]
        public static extern global::System.IntPtr TextEditor_ScrollStateChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollStateChangedSignal_Empty")]
        public static extern bool ScrollStateChangedSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollStateChangedSignal_GetConnectionCount")]
        public static extern uint ScrollStateChangedSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollStateChangedSignal_Connect")]
        public static extern void ScrollStateChangedSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollStateChangedSignal_Disconnect")]
        public static extern void ScrollStateChangedSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollStateChangedSignal_Emit")]
        public static extern void ScrollStateChangedSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ScrollStateChangedSignal")]
        public static extern global::System.IntPtr new_ScrollStateChangedSignal();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ScrollStateChangedSignal")]
        public static extern void delete_ScrollStateChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

    }
}
