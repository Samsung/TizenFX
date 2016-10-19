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
    /// WristUpGestureDetector Class. Used for registering callbacks for wrist up gesture detector and getting the wrist up state
    /// </summary>
    public class WristUpGestureDetector : Sensor
    {
        private static string WristUpKey = "http://tizen.org/feature/sensor.wrist_up";

        /// <summary>
        /// Gets the state of the wrist up gesture.
        /// </summary>
        public DetectorState WristUp { get; private set; }

        /// <summary>
        /// Returns true or false based on whether wrist up gesture detector is supported by device.
        /// </summary>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the wrist up gesture detector is supported");
                return CheckIfSupported(SensorType.WristUpGestureDetector, WristUpKey);
            }
        }

        /// <summary>
        /// Returns the number of wrist up gesture detector available on the device.
        /// </summary>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of wrist up gesture detectors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Sensor.WristUpGestureDetector"/> class.
        /// </summary>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular wrist up gesture detector in case of multiple sensors.
        /// </param>
        public WristUpGestureDetector(int index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating wrist up gesture detector object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.WristUpGestureDetector;
        }

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.WristUpGestureDetector, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for wrist up gesture detector");
                count = 0;
            }
            else
                Interop.Libc.Free(list);
            return count;
        }

        /// <summary>
        /// Event Handler for storing the callback functions for event corresponding to change in wrist up gesture detector data.
        /// </summary>
        public event EventHandler<WristUpGestureDetectorDataUpdatedEventArgs> DataUpdated;

        protected override void EventListenStart()
        {
            int error = Interop.SensorListener.SetEventCallback(ListenerHandle, Interval, SensorEventCallback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for wrist up gesture detector");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for wrist up gesture detector");
            }
        }

        protected override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for wrist up gesture detector");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for wrist up gesture detector");
            }
        }

        private void SensorEventCallback(IntPtr sensorHandle, IntPtr sensorPtr, IntPtr data)
        {
            Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(sensorPtr);
            TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
            WristUp = (DetectorState) sensorData.values[0];

            DataUpdated?.Invoke(this, new WristUpGestureDetectorDataUpdatedEventArgs(sensorData.values[0]));
        }
    }
}
