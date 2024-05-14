/*
 * Copyright (c) 2024 Samsung Electronics Co., Ltd.
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

/*
 * Copyright (C) 2017 The Android Open Source Project
 *
 * Modified by Joogab Yun(joogab.yun@samsung.com)
 */

using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI.Utility
{
    /// <summary>
    /// Calculates the velocity of touch movements over time.
    /// <example>
    ///  private void OnPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
    ///  {
    ///      tracker.AddMovement(e.PanGesture.ScreenPosition, e.PanGesture.Time);
    ///      if (e.PanGesture.State == Gesture.StateType.Started)
    ///      {
    ///      }
    ///      else if (e.PanGesture.State == Gesture.StateType.Continuing)
    ///      {
    ///      }
    ///      else if (e.PanGesture.State == Gesture.StateType.Finished || e.PanGesture.State == Gesture.StateType.Cancelled)
    ///      {
    ///          float panVelocity = (ScrollingDirection == Direction.Horizontal) ? tracker.GetVelocity().X : tracker.GetVelocity().Y;
    ///          tracker.Clear();
    ///      }
    ///  }
    /// </example>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class VelocityTracker
    {
        private struct Axis
        {
            public static int X = 0;
            public static int Y = 1;
        }

        private struct ComputedVelocity
        {
            private Dictionary<int, Dictionary<int, float>> mVelocities;

            public float? GetVelocity(int axis, int id)
            {
                if (mVelocities.ContainsKey(axis) == false)
                    return null;
                else if (mVelocities[axis].ContainsKey(id) == false)
                    return null;
                return mVelocities[axis][id];
            }

            public void AddVelocity(int axis, int id, float velocity)
            {
                if (mVelocities.ContainsKey(axis) == false)
                    mVelocities[axis] = new Dictionary<int, float>();
                mVelocities[axis][id] = velocity;
            }

            public ComputedVelocity(Dictionary<int, Dictionary<int, float>> velocities)
            {
                mVelocities = velocities;
            }
        }

        private int mPointerCount = 0;
        private bool mIsComputed = false;
        private ComputedVelocity mComputedVelocity;
        private VelocityTrackerStrategy[] mConfiguredStrategies;

        /// <summary>
        /// Creates a velocity tracker using the specified strategy.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VelocityTracker(int degree = 2)
        {
            mConfiguredStrategies = new LeastSquaresVelocityTrackerStrategy[2];
            for(int i = 0; i < 2; i++)
            {
                mConfiguredStrategies[i] = new LeastSquaresVelocityTrackerStrategy(degree);
            }
        }

        public VelocityTracker(VelocityTrackerStrategy[] strategy)
        {
            mConfiguredStrategies = strategy;
        }

        /// <summary>
        /// Adds movement information
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddMovement(Vector2 position, uint eventTime)
        {
            if (mConfiguredStrategies != null && mConfiguredStrategies.Length > 1)
            {
                mConfiguredStrategies[Axis.X]?.AddMovement(eventTime, mPointerCount, position.X);
                mConfiguredStrategies[Axis.Y]?.AddMovement(eventTime, mPointerCount, position.Y);
                mIsComputed = false;
            }
        }

        private static float Clamp(float value, float min, float max)
        {
            return value < min ? min : value > max ? max : value;
        }

        /// <summary>
        /// Compute the current velocity based on the points that have been collected.
        /// </summary>
        /// <param name="units">The units you would like the velocity in. A value of 1 provides units per millisecond, 1000 provides units per second.</param>
        /// <param name="maxVelocity">The maximum velocity that can be computed by this method.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ComputeVelocity(int units, float maxVelocity)
        {
            mComputedVelocity = new ComputedVelocity(new Dictionary<int, Dictionary<int, float>>());
            for (int axis = 0; axis < mConfiguredStrategies?.Length; axis++)
            {
                for (int j = 0; j <= mPointerCount; j++)
                {
                    float? velocity = mConfiguredStrategies[axis]?.GetVelocity(j);
                    if (velocity != null)
                    {
                        float adjustedVelocity = Clamp((float)velocity * units / 1000, -maxVelocity, maxVelocity);
                        mComputedVelocity.AddVelocity(axis, j, adjustedVelocity);
                    }
                }
            }
            mIsComputed = true;
        }

        private float GetVelocity(int axis, int id)
        {
            if (axis < 0 || axis > 1) return 0.0f;
            float? value = mComputedVelocity.GetVelocity(axis, id);
            return value.HasValue ? value.Value : 0.0f;
        }

        /// <summary>
        /// Retrieve the last computed velocity.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 GetVelocity()
        {
            if (mIsComputed == false)
                ComputeVelocity(1000, 100);
            float velocityX = GetVelocity(Axis.X, mPointerCount);
            float velocityY = GetVelocity(Axis.Y, mPointerCount);
            return new Vector2(velocityX, velocityY);
        }

        /// <summary>
        /// Resets the velocity tracker state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Clear()
        {
            for(int i = 0; i < mConfiguredStrategies?.Length; i++)
            {
                mConfiguredStrategies[i]?.Clear();
            }
            mPointerCount = 0;
            mIsComputed = false;
        }
    }
}
