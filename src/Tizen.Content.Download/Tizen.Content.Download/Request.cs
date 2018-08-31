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
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tizen.Content.Download
{
    /// <summary>
    /// The Request class provides the functions to create and manage a single download request.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Request : IDisposable
    {
        private int _downloadId;
        private Notification _notificationProperties;
        private IDictionary<string, string> _httpHeaders;
        private EventHandler<StateChangedEventArgs> _downloadStateChanged;
        private Interop.Download.StateChangedCallback _downloadStateChangedCallback;
        private EventHandler<ProgressChangedEventArgs> _downloadProgressChanged;
        private Interop.Download.ProgressChangedCallback _downloadProgressChangedCallback;
        private bool _disposed = false;

        /// <summary>
        /// Creates a Request object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="url">The URL to download.</param>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        public Request(string url)
        {
            if (String.IsNullOrEmpty(url))
            {
                DownloadErrorFactory.ThrowException((int)DownloadError.InvalidParameter, "url cannot be null or empty");
            }
            int ret = Interop.Download.CreateRequest(out _downloadId);
            if (ret != (int)DownloadError.None)
            {
                DownloadErrorFactory.ThrowException(ret, "Request creation failed");
            }
            ret = Interop.Download.SetUrl(_downloadId, url);
            if (ret != (int)DownloadError.None)
            {
                DownloadErrorFactory.ThrowException(ret, "Setting Url failed");
            }
            _notificationProperties = new Notification(_downloadId);
            _httpHeaders = new Dictionary<string, string>();
        }

        /// <summary>
        /// Creates a Request object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="url">The URL to download</param>
        /// <param name="destinationPath">The directory path where downloaded file is stored.</param>
        /// <param name="fileName">The name of the downloaded file.</param>
        /// <param name="type">The network type which the download request must adhere to.</param>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <feature>http://tizen.org/feature/network.wifi.direct</feature>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when a feature is not supported.</exception>
        public Request(string url, string destinationPath, string fileName, NetworkType type)
        {
            if (String.IsNullOrEmpty(url))
            {
                DownloadErrorFactory.ThrowException((int)DownloadError.InvalidParameter, "url cannot be null or empty");
            }
            int ret = Interop.Download.CreateRequest(out _downloadId);
            if (ret != (int)DownloadError.None)
            {
                DownloadErrorFactory.ThrowException(ret, "Request creation failed");
            }

            ret = Interop.Download.SetUrl(_downloadId, url);
            if (ret != (int)DownloadError.None)
            {
                DownloadErrorFactory.ThrowException(ret, "Setting Url failed");
            }

            ret = Interop.Download.SetDestination(_downloadId, destinationPath);
            if (ret != (int)DownloadError.None)
            {
                DownloadErrorFactory.ThrowException(ret, "Setting DestinationPath failed");
            }

            ret = Interop.Download.SetFileName(_downloadId, fileName);
            if (ret != (int)DownloadError.None)
            {
                DownloadErrorFactory.ThrowException(ret, "Setting FileName failed");
            }

            ret = Interop.Download.SetNetworkType(_downloadId, (int)type);
            if (ret != (int)DownloadError.None)
            {
                DownloadErrorFactory.ThrowException(ret, "Setting NetworkType failed");
            }

            _notificationProperties = new Notification(_downloadId);
            _httpHeaders = new Dictionary<string, string>();
        }

        /// <summary>
        /// Creates a Request object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="url">The URL to download.</param>
        /// <param name="destinationPath">The directory path where the downloaded file is stored.</param>
        /// <param name="fileName">The name of the downloaded file.</param>
        /// <param name="type">The network type which the download request must adhere to.</param>
        /// <param name="httpHeaders">HTTP header fields for the download request.</param>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <feature>http://tizen.org/feature/network.wifi.direct</feature>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when a feature is not supported.</exception>
        public Request(string url, string destinationPath, string fileName, NetworkType type, IDictionary<string, string> httpHeaders)
        {
            if (String.IsNullOrEmpty(url))
            {
                DownloadErrorFactory.ThrowException((int)DownloadError.InvalidParameter, "url cannot be null or empty");
            }
            int ret = Interop.Download.CreateRequest(out _downloadId);
            if (ret != (int)DownloadError.None)
            {
                DownloadErrorFactory.ThrowException(ret, "Request creation failed");
            }

            ret = Interop.Download.SetUrl(_downloadId, url);
            if (ret != (int)DownloadError.None)
            {
                DownloadErrorFactory.ThrowException(ret, "Setting Url failed");
            }

            ret = Interop.Download.SetDestination(_downloadId, destinationPath);
            if (ret != (int)DownloadError.None)
            {
                DownloadErrorFactory.ThrowException(ret, "Setting DestinationPath failed");
            }

            ret = Interop.Download.SetFileName(_downloadId, fileName);
            if (ret != (int)DownloadError.None)
            {
                DownloadErrorFactory.ThrowException(ret, "Setting FileName failed");
            }

            ret = Interop.Download.SetNetworkType(_downloadId, (int)type);
            if (ret != (int)DownloadError.None)
            {
                DownloadErrorFactory.ThrowException(ret, "Setting NetworkType failed");
            }

            _notificationProperties = new Notification(_downloadId);
            _httpHeaders = httpHeaders;
        }

        /// <summary>
        /// Destructor of the Request class.
        /// </summary>
        ~Request()
        {
            Dispose(false);
        }

        /// <summary>
        /// An event that occurs when the download state changes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        public event EventHandler<StateChangedEventArgs> StateChanged
        {
            add
            {
                if (_downloadStateChanged == null)
                {
                    RegisterStateChangedEvent();
                }
                _downloadStateChanged += value;
            }
            remove
            {
                _downloadStateChanged -= value;
                if (_downloadStateChanged == null)
                {
                    UnregisterStateChangedEvent();
                }
            }
        }

        /// <summary>
        /// An event that occurs when the download progress changes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        public event EventHandler<ProgressChangedEventArgs> ProgressChanged
        {
            add
            {
                if (_downloadProgressChanged == null)
                {
                    RegisterProgressChangedEvent();
                }
                _downloadProgressChanged += value;
            }
            remove
            {
                _downloadProgressChanged -= value;
                if (_downloadProgressChanged == null)
                {
                    UnregisterProgressChangedEvent();
                }
            }
        }

        /// <summary>
        /// The absolute path where the file will be downloaded.
        /// If you try to get this property value before calling Start(), an empty string is returned.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <remarks>
        /// Returns an empty string if the download is not completed or if a state has not yet changed to completed or if any other error occurs.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        public string DownloadedPath
        {
            get
            {
                string path;
                int ret = Interop.Download.GetDownloadedPath(_downloadId, out path);
                if (ret != (int)DownloadError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get DownloadedPath, " + (DownloadError)ret);
                    return String.Empty;
                }
                return path;
            }
        }

        /// <summary>
        /// The MIME type of the downloaded content.
        /// If you try to get this property value before calling Start(), an empty string is returned.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        public string MimeType
        {
            get
            {
                string mime;
                int ret = Interop.Download.GetMimeType(_downloadId, out mime);
                if (ret != (int)DownloadError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get MimeType, " + (DownloadError)ret);
                    return String.Empty;
                }
                return mime;
            }
        }

        /// <summary>
        /// The current state of the download.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        public DownloadState State
        {
            get
            {
                int state;
                int ret = Interop.Download.GetState(_downloadId, out state);
                if (ret != (int)DownloadError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get DownloadState, " + (DownloadError)ret);
                    return DownloadState.None;
                }
                return (DownloadState)state;
            }
        }

        /// <summary>
        /// The content name of the downloaded file.
        /// This can be defined with reference of the HTTP response header data. The content name can be received when the HTTP response header is received.
        /// If you try to get this property value before calling Start(), an empty string is returned.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        public string ContentName
        {
            get
            {
                string name;
                int ret = Interop.Download.GetContentName(_downloadId, out name);
                if (ret != (int)DownloadError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get ContentName, " + (DownloadError)ret);
                    return String.Empty;
                }
                return name;
            }
        }

        /// <summary>
        /// The total size of the downloaded content.
        /// This information is received from the server. If the server does not send the total size of the content, the content size is set to zero.
        /// If you try to get this property value before calling Start(), 0 is returned.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        public ulong ContentSize
        {
            get
            {
                ulong size;
                int ret = Interop.Download.GetContentSize(_downloadId, out size);
                if (ret != (int)DownloadError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get ContentSize, " + (DownloadError)ret);
                    return 0;
                }
                return size;
            }
        }

        /// <summary>
        /// The HTTP status code when a download exception occurs.
        /// If you try to get this property value before calling Start(), 0 is returned.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <remarks>
        /// The state of the download request must be DownlodState.Failed.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        public int HttpStatus
        {
            get
            {
                int status;
                int ret = Interop.Download.GetHttpStatus(_downloadId, out status);
                if (ret != (int)DownloadError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get HttpStatus, " + (DownloadError)ret);
                    return 0;
                }
                return status;
            }
        }

        /// <summary>
        /// The ETag value from the HTTP response header when making a HTTP request for resume.
        /// If you try to get this property value before calling Start() or if any other error occurs, an empty string is returned.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <remarks>
        /// The ETag value is either available or not dependent on the web server. If not available, then, on getting the property, a null value is returned.
        /// After the download is started, it can get the ETag value.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        public string ETagValue
        {
            get
            {
                string etag;
                int ret = Interop.Download.GetETag(_downloadId, out etag);
                if (ret != (int)DownloadError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get ETagValue, " + (DownloadError)ret);
                    return String.Empty;
                }
                return etag;
            }
        }

        /// <summary>
        /// Contains properties required for creating download notifications.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// When the notification message is clicked, the action taken by the system is decided by the application control properties of the NotificationProperties instance.
        /// If the app control is not set, the following default operation is executed when the notification message is clicked:
        ///  1) The download completed state - the viewer application is executed according to the extension name of the downloaded content.
        ///  2) The download failed state and ongoing state - the client application is executed.
        /// This property should be set before calling Start().
        /// </remarks>
        public Notification NotificationProperties
        {
            get
            {
                return _notificationProperties;
            }
        }

        /// <summary>
        /// The full path of the temporary file stores the downloaded content.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <remarks>
        /// The download state must be one of the states after downloading.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        public string TemporaryPath
        {
            get
            {
                string path;
                int ret = Interop.Download.GetTempFilePath(_downloadId, out path);
                if (ret != (int)DownloadError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get TemporaryPath, " + (DownloadError)ret);
                    return String.Empty;
                }
                return path;
            }
        }

        /// <summary>
        /// The URL to download.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <remarks>
        /// Should be set before calling Start().
        /// If you try to get this property value before setting or if any other error occurs, an empty string is returned.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        public string Url
        {
            get
            {
                string url;
                int ret = Interop.Download.GetUrl(_downloadId, out url);
                if (ret != (int)DownloadError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get Url, " + (DownloadError)ret);
                    return String.Empty;
                }
                return url;
            }
            set
            {
                int ret = Interop.Download.SetUrl(_downloadId, value);
                if (ret != (int)DownloadError.None)
                {
                    DownloadErrorFactory.ThrowException(ret, "Failed to set Url");
                }
            }
        }

        /// <summary>
        /// The allowed network type for downloading the file.
        /// The file will be downloaded only under the allowed network.
        /// If you try to get this property value before setting or if any other error occurs, the default value NetworkType All is returned.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <feature>http://tizen.org/feature/network.wifi.direct</feature>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <remarks>
        /// Should be set before calling Start().
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported.</exception>
        public NetworkType AllowedNetworkType
        {
            get
            {
                int type;
                int ret = Interop.Download.GetNetworkType(_downloadId, out type);
                if (ret != (int)DownloadError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get AllowedNetworkType, " + (DownloadError)ret);
                    return NetworkType.All;
                }
                return (NetworkType)type;
            }
            set
            {
                int ret = Interop.Download.SetNetworkType(_downloadId, (int)value);
                if (ret != (int)DownloadError.None)
                {
                    DownloadErrorFactory.ThrowException(ret, "Failed to set AllowedNetworkType");
                }
            }
        }

        /// <summary>
        /// The file will be downloaded to the set the destination file path. The downloaded file is saved to an auto-generated file name in the destination. If the destination is not specified, the file will be downloaded to the default storage.
        /// If you try to get this property value before setting or if any other error occurs, an empty string is returned.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <remarks>
        /// Should be set before calling Start().
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        public string DestinationPath
        {
            get
            {
                string path;
                int ret = Interop.Download.GetDestination(_downloadId, out path);
                if (ret != (int)DownloadError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get DestinationPath, " + (DownloadError)ret);
                    return String.Empty;
                }
                return path;
            }
            set
            {
                int ret = Interop.Download.SetDestination(_downloadId, value);
                if (ret != (int)DownloadError.None)
                {
                    DownloadErrorFactory.ThrowException(ret, "Failed to set DestinationPath");
                }
            }
        }

        /// <summary>
        /// The file will be saved in the specified destination or the default storage with the set file name. If the file name is not specified, the downloaded file will be saved with an auto-generated file name in the destination.
        /// If you try to get this property value before setting or if any other error occurs, an empty string is returned.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <remarks>
        /// Should be set before calling Start().
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        public string FileName
        {
            get
            {
                string name;
                int ret = Interop.Download.GetFileName(_downloadId, out name);
                if (ret != (int)DownloadError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get FileName, " + (DownloadError)ret);
                    return String.Empty;
                }
                return name;
            }
            set
            {
                int ret = Interop.Download.SetFileName(_downloadId, value);
                if (ret != (int)DownloadError.None)
                {
                    DownloadErrorFactory.ThrowException(ret, "Failed to set FileName");
                }
            }
        }

        /// <summary>
        /// Enables or disables auto download.
        /// If this option is enabled, the previous downloading item is restarted automatically as soon as the download daemon is restarted. The download progress continues after the client process is terminated.
        /// If you try to get this property value before setting, the default value false is returned.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <remarks>
        /// The default value is false.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        public bool AutoDownload
        {
            get
            {
                bool value;
                int ret = Interop.Download.GetAutoDownload(_downloadId, out value);
                if (ret != (int)DownloadError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get AutoDownload, " + (DownloadError)ret);
                    return false;
                }
                return value;
            }
            set
            {
                int ret = Interop.Download.SetAutoDownload(_downloadId, value);
                if (ret != (int)DownloadError.None)
                {
                    DownloadErrorFactory.ThrowException(ret, "Failed to set AutoDownload");
                }
            }
        }

        /// <summary>
        /// The HTTP header field and value pairs to the download request.
        /// The HTTP header &lt;field,value&gt; pair is the &lt;key,value&gt; pair in the dictionary HttpHeaders.
        /// The given HTTP header field will be included with the HTTP request of the download request.
        /// If you try to get this property value before setting, an empty dictionary is returned.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// HTTP header fields should be set before calling Start().
        /// HTTP header fields can be removed before calling Start().
        /// </remarks>
        public IDictionary<string, string> HttpHeaders
        {
            get
            {
                return _httpHeaders;
            }
        }

        /// <summary>
        /// Sets the directory path of a temporary file used in a previous download request.
        /// This is only useful when resuming download to make the HTTP request header at the client side. Otherwise, the path is ignored.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <remarks>
        /// If the ETag value is not present in the download database, it is not useful to set the temporary file path.
        /// When resuming the download request, the data is attached at the end of this temporary file.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        public void SetTemporaryFilePath(string path)
        {
                int ret = Interop.Download.SetTempFilePath(_downloadId, path);
                if (ret != (int)DownloadError.None)
                {
                    DownloadErrorFactory.ThrowException(ret, "Failed to set TemporaryFilePath");
                }
        }

        /// <summary>
        /// Starts or resumes the download.
        /// Starts to download the current URL, or resumes the download if paused.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <remarks>
        /// The URL is the mandatory information to start the download.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        public void Start()
        {
            int ret;
            foreach (KeyValuePair<string, string> entry in _httpHeaders)
            {
                ret = Interop.Download.AddHttpHeaderField(_downloadId, entry.Key, entry.Value);
                if (ret != (int)DownloadError.None)
                {
                    DownloadErrorFactory.ThrowException(ret, "Failed to set HttpHeaders");
                }
            }

            ret = Interop.Download.StartDownload(_downloadId);
            if (ret != (int)DownloadError.None)
            {
                DownloadErrorFactory.ThrowException(ret, "Failed to start download request");
            }
        }

        /// <summary>
        /// Pauses the download request.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <remarks>
        /// The paused download request can be restarted with Start() or canceled with Cancel().
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        public void Pause()
        {
            int ret = Interop.Download.PauseDownload(_downloadId);
            if (ret != (int)DownloadError.None)
            {
                DownloadErrorFactory.ThrowException(ret, "Failed to pause download request");
            }
        }

        /// <summary>
        /// Cancels the download request.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <remarks>
        /// The canceled download can be restarted with Start().
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        public void Cancel()
        {
            int ret = Interop.Download.CancelDownload(_downloadId);
            if (ret != (int)DownloadError.None)
            {
                DownloadErrorFactory.ThrowException(ret, "Failed to cancel download request");
            }
        }

        /// <summary>
        /// Releases all the resources used by the Request class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <remarks>
        /// After calling this method, the download request related data exists in the download database for a certain period of time. Within that time, it is possible to use other APIs with this data.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Deletes the corresponding download request.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Free managed objects.
            }
            Interop.Download.DestroyRequest(_downloadId);
            _disposed = true;
        }

        private void RegisterStateChangedEvent()
        {
            _downloadStateChangedCallback = (int downloadId, int downloadState, IntPtr userData) =>
            {
                StateChangedEventArgs eventArgs = new StateChangedEventArgs((DownloadState)downloadState);
                _downloadStateChanged?.Invoke(this, eventArgs);
            };

            int ret = Interop.Download.SetStateChangedCallback(_downloadId, _downloadStateChangedCallback, IntPtr.Zero);
            if (ret != (int)DownloadError.None)
            {
                DownloadErrorFactory.ThrowException(ret, "Setting StateChanged callback failed");
            }
        }

        private void UnregisterStateChangedEvent()
        {
            int ret = Interop.Download.UnsetStateChangedCallback(_downloadId);
            if (ret != (int)DownloadError.None)
            {
                DownloadErrorFactory.ThrowException(ret, "Unsetting StateChanged callback failed");
            }
        }

        private void RegisterProgressChangedEvent()
        {
            _downloadProgressChangedCallback = (int downloadId, ulong size, IntPtr userData) =>
            {
                ProgressChangedEventArgs eventArgs = new ProgressChangedEventArgs(size);
                _downloadProgressChanged?.Invoke(this, eventArgs);
            };

            int ret = Interop.Download.SetProgressCallback(_downloadId, _downloadProgressChangedCallback, IntPtr.Zero);
            if (ret != (int)DownloadError.None)
            {
                DownloadErrorFactory.ThrowException(ret, "Setting ProgressChanged callback failed");
            }
        }

        private void UnregisterProgressChangedEvent()
        {
            int ret = Interop.Download.UnsetProgressCallback(_downloadId);
            if (ret != (int)DownloadError.None)
            {
                DownloadErrorFactory.ThrowException(ret, "Unsetting ProgressChanged callback failed");
            }
        }
    }
}

