/// Player
///
/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

 
using System;
using System.Threading.Tasks;

namespace Tizen.Multimedia
{
	static internal class PlayerLog
	{
		internal const string LogTag = "Tizen.Multimedia.Player";
	}

    /// <summary>
    /// The Player class provides APIs required for playback.
    /// </summary>
    /// <remarks>
    /// The Player APIs provides functions to create a player, set media filename/url
    /// and play the media content. It also provides APIs to adjust the configurations
    /// of the player such as playback rate, volume, looping etc. And, event handlers
    /// handles are provided to handle various playback events (like playback error/completion)
    /// </remarks>
    public class Player
    {
		private EventHandler<PlaybackCompletedEventArgs> _playbackCompleted;
		private Interop.Player.PlaybackCompletedCallback _playbackCompletedCallback;

		private EventHandler<PlaybackInterruptedEventArgs> _playbackInterrupted;
		private Interop.Player.PlaybackInterruptedCallback _playbackInterruptedCallback;

		private EventHandler<PlaybackErrorEventArgs> _playbackError;
		private Interop.Player.PlaybackErrorCallback _playbackErrorCallback;

		//TODO: Uncomment this after MediaPacket is implemented.
		//private EventHandler<VideoFrameDecodedEventArgs> _videoFrameDecoded;
		//private Interop.Player.VideoFrameDecodedCallback _videoFrameDecodedCallback;

		/// <summary>
        /// PlaybackCompleted event is raised when playback of a media is finished
        /// </summary>
        public event EventHandler<PlaybackCompletedEventArgs> PlaybackCompleted
		{
			add
			{
				if(_playbackCompleted == null) {
					RegisterPlaybackCompletedEvent();
				}
				_playbackCompleted += value;

			}
			remove
			{
				_playbackCompleted -= value;
				if(_playbackCompleted == null) {
					UnregisterPlaybackCompletedEvent();
				}
			}
		}

		private void RegisterPlaybackCompletedEvent()
		{
			_playbackCompletedCallback = (IntPtr userData) =>
				{
				PlaybackCompletedEventArgs eventArgs = new PlaybackCompletedEventArgs();
				_playbackCompleted.Invoke(this, eventArgs);
				};
			int ret = Interop.Player.SetCompletedCb(_playerHandle, _playbackCompletedCallback, IntPtr.Zero);
			if(ret != (int)PlayerError.None) 
			{
				Log.Error(PlayerLog.LogTag, "Setting PlaybackCompleted callback failed" + (PlayerError)ret);
				PlayerErrorFactory.ThrowException(ret, "Setting PlaybackCompleted callback failed"); 
			}
			
		}

		private void UnregisterPlaybackCompletedEvent()
		{
			int ret = Interop.Player.UnsetCompletedCb(_playerHandle);
			if(ret != (int)PlayerError.None) 
			{
				Log.Error(PlayerLog.LogTag, "Unsetting PlaybackCompleted callback failed" + (PlayerError)ret);
				PlayerErrorFactory.ThrowException(ret, "Unsetting PlaybackCompleted callback failed"); 
			}
			
		}

        /// <summary>
        /// PlaybackInterruped event is raised when playback of a media is interrupted
        /// </summary>
        public event EventHandler<PlaybackInterruptedEventArgs> PlaybackInterruped
		{
			add
			{
				if(_playbackInterrupted == null) {
					RegisterPlaybackInterruptedEvent();
				}
				_playbackInterrupted += value;
			}
			remove
			{
				_playbackInterrupted -= value;
				if(_playbackInterrupted == null) {
					UnregisterPlaybackInterruptedEvent();
				}
			}
		}

		private void RegisterPlaybackInterruptedEvent()
		{
			_playbackInterruptedCallback = (int code, IntPtr userData) =>
			{
				PlaybackInterruptedEventArgs eventArgs = new PlaybackInterruptedEventArgs(code);
				_playbackInterrupted.Invoke(this, eventArgs);
			};
			int ret = Interop.Player.SetInterruptedCb(_playerHandle, _playbackInterruptedCallback, IntPtr.Zero);
			if(ret != (int)PlayerError.None) 
			{
				Log.Error(PlayerLog.LogTag, "Setting PlaybackInterrupted callback failed" + (PlayerError)ret);
				PlayerErrorFactory.ThrowException(ret, "Setting PlaybackInterrupted callback failed"); 
			}
			
		}

		private void UnregisterPlaybackInterruptedEvent()
		{
			int ret = Interop.Player.UnsetInterruptedCb(_playerHandle);
			if(ret != (int)PlayerError.None) 
			{
				Log.Error(PlayerLog.LogTag, "Unsetting PlaybackInterrupted callback failed" + (PlayerError)ret);
				PlayerErrorFactory.ThrowException(ret, "Unsetting PlaybackInterrupted callback failed"); 
			}
		}

        /// <summary>
        /// PlaybackErrorOccured event is raised when any error occurs
        /// </summary>
        public event EventHandler<PlaybackErrorEventArgs> PlaybackErrorOccured
		{
			add
			{
				if(_playbackError == null) {
					RegisterPlaybackErrorEvent();
				}
				_playbackError += value;
			}
			remove
			{
				_playbackError -= value;
				if(_playbackError == null) {
					UnregisterPlaybackErrorEvent();
				}
			}
		}

		private void RegisterPlaybackErrorEvent()
		{
			_playbackErrorCallback = (int code, IntPtr userData) =>
			{
				PlaybackErrorEventArgs eventArgs = new PlaybackErrorEventArgs(code);
				_playbackError.Invoke(this, eventArgs);
			};
			int ret = Interop.Player.SetErrorCb(_playerHandle, _playbackErrorCallback, IntPtr.Zero);
			if(ret != (int)PlayerError.None) 
			{
				Log.Error(PlayerLog.LogTag, "Setting PlaybackError callback failed" + (PlayerError)ret);
				PlayerErrorFactory.ThrowException(ret, "Setting PlaybackError callback failed"); 
			}
			
		}

		private void UnregisterPlaybackErrorEvent()
		{
			int ret = Interop.Player.UnsetErrorCb(_playerHandle);
			if(ret != (int)PlayerError.None) 
			{
				Log.Error(PlayerLog.LogTag, "Unsetting PlaybackError callback failed" + (PlayerError)ret);
				PlayerErrorFactory.ThrowException(ret, "Unsetting PlaybackError callback failed"); 
			}
			
		}


		#if _MEDIA_PACKET_
		TODO: Uncomment this after MediaPacket is implemented.
        /// <summary>
        /// VideoFrameCaptured event is raised when a video frame is decoded
        /// </summary>
        public event EventHandler<VideoFrameDecodedEventArgs> VideoFrameDecoded
		{
			add
			{
				if(_videoFrameDecoded == null) {
					RegisterVideoFrameDecodedEvent();
				}
				_videoFrameDecoded += value;
			}
			remove
			{
				_videoFrameDecoded -= value;
				if(_videoFrameDecoded == null) {
					UnregisterVideoFrameDecodedEvent();
				}
			}
		}

		private void RegisterVideoFrameDecodedEvent()
		{
			_videoFrameDecoded = (MediaPacket packet, IntPtr userData) =>
			{
				VideoFrameDecodedEventArgs eventArgs = new VideoFrameDecodedEventArgs();
				_videoFrameDecoded.Invoke(this, eventArgs);
			};
			Interop.Player.SetErrorCb(_playerHandle, _videoFrameDecodedCallback, IntPtr.Zero);
		}

		private void UnregisterVideoFrameDecodedEvent()
		{
			Interop.Player.UnsetMediaPacketVideoFrameDecodedCb(_playerHandle);
		}
		#endif


        /// <summary>
        /// Get Player state.
        /// </summary>
        /// <value> PlayerState </value>
        public PlayerState State 
        {
            get
            {
				int state;
				int ret = Interop.Player.GetState(_playerHandle, out state);

				if(ret != (int)PlayerError.None) 
					PlayerErrorFactory.ThrowException(ret, "Get player state failed"); 

				return (PlayerState)state;
            }
        }

        /// <summary>
        /// Set/Get the left volume level.
        /// </summary>
        /// <value> 0 to 1.0 that indicates left volume level </value>
        public float LeftVolume 
		{
			set
			{
				int ret = Interop.Player.SetVolume(_playerHandle, value, _rightVolume);

				if(ret == (int)PlayerError.None) 
				{
					_leftVolume = value;
				}
				else 
				{
					Log.Error(PlayerLog.LogTag, "Set volume failed" + (PlayerError)ret);
					PlayerErrorFactory.ThrowException(ret, "set volume failed"); 
				}
			}
			get
			{
				//Interop.Player.GetVolume(_playerHandle, out _leftVolume, out _rightVolume);
				return _leftVolume;
			}
		}

        /// <summary>
        /// Set/Get the right volume level.
        /// </summary>
        /// <value> 0 to 1.0 that indicates right volume level </value>
        public float RightVolume 
		{
			set
			{
				int ret = Interop.Player.SetVolume(_playerHandle, _leftVolume, value);

				if(ret == (int)PlayerError.None) 
				{
					_rightVolume = value;
				}
				else 
				{
					Log.Error(PlayerLog.LogTag, "Set volume failed" + (PlayerError)ret);
					PlayerErrorFactory.ThrowException(ret, "set volume failed"); 
				}
			}
			get
			{
				//Interop.Player.GetVolume(_playerHandle, out _leftVolume, out _rightVolume);
				return _rightVolume;
			}
		}

        /// <summary>
        /// Set/Get the Audio Latency Mode.
        /// </summary>
        /// <value> Low, Mid, High </value>
        public AudioLatencyMode AudioLatencyMode 
		{ 
			set
			{
				if(_audioLatencyMode != (int)value) 
				{
					int ret = Interop.Player.SetAudioLatencyMode(_playerHandle, (int)value);
					if(ret != (int)PlayerError.None) 
					{
						Log.Error(PlayerLog.LogTag, "Set audio latency mode failed" + (PlayerError)ret);
						PlayerErrorFactory.ThrowException(ret, "set audio latency mode failed");
					} 
					else 
					{
						_audioLatencyMode = (int)value;
					}
				}
			}

			get 
			{ 
				return (AudioLatencyMode)_audioLatencyMode;
			}
		}

        /// <summary>
        /// Set/Get  mute.
        /// </summary>
        /// <value> true, false </value>
        public bool Mute 
		{ 
			set
			{
				if(_mute != value) 
				{
					int ret = Interop.Player.SetMute(_playerHandle, value);			
					if(ret != (int)PlayerError.None) 
					{
						Log.Error(PlayerLog.LogTag, "Set mute failed" + (PlayerError)ret);
						PlayerErrorFactory.ThrowException(ret, "set mute failed");
					} 
					else 
					{
						_mute = value;
					}
				}
			}
			get
			{
				//Interop.Player.IsMuted(_playerHandle, out _mute);
				return _mute;
			}
		}

        /// <summary>
        /// Set/Get Loop play.
        /// </summary>
        /// <value> true, false </value>
        public bool IsLooping 
		{ 
			set
			{
				if(_isLooping != value) 
				{
					int ret = Interop.Player.SetLooping(_playerHandle, value);
					if(ret != (int)PlayerError.None) 
					{
						Log.Error(PlayerLog.LogTag, "Set loop failed" + (PlayerError)ret);
						PlayerErrorFactory.ThrowException(ret, "set loop failed");
					} 
					else 
					{
						_isLooping = value;
					}
				}
			}
			get
			{
				//Interop.Player.IsLooping(_playerHandle, out _isLooping);
				return _isLooping;
			}
		}

        /// <summary>
        /// Set playback rate.
        /// </summary>
        /// <value> -5.0x to 5.0x </value>
        public float PlaybackRate 
        {
            set
            {
				int ret = Interop.Player.SetPlaybackRate(_playerHandle, value);
				if(ret != (int)PlayerError.None) 
				{
					Log.Error(PlayerLog.LogTag, "Set playback rate failed" + (PlayerError)ret);
					PlayerErrorFactory.ThrowException(ret, "set playback rate failed");
				}
            }
        }

        /// <summary>
        /// Get play position.
        /// </summary>
        /// <value> play position in milli seconds </value>
        public int PlayPosition 
        {
            get
            {
				int playPosition;
				int ret = Interop.Player.GetPlayPosition(_playerHandle, out playPosition);
				if(ret != (int)PlayerError.None) 
					Log.Error(PlayerLog.LogTag, "Failed to get play position, " + (PlayerError)ret);
				return playPosition;
            }
        }

        /// <summary>
        /// Set sound stream.
        /// </summary>
        /// <value> Sound stream </value>
        //public SoundStream SoundStream { set; }

        /// <summary>
        /// Set/Get Display.
        /// </summary>
        /// <value> Display configuration </value>
        public Display Display 
		{
			set
			{
				_display = value;
				_display._playerHandle = _playerHandle;
			}
			get
			{
				return _display;
			}
		}

        /// <summary>
        /// Set/Get Subtitle.
        /// </summary>
        /// <value> Subtitle configuration </value>
        public Subtitle Subtitle
		{
			set
			{
				_subtitle = value;
				_subtitle._playerHandle = _playerHandle;
				_subtitle.Path = _subtitle._path;
			}
			get
			{
				return _subtitle;
			}
		}


        /// <summary>
        /// Get AudioEffect.
        /// </summary>
        /// <value> AudioEffect object </value>
        public AudioEffect AudioEffect 
        {
            get 
            {
                return _audioEffect;
            }
        }

        /// <summary>
        /// Get stream information.
        /// </summary>
        /// <value> StreamInformation object </value>
        public StreamInformation StreamInformation 
        {
            get
            {
                return _streamInformation;
            }
        }

        /// <summary>
        /// Get StreamingConfiguration.
        /// </summary>
        /// <value> StreamingConfiguration object </value>
        public StreamingConfiguration StreamingConfiguration 
        {
            get
            {
                return _streamingConfiguration;
            }
        }

        /// <summary>
        /// Player constructor.</summary>
        public Player()
        {
			int ret;
			
			ret = Interop.Player.Create(out _playerHandle);
			if(ret != (int)PlayerError.None) 
			{
				Log.Error(PlayerLog.LogTag, "Failed to create player" + (PlayerError)ret);
				PlayerErrorFactory.ThrowException(ret, "Failed to create player"); 
			}

			// Initial get values
			Interop.Player.GetVolume(_playerHandle, out _leftVolume, out _rightVolume);
			Interop.Player.GetAudioLatencyMode(_playerHandle, out _audioLatencyMode);
			Interop.Player.IsMuted(_playerHandle, out _mute);
			Interop.Player.IsLooping(_playerHandle, out _isLooping);

			// AudioEffect
			_audioEffect = new AudioEffect();
			_audioEffect._playerHandle = _playerHandle;

			// Display
			_display = new Display(DisplayType.Evas /* Default value? */);
			_display._playerHandle = _playerHandle;


			// StreamingConfiguration
			_streamingConfiguration = new StreamingConfiguration(_playerHandle);

			// StreamInformation
			_streamInformation = new StreamInformation();
			_streamInformation._playerHandle = _playerHandle;
			_streamInformation._contentInfo = new PlayerContentInfo();
			_streamInformation._contentInfo._playerHandle = _playerHandle;

        }

        /// <summary>
        /// Player destructor
        /// </summary>
        ~Player()
        {
        }

        /// <summary>
        /// Prepares the media player for playback. </summary>
		public void PrepareAsync()
        {
			int ret;
			Task.Factory.StartNew(() => {
				Interop.Player.PrepareCallback cb = (IntPtr userData) => {
				}; 
				ret = Interop.Player.PrepareAsync(_playerHandle, cb, IntPtr.Zero); 
				if(ret != (int)PlayerError.None) 
				{
					Log.Error(PlayerLog.LogTag, "Failed to prepare player" + (PlayerError)ret);
					PlayerErrorFactory.ThrowException(ret, "Failed to prepare player"); 
				}
			});
		}

        /// <summary>
        /// The most recently used media is reset and no longer associated with the player. Playback is no longer possible. 
        /// If you want to use the player again, you will have to set the data URI and call prepare() again. </summary>
        public void Unrepare()
        {
			int ret = Interop.Player.Unprepare(_playerHandle);
			if(ret != (int)PlayerError.None) 
			{
				Log.Error(PlayerLog.LogTag, "Failed to unprepare player" +(PlayerError)ret);
				PlayerErrorFactory.ThrowException(ret, "Failed to unprepare player"); 
			}
        }

        /// <summary>
        /// Starts or resumes playback.  </summary>
        public void Start()
        {
			int ret = Interop.Player.Start(_playerHandle);
			if( ret != (int)PlayerError.None) 
			{
				Log.Error(PlayerLog.LogTag, "Failed to start player" + (PlayerError)ret);
				PlayerErrorFactory.ThrowException(ret, "Failed to start player"); 
			}
        }

        /// <summary>
        /// Stops playing media content. </summary>
        public void Stop()
        {
			int ret = Interop.Player.Stop(_playerHandle);
			if( ret != (int)PlayerError.None) 
			{
				Log.Error(PlayerLog.LogTag, "Failed to stop player" + (PlayerError)ret);
				PlayerErrorFactory.ThrowException(ret, "Failed to stop player"); 
			}
        }

        /// <summary>
        /// Pauses the player. </summary>
        public void Pause()
        {
			int ret = Interop.Player.Pause(_playerHandle);
			if(ret != (int)PlayerError.None) 
			{
				Log.Error(PlayerLog.LogTag, "Failed to pause player" + (PlayerError)ret);
				PlayerErrorFactory.ThrowException(ret, "Failed to pause player"); 
			}
        }

		/// <summary>
		/// sets media source for the player. </summary>
		/// <param name="source"> Mediasource </param>
		public void SetSource(MediaSource source)
		{
			int ret;
			if(source.GetType() == typeof(MediaUriSource)) 
			{
				ret = Interop.Player.SetUri(_playerHandle, ((MediaUriSource)source)._uri);
				if(ret != (int)PlayerError.None) 
				{
					Log.Error(PlayerLog.LogTag, "Failed to seturi" + (PlayerError)ret);
					PlayerErrorFactory.ThrowException(ret, "Failed to set uri"); 
				}
			} 
			else if(source.GetType() == typeof(MediaBufferSource)) 
			{
				//if(Interop.Player.SetMemoryBuffer(_playerHandle, ((MediaBufferSource)source)._buffer, ((MediaBufferSource)source)._buffer.Length) != 0) {
					// throw Exception
				//}
			}
			// TODO: Handle MediaStream source after implementing MediaPacket module
		}


        /// <summary>
        /// Captures a video frame asynchronously. </summary>
        public Task<VideoFrameCapture> CaptureVideoAsync()
        {
			return Task.Factory.StartNew(() => CaptureVideoAsyncTask()).Result;
        }

		internal Task<VideoFrameCapture> CaptureVideoAsyncTask()
		{
			TaskCompletionSource<VideoFrameCapture> t = new TaskCompletionSource<VideoFrameCapture> ();
			Interop.Player.VideoCaptureCallback  cb = (byte[] data, int width, int height, uint size, IntPtr userData) => {
				VideoFrameCapture v = new VideoFrameCapture(data, width, height, size);
				t.SetResult(v);
			};

			int ret = Interop.Player.CaptureVideo(_playerHandle, cb, IntPtr.Zero);
			if(ret != (int)PlayerError.None) 
			{
				Log.Error(PlayerLog.LogTag, "Failed to capture video" + (PlayerError)ret);
				PlayerErrorFactory.ThrowException(ret, "Failed to capture video"); 
			}
			return t.Task;
		}

        /// <summary>
        ///Sets the seek position for playback, asynchronously.  </summary>
        /// <param name="milliseconds"> Position to be set in milliseconds</param>
        /// <param name="accurate"> accurate seek or not</param>
        public void SetPlayPositionAsync(int milliseconds, bool accurate)
        {
			Task.Factory.StartNew(() => {
				Interop.Player.SeekCompletedCallback cb = (IntPtr userData) => {
				}; 
				int ret = Interop.Player.SetPlayPosition(_playerHandle, milliseconds, accurate, cb, IntPtr.Zero);
				if(ret != (int)PlayerError.None) 
				{
					Log.Error(PlayerLog.LogTag, "Failed to set playposition" + (PlayerError)ret);
					PlayerErrorFactory.ThrowException(ret, "Failed to set playposition"); 
				}
			});

        }


        internal PlayerState _state;
		internal float _leftVolume;
		internal float _rightVolume;
		internal int _audioLatencyMode;
		internal bool _mute;
		internal bool _isLooping;
		//internal AudioType _audioType;

		internal Display _display;
		internal Subtitle _subtitle;
        internal AudioEffect _audioEffect;
        internal StreamInformation _streamInformation;
        internal StreamingConfiguration _streamingConfiguration;

		internal IntPtr _playerHandle;
    }
}
