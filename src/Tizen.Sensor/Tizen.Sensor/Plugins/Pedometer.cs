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
    /// Pedometer Sensor Class. Used for registering callbacks for pedometer and getting pedometer data
    /// /// </summary>
    public sealed class Pedometer : Sensor
    {
        private static string PedometerKey = "http://tizen.org/feature/sensor.pedometer";

        /// <summary>
        /// Gets the step count
        /// </summary>
        public uint StepCount { get; private set; } = 0;

        /// <summary>
        /// Gets the walking step count
        /// </summary>
        public uint WalkStepCount { get; private set; } = 0;

        /// <summary>
        /// Gets the running step count
        /// </summary>
        public uint RunStepCount { get; private set; } = 0;

        /// <summary>
        /// Gets the moving distance
        /// </summary>
        public float MovingDistance { get; private set; } = 0;

        /// <summary>
        /// Gets the calorie burned
        /// </summary>
        public float CalorieBurned { get; private set; } = 0;

        /// <summary>
        /// Gets the last speed
        /// </summary>
        public float LastSpeed { get; private set; } = 0;

        /// <summary>
        /// Gets the last stepping frequency
        /// </summary>
        public float LastSteppingFrequency { get; private set; } = 0;

        /// <summary>
        /// Gets the last step status
        /// </summary>
        public PedometerState LastStepStatus { get; private set; } = PedometerState.Unknown;

        /// <summary>
        /// Returns true or false based on whether pedometer sensor is supported by device.
        /// </summary>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the Pedometer sensor is supported");
                return CheckIfSupported(SensorType.Pedometer, PedometerKey);
            }
        }

        /// <summary>
        /// Returns the number of pedometer sensors available on the device.
        /// </summary>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of pedometer sensors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Sensor.Pedometer"/> class.
        /// </summary>
        /// <remarks>
        /// For accessing pedometer, app should have http://tizen.org/privilege/healthinfo privilege.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported</exception>
        /// <exception cref="UnauthroizedAccessException">Thrown when the app has no privilege to use the sensor</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular pedometer sensor in case of multiple sensors
        /// </param>
        public Pedometer(uint index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating Pedometer object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.Pedometer;
        }

        /// <summary>
        /// Event Handler for storing the callback functions for event corresponding to change in pedometer sensor data.
        /// </summary>

        public event EventHandler<PedometerDataUpdatedEventArgs> DataUpdated;

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.Pedometer, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for pedometer");
                count = 0;
            }
            else
                Interop.Libc.Free(list);
            return count;
        }

        internal override void EventListenStart()
        {
            int error = Interop.SensorListener.SetEventCallback(ListenerHandle, Interval, SensorEventCallback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for pedometer sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for pedometer");
            }
        }

        internal override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for pedometer sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for pedometer");
            }
        }

        private void SensorEventCallback(IntPtr sensorHandle, IntPtr sensorPtr, IntPtr data)
        {
            Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(sensorPtr);
            TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
            StepCount = (uint)sensorData.values[0];
            WalkStepCount = (uint)sensorData.values[1];
            RunStepCount = (uint)sensorData.values[2];
            MovingDistance = sensorData.values[3];
            CalorieBurned = sensorData.values[4];
            LastSpeed = sensorData.values[5];
            LastSteppingFrequency = sensorData.values[6];
            LastStepStatus = (PedometerState)sensorData.values[7];

            DataUpdated?.Invoke(this, new PedometerDataUpdatedEventArgs(sensorData.values));
        }
    }
}
