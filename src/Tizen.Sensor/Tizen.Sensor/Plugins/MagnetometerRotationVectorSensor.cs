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
    /// The MagnetometerRotationVectorSensor class is used for registering callbacks for the magnetometer rotation vector sensor and getting the magnetometer rotation vector data.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class MagnetometerRotationVectorSensor : Sensor
    {
        private static string MagnetometerRVKey = "http://tizen.org/feature/sensor.geomagnetic_rotation_vector";

        private event EventHandler<SensorAccuracyChangedEventArgs> _accuracyChanged;
        /// <summary>
        /// Gets the X component of the magnetometer rotation vector.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> X </value>
        public float X { get; private set; } = float.MinValue;

        /// <summary>
        /// Gets the Y component of the magnetometer rotation vector.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> Y </value>
        public float Y { get; private set; } = float.MinValue;

        /// <summary>
        /// Gets the Z component of the magnetometer rotation vector.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> Z </value>
        public float Z { get; private set; } = float.MinValue;

        /// <summary>
        /// Gets the W component of the magnetometer rotation vector.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> W </value>
        public float W { get; private set; } = float.MinValue;

        /// <summary>
        /// Gets the accuracy of the magnetometer rotation vector data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> Accuracy </value>
        public SensorDataAccuracy Accuracy { get; private set; }

        /// <summary>
        /// Returns true or false based on whether the magnetometer rotation vector sensor is supported by the device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value><c>true</c> if supported; otherwise <c>false</c>.</value>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the MagnetometerRotationVectorSensor is supported");
                return CheckIfSupported(SensorType.MagnetometerRotationVectorSensor, MagnetometerRVKey);
            }
        }

        /// <summary>
        /// Returns the number of magnetometer rotation vector sensors available on the device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The count of magnetometer rotation vector sensors. </value>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of magnetometer rotation vector sensors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Sensor.MagnetometerRotationVectorSensor"/> class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/sensor.geomagnetic_rotation_vector</feature>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular magnetometer rotation vector sensor in case of multiple sensors.
        /// </param>
        public MagnetometerRotationVectorSensor(uint index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating MagnetometerRotationVectorSensor object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.MagnetometerRotationVectorSensor;
        }

        /// <summary>
        /// An event handler for storing the callback functions for the event corresponding to the change in the magnetometer rotation vector sensor data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>

        public event EventHandler<MagnetometerRotationVectorSensorDataUpdatedEventArgs> DataUpdated;

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

        private static bool CheckIfSupported()
        {
            bool isSupported;
            int error = Interop.SensorManager.SensorIsSupported(SensorType.MagnetometerRotationVectorSensor, out isSupported);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error checking if magnetometer rotation vector sensor is supported");
                isSupported = false;
            }
            return isSupported;
        }

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.MagnetometerRotationVectorSensor, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for magnetometer rotation vector");
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
                X = sensorData.values[0];
                Y = sensorData.values[1];
                Z = sensorData.values[2];
                W = sensorData.values[3];
                Accuracy = sensorData.accuracy;

                DataUpdated?.Invoke(this, new MagnetometerRotationVectorSensorDataUpdatedEventArgs(sensorData.values, sensorData.accuracy));
            };

            int error = Interop.SensorListener.SetEventCallback(ListenerHandle, Interval, _callback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for magnetometer rotation vector sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for magnetometer rotation vector");
            }
        }

        internal override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for magnetometer rotation vector sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for magnetometer rotation vector");
            }
        }

        private static Interop.SensorListener.SensorAccuracyCallback _accuracyCallback;

        private void AccuracyListenStart()
        {
            _accuracyCallback = (IntPtr sensorHandle, UInt64 timestamp, SensorDataAccuracy accuracy, IntPtr data) => {
                TimeSpan = new TimeSpan((Int64)timestamp);
                Accuracy = accuracy;
                _accuracyChanged?.Invoke(this, new SensorAccuracyChangedEventArgs(new TimeSpan((Int64)timestamp), accuracy));
            };

            int error = Interop.SensorListener.SetAccuracyCallback(ListenerHandle, _accuracyCallback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting accuracy event callback for magnetometer rotation vector sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set accuracy event callback for magnetometer rotation vector");
            }
        }

        private void AccuracyListenStop()
        {
            int error = Interop.SensorListener.UnsetAccuracyCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting accuracy event callback for magnetometer rotation vector sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset accuracy event callback for magnetometer rotation vector");
            }
        }
    }
}
