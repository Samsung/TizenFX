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
    /// The PressureSensor class is used for registering callbacks for the pressure sensor and getting the pressure data.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class PressureSensor : Sensor
    {
        private static string PressureSensorKey = "http://tizen.org/feature/sensor.barometer";

        /// <summary>
        /// Gets the value of the pressure sensor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> Pressure </value>
        public float Pressure { get; private set; } = float.MinValue;

        /// <summary>
        /// Returns true or false based on whether the pressure sensor is supported by the device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value><c>true</c> if supported; otherwise <c>false</c>.</value>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the PressureSensor is supported");
                return CheckIfSupported(SensorType.PressureSensor, PressureSensorKey);
            }
        }

        /// <summary>
        /// Returns the number of pressure sensors available on the device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The count of pressure sensors. </value>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of pressure sensors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Sensor.PressureSensor"/> class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/sensor.barometer</feature>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular pressure sensor in case of multiple sensors.
        /// </param>
        public PressureSensor(uint index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating PressureSensor object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.PressureSensor;
        }

        /// <summary>
        /// An event handler for storing the callback functions for the event corresponding to the change in the pressure sensor data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>

        public event EventHandler<PressureSensorDataUpdatedEventArgs> DataUpdated;


        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.PressureSensor, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for pressure");
                count = 0;
            }
            else
                Interop.Libc.Free(list);
            return count;
        }

        /// <summary>
        /// Read pressure sensor data synchronously.
        /// </summary>
        internal override void ReadData()
        {
            Interop.SensorEventStruct sensorData;
            int error = Interop.SensorListener.ReadData(ListenerHandle, out sensorData);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error reading pressure sensor data");
                throw SensorErrorFactory.CheckAndThrowException(error, "Reading pressure sensor data failed");
            }

            Timestamp = sensorData.timestamp;
            Pressure = sensorData.values[0];
        }

        private static Interop.SensorListener.SensorEventsCallback _callback;

        internal override void EventListenStart()
        {
            _callback = (IntPtr sensorHandle, IntPtr eventPtr, uint events_count, IntPtr data) => {
                updateBatchEvents(eventPtr, events_count);
                Interop.SensorEventStruct sensorData = latestEvent();

                Timestamp = sensorData.timestamp;
                Pressure = sensorData.values[0];

                DataUpdated?.Invoke(this, new PressureSensorDataUpdatedEventArgs(sensorData.values[0]));
            };

            int error = Interop.SensorListener.SetEventsCallback(ListenerHandle, _callback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for pressure sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for pressure");
            }
        }

        internal override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventsCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for pressure sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for pressure");
            }
        }
    }
}
