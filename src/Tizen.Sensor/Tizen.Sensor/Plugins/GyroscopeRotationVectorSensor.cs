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
    /// GyroscopeRotationVectorSensor Class. Used for registering callbacks for gyroscope rotation vector sensor and getting gyroscope rotation vector data
    /// </summary>
    public class GyroscopeRotationVectorSensor : Sensor
    {
        private const string GyroscopeRVKey = "http://tizen.org/feature/sensor.gyroscope_rotation_vector";

        /// <summary>
        /// Gets the X component of the gyroscope rotation vector.
        /// </summary>
        public float X { get; private set; } = float.MinValue;

        /// <summary>
        /// Gets the Y component of the gyroscope rotation vector.
        /// </summary>
        public float Y { get; private set; } = float.MinValue;

        /// <summary>
        /// Gets the Z component of the gyroscope rotation vector.
        /// </summary>
        public float Z { get; private set; } = float.MinValue;

        /// <summary>
        /// Gets the W component of the gyroscope rotation vector.
        /// </summary>
        public float W { get; private set; } = float.MinValue;

        /// <summary>
        /// Gets the Accuracy of the gyroscope rotation vector data.
        /// </summary>
        public SensorDataAccuracy Accuracy { get; private set; }

        /// <summary>
        /// Returns true or false based on whether gyroscope rotation vector sensor is supported by device.
        /// </summary>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the GyroscopeRotationVectorSensor is supported");
                return CheckIfSupported(SensorType.GyroscopeRotationVectorSensor, GyroscopeRVKey);
            }
        }

        /// <summary>
        /// Returns the number of gyroscope rotation vector sensors available on the device.
        /// </summary>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of gyroscope rotation vector sensors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Sensor.GyroscopeRotationVectorSensor"/> class.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular gyroscope rotation vector sensor in case of multiple sensors
        /// </param>
        public GyroscopeRotationVectorSensor(uint index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating GyroscopeRotationVectorSensor object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.GyroscopeRotationVectorSensor;
        }

        /// <summary>
        /// Event Handler for storing the callback functions for event corresponding to change in gyroscope rotation vector sensor data.
        /// </summary>

        public event EventHandler<GyroscopeRotationVectorSensorDataUpdatedEventArgs> DataUpdated;

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.GyroscopeRotationVectorSensor, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for gyroscope rotation vector");
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
                Log.Error(Globals.LogTag, "Error setting event callback for gyroscope rotation vector sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for gyroscope rotation vector");
            }
        }

        protected override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for gyroscope rotation vector sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for gyroscope rotation vector");
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

            DataUpdated?.Invoke(this, new GyroscopeRotationVectorSensorDataUpdatedEventArgs(sensorData.values, sensorData.accuracy));
        }

    }
}
