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

namespace Tizen.Content.Download
{
    /// <summary>
    /// Enumeration for download state.
    /// </summary>
    public enum DownloadState
    {
        /// <summary>
        /// Unhandled exception
        /// </summary>
        None = 0,
        /// <summary>
        /// Ready to download
        /// </summary>
        Ready,
        /// <summary>
        /// Queued to start downloading
        /// </summary>
        Queued,
        /// <summary>
        /// Currently downloading
        /// </summary>
        Downloading,
        /// <summary>
        /// Download is paused and can be resumed
        /// </summary>
        Paused,
        /// <summary>
        /// The download is completed
        /// </summary>
        Completed,
        /// <summary>
        /// The download failed
        /// </summary>
        Failed,
        /// <summary>
        /// User canceled the download request
        /// </summary>
        Canceled
    }

    /// <summary>
    /// Enumeration for network type.
    /// </summary>
    public enum NetworkType
    {
        /// <summary>
        /// Download is available through data network
        /// </summary>
        DataNetwork = 0,
        /// <summary>
        /// Download is available through WiFi
        /// </summary>
        Wifi,
        /// <summary>
        /// Download is available through WiFi-Direct
        /// </summary>
        WifiDirect,
        /// <summary>
        /// Download is available through either data network or WiFi
        /// </summary>
        All
    }

    /// <summary>
    /// Enumeration for notification type.
    /// </summary>
    public enum NotificationType
    {
        /// <summary>
        /// Do not register notification
        /// </summary>
        None = 0,
        /// <summary>
        /// Completion notification for success state and failed state
        /// </summary>
        CompleteOnly,
        /// <summary>
        /// All download notifications for ongoing state, success state and failed state
        /// </summary>
        All
    }

    internal enum NotificationAppControlType
    {
        Downloading = 0,
        Completed,
        Failed
    }

    internal static class Globals
    {
        internal const string LogTag = "Tizen.Content.Download";
    }
}
