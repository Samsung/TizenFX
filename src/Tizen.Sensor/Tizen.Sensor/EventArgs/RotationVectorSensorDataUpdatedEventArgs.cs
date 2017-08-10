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
    /// RotationVectorSensor changed event arguments. Class for storing the data returned by rotation vector sensor
    /// </summary>
    public class RotationVectorSensorDataUpdatedEventArgs : EventArgs
    {
        internal RotationVectorSensorDataUpdatedEventArgs(float[] values, SensorDataAccuracy accuracy)
        {
            X = values[0];
            Y = values[1];
            Z = values[2];
            W = values[3];
            Accuracy = accuracy;
        }

        /// <summary>
        /// Gets the X component of the rotation vector.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> X </value>
        public float X { get; private set; }

        /// <summary>
        /// Gets the Y component of the rotation vector.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> Y </value>
        public float Y { get; private set; }

        /// <summary>
        /// Gets the Z component of the rotation vector.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> Z </value>
        public float Z { get; private set; }

        /// <summary>
        /// Gets the W component of the rotation vector.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> W </value>
        public float W { get; private set;}

        /// <summary>
        /// Gets the accuracy of the rotation vector data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> Accuracy </value>
        public SensorDataAccuracy Accuracy { get; private set; }
    }
}