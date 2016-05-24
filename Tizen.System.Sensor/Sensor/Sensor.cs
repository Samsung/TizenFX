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
    /// Sensor class for storing hardware information about a particular sensor
    /// </summary>
    public abstract class Sensor : IDisposable
    {
        private string _name;
        private string _vendor;
        private float _minValue;
        private float _maxValue;
        private float _resolution;
        private int _minInterval;
        private int _fifoCount;
        private int _maxBatchCount;
        private bool _sensing = false;
        private bool _disposed = false;
        private UInt64 _timestamp;
        private uint _interval = 0;
        private uint _maxBatchLatency = 0;
        private SensorPausePolicy _pausePolicy = SensorPausePolicy.None;
        private IntPtr _sensorHandle = IntPtr.Zero;
        private IntPtr _listenerHandle = IntPtr.Zero;

        protected abstract SensorType GetSensorType();
        protected abstract void EventListenStart();
        protected abstract void EventListenStop();

        internal Sensor(int index)
        {
            SensorType type = GetSensorType();
            GetHandleList(type, index);
            if (CheckSensorHandle())
            {
                CreateListener();
                GetProperty();
            }
        }

        ~Sensor()
        {
            Dispose(false);
        }

        /// <summary>
        /// Property: For getting the name of the sensor
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// Property: Gets the vendor.
        /// </summary>
        public string Vendor
        {
            get
            {
                return _vendor;
            }
        }

        /// <summary>
        /// Property: Gets the minimum value of range of sensor data.
        /// </summary>
        public float MinValue
        {
            get
            {
                return _minValue;
            }
        }

        /// <summary>
        /// Property: Gets the maximum value of range of sensor data.
        /// </summary>
        public float MaxValue
        {
            get
            {
                return _maxValue;
            }
        }

        /// <summary>
        /// Property: Gets the resolution.
        /// </summary>
        public float Resolution
        {
            get
            {
                return _resolution;
            }
        }

        /// <summary>
        /// Property: Gets the minimum interval.
        /// </summary>
        public int MinInterval
        {
            get
            {
                return _minInterval;
            }
        }

        /// <summary>
        /// Property: Gets the fifo count.
        /// </summary>
        public int FifoCount
        {
            get
            {
                return _fifoCount;
            }
        }

        /// <summary>
        /// Property: Gets the maximum batch count.
        /// </summary>
        public int MaxBatchCount
        {
            get
            {
                return _maxBatchCount;
            }
        }

        /// <summary>
        /// Sets the interval of the sensor for sensor data event
        /// Callbacks will be called at frequency of this interval
        /// </summary>
        public uint Interval
        {
            set
            {
                _interval = value;
                SetInterval();
            }
            get
            {
                return _interval;
            }
        }

        /// <summary>
        /// Sets the max batch latency for the sensor corresponding to the sensor data event.
        /// </summary>
        public uint MaxBatchLatency
        {
            set
            {
                _maxBatchLatency = value;
                SetMaxBatchLatency();
            }
            get
            {
                return _maxBatchLatency;
            }
        }

        /// <summary>
        /// Gets the attribute.
        /// </summary>
        /// <value>
        public SensorPausePolicy PausePolicy
        {
            set
            {
                _pausePolicy = value;
                SetPausePolicy();
            }
            get
            {
                return _pausePolicy;
            }
        }

        public UInt64 Timestamp
        {
            set
            {
                _timestamp = value;
            }
            get
            {
                return _timestamp;
            }
        }

        public bool Sensing
        {
            get
            {
                return _sensing;
            }
        }

        protected IntPtr ListenerHandle
        {
            get
            {
                return _listenerHandle;
            }
        }

        /// <summary>
        /// Starts the sensor.
        /// After this the event handlers will start receiving events.
        /// </summary>
        public void Start()
        {
            if (CheckListenerHandle())
            {
                int error = Interop.SensorListener.StartListener(_listenerHandle);
                if (error != 0)
                    throw SensorErrorFactory.CheckAndThrowException(error, "Unable to Start Sensor Listener");
                EventListenStart();
                _sensing = true;
            }
        }

        /// <summary>
        /// Stop the sensor.
        /// After this the event handlers will stop receiving the events
        /// </summary>
        public void Stop()
        {
            if (!_sensing)
            {
                int error = Interop.SensorListener.StopListener(_listenerHandle);
                if (error != 0)
                    throw SensorErrorFactory.CheckAndThrowException(error, "Unable to Stop Sensor Listener");
                EventListenStop();
                _sensing = false;
            }
            else
            {
                throw new InvalidOperationException("Operation Failed: Sensor already stopped");
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            DestroyHandles();
            _disposed = true;
        }

        private void GetHandleList(SensorType type, int index)
        {
            IntPtr list;
            IntPtr[] sensorList;
            int count;
            int error = Interop.SensorManager.GetSensorList(type, out list, out count);
            if (error != 0)
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.GetSensorList Failed");
            sensorList = Interop.IntPtrToIntPtrArray(list, count);
            _sensorHandle = sensorList[index];
            Interop.Libc.Free(list);
        }

        private void GetProperty()
        {
            int error = (int)SensorErrorFactory.SensorError.None;

            error = Interop.Sensor.GetName(_sensorHandle, out _name);
            if (error != 0)
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.Name Failed");

            error = Interop.Sensor.GetVendor(_sensorHandle, out _vendor);
            if (error != 0)
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.Vendor Failed");

            error = Interop.Sensor.GetMinRange(_sensorHandle, out _minValue);
            if (error != 0)
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.MinValue Failed");

            error = Interop.Sensor.GetMaxRange(_sensorHandle, out _maxValue);
            if (error != 0)
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.MaxValue Failed");

            error = Interop.Sensor.GetResolution(_sensorHandle, out _resolution);
            if (error != 0)
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.Resolution Failed");

            error = Interop.Sensor.GetMinInterval(_sensorHandle, out _minInterval);
            if (error != 0)
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.MinInterval Failed");

            error = Interop.Sensor.GetFifoCount(_sensorHandle, out _fifoCount);
            if (error != 0)
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.FifoCount Failed");

            error = Interop.Sensor.GetMaxBatchCount(_sensorHandle, out _maxBatchCount);
            if (error != 0)
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.MaxBatchCount Failed");
        }

        private void CreateListener()
        {
            int error = Interop.SensorListener.CreateListener(_sensorHandle, out _listenerHandle);
            if (error != 0)
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.CreateListener Failed");
        }

        private void SetInterval()
        {
            if (CheckListenerHandle())
            {
                int error = Interop.SensorListener.SetInterval(_listenerHandle, _interval);
                if (error != 0)
                    throw SensorErrorFactory.CheckAndThrowException(error, "Setting Sensor.PausePolicy Failed");
            }
        }

        private void SetMaxBatchLatency()
        {
            if (CheckListenerHandle())
            {
                int error = Interop.SensorListener.SetMaxBatchLatency(_listenerHandle, _maxBatchLatency);
                if (error != 0)
                    throw SensorErrorFactory.CheckAndThrowException(error, "Setting Sensor.MaxBatchLatency Failed");
            }
        }

        private void SetPausePolicy()
        {
            if (CheckListenerHandle())
            {
                int error = Interop.SensorListener.SetAttribute(_listenerHandle, SensorAttribute.PausePolicy, (int)_pausePolicy);
                if (error != 0)
                    throw SensorErrorFactory.CheckAndThrowException(error, "Setting Sensor.PausePolicy Failed");
            }
        }

        private bool CheckListenerHandle()
        {
            bool result = false;
            if (_listenerHandle != IntPtr.Zero)
            {
                result = true;
            }
            else
            {
                throw new ArgumentException("Invalid Parameter: Sensor is null");
            }
            return result;
        }

        private bool CheckSensorHandle()
        {
            bool result = false;
            if (_sensorHandle != IntPtr.Zero)
            {
                result = true;
            }
            else
            {
                throw new ArgumentException("Invalid Parameter: Sensor is null");
            }
            return result;
        }

        private void DestroyHandles()
        {
            Interop.SensorListener.DestroyListener(_listenerHandle);
        }
    }
}
