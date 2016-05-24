// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;

namespace Tizen.System.Sensor
{
    /// <summary>
    /// Accelerometer Sensor Class. Used for registering callbacks for accelerometer and getting accelerometer data
    /// /// </summary>
    public class Accelerometer : Sensor
    {
        private uint _defaultInterval = 0;

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
        /// Returns true or false based on whether accelerometer sensor is supported by device.
        /// </summary>
        public static bool IsSupported
        {
            get
            {
                return CheckIfSupported();
            }
        }

        /// <summary>
        /// Returns the number of accelerometer sensors available on the device.
        /// </summary>
        public static int Count
        {
            get
            {
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.System.Sensor.Accelerometer"/> class.
        /// </summary>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular accelerometer sensor in case of multiple sensors
        /// </param>
        public Accelerometer(int index = 0) : base(index)
        {
            Interval = _defaultInterval;
        }

        protected override SensorType GetSensorType()
        {
            return SensorType.Accelerometer;
        }

        /// <summary>
        /// Event Handler for storing the callback functions for event corresponding to change in accelerometer sensor data.
        /// </summary>

        public event EventHandler<AccelerometerChangedEventArgs> DataUpdated;

        private static bool CheckIfSupported()
        {
            bool isSupported;
            int error = Interop.SensorManager.SensorIsSupported(SensorType.Accelerometer, out isSupported);
            if (error != 0)
                isSupported = false;
            return isSupported;
        }

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.Accelerometer, out list, out count);
            if (error != 0)
                count = 0;
            else
                Interop.Libc.Free(list);
            return count;
        }

        protected override void EventListenStart()
        {
            int error = Interop.SensorListener.SetEventCallback(ListenerHandle, Interval, SensorEventCallback, IntPtr.Zero);
            if (error != 0)
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for accelerometer");
        }

        protected override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != 0)
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for accelerometer");
        }

        private void SensorEventCallback(IntPtr sensorHandle, IntPtr sensorPtr, IntPtr data)
        {
            Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(sensorPtr);
            Timestamp = sensorData.timestamp;
            X = sensorData.values[0];
            Y = sensorData.values[1];
            Z = sensorData.values[2];

            DataUpdated?.Invoke(this, new AccelerometerChangedEventArgs(sensorData.values));
        }
    }
}