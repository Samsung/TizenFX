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
using System.Runtime.InteropServices.Marshalling;
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

        internal static partial class ThemeManagerErrorFactory
        {
            internal static Exception GetException(Interop.ThemeManager.ErrorCode err, string message)
            {
                string errMessage = $"{message} err = {err}";
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
        internal delegate int ThemeLoaderChangedCallback(IntPtr handle, IntPtr userData);

        [LibraryImport(Libraries.ThemeManager, EntryPoint = "theme_get_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetId(IntPtr handle, out string id);

        [LibraryImport(Libraries.ThemeManager, EntryPoint = "theme_get_version", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetVersion(IntPtr handle, out string version);

        [LibraryImport(Libraries.ThemeManager, EntryPoint = "theme_get_tool_version", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetToolVersion(IntPtr handle, out string version);

        [LibraryImport(Libraries.ThemeManager, EntryPoint = "theme_get_title", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetTitle(IntPtr handle, out string title);

        [LibraryImport(Libraries.ThemeManager, EntryPoint = "theme_get_resolution", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetResolution(IntPtr handle, out string resolution);

        [LibraryImport(Libraries.ThemeManager, EntryPoint = "theme_get_preview", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetPreview(IntPtr handle, out string preview);

        [LibraryImport(Libraries.ThemeManager, EntryPoint = "theme_get_description", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetDescription(IntPtr handle, out string description);

        [LibraryImport(Libraries.ThemeManager, EntryPoint = "theme_get_string", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetString(IntPtr handle, string key, out string val);

        [LibraryImport(Libraries.ThemeManager, EntryPoint = "theme_get_string_array", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetStringArray(IntPtr handle, string key, out IntPtr val, out int count);

        [LibraryImport(Libraries.ThemeManager, EntryPoint = "theme_get_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetPath(IntPtr handle, string key, out string val);

        [LibraryImport(Libraries.ThemeManager, EntryPoint = "theme_get_path_array", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetPathArray(IntPtr handle, string key, out IntPtr val, out int count);

        [LibraryImport(Libraries.ThemeManager, EntryPoint = "theme_get_int", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetInt(IntPtr handle, string key, out int val);

        [LibraryImport(Libraries.ThemeManager, EntryPoint = "theme_get_float", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetFloat(IntPtr handle, string key, out float val);

        [LibraryImport(Libraries.ThemeManager, EntryPoint = "theme_get_bool", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetBool(IntPtr handle, string key, [MarshalAs(UnmanagedType.U1)] out bool val);

        [LibraryImport(Libraries.ThemeManager, EntryPoint = "theme_is_key_exist", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode IsKeyExist(IntPtr handle, string key, [MarshalAs(UnmanagedType.U1)] out bool val);

        [LibraryImport(Libraries.ThemeManager, EntryPoint = "theme_clone")]
        internal static partial ErrorCode ThemeClone(IntPtr handle, out IntPtr cloned);

        [LibraryImport(Libraries.ThemeManager, EntryPoint = "theme_destroy")]
        internal static partial ErrorCode ThemeDestroy(IntPtr handle);

        [LibraryImport(Libraries.ThemeManager, EntryPoint = "theme_loader_create")]
        internal static partial ErrorCode LoaderCreate(out IntPtr loaderHandle);

        [LibraryImport(Libraries.ThemeManager, EntryPoint = "theme_loader_destroy")]
        internal static partial ErrorCode LoaderDestroy(IntPtr loaderHandle);

        [LibraryImport(Libraries.ThemeManager, EntryPoint = "theme_loader_add_event", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode LoaderAddEvent(IntPtr loaderHandle, ThemeLoaderChangedCallback callback, IntPtr userData, out string eventId);

        [LibraryImport(Libraries.ThemeManager, EntryPoint = "theme_loader_remove_event", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode LoaderRemoveEvent(IntPtr loaderHandle, string eventId);

        [LibraryImport(Libraries.ThemeManager, EntryPoint = "theme_loader_load_current")]
        internal static partial ErrorCode LoaderLoadCurrentTheme(IntPtr loaderHandle, out IntPtr handle);

        [LibraryImport(Libraries.ThemeManager, EntryPoint = "theme_loader_load", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode LoaderLoadTheme(IntPtr loaderHandle, string id, out IntPtr handle);

        [LibraryImport(Libraries.ThemeManager, EntryPoint = "theme_loader_query_id")]
        internal static partial ErrorCode LoaderQueryId(IntPtr loaderHandle, out IntPtr ids, out int count);

        [LibraryImport(Libraries.ThemeManager, EntryPoint = "theme_loader_set_current", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode LoaderSetCurrentTheme(IntPtr loaderHandle, string id);
    }
}




