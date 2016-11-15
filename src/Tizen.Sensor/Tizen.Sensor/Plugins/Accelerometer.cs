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
    /// Accelerometer Sensor Class. Used for registering callbacks for accelerometer and getting accelerometer data
    /// </summary>
    public sealed class Accelerometer : Sensor
    {
        private static string AccelerometerKey = "http://tizen.org/feature/sensor.accelerometer";
        /// <summary>
        /// Gets the X component of the acceleration.
        /// </summary>
        public float X { get; private set; } = float.MinValue;

        /// <summary>
        /// Gets the Y component of the acceleration.
        /// </summary>
        public float Y { get; private set; } = float.MinValue;

        /// <summary>
        /// Gets the Z component of the acceleration.
        /// </summary>
        public float Z { get; private set; } = float.MinValue;

        /// <summary>
        /// Returns true or false based on whether accelerometer sensor is supported by device.
        /// </summary>
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
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
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
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular accelerometer sensor in case of multiple sensors
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
        /// Event Handler for storing the callback functions for event corresponding to change in accelerometer sensor data.
        /// </summary>
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

        private static Interop.SensorListener.SensorEventCallback _callback;

        internal override void EventListenStart()
        {
            _callback = (IntPtr sensorHandle, IntPtr eventPtr, IntPtr data) => {
                Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(eventPtr);

                TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
                X = sensorData.values[0];
                Y = sensorData.values[1];
                Z = sensorData.values[2];

                DataUpdated?.Invoke(this, new AccelerometerDataUpdatedEventArgs(sensorData.values));
            };

            int error = Interop.SensorListener.SetEventCallback(ListenerHandle, Interval, _callback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for accelerometer sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for accelerometer");
            }
        }

        internal override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for accelerometer sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for accelerometer");
            }
        }
    }
}
