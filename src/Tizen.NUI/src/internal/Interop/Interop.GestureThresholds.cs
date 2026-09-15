/*
 * Copyright(c) 2026 Samsung Electronics Co., Ltd.
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
        internal static partial class GestureThresholds
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_GestureThresholds_PanThresholds")]
            public static extern global::System.IntPtr NewPanThresholds();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_GestureThresholds_PanThresholds")]
            public static extern void DeletePanThresholds(global::System.Runtime.InteropServices.HandleRef nuiThresholds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_PanThresholds_SetMinimumDistance")]
            public static extern void PanThresholdsSetMinimumDistance(global::System.Runtime.InteropServices.HandleRef nuiThresholds, int value);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_PanThresholds_GetMinimumDistance")]
            public static extern int PanThresholdsGetMinimumDistance(global::System.Runtime.InteropServices.HandleRef nuiThresholds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_PanThresholds_SetMinimumPanEvents")]
            public static extern void PanThresholdsSetMinimumPanEvents(global::System.Runtime.InteropServices.HandleRef nuiThresholds, int value);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_PanThresholds_GetMinimumPanEvents")]
            public static extern int PanThresholdsGetMinimumPanEvents(global::System.Runtime.InteropServices.HandleRef nuiThresholds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_GetDefaultPanThresholds")]
            public static extern global::System.IntPtr GetDefaultPanThresholds();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_SetPanThresholds")]
            public static extern void SetPanThresholds(global::System.Runtime.InteropServices.HandleRef nuiSelector, global::System.Runtime.InteropServices.HandleRef nuiThresholds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_GetPanThresholds")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool GetPanThresholds(global::System.Runtime.InteropServices.HandleRef nuiSelector, global::System.Runtime.InteropServices.HandleRef nuiThresholds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_ClearPanThresholds")]
            public static extern void ClearPanThresholds(global::System.Runtime.InteropServices.HandleRef nuiSelector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_GestureThresholds_TapThresholds")]
            public static extern global::System.IntPtr NewTapThresholds();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_GestureThresholds_TapThresholds")]
            public static extern void DeleteTapThresholds(global::System.Runtime.InteropServices.HandleRef nuiThresholds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_TapThresholds_SetMaximumMultiTapInterval")]
            public static extern void TapThresholdsSetMaximumMultiTapInterval(global::System.Runtime.InteropServices.HandleRef nuiThresholds, uint value);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_TapThresholds_GetMaximumMultiTapInterval")]
            public static extern uint TapThresholdsGetMaximumMultiTapInterval(global::System.Runtime.InteropServices.HandleRef nuiThresholds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_TapThresholds_SetMaximumHoldingTime")]
            public static extern void TapThresholdsSetMaximumHoldingTime(global::System.Runtime.InteropServices.HandleRef nuiThresholds, uint value);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_TapThresholds_GetMaximumHoldingTime")]
            public static extern uint TapThresholdsGetMaximumHoldingTime(global::System.Runtime.InteropServices.HandleRef nuiThresholds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_TapThresholds_SetMaximumMotionDistance")]
            public static extern void TapThresholdsSetMaximumMotionDistance(global::System.Runtime.InteropServices.HandleRef nuiThresholds, float value);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_TapThresholds_GetMaximumMotionDistance")]
            public static extern float TapThresholdsGetMaximumMotionDistance(global::System.Runtime.InteropServices.HandleRef nuiThresholds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_GetDefaultTapThresholds")]
            public static extern global::System.IntPtr GetDefaultTapThresholds();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_SetTapThresholds")]
            public static extern void SetTapThresholds(global::System.Runtime.InteropServices.HandleRef nuiSelector, global::System.Runtime.InteropServices.HandleRef nuiThresholds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_GetTapThresholds")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool GetTapThresholds(global::System.Runtime.InteropServices.HandleRef nuiSelector, global::System.Runtime.InteropServices.HandleRef nuiThresholds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_ClearTapThresholds")]
            public static extern void ClearTapThresholds(global::System.Runtime.InteropServices.HandleRef nuiSelector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_GestureThresholds_LongPressThresholds")]
            public static extern global::System.IntPtr NewLongPressThresholds();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_GestureThresholds_LongPressThresholds")]
            public static extern void DeleteLongPressThresholds(global::System.Runtime.InteropServices.HandleRef nuiThresholds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_LongPressThresholds_SetMinimumHoldingTime")]
            public static extern void LongPressThresholdsSetMinimumHoldingTime(global::System.Runtime.InteropServices.HandleRef nuiThresholds, uint value);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_LongPressThresholds_GetMinimumHoldingTime")]
            public static extern uint LongPressThresholdsGetMinimumHoldingTime(global::System.Runtime.InteropServices.HandleRef nuiThresholds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_GetDefaultLongPressThresholds")]
            public static extern global::System.IntPtr GetDefaultLongPressThresholds();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_SetLongPressThresholds")]
            public static extern void SetLongPressThresholds(global::System.Runtime.InteropServices.HandleRef nuiSelector, global::System.Runtime.InteropServices.HandleRef nuiThresholds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_GetLongPressThresholds")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool GetLongPressThresholds(global::System.Runtime.InteropServices.HandleRef nuiSelector, global::System.Runtime.InteropServices.HandleRef nuiThresholds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_ClearLongPressThresholds")]
            public static extern void ClearLongPressThresholds(global::System.Runtime.InteropServices.HandleRef nuiSelector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_GestureThresholds_PinchThresholds")]
            public static extern global::System.IntPtr NewPinchThresholds();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_GestureThresholds_PinchThresholds")]
            public static extern void DeletePinchThresholds(global::System.Runtime.InteropServices.HandleRef nuiThresholds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_PinchThresholds_SetMinimumDistance")]
            public static extern void PinchThresholdsSetMinimumDistance(global::System.Runtime.InteropServices.HandleRef nuiThresholds, float value);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_PinchThresholds_GetMinimumDistance")]
            public static extern float PinchThresholdsGetMinimumDistance(global::System.Runtime.InteropServices.HandleRef nuiThresholds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_PinchThresholds_SetMinimumTouchEvents")]
            public static extern void PinchThresholdsSetMinimumTouchEvents(global::System.Runtime.InteropServices.HandleRef nuiThresholds, uint value);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_PinchThresholds_GetMinimumTouchEvents")]
            public static extern uint PinchThresholdsGetMinimumTouchEvents(global::System.Runtime.InteropServices.HandleRef nuiThresholds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_PinchThresholds_SetMinimumTouchEventsAfterStart")]
            public static extern void PinchThresholdsSetMinimumTouchEventsAfterStart(global::System.Runtime.InteropServices.HandleRef nuiThresholds, uint value);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_PinchThresholds_GetMinimumTouchEventsAfterStart")]
            public static extern uint PinchThresholdsGetMinimumTouchEventsAfterStart(global::System.Runtime.InteropServices.HandleRef nuiThresholds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_GetDefaultPinchThresholds")]
            public static extern global::System.IntPtr GetDefaultPinchThresholds();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_SetPinchThresholds")]
            public static extern void SetPinchThresholds(global::System.Runtime.InteropServices.HandleRef nuiSelector, global::System.Runtime.InteropServices.HandleRef nuiThresholds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_GetPinchThresholds")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool GetPinchThresholds(global::System.Runtime.InteropServices.HandleRef nuiSelector, global::System.Runtime.InteropServices.HandleRef nuiThresholds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_ClearPinchThresholds")]
            public static extern void ClearPinchThresholds(global::System.Runtime.InteropServices.HandleRef nuiSelector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_GestureThresholds_RotationThresholds")]
            public static extern global::System.IntPtr NewRotationThresholds();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_GestureThresholds_RotationThresholds")]
            public static extern void DeleteRotationThresholds(global::System.Runtime.InteropServices.HandleRef nuiThresholds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_RotationThresholds_SetMinimumTouchEvents")]
            public static extern void RotationThresholdsSetMinimumTouchEvents(global::System.Runtime.InteropServices.HandleRef nuiThresholds, uint value);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_RotationThresholds_GetMinimumTouchEvents")]
            public static extern uint RotationThresholdsGetMinimumTouchEvents(global::System.Runtime.InteropServices.HandleRef nuiThresholds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_RotationThresholds_SetMinimumTouchEventsAfterStart")]
            public static extern void RotationThresholdsSetMinimumTouchEventsAfterStart(global::System.Runtime.InteropServices.HandleRef nuiThresholds, uint value);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_RotationThresholds_GetMinimumTouchEventsAfterStart")]
            public static extern uint RotationThresholdsGetMinimumTouchEventsAfterStart(global::System.Runtime.InteropServices.HandleRef nuiThresholds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_GetDefaultRotationThresholds")]
            public static extern global::System.IntPtr GetDefaultRotationThresholds();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_SetRotationThresholds")]
            public static extern void SetRotationThresholds(global::System.Runtime.InteropServices.HandleRef nuiSelector, global::System.Runtime.InteropServices.HandleRef nuiThresholds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_GetRotationThresholds")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool GetRotationThresholds(global::System.Runtime.InteropServices.HandleRef nuiSelector, global::System.Runtime.InteropServices.HandleRef nuiThresholds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureThresholds_ClearRotationThresholds")]
            public static extern void ClearRotationThresholds(global::System.Runtime.InteropServices.HandleRef nuiSelector);
        }
    }
}
