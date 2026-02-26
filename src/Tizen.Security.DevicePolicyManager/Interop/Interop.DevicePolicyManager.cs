/*
 *  Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License
 */

using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

internal static partial class Interop
{
    internal static partial class DevicePolicyManager
    {
        internal enum ErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            TimeOut = Tizen.Internals.Errors.ErrorCode.TimedOut,
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
            ConnectionRefused = Tizen.Internals.Errors.ErrorCode.ConnectionRefused,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void PolicyChangedCallback(string name, string state, IntPtr userData);
        // void (* dpm_policy_changed_cb)(const char* name, const char* state, void* user_data);

        [LibraryImport(Libraries.DevicePolicyManager, EntryPoint = "dpm_add_policy_changed_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int AddPolicyChangedCallback(IntPtr handle, string name, PolicyChangedCallback callback, IntPtr userData, out int callbackId);
        // int dpm_add_policy_changed_cb(device_policy_manager_h handle, const char* name, dpm_policy_changed_cb callback, void* user_data, int* id)

        [LibraryImport(Libraries.DevicePolicyManager, EntryPoint = "dpm_remove_policy_changed_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int RemovePolicyChangedCallback(IntPtr handle, int callbackId);
        // int dpm_remove_policy_changed_cb(device_policy_manager_h handle, int id)

        [LibraryImport(Libraries.DevicePolicyManager, EntryPoint = "dpm_manager_create", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial IntPtr CreateHandle();
        // device_policy_manager_h dpm_manager_create(void)

        [LibraryImport(Libraries.DevicePolicyManager, EntryPoint = "dpm_manager_destroy", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int DestroyHandle(IntPtr handle);
        // int dpm_manager_destroy(device_policy_manager_h handle)

        [DllImport(Libraries.DevicePolicyManager, EntryPoint = "dpm_password_get_expires", CallingConvention = CallingConvention.Cdecl), ]
        internal static extern int PasswordGetExpires(IntPtr handle, out int value);
        // int dpm_password_get_expires(device_policy_manager_h handle, int* value)

        [LibraryImport(Libraries.DevicePolicyManager, EntryPoint = "dpm_password_get_history", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int PasswordGetHistory(IntPtr handle, out int value);
        // int dpm_password_get_history(device_policy_manager_h handle, int* value)

        [LibraryImport(Libraries.DevicePolicyManager, EntryPoint = "dpm_password_get_max_inactivity_time_device_lock", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int PasswordGetMaxInactivityTimeDeviceLock(IntPtr handle, out int value);
        // int dpm_password_get_max_inactivity_time_device_lock(device_policy_manager_h handle, int* value)

        [LibraryImport(Libraries.DevicePolicyManager, EntryPoint = "dpm_password_get_maximum_failed_attempts_for_wipe", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int PasswordGetMaximumFailedAttemptsForWipe(IntPtr handle, out int value);
        // int dpm_password_get_maximum_failed_attempts_for_wipe(device_policy_manager_h handle, int* value)

        [LibraryImport(Libraries.DevicePolicyManager, EntryPoint = "dpm_password_get_min_complex_chars", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int PasswordGetMinComplexChars(IntPtr handle, out int value);
        // int dpm_password_get_min_complex_chars(device_policy_manager_h handle, int* value)

        [LibraryImport(Libraries.DevicePolicyManager, EntryPoint = "dpm_password_get_minimum_length", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int PasswordGetMinimumLength(IntPtr handle, out int value);
        // int dpm_password_get_minimum_length(device_policy_manager_h handle, int* value)

        [LibraryImport(Libraries.DevicePolicyManager, EntryPoint = "dpm_password_get_quality", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int PasswordGetQuality(IntPtr handle, out int quality);
        // int dpm_password_get_quality(device_policy_manager_h handle, int* quality)

        [LibraryImport(Libraries.DevicePolicyManager, EntryPoint = "dpm_restriction_get_messaging_state", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int RestrictionGetMessagingState(IntPtr handle, string simId, out int allowed);
        // int dpm_restriction_get_messaging_state(device_policy_manager_h handle, const char* sim_id, int* is_allowed)

        [LibraryImport(Libraries.DevicePolicyManager, EntryPoint = "dpm_restriction_get_popimap_email_state", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int RestrictionGetPopimapEmailState(IntPtr handle, out int allowed);
        // int dpm_restriction_get_popimap_email_state(device_policy_manager_h handle, int* is_allowed)

        [LibraryImport(Libraries.DevicePolicyManager, EntryPoint = "dpm_restriction_get_wifi_state", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int RestrictionGetWifiState(IntPtr handle, out int allowed);
        // int dpm_restriction_get_wifi_state(device_policy_manager_h handle, int* is_allowed)

        [LibraryImport(Libraries.DevicePolicyManager, EntryPoint = "dpm_restriction_get_wifi_hotspot_state", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int RestrictionGetWifiHotspotState(IntPtr handle, out int allowed);
        // int dpm_restriction_get_wifi_hotspot_state(device_policy_manager_h handle, int* is_allowed)

        [LibraryImport(Libraries.DevicePolicyManager, EntryPoint = "dpm_restriction_get_bluetooth_mode_change_state", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int RestrictionGetBluetoothModeChangeState(IntPtr handle, out int allowed);
        // int dpm_restriction_get_bluetooth_mode_change_state(device_policy_manager_h handle, int* is_allowed)

        [LibraryImport(Libraries.DevicePolicyManager, EntryPoint = "dpm_restriction_get_bluetooth_tethering_state", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int RestrictionGetBluetoothTetheringState(IntPtr handle, out int allowed);
        // int dpm_restriction_get_bluetooth_tethering_state(device_policy_manager_h handle, int* is_allowed)

        [LibraryImport(Libraries.DevicePolicyManager, EntryPoint = "dpm_restriction_get_browser_state", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int RestrictionGetBrowserState(IntPtr handle, out int allowed);
        // int dpm_restriction_get_browser_state(device_policy_manager_h handle, int* is_allowed)

        [LibraryImport(Libraries.DevicePolicyManager, EntryPoint = "dpm_restriction_get_camera_state", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int RestrictionGetCameraState(IntPtr handle, out int allowed);
        // int dpm_restriction_get_camera_state(device_policy_manager_h handle, int* is_allowed)

        [LibraryImport(Libraries.DevicePolicyManager, EntryPoint = "dpm_restriction_get_microphone_state", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int RestrictionGetMicrophoneState(IntPtr handle, out int allowed);
        // int dpm_restriction_get_microphone_state(device_policy_manager_h handle, int* is_allowed)

        [LibraryImport(Libraries.DevicePolicyManager, EntryPoint = "dpm_restriction_get_location_state", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int RestrictionGetLocationState(IntPtr handle, out int allowed);
        // int dpm_restriction_get_location_state(device_policy_manager_h handle, int* is_allowed)

        [LibraryImport(Libraries.DevicePolicyManager, EntryPoint = "dpm_restriction_get_external_storage_state", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int RestrictionGetExternalStorageState(IntPtr handle, out int allowed);
        // int dpm_restriction_get_external_storage_state(device_policy_manager_h handle, int* is_allowed)

        [LibraryImport(Libraries.DevicePolicyManager, EntryPoint = "dpm_restriction_get_usb_tethering_state", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int RestrictionGetUsbTetheringState(IntPtr handle, out int allowed);
        // int dpm_restriction_get_usb_tethering_state(device_policy_manager_h handle, int* is_allowed)
    }
}



