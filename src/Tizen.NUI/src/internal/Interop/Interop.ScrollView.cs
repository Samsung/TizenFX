using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class ScrollView
        {

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ScrollViewEffect")]
            public static extern global::System.IntPtr new_ScrollViewEffect();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ScrollViewEffect")]
            public static extern void delete_ScrollViewEffect(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewPagePathEffect_New")]
            public static extern global::System.IntPtr ScrollViewPagePathEffect_New(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, uint jarg5);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ScrollViewPagePathEffect")]
            public static extern global::System.IntPtr new_ScrollViewPagePathEffect();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewPagePathEffect_DownCast")]
            public static extern global::System.IntPtr ScrollViewPagePathEffect_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewPagePathEffect_ApplyToPage")]
            public static extern void ScrollViewPagePathEffect_ApplyToPage(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ScrollViewPagePathEffect")]
            public static extern void delete_ScrollViewPagePathEffect(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ClampEvent_scale_set")]
            public static extern void ScrollView_ClampEvent_scale_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ClampEvent_scale_get")]
            public static extern global::System.IntPtr ScrollView_ClampEvent_scale_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ClampEvent_position_set")]
            public static extern void ScrollView_ClampEvent_position_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ClampEvent_position_get")]
            public static extern global::System.IntPtr ScrollView_ClampEvent_position_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ClampEvent_rotation_set")]
            public static extern void ScrollView_ClampEvent_rotation_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ClampEvent_rotation_get")]
            public static extern int ScrollView_ClampEvent_rotation_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ScrollView_ClampEvent")]
            public static extern global::System.IntPtr new_ScrollView_ClampEvent();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ScrollView_ClampEvent")]
            public static extern void delete_ScrollView_ClampEvent(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SnapEvent_type_set")]
            public static extern void ScrollView_SnapEvent_type_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SnapEvent_type_get")]
            public static extern int ScrollView_SnapEvent_type_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SnapEvent_position_set")]
            public static extern void ScrollView_SnapEvent_position_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SnapEvent_position_get")]
            public static extern global::System.IntPtr ScrollView_SnapEvent_position_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SnapEvent_duration_set")]
            public static extern void ScrollView_SnapEvent_duration_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SnapEvent_duration_get")]
            public static extern float ScrollView_SnapEvent_duration_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ScrollView_SnapEvent")]
            public static extern global::System.IntPtr new_ScrollView_SnapEvent();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ScrollView_SnapEvent")]
            public static extern void delete_ScrollView_SnapEvent(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_WRAP_ENABLED_get")]
            public static extern int ScrollView_Property_WRAP_ENABLED_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_PANNING_ENABLED_get")]
            public static extern int ScrollView_Property_PANNING_ENABLED_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_AXIS_AUTO_LOCK_ENABLED_get")]
            public static extern int ScrollView_Property_AXIS_AUTO_LOCK_ENABLED_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_WHEEL_SCROLL_DISTANCE_STEP_get")]
            public static extern int ScrollView_Property_WHEEL_SCROLL_DISTANCE_STEP_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_MODE_get")]
            public static extern int ScrollView_Property_SCROLL_MODE_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_POSITION_get")]
            public static extern int ScrollView_Property_SCROLL_POSITION_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_PRE_POSITION_get")]
            public static extern int ScrollView_Property_SCROLL_PRE_POSITION_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_PRE_POSITION_X_get")]
            public static extern int ScrollView_Property_SCROLL_PRE_POSITION_X_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_PRE_POSITION_Y_get")]
            public static extern int ScrollView_Property_SCROLL_PRE_POSITION_Y_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_PRE_POSITION_MAX_get")]
            public static extern int ScrollView_Property_SCROLL_PRE_POSITION_MAX_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_PRE_POSITION_MAX_X_get")]
            public static extern int ScrollView_Property_SCROLL_PRE_POSITION_MAX_X_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_PRE_POSITION_MAX_Y_get")]
            public static extern int ScrollView_Property_SCROLL_PRE_POSITION_MAX_Y_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_OVERSHOOT_X_get")]
            public static extern int ScrollView_Property_OVERSHOOT_X_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_OVERSHOOT_Y_get")]
            public static extern int ScrollView_Property_OVERSHOOT_Y_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_FINAL_get")]
            public static extern int ScrollView_Property_SCROLL_FINAL_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_FINAL_X_get")]
            public static extern int ScrollView_Property_SCROLL_FINAL_X_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_FINAL_Y_get")]
            public static extern int ScrollView_Property_SCROLL_FINAL_Y_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_WRAP_get")]
            public static extern int ScrollView_Property_WRAP_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_PANNING_get")]
            public static extern int ScrollView_Property_PANNING_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLLING_get")]
            public static extern int ScrollView_Property_SCROLLING_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_DOMAIN_SIZE_get")]
            public static extern int ScrollView_Property_SCROLL_DOMAIN_SIZE_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_DOMAIN_SIZE_X_get")]
            public static extern int ScrollView_Property_SCROLL_DOMAIN_SIZE_X_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_DOMAIN_SIZE_Y_get")]
            public static extern int ScrollView_Property_SCROLL_DOMAIN_SIZE_Y_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_DOMAIN_OFFSET_get")]
            public static extern int ScrollView_Property_SCROLL_DOMAIN_OFFSET_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_SCROLL_POSITION_DELTA_get")]
            public static extern int ScrollView_Property_SCROLL_POSITION_DELTA_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Property_START_PAGE_POSITION_get")]
            public static extern int ScrollView_Property_START_PAGE_POSITION_get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ScrollView_Property")]
            public static extern global::System.IntPtr new_ScrollView_Property();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ScrollView_Property")]
            public static extern void delete_ScrollView_Property(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ScrollView__SWIG_0")]
            public static extern global::System.IntPtr new_ScrollView__SWIG_0();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ScrollView__SWIG_1")]
            public static extern global::System.IntPtr new_ScrollView__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_Assign")]
            public static extern global::System.IntPtr ScrollView_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ScrollView")]
            public static extern void delete_ScrollView(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_New")]
            public static extern global::System.IntPtr ScrollView_New();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_DownCast")]
            public static extern global::System.IntPtr ScrollView_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetScrollSnapAlphaFunction")]
            public static extern global::System.IntPtr ScrollView_GetScrollSnapAlphaFunction(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetScrollSnapAlphaFunction")]
            public static extern void ScrollView_SetScrollSnapAlphaFunction(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetScrollFlickAlphaFunction")]
            public static extern global::System.IntPtr ScrollView_GetScrollFlickAlphaFunction(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetScrollFlickAlphaFunction")]
            public static extern void ScrollView_SetScrollFlickAlphaFunction(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetScrollSnapDuration")]
            public static extern float ScrollView_GetScrollSnapDuration(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetScrollSnapDuration")]
            public static extern void ScrollView_SetScrollSnapDuration(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetScrollFlickDuration")]
            public static extern float ScrollView_GetScrollFlickDuration(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetScrollFlickDuration")]
            public static extern void ScrollView_SetScrollFlickDuration(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetRulerX")]
            public static extern void ScrollView_SetRulerX(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetRulerY")]
            public static extern void ScrollView_SetRulerY(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetScrollSensitive")]
            public static extern void ScrollView_SetScrollSensitive(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetMaxOvershoot")]
            public static extern void ScrollView_SetMaxOvershoot(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetSnapOvershootAlphaFunction")]
            public static extern void ScrollView_SetSnapOvershootAlphaFunction(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetSnapOvershootDuration")]
            public static extern void ScrollView_SetSnapOvershootDuration(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetActorAutoSnap")]
            public static extern void ScrollView_SetActorAutoSnap(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetWrapMode")]
            public static extern void ScrollView_SetWrapMode(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetScrollUpdateDistance")]
            public static extern int ScrollView_GetScrollUpdateDistance(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetScrollUpdateDistance")]
            public static extern void ScrollView_SetScrollUpdateDistance(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetAxisAutoLock")]
            public static extern bool ScrollView_GetAxisAutoLock(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetAxisAutoLock")]
            public static extern void ScrollView_SetAxisAutoLock(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetAxisAutoLockGradient")]
            public static extern float ScrollView_GetAxisAutoLockGradient(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetAxisAutoLockGradient")]
            public static extern void ScrollView_SetAxisAutoLockGradient(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetFrictionCoefficient")]
            public static extern float ScrollView_GetFrictionCoefficient(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetFrictionCoefficient")]
            public static extern void ScrollView_SetFrictionCoefficient(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetFlickSpeedCoefficient")]
            public static extern float ScrollView_GetFlickSpeedCoefficient(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetFlickSpeedCoefficient")]
            public static extern void ScrollView_SetFlickSpeedCoefficient(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetMinimumDistanceForFlick")]
            public static extern global::System.IntPtr ScrollView_GetMinimumDistanceForFlick(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetMinimumDistanceForFlick")]
            public static extern void ScrollView_SetMinimumDistanceForFlick(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetMinimumSpeedForFlick")]
            public static extern float ScrollView_GetMinimumSpeedForFlick(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetMinimumSpeedForFlick")]
            public static extern void ScrollView_SetMinimumSpeedForFlick(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetMaxFlickSpeed")]
            public static extern float ScrollView_GetMaxFlickSpeed(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetMaxFlickSpeed")]
            public static extern void ScrollView_SetMaxFlickSpeed(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetWheelScrollDistanceStep")]
            public static extern global::System.IntPtr ScrollView_GetWheelScrollDistanceStep(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetWheelScrollDistanceStep")]
            public static extern void ScrollView_SetWheelScrollDistanceStep(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetCurrentScrollPosition")]
            public static extern global::System.IntPtr ScrollView_GetCurrentScrollPosition(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_GetCurrentPage")]
            public static extern uint ScrollView_GetCurrentPage(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_0")]
            public static extern void ScrollView_ScrollTo__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_1")]
            public static extern void ScrollView_ScrollTo__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_2")]
            public static extern void ScrollView_ScrollTo__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_3")]
            public static extern void ScrollView_ScrollTo__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3, int jarg4, int jarg5);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_4")]
            public static extern void ScrollView_ScrollTo__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, int jarg5, int jarg6);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_5")]
            public static extern void ScrollView_ScrollTo__SWIG_5(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_6")]
            public static extern void ScrollView_ScrollTo__SWIG_6(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, float jarg3);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_7")]
            public static extern void ScrollView_ScrollTo__SWIG_7(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, float jarg3, int jarg4);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_8")]
            public static extern void ScrollView_ScrollTo__SWIG_8(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollTo__SWIG_9")]
            public static extern void ScrollView_ScrollTo__SWIG_9(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ScrollToSnapPoint")]
            public static extern bool ScrollView_ScrollToSnapPoint(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ApplyConstraintToChildren")]
            public static extern void ScrollView_ApplyConstraintToChildren(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_RemoveConstraintsFromChildren")]
            public static extern void ScrollView_RemoveConstraintsFromChildren(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_ApplyEffect")]
            public static extern void ScrollView_ApplyEffect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_RemoveEffect")]
            public static extern void ScrollView_RemoveEffect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_RemoveAllEffects")]
            public static extern void ScrollView_RemoveAllEffects(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_BindActor")]
            public static extern void ScrollView_BindActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_UnbindActor")]
            public static extern void ScrollView_UnbindActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetScrollingDirection__SWIG_0")]
            public static extern void ScrollView_SetScrollingDirection__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SetScrollingDirection__SWIG_1")]
            public static extern void ScrollView_SetScrollingDirection__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_RemoveScrollingDirection")]
            public static extern void ScrollView_RemoveScrollingDirection(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SnapStartedSignal")]
            public static extern global::System.IntPtr ScrollView_SnapStartedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewSnapStartedSignal_Empty")]
            public static extern bool ScrollViewSnapStartedSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewSnapStartedSignal_GetConnectionCount")]
            public static extern uint ScrollViewSnapStartedSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewSnapStartedSignal_Connect")]
            public static extern void ScrollViewSnapStartedSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewSnapStartedSignal_Disconnect")]
            public static extern void ScrollViewSnapStartedSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewSnapStartedSignal_Emit")]
            public static extern void ScrollViewSnapStartedSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ScrollViewSnapStartedSignal")]
            public static extern global::System.IntPtr new_ScrollViewSnapStartedSignal();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ScrollViewSnapStartedSignal")]
            public static extern void delete_ScrollViewSnapStartedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewEffect_SWIGUpcast")]
            public static extern global::System.IntPtr ScrollViewEffect_SWIGUpcast(global::System.IntPtr jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollViewPagePathEffect_SWIGUpcast")]
            public static extern global::System.IntPtr ScrollViewPagePathEffect_SWIGUpcast(global::System.IntPtr jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollView_SWIGUpcast")]
            public static extern global::System.IntPtr ScrollView_SWIGUpcast(global::System.IntPtr jarg1);
        }
    }
}
