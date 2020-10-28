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

namespace Tizen.Pims.Calendar
{
    /// <summary>
    /// A class for the time to set, get, or calculate.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class CalendarTime:IComparable<CalendarTime>
    {
        internal int _type;
        internal const int milliseconds = 10000000;

        /// <summary>
        /// Enumeration for the time type.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum Type
        {
            /// <summary>
            /// UTC time.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Utc,
            /// <summary>
            /// Local time.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Local
        }

        /// <summary>
        /// Creates the UTC CalendarTime.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="utcTime">The UTC epoch time. 0 is 1971/01/01.</param>
        public CalendarTime(long utcTime)
        {
            _type = (int)Type.Utc;
            utcTime -= utcTime % milliseconds; /* delete millisecond */
            UtcTime = new DateTime(utcTime);
        }

        /// <summary>
        /// Creates the local CalendarTime
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day.</param>
        /// <param name="hour">The hour.</param>
        /// <param name="minute">The minute.</param>
        /// <param name="second">The second.</param>
        public CalendarTime(int year, int month, int day, int hour, int minute, int second)
        {
            _type = (int)Type.Local;
            LocalTime = new DateTime(year, month, day, hour, minute, second);
        }

        /// <summary>
        /// Gets the UtcTime.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <value>The UTC time.</value>
        public DateTime UtcTime
        {
            get;
        }

        /// <summary>
        /// Gets the LocalTime
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <value>The local time.</value>
        public DateTime LocalTime
        {
            get;
        }

        /// <summary>
        /// Compares the CalendarTime.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="other">The CalendarTime to be compared.</param>
        /// <returns>
        /// A 32-bit signed integer that indicates the relative order of the objects being compared.
        /// </returns>
        public int CompareTo(CalendarTime other)
        {
            if (_type != other._type)
            {
                Log.Error(Globals.LogTag, "Not to compare with different type");
                throw CalendarErrorFactory.GetException((int)CalendarError.InvalidParameter);
            }

            if (_type == (int)Type.Utc)
                return UtcTime.CompareTo(other.UtcTime);
            else
                return LocalTime.CompareTo(other.LocalTime);
        }

        /// <summary>
        /// Equals the CalendarTime.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="obj">The CalendarTime to be compared.</param>
        /// <returns>
        /// A 32-bit signed integer that indicates the relative order of the objects being compared.
        /// </returns>
        public override bool Equals(object obj)
        {
            var other = obj as CalendarTime;
            if (other == null || _type != other._type)
            {
                Log.Error(Globals.LogTag, "Not to compare with different type");
                return false;
            }

            if (_type == (int)Type.Utc)
                return UtcTime.Equals(other.UtcTime);
            else
                return LocalTime.Equals(other.LocalTime);
        }

        /// <summary>
        /// The GetHashCode for the CalendarTime.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <returns>
        /// A hash code for the current object.
        /// </returns>
        public override int GetHashCode()
        {
            if (_type == (int)Type.Utc)
                return this.UtcTime.GetHashCode();
            else
                return this.LocalTime.GetHashCode();
        }
    }
}

