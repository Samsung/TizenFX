/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Sensor
{
    /// <summary>
    /// The SensorRecorder is used for retrieving the recorded data from a particular sensor.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class SensorRecorder : IDisposable
    {
        internal IntPtr _optionHandle;
        internal IntPtr _queryHandle;
        private static Interop.SensorRecoder.SensorRecorderDataCb _sensorRecorderDataCallBack = null;
        /// <summary>
        /// RecorderDataReceived
        /// </summary>
        public static event EventHandler<RecorderDataEventArgs> DataReceived;

        /// <summary>
        /// SensorRecorder constructor.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public SensorRecorder()
        {
            _optionHandle = IntPtr.Zero;
            _queryHandle = IntPtr.Zero;
            CreateOption();
            CreateQuery();
        }

        /// <summary>
        /// SensorRecorder deconstructor.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ~SensorRecorder()
        {
            Dispose(false);
        }

        internal IntPtr OptionHandle
        {
            get
            {
                return _optionHandle;
            }

            set
            {
                _optionHandle = value;
            }
        }

        internal IntPtr QueryHandle
        {
            get
            {
                return _queryHandle;
            }

            set
            {
                _queryHandle = value;
            }
        }

        private bool CheckOption()
        {
            bool result = false;
            if (OptionHandle != IntPtr.Zero)
            {
                result = true;
            }
            else
            {
                Log.Error(Globals.LogTag, "Sensor Recorder Option is null");
                throw new ArgumentException("Invalid Parameter: Sensor Recorder Option is null");
            }
            return result;
        }

        private bool CheckQuery()
        {
            bool result = false;
            if (QueryHandle != IntPtr.Zero)
            {
                result = true;
            }
            else
            {
                Log.Error(Globals.LogTag, "Sensor Recorder Query is null");
                throw new ArgumentException("Invalid Parameter: Sensor Recorder Query is null");
            }
            return result;
        }

        /// <summary>
        /// Creates a recorder option handle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        private void CreateOption()
        {
            IntPtr handle;
            int error = Interop.SensorRecoder.CreateOption(out handle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error creating the sensor recorder option");
                throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorder.CreateOption Failed");
            }

            OptionHandle = handle;
        }

        /// <summary>
        /// Creates a recorder query handle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        private void CreateQuery()
        {
            IntPtr handle;
            int error = Interop.SensorRecoder.CreateQuery(out handle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error creating the sensor recorder query");
                throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorder.CreateQuery Failed");
            }

            QueryHandle = handle;
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
        /// <returns>
        /// returns a double value from a record data.
        /// </returns>
        /// <since_tizen> 6 </since_tizen>
        public double DataGetDouble(int data, int key)
        {
            double value;
            int error = Interop.SensorRecoder.DataGetDouble(data, key, out value);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting the sensor recorder double data");
                throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorder.DataGetDouble Failed");
            }
            return value;
        }

        /// <summary>
        /// Gets the start and the end time of the time period of a given record data.
        /// </summary>
        /// <param name="data">
        /// Record data handle.
        /// </param>
        /// <returns>
        /// returns the start and the end time of the time period of a given record data.
        /// </returns>
        /// <since_tizen> 6 </since_tizen>
        public Tuple<long, long> DataGetTime(int data)
        {
            long startTime, endTime;

            int error = Interop.SensorRecoder.DataGetTime(data, out startTime, out endTime);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting the sensor recorder time");
                throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorder.DataGetTime Failed");
            }

            Tuple<long, long> list = new Tuple<long, long>(startTime, endTime);
            return list;
        }

        /// <summary>
        /// Checks whether it is supported to record a given sensor type.
        /// </summary>
        /// <param name="type">
        /// A sensor type to check.
        /// </param>
        /// <returns>
        /// returns true if it is supported to record a given sensor type.
        /// </returns>
        /// <since_tizen> 6 </since_tizen>
        public bool IsSupported(int type)
        {
            bool isSupported;
            int error = Interop.SensorRecoder.IsSupported(type, out isSupported);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error checking if sensor recorder is supported");
                throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorder.IsSupported Failed");
            }
            return isSupported;
        }

        /// <summary>
        /// Sets a recording option parameter.
        /// </summary>
        /// <param name="recorderOption">
        /// Option parameter.
        /// </param>
        /// <param name="value">
        /// Value.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void OptionSetInt(int recorderOption, int value)
        {
            if (CheckOption())
            {
                int error = Interop.SensorRecoder.OptionSetInt(OptionHandle, recorderOption, value);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error checking sensor recorder option set int");
                    throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorder.OptionSetInt Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Recorder option is not created");
            }
        }

        /// <summary>
        ///  Sets an integer-type query parameter.
        /// </summary>
        /// <param name="recorderQuery">
        /// Query parameter.
        /// </param>
        /// <param name="value">
        /// Value.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void QuerySetInt(int recorderQuery, int value)
        {
            if (CheckQuery())
            {
                int error = Interop.SensorRecoder.QuerySetInt(QueryHandle, recorderQuery, value);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error checking sensor recorder query set int");
                    throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorder.QuerySetInt Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Recorder query is not created");
            }
        }

        /// <summary>
        ///  Sets a time-type query parameter.
        /// </summary>
        /// <param name="recorderQuery">
        /// Query parameter.
        /// </param>
        /// <param name="time">
        /// Time.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void QuerySetTime(int recorderQuery, int time)
        {
            if (CheckQuery())
            {
                int error = Interop.SensorRecoder.QuerySetTime(QueryHandle, recorderQuery, time);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error checking sensor recorder query set time");
                    throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorder.QuerySetTime Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Recorder query is not created");
            }
        }

        /// <summary>
        ///  Queries the recorded data synchronously.
        /// </summary>
        /// <param name="type">
        /// Sensor type.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void Read(int type)
        {
            if (CheckQuery())
            {
                _sensorRecorderDataCallBack = (int _type, int data, int remains, int _error, Int64 _userData) =>
                {
                    RecorderDataEventArgs e = new RecorderDataEventArgs(_type, data, remains, _error, _userData);

                    if (_error != (int)SensorError.None)
                    {
                        Log.Error(Globals.LogTag, "Error in Sensor Recorder Read synchronously CallBack");
                    }

                    DataReceived?.Invoke(null, e);
                    Log.Debug(Globals.LogTag, "Recorder data callback recieved");
                    return true;
                };

                int error = Interop.SensorRecoder.Read(type, QueryHandle, _sensorRecorderDataCallBack, IntPtr.Zero);

                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error in synchronously reading recorder");
                    throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorder.Read Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Recorder query is not created");
            }
        }

        private static void AsyncReader(int type, IntPtr QueryHandle, Interop.SensorRecoder.SensorRecorderDataCb Cb, IntPtr _userData)
        {
            int error = Interop.SensorRecoder.ReadAsync(type, QueryHandle, Cb, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in asynchronously reading recorder");
                throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorder.ReadAsync Failed");
            }
        }

        /// <summary>
        /// Queries the recorded data asynchronously.
        /// </summary>
        /// <param name="type">
        /// Sensor type.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public async Task ReadAsync(int type)
        {
            if (CheckQuery())
            {
                _sensorRecorderDataCallBack = (int _type, int data, int remains, int _error, Int64 _userData) =>
                {
                    RecorderDataEventArgs e = new RecorderDataEventArgs(_type, data, remains, _error, _userData);

                    if (_error != (int)SensorError.None)
                    {
                        Log.Error(Globals.LogTag, "Error in Sensor Recorder Data aynchronously CallBack");
                    }

                    DataReceived?.Invoke(null, e);
                    Log.Debug(Globals.LogTag, "Recorder data callback recieved");
                    return true;
                };

                await Task.Run(() => AsyncReader(type, QueryHandle, _sensorRecorderDataCallBack, IntPtr.Zero)).ConfigureAwait(false);

            }
            else
            {
                Log.Error(Globals.LogTag, "Recorder query is not created");
            }
        }

        /// <summary>
        ///  Starts to record a given sensor type.
        /// </summary>
        /// <param name="type">
        /// A sensor type to be recorded.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void Start(int type)
        {
            if (CheckOption())
            {
                int error = Interop.SensorRecoder.Start(type, OptionHandle);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error in starting recorder");
                    throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorder.Start Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Recorder option is not created");
            }
        }

        /// <summary>
        ///  Stops recording a given sensor type.
        /// </summary>
        /// <param name="type">
        /// A sensor type to be recorded.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void Stop(int type)
        {
            int error = Interop.SensorRecoder.Stop(type);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in stopping recorder");
                throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorder.Stop Failed");
            }

        }

        /// <summary>
        /// Destroys a recorder option handle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        private void DestroyOption()
        {
            if (CheckOption())
            {
                int error = Interop.SensorRecoder.DestroyOption(OptionHandle);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error deleting the sensor recorder option");
                    throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorder.DestroyOption Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Recorder option is not created");
            }
        }

        /// <summary>
        /// Destroys a recorder query handle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        private void DestroyQuery()
        {
            if (CheckQuery())
            {
                int error = Interop.SensorRecoder.DestroyQuery(QueryHandle);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error deleting the sensor recorder query");
                    throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorder.DestroyQuery Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Recorder query is not created");
            }
        }

        /// <summary>
        /// Overloaded Dispose API for destroying the SensorProvider Handle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose API for destroying the SensorProvider handle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="disposing">The boolean value for destoying SensorProvider handle.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_optionHandle != IntPtr.Zero)
                {
                    DestroyOption();
                    _optionHandle = IntPtr.Zero;
                }

                if (_queryHandle != IntPtr.Zero)
                {
                    DestroyQuery();
                    _queryHandle = IntPtr.Zero;
                }
            }
        }

    }

}