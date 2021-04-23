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
        internal static partial class ScrollView
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ScrollViewEffect")]
            public static extern global::System.IntPtr NewScrollViewEffect();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ScrollViewEffect")]
            public static extern void DeleteScrollViewEffect(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewPagePathEffect_New")]
            public static extern global::System.IntPtr ScrollViewPagePathEffectNew(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, uint jarg5);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ScrollViewPagePathEffect")]
            public static extern global::System.IntPtr NewScrollViewPagePathEffect();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewPagePathEffect_DownCast")]
            public static extern global::System.IntPtr ScrollViewPagePathEffectDownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewPagePathEffect_ApplyToPage")]
            public static extern void ScrollViewPagePathEffectApplyToPage(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ScrollViewPagePathEffect")]
            public static extern void DeleteScrollViewPagePathEffect(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ClampEvent_scale_set")]
            public static extern void ClampEventScaleSet(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ClampEvent_scale_get")]
            public static extern global::System.IntPtr ClampEventScaleGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ClampEvent_position_set")]
            public static extern void ClampEventPositionSet(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ClampEvent_position_get")]
            public static extern global::System.IntPtr ClampEventPositionGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ClampEvent_rotation_set")]
            public static extern void ClampEventRotationSet(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ClampEvent_rotation_get")]
            public static extern int ClampEventRotationGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ScrollView_ClampEvent")]
            public static extern global::System.IntPtr NewScrollViewClampEvent();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ScrollView_ClampEvent")]
            public static extern void DeleteScrollViewClampEvent(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SnapEvent_type_set")]
            public static extern void SnapEventTypeSet(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SnapEvent_type_get")]
            public static extern int SnapEventTypeGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SnapEvent_position_set")]
            public static extern void SnapEventPositionSet(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SnapEvent_position_get")]
            public static extern global::System.IntPtr SnapEventPositionGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SnapEvent_duration_set")]
            public static extern void SnapEventDurationSet(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SnapEvent_duration_get")]
            public static extern float SnapEventDurationGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ScrollView_SnapEvent")]
            public static extern global::System.IntPtr NewScrollViewSnapEvent();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ScrollView_SnapEvent")]
            public static extern void DeleteScrollViewSnapEvent(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_WRAP_ENABLED_get")]
            public static extern int WrapEnabledGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_PANNING_ENABLED_get")]
            public static extern int PanningEnabledGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_AXIS_AUTO_LOCK_ENABLED_get")]
            public static extern int AxisAutoLockEnabledGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_WHEEL_SCROLL_DISTANCE_STEP_get")]
            public static extern int WheelScrollDistanceStepGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_MODE_get")]
            public static extern int ScrollModeGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_POSITION_get")]
            public static extern int ScrollPositionGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_PRE_POSITION_get")]
            public static extern int ScrollPrePositionGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_PRE_POSITION_X_get")]
            public static extern int ScrollPrePositionXGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_PRE_POSITION_Y_get")]
            public static extern int ScrollPrePositionYGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_PRE_POSITION_MAX_get")]
            public static extern int ScrollPrePositionMaxGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_PRE_POSITION_MAX_X_get")]
            public static extern int ScrollPrePositionMaxXGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_PRE_POSITION_MAX_Y_get")]
            public static extern int ScrollPrePositionMaxYGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_OVERSHOOT_X_get")]
            public static extern int OvershootXGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_OVERSHOOT_Y_get")]
            public static extern int OvershootYGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_FINAL_get")]
            public static extern int ScrollFinalGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_FINAL_X_get")]
            public static extern int ScrollFinalXGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_FINAL_Y_get")]
            public static extern int ScrollFinalYGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_WRAP_get")]
            public static extern int WrapGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_PANNING_get")]
            public static extern int PanningGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLLING_get")]
            public static extern int ScrollingGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_DOMAIN_SIZE_get")]
            public static extern int ScrollDomainSizeGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_DOMAIN_SIZE_X_get")]
            public static extern int ScrollDomainSizeXGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_DOMAIN_SIZE_Y_get")]
            public static extern int ScrollDomainSizeYGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_DOMAIN_OFFSET_get")]
            public static extern int ScrollDomainOffsetGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_POSITION_DELTA_get")]
            public static extern int ScrollPositionDeltaGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_START_PAGE_POSITION_get")]
            public static extern int StartPagePositionGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ScrollView_Property")]
            public static extern global::System.IntPtr NewScrollViewProperty();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ScrollView_Property")]
            public static extern void DeleteScrollViewProperty(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ScrollView__SWIG_0")]
            public static extern global::System.IntPtr NewScrollView();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ScrollView__SWIG_1")]
            public static extern global::System.IntPtr NewScrollView(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Assign")]
            public static extern global::System.IntPtr Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ScrollView")]
            public static extern void DeleteScrollView(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_New")]
            public static extern global::System.IntPtr New();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_DownCast")]
            public static extern global::System.IntPtr DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetScrollSnapAlphaFunction")]
            public static extern global::System.IntPtr GetScrollSnapAlphaFunction(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetScrollSnapAlphaFunction")]
            public static extern void SetScrollSnapAlphaFunction(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetScrollFlickAlphaFunction")]
            public static extern global::System.IntPtr GetScrollFlickAlphaFunction(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetScrollFlickAlphaFunction")]
            public static extern void SetScrollFlickAlphaFunction(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetScrollSnapDuration")]
            public static extern float GetScrollSnapDuration(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetScrollSnapDuration")]
            public static extern void SetScrollSnapDuration(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetScrollFlickDuration")]
            public static extern float GetScrollFlickDuration(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetScrollFlickDuration")]
            public static extern void SetScrollFlickDuration(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetRulerX")]
            public static extern void SetRulerX(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetRulerY")]
            public static extern void SetRulerY(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetScrollSensitive")]
            public static extern void SetScrollSensitive(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetMaxOvershoot")]
            public static extern void SetMaxOvershoot(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetSnapOvershootAlphaFunction")]
            public static extern void SetSnapOvershootAlphaFunction(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetSnapOvershootDuration")]
            public static extern void SetSnapOvershootDuration(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetActorAutoSnap")]
            public static extern void SetActorAutoSnap(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetWrapMode")]
            public static extern void SetWrapMode(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetScrollUpdateDistance")]
            public static extern int GetScrollUpdateDistance(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetScrollUpdateDistance")]
            public static extern void SetScrollUpdateDistance(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetAxisAutoLock")]
            public static extern bool GetAxisAutoLock(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetAxisAutoLock")]
            public static extern void SetAxisAutoLock(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetAxisAutoLockGradient")]
            public static extern float GetAxisAutoLockGradient(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetAxisAutoLockGradient")]
            public static extern void SetAxisAutoLockGradient(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetFrictionCoefficient")]
            public static extern float GetFrictionCoefficient(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetFrictionCoefficient")]
            public static extern void SetFrictionCoefficient(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetFlickSpeedCoefficient")]
            public static extern float GetFlickSpeedCoefficient(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetFlickSpeedCoefficient")]
            public static extern void SetFlickSpeedCoefficient(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetMinimumDistanceForFlick")]
            public static extern global::System.IntPtr GetMinimumDistanceForFlick(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetMinimumDistanceForFlick")]
            public static extern void SetMinimumDistanceForFlick(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetMinimumSpeedForFlick")]
            public static extern float GetMinimumSpeedForFlick(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetMinimumSpeedForFlick")]
            public static extern void SetMinimumSpeedForFlick(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetMaxFlickSpeed")]
            public static extern float GetMaxFlickSpeed(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetMaxFlickSpeed")]
            public static extern void SetMaxFlickSpeed(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetCurrentScrollPosition")]
            public static extern global::System.IntPtr GetCurrentScrollPosition(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetCurrentPage")]
            public static extern uint GetCurrentPage(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_0")]
            public static extern void ScrollToVector2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_1")]
            public static extern void ScrollTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_2")]
            public static extern void ScrollTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_3")]
            public static extern void ScrollTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3, int jarg4, int jarg5);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_4")]
            public static extern void ScrollTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, int jarg5, int jarg6);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_5")]
            public static extern void ScrollTo(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_6")]
            public static extern void ScrollTo(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_7")]
            public static extern void ScrollTo(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, float jarg3, int jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_8")]
            public static extern void ScrollToView(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_9")]
            public static extern void ScrollToViewDuration(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollToSnapPoint")]
            public static extern bool ScrollToSnapPoint(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ApplyConstraintToChildren")]
            public static extern void ApplyConstraintToChildren(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_RemoveConstraintsFromChildren")]
            public static extern void RemoveConstraintsFromChildren(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ApplyEffect")]
            public static extern void ApplyEffect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_RemoveEffect")]
            public static extern void RemoveEffect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_RemoveAllEffects")]
            public static extern void RemoveAllEffects(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_BindActor")]
            public static extern void BindActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_UnbindActor")]
            public static extern void UnbindActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetScrollingDirection__SWIG_0")]
            public static extern void SetScrollingDirection(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetScrollingDirection__SWIG_1")]
            public static extern void SetScrollingDirection(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_RemoveScrollingDirection")]
            public static extern void RemoveScrollingDirection(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SnapStartedSignal")]
            public static extern global::System.IntPtr SnapStartedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewSnapStartedSignal_Empty")]
            public static extern bool ScrollViewSnapStartedSignalEmpty(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewSnapStartedSignal_GetConnectionCount")]
            public static extern uint ScrollViewSnapStartedSignalGetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewSnapStartedSignal_Connect")]
            public static extern void ScrollViewSnapStartedSignalConnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewSnapStartedSignal_Disconnect")]
            public static extern void ScrollViewSnapStartedSignalDisconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewSnapStartedSignal_Emit")]
            public static extern void ScrollViewSnapStartedSignalEmit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ScrollViewSnapStartedSignal")]
            public static extern global::System.IntPtr NewScrollViewSnapStartedSignal();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ScrollViewSnapStartedSignal")]
            public static extern void DeleteScrollViewSnapStartedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewEffect_SWIGUpcast")]
            public static extern global::System.IntPtr ScrollViewEffectUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewPagePathEffect_SWIGUpcast")]
            public static extern global::System.IntPtr ScrollViewPagePathEffectUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SWIGUpcast")]
            public static extern global::System.IntPtr Upcast(global::System.IntPtr jarg1);
        }
    }
}
