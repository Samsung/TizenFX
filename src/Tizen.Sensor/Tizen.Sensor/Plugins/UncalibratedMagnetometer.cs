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
    /// The UncalibratedMagnetometer sensor class is used for registering callbacks for the uncalibrated magnetometer and getting the uncalibrated magnetometer data.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class UncalibratedMagnetometer : Sensor
    {
        private static string UncalibratedMagnetometerKey = "http://tizen.org/feature/sensor.magnetometer.uncalibrated";

        private event EventHandler<SensorAccuracyChangedEventArgs> _accuracyChanged;
        /// <summary>
        /// Gets the X component of the acceleration.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> X </value>
        public float X { get; private set; } = float.MinValue;

        /// <summary>
        /// Gets the Y component of the acceleration.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> Y </value>
        public float Y { get; private set; } = float.MinValue;

        /// <summary>
        /// Gets the Z component of the acceleration.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> Z </value>
        public float Z { get; private set; } = float.MinValue;

        /// <summary>
        /// Gets the BiasX component of the uncalibrated magnetometer data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The X bias. </value>
        public float BiasX { get; private set; } = 0;

        /// <summary>
        /// Gets the BiasY component of the uncalibrated magnetometer data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The Y bias. </value>
        public float BiasY { get; private set; } = 0;

        /// <summary>
        /// Gets the BiasZ component of the uncalibrated magnetometer data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The Z bias. </value>
        public float BiasZ { get; private set; } = 0;

        /// <summary>
        /// Returns true or false based on whether the uncalibrated magnetometer sensor is supported by the device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value><c>true</c> if supported; otherwise <c>false</c>.</value>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the UncalibratedMagnetometer sensor is supported");
                return CheckIfSupported(SensorType.UncalibratedMagnetometer, UncalibratedMagnetometerKey);
            }
        }

        /// <summary>
        /// Returns the number of uncalibrated magnetometer sensors available on the device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The count of uncalibrated magnetometer sensors. </value>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of uncalibrated magnetometer sensors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Sensor.UncalibratedMagnetometer"/> class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/sensor.magnetometer.uncalibrated</feature>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular uncalibrated magnetometer sensor in case of multiple sensors.
        /// </param>
        public UncalibratedMagnetometer(uint index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating UncalibratedMagnetometer object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.UncalibratedMagnetometer;
        }

        /// <summary>
        /// An event handler for storing the callback functions for the event corresponding to the change in the uncalibrated magnetometer sensor data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>

        public event EventHandler<UncalibratedMagnetometerDataUpdatedEventArgs> DataUpdated;

        /// <summary>
        /// An event handler for accuracy changed events.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
            int error = Interop.SensorManager.GetSensorList(SensorType.UncalibratedMagnetometer, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for uncalibrated magnetometer");
                count = 0;
            }
            else
                Interop.Libc.Free(list);
            return count;
        }

        private void GetInitialCount()
        {
            Interop.SensorEventStruct sensorData;
            int error = Interop.SensorListener.ReadData(ListenerHandle, out sensorData);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error reading uncalibrated magnetometer data");
                throw SensorErrorFactory.CheckAndThrowException(error, "Reading uncalibrated magnetometer data failed");
            }

            TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
            X = sensorData.values[0];
            Y = sensorData.values[1];
            Z = sensorData.values[2];
            BiasX = sensorData.values[3];
            BiasY = sensorData.values[4];
            BiasZ = sensorData.values[5];
        }

        private static Interop.SensorListener.SensorEventCallback _callback;

        internal override void EventListenStart()
        {
            _callback = (IntPtr sensorHandle, IntPtr eventPtr, IntPtr data) => {
                Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(eventPtr);

                TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
                X = sensorData.values[0];
                Y = sensorData.values[1];
                Z = sensorData.values[2];
                BiasX = sensorData.values[3];
                BiasY = sensorData.values[4];
                BiasZ = sensorData.values[5];

                DataUpdated?.Invoke(this, new UncalibratedMagnetometerDataUpdatedEventArgs(sensorData.values));
            };

            GetInitialCount();

            int error = Interop.SensorListener.SetEventCallback(ListenerHandle, Interval, _callback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for uncalibrated magnetometer sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for uncalibrated magnetometer");
            }
        }

        internal override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for uncalibrated magnetometer sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for uncalibrated magnetometer");
            }
        }

        private static Interop.SensorListener.SensorAccuracyCallback _accuracyCallback;

        private void AccuracyListenStart()
        {
            _accuracyCallback = (IntPtr sensorHandle, UInt64 timestamp, SensorDataAccuracy accuracy, IntPtr data) => {
                TimeSpan = new TimeSpan((Int64)timestamp);
                _accuracyChanged?.Invoke(this, new SensorAccuracyChangedEventArgs(new TimeSpan((Int64)timestamp), accuracy));
            };

            int error = Interop.SensorListener.SetAccuracyCallback(ListenerHandle, _accuracyCallback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting accuracy event callback for uncalibrated magnetometer");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set accuracy event callback for uncalibrated magnetometer");
            }
        }

        private void AccuracyListenStop()
        {
            int error = Interop.SensorListener.UnsetAccuracyCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting accuracy event callback for uncalibrated magnetometer");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset accuracy event callback for uncalibrated magnetometer");
            }
        }
    }
}
