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

internal static partial class Interop
{
    internal static partial class AppCommon
    {
	internal enum ResourceCategory : int
        {
            Image = 0,
            Layout,
            Sound,
            Binary
        }

        internal enum AppCommonErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            InvalidContext = -0x01100000 | 0x01,
            NoSuchFile = Tizen.Internals.Errors.ErrorCode.NoSuchFile,
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
        }

        [DllImport(Libraries.AppCommon, EntryPoint = "app_get_id")]
        internal static extern ErrorCode AppGetId(out string appId);

        [DllImport(Libraries.AppCommon, EntryPoint = "app_get_name")]
        internal static extern ErrorCode AppGetName(out string name);

        [DllImport(Libraries.AppCommon, EntryPoint = "app_get_resource_path")]
        internal static extern string AppGetResourcePath();

        [DllImport(Libraries.AppCommon, EntryPoint = "app_get_data_path")]
        internal static extern string AppGetDataPath();

        [DllImport(Libraries.AppCommon, EntryPoint = "app_get_cache_path")]
        internal static extern string AppGetCachePath();

        [DllImport(Libraries.AppCommon, EntryPoint = "app_get_shared_data_path")]
        internal static extern string AppGetSharedDataPath();

        [DllImport(Libraries.AppCommon, EntryPoint = "app_get_shared_resource_path")]
        internal static extern string AppGetSharedResourcePath();

        [DllImport(Libraries.AppCommon, EntryPoint = "app_get_shared_trusted_path")]
        internal static extern string AppGetSharedTrustedPath();

        [DllImport(Libraries.AppCommon, EntryPoint = "app_get_tep_resource_path")]
        internal static extern string AppGetTepResourcePath();

        [DllImport(Libraries.AppCommon, EntryPoint = "app_get_external_cache_path")]
        internal static extern string AppGetExternalCachePath();

        [DllImport(Libraries.AppCommon, EntryPoint = "app_get_external_data_path")]
        internal static extern string AppGetExternalDataPath();

        [DllImport(Libraries.AppCommon, EntryPoint = "app_get_external_shared_data_path")]
        internal static extern string AppGetExternalSharedDataPath();

        [DllImport(Libraries.AppCommon, EntryPoint = "app_get_common_data_path")]
        internal static extern string AppGetCommonDataPath();

        [DllImport(Libraries.AppCommon, EntryPoint = "app_get_common_cache_path")]
        internal static extern string AppGetCommonCachePath();

        [DllImport(Libraries.AppCommon, EntryPoint = "app_get_common_shared_data_path")]
        internal static extern string AppGetCommonSharedDataPath();

        [DllImport(Libraries.AppCommon, EntryPoint = "app_get_common_shared_trusted_path")]
        internal static extern string AppGetCommonSharedTrustedPath();

        [DllImport(Libraries.AppCommon, EntryPoint = "app_get_version")]
        internal static extern ErrorCode AppGetVersion(out string version);

        [DllImport(Libraries.AppCommon, EntryPoint = "app_event_get_low_memory_status")]
        internal static extern ErrorCode AppEventGetLowMemoryStatus(IntPtr handle, out LowMemoryStatus status);

        [DllImport(Libraries.AppCommon, EntryPoint = "app_event_get_low_battery_status")]
        internal static extern ErrorCode AppEventGetLowBatteryStatus(IntPtr handle, out LowBatteryStatus status);

        [DllImport(Libraries.AppCommon, EntryPoint = "app_event_get_language")]
        internal static extern ErrorCode AppEventGetLanguage(IntPtr handle, out string lang);

        [DllImport(Libraries.AppCommon, EntryPoint = "app_event_get_region_format")]
        internal static extern ErrorCode AppEventGetRegionFormat(IntPtr handle, out string region);

        [DllImport(Libraries.AppCommon, EntryPoint = "app_resource_manager_get")]
        internal static extern ErrorCode AppResourceManagerGet(ResourceCategory category, string id, out string path);

        [DllImport(Libraries.Application, EntryPoint = "app_resource_manager_get")]
        internal static extern ErrorCode LegacyAppResourceManagerGet(ResourceCategory category, string id, out string path);

        [DllImport(Libraries.AppCommon, EntryPoint = "app_event_get_device_orientation")]
        internal static extern ErrorCode AppEventGetDeviceOrientation(IntPtr handle, out DeviceOrientation orientation);

        [DllImport(Libraries.AppCommon, EntryPoint = "app_event_get_suspended_state")]
        internal static extern ErrorCode AppEventGetSuspendedState(IntPtr handle, out SuspendedState state);

        [DllImport(Libraries.AppCommon, EntryPoint = "app_get_res_control_allowed_resource_path")]
        internal static extern AppCommonErrorCode AppGetResControlAllowedResourcePath(string applicationId, out string path);

        [DllImport(Libraries.AppCommon, EntryPoint = "app_get_res_control_global_resource_path")]
        internal static extern AppCommonErrorCode AppGetResControlGlobalResourcePath(string applicationId, out string path);

        [DllImport(Libraries.AppCommon, EntryPoint = "app_event_get_time_zone")]
        internal static extern ErrorCode AppEventGetTimeZone(IntPtr handle, out string timeZone, out string timeZoneId);
        
        [DllImport(Libraries.AppCommon, EntryPoint = "app_watchdog_timer_enable")]
        internal static extern AppCommonErrorCode AppWatchdogTimerEnable();

        [DllImport(Libraries.AppCommon, EntryPoint = "app_watchdog_timer_disable")]
        internal static extern AppCommonErrorCode AppWatchdogTimerDisable();

        [DllImport(Libraries.AppCommon, EntryPoint = "app_watchdog_timer_kick")]
        internal static extern AppCommonErrorCode AppWatchdogTimerKick();

        [DllImport(Libraries.AppCommon, EntryPoint = "app_locale_manager_set_language")]
        internal static extern AppCommonErrorCode AppLocaleManagerSetLanguage(string lang);
        // int app_locale_manager_set_language(const char* lang)

        [DllImport(Libraries.AppCommon, EntryPoint = "app_locale_manager_get_language")]
        internal static extern AppCommonErrorCode AppLocaleManagerGetLanguage(out IntPtr langPtr);
        // int app_locale_manager_get_language(const char** lang)

        [DllImport(Libraries.AppCommon, EntryPoint = "app_locale_manager_get_system_language")]
        internal static extern AppCommonErrorCode AppLocaleManagerGetSystemLanguage(out IntPtr langPtr);
        // int app_locale_manager_get_system_language(const char** lang)
    }
}

