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

using Tizen.Internals;

internal static partial class Interop
{
    internal static partial class Libc
    {
        [DllImport(Libraries.Libc, EntryPoint = "free", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Free(IntPtr ptr);

        // Broken-down time is stored in the structure tm which is defined in <time.h> as follows:
        [NativeStruct("struct tm", Include = "time.h")]
        [StructLayout(LayoutKind.Sequential)]
        internal struct SystemTime
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

            // The glibc version of struct tm has additional fields
            public IntPtr tm_gmtoff;
            public IntPtr tm_zone;

            public static implicit operator SystemTime(DateTime value)
            {
                SystemTime tm = new SystemTime();
                tm.tm_sec = value.Second;
                tm.tm_min = value.Minute;
                tm.tm_hour = value.Hour;
                tm.tm_mday = value.Day;
                tm.tm_mon = value.Month - 1;
                tm.tm_year = value.Year - 1900;
                tm.tm_wday = (int)value.DayOfWeek;
                tm.tm_yday = value.DayOfYear;
                tm.tm_isdst = value.IsDaylightSavingTime() ? 1 : 0;
                return tm;
            }

            public static implicit operator DateTime(SystemTime value)
            {
                DateTime date = new DateTime(value.tm_year + 1900, value.tm_mon + 1, value.tm_mday, value.tm_hour, value.tm_min, value.tm_sec);
                return date;
            }
        }
    }
}
