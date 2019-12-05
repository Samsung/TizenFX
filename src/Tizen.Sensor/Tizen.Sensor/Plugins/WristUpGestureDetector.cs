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
    /// The WristUpGestureDetector class is used for registering callbacks for the wrist up gesture detector and getting the wrist up state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class WristUpGestureDetector : Sensor
    {
        private static string WristUpKey = "http://tizen.org/feature/sensor.wrist_up";

        /// <summary>
        /// Gets the state of the wrist up gesture.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The wrist up state. </value>
        public DetectorState WristUp { get; private set; } = DetectorState.Unknown;

        /// <summary>
        /// Returns true or false based on whether the wrist up gesture detector is supported by the device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value><c>true</c> if supported; otherwise <c>false</c>.</value>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the wrist up gesture detector is supported");
                return CheckIfSupported(SensorType.WristUpGestureDetector, WristUpKey);
            }
        }

        /// <summary>
        /// Returns the number of wrist up gesture detectors available on the device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The count of wrist up gesture detectors. </value>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of wrist up gesture detectors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Sensor.WristUpGestureDetector"/> class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/sensor.wrist_up</feature>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular wrist up gesture detector in case of multiple sensors.
        /// </param>
        public WristUpGestureDetector(uint index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating wrist up gesture detector object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.WristUpGestureDetector;
        }

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.WristUpGestureDetector, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for wrist up gesture detector");
                count = 0;
            }
            else
                Interop.Libc.Free(list);
            return count;
        }

        /// <summary>
        /// Read initial wrist up gesture detector data.
        /// </summary>
        protected override void ReadData()
        {
            Interop.SensorEventStruct sensorData;
            int error = Interop.SensorListener.ReadData(ListenerHandle, out sensorData);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error reading wrist up gesture detector data");
                throw SensorErrorFactory.CheckAndThrowException(error, "Reading wrist up gesture detector data failed");
            }

            TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
            WristUp = (DetectorState)sensorData.values[0];
        }

        /// <summary>
        /// An event handler for storing the callback functions for the event corresponding to the change in the wrist up gesture detector data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<WristUpGestureDetectorDataUpdatedEventArgs> DataUpdated;

        private static Interop.SensorListener.SensorEventCallback _callback;

        internal override void EventListenStart()
        {
            _callback = (IntPtr sensorHandle, IntPtr eventPtr, IntPtr data) => {
                Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(eventPtr);

                TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
                WristUp = (DetectorState) sensorData.values[0];

                DataUpdated?.Invoke(this, new WristUpGestureDetectorDataUpdatedEventArgs(sensorData.values[0]));
            };

            int error = Interop.SensorListener.SetEventCallback(ListenerHandle, Interval, _callback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for wrist up gesture detector");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for wrist up gesture detector");
            }
        }

        internal override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for wrist up gesture detector");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for wrist up gesture detector");
            }
        }
    }
}
