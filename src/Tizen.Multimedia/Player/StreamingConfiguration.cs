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
		internal IntPtr _playerHandle;
		internal string _cookie;
		internal string _userAgent;
		internal string _progressiveDownloadPath;
		private EventHandler<BufferingProgressEventArgs> _bufferingProgress;
		private Interop.Player.BufferingProgressCallback _bufferingProgressCallback;
		private EventHandler<ProgressiveDownloadMessageEventArgs> _pdMessage;
		private Interop.Player.ProgressiveDownloadMessageCallback _pdMessageCallback;
		private EventHandler<VideoStreamEventArgs> _videoStreamChanged;
		private Interop.Player.VideoStreamChangedCallback _videoStreamChangedCallback;


		internal StreamingConfiguration(IntPtr handle)
		{
			_playerHandle = handle;
		}


		/// <summary>
        /// BufferingProgressChanged event is raised when there is a change in the buffering status of a media stream
        /// </summary>
        public event EventHandler<BufferingProgressEventArgs> BufferingProgressChanged
		{
			add
			{
				if(_bufferingProgress == null) {
					RegisterBufferingProgressEvent();
				}
				_bufferingProgress += value;
			}
			remove
			{
				_bufferingProgress -= value;
				if(_bufferingProgress == null) {
					UnregisterBufferingProgressEvent();
				}
			}
		}

        /// <summary>
        /// ProgressiveDownloadMessageChanged event is raised when progressive download is started or completed. 
        /// </summary>
        public event EventHandler<ProgressiveDownloadMessageEventArgs> ProgressiveDownloadMessageChanged
		{
			add
			{
				if(_pdMessage == null) {
					RegisterProgressiveDownloadMessageEvent();
				}
				_pdMessage += value;
			}
			remove
			{
				_pdMessage -= value;
				if(_pdMessage == null) {
					UnregisterProgressiveDownloadMessageEvent();
				}
			}
		}

        /// <summary>
        /// Video stream changed event is raised to notify the video stream changed. 
        /// </summary>
        public event EventHandler<VideoStreamEventArgs> VideoStreamChanged
		{
			add
			{
				if(_videoStreamChanged == null) {
					RegisterVideoStreamChangedEvent();
				}
				_videoStreamChanged += value;
			}
			remove
			{
				_videoStreamChanged -= value;
				if(_videoStreamChanged == null) {
					UnregisterVideoStreamChanged();
				}
			}
		}

        /// <summary>
        /// Set/Get Progressive download path.
        /// </summary>
        /// <value> path string </value>
        public string ProgressiveDownloadPath 
		{ 
			set
			{
				int ret = Interop.Player.SetProgressiveDownloadPath(_playerHandle, value);
				if(ret != (int)PlayerError.None) 
				{
					Log.Error(PlayerLog.LogTag, "Setting progressive download path failed" + (PlayerError)ret);
					PlayerErrorFactory.ThrowException(ret, "Setting progressive download path failed"); 
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
				DownloadProgress progress = null;
				int start, current;
				int ret = Interop.Player.GetStreamingDownloadProgress(_playerHandle, out start, out current);
				if(ret == (int)PlayerError.None) 
				{
					progress = new DownloadProgress(start, current);
				}
				else
				{
					Log.Error(PlayerLog.LogTag, "Getting download progress failed" + (PlayerError)ret);
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
				ProgressiveDownloadStatus status = null; 
				ulong current, totalSize;
				int ret = Interop.Player.GetProgressiveDownloadStatus(_playerHandle, out current, out totalSize);
				if(ret == (int)PlayerError.None) 
				{
					status = new ProgressiveDownloadStatus(current, totalSize);
				}
				else
				{
					Log.Error(PlayerLog.LogTag, "Getting progressive download status failed" + (PlayerError)ret);
				}

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
				int ret = Interop.Player.SetStreamingCookie(_playerHandle, value, value.Length + 1);
				if(ret != (int)PlayerError.None) 
				{
					Log.Error(PlayerLog.LogTag, "Setting cookie failed" + (PlayerError)ret);
					PlayerErrorFactory.ThrowException(ret, "Setting cookie failed"); 
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
				int ret = Interop.Player.SetStreamingUserAgent(_playerHandle, value, value.Length + 1);
				if(ret != (int)PlayerError.None) 
				{
					Log.Error(PlayerLog.LogTag, "Setting user agent failed" + (PlayerError)ret);
					PlayerErrorFactory.ThrowException(ret, "Setting user agent failed"); 
				}
				_userAgent = value;
			}
			get
			{
				return _userAgent;
			}
		}


		private void RegisterBufferingProgressEvent()
		{
			_bufferingProgressCallback = (int percent, IntPtr userData) =>
			{
				BufferingProgressEventArgs eventArgs = new BufferingProgressEventArgs(percent);
				_bufferingProgress?.Invoke(this, eventArgs);
			};

			int ret = Interop.Player.SetBufferingCb(_playerHandle, _bufferingProgressCallback, IntPtr.Zero);
			if(ret != (int)PlayerError.None) 
			{
				Log.Error(PlayerLog.LogTag, "Setting Buffering callback failed" + (PlayerError)ret);
				PlayerErrorFactory.ThrowException(ret, "Setting Buffering callback failed"); 
			}

		}

		private void UnregisterBufferingProgressEvent()
		{
			int ret = Interop.Player.UnsetBufferingCb(_playerHandle);
			if(ret != (int)PlayerError.None) 
			{
				Log.Error(PlayerLog.LogTag, "Unsetting Buffering callback failed" + (PlayerError)ret);
				PlayerErrorFactory.ThrowException(ret, "Unsetting Buffering callback failed"); 
			}

		}
		private void RegisterProgressiveDownloadMessageEvent()
		{
			_pdMessageCallback = (int type, IntPtr userData) =>
			{
				ProgressiveDownloadMessageEventArgs eventArgs = new ProgressiveDownloadMessageEventArgs((ProgressiveDownloadMessage)type);
				_pdMessage?.Invoke(this, eventArgs);
			};
			int ret = Interop.Player.SetProgressiveDownloadMessageCb(_playerHandle, _pdMessageCallback, IntPtr.Zero);
			if(ret != (int)PlayerError.None) 
			{
				Log.Error(PlayerLog.LogTag, "Setting progressive download callback failed" + (PlayerError)ret);
				PlayerErrorFactory.ThrowException(ret, "Setting progressive download callback failed"); 
			}
		}

		private void UnregisterProgressiveDownloadMessageEvent()
		{
			int ret = Interop.Player.UnsetProgressiveDownloadMessageCb(_playerHandle);
			if(ret != (int)PlayerError.None) 
			{
				Log.Error(PlayerLog.LogTag, "Unsetting progressive download callback failed" + (PlayerError)ret);
				PlayerErrorFactory.ThrowException(ret, "Unsetting progressive download callback failed"); 
			}

		}

		private void RegisterVideoStreamChangedEvent()
		{
			_videoStreamChangedCallback = (int width, int height, int fps, int bitrate, IntPtr userData) =>
			{
				VideoStreamEventArgs eventArgs = new VideoStreamEventArgs(height, width, fps, bitrate);
				_videoStreamChanged?.Invoke(this, eventArgs);
			};
			int ret = Interop.Player.SetVideoStreamChangedCb(_playerHandle, _videoStreamChangedCallback, IntPtr.Zero);
			if(ret != (int)PlayerError.None) 
			{
				Log.Error(PlayerLog.LogTag, "Setting video stream changed callback failed" + (PlayerError)ret);
				PlayerErrorFactory.ThrowException(ret, "Setting video stream changed callback failed"); 
			}
		}

		private void UnregisterVideoStreamChanged()
		{
			int ret = Interop.Player.UnsetVideoStreamChangedCb(_playerHandle);
			if(ret != (int)PlayerError.None) 
			{
				Log.Error(PlayerLog.LogTag, "Unsetting video stream changed callback failed" + (PlayerError)ret);
				PlayerErrorFactory.ThrowException(ret, "Unsetting video stream changed callback failed"); 
			}
		}
    }
}
