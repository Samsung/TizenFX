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
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal enum ContactsChanged
    {
        Inserted,
        Updated,
        Deleted
    }

    internal static partial class Database
    {
        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_insert_record")]
        internal static extern int Insert(IntPtr recordHandle, out int recordId);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_get_record")]
        internal static extern int Get(string uri, int recordId, out IntPtr recordHandle);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_update_record")]
        internal static extern int Update(IntPtr recordHandle);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_delete_record")]
        internal static extern int Delete(string uri, int recordId);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_replace_record")]
        internal static extern int Replace(IntPtr recordHandle, int recordId);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_get_all_records")]
        internal static extern int GetRecords(string uri, int offset, int limit, out IntPtr listHandle);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_get_records_with_query")]
        internal static extern int GetRecords(IntPtr queryHandle, int offset, int limit, out IntPtr listHandle);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_insert_records")]
        internal static extern int InsertRecords(IntPtr listHandle, out IntPtr ids, out int count);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_update_records")]
        internal static extern int UpdateRecords(IntPtr listHandle);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_delete_records")]
        internal static extern int DeleteRecords(string uri, int[] recordIdArray, int count);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_replace_records")]
        internal static extern int ReplaceRecords(IntPtr listHandle, int[] recordIdArray, int count);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_get_current_version")]
        internal static extern int GetVersion(out int contactsDBVersion);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_add_changed_cb")]
        internal static extern int AddChangedCb(string uri, ContactsDBChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_remove_changed_cb")]
        internal static extern int RemoveChangedCb(string uri, ContactsDBChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_get_changes_by_version")]
        internal static extern int GetChangesByVersion(string uri, int addressBookId, int contactsDBVersion, out IntPtr changeRecordList, out int currentContactsDBVersion);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_search_records")]
        internal static extern int Search(string uri, string keyword, int offset, int limit, out IntPtr listHandle);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_search_records_with_query")]
        internal static extern int Search(IntPtr queryHandle, string keyword, int offset, int limit, out IntPtr listHandle);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_search_records_with_range")]
        internal static extern int Search(string uri, string keyword, int offset, int limit, int range, out IntPtr listHandle);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_search_records_for_snippet")]
        internal static extern int Search(string uri, string keyword, int offset, int limit, string startMatch, string endMatch, int tokenNumber, out IntPtr listHandle);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_search_records_with_query_for_snippet")]
        internal static extern int Search(IntPtr queryHandle, string keyword, int offset, int limit, string startMatch, string endMatch, int tokenNumber, out IntPtr listHandle);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_search_records_with_range_for_snippet")]
        internal static extern int Search(string uri, string keyword, int offset, int limit, int range, string startMatch, string endMatch, int tokenNumber, out IntPtr listHandle);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_get_count")]
        internal static extern int GetCount(string uri, out int count);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_get_count_with_query")]
        internal static extern int GetCount(IntPtr queryHandle, out int count);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_get_last_change_version")]
        internal static extern int GetLastChangeVersion(out int version);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_get_status")]
        internal static extern int GetStatus(out Tizen.Pims.Contacts.ContactsDatabase.DBStatus status);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_add_status_changed_cb")]
        internal static extern int AddStatusChangedCb(ContactsDBStatusChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_db_remove_status_changed_cb")]
        internal static extern int RemoveStatusChangedCb(ContactsDBStatusChangedCallback callback, IntPtr userData);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void ContactsDBChangedCallback(string uri, IntPtr userData);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void ContactsDBStatusChangedCallback(Tizen.Pims.Contacts.ContactsDatabase.DBStatus status, IntPtr userData);
    }
}
