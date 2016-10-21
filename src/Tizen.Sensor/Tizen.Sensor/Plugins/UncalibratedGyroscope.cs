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
    /// UncalibratedGyroscope Sensor Class. Used for registering callbacks for uncalibrated gyroscope and getting uncalibrated gyroscope data
    /// /// </summary>
    public class UncalibratedGyroscope : Sensor
    {
        private static string UncalibratedGyroscopeKey = "http://tizen.org/feature/sensor.gyroscope.uncalibrated";

        /// <summary>
        /// Gets the X component of the acceleration.
        /// </summary>
        public float X { get; private set; }

        /// <summary>
        /// Gets the Y component of the acceleration.
        /// </summary>
        public float Y { get; private set; }

        /// <summary>
        /// Gets the Z component of the acceleration.
        /// </summary>
        public float Z { get; private set; }

        /// <summary>
        /// Gets the BiasX component of the uncalibrated gyroscope data.
        /// </summary>
        public float BiasX { get; private set; }

        /// <summary>
        /// Gets the BiasY component of the uncalibrated gyroscope data.
        /// </summary>
        public float BiasY { get; private set; }

        /// <summary>
        /// Gets the BiasZ component of the uncalibrated gyroscope data.
        /// </summary>
        public float BiasZ { get; private set; }

        /// <summary>
        /// Returns true or false based on whether uncalibrated gyroscope sensor is supported by device.
        /// </summary>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the UncalibratedGyroscope sensor is supported");
                return CheckIfSupported(SensorType.UncalibratedGyroscope, UncalibratedGyroscopeKey);
            }
        }

        /// <summary>
        /// Returns the number of uncalibrated gyroscope sensors available on the device.
        /// </summary>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of uncalibrated gyroscope sensors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Sensor.UncalibratedGyroscope"/> class.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular uncalibrated gyroscope sensor in case of multiple sensors
        /// </param>
        public UncalibratedGyroscope(uint index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating UncalibratedGyroscope object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.UncalibratedGyroscope;
        }

        /// <summary>
        /// Event Handler for storing the callback functions for event corresponding to change in uncalibrated gyroscope sensor data.
        /// </summary>

        public event EventHandler<UncalibratedGyroscopeDataUpdatedEventArgs> DataUpdated;

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.UncalibratedGyroscope, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for uncalibrated gyroscope");
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
                Log.Error(Globals.LogTag, "Error setting event callback for uncalibrated gyroscope sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for uncalibrated gyroscope");
            }
        }

        protected override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for uncalibrated gyroscope sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for uncalibrated gyroscope");
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

            DataUpdated?.Invoke(this, new UncalibratedGyroscopeDataUpdatedEventArgs(sensorData.values));
        }
    }
}
