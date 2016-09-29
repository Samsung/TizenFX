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
    public class InVehicleActivityDetector : ActivityDetector
    {
        /// <summary>
        /// Gets the state of in-vehicle activity detector
        /// </summary>
        public DetectorState InVehicle { get; private set; }

        /// <summary>
        /// Returns true or false based on whether in-vehicle activity detector is supported by device.
        /// </summary>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the in-vehicle activity detector is supported");
                return CheckIfSupported();
            }
        }

        /// <summary>
        /// Returns the number of in-vehicle activity detector available on the device.
        /// </summary>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of in-vehicle activity detectors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.System.Sensor.InVehicleActivityDetector"/> class.
        /// </summary>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular in-vehicle activity detector in case of multiple sensors.
        /// </param>
        public InVehicleActivityDetector(int index = 0) : base(index)
        {
            SetAttribute((SensorAttribute)ActivityAttribute, (int)ActivityType.InVehicle);
            Log.Info(Globals.LogTag, "Creating in-vehicle activity detector object");
        }

        private static bool CheckIfSupported()
        {
            bool isSupported;
            int error = Interop.SensorManager.SensorIsSupported(SensorType.InVehicleActivityDetector, out isSupported);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error checking if in-vehicle activity detector is supported");
                isSupported = false;
            }
            return isSupported;
        }

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.InVehicleActivityDetector, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for in-vehicle activity detector");
                count = 0;
            }
            else
                Interop.Libc.Free(list);
            return count;
        }

        /// <summary>
        /// Event Handler for storing the callback functions for event corresponding to change in in-vehicle activity detector data.
        /// </summary>
        public event EventHandler<InVehicleActivityDetectorDataUpdatedEventArgs> DataUpdated;

        protected override void SensorEventCallback(IntPtr sensorHandle, IntPtr sensorPtr, IntPtr data)
        {
            Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(sensorPtr);
            TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
            InVehicle = (DetectorState)sensorData.values[0];
            ActivityAccuracy = (SensorDataAccuracy) sensorData.accuracy;

            DataUpdated?.Invoke(this, new InVehicleActivityDetectorDataUpdatedEventArgs(sensorData.values[0]));
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.InVehicleActivityDetector;
        }
    }
}
