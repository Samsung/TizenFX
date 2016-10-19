// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;

namespace Tizen.Sensor
{
    /// <summary>
    /// MagnetometerRotationVectorSensor Class. Used for registering callbacks for magnetometer rotation vector sensor and getting magnetometer rotation vector data
    /// /// </summary>
    public class MagnetometerRotationVectorSensor : Sensor
    {
        private static string MagnetometerRVKey = "http://tizen.org/feature/sensor.geomagnetic_rotation_vector";

        private event EventHandler<SensorAccuracyChangedEventArgs> _accuracyChanged;
        /// <summary>
        /// Gets the X component of the magnetometer rotation vector.
        /// </summary>
        public float X { get; private set; }

        /// <summary>
        /// Gets the Y component of the magnetometer rotation vector.
        /// </summary>
        public float Y { get; private set; }

        /// <summary>
        /// Gets the Z component of the magnetometer rotation vector.
        /// </summary>
        public float Z { get; private set; }

        /// <summary>
        /// Gets the W component of the magnetometer rotation vector.
        /// </summary>
        public float W { get; private set; }

        /// <summary>
        /// Gets the Accuracy of the magnetometer rotation vector data.
        /// </summary>
        public SensorDataAccuracy Accuracy { get; private set; }

        /// <summary>
        /// Returns true or false based on whether magnetometer rotation vector sensor is supported by device.
        /// </summary>
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
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular magnetometer rotation vector sensor in case of multiple sensors
        /// </param>
        public MagnetometerRotationVectorSensor(int index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating MagnetometerRotationVectorSensor object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.MagnetometerRotationVectorSensor;
        }

        /// <summary>
        /// Event Handler for storing the callback functions for event corresponding to change in magnetometer rotation vector sensor data.
        /// </summary>

        public event EventHandler<MagnetometerRotationVectorSensorDataUpdatedEventArgs> DataUpdated;

        /// <summary>
        /// Event handler for accuracy changed events.
        /// </summary>
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

        protected override void EventListenStart()
        {
            int error = Interop.SensorListener.SetEventCallback(ListenerHandle, Interval, SensorEventCallback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for magnetometer rotation vector sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for magnetometer rotation vector");
            }
        }

        protected override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for magnetometer rotation vector sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for magnetometer rotation vector");
            }
        }

        private void AccuracyListenStart()
        {
            int error = Interop.SensorListener.SetAccuracyCallback(ListenerHandle, Interval, AccuracyEventCallback, IntPtr.Zero);
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

        private void SensorEventCallback(IntPtr sensorHandle, IntPtr sensorPtr, IntPtr data)
        {
            Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(sensorPtr);
            TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
            X = sensorData.values[0];
            Y = sensorData.values[1];
            Z = sensorData.values[2];
            Accuracy = sensorData.accuracy;

            DataUpdated?.Invoke(this, new MagnetometerRotationVectorSensorDataUpdatedEventArgs(sensorData.values, sensorData.accuracy));
        }

        private void AccuracyEventCallback(IntPtr sensorHandle, UInt64 timestamp, SensorDataAccuracy accuracy, IntPtr data)
        {
            TimeSpan = new TimeSpan((Int64)timestamp);
            Accuracy = accuracy;
            _accuracyChanged?.Invoke(this, new SensorAccuracyChangedEventArgs(new TimeSpan((Int64)timestamp), accuracy));
        }
    }
}
