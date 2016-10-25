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
    /// HeartRateMonitor Class. Used for registering callbacks for heart rate monitor and getting heart rate data
    /// /// </summary>
    public class HeartRateMonitor : Sensor
    {
        private const string HRMKey = "http://tizen.org/feature/sensor.heart_rate_monitor";

        /// <summary>
        /// Gets the value of the heart rate monitor.
        /// </summary>
        public int HeartRate { get; private set; } = int.MinValue;

        /// <summary>
        /// Returns true or false based on whether heart rate monitor is supported by device.
        /// </summary>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the HeartRateMonitor is supported");
                return CheckIfSupported(SensorType.HeartRateMonitor, HRMKey);
            }
        }

        /// <summary>
        /// Returns the number of heart rate monitors available on the device.
        /// </summary>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of heart rate monitors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Sensor.HeartRateMonitor"/> class.
        /// </summary>
        /// <remarks>
        /// For accessing heart rate monitor, app should have http://tizen.org/privilege/healthinfo privilege.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported</exception>
        /// <exception cref="UnauthroizedAccessException">Thrown when the app has no privilege to use the sensor</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular heart rate monitor in case of multiple sensors
        /// </param>
        public HeartRateMonitor(uint index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating HeartRateMonitor object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.HeartRateMonitor;
        }

        /// <summary>
        /// Event Handler for storing the callback functions for event corresponding to change in heart rate monitor data.
        /// </summary>

        public event EventHandler<HeartRateMonitorDataUpdatedEventArgs> DataUpdated;

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.HeartRateMonitor, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for heart rate");
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
                Log.Error(Globals.LogTag, "Error setting event callback for heart rate monitor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for heart rate");
            }
        }

        protected override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for heart rate monitor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for heart rate");
            }
        }

        private void SensorEventCallback(IntPtr sensorHandle, IntPtr sensorPtr, IntPtr data)
        {
            Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(sensorPtr);
            TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
            HeartRate = (int)sensorData.values[0];

            DataUpdated?.Invoke(this, new HeartRateMonitorDataUpdatedEventArgs((int)sensorData.values[0]));
        }
    }
}
