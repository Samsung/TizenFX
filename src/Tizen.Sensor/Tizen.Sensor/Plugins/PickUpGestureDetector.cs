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
    /// PickUpGestureDetector Class. Used for registering callbacks for pick up activity detector and getting the pick up state
    /// </summary>
    public class PickUpGestureDetector : Sensor
    {
        private static string GestureDetectorKey = "http://tizen.org/feature/sensor.gesture_recognition";

        /// <summary>
        /// Gets the state of the pick up gesture.
        /// </summary>
        public DetectorState PickUp { get; private set; }

        /// <summary>
        /// Returns true or false based on whether pick up gesture detector is supported by device.
        /// </summary>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the pick up gesture detector is supported");
                return CheckIfSupported(SensorType.PickUpGestureDetector, GestureDetectorKey);
            }
        }

        /// <summary>
        /// Returns the number of pick up gesture detector available on the device.
        /// </summary>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of pick up gesture detectors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Sensor.PickUpGestureDetector"/> class.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="NotSupportedException">Thrown when the sensor is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular pick up gesture detector in case of multiple sensors.
        /// </param>
        public PickUpGestureDetector(uint index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating pick up gesture detector object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.PickUpGestureDetector;
        }

        private static bool CheckIfSupported()
        {
            bool isSupported;
            int error = Interop.SensorManager.SensorIsSupported(SensorType.PickUpGestureDetector, out isSupported);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error checking if pick up gesture detector is supported");
                isSupported = false;
            }
            return isSupported;
        }

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.PickUpGestureDetector, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for pick up gesture detector");
                count = 0;
            }
            else
                Interop.Libc.Free(list);
            return count;
        }

        /// <summary>
        /// Event Handler for storing the callback functions for event corresponding to change in pick up gesture detector data.
        /// </summary>
        public event EventHandler<PickUpGestureDetectorDataUpdatedEventArgs> DataUpdated;

        protected override void EventListenStart()
        {
            int error = Interop.SensorListener.SetEventCallback(ListenerHandle, Interval, SensorEventCallback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for pick up gesture detector");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for pick up gesture detector");
            }
        }

        protected override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for pick up gesture detector");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for pick up gesture detector");
            }
        }

        private void SensorEventCallback(IntPtr sensorHandle, IntPtr sensorPtr, IntPtr data)
        {
            Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(sensorPtr);
            TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
            PickUp = (DetectorState) sensorData.values[0];

            DataUpdated?.Invoke(this, new PickUpGestureDetectorDataUpdatedEventArgs(sensorData.values[0]));
        }
    }
}
