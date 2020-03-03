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
    /// The alarm API allows setting an "alarm clock" for the delivery of a notification at some point in the future.
    /// </summary>
    /// <example>
    /// <code>
    /// public class AlarmExample
    /// {
    ///     /// ...
    ///     IEnumerable &lt; Alarm &gt; alarms = AlarmManager.GetAllScheduledAlarms();
    ///     alarms[0].Cancel();
    /// }
    /// </code>
    /// </example>
    /// <since_tizen> 3 </since_tizen>
    public class Alarm
    {
        private const string _logTag = "Tizen.Applications.Alarm";

        /// <summary>
        /// Constructor created with the new AlarmId.
        /// </summary>
        /// <param name="id"></param>
        internal Alarm(int id)
        {
            AlarmId = id;
        }

        /// <summary>
        /// The alarm ID uniquely identifies an alarm.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int AlarmId
        {
            get; private set;
        }

        /// <summary>
        /// Gets or sets the recurrence days of the week.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/alarm.set</privilege>
        /// <privilege>http://tizen.org/privilege/alarm.get</privilege>
        /// <remarks>
        /// The setter for <c>WeekFlag</c> property is available since API Level 6.
        /// Weekflag can be a combination of the days of the week, for example Tuesday | Friday.
        /// If the period is already set, it will be removed and the week repetition flag will be set.
        /// If the week repetition flag is already set, it will be overwritten. If not, it will be set.
        /// If the Weekflag argument is 0 and the flag is already set,
        /// the flag will be cleared and the alarm will be changed to set once.
        /// If the Weekflag argument is 0, and the flag is not set or the period is set,
        /// the alarm won't be changed.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public AlarmWeekFlag WeekFlag
        {
            get
            {
                int week;
                AlarmError ret = (AlarmError)Interop.Alarm.GetAlarmWeekFlag(AlarmId, out week);
                if (ret != AlarmError.None)
                {
                    Log.Error(_logTag, "Failed to get WeekFlag");
                }

                return (AlarmWeekFlag)week;
            }

            set
            {
                int week = (int)value;
                AlarmError ret = Interop.Alarm.UpdateWeekFlag(this.AlarmId, week);
                if (ret != AlarmError.None)
                {
                    throw AlarmErrorFactory.GetException(ret, "Failed to update Alarm");
                }
            }
        }

        /// <summary>
        /// Gets or sets the scheduled time.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/alarm.set</privilege>
        /// <privilege>http://tizen.org/privilege/alarm.get</privilege>
        /// <remarks>
        /// The <c>SchduleDate</c> property setter is available since API Level 6.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public DateTime ScheduledDate
        {
            get
            {
                Interop.Alarm.DateTime value;
                AlarmError ret = (AlarmError)Interop.Alarm.GetAlarmScheduledDate(AlarmId, out value);
                if (ret != AlarmError.None)
                {
                    Log.Error(_logTag, "Failed to get WeekFlag");
                }

                DateTime time = AlarmManager.ConvertIntPtrToDateTime(value);
                return time;
            }

            set
            {
                Interop.Alarm.DateTime time = new Interop.Alarm.DateTime();
                time.sec = value.Second;
                time.min = value.Minute;
                time.hour = value.Hour;
                time.mday = value.Day;
                time.mon = value.Month - 1;
                time.year = value.Year - 1900;
                time.wday = (int)value.DayOfWeek;
                time.yday = value.DayOfYear;
                time.isdst = 0;

                AlarmError ret = Interop.Alarm.UpdateDate(this.AlarmId, ref time);
                if (ret != AlarmError.None)
                {
                    throw AlarmErrorFactory.GetException(ret, "Failed to update Alarm");
                }
            }
        }

        /// <summary>
        /// Gets the period of time between the recurrent alarms.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/alarm.set</privilege>
        /// <privilege>http://tizen.org/privilege/alarm.get</privilege>
        /// <remarks>
        /// The <c>Period</c> property setter is available since API Level 6.
        /// If the week recurrence flag was set before, it will be removed and the period will be set
        /// If the period was set before, it will be overwritten.If it was not, it will be set.
        /// If the @a period argument is 0 and the period was previously set,
        /// the period attribute will be cleared and the alarm will be changed to one-time.
        /// If the @a period argument is 0 and the period was not set,
        /// or the week recurrence flag was set, the alarm will be unchanged.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public int Period
        {
            get
            {
                int period;
                AlarmError ret = (AlarmError)Interop.Alarm.GetAlarmScheduledPeriod(AlarmId, out period);
                if (ret != AlarmError.None)
                {
                    Log.Error(_logTag, "Failed to get WeekFlag");
                }

                return period;
            }

            set
            {
                AlarmError ret = Interop.Alarm.UpdatePeriod(this.AlarmId, value);
                if (ret != AlarmError.None)
                {
                    throw AlarmErrorFactory.GetException(ret, "Failed to update Alarm");
                }
            }
        }

        /// <summary>
        /// Gets the AppControl to be invoked when the the alarm is triggered.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/alarm.get</privilege>
        /// <since_tizen> 3 </since_tizen>
        public AppControl AlarmAppControl
        {
            get
            {
                SafeAppControlHandle handle;
                AlarmError ret = (AlarmError)Interop.Alarm.GetAlarmAppControl(AlarmId, out handle);

                if (ret != AlarmError.None)
                {
                    Log.Error(_logTag, "Failed to get WeekFlag");
                }

                return new AppControl(handle);
            }
        }

        /// <summary>
        /// Gets whether the alarm will launch global application or not.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/alarm.set</privilege>
        /// <privilege>http://tizen.org/privilege/alarm.get</privilege>
        /// <since_tizen> 3 </since_tizen>
        public bool Global
        {
            get
            {
                bool global;
                AlarmError ret = (AlarmError)Interop.Alarm.GetAlarmGlobalFlag(AlarmId, out global);
                if (ret != AlarmError.None)
                {
                    Log.Error(_logTag, "Failed to get WeekFlag");
                }

                return global;
            }

            set
            {
                AlarmError ret = (AlarmError)Interop.Alarm.SetAlarmGlobalFlag(AlarmId, value);
                if (ret != AlarmError.None)
                {
                    Log.Error(_logTag, "Failed to get WeekFlag");
                }
            }
        }


        /// <summary>
        /// Cancels the specific alarm.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parmaeter.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of a permission denied due to insufficient privileges.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/alarm.set</privilege>
        /// <since_tizen> 3 </since_tizen>
        public void Cancel()
        {
            AlarmError ret = (AlarmError)Interop.Alarm.CancelAlarm(AlarmId);
            if (ret != AlarmError.None)
            {
                throw AlarmErrorFactory.GetException(ret, "Failed to Cancel alarm");
            }
        }
    }
}
