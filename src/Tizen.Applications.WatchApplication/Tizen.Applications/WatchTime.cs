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

namespace Tizen.Applications
{
    /// <summary>
    /// The information of the Watch Time.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class WatchTime
    {
        private readonly SafeWatchTimeHandle _handle;
        private static readonly string LOGTAG = "Tizen.Applications.WatchApplication";

        internal WatchTime(SafeWatchTimeHandle handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// The information of a year.
        /// </summary>
        /// <feature>http://tizen.org/feature/watch_app</feature>
        /// <exception cref="NotSupportedException">Thrown when the property is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int Year
        {
            get
            {
                int year;
                Interop.Watch.ErrorCode err = Interop.Watch.WatchTimeGetYear(_handle, out year);

                if (err != Interop.Watch.ErrorCode.None)
                {
                    if (err == Interop.Watch.ErrorCode.NotSupported)
                        throw new NotSupportedException("Failed to get Year. err : " + err);
                    else
                        Log.Error(LOGTAG, "Failed to get Year err : " + err);
                }
                return year;
            }
        }

        /// <summary>
        /// The information of a month.
        /// </summary>
        /// <feature>http://tizen.org/feature/watch_app</feature>
        /// <exception cref="NotSupportedException">Thrown when the property is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int Month
        {
            get
            {
                int month;
                Interop.Watch.ErrorCode err = Interop.Watch.WatchTimeGetMonth(_handle, out month);

                if (err != Interop.Watch.ErrorCode.None)
                {
                    if (err == Interop.Watch.ErrorCode.NotSupported)
                        throw new NotSupportedException("Failed to get Month. err : " + err);
                    else
                        Log.Error(LOGTAG, "Failed to get Month err : " + err);
                }
                return month;
            }
        }

        /// <summary>
        /// The information of a day.
        /// </summary>
        /// <feature>http://tizen.org/feature/watch_app</feature>
        /// <exception cref="NotSupportedException">Thrown when the property is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int Day
        {
            get
            {
                int day;
                Interop.Watch.ErrorCode err = Interop.Watch.WatchTimeGetDay(_handle, out day);

                if (err != Interop.Watch.ErrorCode.None)
                {
                    if (err == Interop.Watch.ErrorCode.NotSupported)
                        throw new NotSupportedException("Failed to get Day. err : " + err);
                    else
                        Log.Error(LOGTAG, "Failed to get Day err : " + err);
                }
                return day;
            }
        }

        /// <summary>
        /// The information of a day of the week.
        /// </summary>
        /// <feature>http://tizen.org/feature/watch_app</feature>
        /// <exception cref="NotSupportedException">Thrown when the property is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int DayOfWeek
        {
            get
            {
                int dayOfWeek;
                Interop.Watch.ErrorCode err = Interop.Watch.WatchTimeGetDayOfWeek(_handle, out dayOfWeek);

                if (err != Interop.Watch.ErrorCode.None)
                {
                    if (err == Interop.Watch.ErrorCode.NotSupported)
                        throw new NotSupportedException("Failed to get DayOfWeek. err : " + err);
                    else
                        Log.Error(LOGTAG, "Failed to get DayOfWeek err : " + err);
                }
                return dayOfWeek;
            }
        }

        /// <summary>
        /// The information of an hour.
        /// </summary>
        /// <feature>http://tizen.org/feature/watch_app</feature>
        /// <exception cref="NotSupportedException">Thrown when the property is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int Hour
        {
            get
            {
                int hour;
                Interop.Watch.ErrorCode err = Interop.Watch.WatchTimeGetHour(_handle, out hour);

                if (err != Interop.Watch.ErrorCode.None)
                {
                    if (err == Interop.Watch.ErrorCode.NotSupported)
                        throw new NotSupportedException("Failed to get Hour. err : " + err);
                    else
                        Log.Error(LOGTAG, "Failed to get Hour err : " + err);
                }
                return hour;
            }
        }

        /// <summary>
        /// The information of an hour for the 24 hour format.
        /// </summary>
        /// <feature>http://tizen.org/feature/watch_app</feature>
        /// <exception cref="NotSupportedException">Thrown when the property is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int Hour24
        {
            get
            {
                int hour24;
                Interop.Watch.ErrorCode err = Interop.Watch.WatchTimeGetHour24(_handle, out hour24);

                if (err != Interop.Watch.ErrorCode.None)
                {
                    if (err == Interop.Watch.ErrorCode.NotSupported)
                        throw new NotSupportedException("Failed to get Hour24. err : " + err);
                    else
                        Log.Error(LOGTAG, "Failed to get Hour24 err : " + err);
                }
                return hour24;
            }
        }

        /// <summary>
        /// The information of a minute.
        /// </summary>
        /// <feature>http://tizen.org/feature/watch_app</feature>
        /// <exception cref="NotSupportedException">Thrown when the property is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int Minute
        {
            get
            {
                int minute;
                Interop.Watch.ErrorCode err = Interop.Watch.WatchTimeGetMinute(_handle, out minute);

                if (err != Interop.Watch.ErrorCode.None)
                {
                    if (err == Interop.Watch.ErrorCode.NotSupported)
                        throw new NotSupportedException("Failed to get Minute. err : " + err);
                    else
                        Log.Error(LOGTAG, "Failed to get Minute err : " + err);
                }
                return minute;
            }
        }

        /// <summary>
        /// The information of a second.
        /// </summary>
        /// <feature>http://tizen.org/feature/watch_app</feature>
        /// <exception cref="NotSupportedException">Thrown when the property is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int Second
        {
            get
            {
                int second;
                Interop.Watch.ErrorCode err = Interop.Watch.WatchTimeGetSecond(_handle, out second);

                if (err != Interop.Watch.ErrorCode.None)
                {
                    if (err == Interop.Watch.ErrorCode.NotSupported)
                        throw new NotSupportedException("Failed to get Second. err : " + err);
                    else
                        Log.Error(LOGTAG, "Failed to get Second err : " + err);
                }
                return second;
            }
        }

        /// <summary>
        /// The information of a millisecond.
        /// </summary>
        /// <feature>http://tizen.org/feature/watch_app</feature>
        /// <exception cref="NotSupportedException">Thrown when the property is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int Millisecond
        {
            get
            {
                int ms;
                Interop.Watch.ErrorCode err = Interop.Watch.WatchTimeGetMillisecond(_handle, out ms);

                if (err != Interop.Watch.ErrorCode.None)
                {
                    if (err == Interop.Watch.ErrorCode.NotSupported)
                        throw new NotSupportedException("Failed to get Millisecond. err : " + err);
                    else
                        Log.Error(LOGTAG, "Failed to get Millisecond err : " + err);
                }
                return ms;
            }
        }

        /// <summary>
        /// The information of the timezone.
        /// </summary>
        /// <feature>http://tizen.org/feature/watch_app</feature>
        /// <exception cref="NotSupportedException">Thrown when the property is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public string TimeZone
        {
            get
            {
                string zone;
                Interop.Watch.ErrorCode err = Interop.Watch.WatchTimeGetTimeZone(_handle, out zone);

                if (err != Interop.Watch.ErrorCode.None)
                {
                    if (err == Interop.Watch.ErrorCode.NotSupported)
                        throw new NotSupportedException("Failed to get TimeZone. err : " + err);
                    else
                        Log.Error(LOGTAG, "Failed to get TimeZone err : " + err);
                }
                return zone;
            }
        }

        /// <summary>
        /// The information of the UTC time stamp.
        /// </summary>
        /// <feature>http://tizen.org/feature/watch_app</feature>
        /// <exception cref="NotSupportedException">Thrown when the property is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public DateTime UtcTimestamp
        {
            get
            {
                long ts = 0;
                Interop.Watch.ErrorCode err = Interop.Watch.WatchTimeGetUtcTimestamp(_handle, out ts);

                if (err != Interop.Watch.ErrorCode.None)
                {
                    if (err == Interop.Watch.ErrorCode.NotSupported)
                        throw new NotSupportedException("Failed to get UtcTimestamp. err : " + err);
                    else
                        Log.Error(LOGTAG, "Failed to get UtcTimestamp err : " + err);
                }
                return (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddSeconds(ts).AddMilliseconds(Millisecond);
            }
        }
    }
}
