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
    /// The HeartRateMonitorLedGreen class is used for registering callbacks for the heart rate monitor and getting the heart rate data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public sealed class HeartRateMonitorLedGreen : Sensor
    {
        private const string HrmGreenKey = "http://tizen.org/feature/sensor.heart_rate_monitor.led_green";

        /// <summary>
        /// Gets the green light value of the heart rate monitor.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> Hrm Green Light Value. </value>
        public int HrmGreenLightValue { get; private set; } = int.MinValue;

        /// <summary>
        /// Returns true or false based on whether the heart rate monitor Led Green is supported by the device.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><c>true</c> if supported; otherwise <c>false</c>.</value>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the HeartRateMonitor Led Green is supported");
                return CheckIfSupported(SensorType.HeartRateMonitorLedGreen, HrmGreenKey);
            }
        }

        /// <summary>
        /// Returns the number of Led Green heart rate monitors available on the device.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The count of Led Green heart rate monitors. </value>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of Led Green heart rate monitors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Sensor.HeartRateMonitorLedGreen"/> class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/healthinfo</privilege>
        /// <privlevel>public</privlevel>
        /// <feature>http://tizen.org/feature/sensor.heart_rate_monitor.led_green</feature>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application has no privilege to use the sensor.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular Led Green heart rate monitor in case of multiple sensors.
        /// </param>
        public HeartRateMonitorLedGreen(uint index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating HeartRateMonitorLedGreen object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.HeartRateMonitorLedGreen;
        }

        /// <summary>
        /// An event handler for storing the callback functions for the event corresponding to the change in the heart rate monitor data.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<HeartRateMonitorDataUpdatedEventArgs> DataUpdated;

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.HeartRateMonitorLedGreen, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for heart rate monitor Led Green");
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
                HrmGreenLightValue = (int)sensorData.values[0];

                DataUpdated?.Invoke(this, new HeartRateMonitorDataUpdatedEventArgs((int)sensorData.values[0]));
            };

            int error = Interop.SensorListener.SetEventCallback(ListenerHandle, Interval, _callback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for Led Green heart rate monitor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for heart rate");
            }
        }

        internal override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for Led Green heart rate monitor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for heart rate");
            }
        }
    }
}
