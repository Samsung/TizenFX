/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using Tizen.System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tizen.Sensor
{
    internal static class Globals
    {
        internal const string LogTag = "Tizen.Sensor";
    }

    /// <summary>
    /// The Sensor class is used for storing the hardware information about a particular sensor.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
        private bool _isSensing = false;
        private bool _disposed = false;
        private ulong _timestamp;
        private uint _interval = 0;
        private uint _maxBatchLatency = 0;
        private SensorPausePolicy _pausePolicy = SensorPausePolicy.None;
        private IntPtr _sensorHandle = IntPtr.Zero;
        private IntPtr _listenerHandle = IntPtr.Zero;
        internal IList<Interop.SensorEventStruct> BatchedEvents { get; set; } = new List<Interop.SensorEventStruct>();


        /// <summary>
        /// Read sensor(which inherits this class) data synchronously.
        /// </summary>
        internal abstract void ReadData();

        /// <summary>
        /// Get the type of a sensor which inherits this class.
        /// </summary>
        internal abstract SensorType GetSensorType();

        /// <summary>
        /// Start to listen the event of a sensor which inherits this class.
        /// </summary>
        internal abstract void EventListenStart();

        /// <summary>
        /// Stop to listen the event of a sensor which inherits this class.
        /// </summary>
        internal abstract void EventListenStop();

        /// <summary>
        /// Update the internal batch event list using the latest events.
        /// </summary>
        /// <remarks>
        /// It will be called for updating events about the sensor like
        /// BatchSensor or Plugin classes which inherits this class.
        /// </remarks>
        /// <param name="eventsPtr">
        /// General batch data's raw pointer
        /// </param>
        /// <param name="events_count">
        /// Number of general batch events
        /// </param>
        internal void updateBatchEvents(IntPtr eventsPtr, uint events_count)
        {
            if (events_count >= 1)
            {
                BatchedEvents.Clear();
                IntPtr currentPtr = eventsPtr;
                for (int i = 0; i < events_count; i++)
                {
                    BatchedEvents.Add(Interop.IntPtrToEventStruct(currentPtr));
                    currentPtr += Marshal.SizeOf<Interop.SensorEventStruct>();
                }
            }
        }

        /// <summary>
        /// Return the last element of Batched elements, which is the latest
        /// sensor event.
        /// </summary>
        /// <remarks>
        /// If there is no event, default(Interop.SensorEventStruct) will be
        /// returned.
        /// </remarks>
        internal Interop.SensorEventStruct latestEvent()
        {
            if (BatchedEvents.Count > 0)
            {
                return BatchedEvents[BatchedEvents.Count - 1];
            }
            return default(Interop.SensorEventStruct);
        }

        /// <summary>
        /// Create the Sensor object to listen to the sensor events.
        /// </summary>
        internal Sensor(uint index)
        {
            SensorType type = GetSensorType();
            GetHandleList(type, index);
            if (CheckSensorHandle())
            {
                CreateListener();
                GetProperty();
            }
        }

        /// <summary>
        /// Destroy the Sensor object and release all resources.
        /// </summary>
        ~Sensor()
        {
            Dispose(false);
        }

        /// <summary>
        /// Property: Gets the name of the sensor as a string.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The name of the sensor. </value>
        public string Name
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the sensor name");
                return _name;
            }
        }

        /// <summary>
        /// Property: Gets the vendor of the sensor as a string.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The vendor name of the sensor. </value>
        public string Vendor
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the sensor vendor name");
                return _vendor;
            }
        }

        /// <summary>
        /// Property: Gets the minimum value of the range of the sensor data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The lower bound of the range of the sensor reading. </value>
        public float MinValue
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the min value of the sensor");
                return _minValue;
            }
        }

        /// <summary>
        /// Property: Gets the maximum value of the range of the sensor data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The upper bound of the range of the sensor reading. </value>
        public float MaxValue
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the max value of the sensor");
                return _maxValue;
            }
        }

        /// <summary>
        /// Property: Gets the resolution of the sensor as a float type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The resolution. </value>
        public float Resolution
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the resolution of the sensor");
                return _resolution;
            }
        }

        /// <summary>
        /// Property: Gets the minimum interval of the sensor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The minimum update interval. </value>
        public int MinInterval
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the min interval for the sensor");
                return _minInterval;
            }
        }

        /// <summary>
        /// Property: Gets the FIFO count of the sensor as int type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The size of the hardware FIFO. </value>
        public int FifoCount
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the fifo count of the sensor");
                return _fifoCount;
            }
        }

        /// <summary>
        /// Property: Gets the maximum batch count of the sensor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The maximum batch count. </value>
        public int MaxBatchCount
        {
            get
            {
                Log.Info(Globals.LogTag, "Getting the max batch count of the sensor");
                return _maxBatchCount;
            }
        }

        /// <summary>
        /// Sets the interval of the sensor for the sensor data event.
        /// Callbacks will be called at the frequency of this interval.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        /// <value> The interval of the sensor. </value>
        public uint Interval
        {
            set
            {
                Log.Info(Globals.LogTag, "Setting the interval of the sensor");
                _interval = value;
                SetInterval();
            }
            get
            {
                Log.Info(Globals.LogTag, "Getting the interval of the sensor");
                return _interval;
            }
        }

        /// <summary>
        /// Sets the maximum batch latency for the sensor corresponding to the sensor data event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        /// <value> The maximum batch latency. </value>
        public uint MaxBatchLatency
        {
            set
            {
                Log.Info(Globals.LogTag, "Setting the max batch latency of the sensor");
                _maxBatchLatency = value;
                SetMaxBatchLatency();
            }
            get
            {
                Log.Info(Globals.LogTag, "Getting the max batch latency of the sensor");
                return _maxBatchLatency;
            }
        }

        /// <summary>
        /// Get the pause policy or set the pause policy of the sensor as the
        /// set value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The pause policy.</value>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        /// <value> The pause policy. </value>
        public SensorPausePolicy PausePolicy
        {
            set
            {
                Log.Info(Globals.LogTag, "Setting the pause policy of the sensor");
                _pausePolicy = value;
                SetAttribute(SensorAttribute.PausePolicy, (int)_pausePolicy);
            }
            get
            {
                Log.Info(Globals.LogTag, "Getting the pause policy of the sensor");
                return _pausePolicy;
            }
        }

        /// <summary>
        /// Gets or sets the time span.
        /// Set value will be used as its 'Ticks' attribute.
        /// Get will return the newly allocated TimeSpan object with the same
        /// ticks as the sensor's timestamp.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The time span. </value>
        public TimeSpan TimeSpan
        {
            set
            {
                Log.Info(Globals.LogTag, "Setting the timespan of the sensor values");
                _timestamp = (ulong)value.Ticks;
            }
            get
            {
                Log.Info(Globals.LogTag, "Getting the timespan of the sensor values");
                return new TimeSpan((Int64)_timestamp);
            }
        }

        /// <summary>
        /// Gets or sets the timestamp of a sensor which inherits the sensor
        /// class.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <value> Timestamp. </value>
        public ulong Timestamp
        {
            set
            {
                Log.Info(Globals.LogTag, "Setting the timestamp of the sensor values");
                _timestamp = value;
            }
            get
            {
                Log.Info(Globals.LogTag, "Getting the timestamp of the sensor values");
                return _timestamp;
            }
        }

        /// <summary>
        /// Indicate whether the sensor is sensing or not sensing.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value><c>true</c> if the sensor is sensing; otherwise <c>false</c>.</value>
        public bool IsSensing
        {
            get
            {
                Log.Info(Globals.LogTag, "Checking if the sensor is started");
                return _isSensing;
            }
        }

        internal IntPtr ListenerHandle
        {
            get
            {
                return _listenerHandle;
            }
        }

        /// <summary>
        /// Check if the sensor type is supported or not by the system.
        /// </summary>
        /// <param name="type">The sensor type to check.</param>
        /// <param name="key">The key for the sensor type to check.</param>
        /// <returns>True if the sensor type is supported, otherwise false.</returns>
        internal static bool CheckIfSupported(SensorType type, String key)
        {
            bool isSupported = false;
            bool error = Information.TryGetValue(key, out isSupported);

            if (!error || !isSupported)
            {
                Log.Error(Globals.LogTag, "Error checking if sensor is supported(systeminfo)");
                return false;
            }

            int ret = Interop.SensorManager.SensorIsSupported(type, out isSupported);
            if (ret != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error checking if sensor is supported");
                isSupported = false;
            }

            return isSupported;
        }

        /// <summary>
        /// Starts the sensor.
        /// After this, event handlers will start receiving events.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        public void Start()
        {
            Log.Info(Globals.LogTag, "Starting the sensor");
            if (CheckListenerHandle())
            {
                int error = Interop.SensorListener.StartListener(_listenerHandle);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error starting sensor");
                    throw SensorErrorFactory.CheckAndThrowException(error, "Unable to Start Sensor Listener");
                }
                try
                {
                    ReadData();
                }
                catch (InvalidOperationException e)
                {
                    Log.Error(Globals.LogTag, "Sensor has no data : " + e.Message);
                }
                EventListenStart();
                _isSensing = true;
                Log.Info(Globals.LogTag, "Sensor started");
            }
        }

        /// <summary>
        /// Stops the sensor.
        /// After this, event handlers will stop receiving events.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state.</exception>
        public void Stop()
        {
            Log.Info(Globals.LogTag, "Stopping the sensor");
            if (_isSensing)
            {
                int error = Interop.SensorListener.StopListener(_listenerHandle);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error stopping the sensor");
                    throw SensorErrorFactory.CheckAndThrowException(error, "Unable to Stop Sensor Listener");
                }
                EventListenStop();
                _isSensing = false;
                Log.Info(Globals.LogTag, "Sensor stopped");
            }
        }

        /// <summary>
        /// Destroy the current object and release all the resources.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all resources currently used by this instance.
        /// </summary>
        /// <param name="disposing">
        /// true if managed resources should be disposed
        /// otherwise, false.
        /// </param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            DestroyHandles();
            _disposed = true;
        }

        internal void SetAttribute(SensorAttribute attribute, int option)
        {
            if (CheckListenerHandle())
            {
                int error = Interop.SensorListener.SetAttribute(_listenerHandle, attribute, option);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error setting sensor pause policy");
                    throw SensorErrorFactory.CheckAndThrowException(error, "Setting Sensor.PausePolicy Failed");
                }
            }
        }

        /// <summary>
        /// Gets the handle list of the sensors of a given type and index.
        /// </summary>
        /// <remarks>
        /// A device may have more than one sensors of the given type.
        /// In such case, the 'index'th sensor handle will be used.
        /// </remarks>
        private void GetHandleList(SensorType type, uint index)
        {
            IntPtr list;
            IntPtr[] sensorList;
            int count;
            int error = Interop.SensorManager.GetSensorList(type, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.GetSensorList Failed");
            }
            sensorList = Interop.IntPtrToIntPtrArray(list, count);
            _sensorHandle = sensorList[index];
            Interop.Libc.Free(list);
        }

        /// <summary>
        /// Get the following sensor properties of the sensor:
        /// name, vendor, minimum range, maximum range, resolution, minimum interval, fifo count, maximum batch count
        /// </summary>
        private void GetProperty()
        {
            int error = (int)SensorError.None;

            error = Interop.Sensor.GetName(_sensorHandle, out _name);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor name");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.Name Failed");
            }

            error = Interop.Sensor.GetVendor(_sensorHandle, out _vendor);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor vendor name");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.Vendor Failed");
            }

            error = Interop.Sensor.GetMinRange(_sensorHandle, out _minValue);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor min value");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.MinValue Failed");
            }

            error = Interop.Sensor.GetMaxRange(_sensorHandle, out _maxValue);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor max value");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.MaxValue Failed");
            }

            error = Interop.Sensor.GetResolution(_sensorHandle, out _resolution);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor resolution");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.Resolution Failed");
            }

            error = Interop.Sensor.GetMinInterval(_sensorHandle, out _minInterval);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor min interval");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.MinInterval Failed");
            }

            error = Interop.Sensor.GetFifoCount(_sensorHandle, out _fifoCount);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor fifo count");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.FifoCount Failed");
            }

            error = Interop.Sensor.GetMaxBatchCount(_sensorHandle, out _maxBatchCount);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor max batch count");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.MaxBatchCount Failed");
            }
        }

        /// <summary>
        /// Create a sensor listener and store a handle of the listener as an member variable.
        /// </summary>
        private void CreateListener()
        {
            int error = Interop.SensorListener.CreateListener(_sensorHandle, out _listenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error cerating sensor listener handle");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.CreateListener Failed");
            }
        }

        /// <summary>
        /// Change the interval between updates for the sensor with the value stored in member variable.
        /// </summary>
        private void SetInterval()
        {
            if (CheckListenerHandle())
            {
                if (_isSensing)
                {
                    int error = Interop.SensorListener.SetInterval(_listenerHandle, _interval);
                    if (error != (int)SensorError.None)
                    {
                        Log.Error(Globals.LogTag, "Error setting sensor interval");
                        throw SensorErrorFactory.CheckAndThrowException(error, "Setting Sensor.SetInterval Failed");
                    }
                }
            }
        }

        /// <summary>
        /// Set the desired maximum batch latency of the sensor.
        /// Sensors that support batching may allow applications to change their maximum batch latencies.
        /// For example, if you set the latency as 10,000 ms, the sensor may store its data
        /// up to 10,000 ms, before delivering the data through the HAL.
        /// In case of non-batching sensors no error will be occured,
        /// but nothing is affected by the input latency value.
        /// </summary>
        /// <remarks>
        /// Even if you set a batch latency, the sensor may not work as you intended,
        /// as one sensor can be used by more than one listeners.
        /// In addition, some batch sensors may already have fixed batching latency
        /// or batching queue size, which cannot be altered by applications.
        /// </remarks>
        private void SetMaxBatchLatency()
        {
            if (CheckListenerHandle())
            {
                int error = Interop.SensorListener.SetMaxBatchLatency(_listenerHandle, _maxBatchLatency);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error setting max batch latency");
                    throw SensorErrorFactory.CheckAndThrowException(error, "Setting Sensor.MaxBatchLatency Failed");
                }
            }
        }

        /// <summary>
        /// Check if listener handle for the sensor is valid or not.
        /// </summary>
        /// <remarks>
        /// If listener handle is not valid, then it will throw ArgumentException.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when the sensor listener handler is invalid.</exception>
        /// <value><c>true</c> if listener handle is valid.</value>
        private bool CheckListenerHandle()
        {
            bool result = false;
            if (_listenerHandle != IntPtr.Zero)
            {
                result = true;
            }
            else
            {
                Log.Error(Globals.LogTag, "Sensor listener handle is null");
                throw new ArgumentException("Invalid Parameter: Sensor is null");
            }
            return result;
        }

        /// <summary>
        /// Check if sensor handle for the sensor is valid or not.
        /// If sensor handle is not valid, then it will throw ArgumentException.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the sensor handler is invalid.</exception>
        /// <value><c>true</c> if sensor handle is valid.</value>
        private bool CheckSensorHandle()
        {
            bool result = false;
            if (_sensorHandle != IntPtr.Zero)
            {
                result = true;
            }
            else
            {
                Log.Error(Globals.LogTag, "Sensor handle is null");
                throw new ArgumentException("Invalid Parameter: Sensor is null");
            }
            return result;
        }

        /// <summary>
        /// Destroy resources of a listener handle of the sensor.
        /// Release all resources allocated for a listener handle.
        /// </summary>
        /// <remarks>
        /// If this function is called while the sensor is still running,
        /// that is, then it is implicitly stopped.
        /// </remarks>
        private void DestroyHandles()
        {
            Interop.SensorListener.DestroyListener(_listenerHandle);
        }
    }
}
