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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Tizen.Pims.Contacts
{

    /// <summary>
    /// The ContactsDatabase provides methods to manage contacts information from/to the database.
    /// </summary>
    /// <remarks>
    /// This class allows the user to access/create/update database operations for the contacts information.
    /// </remarks>
    /// <since_tizen> 4 </since_tizen>
    public class ContactsDatabase
    {
        private Object thisLock = new Object();
        private Interop.Database.ContactsDBStatusChangedCallback _contactsDBStatusChangedCallback;
        private EventHandler<DBStatusChangedEventArgs> _dbStatusChanged;
        private Dictionary<string, EventHandler<DBChangedEventArgs>> _eventHandlerMap = new Dictionary<string, EventHandler<DBChangedEventArgs>>();
        private Dictionary<string, Interop.Database.ContactsDBChangedCallback> _callbackMap = new Dictionary<string, Interop.Database.ContactsDBChangedCallback>();

        internal ContactsDatabase()
        {
            /*To be created in ContactsManager only.*/
        }

        /// <summary>
        /// Enumeration for the contacts database status.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum DBStatus
        {
            /// <summary>
            /// Normal.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Normal,
            /// <summary>
            /// Changing collation.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            ChangingCollation
        }

        /// <summary>
        /// Enumeration for the contacts search range.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        [Flags]
        public enum SearchRanges
        {
            /// <summary>
            /// None.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            None = 0,
            /// <summary>
            /// Search record from name.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Name = 0x00000001,
            /// <summary>
            /// Search record from number.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Number = 0x00000002,
            /// <summary>
            /// Search record from data.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Data = 0x00000004,
            /// <summary>
            /// Search record from email. Now, support only PersonEmail view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Email = 0x00000008,
        }

        /// <summary>
        /// Occurs when the contacts database status is changed.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<DBStatusChangedEventArgs> DBStatusChanged
        {
            add
            {
                lock (thisLock)
                {
                    if (_contactsDBStatusChangedCallback == null)
                    {
                        _contactsDBStatusChangedCallback = (DBStatus status, IntPtr userData) =>
                        {
                            DBStatusChangedEventArgs args = new DBStatusChangedEventArgs(status);
                            _dbStatusChanged?.Invoke(this, args);
                        };
                    }

                    if (_dbStatusChanged == null)
                    {
                        int error = Interop.Database.AddStatusChangedCb(_contactsDBStatusChangedCallback, IntPtr.Zero);
                        if ((int)ContactsError.None != error)
                        {
                            Log.Error(Globals.LogTag, "Add StatusChanged Failed with error " + error);
                        }
                    }

                    _dbStatusChanged += value;
                }

            }

            remove
            {
                lock (thisLock)
                {
                    _dbStatusChanged -= value;

                    if (_dbStatusChanged == null)
                    {
                        int error = Interop.Database.RemoveStatusChangedCb(_contactsDBStatusChangedCallback, IntPtr.Zero);
                        if ((int)ContactsError.None != error)
                        {
                            Log.Error(Globals.LogTag, "Remove StatusChanged Failed with error " + error);
                        }
                    }
                }
            }

        }

        /// <summary>
        /// The current contacts database version.
        /// </summary>
        /// <value>The current contacts database version.</value>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public int Version
        {
            get
            {
                int version = -1;
                int error = Interop.Database.GetVersion(out version);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "Version Failed with error " + error);
                }
                return version;
            }
        }

        /// <summary>
        /// The last successful changed contacts database version on the current connection.
        /// </summary>
        /// <value>The last successful changed contacts database version on the current connection.</value>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public int LastChangeVersion
        {
            get
            {
                int version = -1;
                int error = Interop.Database.GetLastChangeVersion(out version);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "LastChangeVersion Failed with error " + error);
                }
                return version;
            }
        }

        /// <summary>
        /// The contacts database status.
        /// </summary>
        /// <value>The contacts database status.</value>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public DBStatus Status
        {
            get
            {
                DBStatus status = DBStatus.Normal;
                int error = Interop.Database.GetStatus(out status);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "GetStatus Failed with error " + error);
                }
                return status;
            }
        }

        /// <summary>
        /// Inserts a record into the contacts database.
        /// </summary>
        /// <param name="record">The record to insert.</param>
        /// <returns>The ID of inserted record.</returns>
        /// <privilege>http://tizen.org/privilege/contact.write</privilege>
        /// <privilege>http://tizen.org/privilege/callhistory.write</privilege>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have proper privileges.</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public int Insert(ContactsRecord record)
        {
            int id = -1;
            int error = Interop.Database.Insert(record._recordHandle, out id);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "Insert Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            return id;
        }

        /// <summary>
        /// Inserts multiple records into the contacts database as a batch operation.
        /// </summary>
        /// <param name="list">The record list.</param>
        /// <returns>The inserted record ID array.</returns>
        /// <privilege>http://tizen.org/privilege/contact.write</privilege>
        /// <privilege>http://tizen.org/privilege/callhistory.write</privilege>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have proper privileges.</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public int[] Insert(ContactsList list)
        {
            IntPtr ids;
            int count;
            int error = Interop.Database.InsertRecords(list._listHandle, out ids, out count);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "Insert Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }

            int[] idArr = new int[count];
            Marshal.Copy(ids, idArr, 0, count);

            return idArr;
        }

        /// <summary>
        /// Gets a record from the contacts database.
        /// </summary>
        /// <param name="viewUri">The view URI of a record.</param>
        /// <param name="recordId">The record ID.</param>
        /// <returns>The record associated with the record ID</returns>
        /// <privilege>http://tizen.org/privilege/contact.read</privilege>
        /// <privilege>http://tizen.org/privilege/callhistory.read</privilege>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have proper privileges.</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public ContactsRecord Get(string viewUri, int recordId)
        {
            IntPtr handle;
            int error = Interop.Database.Get(viewUri, recordId, out handle);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "Get Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            return new ContactsRecord(handle);
        }

        /// <summary>
        /// Updates a record in the contacts database.
        /// </summary>
        /// <param name="record">The record to update.</param>
        /// <privilege>http://tizen.org/privilege/contact.write</privilege>
        /// <privilege>http://tizen.org/privilege/callhistory.write</privilege>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have proper privileges.</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public void Update(ContactsRecord record)
        {
            int error = Interop.Database.Update(record._recordHandle);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "Update Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        /// <summary>
        /// Updates multiple records in the contacts database as a batch operation.
        /// </summary>
        /// <param name="list">The record list.</param>
        /// <privilege>http://tizen.org/privilege/contact.write</privilege>
        /// <privilege>http://tizen.org/privilege/callhistory.write</privilege>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have proper privileges.</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public void Update(ContactsList list)
        {
            int error = Interop.Database.UpdateRecords(list._listHandle);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "Update Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        /// <summary>
        /// Deletes a record from the contacts database with the related child records.
        /// </summary>
        /// <param name="viewUri">The view URI of a record.</param>
        /// <param name="recordId">The record ID to delete.</param>
        /// <privilege>http://tizen.org/privilege/contact.write</privilege>
        /// <privilege>http://tizen.org/privilege/callhistory.write</privilege>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have proper privileges.</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public void Delete(string viewUri, int recordId)
        {
            int error = Interop.Database.Delete(viewUri, recordId);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "Delete Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        /// <summary>
        /// Deletes multiple records with the related child records from the contacts database as a batch operation.
        /// </summary>
        /// <param name="viewUri">The view URI of the records to delete.</param>
        /// <param name="idArray">The record IDs to delete.</param>
        /// <privilege>http://tizen.org/privilege/contact.write</privilege>
        /// <privilege>http://tizen.org/privilege/callhistory.write</privilege>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have proper privileges.</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public void Delete(string viewUri, int[] idArray)
        {
            int error = Interop.Database.DeleteRecords(viewUri, idArray, idArray.Length);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "Delete Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        /// <summary>
        /// Replaces a record in the contacts database.
        /// </summary>
        /// <param name="record">The record to replace.</param>
        /// <param name="recordId">The record ID to be replaced.</param>
        /// <privilege>http://tizen.org/privilege/contact.write</privilege>
        /// <privilege>http://tizen.org/privilege/callhistory.write</privilege>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation<./exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have proper privileges.</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public void Replace(ContactsRecord record, int recordId)
        {
            int error = Interop.Database.Replace(record._recordHandle, recordId);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "Replace Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        /// <summary>
        /// Replaces multiple records in the contacts database as a batch operation.
        /// </summary>
        /// <param name="list">The record list to replace.</param>
        /// <param name="idArray">The record IDs to be replaced.</param>
        /// <privilege>http://tizen.org/privilege/contact.write</privilege>
        /// <privilege>http://tizen.org/privilege/callhistory.write</privilege>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have proper privileges.</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public void Replace(ContactsList list, int[] idArray)
        {
            int error = Interop.Database.ReplaceRecords(list._listHandle, idArray, idArray.Length);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "Replace Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        /// <summary>
        /// Retrieves all the records as a list.
        /// </summary>
        /// <param name="viewUri">The view URI to get records.</param>
        /// <param name="offset">The index from which results.</param>
        /// <param name="limit">The number to limit results (value 0 is used for get all records).</param>
        /// <returns>
        /// The record list.
        /// </returns>
        /// <privilege>http://tizen.org/privilege/contact.read</privilege>
        /// <privilege>http://tizen.org/privilege/callhistory.read</privilege>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have proper privileges.</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public ContactsList GetAll(string viewUri, int offset, int limit)
        {
            IntPtr handle;
            int error = Interop.Database.GetRecords(viewUri, offset, limit, out handle);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "GetAll Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            return new ContactsList(handle);
        }

        /// <summary>
        /// Retrieves the records using a query.
        /// </summary>
        /// <param name="query">The query to filter the results.</param>
        /// <param name="offset">The index from which to get results.</param>
        /// <param name="limit">The number to limit results (value 0 is used for get all records).</param>
        /// <returns>
        /// The record list
        /// </returns>
        /// <privilege>http://tizen.org/privilege/contact.read</privilege>
        /// <privilege>http://tizen.org/privilege/callhistory.read</privilege>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have proper privileges.</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public ContactsList GetRecordsWithQuery(ContactsQuery query, int offset, int limit)
        {
            IntPtr handle;
            int error = Interop.Database.GetRecords(query._queryHandle, offset, limit, out handle);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "GetAllWithQuery Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            return new ContactsList(handle);
        }

        /// <summary>
        /// Retrieves the records changes since the given database version.
        /// </summary>
        /// <param name="viewUri">The view URI to get records.</param>
        /// <param name="addressBookId">The address book ID to filter.</param>
        /// <param name="contactsDBVersion">The contacts database version.</param>
        /// <param name="currentDBVersion">The current contacts database version.</param>
        /// <returns>
        /// The record list.
        /// </returns>
        /// <privilege>http://tizen.org/privilege/contact.read</privilege>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have proper privileges.</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public ContactsList GetChangesByVersion(string viewUri, int addressBookId, int contactsDBVersion, out int currentDBVersion)
        {
            IntPtr recordList;
            int error = Interop.Database.GetChangesByVersion(viewUri, addressBookId, contactsDBVersion, out recordList,out currentDBVersion);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "GetChangesByVersion Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            return new ContactsList(recordList);
        }

        /// <summary>
        /// Finds the records based on a given keyword.
        /// </summary>
        /// <remarks>
        /// This API works only for the views below:
        /// Person, PersonContact, PersonGroupRelation, PersonGroupAssigned, and PersonGroupNotAssigned.
        /// </remarks>
        /// <param name="viewUri">The view URI to find records.</param>
        /// <param name="keyword">The keyword.</param>
        /// <param name="offset">The index from which to get results.</param>
        /// <param name="limit">The number to limit results (value 0 is used for get all records).</param>
        /// <returns>The record list</returns>
        /// <privilege>http://tizen.org/privilege/contact.read</privilege>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have proper privileges.</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public ContactsList Search(string viewUri, string keyword, int offset, int limit)
        {
            IntPtr recordList;
            int error = Interop.Database.Search(viewUri, keyword, offset, limit, out recordList);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "Search Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            return new ContactsList(recordList);
        }

        /// <summary>
        /// Finds the records based on a given query and keyword.
        /// </summary>
        /// <remarks>
        /// This API works only for the views below:
        /// Person, PersonContact, PersonGroupRelation, PersonGroupAssigned, and PersonGroupNotAssigned.
        /// </remarks>
        /// <param name="query">The query to filter.</param>
        /// <param name="keyword">The keyword.</param>
        /// <param name="offset">The index from which to get results.</param>
        /// <param name="limit">The number to limit results (value 0 is used for get all records).</param>
        /// <returns>The record list.</returns>
        /// <privilege>http://tizen.org/privilege/contact.read</privilege>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have proper privileges.</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public ContactsList Search(ContactsQuery query, string keyword, int offset, int limit)
        {
            IntPtr recordList;
            int error = Interop.Database.Search(query._queryHandle, keyword, offset, limit, out recordList);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "Search Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            return new ContactsList(recordList);
        }

        /// <summary>
        /// Finds the records based on a keyword and range.
        /// </summary>
        /// <remarks>
        /// This API works only for the views below:
        /// Person, PersonContact, PersonGroupRelation, PersonGroupAssigned, PersonGroupNotAssigned, PersonNumber, and PersonEmail.
        /// </remarks>
        /// <param name="viewUri">The view URI.</param>
        /// <param name="keyword">The keyword.</param>
        /// <param name="offset">The index from which to get results.</param>
        /// <param name="limit">The number to limit results (value 0 is used for get all records).</param>
        /// <param name="range">The search range should be an element of the SearchRange or bitwise OR operation of them.</param>
        /// <returns>The record list.</returns>
        /// <privilege>http://tizen.org/privilege/contact.read</privilege>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have proper privileges.</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public ContactsList Search(string viewUri, string keyword, int offset, int limit, int range)
        {
            IntPtr recordList;
            int error = Interop.Database.Search(viewUri, keyword, offset, limit, range, out recordList);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "Search Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            return new ContactsList(recordList);
        }

        /// <summary>
        /// Finds the records based on a given keyword for the snippet.
        /// </summary>
        /// <remarks>
        /// This API works only for the views below:
        /// Person, PersonContact, PersonGroupRelation, PersonGroupAssigned, and PersonGroupNotAssigned.
        /// Because the start match and end match are needed to be composed with a keyword, this API performance is lower than Search (string viewUri, string keyword, int offset, int limit).
        /// </remarks>
        /// <param name="viewUri">The view URI to find records.</param>
        /// <param name="keyword">The keyword.</param>
        /// <param name="offset">The index from which to get results.</param>
        /// <param name="limit">The number to limit results (value 0 is used for get all records).</param>
        /// <param name="startMatch">The text, which is inserted into the fragment before the keyword (If NULL, default is "[".)</param>
        /// <param name="endMatch">The text, which is inserted into the fragment after the keyword (If NULL, default is "]")</param>
        /// <param name="tokenNumber">The one side extra number of tokens near keyword (If negative value, full sentence is printed. For example, if the token number is 3 with 'abc' keyword, snippet string will be like "my name is [abc]de and my home").</param>
        /// <returns>The record list</returns>
        /// <privilege>http://tizen.org/privilege/contact.read</privilege>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have proper privileges.</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public ContactsList Search(string viewUri, string keyword, int offset, int limit, string startMatch, string endMatch, int tokenNumber)
        {
            IntPtr recordList;
            int error = Interop.Database.Search(viewUri, keyword, offset, limit, startMatch, endMatch, tokenNumber, out recordList);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "Search Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            return new ContactsList(recordList);
        }

        /// <summary>
        /// Finds the records based on a given query and keyword for the snippet.
        /// </summary>
        /// <remarks>
        /// This API works only for the views below:
        /// Person, PersonContact, PersonGroupRelation, PersonGroupAssigned, and PersonGroupNotAssigned.
        /// Because the start match and end match are needed to be composed with a keyword, this API performance is lower than Search (ContactsQuery query, string keyword, int offset, int limit).
        /// </remarks>
        /// <param name="query">The query to filter.</param>
        /// <param name="keyword">The keyword.</param>
        /// <param name="offset">The index from which to get results.</param>
        /// <param name="limit">The number to limit results (value 0 is used for get all records).</param>
        /// <param name="startMatch">The text, which is inserted into the fragment before a keyword (If NULL, default is "[").</param>
        /// <param name="endMatch">The text, which is inserted into the fragment after a keyword (If NULL, default is "]".)</param>
        /// <param name="tokenNumber">The one side extra number of tokens near a keyword (If negative value, full sentence is printed. For example, if the token number is 3 with 'abc' keyword, snippet string will be like "my name is [abc]de and my home").</param>
        /// <returns>The record list.</returns>
        /// <privilege>http://tizen.org/privilege/contact.read</privilege>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have proper privileges.</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public ContactsList Search(ContactsQuery query, string keyword, int offset, int limit, string startMatch, string endMatch, int tokenNumber)
        {
            IntPtr recordList;
            int error = Interop.Database.Search(query._queryHandle, keyword, offset, limit, startMatch, endMatch, tokenNumber, out recordList);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "Search Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            return new ContactsList(recordList);
        }

        /// <summary>
        /// Finds the records based on a keyword and range for the snippet.
        /// </summary>
        /// <remarks>
        /// This API works only for the views below:
        /// Person, PersonContact, PersonGroupRelation, PersonGroupAssigned, PersonGroupNotAssigned, PersonNumber, and PersonEmail,
        /// Because the start match and end match are needed to be composed with a keyword, this API performance is lower than Search (string viewUri, string keyword, int offset, int limit, int range).
        /// </remarks>
        /// <param name="viewUri">The view URI.</param>
        /// <param name="keyword">The keyword.</param>
        /// <param name="offset">The index from which to get results.</param>
        /// <param name="limit">The number to limit results (value 0 is used for get all records).</param>
        /// <param name="range">The search range should be an element of the SearchRange or bitwise OR operation of them.</param>
        /// <param name="startMatch">The text, which is inserted into the fragment before a keyword (If NULL, default is "[").</param>
        /// <param name="endMatch">The text, which is inserted into the fragment after a keyword (If NULL, default is "]").</param>
        /// <param name="tokenNumber">The one side extra number of tokens near a keyword (If negative value, full sentence is printed. For example, if a token number is 3 with 'abc' keyword, snippet string will be like "my name is [abc]de and my home").</param>
        /// <returns>The record list.</returns>
        /// <privilege>http://tizen.org/privilege/contact.read</privilege>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have proper privileges.</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public ContactsList Search(string viewUri, string keyword, int offset, int limit, int range, string startMatch, string endMatch, int tokenNumber)
        {
            IntPtr recordList;
            int error = Interop.Database.Search(viewUri, keyword, offset, limit, range, startMatch, endMatch, tokenNumber, out recordList);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "Search Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            return new ContactsList(recordList);
        }

        /// <summary>
        /// Gets the number of records in a specific view.
        /// </summary>
        /// <param name="viewUri">The view URI.</param>
        /// <returns>The count of records.</returns>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public int GetCount(string viewUri)
        {
            int count = -1;
            int error = Interop.Database.GetCount(viewUri, out count);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "GetCount Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            return count;
        }

        /// <summary>
        /// Gets the number of records matching a query.
        /// </summary>
        /// <param name="query">The query used for filtering the results.</param>
        /// <returns>The count of records.</returns>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public int GetCount(ContactsQuery query)
        {
            int count = -1;
            int error = Interop.Database.GetCount(query._queryHandle, out count);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "GetCount Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            return count;
        }

        /// <summary>
        /// Registers an EventHandler to be invoked when a record changes.
        /// </summary>
        /// <param name="viewUri">The view URI of records whose changes are monitored.</param>
        /// <param name="DBChanged">The EventHandler to register.</param>
        /// <privilege>http://tizen.org/privilege/contact.read</privilege>
        /// <privilege>http://tizen.org/privilege/callhistory.read</privilege>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have proper privileges.</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public void AddDBChangedEventHandler(string viewUri, EventHandler<DBChangedEventArgs> DBChanged)
        {
            if (!_callbackMap.ContainsKey(viewUri))
            {
                _callbackMap[viewUri] = (string uri, IntPtr userData) =>
                {
                    DBChangedEventArgs args = new DBChangedEventArgs(uri);
                    _eventHandlerMap[uri]?.Invoke(this, args);
                };

                int error = Interop.Database.AddChangedCb(viewUri, _callbackMap[viewUri], IntPtr.Zero);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "AddDBChangedEventHandler Failed with error " + error);
                    throw ContactsErrorFactory.CheckAndCreateException(error);
                }
            }

            EventHandler<DBChangedEventArgs> handler = null;
            if (!_eventHandlerMap.TryGetValue(viewUri, out handler))
                _eventHandlerMap.Add(viewUri, null);

            _eventHandlerMap[viewUri] = handler + DBChanged;
        }

        /// <summary>
        /// Deregisters an EventHandler.
        /// </summary>
        /// <param name="viewUri">The view URI of records whose changes are monitored.</param>
        /// <param name="DBChanged">The EventHandler to deregister.</param>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public void RemoveDBChangedEventHandler(string viewUri, EventHandler<DBChangedEventArgs> DBChanged)
        {
            EventHandler<DBChangedEventArgs> handler = null;
            if (!_eventHandlerMap.TryGetValue(viewUri, out handler))
                _eventHandlerMap.Add(viewUri, null);
            else
                _eventHandlerMap[viewUri] = handler - DBChanged;

            if (_eventHandlerMap[viewUri] == null)
            {
                int error = Interop.Database.RemoveChangedCb(viewUri, _callbackMap[viewUri], IntPtr.Zero);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "RemoveDBChangedEventHandler Failed with error " + error);
                    throw ContactsErrorFactory.CheckAndCreateException(error);
                }
                _callbackMap.Remove(viewUri);
            }
        }
    }
}
