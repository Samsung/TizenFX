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
    /// TemperatureSensor Class. Used for registering callbacks for temperature sensor and getting temperature data
    /// /// </summary>
    public class TemperatureSensor : Sensor
    {
        private static string TemperatureSensorKey = "http://tizen.org/feature/sensor.temperature";

        /// <summary>
        /// Gets the value of the temperature sensor.
        /// </summary>
        public float Temperature { get; private set; }

        /// <summary>
        /// Returns true or false based on whether temperature sensor is supported by device.
        /// </summary>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the TemperatureSensor is supported");
                return CheckIfSupported(SensorType.TemperatureSensor, TemperatureSensorKey);
            }
        }

        /// <summary>
        /// Returns the number of temperature sensors available on the device.
        /// </summary>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of temperature sensors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.System.Sensor.TemperatureSensor"/> class.
        /// </summary>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular temperature sensor in case of multiple sensors
        /// </param>
        public TemperatureSensor(int index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating TemperatureSensor object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.TemperatureSensor;
        }

        /// <summary>
        /// Event Handler for storing the callback functions for event corresponding to change in temperature sensor data.
        /// </summary>

        public event EventHandler<TemperatureSensorDataUpdatedEventArgs> DataUpdated;


        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.TemperatureSensor, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for temperature");
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
                Log.Error(Globals.LogTag, "Error setting event callback for temperature sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for temperature");
            }
        }

        protected override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for temperature sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for temperature");
            }
        }

        private void SensorEventCallback(IntPtr sensorHandle, IntPtr sensorPtr, IntPtr data)
        {
            Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(sensorPtr);
            TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
            Temperature = sensorData.values[0];

            DataUpdated?.Invoke(this, new TemperatureSensorDataUpdatedEventArgs(sensorData.values[0]));
        }
    }
}
