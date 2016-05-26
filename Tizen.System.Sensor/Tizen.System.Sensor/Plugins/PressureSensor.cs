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
    /// PressureSensor Class. Used for registering callbacks for pressure sensor and getting pressure data
    /// /// </summary>
    public class PressureSensor : Sensor
    {
        /// <summary>
        /// Gets the value of the pressure sensor.
        /// </summary>
        public float Pressure { get; private set; }

        /// <summary>
        /// Returns true or false based on whether pressure sensor is supported by device.
        /// </summary>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the PressureSensor is supported");
                return CheckIfSupported();
            }
        }

        /// <summary>
        /// Returns the number of pressure sensors available on the device.
        /// </summary>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of pressure sensors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.System.Sensor.PressureSensor"/> class.
        /// </summary>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular pressure sensor in case of multiple sensors
        /// </param>
        public PressureSensor(int index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating PressureSensor object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.PressureSensor;
        }

        /// <summary>
        /// Event Handler for storing the callback functions for event corresponding to change in pressure sensor data.
        /// </summary>

        public event EventHandler<PressureSensorDataUpdatedEventArgs> DataUpdated;

        private static bool CheckIfSupported()
        {
            bool isSupported;
            int error = Interop.SensorManager.SensorIsSupported(SensorType.PressureSensor, out isSupported);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error checking if pressure sensor is supported");
                isSupported = false;
            }
            return isSupported;
        }

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.PressureSensor, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for pressure");
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
                Log.Error(Globals.LogTag, "Error setting event callback for pressure sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for pressure");
            }
        }

        protected override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for pressure sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for pressure");
            }
        }

        private void SensorEventCallback(IntPtr sensorHandle, IntPtr sensorPtr, IntPtr data)
        {
            Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(sensorPtr);
            TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
            Pressure = sensorData.values[0];

            DataUpdated?.Invoke(this, new PressureSensorDataUpdatedEventArgs(sensorData.values[0]));
        }
    }
}
