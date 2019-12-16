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
    /// The PickUpGestureDetector class is used for registering callbacks for the pick up activity detector and getting the pick up state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class PickUpGestureDetector : Sensor
    {
        private static string GestureDetectorKey = "http://tizen.org/feature/sensor.gesture_recognition";

        /// <summary>
        /// Gets the state of the pick up gesture.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The pick up state. </value>
        public DetectorState PickUp { get; private set; } = DetectorState.Unknown;

        /// <summary>
        /// Returns true or false based on whether the pick up gesture detector is supported by the device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value><c>true</c> if supported; otherwise <c>false</c>.</value>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the pick up gesture detector is supported");
                return CheckIfSupported(SensorType.PickUpGestureDetector, GestureDetectorKey);
            }
        }

        /// <summary>
        /// Returns the number of pick up gesture detectors available on the device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The count of pick up gesture detectors. </value>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of pick up gesture detectors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Sensor.PickUpGestureDetector"/> class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/sensor.gesture_recognition</feature>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular pick up gesture detector in case of multiple sensors.
        /// </param>
        public PickUpGestureDetector(uint index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating pick up gesture detector object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.PickUpGestureDetector;
        }

        private static bool CheckIfSupported()
        {
            bool isSupported;
            int error = Interop.SensorManager.SensorIsSupported(SensorType.PickUpGestureDetector, out isSupported);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error checking if pick up gesture detector is supported");
                isSupported = false;
            }
            return isSupported;
        }

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.PickUpGestureDetector, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for pick up gesture detector");
                count = 0;
            }
            else
                Interop.Libc.Free(list);
            return count;
        }

        /// <summary>
        /// Read pick up gesture detector data synchronously.
        /// </summary>
        internal override void ReadData()
        {
            Interop.SensorEventStruct sensorData;
            int error = Interop.SensorListener.ReadData(ListenerHandle, out sensorData);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error reading pick up gesture detector data");
                throw SensorErrorFactory.CheckAndThrowException(error, "Reading pick up gesture detector data failed");
            }

            TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
            PickUp = (DetectorState)sensorData.values[0];
        }

        /// <summary>
        /// An event handler for storing the callback functions for the event corresponding to the change in the pick up gesture detector data.	
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<PickUpGestureDetectorDataUpdatedEventArgs> DataUpdated;

        private static Interop.SensorListener.SensorEventCallback _callback;

        internal override void EventListenStart()
        {
            _callback = (IntPtr sensorHandle, IntPtr eventPtr, IntPtr data) => {
                Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(eventPtr);

                TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
                PickUp = (DetectorState) sensorData.values[0];

                DataUpdated?.Invoke(this, new PickUpGestureDetectorDataUpdatedEventArgs(sensorData.values[0]));
            };

            int error = Interop.SensorListener.SetEventCallback(ListenerHandle, Interval, _callback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for pick up gesture detector");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for pick up gesture detector");
            }
        }

        internal override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for pick up gesture detector");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for pick up gesture detector");
            }
        }
    }
}
