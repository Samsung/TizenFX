/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;

namespace Tizen.Pims.Calendar
{
    /// <summary>
    /// A record represents an actual record in the database.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    /// <remarks>
    /// A record represents an actual record in the database,
    /// but you can also consider it a piece of information, such as an alarm, attendee, and extended.
    /// A record can be a complex set of data, containing other data.
    /// For example, a calendar record contains the alarm property, which is a reference to an alarm record.
    /// An alarm record could belong to a event record,
    /// and its alarm ID property is set to the identifier of the corresponding event.
    /// In this case, the alarm is the child record of the event, and the event is the parent record.
    /// </remarks>
    public class CalendarRecord : IDisposable
    {
        internal string _uri;
        internal uint _id;
        private Int64 _memoryPressure = CalendarViews.Record.AverageSize;
        internal IntPtr _recordHandle;

        internal CalendarRecord(IntPtr handle)
        {
            _recordHandle = handle;

            IntPtr viewUri;
            int error = Interop.Record.GetUriPointer(handle, out viewUri);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "GetUriPointer Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            _uri = Marshal.PtrToStringAnsi(viewUri);
            GC.AddMemoryPressure(_memoryPressure);
        }

        internal CalendarRecord(IntPtr handle, bool disposedValue)
        {
            _recordHandle = handle;
            _disposedValue = disposedValue;

            IntPtr viewUri;
            int error = Interop.Record.GetUriPointer(handle, out viewUri);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "GetUriPointer Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            _uri = Marshal.PtrToStringAnsi(viewUri);
            if (!_disposedValue)
                GC.AddMemoryPressure(_memoryPressure);
        }

        internal CalendarRecord(IntPtr handle, int id)
        {
            _recordHandle = handle;
            _id = (uint)id;

            IntPtr viewUri;
            int error = Interop.Record.GetUriPointer(handle, out viewUri);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "GetUriPointer Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            _uri = Marshal.PtrToStringAnsi(viewUri);
            GC.AddMemoryPressure(_memoryPressure);
        }

        /// <summary>
        /// Creates a record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <param name="viewUri">The view URI.</param>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public CalendarRecord(string viewUri)
        {
            int error = 0;
            error = Interop.Record.Create(viewUri, out _recordHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "CalendarRecord Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            _uri = viewUri;
            GC.AddMemoryPressure(_memoryPressure);
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~CalendarRecord()
        {
            Dispose(false);
        }

#region IDisposable Support
        /// To detect redundant calls.
        internal bool _disposedValue = false;

        /// <summary>
        /// Disposes of the resources (other than memory) used by the CalendarRecord.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources, false to release only unmanaged resources.</param>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                Log.Debug(Globals.LogTag, "Dispose :" + disposing);

                int error = Interop.Record.Destroy(_recordHandle, false);
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "Destroy Failed with error " + error);
                }
                _disposedValue = true;
                GC.RemoveMemoryPressure(_memoryPressure);
            }
        }

        /// <summary>
        /// Releases all the resources used by the CalendarRecord.
        /// It should be called after it has finished using the object.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
#endregion

        internal static IntPtr ConvertCalendarTimeToStruct(CalendarTime value)
        {
            Console.WriteLine("convert calendar");
            IntPtr caltime = Interop.Record.CreateCalTime();
            Interop.Record.SetCalTimeType(caltime, value._type);

            if ((int)CalendarTime.Type.Utc == value._type)
            {
                DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0);
                Interop.Record.SetCalTimeUtime(caltime, (value.UtcTime.Ticks - epoch.Ticks) / 10_000_000);
                //Log.Debug(Globals.LogTag, "Sameer local time is if:" + Interop.Record.GetCalTimeLocalMonth(caltime) + "," + Interop.Record.GetCalTimeLocalMday(caltime) + "," + Interop.Record.GetCalTimeLocalHour(caltime) + "," + Interop.Record.GetCalTimeLocalMinute(caltime));

            }
            else
            {
                Interop.Record.SetCalTimeLocalYear(caltime, value.LocalTime.Year);
                Interop.Record.SetCalTimeLocalMonth(caltime, value.LocalTime.Month);
                Interop.Record.SetCalTimeLocalMday(caltime, value.LocalTime.Day);
                Interop.Record.SetCalTimeLocalHour(caltime, value.LocalTime.Hour);
                Interop.Record.SetCalTimeLocalMinute(caltime, value.LocalTime.Minute);
                Interop.Record.SetCalTimeLocalSecond(caltime, value.LocalTime.Second);
                //Log.Debug(Globals.LogTag, "Sameer local time is:" + Interop.Record.GetCalTimeLocalHour(caltime) + "," + Interop.Record.GetCalTimeLocalMinute(caltime));
            }
            return caltime;
        }

        internal static CalendarTime ConvertIntPtrToCalendarTime(IntPtr caltime)
        {
            CalendarTime value;
            if ((int)CalendarTime.Type.Utc == Interop.Record.GetCalTimeType(caltime))
            {
                DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0);
                value = new CalendarTime(Interop.Record.GetCalTimeUtime(caltime) * 10_000_000 + epoch.Ticks);
            }
            else
            {
                value = new CalendarTime(Interop.Record.GetCalTimeLocalYear(caltime), Interop.Record.GetCalTimeLocalMonth(caltime), Interop.Record.GetCalTimeLocalMday(caltime),
                    Interop.Record.GetCalTimeLocalHour(caltime), Interop.Record.GetCalTimeLocalMinute(caltime), Interop.Record.GetCalTimeLocalSecond(caltime));
            }
            value._type = Interop.Record.GetCalTimeType(caltime);
            return value;
        }

        /// <summary>
        /// Makes a clone of a record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <returns>
        /// A cloned record.
        /// </returns>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        public CalendarRecord Clone()
        {
            IntPtr _clonedRecordHandle;
            int error = Interop.Record.Clone(_recordHandle, out _clonedRecordHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "Clone Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            return new CalendarRecord(_clonedRecordHandle, (int)_id);
        }

        /// <summary>
        /// Get record URI.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <value>The URI of the record</value>
        [SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        public string Uri
        {
            get
            {
                return _uri;
            }
        }

        /// <summary>
        /// Gets a object from a record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="propertyId">The property ID</param>
        /// <returns>
        /// The value of the property corresponding to property id.
        /// </returns>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        public T Get<T>(uint propertyId)
        {
            object parsedValue = null;
            if (typeof(T) == typeof(string))
            {
                string val;
                int error = Interop.Record.GetString(_recordHandle, propertyId, out val);
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "Get String Failed [" + error + "]" + String.Format("{0:X}", propertyId));
                    throw CalendarErrorFactory.GetException(error);
                }
                parsedValue = Convert.ChangeType(val, typeof(T));
            }
            else if (typeof(T) == typeof(int))
            {
                int val;
                int error = Interop.Record.GetInteger(_recordHandle, propertyId, out val);
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "Get Intger Failed [" + error + "]" + String.Format("{0:X}", propertyId));
                    throw CalendarErrorFactory.GetException(error);
                }
                parsedValue = Convert.ChangeType(val, typeof(T));
            }
            else if (typeof(T) == typeof(long))
            {
                long val;
                int error = Interop.Record.GetLli(_recordHandle, propertyId, out val);
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "Get Long Failed [" + error + "]" + String.Format("{0:X}", propertyId));
                    throw CalendarErrorFactory.GetException(error);
                }
                parsedValue = Convert.ChangeType(val, typeof(T));
            }
            else if (typeof(T) == typeof(double))
            {
                double val;
                int error = Interop.Record.GetDouble(_recordHandle, propertyId, out val);
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "Get Double Failed [" + error + "]" + String.Format("{0:X}", propertyId));
                    throw CalendarErrorFactory.GetException(error);
                }
                parsedValue = Convert.ChangeType(val, typeof(T));
            }
            else if (typeof(T) == typeof(CalendarTime))
            {
                IntPtr time;
                int error = Interop.Record.GetCalTime(_recordHandle, propertyId, out time);
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "Get CalendarTime Failed [" + error + "]" + String.Format("{0:X}", propertyId));
                    throw CalendarErrorFactory.GetException(error);
                }
                CalendarTime val = ConvertIntPtrToCalendarTime(time);
                parsedValue = Convert.ChangeType(val, typeof(T));
            }
            else
            {
                Log.Error(Globals.LogTag, "Not supported Data T/ype");
                throw CalendarErrorFactory.GetException((int)CalendarError.NotSupported);
            }
            return (T)parsedValue;
        }

        /// <summary>
        /// Sets a value of the property to a record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="propertyId">The property ID</param>
        /// <param name="value">value</param>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        public void Set<T>(uint propertyId, T value)
        {
            if (typeof(T) == typeof(string))
            {
                string val = Convert.ToString(value);
                int error = Interop.Record.SetString(_recordHandle, propertyId, val);
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "Set String Failed [" + error + "]" + String.Format("{0:X}", propertyId));
                    throw CalendarErrorFactory.GetException(error);
                }
            }
            else if (typeof(T) == typeof(int))
            {
                int val = Convert.ToInt32(value);
                int error = Interop.Record.SetInteger(_recordHandle, propertyId, val);
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "Set Integer Failed [" + error + "]" + String.Format("{0:X}", propertyId));
                    throw CalendarErrorFactory.GetException(error);
                }
            }
            else if (typeof(T) == typeof(long))
            {
                long val = Convert.ToInt64(value);
                int error = Interop.Record.SetLli(_recordHandle, propertyId, val);
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "Set Long Failed [" + error + "]" + String.Format("{0:X}", propertyId));
                    throw CalendarErrorFactory.GetException(error);
                }
            }
            else if (typeof(T) == typeof(double))
            {
                double val = Convert.ToDouble(value);
                int error = Interop.Record.SetDouble(_recordHandle, propertyId, val);
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "Set Double Failed [" + error + "]" + String.Format("{0:X}", propertyId));
                    throw CalendarErrorFactory.GetException(error);
                }
            }
            else if (typeof(T) == typeof(CalendarTime))
            {
                CalendarTime time = (CalendarTime)Convert.ChangeType(value, typeof(CalendarTime));
                //Interop.Record.DateTime val = ConvertCalendarTimeToStruct(time);
                IntPtr val = ConvertCalendarTimeToStruct(time);
                //int error = Interop.Record.SetCalendarTime(_recordHandle, propertyId, val);
                int error = Interop.Record.SetCalTime(_recordHandle, propertyId, val);
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "Set CalendarTime Failed [" + error + "]" + String.Format("{0:X}", propertyId));
                    throw CalendarErrorFactory.GetException(error);
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Not supported Data T/ype");
                throw CalendarErrorFactory.GetException((int)CalendarError.NotSupported);
            }
        }

        /// <summary>
        /// Adds a child record to the parent record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="propertyId">The property ID.</param>
        /// <param name="childRecord">The child record.</param>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        public void AddChildRecord(uint propertyId, CalendarRecord childRecord)
        {
            int error = Interop.Record.AddChildRecord(_recordHandle, propertyId, childRecord._recordHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "AddChildRecord Failed [" + error + "]" + String.Format("{0:X}", propertyId));
                throw CalendarErrorFactory.GetException(error);
            }
            childRecord._disposedValue = true;
        }

        /// <summary>
        /// Removes a child record from the parent record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="propertyId">The property ID.</param>
        /// <param name="childRecord">The child record.</param>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        public void RemoveChildRecord(uint propertyId, CalendarRecord childRecord)
        {
            int error = Interop.Record.RemoveChildRecord(_recordHandle, propertyId, childRecord._recordHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "RemoveChildRecord Failed [" + error + "]" + String.Format("{0:X}", propertyId));
                throw CalendarErrorFactory.GetException(error);
            }
            childRecord._disposedValue = false;
        }

        /// <summary>
        /// Gets a child record from the parent record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="propertyId">The property ID.</param>
        /// <returns>
        /// The number of child records corresponding to property ID.
        /// </returns>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        public int GetChildRecordCount(uint propertyId)
        {
            int count = 0;
            int error = Interop.Record.GetChildRecordCount(_recordHandle, propertyId, out count);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "GetChildRecordCount Failed [" + error + "]" + String.Format("{0:X}", propertyId));
                throw CalendarErrorFactory.GetException(error);
            }
            return count;
        }

        /// <summary>
        /// Gets a child record from the parent record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="propertyId">The property ID.</param>
        /// <param name="index">The child record index.</param>
        /// <returns>
        /// The record.
        /// </returns>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        public CalendarRecord GetChildRecord(uint propertyId, int index)
        {
            IntPtr handle;

            int error = Interop.Record.GetChildRecordPointer(_recordHandle, propertyId, index, out handle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "GetChildRecord Failed [" + error + "]" + String.Format("{0:X}", propertyId));
                throw CalendarErrorFactory.GetException(error);
            }
            return new CalendarRecord(handle, true);
        }

        /// <summary>
        /// Clones a child record list corresponding to property ID.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="propertyId">The property ID.</param>
        /// <returns>
        /// The record list.
        /// </returns>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        public CalendarList CloneChildRecordList(uint propertyId)
        {
            IntPtr listHandle;
            int error = Interop.Record.CloneChildRecordList(_recordHandle, propertyId, out listHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "CloneChildRecordList Failed with [" + error + "]" + String.Format("{0:X}", propertyId));
                throw CalendarErrorFactory.GetException(error);
            }
            CalendarList list = new CalendarList(listHandle);
            return list;
        }
    }
}
