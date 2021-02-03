/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Tizen;
using Tizen.Applications;

internal static partial class Interop
{
    internal static partial class ThemeManager
    {
        private const string LogTag = "Tizen.Applications.ThemeManager";

        internal enum ErrorCode : int
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
            IoError = Tizen.Internals.Errors.ErrorCode.IoError,
            NoSuchTheme = Tizen.Internals.Errors.ErrorCode.NoSuchFile,
            KeyNotAvailable = Tizen.Internals.Errors.ErrorCode.KeyNotAvailable,
        }

        internal static class ThemeManagerErrorFactory
        {
            internal static Exception GetException(Interop.ThemeManager.ErrorCode err, string message)
            {
                string errMessage = string.Format("{0} err = {1}", message, err);
                Log.Warn(LogTag, errMessage);
                switch (err)
                {
                    case Interop.ThemeManager.ErrorCode.InvalidParameter:
                        return new ArgumentException(errMessage);
                    case Interop.ThemeManager.ErrorCode.PermissionDenied:
                        return new UnauthorizedAccessException(errMessage);
                    case Interop.ThemeManager.ErrorCode.NoSuchTheme:
                        return new FileNotFoundException(errMessage);
                    case Interop.ThemeManager.ErrorCode.KeyNotAvailable:
                        return new KeyNotFoundException(errMessage);
                    case Interop.ThemeManager.ErrorCode.IoError:
                    default:
                        return new InvalidOperationException(errMessage);
                }
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ThemeLoaderChangedCallback(IntPtr handle, IntPtr userData);

        [DllImport(Libraries.ThemeManager, EntryPoint = "theme_get_id")]
        internal static extern ErrorCode GetId(IntPtr handle, out string id);

        [DllImport(Libraries.ThemeManager, EntryPoint = "theme_get_version")]
        internal static extern ErrorCode GetVersion(IntPtr handle, out string version);

        [DllImport(Libraries.ThemeManager, EntryPoint = "theme_get_tool_version")]
        internal static extern ErrorCode GetToolVersion(IntPtr handle, out string version);

        [DllImport(Libraries.ThemeManager, EntryPoint = "theme_get_title")]
        internal static extern ErrorCode GetTitle(IntPtr handle, out string title);

        [DllImport(Libraries.ThemeManager, EntryPoint = "theme_get_resolution")]
        internal static extern ErrorCode GetResolution(IntPtr handle, out string resolution);

        [DllImport(Libraries.ThemeManager, EntryPoint = "theme_get_preview")]
        internal static extern ErrorCode GetPreview(IntPtr handle, out string preview);

        [DllImport(Libraries.ThemeManager, EntryPoint = "theme_get_description")]
        internal static extern ErrorCode GetDescription(IntPtr handle, out string description);

        [DllImport(Libraries.ThemeManager, EntryPoint = "theme_get_string")]
        internal static extern ErrorCode GetString(IntPtr handle, string key, out string val);

        [DllImport(Libraries.ThemeManager, EntryPoint = "theme_get_string_array")]
        internal static extern ErrorCode GetStringArray(IntPtr handle, string key, out IntPtr val, out int count);

        [DllImport(Libraries.ThemeManager, EntryPoint = "theme_get_path")]
        internal static extern ErrorCode GetPath(IntPtr handle, string key, out string val);

        [DllImport(Libraries.ThemeManager, EntryPoint = "theme_get_path_array")]
        internal static extern ErrorCode GetPathArray(IntPtr handle, string key, out IntPtr val, out int count);

        [DllImport(Libraries.ThemeManager, EntryPoint = "theme_get_int")]
        internal static extern ErrorCode GetInt(IntPtr handle, string key, out int val);

        [DllImport(Libraries.ThemeManager, EntryPoint = "theme_get_float")]
        internal static extern ErrorCode GetFloat(IntPtr handle, string key, out float val);

        [DllImport(Libraries.ThemeManager, EntryPoint = "theme_get_bool")]
        internal static extern ErrorCode GetBool(IntPtr handle, string key, out bool val);

        [DllImport(Libraries.ThemeManager, EntryPoint = "theme_is_key_exist")]
        internal static extern ErrorCode IsKeyExist(IntPtr handle, string key, out bool val);

        [DllImport(Libraries.ThemeManager, EntryPoint = "theme_clone")]
        internal static extern ErrorCode ThemeClone(IntPtr handle, out IntPtr cloned);

        [DllImport(Libraries.ThemeManager, EntryPoint = "theme_destroy")]
        internal static extern ErrorCode ThemeDestroy(IntPtr handle);

        [DllImport(Libraries.ThemeManager, EntryPoint = "theme_loader_create")]
        internal static extern ErrorCode LoaderCreate(out IntPtr loaderHandle);

        [DllImport(Libraries.ThemeManager, EntryPoint = "theme_loader_destroy")]
        internal static extern ErrorCode LoaderDestroy(IntPtr loaderHandle);

        [DllImport(Libraries.ThemeManager, EntryPoint = "theme_loader_add_event")]
        internal static extern ErrorCode LoaderAddEvent(IntPtr loaderHandle, ThemeLoaderChangedCallback callback, IntPtr userData, out string eventId);

        [DllImport(Libraries.ThemeManager, EntryPoint = "theme_loader_remove_event")]
        internal static extern ErrorCode LoaderRemoveEvent(IntPtr loaderHandle, string eventId);

        [DllImport(Libraries.ThemeManager, EntryPoint = "theme_loader_load_current")]
        internal static extern ErrorCode LoaderLoadCurrentTheme(IntPtr loaderHandle, out IntPtr handle);

        [DllImport(Libraries.ThemeManager, EntryPoint = "theme_loader_load")]
        internal static extern ErrorCode LoaderLoadTheme(IntPtr loaderHandle, string id, out IntPtr handle);

        [DllImport(Libraries.ThemeManager, EntryPoint = "theme_loader_query_id")]
        internal static extern ErrorCode LoaderQueryId(IntPtr loaderHandle, out IntPtr ids, out int count);

        [DllImport(Libraries.ThemeManager, EntryPoint = "theme_loader_set_current")]
        internal static extern ErrorCode LoaderSetCurrentTheme(IntPtr loaderHandle, string id);
    }
}
