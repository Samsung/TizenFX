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
            internal static extern int GetCalendarTime(IntPtr recordHandle, uint propertyId, out IntPtr value);
        [DllImport(Libraries.Calendar, EntryPoint = "calendar_record_set_str")]
            internal static extern int SetString(IntPtr recordHandle, uint propertyId, string str);
        [DllImport(Libraries.Calendar, EntryPoint = "calendar_record_set_int")]
            internal static extern int SetInteger(IntPtr recordHandle, uint propertyId, int value);
        [DllImport(Libraries.Calendar, EntryPoint = "calendar_record_set_double")]
            internal static extern int SetDouble(IntPtr recordHandle, uint propertyId, double value);
        [DllImport(Libraries.Calendar, EntryPoint = "calendar_record_set_lli")]
            internal static extern int SetLli(IntPtr recordHandle, uint propertyId, long value);
        [DllImport(Libraries.Calendar, EntryPoint = "calendar_record_set_caltime")]
            internal static extern int SetCalendarTime(IntPtr recordHandle, uint propertyId, IntPtr value);
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

        [DllImport(Libraries.Calendar, EntryPoint = "cal_caltime_create")]
        internal static extern IntPtr CreateCalTime();
        [DllImport(Libraries.Calendar, EntryPoint = "cal_caltime_destroy")]
        internal static extern void DestroyCalTime(IntPtr caltime);
        [DllImport(Libraries.Calendar, EntryPoint = "cal_caltime_get_local_type")]
        internal static extern int GetCalTimeType(IntPtr caltime);
        [DllImport(Libraries.Calendar, EntryPoint = "cal_caltime_get_local_utime")]
        internal static extern long GetCalTimeUtime(IntPtr caltime);
        [DllImport(Libraries.Calendar, EntryPoint = "cal_caltime_get_local_year")]
        internal static extern int GetCalTimeLocalYear(IntPtr caltime);
        [DllImport(Libraries.Calendar, EntryPoint = "cal_caltime_get_local_month")]
        internal static extern int GetCalTimeLocalMonth(IntPtr caltime);
        [DllImport(Libraries.Calendar, EntryPoint = "cal_caltime_get_local_mday")]
        internal static extern int GetCalTimeLocalMday(IntPtr caltime);
        [DllImport(Libraries.Calendar, EntryPoint = "cal_caltime_get_local_hour")]
        internal static extern int GetCalTimeLocalHour(IntPtr caltime);
        [DllImport(Libraries.Calendar, EntryPoint = "cal_caltime_get_local_minute")]
        internal static extern int GetCalTimeLocalMinute(IntPtr caltime);
        [DllImport(Libraries.Calendar, EntryPoint = "cal_caltime_get_local_second")]
        internal static extern int GetCalTimeLocalSecond(IntPtr caltime);


        [DllImport(Libraries.Calendar, EntryPoint = "cal_caltime_set_local_type")]
        internal static extern int SetCalTimeType(IntPtr caltime, int type);
        [DllImport(Libraries.Calendar, EntryPoint = "cal_caltime_set_local_utime")]
        internal static extern int SetCalTimeUtime(IntPtr caltime, long utime);
        [DllImport(Libraries.Calendar, EntryPoint = "cal_caltime_set_local_year")]
        internal static extern int SetCalTimeLocalYear(IntPtr caltime, int year);
        [DllImport(Libraries.Calendar, EntryPoint = "cal_caltime_set_local_month")]
        internal static extern int SetCalTimeLocalMonth(IntPtr caltime, int month);
        [DllImport(Libraries.Calendar, EntryPoint = "cal_caltime_set_local_mday")]
        internal static extern int SetCalTimeLocalMday(IntPtr caltime, int mday);
        [DllImport(Libraries.Calendar, EntryPoint = "cal_caltime_set_local_hour")]
        internal static extern int SetCalTimeLocalHour(IntPtr caltime, int hour);
        [DllImport(Libraries.Calendar, EntryPoint = "cal_caltime_set_local_minute")]
        internal static extern int SetCalTimeLocalMinute(IntPtr caltime, int minute);
        [DllImport(Libraries.Calendar, EntryPoint = "cal_caltime_set_local_second")]
        internal static extern int SetCalTimeLocalSecond(IntPtr caltime, int second);


        [DllImport(Libraries.Calendar, EntryPoint = "cal_caltime_set_caltime")]
        internal static extern int SetCalTime(IntPtr recordHandle, uint propertyId, IntPtr value);
        [DllImport(Libraries.Calendar, EntryPoint = "cal_caltime_get_caltime")]
        internal static extern int GetCalTime(IntPtr recordHandle, uint propertyId, out IntPtr value);
    }
}
