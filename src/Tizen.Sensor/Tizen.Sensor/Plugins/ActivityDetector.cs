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
    /// The Activity Detector class is used for storing the common activity information.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public abstract class ActivityDetector : Sensor
    {
        /// <summary>
        /// Attribute key for a activity detector.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected const int ActivityAttribute = (((int)SensorType.StationaryActivityDetector << 8) | 0x80 | 0x1);

        /// <summary>
        /// Activity types.
        /// </summary>
        protected enum ActivityType
        {
            /// <summary>
            /// Unknown.
            /// </summary>
            Unknown = 1,
            /// <summary>
            /// Stationary.
            /// </summary>
            Stationary = 2,
            /// <summary>
            /// Walking.
            /// </summary>
            Walking = 4,
            /// <summary>
            /// Running.
            /// </summary>
            Running = 8,
            /// <summary>
            /// In vehicle.
            /// </summary>
            InVehicle = 16,
            /// <summary>
            /// On bicycle.
            /// </summary>
            OnBicycle = 32,
        };

        /// <summary>
        /// Get the activity accuracy of the activity detector sensor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The activity accuracy. </value>
        public SensorDataAccuracy ActivityAccuracy { get; protected set; }

        internal ActivityDetector(uint index) : base(index)
        {
        }
    }
}
