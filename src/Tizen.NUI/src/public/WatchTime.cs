/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// The WatchTime class is used to get time for the WatchApplication.<br/>
    /// A WatchTime has a time handle from watch application framework.<br/>
    /// You can get time(hour, minute, second, millisecond) and date(year, month, day)<br/>
    /// on receiving timeTick signal.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class WatchTime : Disposable
    {

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public WatchTime() : this(Interop.Watch.NewWatchTime(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal WatchTime(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Get the current hour.
        /// </summary>
        /// <remarks>The return value is always positive.The WatchTime needs to be initialized.</remarks>
        /// <since_tizen> 4 </since_tizen>
        public int Hour
        {
            get
            {
                return GetHour();
            }
        }

        /// <summary>
        /// Get the current hour24.
        /// </summary>
        /// <remarks>The return value is always positive.The WatchTime needs to be initialized.</remarks>
        /// <since_tizen> 4 </since_tizen>
        public int Hour24
        {
            get
            {
                return GetHour24();
            }
        }

        /// <summary>
        /// Get the current minute.
        /// </summary>
        /// <remarks>The return value is always positive.The WatchTime needs to be initialized.</remarks>
        /// <since_tizen> 4 </since_tizen>
        public int Minute
        {
            get
            {
                return GetMinute();
            }
        }

        /// <summary>
        /// Get the current second.
        /// </summary>
        /// <remarks>The return value is always positive.The WatchTime needs to be initialized.</remarks>
        /// <since_tizen> 4 </since_tizen>
        public int Second
        {
            get
            {
                return GetSecond();
            }
        }

        /// <summary>
        /// Get the current millisecond.
        /// </summary>
        /// <remarks>The return value is always positive.The WatchTime needs to be initialized.</remarks>
        /// <since_tizen> 4 </since_tizen>
        public int Millisecond
        {
            get
            {
                return GetMillisecond();
            }
        }

        /// <summary>
        /// Get the current year.
        /// </summary>
        /// <remarks>The return value is always positive.The WatchTime needs to be initialized.</remarks>
        /// <since_tizen> 4 </since_tizen>
        public int Year
        {
            get
            {
                return GetYear();
            }
        }

        /// <summary>
        /// Get the current month.
        /// </summary>
        /// <remarks>The return value is always positive.The WatchTime needs to be initialized.</remarks>
        /// <since_tizen> 4 </since_tizen>
        public int Month
        {
            get
            {
                return GetMonth();
            }
        }

        /// <summary>
        /// Get the current day.
        /// </summary>
        /// <remarks>The return value is always positive.The WatchTime needs to be initialized.</remarks>
        /// <since_tizen> 4 </since_tizen>
        public int Day
        {
            get
            {
                return GetDay();
            }
        }

        /// <summary>
        /// Get the current week.
        /// </summary>
        /// <remarks>The return value is always positive.The WatchTime needs to be initialized.</remarks>
        /// <since_tizen> 4 </since_tizen>
        public int DayOfWeek
        {
            get
            {
                return GetDayOfWeek();
            }
        }

        /// <summary>
        /// Get the ID of timezone.
        /// </summary>
        /// <remarks>
        /// The WatchTime needs to be initialized.<br/>
        /// The timezone ID, according to the IANA(Internet Assigned Numbers Authority)<br/>
        /// If you want to see more information, please refer to the site :<br/>
        /// https://en.wikipedia.org/wiki/List_of_tz_database_time_zones/
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        public string TimeZone
        {
            get
            {
                return GetTimeZone();
            }
        }

        /// <summary>
        /// Get the daylight saving time status.
        /// </summary>
        /// <remarks>The WatchTime needs to be initialized.</remarks>
        /// <since_tizen> 4 </since_tizen>
        public bool DaylightSavingTimeStatus
        {
            get
            {
                return GetDaylightSavingTimeStatus();
            }
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(WatchTime obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal static WatchTime GetWatchTimeFromPtr(global::System.IntPtr cPtr)
        {
            WatchTime ret = new WatchTime(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal int GetDayOfWeek()
        {
            int ret = Interop.Watch.WatchTimeGetDayOfWeek(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SWIGTYPE_p_tm GetUtcTime()
        {
            SWIGTYPE_p_tm ret = new SWIGTYPE_p_tm(Interop.Watch.WatchTimeGetUtcTime(SwigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SWIGTYPE_p_time_t GetUtcTimeStamp()
        {
            SWIGTYPE_p_time_t ret = new SWIGTYPE_p_time_t(Interop.Watch.WatchTimeGetUtcTimeStamp(SwigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal string GetTimeZone()
        {
            string ret = Interop.Watch.WatchTimeGetTimeZone(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal bool GetDaylightSavingTimeStatus()
        {
            bool ret = Interop.Watch.WatchTimeGetDaylightSavingTimeStatus(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal int GetHour()
        {
            int ret = Interop.Watch.WatchTimeGetHour(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal int GetHour24()
        {
            int ret = Interop.Watch.WatchTimeGetHour24(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal int GetMinute()
        {
            int ret = Interop.Watch.WatchTimeGetMinute(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal int GetSecond()
        {
            int ret = Interop.Watch.WatchTimeGetSecond(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal int GetMillisecond()
        {
            int ret = Interop.Watch.WatchTimeGetMillisecond(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal int GetYear()
        {
            int ret = Interop.Watch.WatchTimeGetYear(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal int GetMonth()
        {
            int ret = Interop.Watch.WatchTimeGetMonth(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal int GetDay()
        {
            int ret = Interop.Watch.WatchTimeGetDay(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Watch.DeleteWatchTime(swigCPtr);
        }
    }
}
