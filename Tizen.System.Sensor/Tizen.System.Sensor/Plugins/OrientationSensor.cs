// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). Pitchou
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;

namespace Tizen.System.Sensor
{
    /// <summary>
    /// OrientationSensor Class. Used for registering callbacks for orientation sensor and getting orientation data
    /// /// </summary>
    public class OrientationSensor : Sensor
    {
        private static string OrientationSensorKey = "http://tizen.org/feature/sensor.tiltmeter";

        private event EventHandler<SensorAccuracyChangedEventArgs> _accuracyChanged;
        /// <summary>
        /// Gets the Azimuth component of the orientation.
        /// </summary>
        public float Azimuth { get; private set; }

        /// <summary>
        /// Gets the Pitch component of the orientation.
        /// </summary>
        public float Pitch { get; private set; }

        /// <summary>
        /// Gets the Roll component of the orientation.
        /// </summary>
        public float Roll { get; private set; }

        /// <summary>
        /// Returns true or false based on whether orientation sensor is supported by device.
        /// </summary>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the OrientationSensor is supported");
                return CheckIfSupported(SensorType.OrientationSensor, OrientationSensorKey);
            }
        }

        /// <summary>
        /// Returns the number of orientation sensors available on the device.
        /// </summary>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of orientation sensors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.System.Sensor.OrientationSensor"/> class.
        /// </summary>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular orientation sensor in case of multiple sensors
        /// </param>
        public OrientationSensor(int index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating OrientationSensor object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.OrientationSensor;
        }

        /// <summary>
        /// Event Handler for storing the callback functions for event corresponding to change in orientation sensor data.
        /// </summary>

        public event EventHandler<OrientationSensorDataUpdatedEventArgs> DataUpdated;

        /// <summary>
        /// Event handler for accuracy changed events.
        /// </summary>
        public event EventHandler<SensorAccuracyChangedEventArgs> AccuracyChanged
        {
            add
            {
                if (_accuracyChanged == null)
                {
                    AccuracyListenStart();
                }
                _accuracyChanged += value;
            }
            remove
            {
                _accuracyChanged -= value;
                if (_accuracyChanged == null)
                {
                    AccuracyListenStop();
                }
            }
        }

        private static int GetCount()
        {
            IntPtr list;
            int count;
            int error = Interop.SensorManager.GetSensorList(SensorType.OrientationSensor, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for orientation");
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
                Log.Error(Globals.LogTag, "Error setting event callback for orientation sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for orientation");
            }
        }

        protected override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for orientation sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for orientation");
            }
        }

        private void AccuracyListenStart()
        {
            int error = Interop.SensorListener.SetAccuracyCallback(ListenerHandle, Interval, AccuracyEventCallback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting accuracy event callback for orientation sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set accuracy accuracy event callback for orientation");
            }
        }

        private void AccuracyListenStop()
        {
            int error = Interop.SensorListener.UnsetAccuracyCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for orientation sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset accuracy event callback for orientation");
            }
        }

        private void SensorEventCallback(IntPtr sensorHandle, IntPtr sensorPtr, IntPtr data)
        {
            Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(sensorPtr);
            TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
            Azimuth = sensorData.values[0];
            Pitch = sensorData.values[1];
            Roll = sensorData.values[2];

            DataUpdated?.Invoke(this, new OrientationSensorDataUpdatedEventArgs(sensorData.values));
        }

        private void AccuracyEventCallback(IntPtr sensorHandle, UInt64 timestamp, SensorDataAccuracy accuracy, IntPtr data)
        {
            TimeSpan = new TimeSpan((Int64)timestamp);
            _accuracyChanged?.Invoke(this, new SensorAccuracyChangedEventArgs(new TimeSpan((Int64)timestamp), accuracy));
        }
    }
}
