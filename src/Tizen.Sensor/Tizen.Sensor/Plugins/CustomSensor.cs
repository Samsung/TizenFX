/*
* Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// The CustomSensor class is used for registering callbacks for the custom sensor and getting the custom sensor data.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    public sealed class CustomSensor : Sensor
    {
        private uint _index;
        private const uint maxDataCount = 16;
        private String customSensorKey;

        /// <summary>
        /// Gets the sensor data of custom sensor.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// <value> Values </value>
        public float[] Values { get; private set; }

        /// <summary>
        /// Return true, It doesn't need to check sensor type in case of custom sensor.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public bool IsSupported
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets the number of sensor data for custom sensor.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// <value> ValueCount </value>
        public int ValueCount { get; private set; }

        /// <summary>
        /// Returns the number of custom sensors available on the device.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// <value> The count of custom sensors. </value>
        public int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of custom sensors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Sensor.CustomSensor"/> class.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// <feature>http://tizen.org/feature/sensor</feature>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when values can't allocate memory.</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular custom sensor in case of multiple sensors.
        /// </param>
        /// <param name='uri'>URI infomation.</param>
        public CustomSensor(String uri, uint index = 0) : base(uri, index)
        {
            customSensorKey = String.Copy(uri);
            _index = index;
            try
            {
                Values = new float[maxDataCount];
            }
            catch (OutOfMemoryException e)
            {
                Log.Error(Globals.LogTag, "Memory allocation failed");
            }

            Log.Info(Globals.LogTag, "Creating CustomSensor");
            Log.Debug(Globals.LogTag, "URI : " + customSensorKey);
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.All;
        }

        /// <summary>
        /// An event handler for storing the callback functions for the event corresponding to the change in the custom sensor data.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>

        public event EventHandler<CustomSensorDataUpdatedEventArgs> DataUpdated;

        private int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorListByUri(customSensorKey, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for Custom");
                count = 0;
            }
            else
                Interop.Libc.Free(list);
            Log.Info(Globals.LogTag, "GetCount():" + count.ToString());
            return count;
        }

        private static Interop.SensorListener.SensorEventCallback _callback;

        internal override void EventListenStart()
        {
            _callback = (IntPtr sensorHandle, IntPtr eventPtr, IntPtr data) => {
                Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(eventPtr);

                TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
                Log.Debug(Globals.LogTag, "sensorData.value_count : " + sensorData.value_count);

                Array.Copy(sensorData.values, Values, sensorData.value_count);
                ValueCount = sensorData.value_count;
                Log.Debug(Globals.LogTag, "Values length : " + Values.Length);

                DataUpdated?.Invoke(this, new CustomSensorDataUpdatedEventArgs(sensorData));
            };

            int error = Interop.SensorListener.SetEventCallback(ListenerHandle, Interval, _callback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for custom sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for custom sensor");
            }
        }

        internal override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for custom sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for proximity");
            }
        }
    }
}
