/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// The SleepDetector changed event arguments class is used for storing the data returned by a sleep detector.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class SleepDetectorDataUpdatedEventArgs : EventArgs
    {
        internal SleepDetectorDataUpdatedEventArgs(float[] values)
        {
            BedTime = values[0];
            GetUpTime = values[1];
            StartTime = values[2];
            DelayTime = values[3];
        }

        /// <summary>
        /// Gets the value of the bed time.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The bed time. </value>
        public float BedTime { get; private set; }

        /// <summary>
        /// Gets the value of the get up time.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The get up time. </value>
        public float GetUpTime { get; private set; }

        /// <summary>
        /// Gets the value of the start time.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The start time. </value>
        public float StartTime { get; private set; }

        /// <summary>
        /// Gets the value of the delay time.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The delay time. </value>
        public float DelayTime { get; private set; }
    }
}