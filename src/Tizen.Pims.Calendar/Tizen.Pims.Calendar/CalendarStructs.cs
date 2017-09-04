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
    /// A class for time to set, get or calculate.
    /// </summary>
    public class CalendarTime:IComparable<CalendarTime>
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
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        public CalendarTime(int year, int month, int day, int hour, int minute, int second)
        {
            _type = (int)Type.Local;
            LocalTime = new DateTime(year, month, day, hour, minute, second);
        }

        /// <summary>
        /// Get UtcTime
        /// </summary>
        /// <value>The Utc time</value>
        public DateTime UtcTime
        {
            get;
        }

        /// <summary>
        /// Get localTime
        /// </summary>
        /// <value>The Localtime</value>
        public DateTime LocalTime
        {
            get;
        }

        /// <summary>
        /// Compare CalendarTime
        /// </summary>
        /// <param name="other">The CalendarTime to be compared</param>
        /// <returns>
        /// A 32-bit signed integer that indicates the relative order of the objects being compared.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
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
        /// Equals CalendarTime
        /// </summary>
        /// <param name="other">The CalendarTime to be compared</param>
        /// <returns>
        /// A 32-bit signed integer that indicates the relative order of the objects being compared.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        public override bool Equals(object obj)
        {
            var other = obj as CalendarTime;
            if (_type != other._type)
            {
                Log.Error(Globals.LogTag, "Not to compare with different type");
                throw CalendarErrorFactory.GetException((int)CalendarError.InvalidParameter);
            }

            if (_type == (int)Type.Utc)
                return UtcTime.Equals(other.UtcTime);
            else
                return LocalTime.Equals(other.LocalTime);
        }
    }
}

