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
    /// The CustomSensor changed event arguments class is used for storing the data returned by a custom sensor.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class CustomSensorDataUpdatedEventArgs : EventArgs
    {
        internal CustomSensorDataUpdatedEventArgs(Interop.SensorEventStruct sensorData)
        {
            try
            {
                Values = new float[sensorData.value_count];
                Array.Copy(sensorData.values, Values, sensorData.value_count);
            }
            catch (OutOfMemoryException e)
            {
                Log.Error(Globals.LogTag, e.Message +  "Memory allocation failed");
            }
        }

        /// <summary>
        /// Gets the custom values.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The custom values. </value>
        public float[] Values { get; private set; }
    }
}