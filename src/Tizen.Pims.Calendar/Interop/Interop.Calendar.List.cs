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
        internal static partial class List
        {
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_list_create")]
            internal static extern  int Create(out IntPtr listHandle);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_list_destroy")]
            internal static extern  int Destroy(IntPtr listHandle, bool delete);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_list_get_count")]
            internal static extern  int GetCount(IntPtr listHandle, out int count);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_list_add")]
            internal static extern  int Add(IntPtr listHandle, IntPtr recordHandle);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_list_remove")]
            internal static extern  int Remove(IntPtr listHandle, IntPtr recordHandle);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_list_get_current_record_p")]
            internal static extern  int GetCurrentRecordP(IntPtr listHandle, out IntPtr recordHandle);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_list_prev")]
            internal static extern  int Prev(IntPtr listHandle);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_list_next")]
            internal static extern  int Next(IntPtr listHandle);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_list_first")]
            internal static extern  int First(IntPtr listHandle);
            [DllImport(Libraries.Calendar, EntryPoint = "calendar_list_last")]
            internal static extern  int Last(IntPtr listHandle);
        }
    }
}
