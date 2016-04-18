using System;

namespace Tizen.Content.Download
{
    /// <summary>
    /// Enumeration for download state.
    /// </summary>
    public enum DownloadState
    {
        /// <summary>
        /// Unhandled exception
        /// <summary>
        None = 0,
        /// <summary>
        /// Ready to download
        /// <summary>
        Ready,
        /// <summary>
        /// Queued to start downloading
        /// <summary>
        Queued,
        /// <summary>
        /// Currently downloading
        /// <summary>
        Downloading,
        /// <summary>
        /// Download is paused and can be resumed
        /// <summary>
        Paused,
        /// <summary>
        /// The download is completed
        /// <summary>
        Completed,
        /// <summary>
        /// The download failed
        /// <summary>
        Failed,
        /// <summary>
        /// User canceled the download request
        /// <summary>
        Canceled
    }

    /// <summary>
    /// Enumeration for network type.
    /// </summary>
    public enum NetworkType
    {
        /// <summary>
        /// Download is available through data network
        /// <summary>
        DataNetwork = 0,
        /// <summary>
        /// Download is available through WiFi
        /// <summary>
        Wifi,
        /// <summary>
        /// Download is available through WiFi-Direct
        /// <summary>
        WifiDirect,
        /// <summary>
        /// Download is available through either data network or WiFi
        /// <summary>
        All
    }

    /// <summary>
    /// Enumeration for notification type.
    /// </summary>
    public enum NotificationType
    {
        /// <summary>
        /// Do not register notification
        /// <summary>
        None = 0,
        /// <summary>
        /// Completion notification for success state and failed state
        /// <summary>
        CompleteOnly,
        /// <summary>
        /// All download notifications for ongoing state, success state and failed state
        /// <summary>
        All
    }

    internal enum NotificationAppControlType
    {
        Downloading = 0,
        Completed,
        Failed
    }
    static internal class Downloads
    {
        internal const string LogTag = "Tizen.Content.Download";
    }
}
