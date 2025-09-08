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
    /// The SleepMonitor class is used for registering callbacks for the sleep monitor and getting the sleep data.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class SleepMonitor : Sensor
    {
        private static string SleepMonitorKey = "http://tizen.org/feature/sensor.sleep_monitor";

        /// <summary>
        /// Get the value of the sleep state as enum <see cref="SleepMonitorState"/> type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The sleep state, <seealso cref="SleepMonitorState"/>. </value>
        public SleepMonitorState SleepState { get; private set; } = SleepMonitorState.Unknown;

        /// <summary>
        /// Return true or false based on whether the sleep monitor is supported by the device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value><c>true</c> if supported; otherwise <c>false</c>.</value>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the SleepMonitor is supported");
                return CheckIfSupported(SensorType.SleepMonitor, SleepMonitorKey);
            }
        }

        /// <summary>
        /// Return the number of sleep monitors available on the system.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The count of sleep monitors. </value>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of sleep monitors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="Tizen.Sensor.SleepMonitor"/> class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/healthinfo</privilege>
        /// <privlevel>public</privlevel>
        /// <feature>http://tizen.org/feature/sensor.sleep_monitor</feature>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application has no privilege to use the sensor.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        /// <param name='index'>
        /// Index refers to a particular sleep monitor in case of multiple sensors.
        /// Default value is 0.
        /// </param>
        public SleepMonitor(uint index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating SleepMonitor object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.SleepMonitor;
        }

        /// <summary>
        /// An event handler for storing the callback functions for the event corresponding to the change in the sleep monitor data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<SleepMonitorDataUpdatedEventArgs> DataUpdated;


        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.SleepMonitor, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for sleep");
                count = 0;
            }
            else
                Interop.Libc.Free(list);
            return count;
        }

        /// <summary>
        /// Read sleep monitor data synchronously.
        /// </summary>
        internal override void ReadData()
        {
            Interop.SensorEventStruct sensorData;
            int error = Interop.SensorListener.ReadData(ListenerHandle, out sensorData);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error reading sleep monitor data");
                throw SensorErrorFactory.CheckAndThrowException(error, "Reading sleep monitor data failed");
            }

            Timestamp = sensorData.timestamp;
            SleepState = (SleepMonitorState)sensorData.values[0];
        }

        private static Interop.SensorListener.SensorEventsCallback _callback;

        internal override void EventListenStart()
        {
            _callback = (IntPtr sensorHandle, IntPtr eventPtr, uint events_count, IntPtr data) => {
                updateBatchEvents(eventPtr, events_count);
                Interop.SensorEventStruct sensorData = latestEvent();

                Timestamp = sensorData.timestamp;
                SleepState = (SleepMonitorState)sensorData.values[0];

                DataUpdated?.Invoke(this, new SleepMonitorDataUpdatedEventArgs((int)sensorData.values[0]));
            };

            int error = Interop.SensorListener.SetEventsCallback(ListenerHandle, _callback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for sleep monitor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for sleep");
            }
        }

        internal override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventsCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for sleep monitor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for sleep");
            }
        }
    }
}
