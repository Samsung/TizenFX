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
    /// Gyroscope Sensor Class. Used for registering callbacks for gyroscope and getting gyroscope data
    /// /// </summary>
    public class Gyroscope : Sensor
    {
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
        /// Returns true or false based on whether gyroscope sensor is supported by device.
        /// </summary>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the Gyroscope sensor is supported");
                return CheckIfSupported();
            }
        }

        /// <summary>
        /// Returns the number of gyroscope sensors available on the device.
        /// </summary>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of gyroscope sensors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.System.Sensor.Gyroscope"/> class.
        /// </summary>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular gyroscope sensor in case of multiple sensors
        /// </param>
        public Gyroscope(int index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating Gyroscope object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.Gyroscope;
        }

        /// <summary>
        /// Event Handler for storing the callback functions for event corresponding to change in gyroscope sensor data.
        /// </summary>

        public event EventHandler<GyroscopeDataUpdatedEventArgs> DataUpdated;

        private static bool CheckIfSupported()
        {
            bool isSupported;
            int error = Interop.SensorManager.SensorIsSupported(SensorType.Gyroscope, out isSupported);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error checking if gyroscope sensor is supported");
                isSupported = false;
            }
            return isSupported;
        }

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.Gyroscope, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for gyroscope");
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
                Log.Error(Globals.LogTag, "Error setting event callback for gyroscope sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for gyroscope");
            }
        }

        protected override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for gyroscope sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for gyroscope");
            }
        }

        private void SensorEventCallback(IntPtr sensorHandle, IntPtr sensorPtr, IntPtr data)
        {
            Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(sensorPtr);
            TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
            X = sensorData.values[0];
            Y = sensorData.values[1];
            Z = sensorData.values[2];

            DataUpdated?.Invoke(this, new GyroscopeDataUpdatedEventArgs(sensorData.values));
        }
    }
}
