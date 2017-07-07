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
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tizen.Pims.Calendar
{
    /// <summary>
    /// A record represents an actual record in the database
    /// </summary>
    /// <remarks>
    /// A record represents an actual record in the database,
    /// but you can also consider it a piece of information, such as an alarm, attendee and extended.
    /// A record can be a complex set of data, containing other data.
    /// For example, a calendar record contains the alarm property, which is a reference to an alarm record.
    /// An alarm record could belong to a event record,
    /// and its alarm id property is set to the identifier of the corresponding event.
    /// In this case, the alarm is the child record of the event and the event is the parent record.
    /// </remarks>
    public class CalendarRecord : IDisposable
    {
        internal string _uri;
        internal uint _id;
        private Int64 _memoryPressure = CalendarViews.AverageSizeOfRecord;
        internal IntPtr _recordHandle;

        internal CalendarRecord(IntPtr handle)
        {
            _recordHandle = handle;

            IntPtr viewUri;
            int error = Interop.Calendar.Record.GetUriPointer(handle, out viewUri);
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
            int error = Interop.Calendar.Record.GetUriPointer(handle, out viewUri);
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
            int error = Interop.Calendar.Record.GetUriPointer(handle, out viewUri);
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
        /// <param name="viewUri">The view URI</param>
        /// <exception cref="NotSupportedException">Thrown when an invoked method is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        public CalendarRecord(string viewUri)
        {
            int error = 0;
            error = Interop.Calendar.Record.Create(viewUri, out _recordHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "CalendarRecord Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            _uri = viewUri;
            GC.AddMemoryPressure(_memoryPressure);
        }

        ~CalendarRecord()
        {
            Dispose(false);
        }

#region IDisposable Support
        /// To detect redundant calls
        internal bool _disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                Log.Debug(Globals.LogTag, "Dispose :" + disposing);

                int error = Interop.Calendar.Record.Destroy(_recordHandle, false);
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "Destroy Failed with error " + error);
                    throw CalendarErrorFactory.GetException(error);
                }
                _disposedValue = true;
                GC.RemoveMemoryPressure(_memoryPressure);
            }
        }

        /// <summary>
        /// Releases all resources used by the CalendarRecord.
        /// It should be called after finished using of the object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
#endregion

        internal static Interop.Calendar.Record.DateTime ConvertCalendarTimeToStruct(CalendarTime value)
        {
            Interop.Calendar.Record.DateTime time = new Interop.Calendar.Record.DateTime();
            time.type = value._type;

            if ((int)CalendarTime.Type.Utc == value._type)
            {
                DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0);
                time.utime = (value.UtcTime.Ticks - epoch.Ticks) / 10000000;
            }
            else
            {
                time.year = value.LocalTime.Year;
                time.month = value.LocalTime.Month;
                time.mday = value.LocalTime.Day;
                time.hour = value.LocalTime.Hour;
                time.minute = value.LocalTime.Minute;
                time.second = value.LocalTime.Second;
            }
            return time;
        }

        internal static CalendarTime ConvertIntPtrToCalendarTime(Interop.Calendar.Record.DateTime time)
        {
            CalendarTime value;
            if ((int)CalendarTime.Type.Utc == time.type)
            {
                DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0);
                value = new CalendarTime(time.utime * 10000000 + epoch.Ticks);
            }
            else
            {
                value = new CalendarTime(time.year, time.month, time.mday, time.hour, time.minute, time.second);
            }
            value._type = time.type;
            return value;
        }

        /// <summary>
        /// Makes a clone of a record.
        /// </summary>
        /// <returns>
        /// A cloned record
        /// </returns>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        public CalendarRecord Clone()
        {
            IntPtr _clonedRecordHandle;
            int error = Interop.Calendar.Record.Clone(_recordHandle, out _clonedRecordHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "Clone Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            return new CalendarRecord(_clonedRecordHandle, (int)_id);
        }

        /// <summary>
        /// The URI of the record
        /// </summary>
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
        /// <param name="propertyId">The property ID</param>
        /// <returns>
        /// The value of the property corresponding to property id.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        public T Get<T>(uint propertyId)
        {
            object parsedValue = null;
            if (typeof(T) == typeof(string))
            {
                string val;
                int error = Interop.Calendar.Record.GetString(_recordHandle, propertyId, out val);
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
                int error = Interop.Calendar.Record.GetInteger(_recordHandle, propertyId, out val);
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
                int error = Interop.Calendar.Record.GetLli(_recordHandle, propertyId, out val);
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
                int error = Interop.Calendar.Record.GetDouble(_recordHandle, propertyId, out val);
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "Get Double Failed [" + error + "]" + String.Format("{0:X}", propertyId));
                    throw CalendarErrorFactory.GetException(error);
                }
                parsedValue = Convert.ChangeType(val, typeof(T));
            }
            else if (typeof(T) == typeof(CalendarTime))
            {
                Interop.Calendar.Record.DateTime time;
                int error = Interop.Calendar.Record.GetCalendarTime(_recordHandle, propertyId, out time);
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
        /// <param name="propertyId">The property ID</param>
        /// <param name="value">value</param>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        public void Set<T>(uint propertyId, T value)
        {
            if (typeof(T) == typeof(string))
            {
                string val = Convert.ToString(value);
                int error = Interop.Calendar.Record.SetString(_recordHandle, propertyId, val);
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "Set String Failed [" + error + "]" + String.Format("{0:X}", propertyId));
                    throw CalendarErrorFactory.GetException(error);
                }
            }
            else if (typeof(T) == typeof(int))
            {
                int val = Convert.ToInt32(value);
                int error = Interop.Calendar.Record.SetInteger(_recordHandle, propertyId, val);
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "Set Integer Failed [" + error + "]" + String.Format("{0:X}", propertyId));
                    throw CalendarErrorFactory.GetException(error);
                }
            }
            else if (typeof(T) == typeof(long))
            {
                long val = Convert.ToInt64(value);
                int error = Interop.Calendar.Record.SetLli(_recordHandle, propertyId, val);
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "Set Long Failed [" + error + "]" + String.Format("{0:X}", propertyId));
                    throw CalendarErrorFactory.GetException(error);
                }
            }
            else if (typeof(T) == typeof(double))
            {
                double val = Convert.ToDouble(value);
                int error = Interop.Calendar.Record.SetDouble(_recordHandle, propertyId, val);
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "Set Double Failed [" + error + "]" + String.Format("{0:X}", propertyId));
                    throw CalendarErrorFactory.GetException(error);
                }
            }
            else if (typeof(T) == typeof(CalendarTime))
            {
                CalendarTime time = (CalendarTime)Convert.ChangeType(value, typeof(CalendarTime));
                Interop.Calendar.Record.DateTime val = ConvertCalendarTimeToStruct(time);
                int error = Interop.Calendar.Record.SetCalendarTime(_recordHandle, propertyId, val);
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
        /// <param name="propertyId">The property ID</param>
        /// <param name="childRecord">The child record</param>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        public void AddChildRecord(uint propertyId, CalendarRecord childRecord)
        {
            int error = Interop.Calendar.Record.AddChildRecord(_recordHandle, propertyId, childRecord._recordHandle);
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
        /// <param name="propertyId">The property ID</param>
        /// <param name="childRecord">The child record</param>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        public void RemoveChildRecord(uint propertyId, CalendarRecord childRecord)
        {
            int error = Interop.Calendar.Record.RemoveChildRecord(_recordHandle, propertyId, childRecord._recordHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "RemoveChildRecord Failed [" + error + "]" + String.Format("{0:X}", propertyId));
                throw CalendarErrorFactory.GetException(error);
            }
            childRecord._disposedValue = false;
        }

        /// <summary>
        /// Gets a child record from the parent record
        /// </summary>
        /// <param name="propertyId">The property ID</param>
        /// <returns>
        /// The number of child records corresponding to property ID
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        public int GetChildRecordCount(uint propertyId)
        {
            int count = 0;
            int error = Interop.Calendar.Record.GetChildRecordCount(_recordHandle, propertyId, out count);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "GetChildRecordCount Failed [" + error + "]" + String.Format("{0:X}", propertyId));
                throw CalendarErrorFactory.GetException(error);
            }
            return count;
        }

        /// <summary>
        /// Gets a child record from the parent record
        /// </summary>
        /// <param name="propertyId">The property ID</param>
        /// <param name="index">The child record index</param>
        /// <returns>
        /// The record
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        public CalendarRecord GetChildRecord(uint propertyId, int index)
        {
            IntPtr handle;

            int error = Interop.Calendar.Record.GetChildRecordPointer(_recordHandle, propertyId, index, out handle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "GetChildRecord Failed [" + error + "]" + String.Format("{0:X}", propertyId));
                throw CalendarErrorFactory.GetException(error);
            }
            return new CalendarRecord(handle, true);
        }

        /// <summary>
        /// Clones a child record list corresponding to property ID
        /// </summary>
        /// <param name="propertyId">The property ID</param>
        /// <returns>
        /// the record list
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        public CalendarList CloneChildRecordList(uint propertyId)
        {
            IntPtr listHandle;
            int error = Interop.Calendar.Record.CloneChildRecordList(_recordHandle, propertyId, out listHandle);
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
