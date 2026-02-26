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

internal static partial class Interop
{
    internal static partial class Download
    {
        // Request class

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void StateChangedCallback(int requestId, int state, IntPtr userData);
        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void ProgressChangedCallback(int requestId, ulong receivedSize, IntPtr userData);

        [LibraryImport(Libraries.Download, EntryPoint = "download_create", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int CreateRequest(out int requestId);
        [LibraryImport(Libraries.Download, EntryPoint = "download_destroy", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int DestroyRequest(int requestId);
        [LibraryImport(Libraries.Download, EntryPoint = "download_set_url", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetUrl(int requestId, string url);
        [LibraryImport(Libraries.Download, EntryPoint = "download_get_url", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetUrl(int requestId, out string url);
        [LibraryImport(Libraries.Download, EntryPoint = "download_set_network_type", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetNetworkType(int requestId, int networkType);
        [LibraryImport(Libraries.Download, EntryPoint = "download_get_network_type", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetNetworkType(int requestId, out int networkType);
        [LibraryImport(Libraries.Download, EntryPoint = "download_set_destination", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetDestination(int requestId, string path);
        [LibraryImport(Libraries.Download, EntryPoint = "download_get_destination", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetDestination(int requestId, out string path);
        [LibraryImport(Libraries.Download, EntryPoint = "download_set_file_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetFileName(int requestId, string fileName);
        [LibraryImport(Libraries.Download, EntryPoint = "download_get_file_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetFileName(int requestId, out string path);
        [LibraryImport(Libraries.Download, EntryPoint = "download_set_auto_download", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetAutoDownload(int requestId, [MarshalAs(UnmanagedType.U1)] bool value);
        [LibraryImport(Libraries.Download, EntryPoint = "download_get_auto_download", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetAutoDownload(int requestId, [MarshalAs(UnmanagedType.U1)] out bool value);
        [LibraryImport(Libraries.Download, EntryPoint = "download_set_temp_file_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetTempFilePath(int requestId, string tempPath);
        [LibraryImport(Libraries.Download, EntryPoint = "download_get_temp_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetTempFilePath(int requestId, out string tempPath);
        [LibraryImport(Libraries.Download, EntryPoint = "download_add_http_header_field", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int AddHttpHeaderField(int requestId, string field, string value);
        [LibraryImport(Libraries.Download, EntryPoint = "download_get_downloaded_file_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetDownloadedPath(int requestId, out string downloadedPath);
        [LibraryImport(Libraries.Download, EntryPoint = "download_get_mime_type", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetMimeType(int requestId, out string mimeType);
        [LibraryImport(Libraries.Download, EntryPoint = "download_get_state", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetState(int requestId, out int downloadState);
        [LibraryImport(Libraries.Download, EntryPoint = "download_get_content_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetContentName(int requestId, out string contentName);
        [LibraryImport(Libraries.Download, EntryPoint = "download_get_content_size", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetContentSize(int requestId, out ulong size);
        [LibraryImport(Libraries.Download, EntryPoint = "download_get_http_status", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetHttpStatus(int requestId, out int httpStatus);
        [LibraryImport(Libraries.Download, EntryPoint = "download_get_etag", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetETag(int requestId, out string etag);
        [LibraryImport(Libraries.Download, EntryPoint = "download_start", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int StartDownload(int requestId);
        [LibraryImport(Libraries.Download, EntryPoint = "download_pause", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int PauseDownload(int requestId);
        [LibraryImport(Libraries.Download, EntryPoint = "download_cancel", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int CancelDownload(int requestId);
        [LibraryImport(Libraries.Download, EntryPoint = "download_set_state_changed_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetStateChangedCallback(int requestId, StateChangedCallback callback, IntPtr userData);
        [LibraryImport(Libraries.Download, EntryPoint = "download_unset_state_changed_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int UnsetStateChangedCallback(int requestId);
        [LibraryImport(Libraries.Download, EntryPoint = "download_set_progress_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetProgressCallback(int requestId, ProgressChangedCallback callback, IntPtr userData);
        [LibraryImport(Libraries.Download, EntryPoint = "download_unset_progress_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int UnsetProgressCallback(int requestId);

        // Notification class

        [LibraryImport(Libraries.Download, EntryPoint = "download_set_notification_title", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetNotificationTitle(int requestId, string title);
        [LibraryImport(Libraries.Download, EntryPoint = "download_get_notification_title", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetNotificationTitle(int requestId, out string title);
        [LibraryImport(Libraries.Download, EntryPoint = "download_set_notification_description", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetNotificationDescription(int requestId, string description);
        [LibraryImport(Libraries.Download, EntryPoint = "download_get_notification_description", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetNotificationDescription(int requestId, out string description);
        [LibraryImport(Libraries.Download, EntryPoint = "download_set_notification_type", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetNotificationType(int requestId, int type);
        [LibraryImport(Libraries.Download, EntryPoint = "download_get_notification_type", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetNotificationType(int requestId, out int type);
        [LibraryImport(Libraries.Download, EntryPoint = "download_set_notification_app_control", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetNotificationAppControl(int requestId, int appControlType, SafeAppControlHandle handle);
        [LibraryImport(Libraries.Download, EntryPoint = "download_get_notification_app_control", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetNotificationAppControl(int requestId, int appControlType, out SafeAppControlHandle handle);
        [LibraryImport(Libraries.Download, EntryPoint = "download_set_cache", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetDownloadCache(int downloadId, [MarshalAs(UnmanagedType.U1)] bool enable);
        [LibraryImport(Libraries.Download, EntryPoint = "download_get_cache", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetDownloadCache(int downloadId, [MarshalAs(UnmanagedType.U1)] out bool enable);
        [LibraryImport(Libraries.Download, EntryPoint = "download_reset_cache", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int ResetDownloadCache();
        [LibraryImport(Libraries.Download, EntryPoint = "download_set_cache_max_size", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetDownloadCacheMaxSize(uint maxSize);
        [LibraryImport(Libraries.Download, EntryPoint = "download_get_cache_max_size", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetDownloadCacheMaxSize(out uint maxSize);
        [LibraryImport(Libraries.Download, EntryPoint = "download_reset_all_cache", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int ResetAllDownloadCache();
        [LibraryImport(Libraries.Download, EntryPoint = "download_set_cache_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetDownloadCachePath(string cachePath);
        [LibraryImport(Libraries.Download, EntryPoint = "download_get_cache_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetDownloadCachePath(out string cachePath);
        [LibraryImport(Libraries.Download, EntryPoint = "download_set_cache_lifecycle", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetDownloadCacheLifeCycle(uint time);
        [LibraryImport(Libraries.Download, EntryPoint = "download_get_cache_lifecycle", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetDownloadCacheLifeCycle(out uint time);
    }
}




