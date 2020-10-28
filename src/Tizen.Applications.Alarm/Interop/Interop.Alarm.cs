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

using Tizen.Internals.Errors;
using Tizen.Applications;
using Tizen.Applications.Notifications;

internal static partial class Interop
{
    internal static partial class Alarm
    {
        [StructLayout(LayoutKind.Sequential)]
        internal struct DateTime
        {
            internal int sec;
            internal int min;
            internal int hour;
            internal int mday; /* day of the month, range 1 to 31*/
            internal int mon;
            internal int year;
            internal int wday; /* day of the week, range 0 to 6*/
            internal int yday; /* day in the year, range 0 to 365*/
            internal int isdst; /* daylight saving time*/
            internal long tm_gmtoff;
            internal IntPtr tm_zone;
        };

        [DllImport(Libraries.Alarm, EntryPoint = "alarm_schedule_after_delay")]
        internal static extern int CreateAlarmAfterDelay(SafeAppControlHandle appControl, int delay, int period, out int alarmId);

        [DllImport(Libraries.Alarm, EntryPoint = "alarm_schedule_once_after_delay")]
        internal static extern int CreateAlarmOnceAfterDelay(SafeAppControlHandle appControl, int delay, out int alarmId);

        [DllImport(Libraries.Alarm, EntryPoint = "alarm_schedule_once_at_date")]
        internal static extern int CreateAlarmOnceAtDate(SafeAppControlHandle appControl, ref DateTime date, out int alarmId);

        [DllImport(Libraries.Alarm, EntryPoint = "alarm_schedule_with_recurrence_week_flag")]
        internal static extern int CreateAlarmRecurWeek(SafeAppControlHandle appControl, ref DateTime date, int week, out int alarmId);

        [DllImport(Libraries.Alarm, EntryPoint = "alarm_get_scheduled_recurrence_week_flag")]
        internal static extern int GetAlarmWeekFlag(int alarmId, out int weekFlag);

        [DllImport(Libraries.Alarm, EntryPoint = "alarm_cancel")]
        internal static extern int CancelAlarm(int alarmId);

        [DllImport(Libraries.Alarm, EntryPoint = "alarm_cancel_all")]
        internal static extern int CancelAllAlarms();

        [DllImport(Libraries.Alarm, EntryPoint = "alarm_get_scheduled_date")]
        internal static extern int GetAlarmScheduledDate(int alarmId, out DateTime date);

        [DllImport(Libraries.Alarm, EntryPoint = "alarm_get_current_time")]
        internal static extern int GetCurrentTime(out DateTime date);

        [DllImport(Libraries.Alarm, EntryPoint = "alarm_get_app_control")]
        internal static extern int GetAlarmAppControl(int alarmId, out SafeAppControlHandle control);

        [DllImport(Libraries.Alarm, EntryPoint = "alarm_get_scheduled_period")]
        internal static extern int GetAlarmScheduledPeriod(int alarmId, out int period);

        [DllImport(Libraries.Alarm, EntryPoint = "alarm_set_global")]
        internal static extern int SetAlarmGlobalFlag(int alarmId, bool global);

        [DllImport(Libraries.Alarm, EntryPoint = "alarm_get_global")]
        internal static extern int GetAlarmGlobalFlag(int alarmId, out bool global);

        [DllImport(Libraries.Alarm, EntryPoint = "alarm_foreach_registered_alarm")]
        internal static extern int GetAllRegisteredAlarms(RegisteredAlarmCallback callback, IntPtr userData);

        [DllImport(Libraries.Alarm, EntryPoint = "alarm_schedule_noti_once_at_date")]
        internal static extern AlarmError CreateAlarmNotiOnceAtDate(NotificationSafeHandle noti, ref DateTime date, out int alarmId);

        [DllImport(Libraries.Alarm, EntryPoint = "alarm_schedule_noti_after_delay")]
        internal static extern AlarmError CreateAlarmNotiAfterDelay(NotificationSafeHandle noti, int delay, int period, out int alarmId);

        [DllImport(Libraries.Alarm, EntryPoint = "alarm_schedule_noti_once_after_delay")]
        internal static extern AlarmError CreateAlarmNotiOnceAfterDelay(NotificationSafeHandle noti, int delay, out int alarmId);

        [DllImport(Libraries.Alarm, EntryPoint = "alarm_schedule_noti_with_recurrence_week_flag")]
        internal static extern AlarmError CreateAlarmNotiRecurWeek(NotificationSafeHandle noti, ref DateTime date, int week, out int alarmId);

        [DllImport(Libraries.Alarm, EntryPoint = "alarm_update_delay")]
        internal static extern AlarmError UpdateDelay(int alarmId, int delay);

        [DllImport(Libraries.Alarm, EntryPoint = "alarm_update_date")]
        internal static extern AlarmError UpdateDate(int alarmId, ref DateTime date);

        [DllImport(Libraries.Alarm, EntryPoint = "alarm_update_period")]
        internal static extern AlarmError UpdatePeriod(int alarmId, int period);

        [DllImport(Libraries.Alarm, EntryPoint = "alarm_update_week_flag")]
        internal static extern AlarmError UpdateWeekFlag(int alarmId, int week);

        //callback
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool RegisteredAlarmCallback(int alarmId, IntPtr userData);
    }
}
