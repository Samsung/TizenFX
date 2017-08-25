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
    /// Enumeration for the download states.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum DownloadState
    {
        /// <summary>
        /// Unhandled exception.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        None = 0,
        /// <summary>
        /// Ready to download.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Ready,
        /// <summary>
        /// Queued to start downloading.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Queued,
        /// <summary>
        /// Currently downloading.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Downloading,
        /// <summary>
        /// The download is paused and can be resumed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Paused,
        /// <summary>
        /// The download is completed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Completed,
        /// <summary>
        /// The download failed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Failed,
        /// <summary>
        /// A user canceled the download request.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Canceled
    }

    /// <summary>
    /// Enumeration for the network types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum NetworkType
    {
        /// <summary>
        /// The download is available through data network.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        DataNetwork = 0,
        /// <summary>
        /// The download is available through Wi-Fi.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Wifi,
        /// <summary>
        /// The download is available through Wi-Fi Direct.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        WifiDirect,
        /// <summary>
        /// The download is available either through data network or Wi-Fi.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        All
    }

    /// <summary>
    /// Enumeration for the notification types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum NotificationType
    {
        /// <summary>
        /// Do not register notification.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        None = 0,
        /// <summary>
        /// Completion notification for success state and failed state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        CompleteOnly,
        /// <summary>
        /// All download notifications for ongoing state, success state, and failed state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
