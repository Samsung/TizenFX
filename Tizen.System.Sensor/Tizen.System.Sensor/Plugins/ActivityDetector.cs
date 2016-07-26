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
    public abstract class ActivityDetector : Sensor
    {
        /// <summary>
        /// Gets the activity accuracy of activity detector
        /// </summary>
        public SensorDataAccuracy ActivityAccuracy { get; protected set; }

        protected abstract void SensorEventCallback(IntPtr sensorHandle, IntPtr sensorPtr, IntPtr data);

        internal ActivityDetector(int index) : base(index)
        {
        }

        protected override void EventListenStart()
        {
            int error = Interop.SensorListener.SetEventCallback(ListenerHandle, Interval, SensorEventCallback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting event callback for activity detector");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for activity detector");
            }
        }

        protected override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for activity detector");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for activity detector");
            }
        }
    }
}
