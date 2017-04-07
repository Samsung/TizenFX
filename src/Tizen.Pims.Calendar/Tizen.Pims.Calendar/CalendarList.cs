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
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// </summary>
/// <remarks>
/// </remarks>
namespace Tizen.Pims.Calendar
{
    /// <summary>
    /// </summary>
    public class CalendarList:IDisposable
    {
        internal int _count = -1;
        internal IntPtr _listHandle;
        internal CalendarList(IntPtr handle)
        {
            _listHandle = handle;
        }

        /// <summary>
        /// Creates a calendar list.
        /// </summary>
        public CalendarList()
        {
            int error = Interop.Calendar.List.Create(out _listHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "CalendarList Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        ~CalendarList()
        {
            Dispose(false);
        }

        /// <summary>
        /// The count of the calendar entity.
        /// </summary>
        public int Count
        {
            get
            {
                if (_count == -1)
                {
                    int count = -1;
                    int error = Interop.Calendar.List.GetCount(_listHandle, out count);
                    if (CalendarError.None != (CalendarError)error)
                    {
                        Log.Error(Globals.LogTag, "GetCount Failed with error " + error);
                    }
                    _count = count;
                }
                return _count;
            }
        }

#region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                Log.Debug(Globals.LogTag, "Dispose :" + disposing);

                int error = Interop.Calendar.List.Destroy(_listHandle, true);
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "Destroy Failed with error " + error);
                    throw CalendarErrorFactory.GetException(error);
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
#endregion

        /// <summary>
        /// Adds a record to the calendar list.
        /// </summary>
        /// <param name="record">The record to be added</param>
        public void AddRecord(CalendarRecord record)
        {
            int error = Interop.Calendar.List.Add(_listHandle, record._recordHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "AddRecord Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            record._disposedValue = true;
            _count = -1;
        }

        /// <summary>
        /// Removes a record from the calendar list.
        /// </summary>
        /// <param name="record">The record to be removed</param>
        public void RemoveRecord(CalendarRecord record)
        {
            int error = Interop.Calendar.List.Remove(_listHandle, record._recordHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "RemoveRecord Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            record._disposedValue = false;
            _count = -1;
        }

        /// <summary>
        /// Retrieves a record from the calendar list.
        /// </summary>
        /// <returns>
        /// CalendarRecord
        /// </returns>
        public CalendarRecord GetCurrentRecord()
        {
            IntPtr handle;
            int error = Interop.Calendar.List.GetCurrentRecordP(_listHandle, out handle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "GetCurrentRecord Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            return new CalendarRecord(handle, true);
        }

        /// <summary>
        /// Moves a calendar list to the previous position.
        /// </summary>
        /// <returns>
        /// if cursor is moved to the end, it returns false.
        /// </returns>
        public bool MovePrevious()
        {
            int error = Interop.Calendar.List.Prev(_listHandle);
            if (CalendarError.None == (CalendarError)error)
                return true;
            else if (this.Count > 0 && CalendarError.NoData == (CalendarError)error)
            {
                Log.Debug(Globals.LogTag, "Nodata MovePrevious " + error);
                return false;
            }
            else
            {
                Log.Error(Globals.LogTag, "MovePrevious Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Moves a calendar list to the next position.
        /// </summary>
        /// <returns>
        /// if cursor is moved to the end, it returns false.
        /// </returns>
        public bool MoveNext()
        {
            int error = Interop.Calendar.List.Next(_listHandle);
            if (CalendarError.None == (CalendarError)error)
                return true;
            else if (this.Count > 0 && CalendarError.NoData == (CalendarError)error)
            {
                Log.Debug(Globals.LogTag, "Nodata MoveNext" + error);
                return false;
            }
            else
            {
                Log.Error(Globals.LogTag, "MoveNext Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Moves a calendar list to the first position.
        /// </summary>
        public void MoveFirst()
        {
            int error = Interop.Calendar.List.First(_listHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "MoveFirst Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Moves a calendar list to the last position.
        /// </summary>
        public void MoveLast()
        {
            int error = Interop.Calendar.List.Last(_listHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "MoveLast Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

    }
}
