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
using Tizen.Applications;

/// <summary>
/// Contains interop declarations of the preference classes.
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// Contains interop declarations of the preference device API.
    /// </summary>
    internal static partial class Preference
    {
        internal delegate void ChangedCallback(string key, IntPtr userData);

        [return: MarshalAs(UnmanagedType.U1)] internal delegate bool ItemCallback(string key, IntPtr userData);

        [LibraryImport(Libraries.Preference, EntryPoint = "preference_set_int", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetInt(string key, int value);

        [LibraryImport(Libraries.Preference, EntryPoint = "preference_get_int", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetInt(string key, out int value);

        [LibraryImport(Libraries.Preference, EntryPoint = "preference_set_double", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetDouble(string key, double value);

        [LibraryImport(Libraries.Preference, EntryPoint = "preference_get_double", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetDouble(string key, out double value);

        [LibraryImport(Libraries.Preference, EntryPoint = "preference_set_string", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetString(string key, string value);

        [LibraryImport(Libraries.Preference, EntryPoint = "preference_get_string", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetString(string key, out string value);

        [LibraryImport(Libraries.Preference, EntryPoint = "preference_set_boolean", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetBoolean(string key, [MarshalAs(UnmanagedType.U1)] bool value);

        [LibraryImport(Libraries.Preference, EntryPoint = "preference_get_boolean", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetBoolean(string key, [MarshalAs(UnmanagedType.U1)] out bool value);

        [LibraryImport(Libraries.Preference, EntryPoint = "preference_remove", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int Remove(string key);

        [LibraryImport(Libraries.Preference, EntryPoint = "preference_is_existing", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int IsExisting(string key, [MarshalAs(UnmanagedType.U1)] out bool existing);

        [LibraryImport(Libraries.Preference, EntryPoint = "preference_remove_all", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int RemoveAll();

        [LibraryImport(Libraries.Preference, EntryPoint = "preference_set_changed_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetChangedCb(string key, ChangedCallback callback, IntPtr userData);

        [LibraryImport(Libraries.Preference, EntryPoint = "preference_unset_changed_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int UnsetChangedCb(string key);

        [LibraryImport(Libraries.Preference, EntryPoint = "preference_foreach_item", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int ForeachItem(ItemCallback callback, IntPtr userData);
    }
}




