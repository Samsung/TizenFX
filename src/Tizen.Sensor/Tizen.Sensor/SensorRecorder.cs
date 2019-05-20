using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Sensor
{
    public class SensorRecorder : IDisposable
    {
        internal IntPtr _optionHandle;
        internal IntPtr _queryHandle;
        private static Interop.SensorRecoder.SensorRecorderDataCb _sensorRecorderDataCallBack = null;
        /// <summary>
        /// RecorderDataReceived
        /// </summary>
        private static event EventHandler<RecorderDataEventArgs> RecorderDataReceived;

        internal SensorRecorder()
        {
            _optionHandle = IntPtr.Zero;
            _queryHandle = IntPtr.Zero;
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

        private bool CheckRecorderOption()
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

        private bool CheckRecorderQuery()
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
        private void RecorderCreateOption()
        {
            IntPtr handle;
            int error = Interop.SensorRecoder.RecorderCreateOption(out handle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error creating the sensor recorder option");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderCreateOption Failed");
            }

            OptionHandle = handle;
        }

        /// <summary>
        /// Creates a recorder query handle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        private void RecorderCreateQuery()
        {
            IntPtr handle;
            int error = Interop.SensorRecoder.RecorderCreateQuery(out handle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error creating the sensor recorder query");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderCreateQuery Failed");
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
        public double RecorderDataGetDouble(int data, int key)
        {
            double value;
            int error = Interop.SensorRecoder.RecorderDataGetDouble(data, key, out value);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting the sensor recorder double data");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderDataGetDouble Failed");
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
        public Tuple<long, long> RecorderDataGetTime(int data)
        {
            long startTime, endTime;

            int error = Interop.SensorRecoder.RecorderDataGetTime(data, out startTime, out endTime);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error getting the sensor recorder time");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderDataGetTime Failed");
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
        public bool RecorderIsSupported(int type)
        {
            bool isSupported;
            int error = Interop.SensorRecoder.RecorderIsSupported(type, out isSupported);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error checking if sensor recorder is supported");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderIsSupported Failed");
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
        public void RecorderOptionSetInt(int recorderOption, int value)
        {
            if (CheckRecorderOption())
            {
                int error = Interop.SensorRecoder.RecorderOptionSetInt(OptionHandle, recorderOption, value);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error checking sensor recorder option set int");
                    throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderOptionSetInt Failed");
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
        public void RecorderQuerySetInt(int recorderQuery, int value)
        {
            if (CheckRecorderQuery())
            {
                int error = Interop.SensorRecoder.RecorderQuerySetInt(QueryHandle, recorderQuery, value);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error checking sensor recorder query set int");
                    throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderQuerySetInt Failed");
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
        public void RecorderQuerySetTime(int recorderQuery, int time)
        {
            if (CheckRecorderQuery())
            {
                int error = Interop.SensorRecoder.RecorderQuerySetTime(QueryHandle, recorderQuery, time);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error checking sensor recorder query set time");
                    throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderQuerySetTime Failed");
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
        public void RecorderRead(int type)
        {
            if (CheckRecorderQuery())
            {
                _sensorRecorderDataCallBack = (int _type, int data, int remains, int _error, Int64 _userData) =>
                {
                    RecorderDataEventArgs e = new RecorderDataEventArgs(_type, data, remains, _error, _userData)
                    {
                    };

                    if (_error != 0)
                    {
                        Log.Error(Globals.LogTag, "Error in Sensor Recorder Data Read Synchronously CallBack");
                    }

                    RecorderDataReceived?.Invoke(null, e);
                    Log.Debug(Globals.LogTag, "Recorder data callback recieved");
                    return true;
                };

                int error = Interop.SensorRecoder.RecorderRead(type, QueryHandle, _sensorRecorderDataCallBack, IntPtr.Zero);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error in synchronously reading recorder");
                    throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderRead Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Recorder query is not created");
            }
        }

        private static void RecorderReader(int type, IntPtr QueryHandle, Interop.SensorRecoder.SensorRecorderDataCb Cb, IntPtr _userData)
        {
            int error = Interop.SensorRecoder.RecorderReadAsync(type, QueryHandle, Cb, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in asynchronously reading recorder");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderReadAsync Failed");
            }
        }
         
        /// <summary>
        ///  Queries the recorded data asynchronously.
        /// </summary>
        /// <param name="type">
        /// Sensor type.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public async Task RecorderReadAsync(int type)
        {
            if (CheckRecorderQuery())
            {
                _sensorRecorderDataCallBack = (int _type, int data, int remains, int _error, Int64 _userData) =>
                {
                    RecorderDataEventArgs e = new RecorderDataEventArgs(_type, data, remains, _error, _userData)
                    {
                    };

                    if (_error != 0)
                    {
                        Log.Error(Globals.LogTag, "Error in Sensor Recorder Data aynchronously CallBack");
                    }

                    RecorderDataReceived?.Invoke(null, e);
                    Log.Debug(Globals.LogTag, "Recorder data callback recieved");
                    return true;
                };

                await Task.Run(() => RecorderReader(type, QueryHandle, _sensorRecorderDataCallBack, IntPtr.Zero)).ConfigureAwait(false);
               
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
        public void RecorderStart(int type)
        {
            if (CheckRecorderOption())
            {
                int error = Interop.SensorRecoder.RecorderStart(type, OptionHandle);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error in starting recorder");
                    throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderStart Failed");
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
        public void RecorderStop(int type)
        {
            int error = Interop.SensorRecoder.RecorderStop(type);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in starting recorder");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderStop Failed");
            }

        }

        /// <summary>
        /// Destroys a recorder option handle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        private void RecorderDestroyOption()
        {
            if (CheckRecorderOption())
            {
                int error = Interop.SensorRecoder.RecorderDestroyOption(OptionHandle);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error deleting the sensor recorder option");
                    throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderDestroyOption Failed");
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
        private void RecorderDestroyQuery()
        {
            if (CheckRecorderQuery())
            {
                int error = Interop.SensorRecoder.RecorderDestroyQuery(QueryHandle);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error deleting the sensor recorder query");
                    throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RecorderDestroyQuery Failed");
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
            if (!disposing)
            {
                if (_optionHandle != IntPtr.Zero)
                {
                    Interop.SensorRecoder.RecorderDestroyOption(_optionHandle);
                    _optionHandle = IntPtr.Zero;
                }

                if (_queryHandle != IntPtr.Zero)
                {
                    Interop.SensorRecoder.RecorderDestroyQuery(_queryHandle);
                    _queryHandle = IntPtr.Zero;
                }
            }
        }

    }

}