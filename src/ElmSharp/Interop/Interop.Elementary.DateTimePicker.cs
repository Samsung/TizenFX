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
    internal static partial class Elementary
    {
        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_datetime_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_datetime_value_set(IntPtr obj, ref Libc.SystemTime newtime);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_datetime_value_get(IntPtr obj, ref Libc.SystemTime currtime);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_datetime_format_set(IntPtr obj, string format);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr _elm_datetime_format_get(IntPtr obj);

        internal static string elm_datetime_format_get(IntPtr obj)
        {
            var format = _elm_datetime_format_get(obj);
            return Marshal.PtrToStringAnsi(format);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_datetime_value_max_set(IntPtr obj, ref Libc.SystemTime maxtime);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_datetime_value_max_get(IntPtr obj, ref Libc.SystemTime maxtime);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_datetime_value_min_set(IntPtr obj, ref Libc.SystemTime mintime);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_datetime_value_min_get(IntPtr obj, ref Libc.SystemTime mintime);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_datetime_field_limit_set(IntPtr obj, int type, int min, int max);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_datetime_field_limit_get(IntPtr obj, int type, out int min, out int max);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_datetime_field_visible_set(IntPtr obj, int type, bool visible);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_datetime_field_visible_get(IntPtr obj, int type);

        internal enum DateTimeFieldType
        {
            Year,
            Month,
            Date,
            Hour,
            Minute,
            AmPm
        }
    }
}

