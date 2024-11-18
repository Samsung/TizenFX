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
    /// The Pedometer Sensor class is used for registering callbacks for the pedometer and getting the pedometer data.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class Pedometer : Sensor
    {
        private static string PedometerKey = "http://tizen.org/feature/sensor.pedometer";

        /// <summary>
        /// Get the step count from pedometer as unsigned integer type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The step count. </value>
        public uint StepCount { get; private set; } = 0;

        /// <summary>
        /// Get the walking step count from pedometer as unsigned integer type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The walk step count. </value>
        public uint WalkStepCount { get; private set; } = 0;

        /// <summary>
        /// Get the running step count from pedometer as unsigned integer type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The run step count. </value>
        public uint RunStepCount { get; private set; } = 0;

        /// <summary>
        /// Get the moving distance from pedometer as float type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The moving distance. </value>
        public float MovingDistance { get; private set; } = 0;

        /// <summary>
        /// Get the calorie burned from pedometer as float type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The calorie burned. </value>
        public float CalorieBurned { get; private set; } = 0;

        /// <summary>
        /// Get the last speed from pedometer as float type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The last speed. </value>
        public float LastSpeed { get; private set; } = 0;

        /// <summary>
        /// Get the last stepping frequency from pedometer as float type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The last stepping frequency. </value>
        public float LastSteppingFrequency { get; private set; } = 0;

        /// <summary>
        /// Get the last step status from pedometer as enum <see cref="PedometerState"/> type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The last step status, <seealso cref="PedometerState"/>. </value>
        public PedometerState LastStepStatus { get; private set; } = PedometerState.Unknown;

        /// <summary>
        /// Return true or false based on whether the pedometer sensor is supported by the device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value><c>true</c> if supported; otherwise <c>false</c>.</value>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the Pedometer sensor is supported");
                return CheckIfSupported(SensorType.Pedometer, PedometerKey);
            }
        }

        /// <summary>
        /// Return the number of pedometer sensors available on the system.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The count of pedometer sensors. </value>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of pedometer sensors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="Tizen.Sensor.Pedometer"/> class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/healthinfo</privilege>
        /// <privlevel>public</privlevel>
        /// <feature>http://tizen.org/feature/sensor.pedometer</feature>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application has no privilege to use the sensor.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        /// <param name='index'>
        /// Index refers to a particular pedometer sensor in case of multiple sensors.
        /// Default value is 0.
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
        /// An event handler for storing the callback functions for the event corresponding to the change in the pedometer sensor data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Read pedometer sensor data synchronously.
        /// </summary>
        internal override void ReadData()
        {
            Interop.SensorEventStruct pedoSensorData;
            int error = Interop.SensorListener.ReadData(ListenerHandle, out pedoSensorData);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error reading pedometer sensor data");
                throw SensorErrorFactory.CheckAndThrowException(error, "Reading pedometer sensor data failed");
            }

            StepCount = (uint)pedoSensorData.values[0];
            WalkStepCount = (uint)pedoSensorData.values[1];
            RunStepCount = (uint)pedoSensorData.values[2];
            MovingDistance = pedoSensorData.values[3];
            CalorieBurned = pedoSensorData.values[4];
            LastSpeed = pedoSensorData.values[5];
            LastSteppingFrequency = pedoSensorData.values[6];
            LastStepStatus = (PedometerState)pedoSensorData.values[7];
        }

        private static Interop.SensorListener.SensorEventsCallback _callback;

        internal override void EventListenStart()
        {
            _callback = (IntPtr sensorHandle, IntPtr eventPtr, uint events_count, IntPtr data) => {
                updateBatchEvents(eventPtr, events_count);
                Interop.SensorEventStruct sensorData = latestEvent();

                Timestamp = sensorData.timestamp;
                StepCount = (uint)sensorData.values[0];
                WalkStepCount = (uint)sensorData.values[1];
                RunStepCount = (uint)sensorData.values[2];
                MovingDistance = sensorData.values[3];
                CalorieBurned = sensorData.values[4];
                LastSpeed = sensorData.values[5];
                LastSteppingFrequency = sensorData.values[6];
                LastStepStatus = (PedometerState)sensorData.values[7];

                DataUpdated?.Invoke(this, new PedometerDataUpdatedEventArgs(sensorData.values));
            };

            int error = Interop.SensorListener.SetEventsCallback(ListenerHandle, _callback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for pedometer sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for pedometer");
            }
        }

        internal override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventsCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for pedometer sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for pedometer");
            }
        }
    }
}
