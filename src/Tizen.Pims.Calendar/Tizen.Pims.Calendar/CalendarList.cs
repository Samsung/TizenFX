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

namespace Tizen.Pims.Calendar
{
    /// <summary>
    /// A list of records with the same type.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class CalendarList:IDisposable
    {
        private Int64 _memoryPressure = 20;
        internal int _count = -1;
        internal IntPtr _listHandle;

        internal CalendarList(IntPtr handle)
        {
            _listHandle = handle;

            int error = Interop.List.First(_listHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "MoveFirst Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }

            _memoryPressure += this.Count * CalendarViews.Record.AverageSize;
            GC.AddMemoryPressure(_memoryPressure);
        }

        /// <summary>
        /// Creates a calendar list.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        public CalendarList()
        {
            int error = Interop.List.Create(out _listHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "CalendarList Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            GC.AddMemoryPressure(_memoryPressure);
        }

        /// <summary>
        /// The count of the calendar entity.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <value>The count of the calendar entity.</value>
        public int Count
        {
            get
            {
                if (_count == -1)
                {
                    int count = -1;
                    int error = Interop.List.GetCount(_listHandle, out count);
                    if (CalendarError.None != (CalendarError)error)
                    {
                        Log.Error(Globals.LogTag, "GetCount Failed with error " + error);
                    }
                    _count = count;
                }
                return _count;
            }
        }

        /// <summary>
        /// Destroys the CalendarList resource.
        /// </summary>
        ~CalendarList()
        {
            Dispose(false);
        }

#region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Disposes off the resources (other than memory) used by the CalendarList.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources, false to release only unmanaged resources.</param>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                Log.Debug(Globals.LogTag, "Dispose :" + disposing);

                int error = Interop.List.Destroy(_listHandle, true);
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "Destroy Failed with error " + error);
                }
                disposedValue = true;
                GC.RemoveMemoryPressure(_memoryPressure);
            }
        }

        /// <summary>
        /// Releases all resources used by the CalendarList.
        /// It should be called after it has finished using the object.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
#endregion

        /// <summary>
        /// Adds a record to the calendar list.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="record">The record to be added.</param>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        public void AddRecord(CalendarRecord record)
        {
            int error = Interop.List.Add(_listHandle, record._recordHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "AddRecord Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            record._disposedValue = true;
            _count = -1;
            _memoryPressure += CalendarViews.Record.AverageSize;
        }

        /// <summary>
        /// Removes a record from the calendar list.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="record">The record to be removed.</param>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        public void RemoveRecord(CalendarRecord record)
        {
            int error = Interop.List.Remove(_listHandle, record._recordHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "RemoveRecord Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            record._disposedValue = false;
            _count = -1;
            _memoryPressure -= CalendarViews.Record.AverageSize;
        }

        /// <summary>
        /// Retrieves a record from the calendar list.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <returns>
        /// The calendar record.
        /// </returns>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        public CalendarRecord GetCurrentRecord()
        {
            IntPtr handle;
            int error = Interop.List.GetCurrentRecordP(_listHandle, out handle);
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
        /// <since_tizen> 4 </since_tizen>
        /// <returns>
        /// If the cursor is moved to the end, it returns false.
        /// </returns>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        public bool MovePrevious()
        {
            int error = Interop.List.Prev(_listHandle);
            if (CalendarError.None == (CalendarError)error)
            {
                return true;
            }
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
        /// <since_tizen> 4 </since_tizen>
        /// <returns>
        /// If the cursor is moved to the end, it returns false.
        /// </returns>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        public bool MoveNext()
        {
            int error = Interop.List.Next(_listHandle);
            if (CalendarError.None == (CalendarError)error)
            {
                return true;
            }
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
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        public void MoveFirst()
        {
            int error = Interop.List.First(_listHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "MoveFirst Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Moves a calendar list to the last position.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        public void MoveLast()
        {
            int error = Interop.List.Last(_listHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "MoveLast Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

    }
}
