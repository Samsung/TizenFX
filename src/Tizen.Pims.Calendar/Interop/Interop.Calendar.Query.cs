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
        internal static partial class Query
        {
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_query_create")]
            internal static extern  int Create(string uri, out IntPtr queryHandle);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_query_destroy")]
            internal static extern  int Destroy(IntPtr queryHandle);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_query_set_projection")]
            internal static extern  int SetProjection(IntPtr queryHandle, uint[] propertyIdArray, int count);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_query_set_distinct")]
            internal static extern  int SetDistinct(IntPtr queryHandle, bool set);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_query_set_filter")]
            internal static extern  int SetFilter(IntPtr queryHandle, IntPtr filterHandle);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_query_set_sort")]
            internal static extern  int SetSort(IntPtr queryHandle, uint propertyId, bool isAscending);
        }
    }
}
