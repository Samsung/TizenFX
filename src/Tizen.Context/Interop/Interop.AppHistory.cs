/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// <summary>
    /// The CtxHistory Interop class.
    /// Deprecated since API13
    /// </summary>
    internal static partial class CtxHistory
    {
        [DllImport(Library.AppHistory, EntryPoint = "ctx_history_query")]
        internal static extern int Query(string uri, Int64 startTime, Int64 endTime, uint resultSize, out IntPtr cursor);

        [DllImport(Library.AppHistory, EntryPoint = "ctx_history_is_supported")]
        internal static extern int IsSupported(string subject, out bool supported);

        [DllImport(Library.AppHistory, EntryPoint = "ctx_history_get_last_fully_charged_time")]
        internal static extern int GetLastFullyChargedTime(out Int64 timestamp);

    }

    /// <summary>
    /// The CtxHistoryCursor Interop class.
    /// Deprecated since API13
    /// </summary>
    internal static partial class CtxHistoryCursor
    {
        [DllImport(Library.AppHistory, EntryPoint = "ctx_history_cursor_destroy")]
        internal static extern void Destroy(IntPtr cursor);

        [DllImport(Library.AppHistory, EntryPoint = "ctx_history_cursor_get_count")]
        internal static extern int GetCount(IntPtr cursor, out int count);

        [DllImport(Library.AppHistory, EntryPoint = "ctx_history_cursor_get_position")]
        internal static extern int GetPosition(IntPtr cursor, out int position);

        [DllImport(Library.AppHistory, EntryPoint = "ctx_history_cursor_set_position")]
        internal static extern int SetPosition(IntPtr cursor, int position);

        [DllImport(Library.AppHistory, EntryPoint = "ctx_history_cursor_first")]
        internal static extern int First(IntPtr cursor);

        [DllImport(Library.AppHistory, EntryPoint = "ctx_history_cursor_last")]
        internal static extern int Last(IntPtr cursor);

        [DllImport(Library.AppHistory, EntryPoint = "ctx_history_cursor_next")]
        internal static extern int Next(IntPtr cursor);

        [DllImport(Library.AppHistory, EntryPoint = "ctx_history_cursor_prev")]
        internal static extern int Prev(IntPtr cursor);

        [DllImport(Library.AppHistory, EntryPoint = "ctx_history_cursor_get_int64")]
        internal static extern int GetInt64(IntPtr cursor, string key, out Int64 value);

        [DllImport(Library.AppHistory, EntryPoint = "ctx_history_cursor_get_double")]
        internal static extern int GetDouble(IntPtr cursor, string key, out double value);

        [DllImport(Library.AppHistory, EntryPoint = "ctx_history_cursor_get_string")]
        internal static extern int GetString(IntPtr cursor, string key, out string value);
    }
}
