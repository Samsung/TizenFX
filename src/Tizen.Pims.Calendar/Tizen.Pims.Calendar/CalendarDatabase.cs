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
using System.Diagnostics.CodeAnalysis;

namespace Tizen.Pims.Calendar
{
    /// <summary>
    /// CalendarDatabase provides methods to manage calendar information from/to the database.
    /// </summary>
    /// <remarks>
    /// This class allows user to access/create/update/delete db operations for calendar information.
    /// CalendarDatabase is created by CalendarManager.
    /// </remarks>
    /// <since_tizen> 4 </since_tizen>
    public class CalendarDatabase
    {
        private Object thisLock = new Object();
        private Dictionary<string, EventHandler<DBChangedEventArgs>> _eventHandlerMap = new Dictionary<string, EventHandler<DBChangedEventArgs>>();
        private Dictionary<string, Interop.Database.DBChangedCallback> _callbackMap = new Dictionary<string, Interop.Database.DBChangedCallback>();

        internal CalendarDatabase()
        {
            /*To be created in CalendarManager only*/
        }

        /// <summary>
        /// The calendar database version.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <value>The current calendar database version.</value>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public int Version
        {
            get
            {
                int version = -1;
                int error = Interop.Database.GetCurrentVersion(out version);
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "Version Failed with error " + error);
                }
                return version;
            }
        }

        /// <summary>
        /// Gets last successful changed calendar database version on the current connection.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <returns>The last successful changed calendar database version on the current connection</returns>
        /// <privilege>http://tizen.org/privilege/calendar.read</privilege>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
        /// <value>The last successful changed calendar database version on the current connection.</value>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public int LastChangeVersion
        {
            get
            {
                int version = -1;
                int error = Interop.Database.GetLastChangeVersion(out version);
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "LastChangeVersion Failed with error " + error);
                }
                return version;
            }
        }

        /// <summary>
        /// Inserts a record into the calendar database.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="record">The record to be inserted</param>
        /// <returns>The ID of inserted record</returns>
        /// <privilege>http://tizen.org/privilege/calendar.write</privilege>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public int Insert(CalendarRecord record)
        {
            int id = -1;
            int error = Interop.Database.Insert(record._recordHandle, out id);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "Insert Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            return id;
        }

        /// <summary>
        /// Gets a record from the calendar database.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="viewUri">The view URI of a record</param>
        /// <param name="recordId">The record ID</param>
        /// <returns>
        /// The record associated with the record ID
        /// </returns>
        /// <privilege>http://tizen.org/privilege/calendar.read</privilege>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public CalendarRecord Get(string viewUri, int recordId)
        {
            IntPtr handle;
            int error = Interop.Database.Get(viewUri, recordId, out handle);
            if (CalendarError.None != (CalendarError)error)
            {
				if (CalendarError.DBNotFound == (CalendarError)error)
				{
					Log.Error(Globals.LogTag, "No data" + error);
					return null;
				}
				Log.Error(Globals.LogTag, "Get Failed with error " + error);
				throw CalendarErrorFactory.GetException(error);
            }
            return new CalendarRecord(handle);
        }

        /// <summary>
        /// Updates a record in the calendar database.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="record">The record to be updated</param>
        /// <privilege>http://tizen.org/privilege/calendar.write</privilege>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public void Update(CalendarRecord record)
        {
            int error = Interop.Database.Update(record._recordHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "Update Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Deletes a record from the calendar database with related child records.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="viewUri">The view URI of a record</param>
        /// <param name="recordId">The record ID to be deleted</param>
        /// <privilege>http://tizen.org/privilege/calendar.write</privilege>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public void Delete(string viewUri, int recordId)
        {
            int error = Interop.Database.Delete(viewUri, recordId);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "Delete Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Replaces a record in the calendar database.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="record">The record to be replaced</param>
        /// <param name="id">the record id</param>
        /// <privilege>http://tizen.org/privilege/calendar.write</privilege>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public void Replace(CalendarRecord record, int id)
        {
            int error = Interop.Database.Replace(record._recordHandle, id);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "Replace Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Retrieves all records as a list.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="viewUri">The view URI to get records from</param>
        /// <param name="offset">The index from which results are received</param>
        /// <param name="limit">The maximum number of results(value 0 is used for all records)</param>
        /// <returns>
        /// The record list
        /// </returns>
        /// <privilege>http://tizen.org/privilege/calendar.read</privilege>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public CalendarList GetAll(string viewUri, int offset, int limit)
        {
            IntPtr handle;
            int error = Interop.Database.GetAllRecords(viewUri, offset, limit, out handle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "GetAll Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            return new CalendarList(handle);
        }

        /// <summary>
        /// Retrieves records using a query.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="query">The query used to filter results</param>
        /// <param name="offset">The index from which results are received</param>
        /// <param name="limit">The maximum number of results(value 0 is used for all records)</param>
        /// <returns>
        /// CalendarList
        /// </returns>
        /// <privilege>http://tizen.org/privilege/calendar.read</privilege>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public CalendarList GetRecordsWithQuery(CalendarQuery query, int offset, int limit)
        {
            IntPtr handle;
            int error = Interop.Database.GetRecords(query._queryHandle, offset, limit, out handle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "GetAllWithQuery Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            return new CalendarList(handle);
        }

        /// <summary>
        /// Inserts multiple records into the calendar database as a batch operation.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="list">The record list</param>
        /// <returns>
        /// The inserted record id array
        /// </returns>
        /// <privilege>http://tizen.org/privilege/calendar.write</privilege>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public int[] Insert(CalendarList list)
        {
            IntPtr ids;
            int count;
            int error = Interop.Database.InsertRecords(list._listHandle, out ids, out count);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "Insert Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            int[] idArr = new int[count];
            Marshal.Copy(ids, idArr, 0, count);

            return idArr;
        }

        /// <summary>
        /// Updates multiple records into the calendar database as a batch operation.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="list">The record list</param>
        /// <privilege>http://tizen.org/privilege/calendar.write</privilege>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public void Update(CalendarList list)
        {
            int error = Interop.Database.UpdateRecords(list._listHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "Update Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Deletes multiple records with related child records from the calendar database as a batch operation.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="viewUri">The view URI of the records to delete</param>
        /// <param name="idArray">The record IDs to delete</param>
        /// <privilege>http://tizen.org/privilege/calendar.write</privilege>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public void Delete(string viewUri, int[] idArray)
        {
            int error = Interop.Database.DeleteRecords(viewUri, idArray, idArray.Length);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "Delete Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Deletes multiple records with related child records from the calendar database as a batch operation.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="list">The record list</param>
        /// <privilege>http://tizen.org/privilege/calendar.write</privilege>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
        public void Delete(CalendarList list)
        {
            CalendarRecord record = null;
            if (list.Count <= 0)
                return;

            int[] ids = new int[list.Count];
            int i;
            uint propertyId = 0;
            list.MoveFirst();
            for (i = 0; i < list.Count; i++)
            {
                record = list.GetCurrentRecord();
                if (0 == propertyId)
                {
                    if (0 == String.Compare(CalendarViews.Book.Uri, record.Uri))
                        propertyId = CalendarViews.Book.Id;
                    else if (0 == String.Compare(CalendarViews.Event.Uri, record.Uri))
                        propertyId = CalendarViews.Event.Id;
                    else if (0 == String.Compare(CalendarViews.Todo.Uri, record.Uri))
                        propertyId = CalendarViews.Todo.Id;
                    else if (0 == String.Compare(CalendarViews.Timezone.Uri, record.Uri))
                        propertyId = CalendarViews.Timezone.Id;
                    else if (0 == String.Compare(CalendarViews.Extended.Uri, record.Uri))
                        propertyId = CalendarViews.Extended.Id;
                    else
                    {
                        Log.Error(Globals.LogTag, "Invalid uri [" + record.Uri + "]");
                        continue;
                    }
                }
                ids[i] = record.Get<int>(propertyId);
                list.MoveNext();
            }
            Delete(record.Uri, ids);
        }

        /// <summary>
        /// Replaces multiple records in the calendar database as a batch operation.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="list">The record list</param>
        /// <param name="idArray">The record IDs</param>
        /// <privilege>http://tizen.org/privilege/calendar.write</privilege>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public void Replace(CalendarList list, int[] idArray)
        {
            int error = Interop.Database.ReplaceRecords(list._listHandle, idArray, idArray.Length);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "Replace Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Retrieves records with the given calendar database version.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="viewUri">The view URI to get records from</param>
        /// <param name="BookId">The calendar book ID to filter</param>
        /// <param name="calendarDBVersion">The calendar database version</param>
        /// <param name="currentDBVersion">The current calendar database version</param>
        /// <returns>
        /// The record list
        /// </returns>
        /// <privilege>http://tizen.org/privilege/calendar.read</privilege>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public CalendarList GetChangesByVersion(string viewUri, int BookId, int calendarDBVersion, out int currentDBVersion)
        {
            IntPtr recordList;
            int error = Interop.Database.GetChangesByVersion(viewUri, BookId, calendarDBVersion, out recordList, out currentDBVersion);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "GetChangesByVersion Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            return new CalendarList(recordList);
        }

        /// <summary>
        /// Gets the record count of a specific view.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="viewUri">The view URI to get records from</param>
        /// <returns>
        /// The count of records
        /// </returns>
        /// <privilege>http://tizen.org/privilege/calendar.read</privilege>
        [SuppressMessage("Microsoft.Design", "CA1822:MarkMembersAsStatic")]
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public int GetCount(string viewUri)
        {
            int count = -1;
            int error = Interop.Database.GetCount(viewUri, out count);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "GetCount Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            return count;
        }

        /// <summary>
        /// Gets the record count with a query.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="query">The query used for filtering the results</param>
        /// <returns>
        /// The count of records
        /// </returns>
        /// <privilege>http://tizen.org/privilege/calendar.read</privilege>
        [SuppressMessage("Microsoft.Design", "CA1822:MarkMembersAsStatic")]
        public int GetCount(CalendarQuery query)
        {
            int count = -1;
            int error = Interop.Database.GetCountWithQuery(query._queryHandle, out count);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "GetCount Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            return count;
        }

        /// <summary>
        /// Registers a callback function to be invoked when a record changes.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="viewUri">The view URI of the record to subscribe for change notifications</param>
        /// <param name="DBChanged">The EventHandler to register</param>
        /// <privilege>http://tizen.org/privilege/calendar.read</privilege>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public void AddDBChangedDelegate(string viewUri, EventHandler<DBChangedEventArgs> DBChanged)
        {
            Log.Debug(Globals.LogTag, "AddDBChangedDelegate");

			if (!_callbackMap.ContainsKey(viewUri))
			{
				_callbackMap[viewUri] = (string uri, IntPtr userData) =>
				{
					DBChangedEventArgs args = new DBChangedEventArgs(uri);
					_eventHandlerMap[uri]?.Invoke(this, args);
				};

				int error = Interop.Database.AddChangedCallback(viewUri, _callbackMap[viewUri], IntPtr.Zero);
				if (CalendarError.None != (CalendarError)error)
				{
					Log.Error(Globals.LogTag, "AddDBChangedDelegate Failed with error " + error);
					throw CalendarErrorFactory.GetException(error);
				}
			}

			EventHandler<DBChangedEventArgs> handler = null;
			if (!_eventHandlerMap.TryGetValue(viewUri, out handler))
				_eventHandlerMap.Add(viewUri, null);

			_eventHandlerMap[viewUri] = handler + DBChanged;
        }

        /// <summary>
        /// Deregisters a callback function.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="viewUri">The view URI of the record to subscribe for change notifications</param>
        /// <param name="DBChanged">The EventHandler to deregister</param>
        /// <privilege>http://tizen.org/privilege/calendar.read</privilege>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public void RemoveDBChangedDelegate(string viewUri, EventHandler<DBChangedEventArgs> DBChanged)
        {
            Log.Debug(Globals.LogTag, "RemoveDBChangedDelegate");

            EventHandler<DBChangedEventArgs> handler = null;
            if (!_eventHandlerMap.TryGetValue(viewUri, out handler))
                _eventHandlerMap.Add(viewUri, null);
            else
                _eventHandlerMap[viewUri] = handler - DBChanged;

            if (_eventHandlerMap[viewUri] == null)
            {
				int error = Interop.Database.RemoveChangedCallback(viewUri, _callbackMap[viewUri], IntPtr.Zero);
				if (CalendarError.None != (CalendarError)error)
				{
					Log.Error(Globals.LogTag, "RemoveDBChangedDelegate Failed with error " + error);
					throw CalendarErrorFactory.GetException(error);
				}
				_callbackMap.Remove(viewUri);
			}
        }

        /// <summary>
        /// Link a record to another record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="baseId">The base record ID</param>
        /// <param name="recordId">The record ID to link to</param>
        /// <privilege>http://tizen.org/privilege/calendar.write</privilege>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
        [SuppressMessage("Microsoft.Design", "CA1822:MarkMembersAsStatic")]
        public void LinkRecord(int baseId, int recordId)
        {
            Log.Debug(Globals.LogTag, "LinkRecord");
            int error = Interop.Database.LinkRecord(baseId, recordId);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "LinkRecor Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Unlink a record from base record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="recordId">The record ID to unlink</param>
        /// <privilege>http://tizen.org/privilege/calendar.write</privilege>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public void UnlinkRecord(int recordId)
        {
            Log.Debug(Globals.LogTag, "UnlinkRecord");
            int error = Interop.Database.UnlinkRecord(recordId);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "UnlinkRecor Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }
    }
}
