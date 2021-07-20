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
        internal static partial class GestureOptions
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGesturePredictionMode")]
            public static extern void SetPanGesturePredictionMode(int jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGesturePredictionAmount")]
            public static extern void SetPanGesturePredictionAmount(uint jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureMaximumPredictionAmount")]
            public static extern void SetPanGestureMaximumPredictionAmount(uint jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureMinimumPredictionAmount")]
            public static extern void SetPanGestureMinimumPredictionAmount(uint jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGesturePredictionAmountAdjustment")]
            public static extern void SetPanGesturePredictionAmountAdjustment(uint jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureSmoothingMode")]
            public static extern void SetPanGestureSmoothingMode(int jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureSmoothingAmount")]
            public static extern void SetPanGestureSmoothingAmount(float jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureUseActualTimes")]
            public static extern void SetPanGestureUseActualTimes(bool jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureInterpolationTimeRange")]
            public static extern void SetPanGestureInterpolationTimeRange(int jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureScalarOnlyPredictionEnabled")]
            public static extern void SetPanGestureScalarOnlyPredictionEnabled(bool jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureTwoPointPredictionEnabled")]
            public static extern void SetPanGestureTwoPointPredictionEnabled(bool jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureTwoPointInterpolatePastTime")]
            public static extern void SetPanGestureTwoPointInterpolatePastTime(int jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureTwoPointVelocityBias")]
            public static extern void SetPanGestureTwoPointVelocityBias(float jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureTwoPointAccelerationBias")]
            public static extern void SetPanGestureTwoPointAccelerationBias(float jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureMultitapSmoothingRange")]
            public static extern void SetPanGestureMultitapSmoothingRange(int jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureMinimumDistance")]
            public static extern void SetPanGestureMinimumDistance(int jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureMinimumPanEvents")]
            public static extern void SetPanGestureMinimumPanEvents(int jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPinchGestureMinimumDistance")]
            public static extern void SetPinchGestureMinimumDistance(float jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPinchGestureMinimumTouchEvents")]
            public static extern void SetPinchGestureMinimumTouchEvents(uint jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPinchGestureMinimumTouchEventsAfterStart")]
            public static extern void SetPinchGestureMinimumTouchEventsAfterStart(uint jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetRotationGestureMinimumTouchEvents")]
            public static extern void SetRotationGestureMinimumTouchEvents(uint jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetRotationGestureMinimumTouchEventsAfterStart")]
            public static extern void SetRotationGestureMinimumTouchEventsAfterStart(uint jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetLongPressMinimumHoldingTime")]
            public static extern void SetLongPressMinimumHoldingTime(uint jarg1);
        }
    }
}
