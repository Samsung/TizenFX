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
    /// The information of Watch Time
    /// </summary>
    public class WatchTime
    {
        private readonly SafeWatchTimeHandle _handle;
        private static readonly string LOGTAG = "Tizen.Applications.WatchApplication";

        internal WatchTime(SafeWatchTimeHandle handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// The information of year
        /// </summary>
        public int Year
        {
            get
            {
                int year;
                Interop.Watch.ErrorCode err = Interop.Watch.WatchTimeGetYear(_handle, out year);

                if (err != Interop.Watch.ErrorCode.None)
                {
                    Log.Error(LOGTAG, "Failed to get Year err : " + err);
                }
                return year;
            }
        }

        /// <summary>
        /// The information fo month
        /// </summary>
        public int Month
        {
            get
            {
                int month;
                Interop.Watch.ErrorCode err = Interop.Watch.WatchTimeGetMonth(_handle, out month);

                if (err != Interop.Watch.ErrorCode.None)
                {
                    Log.Error(LOGTAG, "Failed to get Month err : " + err);
                }
                return month;
            }
        }

        /// <summary>
        /// The information of day
        /// </summary>
        public int Day
        {
            get
            {
                int day;
                Interop.Watch.ErrorCode err = Interop.Watch.WatchTimeGetDay(_handle, out day);

                if (err != Interop.Watch.ErrorCode.None)
                {
                    Log.Error(LOGTAG, "Failed to get Day err : " + err);
                }
                return day;
            }
        }

        /// <summary>
        /// The information of day of week
        /// </summary>
        public int DayOfWeek
        {
            get
            {
                int dayOfWeek;
                Interop.Watch.ErrorCode err = Interop.Watch.WatchTimeGetDayOfWeek(_handle, out dayOfWeek);

                if (err != Interop.Watch.ErrorCode.None)
                {
                    Log.Error(LOGTAG, "Failed to get Second err : " + err);
                }
                return dayOfWeek;
            }
        }

        /// <summary>
        /// The information of hour
        /// </summary>
        public int Hour
        {
            get
            {
                int hour;
                Interop.Watch.ErrorCode err = Interop.Watch.WatchTimeGetHour(_handle, out hour);

                if (err != Interop.Watch.ErrorCode.None)
                {
                    Log.Error(LOGTAG, "Failed to get Hour err : " + err);
                }
                return hour;
            }
        }

        /// <summary>
        /// The information of hour for 24 hour form
        /// </summary>
        public int Hour24
        {
            get
            {
                int hour24;
                Interop.Watch.ErrorCode err = Interop.Watch.WatchTimeGetHour24(_handle, out hour24);

                if (err != Interop.Watch.ErrorCode.None)
                {
                    Log.Error(LOGTAG, "Failed to get Hour24 err : " + err);
                }
                return hour24;
            }
        }

        /// <summary>
        /// The information of Minute
        /// </summary>
        public int Minute
        {
            get
            {
                int minute;
                Interop.Watch.ErrorCode err = Interop.Watch.WatchTimeGetMinute(_handle, out minute);

                if (err != Interop.Watch.ErrorCode.None)
                {
                    Log.Error(LOGTAG, "Failed to get Minute err : " + err);
                }
                return minute;
            }
        }

        /// <summary>
        /// The information of second
        /// </summary>
        public int Second
        {
            get
            {
                int second;
                Interop.Watch.ErrorCode err = Interop.Watch.WatchTimeGetSecond(_handle, out second);

                if (err != Interop.Watch.ErrorCode.None)
                {
                    Log.Error(LOGTAG, "Failed to get Second err : " + err);
                }
                return second;
            }
        }

        /// <summary>
        /// The information of millisecond
        /// </summary>
        public int Millisecond
        {
            get
            {
                int ms;
                Interop.Watch.ErrorCode err = Interop.Watch.WatchTimeGetMillisecond(_handle, out ms);

                if (err != Interop.Watch.ErrorCode.None)
                {
                    Log.Error(LOGTAG, "Failed to get Second err : " + err);
                }
                return ms;
            }
        }

        /// <summary>
        /// The information of timezone
        /// </summary>
        public string TimeZone
        {
            get
            {
                string zone;
                Interop.Watch.ErrorCode err = Interop.Watch.WatchTimeGetTimeZone(_handle, out zone);

                if (err != Interop.Watch.ErrorCode.None)
                {
                    Log.Error(LOGTAG, "Failed to get Second err : " + err);
                }
                return zone;
            }
        }

        /// <summary>
        /// The information of UTC time stamp
        /// </summary>
        public DateTime UtcTimestamp
        {
            get
            {
                long ts = 0;

                Interop.Watch.ErrorCode err = Interop.Watch.WatchTimeGetUtcTimestamp(_handle, out ts);

                if (err != Interop.Watch.ErrorCode.None)
                {
                    Log.Error(LOGTAG, "Failed to get UtcTimestamp err : " + err);
                }

                return (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddSeconds(ts).ToLocalTime();
            }
        }
    }
}
