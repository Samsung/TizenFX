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
    /// FaceDownGestureDetector Class. Used for registering callbacks for face down gesture detector and getting the face down state
    /// </summary>
    public class FaceDownGestureDetector : Sensor
    {
        private static string GestureDetectorKey = "http://tizen.org/feature/sensor.gesture_recognition";

        /// <summary>
        /// Gets the state of the face down gesture.
        /// </summary>
        public DetectorState FaceDown { get; private set; }

        /// <summary>
        /// Returns true or false based on whether face down gesture detector is supported by device.
        /// </summary>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the face down gesture detector is supported");
                return CheckIfSupported(SensorType.FaceDownGestureDetector, GestureDetectorKey);
            }
        }

        /// <summary>
        /// Returns the number of face down gesture detector available on the device.
        /// </summary>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of face down gesture detectors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.System.Sensor.FaceDownGestureDetector"/> class.
        /// </summary>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular face down gesture detector in case of multiple sensors.
        /// </param>
        public FaceDownGestureDetector(int index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating face down gesture detector object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.FaceDownGestureDetector;
        }

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.FaceDownGestureDetector, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for face down gesture detector");
                count = 0;
            }
            else
                Interop.Libc.Free(list);
            return count;
        }

        /// <summary>
        /// Event Handler for storing the callback functions for event corresponding to change in face down gesture detector data.
        /// </summary>
        public event EventHandler<FaceDownGestureDetectorDataUpdatedEventArgs> DataUpdated;

        protected override void EventListenStart()
        {
            int error = Interop.SensorListener.SetEventCallback(ListenerHandle, Interval, SensorEventCallback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for face down gesture detector");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for face down gesture detector");
            }
        }

        protected override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for face down gesture detector");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for face down gesture detector");
            }
        }

        private void SensorEventCallback(IntPtr sensorHandle, IntPtr sensorPtr, IntPtr data)
        {
            Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(sensorPtr);
            TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
            FaceDown = (DetectorState) sensorData.values[0];

            DataUpdated?.Invoke(this, new FaceDownGestureDetectorDataUpdatedEventArgs(sensorData.values[0]));
        }
    }
}
