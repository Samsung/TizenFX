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
    internal static partial class Calendar
    {
        internal static partial class Database
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void DbChangedCallback(string uri, IntPtr userData);

            [DllImport(Libraries.Calendar, EntryPoint = "calendar_db_insert_record")]
            internal static extern int Insert(IntPtr recordHandle, out int recordId);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_db_get_record")]
            internal static extern int Get(string uri, int recordId, out IntPtr recordHandle);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_db_update_record")]
            internal static extern int Update(IntPtr recordHandle);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_db_delete_record")]
            internal static extern int Delete(string uri, int recordId);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_db_get_all_records")]
            internal static extern int GetAllRecords(string uri, int offset, int limit, out IntPtr recordListHandle);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_db_get_records_with_query")]
            internal static extern int GetRecords(IntPtr queryHandle, int offset, int limit, out IntPtr recordListHandle);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_db_get_count")]
            internal static extern int GetCount(string uri, out int count);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_db_get_count_with_query")]
            internal static extern int GetCountWithQuery(IntPtr queryHandle, out int count);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_db_insert_records")]
            internal static extern int InsertRecords(IntPtr recordListHandle, out IntPtr recordIds, out int count);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_db_update_records")]
            internal static extern int UpdateRecords(IntPtr recordListHandle);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_db_delete_records")]
            internal static extern int DeleteRecords(string uri, int[] ids, int count);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_db_get_current_version")]
            internal static extern int GetCurrentVersion(out int version);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_db_add_changed_cb")]
            internal static extern int AddChangedCallback(string uri, DbChangedCallback callback, IntPtr userData);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_db_remove_changed_cb")]
            internal static extern int RemoveChangedCallback(string uri, DbChangedCallback callback, IntPtr userData);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_db_get_changes_by_version")]
            internal static extern int GetChangesByVersion(string uri, int bookId, int dbVersion, out IntPtr recordListHandle, out int currentDbVersion);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_db_insert_vcalendars")]
            internal static extern int InsertVcalendars(string stream, out IntPtr recordIds, out int count);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_db_replace_vcalendars")]
            internal static extern int ReplaceVcalendars(string stream, int[] ids, int count);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_db_replace_record")]
            internal static extern int Replace(IntPtr recordHandle, int recordId);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_db_replace_records")]
            internal static extern int ReplaceRecords(IntPtr recordListHandle, int[] ids, int count);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_db_get_last_change_version")]
            internal static extern int GetLastChangeVersion(out int lastChangeVersion);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_db_get_changes_exception_by_version")]
            internal static extern int GetChangesException(string uri, int eventId, int dbVersion, out IntPtr recordListHandle);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_db_clean_after_sync")]
            internal static extern int Clean(int bookId, int dbVersion);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_db_link_record")]
            internal static extern int LinkRecord(int baseId, int recordId);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_db_unlink_record")]
            internal static extern int UnlinkRecord(int recordId);
        }
    }
}
