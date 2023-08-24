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
using Tizen.Internals;
using Tizen.Applications;

internal static partial class Interop
{
    internal static partial class Watch
    {
        internal enum AppEventType
        {
            LowMemory = 0,
            LowBattery,
            LanguageChanged,
            DeviceOrientationChanged,
            RegionFormatChanged,
            SuspendedStateChanged
        }

        internal enum ErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            InvalidContext = -0x01100000 | 0x01,
            NoSuchFile = Tizen.Internals.Errors.ErrorCode.NoSuchFile,
            NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,
            AlreadyRunning = Tizen.Internals.Errors.ErrorCode.AlreadyInProgress
        }

        internal delegate void AppEventCallback(IntPtr handle, IntPtr data);

        internal delegate bool WatchAppCreateCallback(int width, int height, IntPtr userData);

        internal delegate void WatchAppPauseCallback(IntPtr userData);

        internal delegate void WatchAppResumeCallback(IntPtr userData);

        internal delegate void WatchAppTerminateCallback(IntPtr userData);

        internal delegate void WatchAppControlCallback(IntPtr appControl, IntPtr userData);

        internal delegate void WatchAppTimeTickCallback(IntPtr watchTime, IntPtr userData);

        internal delegate void WatchAppAmbientTickCallback(IntPtr watchTime, IntPtr userData);

        internal delegate void WatchAppAmbientChangedCallback(bool ambientMode, IntPtr userData);

#if !PROFILE_TV
        [NativeStruct("watch_app_lifecycle_callback_s", Include="watch_app.h", PkgConfig="capi-appfw-watch-application")]
#endif
        [StructLayout(LayoutKind.Sequential)]
        internal struct WatchAppLifecycleCallbacks
        {
            public WatchAppCreateCallback OnCreate;
            public WatchAppControlCallback OnAppControl;
            public WatchAppPauseCallback OnPause;
            public WatchAppResumeCallback OnResume;
            public WatchAppTerminateCallback OnTerminate;
            public WatchAppTimeTickCallback OnTick;
            public WatchAppAmbientTickCallback OnAmbientTick;
            public WatchAppAmbientChangedCallback OnAmbientChanged;
        }

        [DllImport(Libraries.AppCoreWatch, EntryPoint = "watch_app_main")]
        internal static extern ErrorCode Main(int argc, string[] argv, ref WatchAppLifecycleCallbacks callback, IntPtr userData);

        [DllImport(Libraries.AppCoreWatch, EntryPoint = "watch_app_exit")]
        internal static extern void Exit();

        [DllImport(Libraries.AppCoreWatch, EntryPoint = "watch_app_add_event_handler")]
        internal static extern ErrorCode AddEventHandler(out IntPtr handle, AppEventType eventType, AppEventCallback callback, IntPtr userData);

        [DllImport(Libraries.AppCoreWatch, EntryPoint = "watch_app_remove_event_handler")]
        internal static extern ErrorCode RemoveEventHandler(IntPtr handle);

        // tizen 3.0
        [DllImport(Libraries.AppCoreWatch, EntryPoint = "watch_app_set_time_tick_frequency")]
        internal static extern ErrorCode SetTimeTickFrequency(int ticks, TimeTickResolution type);

        // tizen 3.0
        [DllImport(Libraries.AppCoreWatch, EntryPoint = "watch_app_get_time_tick_frequency")]
        internal static extern ErrorCode GetTimeTickFrequency(out int ticks, out TimeTickResolution type);

        [DllImport(Libraries.AppCoreWatch, EntryPoint = "watch_app_set_ambient_tick_type")]
        internal static extern ErrorCode SetAmbientTickType(AmbientTickType type);

        [DllImport(Libraries.AppCoreWatch, EntryPoint = "watch_app_get_ambient_tick_type")]
        internal static extern ErrorCode GetAmbientTickType(out AmbientTickType type);

        [DllImport(Libraries.AppCoreWatch, EntryPoint = "watch_time_delete")]
        internal static extern ErrorCode WatchTimeDelete(IntPtr watchTime);

        [DllImport(Libraries.AppCoreWatch, EntryPoint = "watch_time_get_year")]
        internal static extern ErrorCode WatchTimeGetYear(SafeWatchTimeHandle handle, out int year);

        [DllImport(Libraries.AppCoreWatch, EntryPoint = "watch_time_get_month")]
        internal static extern ErrorCode WatchTimeGetMonth(SafeWatchTimeHandle handle, out int month);

        [DllImport(Libraries.AppCoreWatch, EntryPoint = "watch_time_get_day")]
        internal static extern ErrorCode WatchTimeGetDay(SafeWatchTimeHandle handle, out int day);

        [DllImport(Libraries.AppCoreWatch, EntryPoint = "watch_time_get_day_of_week")]
        internal static extern ErrorCode WatchTimeGetDayOfWeek(SafeWatchTimeHandle handle, out int day_of_week);

        [DllImport(Libraries.AppCoreWatch, EntryPoint = "watch_time_get_hour")]
        internal static extern ErrorCode WatchTimeGetHour(SafeWatchTimeHandle handle, out int hour);

        [DllImport(Libraries.AppCoreWatch, EntryPoint = "watch_time_get_hour24")]
        internal static extern ErrorCode WatchTimeGetHour24(SafeWatchTimeHandle handle, out int hour24);

        [DllImport(Libraries.AppCoreWatch, EntryPoint = "watch_time_get_minute")]
        internal static extern ErrorCode WatchTimeGetMinute(SafeWatchTimeHandle handle, out int minute);

        [DllImport(Libraries.AppCoreWatch, EntryPoint = "watch_time_get_second")]
        internal static extern ErrorCode WatchTimeGetSecond(SafeWatchTimeHandle handle, out int second);

        [DllImport(Libraries.AppCoreWatch, EntryPoint = "watch_time_get_millisecond")]
        internal static extern ErrorCode WatchTimeGetMillisecond(SafeWatchTimeHandle handle, out int millisecond);

        [DllImport(Libraries.AppCoreWatch, EntryPoint = "watch_app_get_elm_win")]
        internal static extern ErrorCode GetWin(out IntPtr win);

        [DllImport(Libraries.AppCoreWatch, EntryPoint = "watch_time_get_utc_timestamp")]
        internal static extern ErrorCode WatchTimeGetUtcTimestamp(SafeWatchTimeHandle handle, out long utc_timestamp);

        [DllImport(Libraries.AppCoreWatch, EntryPoint = "watch_time_get_time_zone")]
        internal static extern ErrorCode WatchTimeGetTimeZone(SafeWatchTimeHandle handle, out string time_zone_id);

        [DllImport(Libraries.AppCoreWatch, EntryPoint = "watch_time_get_current_time")]
        internal static extern ErrorCode WatchTimeGetCurrentTime(out SafeWatchTimeHandle handle);

        // app common
        [DllImport(Libraries.AppCommon, EntryPoint = "app_event_get_low_memory_status")]
        internal static extern Tizen.Internals.Errors.ErrorCode AppEventGetLowMemoryStatus(IntPtr handle, out LowMemoryStatus status);

        [DllImport(Libraries.AppCommon, EntryPoint = "app_event_get_low_battery_status")]
        internal static extern Tizen.Internals.Errors.ErrorCode AppEventGetLowBatteryStatus(IntPtr handle, out LowBatteryStatus status);

        [DllImport(Libraries.AppCommon, EntryPoint = "app_event_get_language")]
        internal static extern Tizen.Internals.Errors.ErrorCode AppEventGetLanguage(IntPtr handle, out string lang);

        [DllImport(Libraries.AppCommon, EntryPoint = "app_event_get_region_format")]
        internal static extern Tizen.Internals.Errors.ErrorCode AppEventGetRegionFormat(IntPtr handle, out string region);
    }
}