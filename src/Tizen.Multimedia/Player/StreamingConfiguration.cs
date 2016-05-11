/// Streaming configuration
///
/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

 
using System;


namespace Tizen.Multimedia
{
    /// <summary>
    /// Streaming configuration
    /// </summary>
    /// <remarks>
    /// This class provides properties and API that are required for streaming
    /// playback operations.
    /// </remarks>
    public class StreamingConfiguration
    {
        /// <summary>
        /// BufferingProgressChanged event is raised when there is a change in the buffering status of a media stream
        /// </summary>
        public event EventHandler<BufferingProgressEventArgs> BufferingProgressChanged;

        /// <summary>
        /// ProgressiveDownloadMessageChanged event is raised when progressive download is started or completed. 
        /// </summary>
        public event EventHandler<ProgressiveDownloadMessageEventArgs> ProgressiveDownloadMessageChanged;

        /// <summary>
        /// Video stream changed event is raised to notify the video stream changed. 
        /// </summary>
        public event EventHandler<VideoStreamEventArgs> VideoStreamChanged;


        /// <summary>
        /// Set/Get Progressive download path.
        /// </summary>
        /// <value> path string </value>
        public string ProgressiveDownloadPath 
		{ 
			set
			{
				if (Interop.PlayerInterop.SetProgressiveDownloadPath (_playerHandle, value) != 0) {
					// throw Exception
				}
				_progressiveDownloadPath = value;
			}
			get
			{
				return _progressiveDownloadPath;
			}
		}

        /// <summary>
        /// Get Streaming download Progress.
        /// </summary>
        /// <value> download progress int start and current [0 to 100] </value>
        public DownloadProgress DownloadProgress 
        {
            get
            {
				DownloadProgress progress = new DownloadProgress();
				if (Interop.PlayerInterop.GetStreamingDownloadProgress (_playerHandle, out progress.Start, out progress.Current) != 0) {
					// throw Exception;
				}
				return progress;
            }
        }

        /// <summary>
        /// Get progressive download status.
        /// </summary>
        /// <value> progressive download status ulong current and total size </value>
        public ProgressiveDownloadStatus ProgressiveDownloadStatus 
        {
            get
            {
				ProgressiveDownloadStatus status = new ProgressiveDownloadStatus ();
				// TODO: interop
				return status;
            }
        }

        /// <summary>
        /// Set/Get cookie.
        /// </summary>
        /// <value> cookie string </value>
        public string Cookie 
		{
			set
			{
				if (Interop.PlayerInterop.SetStreamingCookie (_playerHandle, value, value.Length + 1) != 0) {
					// throw Exception
				}
				_cookie = value;
			}
			get
			{
				return _cookie;
			}
		}

        /// <summary>
        /// Set/Get User agent.
        /// </summary>
        /// <value> user agent string </value>
        public string UserAgent 
		{
			set
			{
				if (Interop.PlayerInterop.SetStreamingUserAgent (_playerHandle, value, value.Length + 1) != 0) {
					// throw Exception
				}
				_userAgent = value;
			}
			get
			{
				return _userAgent;
			}
		}


		internal IntPtr _playerHandle;

		internal string _cookie;
		internal string _userAgent;
		internal string _progressiveDownloadPath;
    }

}
