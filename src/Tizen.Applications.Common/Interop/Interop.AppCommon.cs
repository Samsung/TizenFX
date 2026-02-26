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

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_get_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppGetId(out string appId);

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_get_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppGetName(out string name);

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_get_resource_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial string AppGetResourcePath();

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_get_data_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial string AppGetDataPath();

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_get_cache_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial string AppGetCachePath();

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_get_shared_data_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial string AppGetSharedDataPath();

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_get_shared_resource_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial string AppGetSharedResourcePath();

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_get_shared_trusted_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial string AppGetSharedTrustedPath();

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_get_tep_resource_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial string AppGetTepResourcePath();

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_get_external_cache_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial string AppGetExternalCachePath();

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_get_external_data_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial string AppGetExternalDataPath();

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_get_external_shared_data_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial string AppGetExternalSharedDataPath();

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_get_common_data_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial string AppGetCommonDataPath();

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_get_common_cache_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial string AppGetCommonCachePath();

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_get_common_shared_data_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial string AppGetCommonSharedDataPath();

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_get_common_shared_trusted_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial string AppGetCommonSharedTrustedPath();

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_get_version", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppGetVersion(out string version);

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_event_get_low_memory_status", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppEventGetLowMemoryStatus(IntPtr handle, out LowMemoryStatus status);

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_event_get_low_battery_status", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppEventGetLowBatteryStatus(IntPtr handle, out LowBatteryStatus status);

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_event_get_language", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppEventGetLanguage(IntPtr handle, out string lang);

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_event_get_region_format", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppEventGetRegionFormat(IntPtr handle, out string region);

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_resource_manager_get", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppResourceManagerGet(ResourceCategory category, string id, out string path);

        [LibraryImport(Libraries.Application, EntryPoint = "app_resource_manager_get", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode LegacyAppResourceManagerGet(ResourceCategory category, string id, out string path);

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_event_get_device_orientation", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppEventGetDeviceOrientation(IntPtr handle, out DeviceOrientation orientation);

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_event_get_suspended_state", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppEventGetSuspendedState(IntPtr handle, out SuspendedState state);

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_get_res_control_allowed_resource_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial AppCommonErrorCode AppGetResControlAllowedResourcePath(string applicationId, out string path);

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_get_res_control_global_resource_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial AppCommonErrorCode AppGetResControlGlobalResourcePath(string applicationId, out string path);

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_event_get_time_zone", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppEventGetTimeZone(IntPtr handle, out string timeZone, out string timeZoneId);
        
        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_watchdog_timer_enable", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial AppCommonErrorCode AppWatchdogTimerEnable();

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_watchdog_timer_disable", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial AppCommonErrorCode AppWatchdogTimerDisable();

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_watchdog_timer_kick", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial AppCommonErrorCode AppWatchdogTimerKick();

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_locale_manager_set_language", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial AppCommonErrorCode AppLocaleManagerSetLanguage(string lang);
        // int app_locale_manager_set_language(const char *lang)

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_locale_manager_get_language", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial AppCommonErrorCode AppLocaleManagerGetLanguage(out IntPtr langPtr);
        // int app_locale_manager_get_language(char **lang)

        [LibraryImport(Libraries.AppCommon, EntryPoint = "app_locale_manager_get_system_language", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial AppCommonErrorCode AppLocaleManagerGetSystemLanguage(out IntPtr langPtr);
        // int app_locale_manager_get_system_language(char **lang)
    }
}



