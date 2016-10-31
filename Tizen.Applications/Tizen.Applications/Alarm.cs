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
    /// The Alarm API allows setting an "alarm clock" for the delivery of a notification at some point in the future.
    /// </summary>
    /// <example>
    /// <code>
    /// public class AlarmExample
    /// {
    ///     /// ...
    ///     IEnumerable &lt; Alarm &gt; alarms = AlarmManager.GetAllSceduledAlarms();
    ///     alarms[0].Cancel();
    /// }
    /// </code>
    /// </example>
    public class Alarm
    {
        private const string _logTag = "Tizen.Applications.Alarm";

        /// <summary>
        /// Constructor created with new AlarmId.
        /// </summary>
        /// <param name="id"></param>
        internal Alarm(int id)
        {
            AlarmId = id;
        }

        /// <summary>
        /// The alarm ID uniquely identifies an alarm.
        /// </summary>
        internal int AlarmId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the recurrence days of the week.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/alarm.get</privilege>
        /// <remarks>
        /// week_flag may be a combination of days, like Tuesday | Friday
        /// </remarks>
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
        }

        /// <summary>
        /// Gets the scheduled time.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/alarm.get</privilege>
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
        }

        /// <summary>
        /// Gets the period of time between the recurrent alarms.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/alarm.get</privilege>
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
        }

        /// <summary>
        /// Gets the AppControl to be invoked when the the alarm is triggered.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/alarm.get</privilege>
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
        /// Cancels the the specific alarm.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown in case of Invalid parmaeter.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of permission denied due to insufficient previlleges.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/alarm.set</privilege>
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
