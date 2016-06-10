/// Media Stream configuration
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
    /// MediaStream configuration
    /// </summary>
    /// <remarks>
    /// MediaStreamConfiguration class for media stream configuration.
    /// </remarks>

    public class MediaStreamConfiguration
    {
		internal IntPtr _playerHandle;
		internal StreamType _streamType;
		#if _MEDIA_FORMAT_
		TODO: Uncomment this when MediaFormat is implemented.
		private EventHandler<BufferStatusEventArgs> _bufferStatusChanged;
		private Interop.Player.BufferStatusCallback _bufferStatusChangedCallback;
		private EventHandler<SeekOffsetEventArgs> _seekOffsetChanged;
		private Interop.Player.SeekOffsetChangedCallback _seekOffsetChangedCallback;
		#endif

		internal MediaStreamConfiguration()
		{
		}

		#if _MEDIA_FORMAT_
		TODO: Uncomment this when MediaFormat is implemented.
        /// <summary>
        /// BufferStatusChanged event is raised when buffer underrun or overflow occurs. 
        /// </summary>
        public event EventHandler<BufferStatusEventArgs> BufferStatusChanged
		{
			add
			{
				if(_bufferStatusChanged == null) {
					RegisterBufferStatusEvent();
				}
				_bufferStatusChanged += value;
			}
			remove
			{
				_bufferStatusChanged -= value;
				if(_bufferStatusChanged == null) {
					UnregisterBufferStatusEvent();
				}
			}
		}

        /// <summary>
        /// SeekOffsetChanged event is raised when seeking occurs. 
        /// </summary>
        public event EventHandler<SeekOffsetEventArgs> SeekOffsetChanged
		{
			add
			{
				if(_seekOffsetChanged == null) {
					RegisterSeekOffsetChangedEvent();
				}
				_seekOffsetChanged += value;
			}
			remove
			{
				_seekOffsetChanged -= value;
				if(_seekOffsetChanged == null) {
					UnregisterSeekOffsetChangedEvent();
				}
			}
		}
		#endif

        /// <summary>
        /// max size bytes of buffer </summary>
        /// <value> Max size in bytes </value>
        public ulong BufferMaxSize 
		{ 
			set
			{ 
				int ret = Interop.Player.SetMediaStreamBufferMaxSize(_playerHandle, (int)_streamType, value);
				if(ret != (int)PlayerError.None) 
				{
					Log.Error(PlayerLog.LogTag, "Set Buffer Max size failed" + (PlayerError)ret);
					PlayerErrorFactory.ThrowException(ret, "Set Buffer Max size failed");
				}

			} 
			get
			{ 
				ulong size;
				int ret = Interop.Player.GetMediaStreamBufferMaxSize(_playerHandle, (int)_streamType, out size);
				if(ret != (int)PlayerError.None) 
				{
					Log.Error(PlayerLog.LogTag, "Set Buffer Max size failed" + (PlayerError)ret);
				}
				return size;
			}
		}

        /// <summary>
        /// Min threshold </summary>
        /// <value> min threshold in percent </value>
        public uint BufferMinThreshold 
		{ 
			set
			{
				int ret = Interop.Player.SetMediaStreamBufferMinThreshold(_playerHandle, (int)_streamType, value);
				if(ret != (int)PlayerError.None) 
				{
					Log.Error(PlayerLog.LogTag, "Set Buffer Min threshold failed" + (PlayerError)ret);
					PlayerErrorFactory.ThrowException(ret, "Set Buffer Min threshold failed");
				}

			}
			get
			{
				uint percent;
				int ret = Interop.Player.GetMediaStreamBufferMinThreshold(_playerHandle, (int)_streamType, out percent);
				if(ret != (int)PlayerError.None) 
				{
					Log.Error(PlayerLog.LogTag, "Get Buffer Min threshold failed" + (PlayerError)ret);
				}
				return percent;
			}
		}

		internal void SetHandle(IntPtr handle)
		{
			_playerHandle = handle;
		}

		#if _MEDIA_FORMAT_
		TODO: Uncomment this when MediaFormat is implemented.
		private void RegisterBufferStatusEvent()
		{
			_bufferStatusChangedCallback = (int status, IntPtr userData) =>
			{
				BufferStatusEventArgs eventArgs = new BufferStatusEventArgs();
				_bufferStatusChanged?.Invoke(this, eventArgs);
			};
			Interop.Player.SetMediaStreamBufferStatusCb(_playerHandle, _bufferStatusChangedCallback, IntPtr.Zero);
		}

		private void UnregisterBufferStatusEvent()
		{
			Interop.Player.UnsetMediaStreamBufferStatusCb(_playerHandle);
		}

		private void RegisterSeekOffsetChangedEvent()
		{
			_seekOffsetChangedCallback = (UInt64 offset, IntPtr userData) =>
			{
				SeekOffsetEventArgs eventArgs = new SeekOffsetEventArgs();
				_seekOffsetChanged?.Invoke(this, eventArgs);
			};
			Interop.Player.SetMediaStreamSeekCb(_playerHandle, _seekOffsetChangedCallback, IntPtr.Zero);
		}

		private void UnregisterSeekOffsetChangedEvent()
		{
			Interop.Player.UnsetMediaStreamSeekCb(_playerHandle);
		}
		#endif

    }
}
