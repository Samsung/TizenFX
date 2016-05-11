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
        /// <summary>
        /// PlaybackCompleted event is raised when playback of a media is finished
        /// </summary>
        public event EventHandler<PlaybackCompletedEventArgs> PlaybackCompleted;

        /// <summary>
        /// PlaybackInterruped event is raised when playback of a media is interrupted
        /// </summary>
        public event EventHandler<PlaybackInterruptedEventArgs> PlaybackInterruped;

        /// <summary>
        /// PlaybackErrorOccured event is raised when any error occurs
        /// </summary>
        public event EventHandler<PlaybackErrorEventArgs> PlaybackErrorOccured;

        /// <summary>
        /// VideoFrameCaptured event is raised when a video frame is decoded
        /// </summary>
        public event EventHandler<VideoFrameDecodedEventArgs> VideoFrameDecoded;

        /// <summary>
        /// Get Player state.
        /// </summary>
        /// <value> PlayerState </value>
        public PlayerState State 
        {
            get
            {
				int state;
				if (Interop.PlayerInterop.GetState (_playerHandle, out state) != 0) {
					//throw Exception;
				}
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
				if (Interop.PlayerInterop.SetVolume (_playerHandle, value, _rightVolume) == 0)
					_leftVolume = value;
				//else
				//	throw Exception;
			}
			get
			{
				//Interop.PlayerInterop.GetVolume (_playerHandle, out _leftVolume, out _rightVolume);
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
				if ( Interop.PlayerInterop.SetVolume (_playerHandle, _leftVolume, value) == 0 )
					_rightVolume = value;
				//else
				//	throw Exception;
			}
			get
			{
				//Interop.PlayerInterop.GetVolume (_playerHandle, out _leftVolume, out _rightVolume);
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
				if (_audioLatencyMode != (int)value && Interop.PlayerInterop.SetAudioLatencyMode (_playerHandle, (int)value) == 0)
					_audioLatencyMode = (int) value;
				//else
				//	throw Exception;
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
				if (_mute != value && Interop.PlayerInterop.SetMute (_playerHandle, value) == 0)
					_mute = value;
				//else
				//	throw Exception;
			}
			get
			{
				//Interop.PlayerInterop.IsMuted (_playerHandle, out _mute);
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
				if (_isLooping != value && Interop.PlayerInterop.SetLooping (_playerHandle, value) == 0)
					_isLooping = value;
				//else
				//	throw Exception;
			}
			get
			{
				//Interop.PlayerInterop.IsLooping (_playerHandle, out _isLooping);
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
				if (Interop.PlayerInterop.SetPlaybackRate (_playerHandle, value) != 0) {
					//throw Exception;
				}
            }
        }

        /// <summary>
        /// Set/Get sound type.
        /// </summary>
        /// <value> System, Notification, Alarm, Ringtone, Media, Call, Voip, Voice </value>
        public SoundType PlayerSoundType 
		{
			set
			{
				if (_soundType != value && Interop.PlayerInterop.SetSoundType (_playerHandle, (int)value) != 0)
					_soundType = value;
				//else
				//	throw Exception;
			}
			get
			{
				return _soundType;
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
				if (Interop.PlayerInterop.GetPlayPosition (_playerHandle, out playPosition) != 0) {
					//throw Exception;
				}
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
			// Throw exception on error returns?
			Interop.PlayerInterop.Create (out _playerHandle);

			// Initial get values
			Interop.PlayerInterop.GetVolume (_playerHandle, out _leftVolume, out _rightVolume);
			Interop.PlayerInterop.GetAudioLatencyMode (_playerHandle, out _audioLatencyMode);
			Interop.PlayerInterop.IsMuted (_playerHandle, out _mute);
			Interop.PlayerInterop.IsLooping (_playerHandle, out _isLooping);


			// AudioEffect
			_audioEffect = new AudioEffect();
			_audioEffect._playerHandle = _playerHandle;

			// Display
			_display = new Display(DisplayType.Evas /* Default value? */);
			_display._playerHandle = _playerHandle;


			// StreamingConfiguration
			_streamingConfiguration = new StreamingConfiguration();
			_streamingConfiguration._playerHandle = _playerHandle;

			// StreamInformation
			_streamInformation = new StreamInformation ();
			_streamInformation._playerHandle = _playerHandle;
			_streamInformation._contentInfo = new PlayerContentInfo ();
			_streamInformation._contentInfo._playerHandle = _playerHandle;

			// Subtitle
			_subtitle = new Subtitle();
			_subtitle._playerHandle = _playerHandle;

        }

        /// <summary>
        /// Player destructor
        /// </summary>
        ~Player()
        {
        }

        /// <summary>
        /// Prepares the media player for playback. </summary>
		/// TODO: make async
		public /*Task<void>*/void PrepareAsync()
        {
			if ((Interop.PlayerInterop.Prepare (_playerHandle)) != 0) {
				//throw Exception;
			}
        }

        /// <summary>
        /// The most recently used media is reset and no longer associated with the player. Playback is no longer possible. 
        /// If you want to use the player again, you will have to set the data URI and call prepare() again. </summary>
        public void Unrepare()
        {
			if (Interop.PlayerInterop.Unprepare (_playerHandle) != 0) {
				//throw Exception;
			}
        }

        /// <summary>
        /// Starts or resumes playback.  </summary>
        public void Start()
        {
			if (Interop.PlayerInterop.Start (_playerHandle) != 0) {
				//throw Exception;
			}
        }

        /// <summary>
        /// Stops playing media content. </summary>
        public void Stop()
        {
			if (Interop.PlayerInterop.Stop (_playerHandle) != 0) {
				//throw Exception;
			}
        }

        /// <summary>
        /// Pauses the player. </summary>
        public void Pause()
        {
			if (Interop.PlayerInterop.Pause (_playerHandle) != 0) {
				//throw Exception;
			}
        }

		/// <summary>
		/// sets media source for the player. </summary>
		/// <param name="source"> Mediasource </param>
		/// TODO: implement memory buffer and packet stream
		public void SetSource(MediaSource source)
		{
			if (source.GetType() == typeof(MediaUriSource)) {
				if ( Interop.PlayerInterop.SetUri (_playerHandle, ((MediaUriSource)source)._uri) != 0) {
					// throw Exception
				}
			}
		}


        /// <summary>
        /// Captures a video frame asynchronously. </summary>
        Task<VideoFrameCapture> CaptureVideoAsync()
        {
          return null;
        }

        /// <summary>
        ///Sets the seek position for playback, asynchronously.  </summary>
        /// <param name="milliseconds"> Position to be set in milliseconds</param>
        /// <param name="accurate"> accurate seek or not</param>
        //public Task<void> SetPlayPositionAsync(int milliseconds, bool accurate)
        //{
        //}


        internal PlayerState _state;
		internal float _leftVolume;
		internal float _rightVolume;
		internal int _audioLatencyMode;
		internal bool _mute;
		internal bool _isLooping;
		internal SoundType _soundType;

		internal Display _display;
		internal Subtitle _subtitle;
        internal AudioEffect _audioEffect;
        internal StreamInformation _streamInformation;
        internal StreamingConfiguration _streamingConfiguration;

		internal IntPtr _playerHandle;
    }
}
