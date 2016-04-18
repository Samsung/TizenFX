using System;
using System.Runtime.InteropServices;
using Tizen.Applications;

internal static partial class Interop
{
    internal static partial class Download
    {
        //capi-web-url-download
        // Request class
        //Callback delegate for event
        internal delegate void StateChangedCallback(int requestId, int state, IntPtr userData);

        internal delegate void ProgressChangedCallback(int requestId, ulong receivedSize, IntPtr userData);

        [DllImport(Libraries.Download, EntryPoint = "download_create")]
        internal static extern int CreateRequest(out int requestId);
        [DllImport(Libraries.Download, EntryPoint = "download_destroy")]
        internal static extern int DestroyRequest(int requestId);
        [DllImport(Libraries.Download, EntryPoint = "download_set_url")]
        internal static extern int SetUrl(int requestId, string url);
        [DllImport(Libraries.Download, EntryPoint = "download_get_url")]
        internal static extern int GetUrl(int requestId, out string url);
        [DllImport(Libraries.Download, EntryPoint = "download_set_network_type")]
        internal static extern int SetNetworkType(int requestId, int networkType);
        [DllImport(Libraries.Download, EntryPoint = "download_get_network_type")]
        internal static extern int GetNetworkType(int requestId, out int networkType);
        [DllImport(Libraries.Download, EntryPoint = "download_set_destination")]
        internal static extern int SetDestination(int requestId, string path);
        [DllImport(Libraries.Download, EntryPoint = "download_get_destination")]
        internal static extern int GetDestination(int requestId, out string path);
        [DllImport(Libraries.Download, EntryPoint = "download_set_file_name")]
        internal static extern int SetFileName(int requestId, string fileName);
        [DllImport(Libraries.Download, EntryPoint = "download_get_file_name")]
        internal static extern int GetFileName(int requestId, out string path);
        [DllImport(Libraries.Download, EntryPoint = "download_set_auto_download")]
        internal static extern int SetAutoDownload(int requestId, bool value);
        [DllImport(Libraries.Download, EntryPoint = "download_get_auto_download")]
        internal static extern int GetAutoDownload(int requestId, out bool value);
        [DllImport(Libraries.Download, EntryPoint = "download_set_temp_file_path")]
        internal static extern int SetTempFilePath(int requestId, string tempPath);
        [DllImport(Libraries.Download, EntryPoint = "download_get_temp_path")]
        internal static extern int GetTempFilePath(int requestId, out string tempPath);
        [DllImport(Libraries.Download, EntryPoint = "download_add_http_header_field")]
        internal static extern int AddHttpHeaderField(int requestId, string field, string value);
        [DllImport(Libraries.Download, EntryPoint = "download_get_http_header_field")]
        internal static extern int GetHttpHeaderField(int requestId, string field, out string value);
        [DllImport(Libraries.Download, EntryPoint = "download_get_http_header_field_list")]
        internal static extern int GetHttpHeaderFieldList(int requestId, out IntPtr field, out int length);
        [DllImport(Libraries.Download, EntryPoint = "download_get_downloaded_file_path")]
        internal static extern int GetDownloadedPath(int requestId, out string downloadedPath);
        [DllImport(Libraries.Download, EntryPoint = "download_get_mime_type")]
        internal static extern int GetMimeType(int requestId, out string mimeType);
        [DllImport(Libraries.Download, EntryPoint = "download_get_state")]
        internal static extern int GetState(int requestId, out int downloadState);
        [DllImport(Libraries.Download, EntryPoint = "download_get_content_name")]
        internal static extern int GetContentName(int requestId, out string contentName);
        [DllImport(Libraries.Download, EntryPoint = "download_get_content_size")]
        internal static extern int GetContentSize(int requestId, out ulong size);
        [DllImport(Libraries.Download, EntryPoint = "download_get_http_status")]
        internal static extern int GetHttpStatus(int requestId, out int httpStatus);
        [DllImport(Libraries.Download, EntryPoint = "download_get_etag")]
        internal static extern int GetETag(int requestId, out string etag);
        [DllImport(Libraries.Download, EntryPoint = "download_start")]
        internal static extern int StartDownload(int requestId);
        [DllImport(Libraries.Download, EntryPoint = "download_pause")]
        internal static extern int PauseDownload(int requestId);
        [DllImport(Libraries.Download, EntryPoint = "download_cancel")]
        internal static extern int CancelDownload(int requestId);
        [DllImport(Libraries.Download, EntryPoint = "download_set_state_changed_cb")]
        internal static extern int SetStateChangedCallback(int requestId, StateChangedCallback callback, IntPtr userData);
        [DllImport(Libraries.Download, EntryPoint = "download_unset_state_changed_cb")]
        internal static extern int UnsetStateChangedCallback(int requestId);
        [DllImport(Libraries.Download, EntryPoint = "download_set_progress_cb")]
        internal static extern int SetProgressCallback(int requestId, ProgressChangedCallback callback, IntPtr userData);
        [DllImport(Libraries.Download, EntryPoint = "download_unset_progress_cb")]
        internal static extern int UnsetProgressCallback(int requestId);

        // Notification class
        [DllImport(Libraries.Download, EntryPoint = "download_set_notification_title")]
        internal static extern int SetNotificationTitle(int requestId, string title);
        [DllImport(Libraries.Download, EntryPoint = "download_get_notification_title")]
        internal static extern int GetNotificationTitle(int requestId, out string title);
        [DllImport(Libraries.Download, EntryPoint = "download_set_notification_description")]
        internal static extern int SetNotificationDescription(int requestId, string description);
        [DllImport(Libraries.Download, EntryPoint = "download_get_notification_description")]
        internal static extern int GetNotificationDescription(int requestId, out string description);
        [DllImport(Libraries.Download, EntryPoint = "download_set_notification_type")]
        internal static extern int SetNotificationType(int requestId, int type);
        [DllImport(Libraries.Download, EntryPoint = "download_get_notification_type")]
        internal static extern int GetNotificationType(int requestId, out int type);
        [DllImport(Libraries.Download, EntryPoint = "download_set_notification_app_control")]
        internal static extern int SetNotificationAppControl(int requestId, int appControlType, SafeAppControlHandle handle);
        [DllImport(Libraries.Download, EntryPoint = "download_get_notification_app_control")]
        internal static extern int GetNotificationAppControl(int requestId, int appControlType, out SafeAppControlHandle handle);
    }
}
