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
using Tizen.System;

internal static partial class Interop
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
        [DllImport("capi-system-system-settings.so.0", EntryPoint = "system_settings_add_changed_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SystemSettingsSetCallback(SystemSettingsKeys systemSettingsKey, SystemSettingsChangedCallback cb, IntPtr data);
        [DllImport("capi-system-system-settings.so.0", EntryPoint = "system_settings_remove_changed_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SystemSettingsRemoveCallback(SystemSettingsKeys systemSettingsKey, SystemSettingsChangedCallback cb);
    }
}
