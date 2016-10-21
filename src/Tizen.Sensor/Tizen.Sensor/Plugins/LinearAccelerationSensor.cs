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
    /// LinearAccelerationSensor Class. Used for registering callbacks for linear acceleration sensor and getting linear acceleration data
    /// /// </summary>
    public class LinearAccelerationSensor : Sensor
    {
        private const string LinearAccelerationSensorKey = "http://tizen.org/feature/sensor.linear_acceleration";

        private event EventHandler<SensorAccuracyChangedEventArgs> _accuracyChanged;
        /// <summary>
        /// Gets the X component of the linear acceleration.
        /// </summary>
        public float X { get; private set; }

        /// <summary>
        /// Gets the Y component of the linear acceleration.
        /// </summary>
        public float Y { get; private set; }

        /// <summary>
        /// Gets the Z component of the linear acceleration.
        /// </summary>
        public float Z { get; private set; }

        /// <summary>
        /// Returns true or false based on whether linear acceleration sensor is supported by device.
        /// </summary>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the LinearAccelerationSensor is supported");
                return CheckIfSupported(SensorType.LinearAccelerationSensor, LinearAccelerationSensorKey);
            }
        }

        /// <summary>
        /// Returns the number of linear acceleration sensors available on the device.
        /// </summary>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of linear acceleration sensors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Sensor.LinearAccelerationSensor"/> class.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular linear acceleration sensor in case of multiple sensors
        /// </param>
        public LinearAccelerationSensor(uint index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating LinearAccelerationSensor object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.LinearAccelerationSensor;
        }

        /// <summary>
        /// Event Handler for storing the callback functions for event corresponding to change in linear acceleration sensor data.
        /// </summary>

        public event EventHandler<LinearAccelerationSensorDataUpdatedEventArgs> DataUpdated;

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
            int error = Interop.SensorManager.GetSensorList(SensorType.LinearAccelerationSensor, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for linear acceleration sensor");
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
                Log.Error(Globals.LogTag, "Error setting event callback for linear acceleration sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for linear acceleration sensor");
            }
        }

        protected override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for linear acceleration sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for linear acceleration");
            }
        }

        private void AccuracyListenStart()
        {
            int error = Interop.SensorListener.SetAccuracyCallback(ListenerHandle, Interval, AccuracyEventCallback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting accuracy event callback for linear acceleration sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set accuracy event callback for linear acceleration sensor");
            }
        }

        private void AccuracyListenStop()
        {
            int error = Interop.SensorListener.UnsetAccuracyCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting accuracy event callback for linear acceleration sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset accuracy event callback for linear acceleration sensor");
            }
        }

        private void SensorEventCallback(IntPtr sensorHandle, IntPtr sensorPtr, IntPtr data)
        {
            Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(sensorPtr);
            TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
            X = sensorData.values[0];
            Y = sensorData.values[1];
            Z = sensorData.values[2];

            DataUpdated?.Invoke(this, new LinearAccelerationSensorDataUpdatedEventArgs(sensorData.values));
        }

        private void AccuracyEventCallback(IntPtr sensorHandle, UInt64 timestamp, SensorDataAccuracy accuracy, IntPtr data)
        {
            TimeSpan = new TimeSpan((Int64)timestamp);
            _accuracyChanged?.Invoke(this, new SensorAccuracyChangedEventArgs(new TimeSpan((Int64)timestamp), accuracy));
        }
    }
}
