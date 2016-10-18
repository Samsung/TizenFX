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
    /// Pedometer Sensor Class. Used for registering callbacks for pedometer and getting pedometer data
    /// /// </summary>
    public class Pedometer : Sensor
    {
        private static string PedometerKey = "http://tizen.org/feature/sensor.pedometer";

        /// <summary>
        /// Gets the step count
        /// </summary>
        public int StepCount { get; private set; }

        /// <summary>
        /// Gets the walking step count
        /// </summary>
        public int WalkStepCount { get; private set; }

        /// <summary>
        /// Gets the running step count
        /// </summary>
        public int RunStepCount { get; private set; }

        /// <summary>
        /// Gets the moving distance
        /// </summary>
        public float MovingDistance { get; private set; }

        /// <summary>
        /// Gets the calorie burned
        /// </summary>
        public float CalorieBurned { get; private set; }

        /// <summary>
        /// Gets the last speed
        /// </summary>
        public float LastSpeed { get; private set; }

        /// <summary>
        /// Gets the last stepping frequency
        /// </summary>
        public float LastSteppingFrequency { get; private set; }

        /// <summary>
        /// Gets the last step status
        /// </summary>
        public PedometerState LastStepStatus { get; private set; }

        /// <summary>
        /// Returns true or false based on whether pedometer sensor is supported by device.
        /// </summary>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the Pedometer sensor is supported");
                return CheckIfSupported(SensorType.Pedometer, PedometerKey);
            }
        }

        /// <summary>
        /// Returns the number of pedometer sensors available on the device.
        /// </summary>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of pedometer sensors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.System.Sensor.Pedometer"/> class.
        /// </summary>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular pedometer sensor in case of multiple sensors
        /// </param>
        public Pedometer(int index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating Pedometer object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.Pedometer;
        }

        /// <summary>
        /// Event Handler for storing the callback functions for event corresponding to change in pedometer sensor data.
        /// </summary>

        public event EventHandler<PedometerDataUpdatedEventArgs> DataUpdated;

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.Pedometer, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for pedometer");
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
                Log.Error(Globals.LogTag, "Error setting event callback for pedometer sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for pedometer");
            }
        }

        protected override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for pedometer sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for pedometer");
            }
        }

        private void SensorEventCallback(IntPtr sensorHandle, IntPtr sensorPtr, IntPtr data)
        {
            Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(sensorPtr);
            TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
            StepCount = (int)sensorData.values[0];
            WalkStepCount = (int)sensorData.values[1];
            RunStepCount = (int)sensorData.values[2];
            MovingDistance = sensorData.values[3];
            CalorieBurned = sensorData.values[4];
            LastSpeed = sensorData.values[5];
            LastSteppingFrequency = sensorData.values[6];
            LastStepStatus = (PedometerState)sensorData.values[7];

            DataUpdated?.Invoke(this, new PedometerDataUpdatedEventArgs(sensorData.values));
        }
    }
}
