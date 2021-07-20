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
    public class GestureOptions : Disposable
    {
        private static readonly GestureOptions instance = new GestureOptions();

        /// <summary>
        /// Constructor.
        /// </summary>
        private GestureOptions() : base()
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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
        /// <param name="value">True = use actual times, False = use perfect values</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGestureUseActualTimes(bool value)
        {
            Interop.GestureOptions.SetPanGestureUseActualTimes(value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the interpolation time range (ms) of past points to use (with weights) when interpolating.
        /// </summary>
        /// <param name="value">Time range in ms</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGestureInterpolationTimeRange(int value)
        {
            Interop.GestureOptions.SetPanGestureInterpolationTimeRange(value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets whether to use scalar only prediction, which when enabled, ignores acceleration.
        /// </summary>
        /// <param name="value">True = use scalar prediction only</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGestureScalarOnlyPredictionEnabled(bool value)
        {
            Interop.GestureOptions.SetPanGestureScalarOnlyPredictionEnabled(value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets whether to use two point prediction. This combines two interpolated points to get more steady acceleration and velocity values.
        /// </summary>
        /// <param name="value">True = use two point prediction</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGestureTwoPointPredictionEnabled(bool value)
        {
            Interop.GestureOptions.SetPanGestureTwoPointPredictionEnabled(value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the time in the past to interpolate the second point when using two point interpolation.
        /// </summary>
        /// <param name="value">Time in past in ms</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGestureTwoPointInterpolatePastTime(int value)
        {
            Interop.GestureOptions.SetPanGestureTwoPointInterpolatePastTime(value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the two point velocity bias. This is the ratio of first and second points to use for velocity.
        /// </summary>
        /// <param name="value">0.0f = 100% first point. 1.0f = 100% of second point.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGestureTwoPointVelocityBias(float value)
        {
            Interop.GestureOptions.SetPanGestureTwoPointVelocityBias(value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the two point acceleration bias. This is the ratio of first and second points to use for acceleration.
        /// </summary>
        /// <param name="value">0.0f = 100% first point. 1.0f = 100% of second point.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGestureTwoPointAccelerationBias(float value)
        {
            Interop.GestureOptions.SetPanGestureTwoPointAccelerationBias(value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the range of time (ms) of points in the history to perform multitap smoothing with (if enabled).
        /// </summary>
        /// <param name="value">Time in past in ms</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGestureMultitapSmoothingRange(int value)
        {
            Interop.GestureOptions.SetPanGestureMultitapSmoothingRange(value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the minimum distance required to start a pan event
        /// </summary>
        /// <param name="value">Distance in pixels</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGestureMinimumDistance(int value)
        {
            Interop.GestureOptions.SetPanGestureMinimumDistance(value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the minimum number of touch events required to start a pan
        /// </summary>
        /// <param name="value">Number of touch events</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGestureMinimumPanEvents(int value)
        {
            Interop.GestureOptions.SetPanGestureMinimumPanEvents(value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the minimum distance required to start a pinch event
        /// </summary>
        /// <param name="value">Distance in pixels</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPinchGestureMinimumDistance(int value)
        {
            Interop.GestureOptions.SetPinchGestureMinimumDistance(value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the minimum touch events required before a pinch can be started
        /// </summary>
        /// <param name="value">The number of touch events</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPinchGestureMinimumTouchEvents(uint value)
        {
            Interop.GestureOptions.SetPinchGestureMinimumTouchEvents(value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the minimum touch events required after a pinch started
        /// </summary>
        /// <param name="value">The number of touch events</param>
        public void SetPinchGestureMinimumTouchEventsAfterStart(uint value)
        {
            Interop.GestureOptions.SetPinchGestureMinimumTouchEventsAfterStart(value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the minimum touch events required before a rotation can be started
        /// </summary>
        /// <param name="value">The number of touch events</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetRotationGestureMinimumTouchEvents(uint value)
        {
            Interop.GestureOptions.SetRotationGestureMinimumTouchEvents(value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the minimum touch events required after a rotation started
        /// </summary>
        /// <param name="value">The number of touch events</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetRotationGestureMinimumTouchEventsAfterStart(uint value)
        {
            Interop.GestureOptions.SetRotationGestureMinimumTouchEventsAfterStart(value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the minimum holding time required to be recognized as a long press gesture
        /// </summary>
        /// <param name="value">The time value in milliseconds</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetLongPressMinimumHoldingTime(uint value)
        {
            Interop.GestureOptions.SetLongPressMinimumHoldingTime(value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }


    }
}
