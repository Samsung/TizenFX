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
    /// UncalibratedGyroscope changed event arguments. Class for storing the data returned by uncalibrated gyroscope
    /// </summary>
    public class UncalibratedGyroscopeDataUpdatedEventArgs : EventArgs
    {
        internal UncalibratedGyroscopeDataUpdatedEventArgs(float[] values)
        {
            X = values[0];
            Y = values[1];
            Z = values[2];
            BiasX = values[3];
            BiasY = values[4];
            BiasZ = values[5];
        }

        /// <summary>
        /// Gets the X component of the uncalibrated gyroscope data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> X </value>
        public float X { get; private set; }

        /// <summary>
        /// Gets the Y component of the uncalibrated gyroscope data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> Y </value>
        public float Y { get; private set; }

        /// <summary>
        /// Gets the Z component of the uncalibrated gyroscope data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> Z </value>
        public float Z { get; private set; }

        /// <summary>
        /// Gets the BiasX component of the uncalibrated gyroscope data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> X bias </value>
        public float BiasX { get; private set; }

        /// <summary>
        /// Gets the BiasY component of the uncalibrated gyroscope data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> Y bias </value>
        public float BiasY { get; private set; }

        /// <summary>
        /// Gets the BiasZ component of the uncalibrated gyroscope data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> Z bias </value>
        public float BiasZ { get; private set; }
    }
}