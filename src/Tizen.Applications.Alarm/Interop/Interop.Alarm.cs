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
using System.Runtime.InteropServices.Marshalling;

using Tizen.Internals;
using Tizen.Applications;
using Tizen.Applications.Notifications;

internal static partial class Interop
{
    internal static partial class Alarm
    {
        [NativeStruct("struct tm", Include="time.h")]
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
            internal IntPtr tm_gmtoff; // Workaround: Use IntPtr instead of long type to match struct size with "struct tm" in time.h
            internal IntPtr tm_zone;
        };

        [LibraryImport(Libraries.Alarm, EntryPoint = "alarm_schedule_after_delay")]
        internal static partial int CreateAlarmAfterDelay(SafeAppControlHandle appControl, int delay, int period, out int alarmId);

        [LibraryImport(Libraries.Alarm, EntryPoint = "alarm_schedule_once_after_delay")]
        internal static partial int CreateAlarmOnceAfterDelay(SafeAppControlHandle appControl, int delay, out int alarmId);

        [LibraryImport(Libraries.Alarm, EntryPoint = "alarm_schedule_once_at_date")]
        internal static partial int CreateAlarmOnceAtDate(SafeAppControlHandle appControl, ref DateTime date, out int alarmId);

        [LibraryImport(Libraries.Alarm, EntryPoint = "alarm_schedule_with_recurrence_week_flag")]
        internal static partial int CreateAlarmRecurWeek(SafeAppControlHandle appControl, ref DateTime date, int week, out int alarmId);

        [LibraryImport(Libraries.Alarm, EntryPoint = "alarm_schedule_service_with_recurrence_seconds")]
        internal static partial int CreateAlarmRecurForService(SafeAppControlHandle appControl, ref DateTime date, int period, out int alarmId);

        [LibraryImport(Libraries.Alarm, EntryPoint = "alarm_schedule_service_once_after_delay")]
        internal static partial int CreateAlarmOnceAfterDelayForService(SafeAppControlHandle appControl, int delay, out int alarmId);

        [LibraryImport(Libraries.Alarm, EntryPoint = "alarm_schedule_service_once_at_date")]
        internal static partial int CreateAlarmOnceAtDateForService(SafeAppControlHandle appControl, ref DateTime date, out int alarmId);

        [LibraryImport(Libraries.Alarm, EntryPoint = "alarm_get_scheduled_recurrence_week_flag")]
        internal static partial int GetAlarmWeekFlag(int alarmId, out int weekFlag);

        [LibraryImport(Libraries.Alarm, EntryPoint = "alarm_cancel")]
        internal static partial int CancelAlarm(int alarmId);

        [LibraryImport(Libraries.Alarm, EntryPoint = "alarm_cancel_all")]
        internal static partial int CancelAllAlarms();

        [LibraryImport(Libraries.Alarm, EntryPoint = "alarm_get_scheduled_date")]
        internal static partial int GetAlarmScheduledDate(int alarmId, out DateTime date);

        [LibraryImport(Libraries.Alarm, EntryPoint = "alarm_get_current_time")]
        internal static partial int GetCurrentTime(out DateTime date);

        [LibraryImport(Libraries.Alarm, EntryPoint = "alarm_get_app_control")]
        internal static partial int GetAlarmAppControl(int alarmId, out SafeAppControlHandle control);

        [LibraryImport(Libraries.Alarm, EntryPoint = "alarm_get_scheduled_period")]
        internal static partial int GetAlarmScheduledPeriod(int alarmId, out int period);

        [LibraryImport(Libraries.Alarm, EntryPoint = "alarm_set_global")]
        internal static partial int SetAlarmGlobalFlag(int alarmId, [MarshalAs(UnmanagedType.U1)] bool global);

        [LibraryImport(Libraries.Alarm, EntryPoint = "alarm_get_global")]
        internal static partial int GetAlarmGlobalFlag(int alarmId, [MarshalAs(UnmanagedType.U1)] out bool global);

        [LibraryImport(Libraries.Alarm, EntryPoint = "alarm_foreach_registered_alarm")]
        internal static partial int GetAllRegisteredAlarms(RegisteredAlarmCallback callback, IntPtr userData);

        [LibraryImport(Libraries.Alarm, EntryPoint = "alarm_schedule_noti_once_at_date")]
        internal static partial AlarmError CreateAlarmNotiOnceAtDate(NotificationSafeHandle noti, ref DateTime date, out int alarmId);

        [LibraryImport(Libraries.Alarm, EntryPoint = "alarm_schedule_noti_after_delay")]
        internal static partial AlarmError CreateAlarmNotiAfterDelay(NotificationSafeHandle noti, int delay, int period, out int alarmId);

        [LibraryImport(Libraries.Alarm, EntryPoint = "alarm_schedule_noti_once_after_delay")]
        internal static partial AlarmError CreateAlarmNotiOnceAfterDelay(NotificationSafeHandle noti, int delay, out int alarmId);

        [LibraryImport(Libraries.Alarm, EntryPoint = "alarm_schedule_noti_with_recurrence_week_flag")]
        internal static partial AlarmError CreateAlarmNotiRecurWeek(NotificationSafeHandle noti, ref DateTime date, int week, out int alarmId);

        [LibraryImport(Libraries.Alarm, EntryPoint = "alarm_update_delay")]
        internal static partial AlarmError UpdateDelay(int alarmId, int delay);

        [LibraryImport(Libraries.Alarm, EntryPoint = "alarm_update_date")]
        internal static partial AlarmError UpdateDate(int alarmId, ref DateTime date);

        [LibraryImport(Libraries.Alarm, EntryPoint = "alarm_update_period")]
        internal static partial AlarmError UpdatePeriod(int alarmId, int period);

        [LibraryImport(Libraries.Alarm, EntryPoint = "alarm_update_week_flag")]
        internal static partial AlarmError UpdateWeekFlag(int alarmId, int week);

        //callback
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool RegisteredAlarmCallback(int alarmId, IntPtr userData);
    }
}
