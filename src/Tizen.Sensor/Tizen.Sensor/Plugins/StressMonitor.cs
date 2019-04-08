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
    /// The StressMonitor class is used for registering callbacks for the Stress monitor and getting the Stress data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class StressMonitor : Sensor
    {
        private static string StressMonitorKey = "http://tizen.org/feature/sensor.stress_monitor";

        /// <summary>
        /// Returns true or false based on whether the stress monitor is supported by the device.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><c>true</c> if supported; otherwise <c>false</c>.</value>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the StressMonitor is supported");
                return CheckIfSupported(SensorType.StressMonitor, StressMonitorKey);
            }
        }

        /// <summary>
        /// Returns the number of stress monitors available on the device.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The count of stress monitors. </value>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of stress monitors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Sensor.StressMonitor"/> class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/healthinfo</privilege>
        /// <privlevel>public</privlevel>
        /// <feature>http://tizen.org/feature/sensor.stress_monitor</feature>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application has no privilege to use the sensor.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular stress monitor in case of multiple sensors.
        /// </param>
        public StressMonitor(uint index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating StressMonitor object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.StressMonitor;
        }

        /// <summary>
        /// An event handler for storing the callback functions for the event corresponding to the change in the stress monitor data.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>

        public event EventHandler<StressMonitorDataUpdatedEventArgs> DataUpdated;


        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.StressMonitor, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for stress");
                count = 0;
            }
            else
                Interop.Libc.Free(list);
            return count;
        }

        private static Interop.SensorListener.SensorEventCallback _callback;

        internal override void EventListenStart()
        {
            _callback = (IntPtr sensorHandle, IntPtr eventPtr, IntPtr data) =>
            {
                DataUpdated?.Invoke(this, new StressMonitorDataUpdatedEventArgs(eventPtr));
            };

            int error = Interop.SensorListener.SetEventCallback(ListenerHandle, Interval, _callback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for stress monitor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for stress");
            }
        }

        internal override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for stress monitor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for stress");
            }
        }
    }
}
