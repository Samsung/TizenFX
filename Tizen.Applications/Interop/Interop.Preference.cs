// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

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
