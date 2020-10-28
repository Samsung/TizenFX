/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using static Tizen.Pims.Calendar.CalendarFilter;

internal static partial class Interop
{
    internal static partial class Filter
    {
        [DllImport(Libraries.Calendar, EntryPoint = "calendar_filter_create")]
            internal static extern int Create(string uri, out IntPtr filterHandle);
        [DllImport(Libraries.Calendar, EntryPoint = "calendar_filter_destroy")]
            internal static extern int Destroy(IntPtr filterHandle);
        [DllImport(Libraries.Calendar, EntryPoint = "calendar_filter_add_str")]
            internal static extern int AddString(IntPtr filterHandle, uint propertyId, StringMatchType match, string value);
        [DllImport(Libraries.Calendar, EntryPoint = "calendar_filter_add_int")]
            internal static extern int AddInteger(IntPtr filterHandle, uint propertyId, IntegerMatchType match, int value);
        [DllImport(Libraries.Calendar, EntryPoint = "calendar_filter_add_double")]
            internal static extern int AddDouble(IntPtr filterHandle, uint propertyId, IntegerMatchType match, double value);
        [DllImport(Libraries.Calendar, EntryPoint = "calendar_filter_add_lli")]
            internal static extern int AddLong(IntPtr filterHandle, uint propertyId, IntegerMatchType match, long value);
        [DllImport(Libraries.Calendar, EntryPoint = "calendar_filter_add_caltime")]
            internal static extern int AddCalendarTime(IntPtr filterHandle, uint propertyId, IntegerMatchType match, IntPtr value);
        [DllImport(Libraries.Calendar, EntryPoint = "calendar_filter_add_filter")]
            internal static extern int AddFilter(IntPtr parentFilterHandle, IntPtr childFilterHandle);
        [DllImport(Libraries.Calendar, EntryPoint = "calendar_filter_add_operator")]
            internal static extern int AddOperator(IntPtr filterHandle, LogicalOperator type);
    }
}
