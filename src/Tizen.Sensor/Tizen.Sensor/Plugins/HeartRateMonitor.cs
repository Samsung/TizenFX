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
    /// The HeartRateMonitor class is used for registering callbacks for the heart rate monitor and getting the heart rate data.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class HeartRateMonitor : Sensor
    {
        private const string HRMKey = "http://tizen.org/feature/sensor.heart_rate_monitor";

        /// <summary>
        /// Gets the value of the heart rate monitor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The heart rate. </value>
        public int HeartRate { get; private set; } = int.MinValue;

        /// <summary>
        /// Returns true or false based on whether the heart rate monitor is supported by the device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value><c>true</c> if supported; otherwise <c>false</c>.</value>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the HeartRateMonitor is supported");
                return CheckIfSupported(SensorType.HeartRateMonitor, HRMKey);
            }
        }

        /// <summary>
        /// Returns the number of heart rate monitors available on the device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The count of heart rate monitors. </value>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of heart rate monitors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Sensor.HeartRateMonitor"/> class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/healthinfo</privilege>
        /// <privlevel>public</privlevel>
        /// <feature>http://tizen.org/feature/sensor.heart_rate_monitor</feature>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application has no privilege to use the sensor.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular heart rate monitor in case of multiple sensors.
        /// </param>
        public HeartRateMonitor(uint index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating HeartRateMonitor object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.HeartRateMonitor;
        }

        /// <summary>
        /// An event handler for storing the callback functions for the event corresponding to the change in the heart rate monitor data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<HeartRateMonitorDataUpdatedEventArgs> DataUpdated;

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.HeartRateMonitor, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for heart rate");
                count = 0;
            }
            else
                Interop.Libc.Free(list);
            return count;
        }

        private void GetInitialData()
        {
            Interop.SensorEventStruct sensorData;
            int error = Interop.SensorListener.ReadData(ListenerHandle, out sensorData);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error reading heart rate monitor data");
                throw SensorErrorFactory.CheckAndThrowException(error, "Reading heart rate monitor data failed");
            }

            TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
            HeartRate = (int)sensorData.values[0];
        }

        private static Interop.SensorListener.SensorEventCallback _callback;

        internal override void EventListenStart()
        {
            _callback = (IntPtr sensorHandle, IntPtr eventPtr, IntPtr data) => {
                Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(eventPtr);

                TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
                HeartRate = (int)sensorData.values[0];

                DataUpdated?.Invoke(this, new HeartRateMonitorDataUpdatedEventArgs((int)sensorData.values[0]));
            };

            GetInitialData();

            int error = Interop.SensorListener.SetEventCallback(ListenerHandle, Interval, _callback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for heart rate monitor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for heart rate");
            }
        }

        internal override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for heart rate monitor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for heart rate");
            }
        }
    }
}
