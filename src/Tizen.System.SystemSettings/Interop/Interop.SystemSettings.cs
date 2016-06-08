/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Runtime.InteropServices;

namespace Tizen.System.SystemSettings
{
    internal static class Interop
    {
        internal static partial class Settings
        {
            [DllImport("capi-system-system-settings.so.0", EntryPoint = "system_settings_set_value_int", CallingConvention = CallingConvention.Cdecl)]
            internal static extern int SystemSettingsSetValueInt(SystemSettingsKeys key, int value);

            [DllImport("capi-system-system-settings.so.0", EntryPoint = "system_settings_set_value_bool", CallingConvention = CallingConvention.Cdecl)]
            internal static extern int SystemSettingsSetValueBool(SystemSettingsKeys key, bool value);

            [DllImport("capi-system-system-settings.so.0", EntryPoint = "system_settings_set_value_string", CallingConvention = CallingConvention.Cdecl)]
            internal static extern int SystemSettingsSetValueString(SystemSettingsKeys key, string value);


            [DllImport("capi-system-system-settings.so.0", EntryPoint = "system_settings_get_value_int", CallingConvention = CallingConvention.Cdecl)]
            internal static extern int SystemSettingsGetValueInt(SystemSettingsKeys key, out int value);

            [DllImport("capi-system-system-settings.so.0", EntryPoint = "system_settings_get_value_bool", CallingConvention = CallingConvention.Cdecl)]
            internal static extern int SystemSettingsGetValueBool(SystemSettingsKeys key, out bool value);

            [DllImport("capi-system-system-settings.so.0", EntryPoint = "system_settings_get_value_string", CallingConvention = CallingConvention.Cdecl)]
            internal static extern int SystemSettingsGetValueString(SystemSettingsKeys key, out string value);

            // Callback
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void SystemSettingsChangedCallback(SystemSettingsKeys key, IntPtr data);
            [DllImport("capi-system-system-settings.so.0", EntryPoint = "system_settings_set_changed_cb", CallingConvention = CallingConvention.Cdecl)]
            internal static extern int SystemSettingsSetCallback(SystemSettingsKeys systemSettingsKey, SystemSettingsChangedCallback cb, IntPtr data);
            [DllImport("capi-system-system-settings.so.0", EntryPoint = "system_settings_unset_changed_cb", CallingConvention = CallingConvention.Cdecl)]
            internal static extern int SystemSettingsRemoveCallback(SystemSettingsKeys systemSettingsKey);
        }
    }
}