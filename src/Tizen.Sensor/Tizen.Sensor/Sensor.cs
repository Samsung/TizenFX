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
using System.Runtime.InteropServices;

namespace Tizen.Sensor
{
    internal static class Globals
    {
        internal const string LogTag = "Tizen.Sensor";
    }

    /// <summary>
    /// Data from sensor
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public struct SensorEventStruct
    {
        /// <summary>
        /// Accuracy of sensor data 
        /// </summary>
        public SensorDataAccuracy accuracy
        {
            get { return accuracy; }
            private set { }
        }

        /// <summary>
        /// time stamp value 
        /// </summary>
        public UInt64 Timestamp
        {
            get { return Timestamp; }
            private set { }
        }

        /// <summary> 
        /// value count
        /// </summary>
        public int valueCount
        {
            get { return valueCount; }
            private set { }
        }

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        private float[] values;

        /// <summary> 
        /// sensor data values
        /// </summary>
        public float[] Values
        {
            get { return values; }
            private set { }
        }

    }

    /// <summary>
    /// The Sensor class is used for storing the hardware information about a particular sensor.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public abstract class Sensor : IDisposable
    {
        private string _uri;
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
        private TimeSpan _timeSpan;
        private uint _interval = 0;
        private uint _maxBatchLatency = 0;
        private SensorPausePolicy _pausePolicy = SensorPausePolicy.None;
        private IntPtr _sensorHandle = IntPtr.Zero;
        private IntPtr _listenerHandle = IntPtr.Zero;
        private IntPtr recorderOption = IntPtr.Zero;
        private IntPtr recorderQuery = IntPtr.Zero;
        private IntPtr _sensorProviderHandle = IntPtr.Zero;

        internal abstract SensorType GetSensorType();
        internal abstract void EventListenStart();
        internal abstract void EventListenStop();
        private static Interop.SensorRecoder.SensorRecorderDataCb _sensorRecorderDataCallBack = null;
        private static Interop.SensorProvider.SensorProviderStartCb _sensorProviderStartCallBack = null;
        private static Interop.SensorProvider.SensorProviderStopCb _sensorProviderStopCallBack = null;
        private static Interop.SensorProvider.SensorProviderIntervalChangedCb _sensorProviderIntervalChangedCallBack = null;
        private static Interop.SensorManager.SensorAddedCb _sensorAddedCallBack = null;
        private static Interop.SensorManager.SensorRemovedCb _sensorRemovedCallBack = null;
        /// <summary>
        /// RecorderDataReceived
        /// </summary>
        public static event EventHandler<RecorderDataEventArgs> RecorderDataReceived;
        /// <summary>
        /// ProviderStarted
        /// </summary>
        public static event EventHandler<ProviderStartEventArgs> ProviderStarted;
        /// <summary>
        /// ProviderStoped
        /// </summary>
        public static event EventHandler<ProviderStopEventArgs> ProviderStoped;
        /// <summary>
        /// ProviderIntervalChanged
        /// </summary>
        public static event EventHandler<ProviderIntervalChangedEventArgs> ProviderIntervalChanged;
        /// <summary>
        /// AddSensorAdded
        /// </summary>
        public static event EventHandler<SensorAddedEventArgs> AddSensorAdded;
        /// <summary>
        /// RemoveSensorAdded
        /// </summary>
        public static event EventHandler<SensorAddedEventArgs> RemoveSensorAdded;
        /// <summary>
        /// AddSensorRemoved
        /// </summary>
        public static event EventHandler<SensorRemovedEventArgs> AddSensorRemoved;
        /// <summary>
        /// RemoveSensorRemoved
        /// </summary>
        public static event EventHandler<SensorRemovedEventArgs> RemoveSensorRemoved;

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

        internal Sensor(String uri, uint index)
        {
            GetHandleList(uri, index);
            if (CheckSensorHandle())
            {
                CreateListener();
                GetProperty();
            }
        }


        /// <summary>
        /// Destroy the Sensor object.
        /// </summary>
        ~Sensor()
        {
            Dispose(false);
        }

        /// <summary>
        /// Property: Gets the name of the sensor.
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
        /// Property: Gets the vendor.
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
        /// Property: Gets the resolution.
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
        /// Property: Gets the minimum interval.
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
        /// Property: Gets the FIFO count.
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
        /// Property: Gets the maximum batch count.
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
        /// Sets the pause policy of the sensor.
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
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> The time span. </value>
        public TimeSpan TimeSpan
        {
            set
            {
                Log.Info(Globals.LogTag, "Setting the timespan of the sensor values");
                _timeSpan = value;
            }
            get
            {
                Log.Info(Globals.LogTag, "Getting the timespan of the sensor values");
                return _timeSpan;
            }
        }

        /// <summary>
        /// Indicates whether this sensor is sensing.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value><c>true</c> if this sensor is sensing; otherwise <c>false</c>.</value>
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
        /// Destroy the current object.
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
            error = Interop.Sensor.GetUri(_sensorHandle, out _uri);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor uri");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.Uri Failed");
            }
        }

        private void CreateListener()
        {
            int error = Interop.SensorListener.CreateListener(_sensorHandle, out _listenerHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error creating sensor listener handle");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.CreateListener Failed");
            }
        }

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

        private void DestroyHandles()
        {
            Interop.SensorListener.DestroyListener(_listenerHandle);
        }

        /// <summary>
        /// Gets the handle for the default sensor of a given sensor URI.
        /// </summary>
        /// <param name="uri">
        /// A sensor or a sensor type URI to get the handle of its default sensor.
        /// </param>
        /// <param name="sensorHandle">
        /// The default sensor handle.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void GetDefaultSensorByUri(string uri, out IntPtr sensorHandle)
        {
            int error = Interop.SensorManager.GetDefaultSensorByUri(uri, out sensorHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting default sensor by uri");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.GetDefaultSensorByUri Failed");
            }

        }

        private void GetHandleList(string uri, uint index) {
            IntPtr list;
            IntPtr[] sensorList;
            int count;
            int error = Interop.SensorManager.GetSensorListByUri(uri, out list, out count);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting sensor list by uri");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.GetSensorListByUri Failed");
            }
            sensorList = Interop.IntPtrToIntPtrArray(list, count);
            _sensorHandle = sensorList[index];
            Interop.Libc.Free(list);
        }

        /// <summary>
        /// Creates a recorder option handle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void RecorderCreateOption() {
            int error = Interop.SensorRecoder.RecorderCreateOption(out recorderOption);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error creating the sensor recorder option");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderCreateOption Failed");
            }
        }

        /// <summary>
        /// Creates a recorder query handle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void RecorderCreateQuery()
        {
            int error = Interop.SensorRecoder.RecorderCreateQuery(out recorderQuery);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error creating the sensor recorder query");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderCreateQuery Failed");
            }
        }

        /// <summary>
        /// Gets a double value from a record data.
        /// </summary>
        /// <param name="data">
        /// Record data handle.
        /// </param>
        /// <param name="key">
        /// Data attribute to retrieve.
        /// </param>
        /// <param name="value">
        /// Retrieved value.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void RecorderDataGetDouble(IntPtr data, int key, out IntPtr value)
        {
            int error = Interop.SensorRecoder.RecorderDataGetDouble(data , key , out value);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting the sensor recorder double data");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderDataGetDouble Failed");
            }
        }

        /// <summary>
        /// Gets the start and the end time of the time period of a given record data.
        /// </summary>
        /// <param name="data">
        /// Record data handle.
        /// </param>
        /// <param name="startTime">
        /// Start time of the time period of the record.
        /// </param>
        /// <param name="endTime">
        /// End time of the time period of the record.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void RecorderDataGetTime(IntPtr data, out IntPtr startTime, out IntPtr endTime)
        {
            int error = Interop.SensorRecoder.RecorderDataGetTime(data, out startTime, out endTime);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting the sensor recorder time");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderDataGetTime Failed");
            }
        }

        /// <summary>
        /// Destroys a recorder option handle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void RecorderDestroyOption()
        {
            int error = Interop.SensorRecoder.RecorderDestroyOption(recorderOption);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error deleting the sensor recorder option");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderDestroyOption Failed");
            }
        }

        /// <summary>
        /// Destroys a recorder query handle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void RecorderDestroyQuery()
        {
            int error = Interop.SensorRecoder.RecorderDestroyQuery(recorderQuery);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error deleting the sensor recorder query");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderDestroyQuery Failed");
            }
        }

        /// <summary>
        /// Checks whether it is supported to record a given sensor type.
        /// </summary>
        /// <param name="type">
        /// A sensor type to check.
        /// </param>
        /// <param name="isSupported">
        /// If supported.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void RecorderIsSupported(Enum type, out IntPtr isSupported)
        {
            int error = Interop.SensorRecoder.RecorderIsSupported(type, out isSupported);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error checking if sensor recorder is supported");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderIsSupported Failed");
            }
        }

        /// <summary>
        /// Sets a recording option parameter.
        /// </summary>
        /// <param name="recorderOptionE">
        /// Option parameter.
        /// </param>
        /// <param name="value">
        /// Value.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void RecorderOptionSetInt(Enum recorderOptionE, int value)
        {
            int error = Interop.SensorRecoder.RecorderOptionSetInt(recorderOption, recorderOptionE,  value);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error checking sensor recorder option set int");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderOptionSetInt Failed");
            }
        }

        /// <summary>
        ///  Sets an integer-type query parameter.
        /// </summary>
        /// <param name="recorderQueryE">
        /// Query parameter.
        /// </param>
        /// <param name="value">
        /// Value.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void RecorderQuerySetInt(Enum recorderQueryE, int value)
        {
            int error = Interop.SensorRecoder.RecorderQuerySetInt(recorderQuery, recorderQueryE, value);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error checking sensor recorder query set int");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderQuerySetInt Failed");
            }
        }

        /// <summary>
        ///  Sets a time-type query parameter.
        /// </summary>
        /// <param name="recorderQueryE">
        /// Query parameter.
        /// </param>
        /// <param name="time">
        /// Time.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void RecorderQuerySetTime(Enum recorderQueryE, int time)
        {
            int error = Interop.SensorRecoder.RecorderQuerySetTime(recorderQuery, recorderQueryE, time);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error checking sensor recorder query set time");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderQuerySetTime Failed");
            }
        }

        /// <summary>
        ///  Queries the recorded data asynchronously.
        /// </summary>
        /// <param name="type">
        /// Sensor type.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void RecorderRead(Enum type)
        {
            _sensorRecorderDataCallBack = (Enum _type, Int64 data, int remains, Enum _error, Int64 _userData) =>
            {
                RecorderDataEventArgs e = new RecorderDataEventArgs(_type,data,remains,_error,_userData)
                {
                };
                RecorderDataReceived?.Invoke(null, e);
                Log.Debug(Globals.LogTag, "Recorder data callback recieved");
                return true;
            };

            int error = Interop.SensorRecoder.RecorderRead(type, recorderQuery, _sensorRecorderDataCallBack, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in reading recorder");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderRead Failed");
            }

        }

        /// <summary>
        ///  Starts to record a given sensor type.
        /// </summary>
        /// <param name="type">
        /// A sensor type to be recorded.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void RecorderStart(Enum type)
        {
            int error = Interop.SensorRecoder.RecorderStart(type, recorderOption);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in starting recorder");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderStart Failed");
            }

        }

        /// <summary>
        ///  Stops recording a given sensor type.
        /// </summary>
        /// <param name="type">
        /// A sensor type to be recorded.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void RecorderStop(Enum type)
        {
            int error = Interop.SensorRecoder.RecorderStop(type);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in starting recorder");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderStop Failed");
            }

        }

        /// <summary>
        ///  This function creates a sensor provider handle with a given URI.
        /// </summary>
        /// <param name="uri">
        /// The URI of sensor to be created.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void CreateProvider(string uri) {

            int error = Interop.SensorProvider.CreateProvider(uri,out _sensorProviderHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in creating sensor provider");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.CreateProvider Failed");
            }

        }

        /// <summary>
        /// Registers the sensor provider.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void AddProvider()
        {
            int error = Interop.SensorProvider.AddProvider(_sensorProviderHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in adding sensor provider");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.AddProvider Failed");
            }

        }

        /// <summary>
        /// Unregisters the sensor provider.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void RemoveProvider()
        {
            int error = Interop.SensorProvider.RemoveProvider(_sensorProviderHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in removing sensor provider");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RemoveProvider Failed");
            }

        }

        /// <summary>
        /// Releases all the resources allocated for the sensor provider.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void DestroyProvider()
        {
            int error = Interop.SensorProvider.DestroyProvider(_sensorProviderHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in destroying sensor provider");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.DestroyProvider Failed");
            }

        }


        /// <summary>
        ///  Sets the name to the sensor provider.
        /// </summary>
        /// <param name="name">
        /// The name of the sensor.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void ProviderSetName(string name)
        {
            int error = Interop.SensorProvider.ProviderSetName(_sensorProviderHandle, name);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in setting name of sensor provider");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.ProviderSetName Failed");
            }

        }

        /// <summary>
        /// Sets the vendor to the sensor provider.
        /// </summary>
        /// <param name="vendor">
        /// The vendor of the sensor.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void ProviderSetVendor(string vendor)
        {
            int error = Interop.SensorProvider.ProviderSetVendor(_sensorProviderHandle, vendor);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in setting vendor of sensor provider");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.ProviderSetVendor Failed");
            }

        }

        /// <summary>
        /// Sets the range of possible sensor values to the sensor provider.
        /// </summary>
        /// <param name="minRange">
        /// The lower bound.
        /// </param>
        /// <param name="maxRange">
        /// The upper bound.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void ProviderSetRange(float minRange, float maxRange)
        {
            int error = Interop.SensorProvider.ProviderSetRange(_sensorProviderHandle, minRange, maxRange);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in setting range of sensor provider");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.ProviderSetRange Failed");
            }

        }

        /// <summary>
        /// Sets the resolution of sensor values to the sensor provider.
        /// </summary>
        /// <param name="resolution">
        /// The resolution.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void ProviderSetResolution(float resolution)
        {
            int error = Interop.SensorProvider.ProviderSetResolution(_sensorProviderHandle, resolution);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in setting resolution of sensor provider");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.ProviderSetResolution Failed");
            }

        }

        /// <summary>
        /// Registers the callback function to be invoked when a listener starts the sensor provider.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void ProviderSetStartCb()
        {
            _sensorProviderStartCallBack = (IntPtr _provider, Int64 _userData) =>
            {
                ProviderStartEventArgs e = new ProviderStartEventArgs(_userData)
                {
                };
                ProviderStarted?.Invoke(null, e);  
            };

            int error = Interop.SensorProvider.ProviderSetStartCb(_sensorProviderHandle, _sensorProviderStartCallBack, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in setting start callback of sensor provider");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.ProviderSetStartCb Failed");
            }

        }

        /// <summary>
        /// Registers the callback function to be invoked when a sensor listener stops the sensor provider.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void ProviderSetStopCb()
        {
            _sensorProviderStopCallBack = (IntPtr _provider, Int64 _userData) =>
            {
                ProviderStopEventArgs e = new ProviderStopEventArgs(_userData)
                {
                };
                ProviderStoped?.Invoke(null, e);
            };

            int error = Interop.SensorProvider.ProviderSetStopCb(_sensorProviderHandle, _sensorProviderStopCallBack, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in setting stop callback of sensor provider");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.ProviderSetStopCb Failed");
            }

        }

        /// <summary>
        /// Registers the callback function to be invoked when the interval is changed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void ProviderSetIntervalChangedCb()
        {
            _sensorProviderIntervalChangedCallBack = (IntPtr _provider, uint IntervalMs, Int64 _userData) =>
            {
                ProviderIntervalChangedEventArgs e = new ProviderIntervalChangedEventArgs(_provider, IntervalMs, _userData)
                {
                };
                ProviderIntervalChanged?.Invoke(null, e);
            };

            int error = Interop.SensorProvider.ProviderSetIntervalChangedCb(_sensorProviderHandle, _sensorProviderIntervalChangedCallBack, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in setting interval callback of sensor provider");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.ProviderSetIntervalChangedCb Failed");
            }

        }

        /// <summary>
        /// Publishes a sensor event through the declared sensor.
        /// This function publishes a sensor's data to its listeners.
        /// </summary>
        /// <param name="sensorEventS">
        /// The sensor event.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void ProviderPublish(SensorEventStruct sensorEventS)
        {
            int error = Interop.SensorProvider.ProviderPublish(_sensorProviderHandle, sensorEventS);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in sensor provider publish");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.ProviderPublish Failed");
            }

        }

        /// <summary>
        /// Adds a callback function to be invoked when a new sensor is added.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void SetSensorAddedCB()
        {
            _sensorAddedCallBack = (String uri, Int64 _userData) =>
            {
                SensorAddedEventArgs e = new SensorAddedEventArgs(_userData)
                {
                };
                AddSensorAdded?.Invoke(null, e);
            };

            int error = Interop.SensorManager.AddSensorAddedCB(_sensorAddedCallBack, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in sensor add sensor added callback");
                throw SensorErrorFactory.CheckAndThrowException(error, "SensorManager.AddSensorAddedCB Failed");
            }

        }

        /// <summary>
        /// Adds a callback function to be invoked when a sensor is removed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void SetSensorRemovedCB()
        {
            _sensorRemovedCallBack = (String uri, Int64 _userData) =>
            {
                SensorRemovedEventArgs e = new SensorRemovedEventArgs(_userData)
                {
                };
                AddSensorRemoved?.Invoke(null, e);
            };

            int error = Interop.SensorManager.AddSensorRemovedCB(_sensorRemovedCallBack, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in sensor add sensor removed callback");
                throw SensorErrorFactory.CheckAndThrowException(error, "SensorManager.AddSensorRemovedCB Failed");
            }

        }

        /// <summary>
        /// Removes a callback function added using AddSensorRemovedCB()
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void UnsetSensorAddedCB()
        {
            _sensorAddedCallBack = (String uri, Int64 _userData) =>
            {
                SensorAddedEventArgs e = new SensorAddedEventArgs(_userData)
                {
                };
                RemoveSensorAdded?.Invoke(null, e);
            };

            int error = Interop.SensorManager.RemoveSensorAddedCB(_sensorAddedCallBack);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in sensor remove sensor added callback");
                throw SensorErrorFactory.CheckAndThrowException(error, "SensorManager.RemoveSensorAddedCB Failed");
            }

        }

        /// <summary>
        /// Removes a callback function added using AddSensorRemovedCB()
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void UnsetSensorRemovedCB()
        {
            _sensorRemovedCallBack = (String uri, Int64 _userData) =>
            {
                SensorRemovedEventArgs e = new SensorRemovedEventArgs(_userData)
                {
                };
                RemoveSensorRemoved?.Invoke(null, e);
            };

            int error = Interop.SensorManager.RemoveSensorRemovedCB(_sensorRemovedCallBack);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in sensor remove sensor removed callback");
                throw SensorErrorFactory.CheckAndThrowException(error, "SensorManager.RemoveSensorRemovedCB Failed");
            }

        }

    }
}
