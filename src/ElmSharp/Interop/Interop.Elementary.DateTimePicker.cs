// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Elementary
    {
        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_datetime_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_datetime_value_set(IntPtr obj, ref tm newtime);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_datetime_value_get(IntPtr obj, ref tm currtime);

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
        internal static extern bool elm_datetime_value_max_set(IntPtr obj, ref tm maxtime);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_datetime_value_max_get(IntPtr obj, ref tm maxtime);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_datetime_value_min_set(IntPtr obj, ref tm mintime);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_datetime_value_min_get(IntPtr obj, ref tm mintime);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_datetime_field_limit_set(IntPtr obj, int type, int min, int max);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_datetime_field_limit_get(IntPtr obj, int type, out int min, out int max);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_datetime_field_visible_set(IntPtr obj, int type, bool visible);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_datetime_field_visible_get(IntPtr obj, int type);

        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        internal struct tm
        {
            public int tm_sec;
            public int tm_min;
            public int tm_hour;
            public int tm_mday;
            public int tm_mon;
            public int tm_year;
            public int tm_wday;
            public int tm_yday;
            public int tm_isdst;
        }
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

