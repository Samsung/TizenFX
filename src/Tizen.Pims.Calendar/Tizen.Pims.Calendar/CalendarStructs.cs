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

/// <summary>
/// </summary>
/// <remarks>
/// </remarks>
namespace Tizen.Pims.Calendar
{
    /// <summary>
    /// </summary>
    public class CalendarTime : IDisposable
    {
        internal int _type;
        internal DateTime _dateTime;

        /// <summary>
        /// Enumeration for the time type.
        /// </summary>
        public enum Type
        {
            /// <summary>
            /// UTC time
            /// </summary>
            Utc,
            /// <summary>
            /// Local time
            /// </summary>
            Local
        }

        /// <summary>
        /// Get time type.
        /// </summary>
        public int TypeValue
        {
            get
            {
                return _type;
            }
        }

        /// <summary>
        /// Get datatime.
        /// </summary>
        public DateTime DateTime
        {
            get
            {
                return _dateTime;
            }
        }

        /// <summary>
        /// Create UTC CalendarTime
        /// </summary>
        /// <param name="utcTime">UTC epoch time. 0 is 1971/01/01</param>
        public CalendarTime(long utcTime)
        {
            _type = (int)Type.Utc;
            utcTime -= utcTime % 10000000; /* delete millisecond */
            _dateTime = new DateTime(utcTime);
        }

        /// <summary>
        /// Create Local CalendarTime
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="month">month</param>
        /// <param name="day">day</param>
        /// <param name="hour">hour</param>
        /// <param name="minute">minute</param>
        /// <param name="second">second</param>
        public CalendarTime(int year, int month, int day, int hour, int minute, int second)
        {
            _type = (int)Type.Local;
            _dateTime = new DateTime(year, month, day, hour, minute, second);
        }

        /// <summary>
        /// Compare CalendarTime
        /// </summary>
        /// <param name="t1">The first CalendarTime to compare</param>
        /// <param name="t1">The second CalendarTime to compare</param>
        /// <returns>
        /// A signed number indicating the relative values of t1 and t2.
        /// </returns>
        public static int Compare(CalendarTime t1, CalendarTime t2)
        {
            if (t1.TypeValue != t2.TypeValue)
                return -1;

            long ret = (t1.DateTime.Ticks / 10000000) - (t2.DateTime.Ticks / 10000000);
            return (int)(0 == ret ? 0 : (ret / ret));
        }

        /// <summary>
        /// </summary>
        /// <param name=""></param>
        public void Dispose()
        {

        }
    }
}

