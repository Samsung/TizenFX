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
    /// The SleepDetector class is used for registering callbacks for the sleep detector and getting the sleep data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public sealed class SleepDetector : Sensor
    {
        private static string SleepDetectorKey = "http://tizen.org/feature/sensor.sleep_monitor";

        /// <summary>
        /// Gets the value of the bed time.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The BedTime. </value>
        public float BedTime { get; private set; } = 0;

        /// <summary>
        /// Gets the value of the get up time.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The GetUpTime. </value>
        public float GetUpTime { get; private set; } = 0;

        /// <summary>
        /// Gets the value of the start time.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The start time. </value>
        public float StartTime { get; private set; } = 0;

        /// <summary>
        /// Gets the value of the delay time.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The delay time. </value>
        public float DelayTime { get; private set; } = 0;

        /// <summary>
        /// Returns true or false based on whether the sleep detector is supported by the device.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><c>true</c> if supported; otherwise <c>false</c>.</value>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the SleepDetector is supported");
                return CheckIfSupported(SensorType.SleepDetector, SleepDetectorKey);
            }
        }

        /// <summary>
        /// Returns the number of sleep detectors available on the device.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The count of sleep detector. </value>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of sleep detectors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Sensor.SleepDetector"/> class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/healthinfo</privilege>
        /// <privlevel>public</privlevel>
        /// <feature>http://tizen.org/feature/sensor.sleep_monitor</feature>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application has no privilege to use the sensor.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular sleep Detector in case of multiple sensors.
        /// </param>
        public SleepDetector(uint index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating SleepDetector object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.SleepDetector;
        }

        /// <summary>
        /// An event handler for storing the callback functions for the event corresponding to the change in the sleep monitor data.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>

        public event EventHandler<SleepDetectorDataUpdatedEventArgs> DataUpdated;


        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.SleepDetector, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for sleep");
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
                BedTime = sensorData.values[0];
                GetUpTime = sensorData.values[1];
                StartTime = sensorData.values[2];
                DelayTime = sensorData.values[3];

                DataUpdated?.Invoke(this, new SleepDetectorDataUpdatedEventArgs(sensorData.values));
            };

            int error = Interop.SensorListener.SetEventCallback(ListenerHandle, Interval, _callback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for sleep detector");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for sleep");
            }
        }

        internal override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for sleep detector");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for sleep");
            }
        }
    }
}
