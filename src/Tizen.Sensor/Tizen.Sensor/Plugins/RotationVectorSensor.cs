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
    /// RotationVectorSensor Class. Used for registering callbacks for rotation vector sensor and getting rotation vector data
    /// /// </summary>
    public class RotationVectorSensor : Sensor
    {
        private static string RotationVectorKey = "http://tizen.org/feature/sensor.rotation_vector";

        private event EventHandler<SensorAccuracyChangedEventArgs> _accuracyChanged;
        /// <summary>
        /// Gets the X component of the rotation vector.
        /// </summary>
        public float X { get; private set; }

        /// <summary>
        /// Gets the Y component of the rotation vector.
        /// </summary>
        public float Y { get; private set; }

        /// <summary>
        /// Gets the Z component of the rotation vector.
        /// </summary>
        public float Z { get; private set; }

        /// <summary>
        /// Gets the W component of the rotation vector.
        /// </summary>
        public float W { get; private set; }

        /// <summary>
        /// Gets the Accuracy of the rotation vector data.
        /// </summary>
        public SensorDataAccuracy Accuracy { get; private set; }

        /// <summary>
        /// Returns true or false based on whether rotation vector sensor is supported by device.
        /// </summary>
        public static bool IsSupported
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the RotationVectorSensor is supported");
                return CheckIfSupported(SensorType.RotationVectorSensor, RotationVectorKey);
            }
        }

        /// <summary>
        /// Returns the number of rotation vector sensors available on the device.
        /// </summary>
        public static int Count
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the count of rotation vector sensors");
                return GetCount();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Sensor.RotationVectorSensor"/> class.
        /// </summary>
        /// <param name='index'>
        /// Index. Default value for this is 0. Index refers to a particular rotation vector sensor in case of multiple sensors
        /// </param>
        public RotationVectorSensor(int index = 0) : base(index)
        {
            Log.Info(Globals.LogTag, "Creating RotationVectorSensor object");
        }

        internal override SensorType GetSensorType()
        {
            return SensorType.RotationVectorSensor;
        }

        /// <summary>
        /// Event Handler for storing the callback functions for event corresponding to change in rotation vector sensor data.
        /// </summary>

        public event EventHandler<RotationVectorSensorDataUpdatedEventArgs> DataUpdated;

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
            int error = Interop.SensorManager.GetSensorList(SensorType.RotationVectorSensor, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list for rotation vector");
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
                Log.Error(Globals.LogTag, "Error setting event callback for rotation vector sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set event callback for rotation vector");
            }
        }

        protected override void EventListenStop()
        {
            int error = Interop.SensorListener.UnsetEventCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting event callback for rotation vector sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset event callback for rotation vector");
            }
        }

        private void AccuracyListenStart()
        {
            int error = Interop.SensorListener.SetAccuracyCallback(ListenerHandle, Interval, AccuracyEventCallback, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error setting accuracy event callback for rotation vector sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to set accuracy event callback for rotation vector");
            }
        }

        private void AccuracyListenStop()
        {
            int error = Interop.SensorListener.UnsetAccuracyCallback(ListenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error unsetting accuracy event callback for rotation vector sensor");
                throw SensorErrorFactory.CheckAndThrowException(error, "Unable to unset accuracy event callback for rotation vector");
            }
        }

        private void SensorEventCallback(IntPtr sensorHandle, IntPtr sensorPtr, IntPtr data)
        {
            Interop.SensorEventStruct sensorData = Interop.IntPtrToEventStruct(sensorPtr);
            TimeSpan = new TimeSpan((Int64)sensorData.timestamp);
            X = sensorData.values[0];
            Y = sensorData.values[1];
            Z = sensorData.values[2];
            Accuracy = sensorData.accuracy;

            DataUpdated?.Invoke(this, new RotationVectorSensorDataUpdatedEventArgs(sensorData.values, sensorData.accuracy));
        }

        private void AccuracyEventCallback(IntPtr sensorHandle, UInt64 timestamp, SensorDataAccuracy accuracy, IntPtr data)
        {
            TimeSpan = new TimeSpan((Int64)timestamp);
            Accuracy = accuracy;
            _accuracyChanged?.Invoke(this, new SensorAccuracyChangedEventArgs(new TimeSpan((Int64)timestamp), accuracy));
        }
    }
}
