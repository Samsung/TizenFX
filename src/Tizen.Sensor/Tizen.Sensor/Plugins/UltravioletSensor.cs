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
    /// UltravioletSensor Class. Used for registering callbacks for ultraviolet sensor and getting ultraviolet data
    /// /// </summary>
    public class UltravioletSensor : Sensor
    {
        private static string UltravioletSensorKey = "http://tizen.org/feature/sensor.ultraviolet";

        /// <summary>
        /// Gets the value of the ultraviolet sensor.
        /// </summary>
        public float UltravioletIndex { get; private set; }

        /// <summary>
        /// Returns true or false based on whether ultraviolet sensor is supported by device.
        /// </summary>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the UltravioletSensor is supported");
                return CheckIfSupported(SensorType.UltravioletSensor, UltravioletSensorKey);
            }
        }

        /// <summary>
        /// Returns the number of ultraviolet sensors available on the device.
        /// </summary>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of ultraviolet sensors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Sensor.UltravioletSensor"/> class.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular ultraviolet sensor in case of multiple sensors
        /// </param>
        public UltravioletSensor(uint index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating UltravioletSensor object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.UltravioletSensor;
        }

        /// <summary>
        /// Event Handler for storing the callback functions for event corresponding to change in ultraviolet sensor data.
        /// </summary>

        public event EventHandler<UltravioletSensorDataUpdatedEventArgs> DataUpdated;


        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.UltravioletSensor, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for ultraviolet");
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
                Log.Error(Globals.LogTag, "Error setting event callback for ultraviolet sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for ultraviolet");
            }
        }

        protected override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for ultraviolet sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for ultraviolet");
            }
        }

        private void SensorEventCallback(IntPtr sensorHandle, IntPtr sensorPtr, IntPtr data)
        {
            Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(sensorPtr);
            TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
            UltravioletIndex = sensorData.values[0];

            DataUpdated?.Invoke(this, new UltravioletSensorDataUpdatedEventArgs(sensorData.values[0]));
        }
    }
}
