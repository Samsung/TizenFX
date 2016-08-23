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
    public class RunningActivityDetector : ActivityDetector
    {
        /// <summary>
        /// Gets the state of running activity detector
        /// </summary>
        public DetectorState Running { get; private set; }

        /// <summary>
        /// Returns true or false based on whether running activity detector is supported by device.
        /// </summary>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the running activity detector is supported");
                return CheckIfSupported();
            }
        }

        /// <summary>
        /// Returns the number of running activity detector available on the device.
        /// </summary>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of running activity detectors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.System.Sensor.RunningActivityDetector"/> class.
        /// </summary>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular running activity detector in case of multiple sensors.
        /// </param>
        public RunningActivityDetector(int index) : base(index)
        {
            SetAttribute((SensorAttribute)ActivityAttribute, (int)ActivityType.Running);
            Log.Info(Globals.LogTag, "Creating running activity detector object");
        }

        private static bool CheckIfSupported()
        {
            bool isSupported;
            int error = Interop.SensorManager.SensorIsSupported(SensorType.RunningActivityDetector, out isSupported);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error checking if running activity detector is supported");
                isSupported = false;
            }
            return isSupported;
        }

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.RunningActivityDetector, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for running activity detector");
                count = 0;
            }
            else
                Interop.Libc.Free(list);
            return count;
        }

        /// <summary>
        /// Event Handler for storing the callback functions for event corresponding to change in running activity detector data.
        /// </summary>
        public event EventHandler<RunningActivityDetectorDataUpdatedEventArgs> DataUpdated;

        protected override void SensorEventCallback(IntPtr sensorHandle, IntPtr sensorPtr, IntPtr data)
        {
            Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(sensorPtr);
            TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
            Running = (DetectorState)sensorData.values[0];
            ActivityAccuracy = (SensorDataAccuracy) sensorData.accuracy;

            DataUpdated?.Invoke(this, new RunningActivityDetectorDataUpdatedEventArgs(sensorData.values[0]));
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.RunningActivityDetector;
        }
    }
}
