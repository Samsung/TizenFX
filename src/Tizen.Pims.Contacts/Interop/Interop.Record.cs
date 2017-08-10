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
    internal static partial class Record
    {
        [DllImport(Libraries.Contacts, EntryPoint = "contacts_record_create")]
        internal static extern int Create(string uri, out IntPtr recordIdHandle);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_record_destroy")]
        internal static extern int Destroy(IntPtr recordHandle, bool deleteChild);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_record_clone")]
        internal static extern int Clone(IntPtr recordHandle, out IntPtr clonedRecordHandle);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_record_get_str")]
        internal static extern int GetStr(IntPtr recordHandle, uint propertyId, out string value);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_record_get_str_p")]
        internal static extern int GetStrP(IntPtr recordHandle, uint propertyId, out string value);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_record_set_str")]
        internal static extern int SetStr(IntPtr recordHandle, uint propertyId, string value);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_record_get_int")]
        internal static extern int GetInt(IntPtr recordHandle, uint propertyId, out int value);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_record_set_int")]
        internal static extern int SetInt(IntPtr recordHandle, uint propertyId, int value);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_record_get_lli")]
        internal static extern int GetLli(IntPtr recordHandle, uint propertyId, out long value);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_record_set_lli")]
        internal static extern int SetLli(IntPtr recordHandle, uint propertyId, long value);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_record_get_bool")]
        internal static extern int GetBool(IntPtr recordHandle, uint propertyId, out bool value);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_record_set_bool")]
        internal static extern int SetBool(IntPtr recordHandle, uint propertyId, bool value);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_record_get_double")]
        internal static extern int GetDouble(IntPtr recordHandle, uint propertyId, out double value);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_record_set_double")]
        internal static extern int SetDouble(IntPtr recordHandle, uint propertyId, double value);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_record_add_child_record")]
        internal static extern int AddChildRecord(IntPtr recordHandle, uint propertyId, IntPtr childRecordHandle);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_record_remove_child_record")]
        internal static extern int RemoveChildRecord(IntPtr recordHandle, uint propertyId, IntPtr childRecordHandle);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_record_get_child_record_count")]
        internal static extern int GetChildRecordCount(IntPtr recordHandle, uint propertyId, out int count);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_record_get_child_record_at_p")]
        internal static extern int GetChildRecordAtP(IntPtr recordHandle, uint propertyId, int index, out IntPtr childRecordHandle);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_record_clone_child_record_list")]
        internal static extern int CloneChildRecordList(IntPtr recordHandle, uint propertyId, out IntPtr clonedListHandle);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_record_get_uri_p")]
        internal static extern int GetUriP(IntPtr recordHandle, out IntPtr uri);
    }
}
