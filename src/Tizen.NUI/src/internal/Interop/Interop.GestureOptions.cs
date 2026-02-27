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
        internal static partial class GestureOptions
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGesturePredictionMode", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPanGesturePredictionMode(int mode);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGesturePredictionAmount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPanGesturePredictionAmount(uint amount);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureMaximumPredictionAmount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPanGestureMaximumPredictionAmount(uint amount);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureMinimumPredictionAmount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPanGestureMinimumPredictionAmount(uint amount);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGesturePredictionAmountAdjustment", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPanGesturePredictionAmountAdjustment(uint amount);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureSmoothingMode", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPanGestureSmoothingMode(int mode);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureSmoothingAmount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPanGestureSmoothingAmount(float jaamountrg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureUseActualTimes", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPanGestureUseActualTimes([MarshalAs(UnmanagedType.U1)] bool enable);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureInterpolationTimeRange", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPanGestureInterpolationTimeRange(int range);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureScalarOnlyPredictionEnabled", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPanGestureScalarOnlyPredictionEnabled([MarshalAs(UnmanagedType.U1)] bool enable);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureTwoPointPredictionEnabled", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPanGestureTwoPointPredictionEnabled([MarshalAs(UnmanagedType.U1)] bool enable);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureTwoPointInterpolatePastTime", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPanGestureTwoPointInterpolatePastTime(int time);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureTwoPointVelocityBias", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPanGestureTwoPointVelocityBias(float velocity);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureTwoPointAccelerationBias", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPanGestureTwoPointAccelerationBias(float acceleration);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureMultitapSmoothingRange", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPanGestureMultitapSmoothingRange(int range);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureMinimumDistance", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPanGestureMinimumDistance(int distance);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPanGestureMinimumPanEvents", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPanGestureMinimumPanEvents(int number);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPinchGestureMinimumDistance", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPinchGestureMinimumDistance(float distance);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPinchGestureMinimumTouchEvents", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPinchGestureMinimumTouchEvents(uint number);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetPinchGestureMinimumTouchEventsAfterStart", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPinchGestureMinimumTouchEventsAfterStart(uint number);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetRotationGestureMinimumTouchEvents", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetRotationGestureMinimumTouchEvents(uint number);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetRotationGestureMinimumTouchEventsAfterStart", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetRotationGestureMinimumTouchEventsAfterStart(uint number);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetLongPressMinimumHoldingTime", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetLongPressMinimumHoldingTime(uint time);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetTapMaximumAllowedTime", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetDoubleTapTimeout(uint ms);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetTapRecognizerTime", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetTapRecognizerTime(uint ms);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureOptions_SetTapMaximumMotionAllowedDistance", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetTapMaximumMotionAllowedDistance(float distance);
        }
    }
}





