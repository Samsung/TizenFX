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

namespace Tizen.Applications
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using Tizen.Applications.Notifications;

    /// <summary>
    /// Enumeration for alarm week flag, the days of the week.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Flags]
    public enum AlarmWeekFlag
    {
        /// <summary>
        /// An identifier for Sunday.
        /// </summary>
        Sunday = 0x01,

        /// <summary>
        /// An identifier for Monday.
        /// </summary>
        Monday = 0x02,

        /// <summary>
        /// An identifier for Tuesday.
        /// </summary>
        Tuesday = 0x04,

        /// <summary>
        /// An identifier for Wednesday.
        /// </summary>
        Wednesday = 0x08,

        /// <summary>
        /// An identifier for Thursday.
        /// </summary>
        Thursday = 0x10,

        /// <summary>
        /// An identifier for Friday.
        /// </summary>
        Friday = 0x20,

        /// <summary>
        /// An identifier for Saturday.
        /// </summary>
        Saturday = 0x40,

        /// <summary>
        /// All days of the week.
        /// </summary>
        AllDays = Sunday |Monday|Tuesday|Wednesday|Thursday|Friday|Saturday,

        /// <summary>
        /// Only weekdays.
        /// </summary>
        WeekDays = Monday | Tuesday | Wednesday | Thursday | Friday
    }

    /// <summary>
    /// Enumeration for inexact interval.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public enum AlarmStandardPeriod
    {
        /// <summary>
        /// 900 seconds.
        /// </summary>
        FifteenMinutes = 900,

        /// <summary>
        /// 1800 seconds.
        /// </summary>
        HalfHour = FifteenMinutes * 2,

        /// <summary>
        /// 3600 seconds.
        /// </summary>
        Hour = HalfHour * 2,

        /// <summary>
        /// 86400 seconds.
        /// </summary>
        Day = Hour * 24,
    }

    /// <summary>
    /// Mobile devices typically give constant access to information from various sources. Some of this information is best delivered through alarms.
    /// The most obvious case is a calendar scheduling application, which lets you know when a meeting is about to start. Alarms are certainly better than actively waiting in a loop.
    /// They are also better than putting an interface to sleep because they do not block your main UI thread.
    /// Use of alarms helps build smooth user experiences and implements unattended data synchronization tasks.
    /// If an application is installed after setting the alarm, your alarm is canceled automatically.
    /// </summary>
    /// <example>
    /// <code>
    /// public class AlarmManagerExample
    /// {
    ///     /// ...
    ///     Alarm alarm = AlarmManager.CreateAlarm(24000,1000,null);
    ///     AlarmManager.CancelAll();
    /// }
    /// </code>
    /// </example>
    /// <since_tizen> 3 </since_tizen>

    public static class AlarmManager
    {
        private const string LogTag = "Tizen.Applications.Alarm";

        private static Interop.Alarm.DateTime ConvertDateTimeToStruct(DateTime value)
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
            return time;
        }

        internal static DateTime ConvertIntPtrToDateTime(Interop.Alarm.DateTime time)
        {
            DateTime value = new DateTime(1900 + time.year, 1 + time.mon, time.mday, time.hour, time.min, time.sec, DateTimeKind.Utc);
            return value;
        }

        /// <summary>
        /// Sets an alarm to be triggered after a specific time.
        /// The alarm will first go off delay seconds later and then will go off every certain amount of time defined using period seconds.
        /// </summary>
        /// <param name="delay">The amount of time before the first execution (in seconds).</param>
        /// <param name="period"> The amount of time between subsequent alarms (in seconds). This value does not guarantee the accuracy.
        /// The actual interval is calculated by the OS. The minimum value is 600sec.</param>
        /// <param name="appControl"> The destination AppControl is used to perform a specific task when the alarm is triggered. </param>
        /// <returns> An alarm instance is created with the set param values.</returns>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of a permission denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/alarm.set</privilege>
        /// <since_tizen> 3 </since_tizen>
        public static Alarm CreateAlarm(int delay, int period, AppControl appControl)
        {
            if (appControl == null)
            {
                throw AlarmErrorFactory.GetException(AlarmError.InvalidParameter, "AppControl should be not null");
            }

            Alarm alarm = null;
            int alarmId;
            AlarmError ret = (AlarmError)Interop.Alarm.CreateAlarmAfterDelay(appControl.SafeAppControlHandle, delay, period, out alarmId);
            alarm = new Alarm(alarmId);
            if (ret != AlarmError.None)
            {
                throw AlarmErrorFactory.GetException(ret, "Failed to create Alarm");
            }

            return alarm;
        }

        /// <summary>
        /// Sets an alarm to be triggered after a specific time.
        /// The alarm will go off delay seconds later.
        /// </summary>
        /// <param name="delay"> The amount of time before the execution (in seconds). </param>
        /// <param name="appControl"> The destination AppControl to perform a specific task when the alarm is triggered. </param>
        /// <returns> An alarm instance is created with the set param values.</returns>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of a permission denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/alarm.set</privilege>
        /// <since_tizen> 3 </since_tizen>
        public static Alarm CreateAlarm(int delay, AppControl appControl)
        {
            if (appControl == null)
            {
                throw AlarmErrorFactory.GetException(AlarmError.InvalidParameter, "AppControl should be not null");
            }

            Alarm alarm = null;
            int alarmId;
            AlarmError ret = (AlarmError)Interop.Alarm.CreateAlarmOnceAfterDelay(appControl.SafeAppControlHandle, delay, out alarmId);
            alarm = new Alarm(alarmId);
            if (ret != AlarmError.None)
            {
                throw AlarmErrorFactory.GetException(ret, "Failed to create Alarm");
            }

            return alarm;
        }

        /// <summary>
        /// Sets an alarm to be triggered at a specific time.
        /// The date describes the time of the first occurrence.
        /// </summary>
        /// <param name="value"> The first active alarm time. </param>
        /// <param name="appControl"> The destination AppControl to perform specific work when the alarm is triggered. </param>
        /// <returns> An alarm instance is created with the set param values.</returns>
        /// <remarks>This operation is permitted with the UI application appcontrol only.</remarks>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of a permission denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/alarm.set</privilege>
        /// <since_tizen> 3 </since_tizen>
        public static Alarm CreateAlarm(DateTime value, AppControl appControl)
        {
            if (appControl == null)
            {
                throw AlarmErrorFactory.GetException(AlarmError.InvalidParameter, "AppControl should be not null");
            }

            Alarm alarm = null;
            int alarmId;
            Interop.Alarm.DateTime time = ConvertDateTimeToStruct(value);
            AlarmError ret = (AlarmError)Interop.Alarm.CreateAlarmOnceAtDate(appControl.SafeAppControlHandle, ref time, out alarmId);
            alarm = new Alarm(alarmId);
            if (ret != AlarmError.None)
            {
                throw AlarmErrorFactory.GetException(ret, "Failed to create Alarm");
            }

            return alarm;
        }

        /// <summary>
        /// Sets an alarm to be triggered periodically, starting at a specific time.
        /// The date describes the time of the first occurrence.
        /// The weekFlag is the repeat value of the days of the week.
        /// If the weekFlag is AlarmWeekFlag.Tuesday, the alarm will repeat every Tuesday at a specific time.
        /// </summary>
        /// <remarks>This operation is permitted with UI application appcontrol only.</remarks>
        /// <param name="value"> The first active alarm time. </param>
        /// <param name="weekFlag"> The day of the week, AlarmWeekFlag may be a combination of days, like AlarmWeekFlag.Sunday | AlarmWeekFlag.Monday.</param>
        /// <param name="appControl"> The destination AppControl to perform specific work when the alarm is triggered. </param>
        /// <returns> An alarm instance is created with the set param values.</returns>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of a permission denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/alarm.set</privilege>
        /// <since_tizen> 3 </since_tizen>
        public static Alarm CreateAlarm(DateTime value, AlarmWeekFlag weekFlag, AppControl appControl)
        {
            if (appControl == null)
            {
                throw AlarmErrorFactory.GetException(AlarmError.InvalidParameter, "AppControl should be not null");
            }

            Alarm alarm = null;
            int alarmId;
            Interop.Alarm.DateTime time = ConvertDateTimeToStruct(value);
            AlarmError ret = (AlarmError)Interop.Alarm.CreateAlarmRecurWeek(appControl.SafeAppControlHandle, ref time, (int)weekFlag, out alarmId);
            alarm = new Alarm(alarmId);
            if (ret != AlarmError.None)
            {
                throw AlarmErrorFactory.GetException(ret, "Failed to create Alarm");
            }

            return alarm;
        }

        /// <summary>
        /// Sets an alarm to be triggered after a specific time.
        /// The alarm will first go off delay seconds later and then will go off every certain amount of time defined using standard period seconds.
        /// </summary>
        /// <param name="delay">The amount of time before the first execution (in seconds).</param>
        /// <param name="standardPeriod"> It can be the <see cref="Tizen.Applications.AlarmStandardPeriod"/>. If then, the period of alarm is guaranteed. </param>
        /// <param name="appControl"> The destination AppControl is used to perform a specific task when the alarm is triggered. </param>
        /// <returns> An alarm instance is created with the set param values.</returns>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of a permission denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/alarm.set</privilege>
        /// <since_tizen> 8 </since_tizen>
        public static Alarm CreateAlarm(int delay, AlarmStandardPeriod standardPeriod, AppControl appControl)
        {
            return CreateAlarm(delay, (int)standardPeriod, appControl);
        }

        /// <summary>
        /// Sets a notification alarm to be triggered at a specific time.
        /// The date describes the time of the first occurrence.
        /// </summary>
        /// <param name="dateTime"> The first active alarm time. </param>
        /// <param name="notification"> The notification to be posted when the alarm is triggered. </param>
        /// <returns> An alarm instance is created with the set param values.</returns>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of a permission denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/alarm.set</privilege>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <since_tizen> 3 </since_tizen>
        public static Alarm CreateAlarm(DateTime dateTime, Notification notification)
        {
            Alarm alarm = null;
            int alarmId;
            NotificationSafeHandle safeHandle = NotificationManager.MakeNotificationSafeHandle(notification);
            Interop.Alarm.DateTime time = ConvertDateTimeToStruct(dateTime);
            AlarmError ret = Interop.Alarm.CreateAlarmNotiOnceAtDate(safeHandle, ref time, out alarmId);
            if (ret != AlarmError.None)
            {
                throw AlarmErrorFactory.GetException(ret, "Failed to create Alarm");
            }

            alarm = new Alarm(alarmId);

            return alarm;
        }

        /// <summary>
        /// Sets a notification alarm to be triggered after a specific time.
        /// The alarm will first go off delay seconds later and then will go off every certain amount of time defined using period seconds.
        /// </summary>
        /// <param name="delay">The amount of time before the first execution (in seconds). </param>
        /// <param name="period"> The amount of time between subsequent alarms (in seconds). This value does not guarantee the accuracy. </param>
        /// <param name="notification"> The notification to be posted when the alarm is triggered. </param>
        /// <returns> An alarm instance is created with the set param values.</returns>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of a permission denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/alarm.set</privilege>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <since_tizen> 3 </since_tizen>
        public static Alarm CreateAlarm(int delay, int period, Notification notification)
        {
            Alarm alarm = null;
            int alarmId;
            NotificationSafeHandle safeHandle = NotificationManager.MakeNotificationSafeHandle(notification);
            AlarmError ret = Interop.Alarm.CreateAlarmNotiAfterDelay(safeHandle, delay, period, out alarmId);
            if (ret != AlarmError.None)
            {
                throw AlarmErrorFactory.GetException(ret, "Failed to create Alarm");
            }

            alarm = new Alarm(alarmId);

            return alarm;
        }

        /// <summary>
        /// Sets a notification alarm to be triggered periodically, starting at a specific time.
        /// The date describes the time of the first occurrence.
        /// The weekFlag is the repeat value of the days of the week.
        /// If the weekFlag is AlarmWeekFlag.Tuesday, the alarm will repeat every Tuesday at a specific time.
        /// </summary>
        /// <param name="dateTime"> The first active alarm time. </param>
        /// <param name="weekFlag"> The day of the week, AlarmWeekFlag may be a combination of days,
        ///                         like AlarmWeekFlag.Sunday | AlarmWeekFlag.Monday.</param>
        /// <param name="notification"> The notification to be posted when the alarm is triggered. </param>
        /// <returns> An alarm instance is created with the set param values.</returns>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of a permission denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/alarm.set</privilege>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <since_tizen> 3 </since_tizen>
        public static Alarm CreateAlarm(DateTime dateTime, AlarmWeekFlag weekFlag, Notification notification)
        {
            Alarm alarm = null;
            int alarmId;
            NotificationSafeHandle safeHandle = NotificationManager.MakeNotificationSafeHandle(notification);
            Interop.Alarm.DateTime time = ConvertDateTimeToStruct(dateTime);
            AlarmError ret = Interop.Alarm.CreateAlarmNotiRecurWeek(safeHandle, ref time, (int)weekFlag, out alarmId);
            if (ret != AlarmError.None)
            {
                throw AlarmErrorFactory.GetException(ret, "Failed to create Alarm");
            }

            alarm = new Alarm(alarmId);

            return alarm;
        }

        /// <summary>
        /// Sets a notification alarm to be triggered after a specific time.
        /// The alarm will go off delay seconds later.
        /// </summary>
        /// <param name="delay">The amount of time before the first execution (in seconds).</param>
        /// <param name="notification"> The notification to be posted when the alarm is triggered. </param>
        /// <returns> An alarm instance is created with the set param values.</returns>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of a permission denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/alarm.set</privilege>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <since_tizen> 3 </since_tizen>
        public static Alarm CreateAlarm(int delay, Notification notification)
        {
            Alarm alarm = null;
            int alarmId;
            NotificationSafeHandle safeHandle = NotificationManager.MakeNotificationSafeHandle(notification);
            AlarmError ret = Interop.Alarm.CreateAlarmNotiOnceAfterDelay(safeHandle, delay, out alarmId);
            if (ret != AlarmError.None)
            {
                throw AlarmErrorFactory.GetException(ret, "Failed to create Alarm");
            }

            alarm = new Alarm(alarmId);

            return alarm;
        }

        /// <summary>
        /// Sets a notification alarm to be triggered after a specific time.
        /// The alarm will first go off delay seconds later and then will go off every certain amount of time defined using period seconds.
        /// </summary>
        /// <param name="delay">The amount of time before the first execution (in seconds).</param>
        /// <param name="standardPeriod"> It can be the <see cref="Tizen.Applications.AlarmStandardPeriod"/>. If then, the period of alarm is guaranteed.</param>
        /// <param name="notification"> The notification to be posted when the alarm is triggered. </param>
        /// <returns> An alarm instance is created with the set param values.</returns>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of a permission denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/alarm.set</privilege>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <since_tizen> 8 </since_tizen>
        public static Alarm CreateAlarm(int delay, AlarmStandardPeriod standardPeriod, Notification notification)
        {
            return CreateAlarm(delay, (int)standardPeriod, notification);
        }

        /// <summary>
        /// Cancels all scheduled alarms that are registered by the application that calls this API.
        /// </summary>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of a permission denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/alarm.set</privilege>
        /// <since_tizen> 3 </since_tizen>
        public static void CancelAll()
        {
            AlarmError ret = (AlarmError)Interop.Alarm.CancelAllAlarms();
            if (ret != AlarmError.None)
            {
                throw AlarmErrorFactory.GetException(ret, "Failed to cancel Alarms");
            }
        }

        /// <summary>
        /// Retrieves all registered alarms.
        /// </summary>
        /// <returns>List of all alarm instances.</returns>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of a permission denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/alarm.get</privilege>
        /// <since_tizen> 4 </since_tizen>
        public static IEnumerable<Alarm> GetAllScheduledAlarms()
        {
            List<Alarm> alarms = new List<Alarm>();
            Interop.Alarm.RegisteredAlarmCallback callback = (int alarmId, IntPtr userData) =>
            {
                alarms.Add(new Alarm(alarmId));
                return true;
            };

            AlarmError ret = (AlarmError)Interop.Alarm.GetAllRegisteredAlarms(callback, IntPtr.Zero);
            if (ret != AlarmError.None)
            {
                throw AlarmErrorFactory.GetException(ret, "Failed to get Alarms");
            }

            return alarms;
        }

        /// <summary>
        /// Gets the current system time.
        /// </summary>
        /// <returns>The current system time.</returns>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static DateTime GetCurrentTime()
        {
            DateTime time;
            Interop.Alarm.DateTime value;
            AlarmError ret = (AlarmError)Interop.Alarm.GetCurrentTime(out value);
            if (ret != AlarmError.None)
            {
                throw AlarmErrorFactory.GetException(ret, "Failed to get Currenttime");
            }
            else
            {

                time = ConvertIntPtrToDateTime(value);
            }

            return time;
        }

    }
}
