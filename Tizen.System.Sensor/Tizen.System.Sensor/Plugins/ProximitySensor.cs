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
    /// ProximitySensor Class. Used for registering callbacks for proximity sensor and getting proximity data
    /// /// </summary>
    public class ProximitySensor : Sensor
    {
        private static string ProximitySensorKey = "http://tizen.org/feature/sensor.proximity";

        /// <summary>
        /// Gets the proximity state.
        /// </summary>
        public ProximitySensorState Proximity { get; private set; }

        /// <summary>
        /// Returns true or false based on whether proximity sensor is supported by device.
        /// </summary>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the ProximitySensor is supported");
                return CheckIfSupported(SensorType.ProximitySensor, ProximitySensorKey);
            }
        }

        /// <summary>
        /// Returns the number of proximity sensors available on the device.
        /// </summary>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of proximity sensors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.System.Sensor.ProximitySensor"/> class.
        /// </summary>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular proximity sensor in case of multiple sensors
        /// </param>
        public ProximitySensor(int index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating ProximitySensor object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.ProximitySensor;
        }

        /// <summary>
        /// Event Handler for storing the callback functions for event corresponding to change in proximity sensor data.
        /// </summary>

        public event EventHandler<ProximitySensorDataUpdatedEventArgs> DataUpdated;

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.ProximitySensor, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for proximity");
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
                Log.Error(Globals.LogTag, "Error setting event callback for proximity sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for proximity");
            }
        }

        protected override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for proximity sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for proximity");
            }
        }

        private void SensorEventCallback(IntPtr sensorHandle, IntPtr sensorPtr, IntPtr data)
        {
            Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(sensorPtr);
            TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
            Proximity = (ProximitySensorState) sensorData.values[0];

            DataUpdated?.Invoke(this, new ProximitySensorDataUpdatedEventArgs(sensorData.values[0]));
        }
    }
}
