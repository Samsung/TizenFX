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
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Threading;
using static Interop;

namespace Tizen.Multimedia
{
    static internal class PlayerLog
    {
        internal const string Tag = "Tizen.Multimedia.Player";
        internal const string Enter = "[ENTER]";
        internal const string Leave = "[LEAVE]";
    }

    /// <summary>
    /// Provides the ability to control media playback.
    /// </summary>
    /// <remarks>
    /// The Player provides functions to play a media content.
    /// It also provides functions to adjust the configurations of the player such as playback rate, volume, looping etc.
    /// Note that only one video player can be played at one time.
    /// </remarks>
    public class Player : IDisposable, IDisplayable<PlayerErrorCode>
    {
        private PlayerHandle _handle;

        /// <summary>
        /// Occurs when playback of a media is finished.
        /// </summary>
        public event EventHandler<EventArgs> PlaybackCompleted;
        private NativePlayer.PlaybackCompletedCallback _playbackCompletedCallback;

        /// <summary>
        /// Occurs when playback of a media is interrupted.
        /// </summary>
        public event EventHandler<PlaybackInterruptedEventArgs> PlaybackInterrupted;
        private NativePlayer.PlaybackInterruptedCallback _playbackInterruptedCallback;

        /// <summary>
        /// Occurs when any error occurs.
        /// </summary>
        /// <remarks>The event handler will be executed on an internal thread.</remarks>
        public event EventHandler<PlayerErrorOccurredEventArgs> ErrorOccurred;
        private NativePlayer.PlaybackErrorCallback _playbackErrorCallback;

        /// <summary>
        /// Occurs when the video stream changed.
        /// </summary>
        /// <remarks>The event handler will be executed on an internal thread.</remarks>
        public event EventHandler<VideoStreamChangedEventArgs> VideoStreamChanged;
        private NativePlayer.VideoStreamChangedCallback _videoStreamChangedCallback;

        /// <summary>
        /// Occurs when the subtitle is updated.
        /// </summary>
        /// <remarks>The event handler will be executed on an internal thread.</remarks>
        public EventHandler<SubtitleUpdatedEventArgs> SubtitleUpdated;
        private NativePlayer.SubtitleUpdatedCallback _subtitleUpdatedCallback;

        /// <summary>
        /// Occurs when there is a change in the buffering status of streaming.
        /// </summary>
        public event EventHandler<BufferingProgressChangedEventArgs> BufferingProgressChanged;
        private NativePlayer.BufferingProgressCallback _bufferingProgressCallback;

        internal event EventHandler<MediaStreamBufferStatusChangedEventArgs> MediaStreamAudioBufferStatusChanged;
        private NativePlayer.MediaStreamBufferStatusCallback _mediaStreamAudioBufferStatusChangedCallback;

        internal event EventHandler<MediaStreamBufferStatusChangedEventArgs> MediaStreamVideoBufferStatusChanged;
        private NativePlayer.MediaStreamBufferStatusCallback _mediaStreamVideoBufferStatusChangedCallback;

        internal event EventHandler<MediaStreamSeekingOccurredEventArgs> MediaStreamAudioSeekingOccurred;
        private NativePlayer.MediaStreamSeekCallback _mediaStreamAudioSeekCallback;

        internal event EventHandler<MediaStreamSeekingOccurredEventArgs> MediaStreamVideoSeekingOccurred;
        private NativePlayer.MediaStreamSeekCallback _mediaStreamVideoSeekCallback;

        /// <summary>
        /// Initialize a new instance of the Player class.
        /// </summary>
        public Player()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);

            NativePlayer.Create(out _handle).ThrowIfFailed("Failed to create player");

            Debug.Assert(_handle != null);

            RetrieveProperties();

            if (Features.IsSupported(Features.AudioEffect))
            {
                _audioEffect = new AudioEffect(this);
            }

            if (Features.IsSupported(Features.RawVideo))
            {
                RegisterVideoFrameDecodedCallback();
            }
        }

        private void RetrieveProperties()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);

            NativePlayer.GetAudioLatencyMode(Handle, out _audioLatencyMode).
                ThrowIfFailed("Failed to initialize the player");

            NativePlayer.IsLooping(Handle, out _isLooping).ThrowIfFailed("Failed to initialize the player");

            Log.Debug(PlayerLog.Tag, PlayerLog.Leave);
        }

        private bool _callbackRegistered;

        private void RegisterCallbacks()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);

            if (_callbackRegistered)
            {
                return;
            }
            RegisterSubtitleUpdatedCallback();
            RegisterErrorOccurredCallback();
            RegisterPlaybackInterruptedCallback();
            RegisterVideoStreamChangedCallback();
            RegisterBufferingCallback();
            RegisterMediaStreamBufferStatusCallback();
            RegisterMediaStreamSeekCallback();
            RegisterPlaybackCompletedCallback();

            _callbackRegistered = true;
        }

        /// <summary>
        /// Gets the native handle of the player.
        /// </summary>
        /// <value>An IntPtr that contains the native handle of the player.</value>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        public IntPtr Handle
        {
            get
            {
                ValidateNotDisposed();
                return _handle.DangerousGetHandle();
            }
        }

        internal void ValidatePlayerState(params PlayerState[] desiredStates)
        {
            Debug.Assert(desiredStates.Length > 0);

            ValidateNotDisposed();

            var curState = State;
            if (curState.IsAnyOf(desiredStates))
            {
                return;
            }

            throw new InvalidOperationException($"The player is not in a valid state. " +
                $"Current State : { curState }, Valid State : { string.Join(", ", desiredStates) }.");
        }

        #region Properties
        #region Network configuration
        private string _cookie = "";
        private string _userAgent = "";

        /// <summary>
        /// Gets or Sets the cookie for streaming playback.
        /// </summary>
        /// <remarks>To set, the player must be in the <see cref="PlayerState.Idle"/> state.</remarks>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="ArgumentNullException">The value to set is null.</exception>
        public string Cookie
        {
            get
            {
                Log.Info(PlayerLog.Tag, "get cookie : " + _cookie);
                return _cookie;
            }
            set
            {
                Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
                ValidatePlayerState(PlayerState.Idle);

                if (value == null)
                {
                    Log.Error(PlayerLog.Tag, "cookie can't be null");
                    throw new ArgumentNullException(nameof(value), "Cookie can't be null.");
                }

                NativePlayer.SetStreamingCookie(Handle, value, value.Length).
                    ThrowIfFailed("Failed to set the cookie to the player");

                _cookie = value;
                Log.Debug(PlayerLog.Tag, PlayerLog.Leave);
            }
        }

        /// <summary>
        /// Gets or Sets the user agent for streaming playback.
        /// </summary>
        /// <remarks>To set, the player must be in the <see cref="PlayerState.Idle"/> state.</remarks>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="ArgumentNullException">The value to set is null.</exception>
        public string UserAgent
        {
            get
            {
                Log.Info(PlayerLog.Tag, "get useragent : " + _userAgent);
                return _userAgent;
            }
            set
            {
                Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
                ValidatePlayerState(PlayerState.Idle);

                if (value == null)
                {
                    Log.Error(PlayerLog.Tag, "UserAgent can't be null");
                    throw new ArgumentNullException(nameof(value), "UserAgent can't be null.");
                }

                NativePlayer.SetStreamingUserAgent(Handle, value, value.Length).
                    ThrowIfFailed("Failed to set the user agent to the player");

                _userAgent = value;
                Log.Debug(PlayerLog.Tag, PlayerLog.Leave);
            }
        }
        #endregion

        /// <summary>
        /// Gets the state of the player.
        /// </summary>
        /// <value>The current state of the player.</value>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        public PlayerState State
        {
            get
            {
                ValidateNotDisposed();

                if (IsPreparing())
                {
                    return PlayerState.Preparing;
                }

                int state = 0;
                NativePlayer.GetState(Handle, out state).ThrowIfFailed("Failed to retrieve the state of the player");

                Debug.Assert(Enum.IsDefined(typeof(PlayerState), state));

                return (PlayerState)state;
            }
        }

        private AudioLatencyMode _audioLatencyMode;

        /// <summary>
        /// Gets or sets the audio latency mode.
        /// </summary>
        /// <value>A <see cref="AudioLatencyMode"/> that specifies the mode. The default is <see cref="AudioLatencyMode.Mid"/>.</value>
        /// <remarks>
        /// If the mode is <see cref="AudioLatencyMode.High"/>,
        /// audio output interval can be increased so, it can keep more audio data to play.
        /// But, state transition like pause or resume can be more slower than default(<see cref="AudioLatencyMode.Mid"/>).
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="ArgumentException">The value is not valid.</exception>
        public AudioLatencyMode AudioLatencyMode
        {
            get
            {
                Log.Info(PlayerLog.Tag, "get audio latency mode : " + _audioLatencyMode);
                return _audioLatencyMode;
            }
            set
            {
                Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
                ValidateNotDisposed();

                if (_audioLatencyMode == value)
                {
                    return;
                }
                ValidationUtil.ValidateEnum(typeof(AudioLatencyMode), value);

                NativePlayer.SetAudioLatencyMode(Handle, value).
                    ThrowIfFailed("Failed to set the audio latency mode of the player");

                _audioLatencyMode = value;
            }
        }

        private bool _isLooping;

        /// <summary>
        /// Gets or sets the looping state.
        /// </summary>
        /// <value>true if the playback is looping; otherwise, false. The default value is false.</value>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        public bool IsLooping
        {
            get
            {
                Log.Info(PlayerLog.Tag, "get looping : " + _isLooping);
                return _isLooping;
            }
            set
            {
                Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
                ValidateNotDisposed();

                if (_isLooping == value)
                {
                    return;
                }

                NativePlayer.SetLooping(Handle, value).ThrowIfFailed("Failed to set the looping state of the player");

                _isLooping = value;
            }
        }

        #region Display methods
        /// <summary>
        /// Gets the display settings.
        /// </summary>
        /// <value>A <see cref="PlayerDisplaySettings"/> that specifies the display settings.</value>
        public PlayerDisplaySettings DisplaySettings { get; }

        private Display _display;

        private PlayerErrorCode SetDisplay(Display display)
        {
            if (display == null)
            {
                Log.Info(PlayerLog.Tag, "set display to none");
                return NativePlayer.SetDisplay(Handle, DisplayType.None, IntPtr.Zero);
            }

            return display.ApplyTo(this);
        }

        private void ReplaceDisplay(Display newDisplay)
        {
            _display?.SetOwner(null);
            _display = newDisplay;
            _display?.SetOwner(this);
        }

        /// <summary>
        /// Gets or sets the display.
        /// </summary>
        /// <value>A <see cref="Multimedia.Display"/> that specifies the display.</value>
        /// <remarks>The player must be in the <see cref="PlayerState.Idle"/> state.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="ArgumentException">The value has already been assigned to another player.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        public Display Display
        {
            get
            {
                return _display;
            }
            set
            {
                ValidatePlayerState(PlayerState.Idle);

                if (value?.Owner != null)
                {
                    if (ReferenceEquals(this, value.Owner))
                    {
                        return;
                    }

                    throw new ArgumentException("The display has already been assigned to another.");
                }
                SetDisplay(value).ThrowIfFailed("Failed to set the display to the player");

                ReplaceDisplay(value);
            }
        }

        PlayerErrorCode IDisplayable<PlayerErrorCode>.ApplyEvasDisplay(DisplayType type, ElmSharp.EvasObject evasObject)
        {
            Debug.Assert(IsDisposed == false);

            Debug.Assert(Enum.IsDefined(typeof(DisplayType), type));

            return NativePlayer.SetDisplay(Handle, type, evasObject);
        }
        #endregion

        private PlayerTrackInfo _audioTrack;

        /// <summary>
        /// Gets the track info for audio.
        /// </summary>
        /// <value>A <see cref="PlayerTrackInfo"/> for audio.</value>
        public PlayerTrackInfo AudioTrackInfo
        {
            get
            {
                Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
                if (_audioTrack == null)
                {
                    _audioTrack = new PlayerTrackInfo(this, StreamType.Audio);
                }
                return _audioTrack;
            }
        }

        private PlayerTrackInfo _subtitleTrackInfo;

        /// <summary>
        /// Gets the track info for subtitle.
        /// </summary>
        /// <value>A <see cref="PlayerTrackInfo"/> for subtitle.</value>
        public PlayerTrackInfo SubtitleTrackInfo
        {
            get
            {
                Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
                if (_subtitleTrackInfo == null)
                {
                    _subtitleTrackInfo = new PlayerTrackInfo(this, StreamType.Text);
                }
                return _subtitleTrackInfo;
            }
        }

        private StreamInfo _streamInfo;

        /// <summary>
        /// Gets the stream information.
        /// </summary>
        /// <value>A <see cref="StreamInfo"/> for this player.</value>
        public StreamInfo StreamInfo
        {
            get
            {
                Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
                if (_streamInfo == null)
                {
                    _streamInfo = new StreamInfo(this);
                }
                return _streamInfo;
            }
        }

        private readonly AudioEffect _audioEffect;

        /// <summary>
        /// Gets the audio effect.
        /// </summary>
        /// <feature>http://tizen.org/feature/multimedia.custom_audio_effect</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public AudioEffect AudioEffect
        {
            get
            {
                if (_audioEffect == null)
                {
                    throw new NotSupportedException($"The feature({Features.AudioEffect}) is not supported.");
                }

                return _audioEffect;
            }
        }

        #endregion

        #region Dispose support
        private bool _disposed;

        /// <summary>
        /// Releases all resources used by the current instance.
        /// </summary>
        public void Dispose()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                ReplaceDisplay(null);

                if (_source != null)
                {
                    try
                    {
                        _source.DetachFrom(this);
                    }
                    catch (Exception e)
                    {
                        Log.Error(PlayerLog.Tag, e.ToString());
                    }
                }
                _source = null;

                if (_handle != null)
                {
                    _handle.Dispose();
                }
                _disposed = true;
            }
        }

        internal void ValidateNotDisposed()
        {
            if (_disposed)
            {
                Log.Warn(PlayerLog.Tag, "player was disposed");
                throw new ObjectDisposedException(nameof(Player));
            }
        }

        internal bool IsDisposed => _disposed;
        #endregion

        #region Methods

        /// <summary>
        /// Gets or sets the mute state.
        /// </summary>
        /// <value>true if the player is muted; otherwise, false.</value>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        public bool Muted
        {
            get
            {
                Log.Debug(PlayerLog.Tag, PlayerLog.Enter);

                bool value = false;
                NativePlayer.IsMuted(Handle, out value).ThrowIfFailed("Failed to get the mute state of the player");

                Log.Info(PlayerLog.Tag, "get mute : " + value);

                return value;
            }
            set
            {
                NativePlayer.SetMute(Handle, value).ThrowIfFailed("Failed to set the mute state of the player");
            }
        }

        /// <summary>
        /// Gets the streaming download Progress.
        /// </summary>
        /// <returns>The <see cref="DownloadProgress"/> containing current download progress.</returns>
        /// <remarks>The player must be in the <see cref="PlayerState.Playing"/> or <see cref="PlayerState.Paused"/> state.</remarks>
        /// <exception cref="InvalidOperationException">
        ///     The player is not streaming.\n
        ///     -or-\n
        ///     The player is not in the valid state.
        ///     </exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        public DownloadProgress GetDownloadProgress()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            ValidatePlayerState(PlayerState.Playing, PlayerState.Paused);

            int start = 0;
            int current = 0;
            NativePlayer.GetStreamingDownloadProgress(Handle, out start, out current).
                ThrowIfFailed("Failed to get download progress");

            Log.Info(PlayerLog.Tag, "get download progress : " + start + ", " + current);

            return new DownloadProgress(start, current);
        }

        #region Volume
        /// <summary>
        /// Gets or sets the current volume.
        /// </summary>
        /// <remarks>Valid volume range is from 0 to 1.0, inclusive.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="value"/> is less than zero.\n
        ///     -or-\n
        ///     <paramref name="value"/> is greater than 1.0.
        /// </exception>
        public float Volume
        {
            get
            {
                float value = 0.0F;
                NativePlayer.GetVolume(Handle, out value, out value).
                    ThrowIfFailed("Failed to get the volume of the player");
                return value;
            }
            set
            {
                if (value < 0F || 1.0F < value)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        $"Valid volume range is 0 <= value <= 1.0, but got { value }.");
                }

                NativePlayer.SetVolume(Handle, value, value).
                    ThrowIfFailed("Failed to set the volume of the player");
            }
        }

        #endregion

        /// <summary>
        /// Sets the subtitle path for playback.
        /// </summary>
        /// <remarks>Only MicroDVD/SubViewer(*.sub), SAMI(*.smi), and SubRip(*.srt) subtitle formats are supported.
        ///     <para>The mediastorage privilege(http://tizen.org/privilege/mediastorage) must be added if any files are used to play located in the internal storage.
        ///     The externalstorage privilege(http://tizen.org/privilege/externalstorage) must be added if any files are used to play located in the external storage.</para>
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="ArgumentException"><paramref name="path"/> is an empty string.</exception>
        /// <exception cref="FileNotFoundException">The specified path does not exist.</exception>
        /// <exception cref="ArgumentNullException">The path is null.</exception>
        public void SetSubtitle(string path)
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            ValidateNotDisposed();

            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (path.Length == 0)
            {
                throw new ArgumentException("The path is empty.", nameof(path));
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"The specified file does not exist.", path);
            }

            NativePlayer.SetSubtitlePath(Handle, path).
                ThrowIfFailed("Failed to set the subtitle path to the player");

            Log.Debug(PlayerLog.Tag, PlayerLog.Leave);
        }

        /// <summary>
        /// Removes the subtitle path.
        /// </summary>
        /// <remarks>The player must be in the <see cref="PlayerState.Idle"/> state.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        public void ClearSubtitle()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            ValidatePlayerState(PlayerState.Idle);

            NativePlayer.SetSubtitlePath(Handle, null).
                ThrowIfFailed("Failed to clear the subtitle of the player");
            Log.Debug(PlayerLog.Tag, PlayerLog.Leave);
        }

        /// <summary>
        /// Sets the offset for the subtitle.
        /// </summary>
        /// <param name="offset">The value indicating a desired offset in milliseconds.</param>
        /// <remarks>The player must be in the <see cref="PlayerState.Playing"/> or <see cref="PlayerState.Paused"/> state.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The player is not in the valid state.\n
        ///     -or-\n
        ///     No subtitle is set.
        /// </exception>
        /// <seealso cref="SetSubtitle(string)"/>
        public void SetSubtitleOffset(int offset)
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            ValidatePlayerState(PlayerState.Playing, PlayerState.Paused);

            var err = NativePlayer.SetSubtitlePositionOffset(Handle, offset);

            if (err == PlayerErrorCode.FeatureNotSupported)
            {
                throw new InvalidOperationException("No subtitle set");
            }

            err.ThrowIfFailed("Failed to the subtitle offset of the player");
            Log.Debug(PlayerLog.Tag, PlayerLog.Leave);
        }

        private void Prepare()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            NativePlayer.Prepare(Handle).ThrowIfFailed("Failed to prepare the player");
        }

        protected virtual void OnPreparing()
        {
            RegisterCallbacks();
        }

        /// <summary>
        /// Prepares the media player for playback, asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous prepare operation.</returns>
        /// <remarks>To prepare the player, the player must be in the <see cref="PlayerState.Idle"/> state,
        ///     and a source must be set.</remarks>
        /// <exception cref="InvalidOperationException">No source is set.</exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        public virtual Task PrepareAsync()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            if (_source == null)
            {
                throw new InvalidOperationException("No source is set.");
            }

            ValidatePlayerState(PlayerState.Idle);

            OnPreparing();

            var completionSource = new TaskCompletionSource<bool>();

            SetPreparing();

            Task.Run(() =>
            {
                try
                {
                    Prepare();
                    ClearPreparing();
                    completionSource.SetResult(true);
                }
                catch (Exception e)
                {
                    ClearPreparing();
                    completionSource.TrySetException(e);
                }
            });
            Log.Debug(PlayerLog.Tag, PlayerLog.Leave);

            return completionSource.Task;
        }

        /// <summary>
        /// Unprepares the player.
        /// </summary>
        /// <remarks>
        ///     The most recently used source is reset and no longer associated with the player. Playback is no longer possible.
        ///     If you want to use the player again, you have to set a source and call <see cref="PrepareAsync"/> again.
        ///     <para>
        ///     The player must be in the <see cref="PlayerState.Ready"/>, <see cref="PlayerState.Playing"/> or <see cref="PlayerState.Paused"/> state.
        ///     It has no effect if the player is already in the <see cref="PlayerState.Idle"/> state.
        ///     </para>
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        public virtual void Unprepare()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            if (State == PlayerState.Idle)
            {
                Log.Warn(PlayerLog.Tag, "idle state already");
                return;
            }
            ValidatePlayerState(PlayerState.Ready, PlayerState.Paused, PlayerState.Playing);

            NativePlayer.Unprepare(Handle).ThrowIfFailed("Failed to unprepare the player");

            OnUnprepared();
        }

        protected virtual void OnUnprepared()
        {
            _source?.DetachFrom(this);
            _source = null;
        }

        /// <summary>
        /// Starts or resumes playback.
        /// </summary>
        /// <remarks>
        /// The player must be in the <see cref="PlayerState.Ready"/> or <see cref="PlayerState.Paused"/> state.
        /// It has no effect if the player is already in the <see cref="PlayerState.Playing"/> state.\n
        /// \n
        /// Sound can be mixed with other sounds if you don't control the stream focus using <see cref="ApplyAudioStreamPolicy"/>.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <seealso cref="PrepareAsync"/>
        /// <seealso cref="Stop"/>
        /// <seealso cref="Pause"/>
        /// <seealso cref="PlaybackCompleted"/>
        /// <seealso cref="ApplyAudioStreamPolicy"/>
        public virtual void Start()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            if (State == PlayerState.Playing)
            {
                Log.Warn(PlayerLog.Tag, "playing state already");
                return;
            }
            ValidatePlayerState(PlayerState.Ready, PlayerState.Paused);

            NativePlayer.Start(Handle).ThrowIfFailed("Failed to start the player");
            Log.Debug(PlayerLog.Tag, PlayerLog.Leave);
        }

        /// <summary>
        /// Stops playing media content.
        /// </summary>
        /// <remarks>
        /// The player must be in the <see cref="PlayerState.Playing"/> or <see cref="PlayerState.Paused"/> state.
        /// It has no effect if the player is already in the <see cref="PlayerState.Ready"/> state.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <seealso cref="Start"/>
        /// <seealso cref="Pause"/>
        public virtual void Stop()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            if (State == PlayerState.Ready)
            {
                Log.Warn(PlayerLog.Tag, "ready state already");
                return;
            }
            ValidatePlayerState(PlayerState.Paused, PlayerState.Playing);

            NativePlayer.Stop(Handle).ThrowIfFailed("Failed to stop the player");
            Log.Debug(PlayerLog.Tag, PlayerLog.Leave);
        }

        /// <summary>
        /// Pauses the player.
        /// </summary>
        /// <remarks>
        /// The player must be in the <see cref="PlayerState.Playing"/> state.
        /// It has no effect if the player is already in the <see cref="PlayerState.Paused"/> state.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <seealso cref="Start"/>
        public virtual void Pause()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            if (State == PlayerState.Paused)
            {
                Log.Warn(PlayerLog.Tag, "pause state already");
                return;
            }

            ValidatePlayerState(PlayerState.Playing);

            NativePlayer.Pause(Handle).ThrowIfFailed("Failed to pause the player");
            Log.Debug(PlayerLog.Tag, PlayerLog.Leave);
        }

        private MediaSource _source;

        /// <summary>
        /// Sets a media source for the player.
        /// </summary>
        /// <param name="source">A <see cref="MediaSource"/> that specifies the source for playback.</param>
        /// <remarks>The player must be in the <see cref="PlayerState.Idle"/> state.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The player is not in the valid state.\n
        ///     -or-\n
        ///     It is not able to assign the source to the player.
        ///     </exception>
        /// <seealso cref="PrepareAsync"/>
        public void SetSource(MediaSource source)
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            ValidatePlayerState(PlayerState.Idle);

            if (source != null)
            {
                source.AttachTo(this);
            }

            if (_source != null)
            {
                _source.DetachFrom(this);
            }

            _source = source;
            Log.Debug(PlayerLog.Tag, PlayerLog.Leave);
        }

        /// <summary>
        /// Captures a video frame asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous capture operation.</returns>
        /// <feature>http://tizen.org/feature/multimedia.raw_video</feature>
        /// <remarks>The player must be in the <see cref="PlayerState.Playing"/> or <see cref="PlayerState.Paused"/> state.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public async Task<CapturedFrame> CaptureVideoAsync()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);

            ValidationUtil.ValidateFeatureSupported(Features.RawVideo);

            ValidatePlayerState(PlayerState.Playing, PlayerState.Paused);

            TaskCompletionSource<CapturedFrame> t = new TaskCompletionSource<CapturedFrame>();

            NativePlayer.VideoCaptureCallback cb = (data, width, height, size, _) =>
            {
                Debug.Assert(size <= int.MaxValue);

                byte[] buf = new byte[size];
                Marshal.Copy(data, buf, 0, (int)size);

                t.TrySetResult(new CapturedFrame(buf, width, height));
            };

            using (var cbKeeper = ObjectKeeper.Get(cb))
            {
                NativePlayer.CaptureVideo(Handle, cb)
                    .ThrowIfFailed("Failed to capture the video");

                return await t.Task;
            }
        }

        /// <summary>
        /// Gets the play position in milliseconds.
        /// </summary>
        /// <remarks>The player must be in the <see cref="PlayerState.Ready"/>, <see cref="PlayerState.Playing"/> or <see cref="PlayerState.Paused"/> state.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <seealso cref="SetPlayPositionAsync(int, bool)"/>
        public int GetPlayPosition()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            ValidatePlayerState(PlayerState.Ready, PlayerState.Paused, PlayerState.Playing);

            int playPosition = 0;

            NativePlayer.GetPlayPosition(Handle, out playPosition).
                ThrowIfFailed("Failed to get the play position of the player");

            Log.Info(PlayerLog.Tag, "get play position : " + playPosition);

            return playPosition;
        }

        private void SetPlayPosition(int milliseconds, bool accurate,
            NativePlayer.SeekCompletedCallback cb)
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            var ret = NativePlayer.SetPlayPosition(Handle, milliseconds, accurate, cb, IntPtr.Zero);

            //Note that we assume invalid param error is returned only when the position value is invalid.
            if (ret == PlayerErrorCode.InvalidArgument)
            {
                throw new ArgumentOutOfRangeException(nameof(milliseconds), milliseconds,
                    "The position is not valid.");
            }
            if (ret != PlayerErrorCode.None)
            {
                Log.Error(PlayerLog.Tag, "Failed to set play position, " + (PlayerError)ret);
            }
            ret.ThrowIfFailed("Failed to set play position");
        }

        /// <summary>
        /// Sets the seek position for playback, asynchronously.
        /// </summary>
        /// <param name="position">The value indicating a desired position in milliseconds.</param>
        /// <param name="accurate">The value indicating whether the operation performs with accuracy.</param>
        /// <remarks>
        ///     <para>The player must be in the <see cref="PlayerState.Ready"/>, <see cref="PlayerState.Playing"/> or <see cref="PlayerState.Paused"/> state.</para>
        ///     <para>If the <paramref name="accurate"/> is true, the play position will be adjusted as the specified <paramref name="position"/> value,
        ///     but this might be considerably slow. If false, the play position will be a nearest keyframe position.</para>
        ///     </remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified position is not valid.</exception>
        /// <seealso cref="GetPlayPosition"/>
        public async Task SetPlayPositionAsync(int position, bool accurate)
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);

            var taskCompletionSource = new TaskCompletionSource<bool>();

            bool immediateResult = _source is MediaStreamSource;

            NativePlayer.SeekCompletedCallback cb = _ => taskCompletionSource.TrySetResult(true);

            using (var cbKeeper = ObjectKeeper.Get(cb))
            {
                SetPlayPosition(position, accurate, cb);
                if (immediateResult)
                {
                    taskCompletionSource.TrySetResult(true);
                }

                await taskCompletionSource.Task;
            }

            Log.Debug(PlayerLog.Tag, PlayerLog.Leave);
        }

        /// <summary>
        /// Sets playback rate.
        /// </summary>
        /// <param name="rate">The value for the playback rate. Valid range is -5.0 to 5.0, inclusive.</param>
        /// <remarks>
        ///     <para>The player must be in the <see cref="PlayerState.Ready"/>, <see cref="PlayerState.Playing"/> or <see cref="PlayerState.Paused"/> state.</para>
        ///     <para>The sound will be muted, when the playback rate is under 0.0 or over 2.0.</para>
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The player is not in the valid state.\n
        ///     -or-\n
        ///     Streaming playback.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="rate"/> is less than 5.0.\n
        ///     -or-\n
        ///     <paramref name="rate"/> is greater than 5.0.\n
        ///     -or-\n
        ///     <paramref name="rate"/> is zero.
        /// </exception>
        public void SetPlaybackRate(float rate)
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            if (rate < -5.0F || 5.0F < rate || rate == 0.0F)
            {
                throw new ArgumentOutOfRangeException(nameof(rate), rate, "Valid range is -5.0 to 5.0 (except 0.0)");
            }

            ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);

            NativePlayer.SetPlaybackRate(Handle, rate).ThrowIfFailed("Failed to set the playback rate.");
            Log.Debug(PlayerLog.Tag, PlayerLog.Leave);
        }

        /// <summary>
        /// Applies the audio stream policy.
        /// </summary>
        /// <param name="policy">The <see cref="AudioStreamPolicy"/> to apply.</param>
        /// <remarks>The player must be in the <see cref="PlayerState.Idle"/> state.</remarks>
        /// <exception cref="ObjectDisposedException">
        ///     The player has already been disposed of.\n
        ///     -or-\n
        ///     <paramref name="policy"/> has already been disposed of.
        /// </exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="policy"/> is null.</exception>
        public void ApplyAudioStreamPolicy(AudioStreamPolicy policy)
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            if (policy == null)
            {
                throw new ArgumentNullException(nameof(policy));
            }

            if (policy.Handle == IntPtr.Zero)
            {
                throw new ObjectDisposedException(nameof(policy));
            }

            ValidatePlayerState(PlayerState.Idle);

            NativePlayer.SetAudioPolicyInfo(Handle, policy.Handle).
                ThrowIfFailed("Failed to set the audio stream policy to the player");
        }
        #endregion

        #region Callback registrations
        private void RegisterSubtitleUpdatedCallback()
        {
            _subtitleUpdatedCallback = (duration, text, _) =>
            {
                Log.Debug(PlayerLog.Tag, "duration : " + duration + ", text : " + text);
                SubtitleUpdated?.Invoke(this, new SubtitleUpdatedEventArgs(duration, text));
            };

            NativePlayer.SetSubtitleUpdatedCb(Handle, _subtitleUpdatedCallback).
                ThrowIfFailed("Failed to initialize the player");
        }

        private void RegisterPlaybackCompletedCallback()
        {
            _playbackCompletedCallback = _ =>
            {
                Log.Debug(PlayerLog.Tag, "completed callback");
                PlaybackCompleted?.Invoke(this, EventArgs.Empty);
            };
            NativePlayer.SetCompletedCb(Handle, _playbackCompletedCallback).
                ThrowIfFailed("Failed to set PlaybackCompleted");
        }

        private void RegisterPlaybackInterruptedCallback()
        {
            _playbackInterruptedCallback = (code, _) =>
            {
                if (!Enum.IsDefined(typeof(PlaybackInterruptionReason), code))
                {
                    return;
                }

                if (code == PlaybackInterruptionReason.ResourceConflict)
                {
                    OnUnprepared();
                }

                Log.Warn(PlayerLog.Tag, "interrupted reason : " + code);
                PlaybackInterrupted?.Invoke(this, new PlaybackInterruptedEventArgs(code));
            };

            NativePlayer.SetInterruptedCb(Handle, _playbackInterruptedCallback).
                ThrowIfFailed("Failed to set PlaybackInterrupted");
        }

        private void RegisterErrorOccurredCallback()
        {
            _playbackErrorCallback = (code, _) =>
            {
                //TODO handle service disconnected error.
                Log.Warn(PlayerLog.Tag, "error code : " + code);
                ErrorOccurred?.Invoke(this, new PlayerErrorOccurredEventArgs((PlayerError)code));
            };

            NativePlayer.SetErrorCb(Handle, _playbackErrorCallback).
                ThrowIfFailed("Failed to set PlaybackError");
        }

        #region VideoFrameDecoded event

        private EventHandler<VideoFrameDecodedEventArgs> _videoFrameDecoded;

        private NativePlayer.VideoFrameDecodedCallback _videoFrameDecodedCallback;

        /// <summary>
        /// Occurs when a video frame is decoded.
        /// </summary>
        /// <remarks>
        ///     <para>The event handler will be executed on an internal thread.</para>
        ///     <para>The <see cref="VideoFrameDecodedEventArgs.Packet"/> in event args should be disposed after use.</para>
        /// </remarks>
        /// <feature>http://tizen.org/feature/multimedia.raw_video</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <seealso cref="VideoFrameDecodedEventArgs.Packet"/>
        public event EventHandler<VideoFrameDecodedEventArgs> VideoFrameDecoded
        {
            add
            {
                ValidationUtil.ValidateFeatureSupported(Features.RawVideo);

                _videoFrameDecoded += value;
            }
            remove
            {
                ValidationUtil.ValidateFeatureSupported(Features.RawVideo);

                _videoFrameDecoded -= value;
            }
        }

        private void RegisterVideoFrameDecodedCallback()
        {
            _videoFrameDecodedCallback = (packetHandle, _) =>
            {
                var handler = _videoFrameDecoded;
                if (handler != null)
                {
                    Log.Debug(PlayerLog.Tag, "packet : " + packetHandle);
                    handler.Invoke(this,
                        new VideoFrameDecodedEventArgs(MediaPacket.From(packetHandle)));
                }
                else
                {
                    MediaPacket.From(packetHandle).Dispose();
                }
            };

            NativePlayer.SetVideoFrameDecodedCb(Handle, _videoFrameDecodedCallback).
                ThrowIfFailed("Failed to register the VideoFrameDecoded");
        }
        #endregion

        private void RegisterVideoStreamChangedCallback()
        {
            ValidatePlayerState(PlayerState.Idle);

            _videoStreamChangedCallback = (width, height, fps, bitrate, _) =>
            {
                Log.Debug(PlayerLog.Tag, "height : " + height + ", width : " + width
                + ", fps : " + fps + ", bitrate : " + bitrate);

                VideoStreamChanged?.Invoke(this, new VideoStreamChangedEventArgs(height, width, fps, bitrate));
            };

            NativePlayer.SetVideoStreamChangedCb(Handle, _videoStreamChangedCallback).
                ThrowIfFailed("Failed to set the video stream changed callback");
        }

        private void RegisterBufferingCallback()
        {
            _bufferingProgressCallback = (percent, _) =>
            {
                Log.Debug(PlayerLog.Tag, $"Buffering callback with percent { percent }");
                BufferingProgressChanged?.Invoke(this, new BufferingProgressChangedEventArgs(percent));
            };

            NativePlayer.SetBufferingCb(Handle, _bufferingProgressCallback).
                ThrowIfFailed("Failed to set BufferingProgress");
        }

        private void RegisterMediaStreamBufferStatusCallback()
        {
            _mediaStreamAudioBufferStatusChangedCallback = (status, _) =>
            {
                Debug.Assert(Enum.IsDefined(typeof(MediaStreamBufferStatus), status));
                Log.Debug(PlayerLog.Tag, "audio buffer status : " + status);
                MediaStreamAudioBufferStatusChanged?.Invoke(this,
                    new MediaStreamBufferStatusChangedEventArgs(status));
            };
            _mediaStreamVideoBufferStatusChangedCallback = (status, _) =>
            {
                Debug.Assert(Enum.IsDefined(typeof(MediaStreamBufferStatus), status));
                Log.Debug(PlayerLog.Tag, "video buffer status : " + status);
                MediaStreamVideoBufferStatusChanged?.Invoke(this,
                    new MediaStreamBufferStatusChangedEventArgs(status));
            };

            RegisterMediaStreamBufferStatusCallback(StreamType.Audio, _mediaStreamAudioBufferStatusChangedCallback);
            RegisterMediaStreamBufferStatusCallback(StreamType.Video, _mediaStreamVideoBufferStatusChangedCallback);
        }

        private void RegisterMediaStreamBufferStatusCallback(StreamType streamType,
            NativePlayer.MediaStreamBufferStatusCallback cb)
        {
            NativePlayer.SetMediaStreamBufferStatusCb(Handle, streamType, cb).
                ThrowIfFailed("Failed to SetMediaStreamBufferStatus");
        }

        private void RegisterMediaStreamSeekCallback()
        {
            _mediaStreamAudioSeekCallback = (offset, _) =>
            {
                Log.Debug(PlayerLog.Tag, "audio seeking offset : " + offset);
                MediaStreamAudioSeekingOccurred?.Invoke(this, new MediaStreamSeekingOccurredEventArgs(offset));
            };
            _mediaStreamVideoSeekCallback = (offset, _) =>
            {
                Log.Debug(PlayerLog.Tag, "video seeking offset : " + offset);
                MediaStreamVideoSeekingOccurred?.Invoke(this, new MediaStreamSeekingOccurredEventArgs(offset));
            };

            RegisterMediaStreamSeekCallback(StreamType.Audio, _mediaStreamAudioSeekCallback);
            RegisterMediaStreamSeekCallback(StreamType.Video, _mediaStreamVideoSeekCallback);
        }

        private void RegisterMediaStreamSeekCallback(StreamType streamType, NativePlayer.MediaStreamSeekCallback cb)
        {
            NativePlayer.SetMediaStreamSeekCb(Handle, streamType, cb).
                ThrowIfFailed("Failed to SetMediaStreamSeek");
        }
        #endregion

        #region Preparing state

        private int _isPreparing;

        private bool IsPreparing()
        {
            return Interlocked.CompareExchange(ref _isPreparing, 1, 1) == 1;
        }

        private void SetPreparing()
        {
            Interlocked.Exchange(ref _isPreparing, 1);
        }

        private void ClearPreparing()
        {
            Interlocked.Exchange(ref _isPreparing, 0);
        }

        #endregion
    }
}
