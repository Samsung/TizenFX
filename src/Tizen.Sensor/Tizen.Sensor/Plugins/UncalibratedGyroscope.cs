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
    /// UncalibratedGyroscope Sensor Class. Used for registering callbacks for uncalibrated gyroscope and getting uncalibrated gyroscope data
    /// /// </summary>
    public sealed class UncalibratedGyroscope : Sensor
    {
        private static string UncalibratedGyroscopeKey = "http://tizen.org/feature/sensor.gyroscope.uncalibrated";

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
        /// Gets the BiasX component of the uncalibrated gyroscope data.
        /// </summary>
        public float BiasX { get; private set; } = 0;

        /// <summary>
        /// Gets the BiasY component of the uncalibrated gyroscope data.
        /// </summary>
        public float BiasY { get; private set; } = 0;

        /// <summary>
        /// Gets the BiasZ component of the uncalibrated gyroscope data.
        /// </summary>
        public float BiasZ { get; private set; } = 0;

        /// <summary>
        /// Returns true or false based on whether uncalibrated gyroscope sensor is supported by device.
        /// </summary>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the UncalibratedGyroscope sensor is supported");
                return CheckIfSupported(SensorType.UncalibratedGyroscope, UncalibratedGyroscopeKey);
            }
        }

        /// <summary>
        /// Returns the number of uncalibrated gyroscope sensors available on the device.
        /// </summary>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of uncalibrated gyroscope sensors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Sensor.UncalibratedGyroscope"/> class.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular uncalibrated gyroscope sensor in case of multiple sensors
        /// </param>
        public UncalibratedGyroscope(uint index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating UncalibratedGyroscope object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.UncalibratedGyroscope;
        }

        /// <summary>
        /// Event Handler for storing the callback functions for event corresponding to change in uncalibrated gyroscope sensor data.
        /// </summary>

        public event EventHandler<UncalibratedGyroscopeDataUpdatedEventArgs> DataUpdated;

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.UncalibratedGyroscope, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for uncalibrated gyroscope");
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
                BiasX = sensorData.values[3];
                BiasY = sensorData.values[4];
                BiasZ = sensorData.values[5];

                DataUpdated?.Invoke(this, new UncalibratedGyroscopeDataUpdatedEventArgs(sensorData.values));
            };

            int error = Interop.SensorListener.SetEventCallback(ListenerHandle, Interval, _callback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for uncalibrated gyroscope sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for uncalibrated gyroscope");
            }
        }

        internal override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for uncalibrated gyroscope sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for uncalibrated gyroscope");
            }
        }
    }
}
