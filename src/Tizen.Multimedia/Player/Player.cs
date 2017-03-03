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
    public sealed class Player : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;

        /// <summary>
        /// Occurs when playback of a media is finished.
        /// </summary>
        public event EventHandler<EventArgs> PlaybackCompleted;
        private Interop.Player.PlaybackCompletedCallback _playbackCompletedCallback;

        /// <summary>
        /// Occurs when playback of a media is interrupted.
        /// </summary>
        public event EventHandler<PlaybackInterruptedEventArgs> PlaybackInterrupted;
        private Interop.Player.PlaybackInterruptedCallback _playbackInterruptedCallback;

        /// <summary>
        /// Occurs when any error occurs.
        /// </summary>
        /// <remarks>The event handler will be executed on an internal thread.</remarks>
        public event EventHandler<PlayerErrorOccurredEventArgs> ErrorOccurred;
        private Interop.Player.PlaybackErrorCallback _playbackErrorCallback;

        /// <summary>
        /// Occurs when a video frame is decoded
        /// </summary>
        /// <remarks>
        ///     <para>The event handler will be executed on an internal thread.</para>
        ///     <para>The <see cref="VideoFrameDecodedEventArgs.Packet"/> in event args should be disposed after use.</para>
        /// </remarks>
        /// <see cref="VideoFrameDecodedEventArgs.Packet"/>
        public event EventHandler<VideoFrameDecodedEventArgs> VideoFrameDecoded;
        private Interop.Player.VideoFrameDecodedCallback _videoFrameDecodedCallback;

        /// <summary>
        /// Occurs when the video stream changed.
        /// </summary>
        /// <remarks>The event handler will be executed on an internal thread.</remarks>
        public event EventHandler<VideoStreamChangedEventArgs> VideoStreamChanged;
        private Interop.Player.VideoStreamChangedCallback _videoStreamChangedCallback;

        /// <summary>
        /// Occurs when the subtitle is updated.
        /// </summary>
        /// <remarks>The event handler will be executed on an internal thread.</remarks>
        public EventHandler<SubtitleUpdatedEventArgs> SubtitleUpdated;
        private Interop.Player.SubtitleUpdatedCallback _subtitleUpdatedCallback;

        /// <summary>
        /// Occurs when there is a change in the buffering status of streaming.
        /// </summary>
        public event EventHandler<BufferingProgressChangedEventArgs> BufferingProgressChanged;
        private Interop.Player.BufferingProgressCallback _bufferingProgressCallback;

        internal event EventHandler<MediaStreamBufferStatusChangedEventArgs> MediaStreamAudioBufferStatusChanged;
        private Interop.Player.MediaStreamBufferStatusCallback _mediaStreamAudioBufferStatusChangedCallback;

        internal event EventHandler<MediaStreamBufferStatusChangedEventArgs> MediaStreamVideoBufferStatusChanged;
        private Interop.Player.MediaStreamBufferStatusCallback _mediaStreamVideoBufferStatusChangedCallback;

        internal event EventHandler<MediaStreamSeekingOccurredEventArgs> MediaStreamAudioSeekingOccurred;
        private Interop.Player.MediaStreamSeekCallback _mediaStreamAudioSeekCallback;

        internal event EventHandler<MediaStreamSeekingOccurredEventArgs> MediaStreamVideoSeekingOccurred;
        private Interop.Player.MediaStreamSeekCallback _mediaStreamVideoSeekCallback;

        /// <summary>
        /// Initialize a new instance of the Player class.
        /// </summary>
        public Player()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            try
            {
                int ret = Interop.Player.Create(out _handle);
                if (ret != (int)PlayerErrorCode.None)
                {
                    Log.Error(PlayerLog.Tag, "Failed to create player, " + (PlayerError)ret);
                }
                PlayerErrorConverter.ThrowIfError(ret, "Failed to create player");

                RetrieveProperties();
                RegisterCallbacks();

                AudioEffect = new AudioEffect(this);
            }
            catch (Exception)
            {
                if (_handle != IntPtr.Zero)
                {
                    Interop.Player.Destroy(_handle);
                }
                throw;
            }
        }

        private void RetrieveProperties()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            PlayerErrorConverter.ThrowIfError(Interop.Player.GetVolume(_handle, out _volume, out _volume),
                "Failed to initialize the player");

            int value = 0;
            PlayerErrorConverter.ThrowIfError(Interop.Player.GetAudioLatencyMode(_handle, out value),
                "Failed to initialize the player");
            _audioLatencyMode = (AudioLatencyMode)value;

            PlayerErrorConverter.ThrowIfError(Interop.Player.IsLooping(_handle, out _isLooping),
                "Failed to initialize the player");
            Log.Debug(PlayerLog.Tag, PlayerLog.Leave);
        }

        private void RegisterCallbacks()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            RegisterSubtitleUpdatedCallback();
            RegisterErrorOccuuredCallback();
            RegisterPlaybackInterruptedCallback();
            RegisterVideoStreamChangedCallback();
            RegisterBufferingCallback();
            RegisterMediaStreamBufferStatusCallback();
            RegisterMediaStreamSeekCallback();
            RegisterPlaybackCompletedCallback();
            RegisterVideoFrameDecodedCallback();
        }

        ~Player()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            Dispose(false);
        }

        internal IntPtr GetHandle()
        {
            ValidateNotDisposed();
            return _handle;
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

            Log.Warn(PlayerLog.Tag, "current state : " + State + ", desired state : " + string.Join(", ", desiredStates));
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

                int ret = Interop.Player.SetStreamingCookie(_handle, value, value.Length);
                if (ret != (int)PlayerErrorCode.None)
                {
                    Log.Error(PlayerLog.Tag, "Failed to set the cookie to the player, " + (PlayerError)ret);
                }
                PlayerErrorConverter.ThrowIfError(ret, "Failed to set the cookie to the player");

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

                int ret = Interop.Player.SetStreamingUserAgent(_handle, value, value.Length);
                if (ret != (int)PlayerErrorCode.None)
                {
                    Log.Error(PlayerLog.Tag, "Failed to set the user agent to the player, " + (PlayerError)ret);
                }
                PlayerErrorConverter.ThrowIfError(ret, "Failed to set the user agent to the player");

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

                //TODO is this needed?
                if (IsPreparing())
                {
                    return PlayerState.Preparing;
                }

                int state = 0;
                int ret = Interop.Player.GetState(_handle, out state);
                if (ret != (int)PlayerErrorCode.None)
                {
                    Log.Error(PlayerLog.Tag, "Failed to retrieve the state of the player, " + (PlayerError)ret);
                }
                PlayerErrorConverter.ThrowIfError(ret, "Failed to retrieve the state of the player");

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
        /// If the mode is <see cref="AudioLatencyMode.AudioLatencyMode"/>,
        /// audio output interval can be increased so, it can keep more audio data to play.
        /// But, state transition like pause or resume can be more slower than default(<see cref="AudioLatencyMode.Mid"/>) mode.
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

                int ret = Interop.Player.SetAudioLatencyMode(_handle, (int)value);
                if (ret != (int)PlayerErrorCode.None)
                {
                    Log.Error(PlayerLog.Tag, "Failed to set the audio latency mode of the player, " + (PlayerError)ret);
                }
                PlayerErrorConverter.ThrowIfError(ret, "Failed to set the audio latency mode of the player");

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

                int ret = Interop.Player.SetLooping(_handle, value);
                if (ret != (int)PlayerErrorCode.None)
                {
                    Log.Error(PlayerLog.Tag, "Failed to set the looping state of the player, " + (PlayerError)ret);
                }
                PlayerErrorConverter.ThrowIfError(ret, "Failed to set the looping state of the player");

                _isLooping = value;
            }
        }

#region Display methods
        private PlayerDisplay _display;

        private int SetDisplay(PlayerDisplay display)
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            if (display == null)
            {
                Log.Info(PlayerLog.Tag, "set display to none");
                return Interop.Player.SetDisplay(_handle, (int)PlayerDisplayType.None, IntPtr.Zero);
            }
            Log.Info(PlayerLog.Tag, "set display to " + display.Type + " (" + display.EvasObject + ")");

            Debug.Assert(Enum.IsDefined(typeof(PlayerDisplayType), display.Type));
            Debug.Assert(display.EvasObject != null);

            return Interop.Player.SetDisplay(_handle, (int)display.Type, display.EvasObject);
        }

        private void ReplaceDisplay(PlayerDisplay newDisplay)
        {
            if (_display != null)
            {
                _display.Player = null;
            }
            _display = newDisplay;
            if (_display != null)
            {
                _display.Player = this;
                Log.Info(PlayerLog.Tag, "replace display to " + newDisplay.Type + " (" + newDisplay.EvasObject + ")");
            }
        }

        /// <summary>
        /// Gets or sets the display.
        /// </summary>
        /// <value>A <see cref="PlayerDisplay"/> that specifies the display configurations.</value>
        /// <remarks>The player must be in the <see cref="PlayerState.Idle"/> state.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="ArgumentException">The value has already been assigned to another player.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        public PlayerDisplay Display
        {
            get
            {
                return _display;
            }
            set
            {
                Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
                ValidatePlayerState(PlayerState.Idle);

                if (value != null && value.Player != null)
                {
                    if (ReferenceEquals(this, value.Player))
                    {
                        return;
                    }
                    else
                    {
                        throw new ArgumentException("The display has already been assigned to another player.");
                    }
                }

                PlayerErrorConverter.ThrowIfError(SetDisplay(value), "Failed to set the display to the player");

                ReplaceDisplay(value);
                Log.Debug(PlayerLog.Tag, PlayerLog.Leave);
            }
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

        /// <summary>
        /// Gets audio effect.
        /// </summary>
        public AudioEffect AudioEffect { get; }

#endregion

#region Dispose support
        private bool _disposed;

        public void Dispose()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
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

                if (_handle != IntPtr.Zero)
                {
                    Interop.Player.Destroy(_handle);
                    _handle = IntPtr.Zero;
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

        internal bool IsDisposed
        {
            get
            {
                Log.Info(PlayerLog.Tag, "get disposed : " + _disposed);
                return _disposed;
            }
        }
#endregion

#region Methods

        /// <summary>
        /// Gets the mute state.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        public bool IsMuted()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            ValidateNotDisposed();

            bool value = false;
            PlayerErrorConverter.ThrowIfError(Interop.Player.IsMuted(_handle, out value),
                "Failed to get the mute state of the player");

            Log.Info(PlayerLog.Tag, "get mute : " + value);

            return value;
        }

        /// <summary>
        /// Sets the mute state.
        /// </summary>
        /// <param name="mute">true to mute the player; otherwise, false.</value>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        public void SetMute(bool mute)
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            ValidateNotDisposed();

            int ret = Interop.Player.SetMute(_handle, mute);
            if (ret != (int)PlayerErrorCode.None)
            {
                Log.Error(PlayerLog.Tag, "Failed to set the mute state of the player, " + (PlayerError)ret);
            }
            PlayerErrorConverter.ThrowIfError(ret, "Failed to set the mute state of the player");
        }

        /// <summary>
        /// Get Streaming download Progress.
        /// </summary>
        /// <remarks>The player must be in the <see cref="PlayerState.Playing"/> or <see cref="PlayerState.Paused"/> state.</remarks>
        /// <exception cref="InvalidOperationException">
        ///     The player is not streaming.
        ///     <para>-or-</para>
        ///     The player is not in the valid state.
        ///     </exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        public DownloadProgress GetDownloadProgress()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            ValidatePlayerState(PlayerState.Playing, PlayerState.Paused);

            int start = 0;
            int current = 0;
            int ret = Interop.Player.GetStreamingDownloadProgress(_handle, out start, out current);
            PlayerErrorConverter.ThrowIfError(ret, "Failed to get download progress");

            Log.Info(PlayerLog.Tag, "get download progress : " + start + ", " + current);

            return new DownloadProgress(start, current);
        }

#region Volume
        private float _volume;

        /// <summary>
        /// Sets the current volume.
        /// </summary>
        /// <remarks>Valid volume range is from 0 to 1.0, inclusive.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     value is less than zero.
        ///     <para>-or-</para>
        ///     value is greater than 1.0.
        /// </exception>
        public void SetVolume(float value)
        {
            ValidateNotDisposed();

            if (value < 0F || 1.0F < value)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value,
                    $"Valid volume range is 0 <= value <= 1.0, but got { value }.");
            }

            int ret = Interop.Player.SetVolume(_handle, value, value);
            PlayerErrorConverter.ThrowIfError(ret, "Failed to set the volume of the player");
        }

        /// <summary>
        /// Gets the current volume.
        /// </summary>
        /// <remarks>the volume range is from 0 to 1.0, inclusive.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        public float GetVolume()
        {
            ValidateNotDisposed();

            float value = 0.0F;
            int ret = Interop.Player.GetVolume(_handle, out value, out value);
            PlayerErrorConverter.ThrowIfError(ret, "Failed to get the volume of the player");
            return value;
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
        /// <exception cref="ArgumentException">The specified path does not exist.</exception>
        /// <exception cref="ArgumentNullException">The path is null.</exception>
        public void SetSubtitle(string path)
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            ValidateNotDisposed();

            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"The specified file does not exist : { path }.");
            }

            PlayerErrorConverter.ThrowIfError(Interop.Player.SetSubtitlePath(_handle, path),
                "Failed to set the subtitle path to the player");
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

            PlayerErrorConverter.ThrowIfError(Interop.Player.SetSubtitlePath(_handle, null),
                "Failed to clear the subtitle of the player");
            Log.Debug(PlayerLog.Tag, PlayerLog.Leave);
        }

        /// <summary>
        /// Sets the offset for the subtitle.
        /// </summary>
        /// <remarks>The player must be in the <see cref="PlayerState.Playing"/> or <see cref="PlayerState.Paused"/> state.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        public void SetSubtitleOffset(int offset)
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            ValidatePlayerState(PlayerState.Playing, PlayerState.Paused);

            PlayerErrorConverter.ThrowIfError(Interop.Player.SetSubtitlePositionOffset(_handle, offset),
                "Failed to the subtitle offset of the player");
            Log.Debug(PlayerLog.Tag, PlayerLog.Leave);
        }

        private void Prepare()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            int ret = Interop.Player.Prepare(_handle);
            if (ret != (int)PlayerErrorCode.None)
            {
                Log.Error(PlayerLog.Tag, "Failed to prepare the player, " + (PlayerError)ret);
            }
            PlayerErrorConverter.ThrowIfError(ret, "Failed to prepare the player");
        }

        /// <summary>
        /// Prepares the media player for playback, asynchronously.
        /// </summary>
        /// <remarks>To prepare the player, the player must be in the <see cref="PlayerState.Idle"/> state,
        ///     and a source must be set.</remarks>
        /// <exception cref="InvalidOperationException">No source is set.</exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        public Task PrepareAsync()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            if (_source == null)
            {
                throw new InvalidOperationException("No source is set.");
            }

            ValidatePlayerState(PlayerState.Idle);

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
        public void Unprepare()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            if (State == PlayerState.Idle)
            {
                Log.Warn(PlayerLog.Tag, "idle state already");
                return;
            }
            ValidatePlayerState(PlayerState.Ready, PlayerState.Paused, PlayerState.Playing);

            PlayerErrorConverter.ThrowIfError(Interop.Player.Unprepare(_handle),
                "Failed to unprepare the player");

            if (_source != null)
            {
                _source.DetachFrom(this);
            }
            _source = null;
        }


        //TODO remarks needs to be updated. see the native reference.
        /// <summary>
        /// Starts or resumes playback.
        /// </summary>
        /// <remarks>
        /// The player must be in the <see cref="PlayerState.Ready"/> or <see cref="PlayerState.Paused"/> state.
        /// It has no effect if the player is already in the <see cref="PlayerState.Playing"/> state.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <seealso cref="PrepareAsync"/>
        /// <seealso cref="Stop"/>
        /// <seealso cref="Pause"/>
        /// <seealso cref="PlaybackCompleted"/>
        public void Start()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            if (State == PlayerState.Playing)
            {
                Log.Warn(PlayerLog.Tag, "playing state already");
                return;
            }
            ValidatePlayerState(PlayerState.Ready, PlayerState.Paused);

            PlayerErrorConverter.ThrowIfError(Interop.Player.Start(_handle), "Failed to start the player");
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
        public void Stop()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            if (State == PlayerState.Ready)
            {
                Log.Warn(PlayerLog.Tag, "ready state already");
                return;
            }
            ValidatePlayerState(PlayerState.Paused, PlayerState.Playing);

            PlayerErrorConverter.ThrowIfError(Interop.Player.Stop(_handle), "Failed to stop the player");
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
        public void Pause()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            if (State == PlayerState.Paused)
            {
                Log.Warn(PlayerLog.Tag, "pause state already");
                return;
            }

            ValidatePlayerState(PlayerState.Playing);

            PlayerErrorConverter.ThrowIfError(Interop.Player.Pause(_handle), "Failed to pause the player");
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
        ///     The player is not in the valid state.
        ///     <para>-or-</para>
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
        /// <remarks>The player must be in the <see cref="PlayerState.Playing"/> or <see cref="PlayerState.Paused"/> state.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        public Task<CapturedFrame> CaptureVideoAsync()
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            ValidatePlayerState(PlayerState.Playing, PlayerState.Paused);

            TaskCompletionSource<CapturedFrame> t = new TaskCompletionSource<CapturedFrame>();

            Interop.Player.VideoCaptureCallback cb = (data, width, height, size, gchPtr) =>
            {
                Debug.Assert(size <= int.MaxValue);

                byte[] buf = new byte[size];
                Marshal.Copy(data, buf, 0, (int)size);

                t.TrySetResult(new CapturedFrame(buf, width, height));

                GCHandle.FromIntPtr(gchPtr).Free();
            };

            var gch = GCHandle.Alloc(cb);
            try
            {
                PlayerErrorConverter.ThrowIfError(
                    Interop.Player.CaptureVideo(_handle, cb, GCHandle.ToIntPtr(gch)),
                    "Failed to capture the video");
            }
            catch(Exception)
            {
                gch.Free();
                throw;
            }
            Log.Debug(PlayerLog.Tag, PlayerLog.Leave);

            return t.Task;
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

            PlayerErrorConverter.ThrowIfError(Interop.Player.GetPlayPosition(_handle, out playPosition),
                "Failed to get the play position of the player");

            Log.Info(PlayerLog.Tag, "get play position : " + playPosition);

            return playPosition;
        }

        private void SetPlayPosition(int milliseconds, bool accurate,
            Interop.Player.SeekCompletedCallback cb)
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            int ret = Interop.Player.SetPlayPosition(_handle, milliseconds, accurate, cb, IntPtr.Zero);

            //Note that we assume invalid param error is returned only when the position value is invalid.
            if (ret == (int)PlayerErrorCode.InvalidArgument)
            {
                throw new ArgumentOutOfRangeException(nameof(milliseconds), milliseconds,
                    "The position is not valid.");
            }
            if (ret != (int)PlayerErrorCode.None)
            {
                Log.Error(PlayerLog.Tag, "Failed to set play position, " + (PlayerError)ret);
            }
            PlayerErrorConverter.ThrowIfError(ret, "Failed to set play position");
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
        public Task SetPlayPositionAsync(int position, bool accurate)
        {
            Log.Debug(PlayerLog.Tag, PlayerLog.Enter);
            ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);

            var taskCompletionSource = new TaskCompletionSource<bool>();

            bool immediateResult = _source is MediaStreamSource;

            Interop.Player.SeekCompletedCallback cb = _ => taskCompletionSource.TrySetResult(true);

            SetPlayPosition(position, accurate, cb);
            if (immediateResult)
            {
                taskCompletionSource.TrySetResult(true);
            }

            Log.Debug(PlayerLog.Tag, PlayerLog.Leave);

            return taskCompletionSource.Task;
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
        ///     The player is not in the valid state.
        ///     <para>-or-</para>
        ///     Streaming playback.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="rate"/> is less than 5.0.
        ///     <para>-or-</para>
        ///     <paramref name="rate"/> is greater than 5.0.
        ///     <para>-or-</para>
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

            PlayerErrorConverter.ThrowIfError(Interop.Player.SetPlaybackRate(_handle, rate),
                "Failed to set the playback rate.");
            Log.Debug(PlayerLog.Tag, PlayerLog.Leave);
        }

        /// <summary>
        /// Applies the audio stream policy.
        /// </summary>
        /// <param name="policy">The <see cref="AudioStreamPolicy"/> to apply.</param>
        /// <remarks>The player must be in the <see cref="PlayerState.Idle"/> state.</remarks>
        /// <exception cref="ObjectDisposedException">
        ///     The player has already been disposed of.
        ///     <para>-or-</para>
        ///     <paramref name="poilcy"/> has already been disposed of.
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

            PlayerErrorConverter.ThrowIfError(Interop.Player.SetAudioPolicyInfo(_handle, policy.Handle),
                "Failed to set the audio stream policy to the player");
            Log.Debug(PlayerLog.Tag, PlayerLog.Leave);
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

            int ret = Interop.Player.SetSubtitleUpdatedCb(_handle, _subtitleUpdatedCallback, IntPtr.Zero);
            if (ret != (int)PlayerErrorCode.None)
            {
                Log.Error(PlayerLog.Tag, "Failed to initialize the player, " + (PlayerError)ret);
            }
            PlayerErrorConverter.ThrowIfError(ret, "Failed to initialize the player");
        }

        private void RegisterPlaybackCompletedCallback()
        {
            _playbackCompletedCallback = _ =>
            {
                Log.Debug(PlayerLog.Tag, "completed callback");
                PlaybackCompleted?.Invoke(this, EventArgs.Empty);
            };
            int ret = Interop.Player.SetCompletedCb(_handle, _playbackCompletedCallback, IntPtr.Zero);
            if (ret != (int)PlayerErrorCode.None)
            {
                Log.Error(PlayerLog.Tag, "Failed to set PlaybackCompleted, " + (PlayerError)ret);
            }
            PlayerErrorConverter.ThrowIfError(ret, "Failed to set PlaybackCompleted");
        }

        private void RegisterPlaybackInterruptedCallback()
        {
            _playbackInterruptedCallback = (code, _) =>
            {
                if (!Enum.IsDefined(typeof(PlaybackIntrruptionReason), code))
                {
                    return;
                }
                Log.Warn(PlayerLog.Tag, "interrupted reason : " + code);
                PlaybackInterrupted?.Invoke(this,
                    new PlaybackInterruptedEventArgs((PlaybackIntrruptionReason)code));
            };
            int ret = Interop.Player.SetInterruptedCb(_handle, _playbackInterruptedCallback, IntPtr.Zero);
            if (ret != (int)PlayerErrorCode.None)
            {
                Log.Error(PlayerLog.Tag, "Failed to set PlaybackInterrupted, " + (PlayerError)ret);
            }
            PlayerErrorConverter.ThrowIfError(ret, "Failed to set PlaybackInterrupted");
        }

        private void RegisterErrorOccuuredCallback()
        {
            _playbackErrorCallback = (code, _) =>
            {
                if (!Enum.IsDefined(typeof(PlayerError), code))
                {
                    return;
                }
                //TODO handle service disconnected error.
                Log.Warn(PlayerLog.Tag, "error code : " + code);
                ErrorOccurred?.Invoke(this, new PlayerErrorOccurredEventArgs((PlayerError)code));
            };
            int ret = Interop.Player.SetErrorCb(_handle, _playbackErrorCallback, IntPtr.Zero);
            if (ret != (int)PlayerErrorCode.None)
            {
                Log.Error(PlayerLog.Tag, "Failed to set PlaybackError, " + (PlayerError)ret);
            }
            PlayerErrorConverter.ThrowIfError(ret, "Failed to set PlaybackError");
        }

        private void RegisterVideoFrameDecodedCallback()
        {
            _videoFrameDecodedCallback = (packetHandle,_) =>
            {
                var handler = VideoFrameDecoded;
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

            int ret = Interop.Player.SetVideoFrameDecodedCb(_handle, _videoFrameDecodedCallback, IntPtr.Zero);
            if (ret != (int)PlayerErrorCode.None)
            {
                Log.Error(PlayerLog.Tag, "Failed to set the VideoFrameDecoded, " + (PlayerError)ret);
            }
            PlayerErrorConverter.ThrowIfError(ret, "Failed to register the VideoFrameDecoded");
        }

        private void RegisterVideoStreamChangedCallback()
        {
            ValidatePlayerState(PlayerState.Idle);

            _videoStreamChangedCallback = (width, height, fps, bitrate, _) =>
            {
                Log.Debug(PlayerLog.Tag, "height : " + height + ", width : " + width
                + ", fps : " + fps + ", bitrate : " + bitrate);
                VideoStreamChangedEventArgs eventArgs = new VideoStreamChangedEventArgs(height, width, fps, bitrate);
                VideoStreamChanged?.Invoke(this, eventArgs);
            };
            int ret = Interop.Player.SetVideoStreamChangedCb(GetHandle(), _videoStreamChangedCallback, IntPtr.Zero);
            if (ret != (int)PlayerErrorCode.None)
            {
                Log.Error(PlayerLog.Tag, "Failed to set the video stream changed callback, " + (PlayerError)ret);
            }
            PlayerErrorConverter.ThrowIfError(ret, "Failed to set the video stream changed callback");
        }

        private void RegisterBufferingCallback()
        {
            _bufferingProgressCallback = (percent, _) =>
            {
                Log.Debug(PlayerLog.Tag, $"Buffering callback with percent { percent }");
                BufferingProgressChanged?.Invoke(this, new BufferingProgressChangedEventArgs(percent));
            };

            int ret = Interop.Player.SetBufferingCb(_handle, _bufferingProgressCallback, IntPtr.Zero);
            if (ret != (int)PlayerErrorCode.None)
            {
                Log.Error(PlayerLog.Tag, "Failed to set BufferingProgress, " + (PlayerError)ret);
            }
            PlayerErrorConverter.ThrowIfError(ret, "Failed to set BufferingProgress");
        }

        private void RegisterMediaStreamBufferStatusCallback()
        {
            _mediaStreamAudioBufferStatusChangedCallback = (status, _) =>
            {
                Debug.Assert(Enum.IsDefined(typeof(MediaStreamBufferStatus), status));
                Log.Debug(PlayerLog.Tag, "audio buffer status : " + status);
                MediaStreamAudioBufferStatusChanged?.Invoke(this,
                    new MediaStreamBufferStatusChangedEventArgs((MediaStreamBufferStatus)status));
            };
            _mediaStreamVideoBufferStatusChangedCallback = (status, _) =>
            {
                Debug.Assert(Enum.IsDefined(typeof(MediaStreamBufferStatus), status));
                Log.Debug(PlayerLog.Tag, "video buffer status : " + status);
                MediaStreamVideoBufferStatusChanged?.Invoke(this,
                    new MediaStreamBufferStatusChangedEventArgs((MediaStreamBufferStatus)status));
            };

            RegisterMediaStreamBufferStatusCallback(StreamType.Audio, _mediaStreamAudioBufferStatusChangedCallback);
            RegisterMediaStreamBufferStatusCallback(StreamType.Video, _mediaStreamVideoBufferStatusChangedCallback);
        }

        private void RegisterMediaStreamBufferStatusCallback(StreamType streamType,
            Interop.Player.MediaStreamBufferStatusCallback cb)
        {
            int ret = Interop.Player.SetMediaStreamBufferStatusCb(_handle, (int)streamType,
              cb, IntPtr.Zero);
            if (ret != (int)PlayerErrorCode.None)
            {
                Log.Error(PlayerLog.Tag, "Failed to SetMediaStreamBufferStatus, " + (PlayerError)ret);
            }
            PlayerErrorConverter.ThrowIfError(ret, "Failed to SetMediaStreamBufferStatus");
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

        private void RegisterMediaStreamSeekCallback(StreamType streamType, Interop.Player.MediaStreamSeekCallback cb)
        {
            int ret = Interop.Player.SetMediaStreamSeekCb(_handle, (int)streamType,
                cb, IntPtr.Zero);
            if (ret != (int)PlayerErrorCode.None)
            {
                Log.Error(PlayerLog.Tag, "Failed to SetMediaStreamSeek, " + (PlayerError)ret);
            }
            PlayerErrorConverter.ThrowIfError(ret, "Failed to SetMediaStreamSeek");
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
