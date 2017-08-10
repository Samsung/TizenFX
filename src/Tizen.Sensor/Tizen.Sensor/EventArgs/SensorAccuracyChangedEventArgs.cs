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
    /// Sensor accuracy changed event arguments Class. Contains the parameters to be returned through accuracy callback
    /// </summary>
    public class SensorAccuracyChangedEventArgs : EventArgs
    {
        internal SensorAccuracyChangedEventArgs(TimeSpan timespan, SensorDataAccuracy accuracy)
        {
            TimeSpan = timespan;
            Accuracy = accuracy;
        }

        /// <summary>
        /// Gets the time stamp.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> Time span </value>
        public TimeSpan TimeSpan { get; private set; }

        /// <summary>
        /// Gets the accuracy.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> Accuracy </value>
        public SensorDataAccuracy Accuracy { get; private set; }
    }
}