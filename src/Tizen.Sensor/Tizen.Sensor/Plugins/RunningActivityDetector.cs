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
using System.Runtime.InteropServices;

namespace Tizen.Sensor
{
    /// <summary>
    /// The RunningActivityDetector class is used for registering callbacks for running the activity detector and getting the running state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class RunningActivityDetector : ActivityDetector
    {
        private static string ActivityDetectorKey = "http://tizen.org/feature/sensor.activity_recognition";

        /// <summary>
        /// Get the state of the running activity detector as enum <see cref="DetectorState"/> type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The running state, <seealso cref="DetectorState"/>. </value>
        public DetectorState Running { get; private set; } = DetectorState.Unknown;

        /// <summary>
        /// Return true or false based on whether the running activity detector is supported by the device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value><c>true</c> if supported; otherwise <c>false</c>.</value>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the running activity detector is supported");
                return CheckIfSupported(SensorType.RunningActivityDetector, ActivityDetectorKey);
            }
        }

        /// <summary>
        /// Return the number of running activity detectors available on the system.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The count of running activity detectors. </value>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of running activity detectors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="Tizen.Sensor.RunningActivityDetector"/> class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/sensor.activity_recognition</feature>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        /// <param name='index'>
        /// Index refers to a particular running activity detector in case of multiple sensors.
        /// Default value is 0.
        /// </param>
        public RunningActivityDetector(uint index = 0) : base(index)
        {
            SetAttribute((SensorAttribute)ActivityAttribute, (int)ActivityType.Running);
            Log.Info(Globals.LogTag, "Creating running activity detector object");
        }

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.RunningActivityDetector, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for running activity detector");
                count = 0;
            }
            else
                Marshal.FreeHGlobal(list);
            return count;
        }

        /// <summary>
        /// Read running activity detector data synchronously.
        /// </summary>
        internal override void ReadData()
        {
            Interop.SensorEventStruct sensorData;
            int error = Interop.SensorListener.ReadData(ListenerHandle, out sensorData);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error reading running activity detector data");
                throw SensorErrorFactory.CheckAndThrowException(error, "Reading running activity detector data failed");
            }

            Timestamp = sensorData.timestamp;
            Running = (DetectorState)sensorData.values[0];
            ActivityAccuracy = (SensorDataAccuracy)sensorData.accuracy;
        }

        /// <summary>
        /// An event handler for storing the callback functions for the event corresponding to the change in running the activity detector data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<RunningActivityDetectorDataUpdatedEventArgs> DataUpdated;

        private static Interop.SensorListener.SensorEventsCallback _callback;

        internal override void EventListenStart()
        {
            _callback = (IntPtr sensorHandle, IntPtr eventPtr, uint events_count, IntPtr data) => {
                updateBatchEvents(eventPtr, events_count);
                Interop.SensorEventStruct sensorData = latestEvent();

                Timestamp = sensorData.timestamp;
                Running = (DetectorState)sensorData.values[0];
                ActivityAccuracy = (SensorDataAccuracy) sensorData.accuracy;

                DataUpdated?.Invoke(this, new RunningActivityDetectorDataUpdatedEventArgs(sensorData.values[0]));
            };

            int error = Interop.SensorListener.SetEventsCallback(ListenerHandle, _callback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for running activity detector");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for running activity detector");
            }
        }

        internal override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventsCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for running activity detector");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for running activity detector");
            }
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.RunningActivityDetector;
        }
    }
}
