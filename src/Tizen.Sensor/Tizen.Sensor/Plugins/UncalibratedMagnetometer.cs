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
    /// UncalibratedMagnetometer Sensor Class. Used for registering callbacks for uncalibrated magnetometer and getting uncalibrated magnetometer data
    /// /// </summary>
    public sealed class UncalibratedMagnetometer : Sensor
    {
        private static string UncalibratedMagnetometerKey = "http://tizen.org/feature/sensor.magnetometer.uncalibrated";

        private event EventHandler<SensorAccuracyChangedEventArgs> _accuracyChanged;
        /// <summary>
        /// Gets the X component of the acceleration.
        /// </summary>
        public float X { get; private set; } = float.MinValue;

        /// <summary>
        /// Gets the Y component of the acceleration.
        /// </summary>
        public float Y { get; private set; } = float.MinValue;

        /// <summary>
        /// Gets the Z component of the acceleration.
        /// </summary>
        public float Z { get; private set; } = float.MinValue;

        /// <summary>
        /// Gets the BiasX component of the uncalibrated magnetometer data.
        /// </summary>
        public float BiasX { get; private set; } = 0;

        /// <summary>
        /// Gets the BiasY component of the uncalibrated magnetometer data.
        /// </summary>
        public float BiasY { get; private set; } = 0;

        /// <summary>
        /// Gets the BiasZ component of the uncalibrated magnetometer data.
        /// </summary>
        public float BiasZ { get; private set; } = 0;

        /// <summary>
        /// Returns true or false based on whether uncalibrated magnetometer sensor is supported by device.
        /// </summary>
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
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular uncalibrated magnetometer sensor in case of multiple sensors
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
        /// Event Handler for storing the callback functions for event corresponding to change in uncalibrated magnetometer sensor data.
        /// </summary>

        public event EventHandler<UncalibratedMagnetometerDataUpdatedEventArgs> DataUpdated;

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

        protected internal override void EventListenStart()
        {
            int error = Interop.SensorListener.SetEventCallback(ListenerHandle, Interval, SensorEventCallback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for uncalibrated magnetometer sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for uncalibrated magnetometer");
            }
        }

        protected internal override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for uncalibrated magnetometer sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for uncalibrated magnetometer");
            }
        }

        private void AccuracyListenStart()
        {
            int error = Interop.SensorListener.SetAccuracyCallback(ListenerHandle, Interval, AccuracyEventCallback, IntPtr.Zero);
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

        private void SensorEventCallback(IntPtr sensorHandle, IntPtr sensorPtr, IntPtr data)
        {
            Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(sensorPtr);
            TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
            X = sensorData.values[0];
            Y = sensorData.values[1];
            Z = sensorData.values[2];
            BiasX = sensorData.values[3];
            BiasY = sensorData.values[4];
            BiasZ = sensorData.values[5];

            DataUpdated?.Invoke(this, new UncalibratedMagnetometerDataUpdatedEventArgs(sensorData.values));
        }

        private void AccuracyEventCallback(IntPtr sensorHandle, UInt64 timestamp, SensorDataAccuracy accuracy, IntPtr data)
        {
            TimeSpan = new TimeSpan((Int64)timestamp);
            _accuracyChanged?.Invoke(this, new SensorAccuracyChangedEventArgs(new TimeSpan((Int64)timestamp), accuracy));
        }
    }
}
