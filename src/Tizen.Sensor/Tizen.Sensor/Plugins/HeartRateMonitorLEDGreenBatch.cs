/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.Sensor
{
    /// <summary>
    /// The HeartRateMonitorLEDGreenBatch class registers callbacks for the HRMLEDGreen batch and provides batch data of HRMLEDGreen batch.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public sealed class HeartRateMonitorLEDGreenBatch : BatchSensor<HeartRateMonitorLEDGreenBatchData>
    {
        private static string HRMLEDGreenBatchKey = "http://tizen.org/feature/sensor.heart_rate_monitor.led_green.batch";

        private event EventHandler<SensorAccuracyChangedEventArgs> _accuracyChanged;

        /// <summary>
        /// List of converted HeartRateMonitorLEDGreenBatchData.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        protected override IReadOnlyList<HeartRateMonitorLEDGreenBatchData> ConvertBatchData()
        {
            List<HeartRateMonitorLEDGreenBatchData> list = new List<HeartRateMonitorLEDGreenBatchData>();
            Interop.SensorEventStruct sensorData;
            for (int i = 0; i < BatchedEvents.Count; i++)
            {
                sensorData = BatchedEvents[i];
                list.Add(new HeartRateMonitorLEDGreenBatchData(sensorData.timestamp, sensorData.accuracy, (uint)sensorData.values[0], (int)sensorData.values[1], (int)sensorData.values[2], (int)sensorData.values[3], (uint)sensorData.values[4]));
            }
            return list.AsReadOnly(); ;
        }

        /// <summary>
        /// Gets the accuracy of the auto HeartRateMonitorLEDGreenBatch data.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <value> Accuracy </value>
        public SensorDataAccuracy Accuracy { get; private set; } = SensorDataAccuracy.Undefined;

        /// <summary>
        /// Returns true or false based on whether the HeartRateMonitorLEDGreenBatch sensor is supported by the device.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <value><c>true</c> if supported; otherwise <c>false</c>.</value>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the HeartRateMonitorLEDGreenBatch is supported");
                return CheckIfSupported(SensorType.HRMLEDGreenBatch, HRMLEDGreenBatchKey);
            }
        }

        /// <summary>
        /// Returns the number of HeartRateMonitorLEDGreenBatch sensors available on the device.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <value> The count of HeartRateMonitorLEDGreenBatch sensors. </value>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of accelerometer sensors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Sensor.HeartRateMonitorLEDGreenBatch"/> class.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <privilege>http://tizen.org/privilege/healthinfo</privilege>
        /// <privlevel>public</privlevel>
        /// <feature>http://tizen.org/feature/sensor.heart_rate_monitor.led_green.batch</feature>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application has no privilege to use the sensor.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular HeartRateMonitorLEDGreenBatch sensor in case of multiple sensors.
        /// </param>
        public HeartRateMonitorLEDGreenBatch(uint index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating HeartRateMonitorLEDGreenBatch object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.HRMLEDGreenBatch;
        }

        /// <summary>
        /// An event handler for storing the callback functions for the event corresponding to the change in the HeartRateMonitorLEDGreenBatch sensor data.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>

        public event EventHandler<HeartRateMonitorLEDGreenBatchDataUpdatedEventArgs> DataUpdated;

        /// <summary>
        /// An event handler for accuracy changed events.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public event EventHandler<SensorAccuracyChangedEventArgs> AccuracyChanged
        {
            add
            {
                if (_accuracyChanged == null)
                {
                    AccuracyListenStart();
                }
                _accuracyChanged += value;
            }
            remove
            {
                _accuracyChanged -= value;
                if (_accuracyChanged == null)
                {
                    AccuracyListenStop();
                }
            }
        }

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.HRMLEDGreenBatch, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for HeartRateMonitorLEDGreenBatch");
                count = 0;
            }
            else
                Interop.Libc.Free(list);
            return count;
        }

        /// <summary>
        /// Reads HeartRateMonitorLEDGreenBatch data synchronously.
        /// </summary>
        internal override void ReadData()
        {
            int error = Interop.SensorListener.ReadDataList(ListenerHandle, out IntPtr eventsPtr, out uint events_count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error reading HeartRateMonitorLEDGreenBatch data");
                throw SensorErrorFactory.CheckAndThrowException(error, "Reading HeartRateMonitorBatch data failed");
            }
            UpdateBatchData(eventsPtr, events_count);
            Interop.SensorEventStruct sensorData = latestEvent();
            Timestamp = sensorData.timestamp;
            Accuracy = sensorData.accuracy;
            Interop.Libc.Free(eventsPtr);
        }

        private static Interop.SensorListener.SensorEventsCallback _callback;

        internal override void EventListenStart()
        {
            _callback = (IntPtr sensorHandle, IntPtr eventsPtr, uint events_count, IntPtr data) =>
            {
                UpdateBatchData(eventsPtr, events_count);
                Interop.SensorEventStruct sensorData = latestEvent();
                Timestamp = (ulong)DateTimeOffset.Now.ToUnixTimeMilliseconds();
                Accuracy = sensorData.accuracy;
                DataUpdated?.Invoke(this, new HeartRateMonitorLEDGreenBatchDataUpdatedEventArgs((IReadOnlyList<HeartRateMonitorLEDGreenBatchData>)Data));

            };

            int error = Interop.SensorListener.SetEventsCallback(ListenerHandle, _callback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for HeartRateMonitorLEDGreenBatch sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for HeartRateMonitorLEDGreenBatch");
            }
        }

        internal override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventsCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for HeartRateMonitorLEDGreenBatch sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for HeartRateMonitorLEDGreenBatch");
            }
        }

        private static Interop.SensorListener.SensorAccuracyCallback _accuracyCallback;

        private void AccuracyListenStart()
        {
            _accuracyCallback = (IntPtr sensorHandle, UInt64 timestamp, SensorDataAccuracy accuracy, IntPtr data) =>
            {
                Timestamp = timestamp;
                Accuracy = accuracy;
                _accuracyChanged?.Invoke(this, new SensorAccuracyChangedEventArgs(timestamp, accuracy));
            };

            int error = Interop.SensorListener.SetAccuracyCallback(ListenerHandle, _accuracyCallback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting accuracy event callback for HeartRateMonitorLEDGreenBatch sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set accuracy event callback for HeartRateMonitorLEDGreenBatch");
            }
        }

        private void AccuracyListenStop()
        {
            int error = Interop.SensorListener.UnsetAccuracyCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting accuracy event callback for HeartRateMonitorLEDGreenBatch sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset accuracy event callback for HeartRateMonitorLEDGreenBatch");
            }
        }
    }
}
