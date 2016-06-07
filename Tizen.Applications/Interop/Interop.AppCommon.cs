// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;

using Tizen.Internals.Errors;
using Tizen.Applications;

internal static partial class Interop
{
    internal static partial class AppCommon
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

        internal delegate void AppEventCallback(IntPtr handle, IntPtr data);

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

    }
}

