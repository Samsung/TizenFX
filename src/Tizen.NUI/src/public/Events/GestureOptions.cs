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
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// This is a calss that sets the configuration options of Gestures
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class GestureOptions
    {
        private static readonly GestureOptions instance = new GestureOptions();

        /// <summary>
        /// Constructor.
        /// </summary>
        private GestureOptions()
        {
        }

        /// <summary>
        /// Gets the singleton of the GestureOptions object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static GestureOptions Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Sets the prediction mode for pan gestures <br />
        ///    * 0 - No prediction <br />
        ///    * 1 - Prediction using average acceleration <br />
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="mode">The prediction mode</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGesturePredictionMode(int mode)
        {
            Interop.GestureOptions.SetPanGesturePredictionMode(mode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the prediction amount of the pan gesture
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="amount">The prediction amount in milliseconds</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGesturePredictionAmount(uint amount)
        {
            Interop.GestureOptions.SetPanGesturePredictionAmount(amount);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the upper bound of the prediction amount for clamping
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="amount">The prediction amount in milliseconds</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGestureMaximumPredictionAmount(uint amount)
        {
            Interop.GestureOptions.SetPanGestureMaximumPredictionAmount(amount);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        ///  Sets the lower bound of the prediction amount for clamping
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="amount">The prediction amount in milliseconds</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGestureMinimumPredictionAmount(uint amount)
        {
            Interop.GestureOptions.SetPanGestureMinimumPredictionAmount(amount);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the amount of prediction interpolation to adjust when the pan velocity is changed
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="amount">The prediction amount in milliseconds</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGesturePredictionAmountAdjustment(uint amount)
        {
            Interop.GestureOptions.SetPanGesturePredictionAmountAdjustment(amount);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Called to set the prediction mode for pan gestures <br />
        ///    * Valid modes: <br />
        ///    * 0 - No smoothing <br />
        ///    * 1 - average between last 2 values <br />
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="mode">The prediction mode</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGestureSmoothingMode(int mode)
        {
            Interop.GestureOptions.SetPanGestureSmoothingMode(mode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the smoothing amount of the pan gesture
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="amount">The smotthing amount from 0.0f (none) to 1.0f (full)</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGestureSmoothingAmount(float amount)
        {
            Interop.GestureOptions.SetPanGestureSmoothingAmount(amount);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets whether to use actual times of the real gesture and frames or not.
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="enable">True = use actual times, False = use perfect values</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGestureUseActualTimes(bool enable)
        {
            Interop.GestureOptions.SetPanGestureUseActualTimes(enable);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the interpolation time range (ms) of past points to use (with weights) when interpolating.
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="range">Time range in ms</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGestureInterpolationTimeRange(int range)
        {
            Interop.GestureOptions.SetPanGestureInterpolationTimeRange(range);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets whether to use scalar only prediction, which when enabled, ignores acceleration.
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="enable">True = use scalar prediction only</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGestureScalarOnlyPredictionEnabled(bool enable)
        {
            Interop.GestureOptions.SetPanGestureScalarOnlyPredictionEnabled(enable);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets whether to use two point prediction. This combines two interpolated points to get more steady acceleration and velocity values.
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="enable">True = use two point prediction</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGestureTwoPointPredictionEnabled(bool enable)
        {
            Interop.GestureOptions.SetPanGestureTwoPointPredictionEnabled(enable);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the time in the past to interpolate the second point when using two point interpolation.
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="time">Time in past in ms</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGestureTwoPointInterpolatePastTime(int time)
        {
            Interop.GestureOptions.SetPanGestureTwoPointInterpolatePastTime(time);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the two point velocity bias. This is the ratio of first and second points to use for velocity.
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="velocity">0.0f = 100% first point. 1.0f = 100% of second point.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGestureTwoPointVelocityBias(float velocity)
        {
            Interop.GestureOptions.SetPanGestureTwoPointVelocityBias(velocity);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the two point acceleration bias. This is the ratio of first and second points to use for acceleration.
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="acceleration">0.0f = 100% first point. 1.0f = 100% of second point.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGestureTwoPointAccelerationBias(float acceleration)
        {
            Interop.GestureOptions.SetPanGestureTwoPointAccelerationBias(acceleration);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the range of time (ms) of points in the history to perform multitap smoothing with (if enabled).
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="range">Time in past in ms</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGestureMultitapSmoothingRange(int range)
        {
            Interop.GestureOptions.SetPanGestureMultitapSmoothingRange(range);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the minimum distance required to start a pan event
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="distance">Distance in pixels</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGestureMinimumDistance(int distance)
        {
            Interop.GestureOptions.SetPanGestureMinimumDistance(distance);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the minimum number of touch events required to start a pan
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="number">Number of touch events</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGestureMinimumPanEvents(int number)
        {
            Interop.GestureOptions.SetPanGestureMinimumPanEvents(number);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the minimum distance required to start a pinch event
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="distance">Distance in pixels</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPinchGestureMinimumDistance(int distance)
        {
            Interop.GestureOptions.SetPinchGestureMinimumDistance(distance);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the minimum touch events required before a pinch can be started
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="number">The number of touch events</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPinchGestureMinimumTouchEvents(uint number)
        {
            Interop.GestureOptions.SetPinchGestureMinimumTouchEvents(number);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the minimum touch events required after a pinch started
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="number">The number of touch events</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPinchGestureMinimumTouchEventsAfterStart(uint number)
        {
            Interop.GestureOptions.SetPinchGestureMinimumTouchEventsAfterStart(number);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the minimum touch events required before a rotation can be started
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="number">The number of touch events</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetRotationGestureMinimumTouchEvents(uint number)
        {
            Interop.GestureOptions.SetRotationGestureMinimumTouchEvents(number);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the minimum touch events required after a rotation started
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="number">The number of touch events</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetRotationGestureMinimumTouchEventsAfterStart(uint number)
        {
            Interop.GestureOptions.SetRotationGestureMinimumTouchEventsAfterStart(number);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the minimum holding time required to be recognized as a long press gesture
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="time">The time value in milliseconds</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetLongPressMinimumHoldingTime(uint time)
        {
            Interop.GestureOptions.SetLongPressMinimumHoldingTime(time);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the duration in milliseconds between the first tap's up event and the second tap's down event to be recognized as a duoble-tap gesture.
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="ms">The time value in milliseconds</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetDoubleTapTimeout(uint ms)
        {
            Interop.GestureOptions.SetDoubleTapTimeout(ms);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
