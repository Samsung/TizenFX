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
    /// The Accelerometer Sensor class is used for registering callbacks for the accelerometer and getting the accelerometer data.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class Accelerometer : Sensor
    {
        private static string AccelerometerKey = "http://tizen.org/feature/sensor.accelerometer";
        /// <summary>
        /// Gets the X component of the acceleration.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> X </value>
        public float X { get; private set; } = float.MinValue;

        /// <summary>
        /// Gets the Y component of the acceleration.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> Y </value>
        public float Y { get; private set; } = float.MinValue;

        /// <summary>
        /// Gets the Z component of the acceleration.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> Z </value>
        public float Z { get; private set; } = float.MinValue;

        /// <summary>
        /// Returns true or false based on whether accelerometer sensor is supported by the device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value><c>true</c> if supported; otherwise <c>false</c>.</value>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the Accelerometer sensor is supported");
                return CheckIfSupported(SensorType.Accelerometer, AccelerometerKey);
            }
        }

        /// <summary>
        /// Returns the number of accelerometer sensors available on the device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The count of accelerometer sensors. </value>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of accelerometer sensors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Sensor.Accelerometer"/> class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/sensor.accelerometer</feature>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular accelerometer sensor in case of multiple sensors.
        /// </param>
        public Accelerometer(uint index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating Accelerometer object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.Accelerometer;
        }

        /// <summary>
        /// An event handler for storing the callback functions for the event corresponding to the change in the accelerometer sensor data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<AccelerometerDataUpdatedEventArgs> DataUpdated;

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.Accelerometer, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for accelerometer");
                count = 0;
            }
            else
                Interop.Libc.Free(list);
            return count;
        }

        /// <summary>
        /// Read accelerometer data synchronously.
        /// </summary>
        internal override void ReadData()
        {
            Interop.SensorEventStruct sensorData;
            int error = Interop.SensorListener.ReadData(ListenerHandle, out sensorData);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error reading accelerometer data");
                throw SensorErrorFactory.CheckAndThrowException(error, "Reading accelerometer data failed");
            }

            Timestamp = sensorData.timestamp;
            X = sensorData.values[0];
            Y = sensorData.values[1];
            Z = sensorData.values[2];
        }

        private static Interop.SensorListener.SensorEventsCallback _callback;

        internal override void EventListenStart()
        {
            _callback = (IntPtr sensorHandle, IntPtr eventPtr, uint events_count, IntPtr data) => {
                updateBatchEvents(eventPtr, events_count);
                Interop.SensorEventStruct sensorData = latestEvent();
                Timestamp = sensorData.timestamp;
                X = sensorData.values[0];
                Y = sensorData.values[1];
                Z = sensorData.values[2];
                DataUpdated?.Invoke(this, new AccelerometerDataUpdatedEventArgs(sensorData.values));
            };

            int error = Interop.SensorListener.SetEventsCallback(ListenerHandle, _callback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for accelerometer sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for accelerometer");
            }
        }

        internal override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventsCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for accelerometer sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for accelerometer");
            }
        }
    }
}
