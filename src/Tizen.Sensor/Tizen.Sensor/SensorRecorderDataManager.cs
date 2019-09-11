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
    /// An interface for building recorder query
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public interface IQueryBuilder
    {
        /// <summary>
        ///  Sets a start time query parameter.
        /// </summary>
        /// <param name="time">
        /// Time.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        void SetStartTime(int time);

        /// <summary>
        ///  Sets end time query parameter.
        /// </summary>
        /// <param name="time">
        /// Time.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        void SetEndTime(int time);

        /// <summary>
        ///  Sets anchor time query parameter.
        /// </summary>
        /// <param name="time">
        /// Time.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        void SetAnchorTime(int time);

        /// <summary>
        ///  Sets an interval query parameter.
        /// </summary>
        /// <param name="value">
        /// Value.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        void SetInterval(int value);

        /// <summary>
        /// gets the QueryHandle object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Query getQuery();
    }

    /// <summary>
    /// This class is used to set query parameters
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class QueryBuilder : IQueryBuilder
    {

        private Query query;

        /// <summary>
        /// Initializes a new instance of the QueryBuilder class.
        /// </summary>
        public QueryBuilder()
        {
            query = new Query();
            CreateQuery();
        }

        /// <summary>
        /// Destroy the QueryBuilder object.
        /// </summary>
        ~QueryBuilder()
        {
            DestroyQuery();
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
                throw SensorErrorFactory.CheckAndThrowException(error, "QueryBuilder.CreateQuery Failed");
            }

            query.queryHandle = handle;
        }

        /// <summary>
        /// Destroys a recorder query handle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        private void DestroyQuery()
        {
            if (query != null)
            {
                int error = Interop.SensorRecoder.DestroyQuery(query.queryHandle);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error deleting the sensor recorder query");
                    throw SensorErrorFactory.CheckAndThrowException(error, "QueryBuilder.DestroyQuery Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Recorder query is not created");
            }
        }

        /// <summary>
        ///  Sets start time query parameter.
        /// </summary>
        /// <param name="time">
        /// Time.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void SetStartTime(int time)
        {
            if (query != null)
            {
                int error = Interop.SensorRecoder.QuerySetTime(query.queryHandle, RecorderQuery.StartTime, time);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error checking sensor recorder query set time");
                    throw SensorErrorFactory.CheckAndThrowException(error, "QueryBuilder.SetStartTime Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Recorder query is not created");
            }
        }

        /// <summary>
        ///  Sets end time query parameter.
        /// </summary>
        /// <param name="time">
        /// Time.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void SetEndTime(int time)
        {
            if (query != null)
            {
                int error = Interop.SensorRecoder.QuerySetTime(query.queryHandle, RecorderQuery.EndTime, time);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error checking sensor recorder query set time");
                    throw SensorErrorFactory.CheckAndThrowException(error, "QueryBuilder.SetEndTime Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Recorder query is not created");
            }
        }

        /// <summary>
        ///  Sets anchor time query parameter.
        /// </summary>
        /// <param name="time">
        /// Time.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void SetAnchorTime(int time)
        {
            if (query != null)
            {
                int error = Interop.SensorRecoder.QuerySetTime(query.queryHandle, RecorderQuery.AnchorTime, time);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error checking sensor recorder query set time");
                    throw SensorErrorFactory.CheckAndThrowException(error, "QueryBuilder.SetAnchorTime Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Recorder query is not created");
            }
        }

        /// <summary>
        ///  Sets an interval query parameter.
        /// </summary>
        /// <param name="value">
        /// Value.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void SetInterval(int value)
        {
            if (query != null)
            {
                int error = Interop.SensorRecoder.QuerySetInt(query.queryHandle, RecorderQuery.TimeInterval, value);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error checking sensor recorder query set int");
                    throw SensorErrorFactory.CheckAndThrowException(error, "QueryBuilder.SetInterval Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Recorder query is not created");
            }
        }

        /// <summary>
        /// gets the QueryHandle object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Query getQuery()
        {
            return query;
        }
    }

    /// <summary>
    /// This class provides the query handle.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class Query
    {
        /// <summary>
        /// Property: Gets the queryHandle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The query handle </value>
        public IntPtr queryHandle { set; get; }
    }


    /// <summary>
    /// The SensorRecorderDataManager class is used for retrieving the pre-recorded from database. 
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class SensorRecorderDataManager : IDisposable
    {
        private bool _disposed = false;
        private int sensorType;
        private IntPtr dataHandle;
        private Interop.SensorRecoder.SensorRecorderDataCb _sensorRecorderDataCallBack = null;

        /// <summary>
        /// signal to notify user about updated dataHandle
        /// </summary>
        public event EventHandler<RecorderDataEventArgs> DataReceived;

        /// <summary>
        /// Initializes a new instance of the SensorRecorderDataManager class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name='type'>
        /// type refers to sensor type
        /// </param>
        public SensorRecorderDataManager(int type)
        {

            sensorType = type;

            if (IsSupported())
            {
                throw new NotSupportedException(" recorder is not supported.");
            }

            dataHandle = IntPtr.Zero;
        }

        /// <summary>
        /// SensorRecorderDataManager deconstructor.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ~SensorRecorderDataManager()
        {
            Dispose(false);
        }

        private bool CheckDataHandle()
        {
            bool result = false;
            if (dataHandle != IntPtr.Zero)
            {
                result = true;
            }
            else
            {
                Log.Error(Globals.LogTag, "Sensor Recorder Data handle is null");
                throw new ArgumentException("Invalid Parameter: Sensor Recorder Data handle is null");
            }
            return result;
        }

        private bool IsSupported()
        {
            bool isSupported;
            int error = Interop.SensorRecoder.IsSupported(sensorType, out isSupported);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error checking if sensor recorder is supported");
                throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorderDataManager.IsSupported Failed");
            }
            return isSupported;
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
                int error = Interop.SensorRecoder.DataGetDouble(dataHandle, key, out value);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error getting the sensor recorder double data");
                    throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorderDataManager.DataGetDouble Failed");
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
            if (CheckDataHandle())
            {
                int error = Interop.SensorRecoder.DataGetTime(dataHandle, out startTime, out endTime);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error getting the sensor recorder time");
                    throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorderDataManager.DataGetTime Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Recorder data is not created");
            }

            return new RecordTimePeriod(startTime, endTime);
        }

        /// <summary>
        ///  Queries the recorded data synchronously and updates the data handle
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Update(Query query)
        {
            _sensorRecorderDataCallBack = (SensorType _type, IntPtr _dataHandle, int remains, int _error, Int64 _userData) =>
            {
                if (_error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error in Update synchronously CallBack");
                }
                else
                {
                    dataHandle = _dataHandle;
                }

                Log.Debug(Globals.LogTag, "Recorder data callback recieved");
                return true;
            };

            int error = Interop.SensorRecoder.Read(sensorType, query.queryHandle, _sensorRecorderDataCallBack, IntPtr.Zero);

            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in synchronously updating data handle");
                throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorderDataManager.update Failed");
            }
        }

        private void AsyncUpdater(IntPtr QueryHandle, Interop.SensorRecoder.SensorRecorderDataCb Cb, IntPtr _userData)
        {
            int error = Interop.SensorRecoder.ReadAsync(sensorType, QueryHandle, Cb, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in asynchronously updating data handle");
                throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorderDataManager.AsyncUpdater Failed");
            }
        }

        /// <summary>
        /// Queries the recorded data asynchronously and updates the data handle
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public async Task UpdateAsync(Query query)
        {
            TaskCompletionSource<IntPtr> tcs = new TaskCompletionSource<IntPtr>();

            _sensorRecorderDataCallBack = (SensorType _type, IntPtr _dataHandle, int remains, int _error, Int64 _userData) =>
            {
                RecorderDataEventArgs e = new RecorderDataEventArgs();
                if (_error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error in Update synchronously CallBack");
                    tcs.SetException(new Exception("Error in Update synchronously CallBack"));
                }
                else
                {
                    tcs.SetResult(_dataHandle);
                }

                DataReceived?.Invoke(null, e);
                Log.Debug(Globals.LogTag, "Recorder data callback recieved");
                return true;
            };

            await Task.Run(() => AsyncUpdater(query.queryHandle, _sensorRecorderDataCallBack, IntPtr.Zero)).ConfigureAwait(false);
            dataHandle = await tcs.Task.ConfigureAwait(false);
        }

        /// <summary>
        /// Destroy the current object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all resources currently used by this instance.
        /// </summary>
        /// <param name="disposing">
        /// true if managed resources should be disposed
        /// otherwise, false.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (dataHandle != IntPtr.Zero)
            {
                dataHandle = IntPtr.Zero;
            }
            _disposed = true;
        }
    }
}
