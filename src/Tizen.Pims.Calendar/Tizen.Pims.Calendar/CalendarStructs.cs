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
    public class CalendarTime : IComparable<CalendarTime>
    {
        internal int _type;
        internal const int milliseconds = 10000000;

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
        /// Create UTC CalendarTime
        /// </summary>
        /// <param name="utcTime">UTC epoch time. 0 is 1971/01/01</param>
        public CalendarTime(long utcTime)
        {
            _type = (int)Type.Utc;
            utcTime -= utcTime % milliseconds; /* delete millisecond */
            UtcTime = new DateTime(utcTime);
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
            LocalTime = new DateTime(year, month, day, hour, minute, second);
        }

        /// <summary>
        /// Get utcTime
        /// </summary>
        public DateTime UtcTime
        {
            get;
        }

        /// <summary>
        /// Get localTime
        /// </summary>
        public DateTime LocalTime
        {
            get;
        }

        /// <summary>
        /// Compare CalendarTime
        /// </summary>
        /// <param name="t">The CalendarTime to be compared</param>
        /// <returns>
        /// A 32-bit signed integer that indicates the relative order of the objects being compared.
        /// </returns>
        public int CompareTo(CalendarTime t)
        {
            if (_type != t._type)
                throw new NotImplementedException("Not to compare with different type");

            if (_type == (int)Type.Utc)
                return UtcTime.CompareTo(t.UtcTime);
            else
                return LocalTime.CompareTo(t.LocalTime);
        }
    }
}

