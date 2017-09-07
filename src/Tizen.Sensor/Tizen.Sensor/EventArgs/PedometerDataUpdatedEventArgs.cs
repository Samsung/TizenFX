/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace Tizen.Sensor
{
    /// <summary>
    /// The Pedometer changed event arguments class is used for storing the data returned by a pedometer.
    /// </summary>
    public class PedometerDataUpdatedEventArgs : EventArgs
    {
        internal PedometerDataUpdatedEventArgs(float[] values)
        {
            StepCount = (uint) values[0];
            WalkStepCount = (uint) values[1];
            RunStepCount = (uint) values[2];
            MovingDistance = values[3];
            CalorieBurned = values[4];
            LastSpeed = values[5];
            LastSteppingFrequency = values[6];
            LastStepStatus = (PedometerState) values[7];
        }

        /// <summary>
        /// Gets the step count.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The step count. </value>
        public uint StepCount { get; private set; }

        /// <summary>
        /// Gets the walking step count.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The walk step count. </value>
        public uint WalkStepCount { get; private set; }

        /// <summary>
        /// Gets the running step count.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The run step count.</value>
        public uint RunStepCount { get; private set; }

        /// <summary>
        /// Gets the moving distance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The moving distance.</value>
        public float MovingDistance { get; private set; }

        /// <summary>
        /// Gets the calorie burned.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The calorie burned.</value>
        public float CalorieBurned { get; private set; }

        /// <summary>
        /// Gets the last speed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The last speed. </value>
        public float LastSpeed { get; private set; }

        /// <summary>
        /// Gets the last stepping frequency.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The last stepping frequency.</value>
        public float LastSteppingFrequency { get; private set; }

        /// <summary>
        /// Gets the last step status.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The last stepping status. </value>
        public PedometerState LastStepStatus { get; private set; }
    }
}
