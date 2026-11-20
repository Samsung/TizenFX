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
        private static uint panGestureMinimumTouchesRequired;
        private static uint panGestureMaximumTouchesRequired;

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
        /// Sets the minimum number of touches required for the pan gesture to be detected.
        /// </summary>
        /// <param name="minimum">The minimum number of touches required</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGestureMinimumTouchesRequired(uint minimum)
        {
            panGestureMinimumTouchesRequired = minimum;
        }

        /// <summary>
        /// Gets the minimum number of touches required for the pan gesture to be detected.
        /// </summary>
        /// <returns>The minimum number of touches required</returns>
        internal uint GetPanGestureMinimumTouchesRequired()
        {
            return panGestureMinimumTouchesRequired;
        }

        /// <summary>
        /// Sets the maximum number of touches required for the pan gesture to be detected.
        /// </summary>
        /// <param name="maximum">The maximum number of touches required</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanGestureMaximumTouchesRequired(uint maximum)
        {
            panGestureMaximumTouchesRequired = maximum;
        }

        /// <summary>
        /// Gets the maximum number of touches required for the pan gesture to be detected.
        /// </summary>
        /// <returns>The maximum number of touches required</returns>
        internal uint GetPanGestureMaximumTouchesRequired()
        {
            return panGestureMaximumTouchesRequired;
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
        /// Sets the duration in milliseconds the duration time for recognizing multi-tap gesture.
        /// If there are two taps within this time, it is a double tap.
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="ms">The time value in milliseconds</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetDoubleTapTimeout(uint ms)
        {
            Interop.GestureOptions.SetDoubleTapTimeout(ms);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the recognizer time required to be recognized as a tap gesture,
        /// This time is from touch down to touch up to recognize the tap gesture.
        /// If the time between touch down and touch up is longer than recognizer time, it is not recognized as a tap gesture.
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="ms">The time value in milliseconds</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTapRecognizerTime(uint ms)
        {
            Interop.GestureOptions.SetTapRecognizerTime(ms);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the distance required to be recognized as a tap gesture,
        /// This distance is from touch down to touch up to recognize the tap gesture.
        /// If the distance between touch down and touch up is longer than distance, it is not recognized as a tap gesture.
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all gestures.</remarks>
        /// <param name="distance">The distance</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTapMaximumMotionAllowedDistance(float distance)
        {
            Interop.GestureOptions.SetTapMaximumMotionAllowedDistance(distance);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns a copy of the pan recognition thresholds used when no device-specific thresholds match.
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all pan gesture detectors.</remarks>
        /// <returns>A new PanThresholds object. Dispose it when no longer needed.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PanThresholds GetDefaultPanThresholds()
        {
            PanThresholds ret = new PanThresholds(Interop.GestureThresholds.GetDefaultPanThresholds(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Registers the pan recognition thresholds to use for gestures that start on a device matching the selector.<br />
        /// Registering with an equal selector replaces the earlier thresholds. The values are copied, so later changes to
        /// <paramref name="thresholds"/> have no effect until they are set again.
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all pan gesture detectors, including those created by components.</remarks>
        /// <param name="selector">The devices the thresholds apply to.</param>
        /// <param name="thresholds">The complete thresholds for those devices.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPanThresholds(GestureDeviceSelector selector, PanThresholds thresholds)
        {
            Interop.GestureThresholds.SetPanThresholds(GestureDeviceSelector.getCPtr(selector), PanThresholds.getCPtr(thresholds));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves the pan recognition thresholds registered for exactly this selector. Fallback to a less specific selector is not applied.
        /// </summary>
        /// <param name="selector">The selector the thresholds were registered with.</param>
        /// <param name="thresholds">The registered thresholds, or null when none are registered for the selector.</param>
        /// <returns>True when thresholds are registered for the selector.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TryGetPanThresholds(GestureDeviceSelector selector, out PanThresholds thresholds)
        {
            PanThresholds result = new PanThresholds();
            bool found = Interop.GestureThresholds.GetPanThresholds(GestureDeviceSelector.getCPtr(selector), PanThresholds.getCPtr(result));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                result.Dispose();
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            if (!found)
            {
                result.Dispose();
                thresholds = null;
                return false;
            }

            thresholds = result;
            return true;
        }

        /// <summary>
        /// Removes the pan recognition thresholds registered for exactly this selector. Does nothing when none are registered.
        /// </summary>
        /// <param name="selector">The selector the thresholds were registered with.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearPanThresholds(GestureDeviceSelector selector)
        {
            Interop.GestureThresholds.ClearPanThresholds(GestureDeviceSelector.getCPtr(selector));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns a copy of the tap recognition thresholds used when no device-specific thresholds match.
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all tap gesture detectors.</remarks>
        /// <returns>A new TapThresholds object. Dispose it when no longer needed.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TapThresholds GetDefaultTapThresholds()
        {
            TapThresholds ret = new TapThresholds(Interop.GestureThresholds.GetDefaultTapThresholds(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Registers the tap recognition thresholds to use for gestures that start on a device matching the selector.<br />
        /// Registering with an equal selector replaces the earlier thresholds. The values are copied, so later changes to
        /// <paramref name="thresholds"/> have no effect until they are set again.
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all tap gesture detectors, including those created by components.</remarks>
        /// <param name="selector">The devices the thresholds apply to.</param>
        /// <param name="thresholds">The complete thresholds for those devices.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTapThresholds(GestureDeviceSelector selector, TapThresholds thresholds)
        {
            Interop.GestureThresholds.SetTapThresholds(GestureDeviceSelector.getCPtr(selector), TapThresholds.getCPtr(thresholds));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves the tap recognition thresholds registered for exactly this selector. Fallback to a less specific selector is not applied.
        /// </summary>
        /// <param name="selector">The selector the thresholds were registered with.</param>
        /// <param name="thresholds">The registered thresholds, or null when none are registered for the selector.</param>
        /// <returns>True when thresholds are registered for the selector.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TryGetTapThresholds(GestureDeviceSelector selector, out TapThresholds thresholds)
        {
            TapThresholds result = new TapThresholds();
            bool found = Interop.GestureThresholds.GetTapThresholds(GestureDeviceSelector.getCPtr(selector), TapThresholds.getCPtr(result));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                result.Dispose();
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            if (!found)
            {
                result.Dispose();
                thresholds = null;
                return false;
            }

            thresholds = result;
            return true;
        }

        /// <summary>
        /// Removes the tap recognition thresholds registered for exactly this selector. Does nothing when none are registered.
        /// </summary>
        /// <param name="selector">The selector the thresholds were registered with.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearTapThresholds(GestureDeviceSelector selector)
        {
            Interop.GestureThresholds.ClearTapThresholds(GestureDeviceSelector.getCPtr(selector));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns a copy of the long press recognition thresholds used when no device-specific thresholds match.
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all long press gesture detectors.</remarks>
        /// <returns>A new LongPressThresholds object. Dispose it when no longer needed.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LongPressThresholds GetDefaultLongPressThresholds()
        {
            LongPressThresholds ret = new LongPressThresholds(Interop.GestureThresholds.GetDefaultLongPressThresholds(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Registers the long press recognition thresholds to use for gestures that start on a device matching the selector.<br />
        /// Registering with an equal selector replaces the earlier thresholds. The values are copied, so later changes to
        /// <paramref name="thresholds"/> have no effect until they are set again.
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all long press gesture detectors, including those created by components.</remarks>
        /// <param name="selector">The devices the thresholds apply to.</param>
        /// <param name="thresholds">The complete thresholds for those devices.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetLongPressThresholds(GestureDeviceSelector selector, LongPressThresholds thresholds)
        {
            Interop.GestureThresholds.SetLongPressThresholds(GestureDeviceSelector.getCPtr(selector), LongPressThresholds.getCPtr(thresholds));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves the long press recognition thresholds registered for exactly this selector. Fallback to a less specific selector is not applied.
        /// </summary>
        /// <param name="selector">The selector the thresholds were registered with.</param>
        /// <param name="thresholds">The registered thresholds, or null when none are registered for the selector.</param>
        /// <returns>True when thresholds are registered for the selector.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TryGetLongPressThresholds(GestureDeviceSelector selector, out LongPressThresholds thresholds)
        {
            LongPressThresholds result = new LongPressThresholds();
            bool found = Interop.GestureThresholds.GetLongPressThresholds(GestureDeviceSelector.getCPtr(selector), LongPressThresholds.getCPtr(result));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                result.Dispose();
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            if (!found)
            {
                result.Dispose();
                thresholds = null;
                return false;
            }

            thresholds = result;
            return true;
        }

        /// <summary>
        /// Removes the long press recognition thresholds registered for exactly this selector. Does nothing when none are registered.
        /// </summary>
        /// <param name="selector">The selector the thresholds were registered with.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearLongPressThresholds(GestureDeviceSelector selector)
        {
            Interop.GestureThresholds.ClearLongPressThresholds(GestureDeviceSelector.getCPtr(selector));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns a copy of the pinch recognition thresholds used when no device-specific thresholds match.
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all pinch gesture detectors.</remarks>
        /// <returns>A new PinchThresholds object. Dispose it when no longer needed.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PinchThresholds GetDefaultPinchThresholds()
        {
            PinchThresholds ret = new PinchThresholds(Interop.GestureThresholds.GetDefaultPinchThresholds(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Registers the pinch recognition thresholds to use for gestures that start on a device matching the selector.<br />
        /// Registering with an equal selector replaces the earlier thresholds. The values are copied, so later changes to
        /// <paramref name="thresholds"/> have no effect until they are set again.
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all pinch gesture detectors, including those created by components.</remarks>
        /// <param name="selector">The devices the thresholds apply to.</param>
        /// <param name="thresholds">The complete thresholds for those devices.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPinchThresholds(GestureDeviceSelector selector, PinchThresholds thresholds)
        {
            Interop.GestureThresholds.SetPinchThresholds(GestureDeviceSelector.getCPtr(selector), PinchThresholds.getCPtr(thresholds));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves the pinch recognition thresholds registered for exactly this selector. Fallback to a less specific selector is not applied.
        /// </summary>
        /// <param name="selector">The selector the thresholds were registered with.</param>
        /// <param name="thresholds">The registered thresholds, or null when none are registered for the selector.</param>
        /// <returns>True when thresholds are registered for the selector.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TryGetPinchThresholds(GestureDeviceSelector selector, out PinchThresholds thresholds)
        {
            PinchThresholds result = new PinchThresholds();
            bool found = Interop.GestureThresholds.GetPinchThresholds(GestureDeviceSelector.getCPtr(selector), PinchThresholds.getCPtr(result));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                result.Dispose();
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            if (!found)
            {
                result.Dispose();
                thresholds = null;
                return false;
            }

            thresholds = result;
            return true;
        }

        /// <summary>
        /// Removes the pinch recognition thresholds registered for exactly this selector. Does nothing when none are registered.
        /// </summary>
        /// <param name="selector">The selector the thresholds were registered with.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearPinchThresholds(GestureDeviceSelector selector)
        {
            Interop.GestureThresholds.ClearPinchThresholds(GestureDeviceSelector.getCPtr(selector));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns a copy of the rotation recognition thresholds used when no device-specific thresholds match.
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all rotation gesture detectors.</remarks>
        /// <returns>A new RotationThresholds object. Dispose it when no longer needed.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RotationThresholds GetDefaultRotationThresholds()
        {
            RotationThresholds ret = new RotationThresholds(Interop.GestureThresholds.GetDefaultRotationThresholds(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Registers the rotation recognition thresholds to use for gestures that start on a device matching the selector.<br />
        /// Registering with an equal selector replaces the earlier thresholds. The values are copied, so later changes to
        /// <paramref name="thresholds"/> have no effect until they are set again.
        /// </summary>
        /// <remarks>This is a global configuration option. Affects all rotation gesture detectors, including those created by components.</remarks>
        /// <param name="selector">The devices the thresholds apply to.</param>
        /// <param name="thresholds">The complete thresholds for those devices.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetRotationThresholds(GestureDeviceSelector selector, RotationThresholds thresholds)
        {
            Interop.GestureThresholds.SetRotationThresholds(GestureDeviceSelector.getCPtr(selector), RotationThresholds.getCPtr(thresholds));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves the rotation recognition thresholds registered for exactly this selector. Fallback to a less specific selector is not applied.
        /// </summary>
        /// <param name="selector">The selector the thresholds were registered with.</param>
        /// <param name="thresholds">The registered thresholds, or null when none are registered for the selector.</param>
        /// <returns>True when thresholds are registered for the selector.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TryGetRotationThresholds(GestureDeviceSelector selector, out RotationThresholds thresholds)
        {
            RotationThresholds result = new RotationThresholds();
            bool found = Interop.GestureThresholds.GetRotationThresholds(GestureDeviceSelector.getCPtr(selector), RotationThresholds.getCPtr(result));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                result.Dispose();
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            if (!found)
            {
                result.Dispose();
                thresholds = null;
                return false;
            }

            thresholds = result;
            return true;
        }

        /// <summary>
        /// Removes the rotation recognition thresholds registered for exactly this selector. Does nothing when none are registered.
        /// </summary>
        /// <param name="selector">The selector the thresholds were registered with.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearRotationThresholds(GestureDeviceSelector selector)
        {
            Interop.GestureThresholds.ClearRotationThresholds(GestureDeviceSelector.getCPtr(selector));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
