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
    /// HumiditySensor Class. Used for registering callbacks for humidity sensor and getting humidity data
    /// /// </summary>
    public class HumiditySensor : Sensor
    {
        private const string HumiditySensorKey = "http://tizen.org/feature/sensor.humidity";

        /// <summary>
        /// Gets the value of the humidity sensor.
        /// </summary>
        public float Humidity { get; private set; }

        /// <summary>
        /// Returns true or false based on whether humidity sensor is supported by device.
        /// </summary>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the HumiditySensor is supported");
                return CheckIfSupported(SensorType.HumiditySensor, HumiditySensorKey);
            }
        }

        /// <summary>
        /// Returns the number of humidity sensors available on the device.
        /// </summary>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of humidity sensors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Sensor.HumiditySensor"/> class.
        /// </summary>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular humidity sensor in case of multiple sensors
        /// </param>
        public HumiditySensor(int index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating HumiditySensor object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.HumiditySensor;
        }

        /// <summary>
        /// Event Handler for storing the callback functions for event corresponding to change in humidity sensor data.
        /// </summary>

        public event EventHandler<HumiditySensorDataUpdatedEventArgs> DataUpdated;

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.HumiditySensor, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for humidity");
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
                Log.Error(Globals.LogTag, "Error setting event callback for humidity sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for humidity");
            }
        }

        protected override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for humidity sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for humidity");
            }
        }

        private void SensorEventCallback(IntPtr sensorHandle, IntPtr sensorPtr, IntPtr data)
        {
            Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(sensorPtr);
            TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
            Humidity = sensorData.values[0];

            DataUpdated?.Invoke(this, new HumiditySensorDataUpdatedEventArgs(sensorData.values[0]));
        }
    }
}
