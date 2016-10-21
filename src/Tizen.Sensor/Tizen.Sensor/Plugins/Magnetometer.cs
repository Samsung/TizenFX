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
    /// Magnetometer Class. Used for registering callbacks for magnetometer and getting magnetometer data
    /// /// </summary>
    public class Magnetometer : Sensor
    {
        private static string MagnetometerKey = "http://tizen.org/feature/sensor.magnetometer";

        private event EventHandler<SensorAccuracyChangedEventArgs> _accuracyChanged;
        /// <summary>
        /// Gets the X component of the magnetometer.
        /// </summary>
        public float X { get; private set; }

        /// <summary>
        /// Gets the Y component of the magnetometer.
        /// </summary>
        public float Y { get; private set; }

        /// <summary>
        /// Gets the Z component of the magnetometer.
        /// </summary>
        public float Z { get; private set; }

        /// <summary>
        /// Returns true or false based on whether magnetometer is supported by device.
        /// </summary>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the Magnetometer is supported");
                return CheckIfSupported(SensorType.Magnetometer, MagnetometerKey);
            }
        }

        /// <summary>
        /// Returns the number of magnetometers available on the device.
        /// </summary>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of magnetometers");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Sensor.Magnetometer"/> class.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular magnetometer in case of multiple sensors
        /// </param>
        public Magnetometer(int index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating Magnetometer object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.Magnetometer;
        }

        /// <summary>
        /// Event Handler for storing the callback functions for event corresponding to change in magnetometer data.
        /// </summary>

        public event EventHandler<MagnetometerDataUpdatedEventArgs> DataUpdated;

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
            int error = Interop.SensorManager.GetSensorList(SensorType.Magnetometer, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for magnetometer");
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
                Log.Error(Globals.LogTag, "Error setting event callback for magnetometer");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for magnetometer");
            }
        }

        protected override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for magnetometer");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for magnetometer");
            }
        }

        private void AccuracyListenStart()
        {
            int error = Interop.SensorListener.SetAccuracyCallback(ListenerHandle, Interval, AccuracyEventCallback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting accuracy event callback for magnetometer");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set accuracy event callback for magnetometer");
            }
        }

        private void AccuracyListenStop()
        {
            int error = Interop.SensorListener.UnsetAccuracyCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting accuracy event callback for magnetometer");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset accuracy event callback for magnetometer");
            }
        }

        private void SensorEventCallback(IntPtr sensorHandle, IntPtr sensorPtr, IntPtr data)
        {
            Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(sensorPtr);
            TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
            X = sensorData.values[0];
            Y = sensorData.values[1];
            Z = sensorData.values[2];

            DataUpdated?.Invoke(this, new MagnetometerDataUpdatedEventArgs(sensorData.values));
        }

        private void AccuracyEventCallback(IntPtr sensorHandle, UInt64 timestamp, SensorDataAccuracy accuracy, IntPtr data)
        {
            TimeSpan = new TimeSpan((Int64)timestamp);
            _accuracyChanged?.Invoke(this, new SensorAccuracyChangedEventArgs(new TimeSpan((Int64)timestamp), accuracy));
        }
    }
}
