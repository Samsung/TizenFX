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
    /// The RecordTimePeriod is used to represent the start and end time of the time period of a given record data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public struct RecordTimePeriod : IEquatable<RecordTimePeriod>
    {
        /// <summary>
        /// Initializes a new instance of the RecordTimePeriod with the specified values.
        /// </summary>
        /// <param name="startTime">The start time of the time period of a given record data.</param>
        /// <param name="endTime">The end time of the time period of a given record data.</param>
        /// <since_tizen> 6 </since_tizen>
        public RecordTimePeriod(long startTime, long endTime)
        {
            this.startTime = startTime;
            this.endTime = endTime;
        }

        /// <summary>
        /// Gets or sets the start time of the time period of a given record data.
        /// </summary>
        /// <value>The start time of the time period of a given record data.</value>
        /// <since_tizen> 6 </since_tizen>
        public long startTime { get; set; }

        /// <summary>
        /// Gets or sets the end time of the time period of a given record data.
        /// </summary>
        /// <value>The end time of the time period of a given record data.</value>
        /// <since_tizen> 6 </since_tizen>
        public long endTime { get; set; }

        /// <summary>
        /// Returns the hash code for this RecordTimePeriod structure.
        /// </summary>
        /// <returns>An integer that represents the hash code for this RecordTimePeriod.</returns>
        /// <since_tizen> 6 </since_tizen>
        public override int GetHashCode() => new { startTime, endTime }.GetHashCode();

        /// <summary>
        /// Tests whether object is a RecordTimePeriod structure with the same startTime and endTime of this RecordTimePeriod structure.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to compare.</param>
        /// <returns>
        /// true if object is a RecordTimePeriod structure and its startTime and endTime properties are
        /// equal to the corresponding properties of this RecordTimePeriod structure; otherwise, false.
        /// </returns>
        /// <since_tizen> 6 </since_tizen>
        public override bool Equals(object obj) => obj is RecordTimePeriod && this == (RecordTimePeriod)obj;

        /// <summary>
        /// Tests whether two RecordTimePeriod structures have equal startTime and endTime.
        /// </summary>
        /// <param name="rec1">The <see cref="RecordTimePeriod"/> to compare.</param>
        /// <param name="rec2">The <see cref="RecordTimePeriod"/> to compare.</param>
        /// <returns>true if the two RecordTimePeriod structures have equal startTime and endTime; otherwise, false.</returns>
        /// <since_tizen> 6 </since_tizen>
        public static bool operator ==(RecordTimePeriod rec1, RecordTimePeriod rec2)
            => rec1.startTime == rec2.startTime && rec1.endTime == rec2.endTime;

        /// <summary>
        /// Tests whether two RecordTimePeriod structures differ in startTime or endTime.
        /// </summary>
        /// <param name="rec1">The <see cref="RecordTimePeriod"/> to compare.</param>
        /// <param name="rec2">The <see cref="RecordTimePeriod"/> to compare.</param>
        /// <returns>true if one of the startTime, or endTime properties of the two RecordTimePeriod structures are unequal; otherwise false.</returns>
        /// <since_tizen> 6 </since_tizen>
        public static bool operator !=(RecordTimePeriod rec1, RecordTimePeriod rec2) => !(rec1 == rec2);

        /// <summary>
        /// Returns a boolean indicating whether the given RecordTimePeriod is equal to this RecordTimePeriod instance.
        /// </summary>
        /// <param name="other">The RecordTimePeriod to compare this instance to.</param>
        /// <returns>True if the other RecordTimePeriod is equal to this instance; False otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool Equals(RecordTimePeriod other)
        {
            if (other == null)
                return false;

            if (startTime == other.startTime && endTime == other.endTime)
                return true;
            else
                return false;
        }
    }

    /// <summary>
    /// The SensorRecorderDataManager class is used for retrieving the pre-recorded from database. 
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public abstract class SensorRecorderDataManager : SensorRecorderManager
    {
        private bool _disposed = false;
        internal IntPtr _queryHandle;
        internal IntPtr _dataHandle;
        private Interop.SensorRecoder.SensorRecorderDataCb _sensorRecorderDataCallBack = null;

        internal SensorRecorderDataManager() {
            _queryHandle = IntPtr.Zero;
            _dataHandle = IntPtr.Zero;
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

        internal IntPtr DataHandle
        {
            get
            {
                return _dataHandle;
            }

            set
            {
                _dataHandle = value;
            }
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

        private bool CheckDataHandle()
        {
            bool result = false;
            if (DataHandle != IntPtr.Zero)
            {
                result = true;
            }
            else
            {
                Log.Error(Globals.LogTag, "Sensor Recorder Data is null");
                throw new ArgumentException("Invalid Parameter: Sensor Recorder Data is null");
            }
            return result;
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
        /// <param name="key">
        /// Data attribute to retrieve.
        /// </param>
        /// <returns>
        /// returns a double value from a record data.
        /// </returns>
        /// <since_tizen> 6 </since_tizen>
        public double DataGetDouble(RecorderData key)
        {
            double value = -1;
            if (CheckDataHandle())
            {
                int error = Interop.SensorRecoder.DataGetDouble(DataHandle, key, out value);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error getting the sensor recorder double data");
                    throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorder.DataGetDouble Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Recorder data is not created");
            }

            return value;
        }

        /// <summary>
        /// Gets the start and the end time of the time period of a given record data.
        /// </summary>
        /// <returns>
        /// returns the start and the end time of the time period of a given record data.
        /// </returns>
        /// <since_tizen> 6 </since_tizen>
        public RecordTimePeriod DataGetTime()
        {
            long startTime = -1, endTime = -1;
            if (CheckDataHandle()) {
                int error = Interop.SensorRecoder.DataGetTime(DataHandle, out startTime, out endTime);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error getting the sensor recorder time");
                    throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorder.DataGetTime Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Recorder data is not created");
            }

            return new RecordTimePeriod(startTime, endTime);
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
        public void QuerySetInt(RecorderQuery recorderQuery, int value)
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
        public void QuerySetTime(RecorderQuery recorderQuery, int time)
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
        /// <since_tizen> 6 </since_tizen>
        public void Read()
        {
            if (CheckQuery())
            {
                _sensorRecorderDataCallBack = (SensorType _type, IntPtr dataHandle, int remains, int _error, Int64 _userData) =>
                {
                    if (_error != (int)SensorError.None)
                    {
                        Log.Error(Globals.LogTag, "Error in Sensor Recorder Read synchronously CallBack");
                    }
                    else
                    {
                        DataHandle = dataHandle;
                    }

                    Log.Debug(Globals.LogTag, "Recorder data callback recieved");
                    return true;
                };

                int error = Interop.SensorRecoder.Read(sensorType, QueryHandle, _sensorRecorderDataCallBack, IntPtr.Zero);

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

        private void AsyncReader(IntPtr QueryHandle, Interop.SensorRecoder.SensorRecorderDataCb Cb, IntPtr _userData)
        {
            int error = Interop.SensorRecoder.ReadAsync(sensorType, QueryHandle, Cb, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in asynchronously reading recorder");
                throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorder.ReadAsync Failed");
            }
        }

        /// <summary>
        /// Queries the recorded data asynchronously.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public async Task ReadAsync()
        {
            if (CheckQuery())
            {
                TaskCompletionSource<IntPtr> tcs = new TaskCompletionSource<IntPtr>();

                _sensorRecorderDataCallBack = (SensorType _type, IntPtr dataHandle, int remains, int _error, Int64 _userData) =>
                {
                    if (_error != (int)SensorError.None)
                    {
                        Log.Error(Globals.LogTag, "Error in Sensor Recorder Data CallBack");
                        tcs.SetException(new Exception("Error in Sensor Recorder Data CallBack"));
                    }
                    else
                    {
                        tcs.SetResult(dataHandle);
                    }

                    Log.Debug(Globals.LogTag, "Recorder data callback recieved");
                    return true;
                };
          
                await Task.Run(() => AsyncReader(QueryHandle, _sensorRecorderDataCallBack, IntPtr.Zero)).ConfigureAwait(false);
                DataHandle = await tcs.Task.ConfigureAwait(false);
            }
            else
            {
                Log.Error(Globals.LogTag, "Recorder query is not created");
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

        private void DestroyHandles()
        {
            if (_queryHandle != IntPtr.Zero)
            {
                DestroyQuery();
                _queryHandle = IntPtr.Zero;
            }

            if (_dataHandle != IntPtr.Zero)
            {
                _dataHandle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Releases all resources currently used by this instance.
        /// </summary>
        /// <param name="disposing">
        /// true if managed resources should be disposed
        /// otherwise, false.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        protected override void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            DestroyHandles();
            base.Dispose(disposing);
            _disposed = true;
        }
    }
}
