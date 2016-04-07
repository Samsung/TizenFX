using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tizen.Applications;

namespace Tizen.Content.Download
{
    /// <summary>
    /// The Request class provides functions to create and manage one or more download requests.
    /// </summary>
    public class Request : IDisposable
    {
        /// <summary>
        /// Creates a Request object.
        /// </summary>
        /// <param name="url"> URL to download</param>
        public Request(string url)
        {
        }

        /// <summary>
        /// Creates a Request object.
        /// </summary>
        /// <param name="url"> URL to download</param>
        /// <param name="destinationPath"> Directory path where downloaded file is stored </param>
        /// <param name="fileName"> Name of the downloaded file </param>
        /// <param name="type"> Network type which the download request must adhere to </param>
        public Request(string url, string destinationPath, string fileName, NetworkType type)
        {
        }

        /// <summary>
        /// Creates a Request object.
        /// </summary>
        /// <param name="url"> URL to download</param>
        /// <param name="destinationPath"> Directory path where downloaded file is stored </param>
        /// <param name="fileName"> Name of the downloaded file </param>
        /// <param name="type"> Network type which the download request must adhere to </param>
        /// <param name-"httpHeaders"> HTTP header fields for download request </param>
        public Request(string url, string destinationPath, string fileName, NetworkType type, Dictionary<string, string> httpHeaders)
        {
        }

        /// <summary>
        /// Event that occurs when the download state changes.
        /// </summary>
        public event EventHandler<StateChangedEventArgs> StateChanged
        {
        }

        /// <summary>
        /// Event that occurs when the download progress changes.
        /// </summary>
        public event EventHandler<ProgressChangedEventArgs> ProgressChanged
        {
        }

        /// <summary>
        /// Absolute path to save the downloaded file.
        /// If you try to get this property value before calling Start(), an empty string is returned.
        /// </summary>
        public string DownloadedPath
        {
            get
            {
            }
        }

        /// <summary>
        /// MIME type of the downloaded content.
        /// If you try to get this property value before calling Start(), an empty string is returned.
        /// </summary>
        public string MimeType
        {
            get
            {
            }
        }

        /// <summary>
        /// Current state of the download.
        /// </summary>
        public DownloadState State
        {
            get
            {
            }
        }

        /// <summary>
        /// Content name of the downloaded file.
        /// This can be defined with reference of HTTP response header data. The content name can be received when HTTP response header is received.
        /// If you try to get this property value before calling Start(), an empty string is returned.
        /// </summary>
        public string ContentName
        {
            get
            {
            }
        }

        /// <summary>
        /// Total size of downloaded content.
        /// This information is received from the server. If the server does not send the total size of the content, content_size is set to zero.
        /// If you try to get this property value before calling Start(), 0 is returned.
        /// </summary>
        public ulong ContentSize
        {
            get
            {
            }
        }

        /// <summary>
        /// HTTP status code when a download exception occurs.
        /// If you try to get this property value before calling Start(), -1 is returned.
        /// </summary>
        public int HttpStatus
        {
            get
            {
            }
        }

        /// <summary>
        /// ETag value from the HTTP response header when making a HTTP request for resume.
        /// If you try to get this property value before calling Start(), an empty string is returned.
        /// </summary>
        /// <remarks>
        /// The etag value is available or not depending on the web server. If not available, then on get of the property null is returned.
        /// After download is started, it can get the etag value.
        /// </remarks>
        public string ETagValue
        {
            get
            {
            }
        }

        /// <summary>
        /// Contains properties required for creating download notifications.
        /// </summary>
        /// <remarks>
        /// When the notification message is clicked, the action to take is decided by the app control.
        /// If the app control is not set, the following default operation is executed when the notification message is clicked:
        ///  1) download completed state - the viewer application is executed according to extension name of downloaded content,
        ///  2) download failed state and ongoing state - the client application is executed.
        /// Should be set before calling Start().
        /// </remarks>
        public Notification NotificationProperties
        {
            get
            {
            }
        }

        /// <summary>
        /// URL to download.
        /// </summary>
        /// <remarks>
        /// Should be set before calling Start().
        /// If you try to get this property value before setting, an empty string is returned.
        /// </remarks>
        public string Url
        {
            get
            {
            }
            set
            {
            }
        }

        /// <summary>
        /// Allowed network type for downloading the file.
        /// The file will be downloaded only under the allowed network.
        /// If you try to get this property value before setting, default value NetworkType All is returned.
        /// </summary>
        /// <remarks>
        /// Should be set before calling Start().
        /// </remarks>
        public NetworkType AllowedNetworkType
        {
            get
            {
            }
            set
            {
            }
        }

        /// <summary>
        /// The file will be downloaded to the set destination file path. The downloaded file is saved to an auto-generated file name in the destination. If the destination is not specified, the file will be downloaded to default storage.
        /// If you try to get this property value before setting, an empty string is returned.
        /// </summary>
        /// <remarks>
        /// Should be set before calling Start().
        /// </remarks>
        public string DestinationPath
        {
            get
            {
            }
            set
            {
            }
        }

        /// <summary>
        /// The file will be saved in the specified destination or default storage with the set file name. If the file name is not specified, the downloaded file will be saved with an auto-generated file name in the destination.
        /// If you try to get this property value before setting, an empty string is returned.
        /// </summary>
        /// <remarks>
        /// Should be set before calling Start().
        /// </remarks>
        public string FileName
        {
            get
            {
            }
            set
            {
            }
        }

        /// <summary>
        /// Enables or disables auto download.
        /// If this option is enabled, the previous downloading item is restarted automatically as soon as the download daemon is restarted. The download progress continues after the client process is terminated.
        /// If you try to get this property value before setting, default value false is returned.
        /// </summary>
        /// <remarks>
        /// The default value is false.
        /// </remarks>
        public bool AutoDownload
        {
            get
            {
            }
            set
            {
            }
        }

        /// <summary>
        /// Directory path of the temporary file used in the previous download request.
        /// This is only useful when resuming download to make HTTP request header at the client side. Otherwise, the path is ignored.
        /// If you try to get this property value before setting, an empty string is returned.
        /// </summary>
        /// <remarks>
        /// If the etag value is not present in the download database, it is not useful to set the temporary file path.
        /// When resuming download request, the data is attached at the end of this temporary file.
        /// </remarks>
        public string TempFilePath
        {
            get
            {
            }
            set
            {
            }
        }

        /// <summary>
        /// HTTP header field and value pairs to the download request.
        /// HTTP header <field,value> pair is the <key,value> pair in the Dictionary HttpHeaders
        /// The given HTTP header field will be included with the HTTP request of the download request.
        /// If you try to get this property value before setting, an empty dictionary is returned.
        /// </summary>
        /// <remarks>
        /// HTTP header fields should be set before calling Start().
        /// HTTP header fields can be removed before calling Start().
        /// </remarks>
        public Dictionary<string, string> HttpHeaders
        {
            get
            {
            }
            set
            {
            }
        }

        /// <summary>
        /// Starts or resumes download.
        /// Starts to download the current URL, or resumes the download if paused.
        /// </summary>
        /// <remarks>
        /// The URL is the mandatory information to start the download.
        /// </remarks>
        public void Start()
        {
        }

        /// <summary>
        /// Pauses download request.
        /// </summary>
        /// <remarks>
        /// The paused download request can be restarted with Start() or canceled with Cancel().
        /// </remarks>
        public void Pause()
        {
        }

        /// <summary>
        /// Cancels download request.
        /// </summary>
        /// <remarks>
        /// The canceled download can be restarted with Start().
        /// </remarks>
        public void Cancel()
        {
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed download state type.
    /// </summary>
    public class StateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Present download state.
        /// </summary>
        public DownloadState state
        {
            get
            {
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains size of received data in bytes.
    /// </summary>
    public class ProgressChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Received data size in bytes.
        /// </summary>
        public ulong receivedDataSize
        {
            get
            {
            }
        }
    }
}

