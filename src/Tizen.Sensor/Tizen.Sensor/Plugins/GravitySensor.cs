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
    /// GravitySensor Class. Used for registering callbacks for gravity sensor and getting gravity data
    /// </summary>
    public class GravitySensor : Sensor
    {
        private const string GravitySensorKey = "http://tizen.org/feature/sensor.gravity";

        private event EventHandler<SensorAccuracyChangedEventArgs> _accuracyChanged;
        /// <summary>
        /// Gets the X component of the gravity.
        /// </summary>
        public float X { get; private set; }

        /// <summary>
        /// Gets the Y component of the gravity.
        /// </summary>
        public float Y { get; private set; }

        /// <summary>
        /// Gets the Z component of the gravity.
        /// </summary>
        public float Z { get; private set; }

        /// <summary>
        /// Returns true or false based on whether gravity sensor is supported by device.
        /// </summary>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the GravitySensor is supported");
                return CheckIfSupported(SensorType.GravitySensor, GravitySensorKey);
            }
        }

        /// <summary>
        /// Returns the number of gravity sensors available on the device.
        /// </summary>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of gravity sensors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Sensor.GravitySensor"/> class.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular gravity sensor in case of multiple sensors
        /// </param>
        public GravitySensor (uint index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating GravitySensor object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.GravitySensor;
        }

        /// <summary>
        /// Event Handler for storing the callback functions for event corresponding to change in gravity sensor data.
        /// </summary>

        public event EventHandler<GravitySensorDataUpdatedEventArgs> DataUpdated;

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
            int error = Interop.SensorManager.GetSensorList(SensorType.GravitySensor, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for gravity");
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
                Log.Error(Globals.LogTag, "Error setting event callback for gravity sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for gravity");
            }
        }

        protected override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for gravity sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for gravity");
            }
        }

        private void AccuracyListenStart()
        {
            int error = Interop.SensorListener.SetAccuracyCallback(ListenerHandle, Interval, AccuracyEventCallback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting accuracy event callback for gravity sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set accuracy event callback for gravity");
            }
        }

        private void AccuracyListenStop()
        {
            int error = Interop.SensorListener.UnsetAccuracyCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting accuracy event callback for gravity sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset accuracy event callback for gravity");
            }
        }

        private void SensorEventCallback(IntPtr sensorHandle, IntPtr sensorPtr, IntPtr data)
        {
            Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(sensorPtr);
            TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
            X = sensorData.values[0];
            Y = sensorData.values[1];
            Z = sensorData.values[2];

            DataUpdated?.Invoke(this, new GravitySensorDataUpdatedEventArgs(sensorData.values));
        }

        private void AccuracyEventCallback(IntPtr sensorHandle, UInt64 timestamp, SensorDataAccuracy accuracy, IntPtr data)
        {
            TimeSpan = new TimeSpan((Int64)timestamp);
            _accuracyChanged?.Invoke(this, new SensorAccuracyChangedEventArgs(new TimeSpan((Int64)timestamp), accuracy));
        }
    }
}
