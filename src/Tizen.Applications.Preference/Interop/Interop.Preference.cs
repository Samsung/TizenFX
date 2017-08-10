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
using Tizen.Applications;

/// <summary>
/// Contains Interop declarations of Preference classes.
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// Contains Interop declarations of Preference device API.
    /// </summary>
    internal static partial class Preference
    {
        internal delegate void ChangedCallback(string key, IntPtr userData);

        internal delegate bool ItemCallback(string key, IntPtr userData);

        [DllImport(Libraries.Preference, EntryPoint = "preference_set_int")]
        internal static extern int SetInt(string key, int value);

        [DllImport(Libraries.Preference, EntryPoint = "preference_get_int")]
        internal static extern int GetInt(string key, out int value);

        [DllImport(Libraries.Preference, EntryPoint = "preference_set_double")]
        internal static extern int SetDouble(string key, double value);

        [DllImport(Libraries.Preference, EntryPoint = "preference_get_double")]
        internal static extern int GetDouble(string key, out double value);

        [DllImport(Libraries.Preference, EntryPoint = "preference_set_string")]
        internal static extern int SetString(string key, string value);

        [DllImport(Libraries.Preference, EntryPoint = "preference_get_string")]
        internal static extern int GetString(string key, out string value);

        [DllImport(Libraries.Preference, EntryPoint = "preference_set_boolean")]
        internal static extern int SetBoolean(string key, bool value);

        [DllImport(Libraries.Preference, EntryPoint = "preference_get_boolean")]
        internal static extern int GetBoolean(string key, out bool value);

        [DllImport(Libraries.Preference, EntryPoint = "preference_remove")]
        internal static extern int Remove(string key);

        [DllImport(Libraries.Preference, EntryPoint = "preference_is_existing")]
        internal static extern int IsExisting(string key, out bool existing);

        [DllImport(Libraries.Preference, EntryPoint = "preference_remove_all")]
        internal static extern int RemoveAll();

        [DllImport(Libraries.Preference, EntryPoint = "preference_set_changed_cb")]
        internal static extern int SetChangedCb(string key, ChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Preference, EntryPoint = "preference_unset_changed_cb")]
        internal static extern int UnsetChangedCb(string key);

        [DllImport(Libraries.Preference, EntryPoint = "preference_foreach_item")]
        internal static extern int ForeachItem(ItemCallback callback, IntPtr userData);
    }
}
