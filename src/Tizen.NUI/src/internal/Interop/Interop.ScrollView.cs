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

using global::System;
using global::System.Runtime.InteropServices;
using global::System.Runtime.InteropServices.Marshalling;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class ScrollView
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ScrollViewEffect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewScrollViewEffect();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ScrollViewEffect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteScrollViewEffect(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewPagePathEffect_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ScrollViewPagePathEffectNew(IntPtr jarg1, IntPtr jarg2, int jarg3, IntPtr jarg4, uint jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewPagePathEffect_ApplyToPage", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ScrollViewPagePathEffectApplyToPage(IntPtr jarg1, IntPtr jarg2, uint jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ScrollViewPagePathEffect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteScrollViewPagePathEffect(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SnapEvent_type_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SnapEventTypeSet(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SnapEvent_type_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SnapEventTypeGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SnapEvent_position_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SnapEventPositionSet(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SnapEvent_position_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr SnapEventPositionGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SnapEvent_duration_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SnapEventDurationSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SnapEvent_duration_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float SnapEventDurationGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ScrollView_SnapEvent", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewScrollViewSnapEvent();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ScrollView_SnapEvent", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteScrollViewSnapEvent(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_WRAP_ENABLED_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int WrapEnabledGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_PANNING_ENABLED_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PanningEnabledGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_AXIS_AUTO_LOCK_ENABLED_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AxisAutoLockEnabledGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_WHEEL_SCROLL_DISTANCE_STEP_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int WheelScrollDistanceStepGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_MODE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollModeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_POSITION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollPositionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_PRE_POSITION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollPrePositionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_PRE_POSITION_X_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollPrePositionXGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_PRE_POSITION_Y_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollPrePositionYGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_PRE_POSITION_MAX_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollPrePositionMaxGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_PRE_POSITION_MAX_X_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollPrePositionMaxXGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_PRE_POSITION_MAX_Y_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollPrePositionMaxYGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_OVERSHOOT_X_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int OvershootXGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_OVERSHOOT_Y_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int OvershootYGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_FINAL_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollFinalGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_FINAL_X_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollFinalXGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_FINAL_Y_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollFinalYGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_WRAP_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int WrapGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_PANNING_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PanningGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLLING_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollingGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_DOMAIN_SIZE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollDomainSizeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_DOMAIN_SIZE_X_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollDomainSizeXGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_DOMAIN_SIZE_Y_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollDomainSizeYGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_DOMAIN_OFFSET_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollDomainOffsetGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_POSITION_DELTA_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollPositionDeltaGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_START_PAGE_POSITION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int StartPagePositionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ScrollView", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteScrollView(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetScrollSnapAlphaFunction", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetScrollSnapAlphaFunction(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetScrollSnapAlphaFunction", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetScrollSnapAlphaFunction(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetScrollFlickAlphaFunction", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetScrollFlickAlphaFunction(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetScrollFlickAlphaFunction", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetScrollFlickAlphaFunction(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetScrollSnapDuration", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetScrollSnapDuration(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetScrollSnapDuration", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetScrollSnapDuration(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetScrollFlickDuration", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetScrollFlickDuration(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetScrollFlickDuration", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetScrollFlickDuration(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetRulerX", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetRulerX(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetRulerY", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetRulerY(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetScrollSensitive", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetScrollSensitive(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetMaxOvershoot", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetMaxOvershoot(IntPtr jarg1, float jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetSnapOvershootAlphaFunction", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetSnapOvershootAlphaFunction(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetSnapOvershootDuration", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetSnapOvershootDuration(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetActorAutoSnap", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetActorAutoSnap(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetWrapMode", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetWrapMode(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetScrollUpdateDistance", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetScrollUpdateDistance(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetScrollUpdateDistance", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetScrollUpdateDistance(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetAxisAutoLock", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetAxisAutoLock(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetAxisAutoLock", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetAxisAutoLock(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetAxisAutoLockGradient", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetAxisAutoLockGradient(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetAxisAutoLockGradient", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetAxisAutoLockGradient(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetFrictionCoefficient", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetFrictionCoefficient(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetFrictionCoefficient", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetFrictionCoefficient(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetFlickSpeedCoefficient", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetFlickSpeedCoefficient(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetFlickSpeedCoefficient", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetFlickSpeedCoefficient(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetMinimumDistanceForFlick", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetMinimumDistanceForFlick(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetMinimumDistanceForFlick", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetMinimumDistanceForFlick(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetMinimumSpeedForFlick", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetMinimumSpeedForFlick(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetMinimumSpeedForFlick", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetMinimumSpeedForFlick(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetMaxFlickSpeed", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetMaxFlickSpeed(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetMaxFlickSpeed", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetMaxFlickSpeed(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetCurrentScrollPosition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetCurrentScrollPosition(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetCurrentPage", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetCurrentPage(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ScrollToVector2(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ScrollTo(IntPtr jarg1, IntPtr jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ScrollTo(IntPtr jarg1, IntPtr jarg2, float jarg3, IntPtr jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ScrollTo(IntPtr jarg1, IntPtr jarg2, float jarg3, int jarg4, int jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ScrollTo(IntPtr jarg1, IntPtr jarg2, float jarg3, IntPtr jarg4, int jarg5, int jarg6);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_5", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ScrollTo(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_6", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ScrollTo(IntPtr jarg1, uint jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_7", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ScrollTo(IntPtr jarg1, uint jarg2, float jarg3, int jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_8", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ScrollToView(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_9", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ScrollToViewDuration(IntPtr jarg1, IntPtr jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollToSnapPoint", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool ScrollToSnapPoint(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ApplyConstraintToChildren", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ApplyConstraintToChildren(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ApplyEffect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ApplyEffect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_RemoveEffect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RemoveEffect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_RemoveAllEffects", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RemoveAllEffects(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_BindActor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void BindActor(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_UnbindActor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void UnbindActor(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetScrollingDirection__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetScrollingDirection(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetScrollingDirection__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetScrollingDirection(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_RemoveScrollingDirection", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RemoveScrollingDirection(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SnapStartedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr SnapStartedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewSnapStartedSignal_Empty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool ScrollViewSnapStartedSignalEmpty(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewSnapStartedSignal_GetConnectionCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint ScrollViewSnapStartedSignalGetConnectionCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewSnapStartedSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ScrollViewSnapStartedSignalConnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewSnapStartedSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ScrollViewSnapStartedSignalDisconnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewSnapStartedSignal_Emit", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ScrollViewSnapStartedSignalEmit(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ScrollViewSnapStartedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewScrollViewSnapStartedSignal();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ScrollViewSnapStartedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteScrollViewSnapStartedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewEffect_SWIGUpcast", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ScrollViewEffectUpcast(global::System.IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewPagePathEffect_SWIGUpcast", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ScrollViewPagePathEffectUpcast(global::System.IntPtr jarg1);
        }
    }
}





