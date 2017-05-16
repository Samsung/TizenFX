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

namespace Tizen.Pims.Contacts
{
    /// <summary>
    /// ContactsDatabase provides methods to manage contacts information from/to the database.
    /// </summary>
    /// <remarks>
    /// This class allows user to access/create/update db operations for contacts information.
    /// </remarks>
    public class ContactsDatabase
    {
        /// <summary>
        /// Delegete for detecting the contacts database changes
        /// </summary>
        /// <param name="uri">The contacts view URI</param>
        /// <remarks>
        /// The delegate must be registered using AddDBChangedDelegate.
        /// It's invoked when the designated view changes.
        /// </remarks>
        /// <see cref="AddDBChangedDelegate"/>
        public delegate void ContactsDBChangedDelegate(string uri);
        private Object thisLock = new Object();
        private Interop.Database.ContactsDBStatusChangedCallback _contactsDBStatusChangedCallback;
        private event EventHandler<DBStatusChangedEventArgs> _dbStatusChanged;
        private Dictionary<string, ContactsDBChangedDelegate> _callbackMap = new Dictionary<string, ContactsDBChangedDelegate>();
        private Dictionary<string, Interop.Database.ContactsDBChangedCallback> _delegateMap = new Dictionary<string, Interop.Database.ContactsDBChangedCallback>();
        private Interop.Database.ContactsDBChangedCallback _dbChangedDelegate;

        internal ContactsDatabase()
        {
            ///To be created in ContactsManager only.
        }

        /// <summary>
        /// Enumeration for contacts database status.
        /// </summary>
        public enum DBStatus
        {
            /// <summary>
            /// Normal
            /// </summary>
            Normal,
            /// <summary>
            /// Changing collation.
            /// </summary>
            ChangingCollation
        }

        /// <summary>
        /// Enumeration for Contacts search range.
        /// </summary>
        public enum SearchRange
        {
            /// <summary>
            /// Search record from name
            /// </summary>
            Name = 0x00000001,
            /// <summary>
            /// Search record from name and number
            /// </summary>
            Number = 0x00000002,
            /// <summary>
            /// Search record from name,number and data
            /// </summary>
            Data = 0x00000004,
            /// <summary>
            /// Search record from name,number,data and email. Now, support only PersonEmail view
            /// </summary>
            Email = 0x00000008,
        }

        /// <summary>
        /// Occurs when contacts database status is changed.
        /// </summary>
        public event EventHandler<DBStatusChangedEventArgs> DBStatusChanged
        {
            add
            {
                lock (thisLock)
                {
                    _contactsDBStatusChangedCallback = (DBStatus status, IntPtr userData) =>
                    {
                        DBStatusChangedEventArgs args = new DBStatusChangedEventArgs(status);
                        _dbStatusChanged?.Invoke(this, args);
                    };

                    int error = Interop.Database.AddStatusChangedCb(_contactsDBStatusChangedCallback, IntPtr.Zero);
                    if ((int)ContactsError.None != error)
                    {
                        Log.Error(Globals.LogTag, "Add StatusChanged Failed with error " + error);
                    }
                    else
                    {
                        _dbStatusChanged += value;
                    }
                }

            }

            remove
            {
                lock (thisLock)
                {
                    int error = Interop.Database.RemoveStatusChangedCb(_contactsDBStatusChangedCallback, IntPtr.Zero);
                    if ((int)ContactsError.None != error)
                    {
                        Log.Error(Globals.LogTag, "Remove StatusChanged Failed with error " + error);
                    }

                    _dbStatusChanged -= value;
                }
            }

        }

        /// <summary>
        /// The contacts database status.
        /// </summary>
        public DBStatus Status
        {
            get
            {
                DBStatus status;
                int error = Interop.Database.GetStatus(out status);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "GetStatus Failed with error " + error);
                }
                return status;
            }
        }

        /// <summary>
        /// Gets current contacts database version.
        /// </summary>
        /// <returns>The current contacts database version</returns>
        /// <privilege>http://tizen.org/privilege/contact.read</privilege>
        /// <privilege>http://tizen.org/privilege/callhistory.read</privilege>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
        public int GetVersion()
        {
            int version = -1;
            int error = Interop.Database.GetVersion(out version);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "GetVersion() Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            return version;
        }

        /// <summary>
        /// Gets last successful changed contacts database version on the current connection.
        /// </summary>
        /// <returns>The last successful changed contacts database version on the current connection</returns>
        /// <privilege>http://tizen.org/privilege/contact.read</privilege>
        /// <privilege>http://tizen.org/privilege/callhistory.read</privilege>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
        public int GetLastChangeVersion
        {
            get
            {
                int version = -1;
                int error = Interop.Database.GetLastChangeVersion(out version);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "GetLastChangeVersion Failed with error " + error);
                }
                return version;
            }
        }

        /// <summary>
        /// Inserts a record into the contacts database.
        /// </summary>
        /// <param name="record">The record to insert</param>
        /// <returns>The ID of inserted record</returns>
        /// <privilege>http://tizen.org/privilege/contact.write</privilege>
        /// <privilege>http://tizen.org/privilege/callhistory.write</privilege>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="NotSupportedException">Thrown when an invoked method is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
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
        /// <param name="list">The record list</param>
        /// <returns>The inserted record ID array</returns>
        /// <privilege>http://tizen.org/privilege/contact.write</privilege>
        /// <privilege>http://tizen.org/privilege/callhistory.write</privilege>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="NotSupportedException">Thrown when an invoked method is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
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
        /// <param name="viewUri">The view URI of a record</param>
        /// <param name="recordId">The record ID</param>
        /// <returns>The record associated with the record ID</returns>
        /// <privilege>http://tizen.org/privilege/contact.read</privilege>
        /// <privilege>http://tizen.org/privilege/callhistory.read</privilege>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="NotSupportedException">Thrown when an invoked method is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
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
        /// <param name="record">The record to update</param>
        /// <privilege>http://tizen.org/privilege/contact.write</privilege>
        /// <privilege>http://tizen.org/privilege/callhistory.write</privilege>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="NotSupportedException">Thrown when an invoked method is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
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
        /// <param name="list">The record list</param>
        /// <privilege>http://tizen.org/privilege/contact.write</privilege>
        /// <privilege>http://tizen.org/privilege/callhistory.write</privilege>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="NotSupportedException">Thrown when an invoked method is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
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
        /// Deletes a record from the contacts database with related child records.
        /// </summary>
        /// <param name="viewUri">The view URI of a record</param>
        /// <param name="recordId">The record ID to delete</param>
        /// <privilege>http://tizen.org/privilege/contact.write</privilege>
        /// <privilege>http://tizen.org/privilege/callhistory.write</privilege>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="NotSupportedException">Thrown when an invoked method is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
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
        /// Deletes multiple records with related child records from the contacts database as a batch operation.
        /// </summary>
        /// <param name="viewUri">The view URI of the records to delete</param>
        /// <param name="idArray">The record IDs to delete</param>
        /// <privilege>http://tizen.org/privilege/contact.write</privilege>
        /// <privilege>http://tizen.org/privilege/callhistory.write</privilege>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="NotSupportedException">Thrown when an invoked method is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
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
        /// <param name="record">The record to replace</param>
        /// <param name="id">the record ID to be replaced</param>
        /// <privilege>http://tizen.org/privilege/contact.write</privilege>
        /// <privilege>http://tizen.org/privilege/callhistory.write</privilege>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="NotSupportedException">Thrown when an invoked method is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
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
        /// <param name="list">The record list to replace</param>
        /// <param name="idArray">The record IDs to be replaced</param>
        /// <privilege>http://tizen.org/privilege/contact.write</privilege>
        /// <privilege>http://tizen.org/privilege/callhistory.write</privilege>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="NotSupportedException">Thrown when an invoked method is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
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
        /// Retrieves all records as a list.
        /// </summary>
        /// <param name="viewUri">The view URI to get records</param>
        /// <param name="offset">The index from which results</param>
        /// <param name="limit">The number to limit results(value 0 is used for all records)</param>
        /// <returns>
        /// The record list
        /// </returns>
        /// <privilege>http://tizen.org/privilege/contact.read</privilege>
        /// <privilege>http://tizen.org/privilege/callhistory.read</privilege>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="NotSupportedException">Thrown when an invoked method is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
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
        /// Retrieves records using a query.
        /// </summary>
        /// <param name="query">The query to filter the results</param>
        /// <param name="offset">The index from which to get results</param>
        /// <param name="limit">The number to limit results(value 0 is used for get all records)</param>
        /// <returns>
        /// The record list
        /// </returns>
        /// <privilege>http://tizen.org/privilege/contact.read</privilege>
        /// <privilege>http://tizen.org/privilege/callhistory.read</privilege>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="NotSupportedException">Thrown when an invoked method is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
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
        /// Retrieves records changes since the given database version.
        /// </summary>
        /// <param name="viewUri">The view URI to get records</param>
        /// <param name="addressbookId">The address book ID to filter</param>
        /// <param name="contactsDBVersion">The contacts database version</param>
        /// <param name="currentDBVersion">The current contacts database version</param>
        /// <returns>
        /// The record list
        /// </returns>
        /// <privilege>http://tizen.org/privilege/contact.read</privilege>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="NotSupportedException">Thrown when an invoked method is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
        public ContactsList GetChangesByVersion(string viewUri, int addressbookId, int contactsDBVersion, out int currentDBVersion)
        {
            IntPtr recordList;
            int error = Interop.Database.GetChangesByVersion(viewUri, addressbookId, contactsDBVersion, out recordList,out currentDBVersion);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "GetChangesByVersion Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            return new ContactsList(recordList);
        }

        /// <summary>
        /// Finds records based on a given keyword.
        /// </summary>
        /// <remarks>
        /// This API works only for the Views below.
        /// Person, PersonContact, PersonGroupRelation, PersonGroupAssigned and PersonGroupNotAssigned.
        /// </remarks>
        /// <param name="viewUri">The view URI to find records</param>
        /// <param name="keyword">The keyword</param>
        /// <param name="offset">The index from which to get results</param>
        /// <param name="limit">The number to limit results(value 0 is used for get all records)</param>
        /// <returns></returns>
        /// <privilege>http://tizen.org/privilege/contact.read</privilege>
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
        /// Finds records based on given query and keyword.
        /// </summary>
        /// <remarks>
        /// This API works only for the Views below.
        /// Person, PersonContact, PersonGroupRelation, PersonGroupAssigned and PersonGroupNotAssigned.
        /// </remarks>
        /// <param name="query">The query to filter</param>
        /// <param name="keyword">The keyword</param>
        /// <param name="offset">The index from which to get results</param>
        /// <param name="limit">The number to limit results(value 0 used for get all records)</param>
        /// <returns>The record list</returns>
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
        /// Finds records based on a keyword and range.
        /// </summary>
        /// <remarks>
        /// This API works only for the Views below.
        /// Person, PersonContact, PersonGroupRelation, PersonGroupAssigned, PersonGroupNotAssigned, PersonNumber and PersonEmail
        /// </remarks>
        /// <param name="viewUri">The view URI</param>
        /// <param name="keyword">The keyword</param>
        /// <param name="offset">The index from which to get results</param>
        /// <param name="limit">The number to limit results(value 0 is used for get all records)</param>
        /// <param name="range">The search range</param>
        /// <returns>The record list</returns>
        public ContactsList Search(string viewUri, string keyword, int offset, int limit, int range)
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
        /// Finds records based on a given keyword for snippet
        /// </summary>
        /// <remarks>
        /// This API works only for the Views below.
        /// Person, PersonContact, PersonGroupRelation, PersonGroupAssigned and PersonGroupNotAssigned.
        /// Because start match and end match are needed to be composed with keyword, this API performance is lower than Search(string viewUri, string keyword, int offset, int limit).
        /// </remarks>
        /// <param name="viewUri">The view URI to find records</param>
        /// <param name="keyword">The keyword</param>
        /// <param name="offset">The index from which to get results</param>
        /// <param name="limit">The number to limit results(value 0 used for get all records)</param>
        /// <param name="startMatch">The text which is inserted into the fragment before the keyword(If NULL, default is "[")</param>
        /// <param name="endMatch">The text which is inserted into the fragment after the keyword(If NULL, default is "]")</param>
        /// <param name="tokenNumber">The one side extra number of tokens near keyword(If negative value, full sentence is printed. e.g. if token number is 3 with 'abc' keyword, "my name is [abc]de and my home")</param>
        /// <returns>The record list</returns>
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
        /// Finds records based on given query and keyword for snippet.
        /// </summary>
        /// <remarks>
        /// This API works only for the Views below.
        /// Person, PersonContact, PersonGroupRelation, PersonGroupAssigned and PersonGroupNotAssigned.
        /// Because start match and end match are needed to be composed with keyword, this API performance is lower than Search(ContactsQuery query, string keyword, int offset, int limit).
        /// </remarks>
        /// <param name="query">The query to filter</param>
        /// <param name="keyword">The keyword</param>
        /// <param name="offset">The index from which to get results</param>
        /// <param name="limit">The number to limit results(value 0 used for get all records)</param>
        /// <param name="startMatch">The text which is inserted into the fragment before the keyword(If NULL, default is "[")</param>
        /// <param name="endMatch">The text which is inserted into the fragment after the keyword(If NULL, default is "]")</param>
        /// <param name="tokenNumber">The one side extra number of tokens near keyword(If negative value, full sentence is printed. e.g. if token number is 3 with 'abc' keyword, "my name is [abc]de and my home")</param>
        /// <returns>The record list</returns>
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
        /// Finds records based on a keyword and range for snippet.
        /// </summary>
        /// <remarks>
        /// This API works only for the Views below.
        /// Person, PersonContact, PersonGroupRelation, PersonGroupAssigned, PersonGroupNotAssigned, PersonNumber and PersonEmail
        /// Because start match and end match are needed to be composed with keyword, this API performance is lower than Search(string viewUri, string keyword, int offset, int limit, int range).
        /// </remarks>
        /// <param name="viewUri">The view URI</param>
        /// <param name="keyword">The keyword</param>
        /// <param name="offset">The index from which to get results</param>
        /// <param name="limit">The number to limit results(value 0 is used for get all records)</param>
        /// <param name="range">The search range</param>
        /// <param name="startMatch">The text which is inserted into the fragment before the keyword(If NULL, default is "[")</param>
        /// <param name="endMatch">The text which is inserted into the fragment after the keyword(If NULL, default is "]")</param>
        /// <param name="tokenNumber">The one side extra number of tokens near keyword(If negative value, full sentence is printed. e.g. if token number is 3 with 'abc' keyword, "my name is [abc]de and my home")</param>
        /// <returns>The record list</returns>
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
        /// Gets the number of records in a specific view
        /// </summary>
        /// <param name="viewUri">The view URI</param>
        /// <returns>The count of records</returns>
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
        /// <param name="query">The query used for filtering the results</param>
        /// <returns>The count of records</returns>
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
        /// Registers a callback function to be invoked when a record changes.
        /// </summary>
        /// <param name="viewUri">The view URI of records whose changes are monitored</param>
        /// <param name="callback">The callback function to register</param>
        public void AddDBChangedDelegate(string viewUri, ContactsDBChangedDelegate callback)
        {
            _dbChangedDelegate = (string uri, IntPtr userData) =>
            {
                _callbackMap[uri](uri);
            };
            int error = Interop.Database.AddChangedCb(viewUri, _dbChangedDelegate, IntPtr.Zero);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "AddDBChangedDelegate Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            _callbackMap[viewUri] = callback;
            _delegateMap[viewUri] = _dbChangedDelegate;
        }

        /// <summary>
        /// Unregisters a callback function.
        /// </summary>
        /// <param name="viewUri">The view URI of records whose changes are monitored</param>
        /// <param name="callback">The callback function to register</param>
        public void RemoveDBChangedDelegate(string viewUri, ContactsDBChangedDelegate callback)
        {
            int error = Interop.Database.RemoveChangedCb(viewUri, _delegateMap[viewUri], IntPtr.Zero);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "RemoveDBChangedDelegate Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
            _callbackMap.Remove(viewUri);
            _delegateMap.Remove(viewUri);
        }
    }
}
