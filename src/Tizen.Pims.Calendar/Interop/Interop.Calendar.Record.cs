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
using Tizen.Pims.Calendar;

internal static partial class Interop
{
    internal static partial class Calendar
    {
        internal static partial class Record
        {
			[StructLayout(LayoutKind.Sequential)]
			internal struct DateTime
			{
				internal int type;
				internal long utime;
				internal int year;
				internal int month;
				internal int mday;
				internal int hour;
				internal int minute;
				internal int second;
			};

			[DllImport(Libraries.Calendar, EntryPoint = "calendar_record_create")]
            internal static extern int Create(string uri, out IntPtr recordHandle);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_record_destroy")]
            internal static extern int Destroy(IntPtr recordHandle, bool isDeleteChild);
			[DllImport(Libraries.Calendar, EntryPoint = "calendar_record_clone")]
            internal static extern int Clone(IntPtr recordHandle, out IntPtr cloneHandle);
			[DllImport(Libraries.Calendar, EntryPoint = "calendar_record_get_uri_p")]
            internal static extern int GetUriPointer(IntPtr recordHandle, out IntPtr uri);
			[DllImport(Libraries.Calendar, EntryPoint = "calendar_record_get_str")]
            internal static extern int GetString(IntPtr recordHandle, uint propertyId, out string str);
			[DllImport(Libraries.Calendar, EntryPoint = "calendar_record_get_str_p")]
            internal static extern int GetStringPointer(IntPtr recordHandle, uint propertyId, out string str);
			[DllImport(Libraries.Calendar, EntryPoint = "calendar_record_get_int")]
            internal static extern int GetInteger(IntPtr recordHandle, uint propertyId, out int value);
			[DllImport(Libraries.Calendar, EntryPoint = "calendar_record_get_double")]
            internal static extern int GetDouble(IntPtr recordHandle, uint propertyId, out double value);
			[DllImport(Libraries.Calendar, EntryPoint = "calendar_record_get_lli")]
            internal static extern int GetLli(IntPtr recordHandle, uint propertyId, out long value);
			[DllImport(Libraries.Calendar, EntryPoint = "calendar_record_get_caltime")]
            internal static extern int GetCalendarTime(IntPtr recordHandle, uint propertyId, out DateTime value);
			[DllImport(Libraries.Calendar, EntryPoint = "calendar_record_set_str")]
            internal static extern int SetString(IntPtr recordHandle, uint propertyId, string str);
			[DllImport(Libraries.Calendar, EntryPoint = "calendar_record_set_int")]
            internal static extern int SetInteger(IntPtr recordHandle, uint propertyId, int value);
			[DllImport(Libraries.Calendar, EntryPoint = "calendar_record_set_double")]
            internal static extern int SetDouble(IntPtr recordHandle, uint propertyId, double value);
			[DllImport(Libraries.Calendar, EntryPoint = "calendar_record_set_lli")]
            internal static extern int SetLli(IntPtr recordHandle, uint propertyId, long value);
			[DllImport(Libraries.Calendar, EntryPoint = "calendar_record_set_caltime")]
            internal static extern int SetCalendarTime(IntPtr recordHandle, uint propertyId, DateTime value);
			[DllImport(Libraries.Calendar, EntryPoint = "calendar_record_add_child_record")]
            internal static extern int AddChildRecord(IntPtr recordHandle, uint propertyId, IntPtr childHandle);
			[DllImport(Libraries.Calendar, EntryPoint = "calendar_record_remove_child_record")]
            internal static extern int RemoveChildRecord(IntPtr recordHandle, uint propertyId, IntPtr childHandle);
			[DllImport(Libraries.Calendar, EntryPoint = "calendar_record_get_child_record_count")]
            internal static extern int GetChildRecordCount(IntPtr recordHandle, uint propertyId, out int count);
			[DllImport(Libraries.Calendar, EntryPoint = "calendar_record_get_child_record_at_p")]
            internal static extern int GetChildRecordPointer(IntPtr recordHandle, uint propertyId, int index, out IntPtr childHandle);
			[DllImport(Libraries.Calendar, EntryPoint = "calendar_record_clone_child_record_list")]
            internal static extern int CloneChildRecordList(IntPtr childRecordHandle, uint propertyId, out IntPtr listHandle);
        }
    }
}
