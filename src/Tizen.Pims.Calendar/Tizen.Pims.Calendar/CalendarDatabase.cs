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

/// <summary>
/// The Calendar Service API provides functions, enumerations used in the entire Content Service.
/// </summary>
/// <remarks>
/// The Calendar Service API provides functions and ienumerations used in the entire Content Service.
/// The Information about calendar items i.e. book, event, todo, alarm, attendee and extended are managed in the database
/// and operations that involve database requires an active connection with the calendar contact service.
/// </remarks>

namespace Tizen.Pims.Calendar
{
    /// <summary>
    /// CalendarDatabase class is the interface class for managing the record from/to the database.
    /// This class allows usre to access/create/update db operations for media content.
    /// </summary>
    public class CalendarDatabase
    {
        /// <summary>
        /// </summary>
        /// <param name="uri">The record uri</param>
        public delegate void CalendarDbChangedDelegate(string uri);

        private Object thisLock = new Object();
        private Dictionary<string, CalendarDbChangedDelegate> _callbackMap = new Dictionary<string, CalendarDbChangedDelegate>();
        private Dictionary<string, Interop.Calendar.Database.DbChangedCallback> _delegateMap = new Dictionary<string, Interop.Calendar.Database.DbChangedCallback>();
        private Interop.Calendar.Database.DbChangedCallback _dbChangedDelegate;

        internal CalendarDatabase()
        {

        }

        /// <summary>
        /// The calendar database version.
        /// </summary>
        public int Version
        {
            get
            {
                int version = -1;
                int error = Interop.Calendar.Database.GetCurrentVersion(out version);
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "Version Failed with error " + error);
                }
                return version;
            }
        }

        /// <summary>
        /// The calendar database version on the current connection.
        /// </summary>
        public int LastChangeVersion
        {
            get
            {
                int version = -1;
                int error = Interop.Calendar.Database.GetLastChangeVersion(out version);
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
        /// <param name="record">The record to be inserted</param>
        /// <returns>
        /// The record id
        /// </returns>
        public int Insert(CalendarRecord record)
        {
            int id = -1;
            int error = Interop.Calendar.Database.Insert(record._recordHandle, out id);
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
        /// <param name="viewUri">The view URI of a record</param>
        /// <param name="recordId">The record ID</param>
        /// <returns>
        /// CalendarRecord instance.
        /// </returns>
        public CalendarRecord Get(string viewUri, int recordId)
        {
            IntPtr handle;
            int error = Interop.Calendar.Database.Get(viewUri, recordId, out handle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "Get Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            return new CalendarRecord(handle);
        }

        /// <summary>
        /// Updates a record in the calendar database.
        /// </summary>
        /// <param name="record">The record to be updated</param>
        public void Update(CalendarRecord record)
        {
            int error = Interop.Calendar.Database.Update(record._recordHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "Update Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Deletes a record from the calendar database with related child records.
        /// </summary>
        /// <param name="viewUri">The view URI of a record</param>
        /// <param name="recordId">The record ID to be deleted</param>
        public void Delete(string viewUri, int recordId)
        {
            int error = Interop.Calendar.Database.Delete(viewUri, recordId);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "Delete Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Replaces a record in the calendar database.
        /// </summary>
        /// <param name="record">The record to be replaced</param>
        /// <param name="id">the record id</param>
        public void Replace(CalendarRecord record, int id)
        {
            int error = Interop.Calendar.Database.Replace(record._recordHandle, id);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "Replace Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Retrieves all records as a list.
        /// </summary>
        /// <param name="viewUri">The view URI to get records from</param>
        /// <param name="offset">The index from which results are received</param>
        /// <param name="limit">The maximum number of results(value 0 is used for all records)</param>
        /// <returns>
        /// CalendarList
        /// </returns>
        public CalendarList GetAll(string viewUri, int offset, int limit)
        {
            IntPtr handle;
            int error = Interop.Calendar.Database.GetAllRecords(viewUri, offset, limit, out handle);
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
        /// <param name="query">The query used to filter results</param>
        /// <param name="offset">The index from which results are received</param>
        /// <param name="limit">The maximum number of results(value 0 is used for all records)</param>
        /// <returns>
        /// CalendarList
        /// </returns>
        public CalendarList GetRecordsWithQuery(CalendarQuery query, int offset, int limit)
        {
            IntPtr handle;
            int error = Interop.Calendar.Database.GetRecords(query._queryHandle, offset, limit, out handle);
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
        /// <param name="list">The record list</param>
        /// <returns>
        /// The inserted record id array
        /// </returns>
        public int[] Insert(CalendarList list)
        {
            IntPtr ids;
            int count;
            int error = Interop.Calendar.Database.InsertRecords(list._listHandle, out ids, out count);
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
        /// <param name="list">The record list</param>
        public void Update(CalendarList list)
        {
            int error = Interop.Calendar.Database.UpdateRecords(list._listHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "Update Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Deletes multiple records with related child records from the calendar database as a batch operation.
        /// </summary>
        /// <param name="viewUri">The view URI of the records to delete</param>
        /// <param name="idArray">The record IDs to delete</param>
        public void Delete(string viewUri, int[] idArray)
        {
            int error = Interop.Calendar.Database.DeleteRecords(viewUri, idArray, idArray.Length);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "Delete Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Deletes multiple records with related child records from the calendar database as a batch operation.
        /// </summary>
        /// <param name="list">The record list</param>
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
        /// <param name="list">The record list</param>
        /// <param name="idArray">The record IDs</param>
        public void Replace(CalendarList list, int[] idArray)
        {
            int error = Interop.Calendar.Database.ReplaceRecords(list._listHandle, idArray, idArray.Length);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "Replace Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Retrieves records with the given calendar database version.
        /// </summary>
        /// <param name="viewUri">The view URI to get records from</param>
        /// <param name="BookId">The calendar book ID to filter</param>
        /// <param name="calendarDBVersion">The calendar database version</param>
        /// <param name="currentDBVersion"The current calendar database versio></param>
        /// <returns>
        /// CalendarList
        /// </returns>
        public CalendarList GetChangesByVersion(string viewUri, int BookId, int calendarDBVersion, out int currentDBVersion)
        {
            IntPtr recordList;
            int error = Interop.Calendar.Database.GetChangesByVersion(viewUri, BookId, calendarDBVersion, out recordList, out currentDBVersion);
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
        /// <param name="viewUri">The view URI to get records from</param>
        /// <returns>
        /// The count
        /// </returns>
        public int GetCount(string viewUri)
        {
            int count = -1;
            int error = Interop.Calendar.Database.GetCount(viewUri, out count);
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
        /// <param name="query">The query used for filtering the results</param>
        /// <returns>
        /// The count
        /// </returns>
        public int GetCount(CalendarQuery query)
        {
            int count = -1;
            int error = Interop.Calendar.Database.GetCountWithQuery(query._queryHandle, out count);
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
        /// <param name="viewUri">The view URI of the record to subscribe for change notifications</param>
        /// <param name="callback">The callback function to register</param>
        public void AddDBChangedDelegate(string viewUri, CalendarDbChangedDelegate callback)
        {
            Log.Debug(Globals.LogTag, "AddDBChangedDelegate");

            _dbChangedDelegate = (string uri, IntPtr userData) =>
            {
                _callbackMap[uri](uri);
            };
            int error = Interop.Calendar.Database.AddChangedCallback(viewUri, _dbChangedDelegate, IntPtr.Zero);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "AddDBChangedDelegate Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            _callbackMap[viewUri] = callback;
            _delegateMap[viewUri] = _dbChangedDelegate;
        }

        /// <summary>
        /// Unregisters a callback function.
        /// </summary>
        /// <param name="viewUri">The view URI of the record to subscribe for change notifications</param>
        /// <param name="callback">The callback function to register</param>
        public void RemoveDBChangedDelegate(string viewUri, CalendarDbChangedDelegate callback)
        {
            Log.Debug(Globals.LogTag, "RemoveDBChangedDelegate");

            int error = Interop.Calendar.Database.RemoveChangedCallback(viewUri, _delegateMap[viewUri], IntPtr.Zero);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "RemoveDBChangedDelegate Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
            _callbackMap.Remove(viewUri);
            _delegateMap.Remove(viewUri);
        }

        /// <summary>
        /// Link a record to another record.
        /// </summary>
        /// <param name="baseId">The base record ID</param>
        /// <param name="recordId">The record ID to link to</param>
        public void LinkRecord(int baseId, int recordId)
        {
            Log.Debug(Globals.LogTag, "LinkRecord");
            int error = Interop.Calendar.Database.LinkRecord(baseId, recordId);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "LinkRecor Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Unlink a record from base record.
        /// </summary>
        /// <param name="recordId">The record ID to unlink</param>
        public void UnlinkRecord(int recordId)
        {
            Log.Debug(Globals.LogTag, "UnlinkRecord");
            int error = Interop.Calendar.Database.UnlinkRecord(recordId);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "UnlinkRecor Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }
    }
}
