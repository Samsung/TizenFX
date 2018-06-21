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
using NativeDisplay = Interop.Display;
using static Interop;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Represents properties for streaming buffering time
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public struct PlayerBufferingTime
    {
        /// <summary>
        /// Initializes a new instance of the PlayerBufferingTime struct.
        /// </summary>
        /// <param name="preBufferMs">A duration of buffering data that must be prerolled to start playback.</param>
        /// <param name="reBufferMs">A duration of buffering data that must be prerolled to resume playback
        /// if player enters pause state for buffering.</param>
        /// <since_tizen> 5 </since_tizen>
        public PlayerBufferingTime(int preBufferMs, int reBufferMs)
        {
            PreBufferMs = preBufferMs;
            ReBufferMs = reBufferMs;
        }

        /// <summary>
        /// Gets or sets the duration of buffering data that must be prerolled to start playback
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public int PreBufferMs
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the duration of buffering data that must be prerolled to resume playback
        /// if player enters pause state for buffering.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public int ReBufferMs
        {
            get;
            set;
        }
    }
    /// <since_tizen> 3 </since_tizen>
    public partial class Player
    {
        /// <summary>
        /// Gets the native handle of the player.
        /// </summary>
        /// <value>An IntPtr that contains the native handle of the player.</value>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public IntPtr Handle
        {
            get
            {
                ValidateNotDisposed();
                return _handle.DangerousGetHandle();
            }
        }

        #region Network configuration
        private string _cookie = "";
        private string _userAgent = "";

        /// <summary>
        /// Gets or sets the cookie for streaming playback.
        /// </summary>
        /// <remarks>To set, the player must be in the <see cref="PlayerState.Idle"/> state.</remarks>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="ArgumentNullException">The value to set is null.</exception>
        /// <since_tizen> 3 </since_tizen>
        public string Cookie
        {
            get
            {
                return _cookie;
            }
            set
            {
                ValidatePlayerState(PlayerState.Idle);

                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Cookie can't be null.");
                }

                NativePlayer.SetStreamingCookie(Handle, value, value.Length).
                    ThrowIfFailed(this, "Failed to set the cookie to the player");

                _cookie = value;
            }
        }

        /// <summary>
        /// Gets or sets the user agent for streaming playback.
        /// </summary>
        /// <remarks>To set, the player must be in the <see cref="PlayerState.Idle"/> state.</remarks>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="ArgumentNullException">The value to set is null.</exception>
        /// <since_tizen> 3 </since_tizen>
        public string UserAgent
        {
            get
            {
                return _userAgent;
            }
            set
            {
                ValidatePlayerState(PlayerState.Idle);

                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "UserAgent can't be null.");
                }

                NativePlayer.SetStreamingUserAgent(Handle, value, value.Length).
                    ThrowIfFailed(this, "Failed to set the user agent to the player");

                _userAgent = value;
            }
        }

        /// <summary>
        /// Gets or sets the streaming buffering time.
        /// </summary>
        /// <remarks>To set, the player must be in the <see cref="PlayerState.Idle"/> state.</remarks>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <pramref name="PreBufferMs"/> is less than 0.<br/>
        ///     -or-<br/>
        ///     <pramref name="ReBufferMs"/> is less than 0.<br/>
        /// </exception>
        /// <exception cref="ArgumentException">The value is not valid.</exception>
        /// <seealso cref="PlayerBufferingTime"/>
        /// <since_tizen> 5 </since_tizen>
        public PlayerBufferingTime BufferingTime
        {
            get
            {
                ValidateNotDisposed();

                NativePlayer.GetStreamingBufferingTime(Handle, out var PreBuffMs, out var ReBuffMs).
                        ThrowIfFailed(this, "Failed to get the buffering time of the player");

                return new PlayerBufferingTime(PreBuffMs, ReBuffMs);
            }
            set
            {
                ValidatePlayerState(PlayerState.Idle);

                if (value.PreBufferMs < 0 || value.ReBufferMs < 0)
                {
                    throw new ArgumentOutOfRangeException("invalid range");
                }

                NativePlayer.SetStreamingBufferingTime(Handle, value.PreBufferMs, value.ReBufferMs).
                    ThrowIfFailed(this, "Failed to set the buffering time of the player");
            }
        }
        #endregion

        /// <summary>
        /// Gets the state of the player.
        /// </summary>
        /// <value>The current state of the player.</value>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public PlayerState State
        {
            get
            {
                ValidateNotDisposed();

                if (IsPreparing())
                {
                    return PlayerState.Preparing;
                }

                NativePlayer.GetState(Handle, out var state).
                    ThrowIfFailed(this, "Failed to retrieve the state of the player");

                Debug.Assert(Enum.IsDefined(typeof(PlayerState), state));

                return (PlayerState)state;
            }
        }

        /// <summary>
        /// Gets or sets the audio latency mode.
        /// </summary>
        /// <value>A <see cref="AudioLatencyMode"/> that specifies the mode. The default is <see cref="AudioLatencyMode.Mid"/>.</value>
        /// <remarks>
        /// If the mode is <see cref="AudioLatencyMode.High"/>,
        /// audio output interval can be increased, so it can keep more audio data to play.
        /// But, state transition like pause or resume can be more slower than default(<see cref="AudioLatencyMode.Mid"/>).
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="ArgumentException">The value is not valid.</exception>
        /// <since_tizen> 3 </since_tizen>
        public AudioLatencyMode AudioLatencyMode
        {
            get
            {
                NativePlayer.GetAudioLatencyMode(Handle, out var value).
                    ThrowIfFailed(this, "Failed to get the audio latency mode of the player");

                return value;
            }
            set
            {
                ValidateNotDisposed();

                ValidationUtil.ValidateEnum(typeof(AudioLatencyMode), value, nameof(value));

                NativePlayer.SetAudioLatencyMode(Handle, value).
                    ThrowIfFailed(this, "Failed to set the audio latency mode of the player");
            }
        }

        /// <summary>
        /// Gets or sets the looping state.
        /// </summary>
        /// <value>true if the playback is looping; otherwise, false. The default value is false.</value>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public bool IsLooping
        {
            get
            {
                NativePlayer.IsLooping(Handle, out var value).
                    ThrowIfFailed(this, "Failed to get the looping state of the player");

                return value;
            }
            set
            {
                ValidateNotDisposed();

                NativePlayer.SetLooping(Handle, value).
                    ThrowIfFailed(this, "Failed to set the looping state of the player");
            }
        }

        #region Display methods

        private PlayerDisplaySettings _displaySettings;

        /// <summary>
        /// Gets the display settings.
        /// </summary>
        /// <value>A <see cref="PlayerDisplaySettings"/> that specifies the display settings.</value>
        /// <since_tizen> 3 </since_tizen>
        public PlayerDisplaySettings DisplaySettings => _displaySettings;

        private Display _display;

        private PlayerErrorCode SetDisplay(Display display)
        {
            if (display == null)
            {
                return NativeDisplay.SetDisplay(Handle, PlayerDisplayType.None, IntPtr.Zero);
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
        /// <remarks>
        ///     The player must be in the <see cref="PlayerState.Idle"/> state.<br/>
        ///     The raw video feature(http://tizen.org/feature/multimedia.raw_video) is required if
        ///     the display is created with <see cref="MediaView"/>.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="ArgumentException">The value has already been assigned to another player.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 3 </since_tizen>
        public Display Display
        {
            get
            {
                return _display;
            }
            set
            {
                ValidatePlayerState(PlayerState.Idle);

                if (value != null && value.HasMediaView)
                {
                    ValidationUtil.ValidateFeatureSupported(PlayerFeatures.RawVideo);
                }

                if (value?.Owner != null)
                {
                    if (ReferenceEquals(this, value.Owner))
                    {
                        return;
                    }

                    throw new ArgumentException("The display has already been assigned to another.");
                }

                SetDisplay(value).ThrowIfFailed(this, "Failed to configure display of the player");

                ReplaceDisplay(value);
            }
        }

        PlayerErrorCode IDisplayable<PlayerErrorCode>.ApplyEvasDisplay(DisplayType type, ElmSharp.EvasObject evasObject)
        {
            Debug.Assert(IsDisposed == false);

            Debug.Assert(Enum.IsDefined(typeof(DisplayType), type));
            Debug.Assert(type != DisplayType.None);

            return NativeDisplay.SetDisplay(Handle,
                type == DisplayType.Overlay ? PlayerDisplayType.Overlay : PlayerDisplayType.Evas, evasObject);
        }

        PlayerErrorCode IDisplayable<PlayerErrorCode>.ApplyEcoreWindow(IntPtr windowHandle)
        {
            Debug.Assert(IsDisposed == false);

            return NativeDisplay.SetEcoreDisplay(Handle, PlayerDisplayType.Overlay, windowHandle);
        }
        #endregion

        private PlayerTrackInfo _audioTrack;

        /// <summary>
        /// Gets the track info for the audio.
        /// </summary>
        /// <value>A <see cref="PlayerTrackInfo"/> for audio.</value>
        /// <since_tizen> 3 </since_tizen>
        public PlayerTrackInfo AudioTrackInfo
        {
            get
            {
                if (_audioTrack == null)
                {
                    _audioTrack = new PlayerTrackInfo(this, StreamType.Audio);
                }
                return _audioTrack;
            }
        }

        private PlayerTrackInfo _subtitleTrackInfo;

        /// <summary>
        /// Gets the track info for the subtitle.
        /// </summary>
        /// <value>A <see cref="PlayerTrackInfo"/> for the subtitle.</value>
        /// <since_tizen> 3 </since_tizen>
        public PlayerTrackInfo SubtitleTrackInfo
        {
            get
            {
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
        /// <since_tizen> 3 </since_tizen>
        public StreamInfo StreamInfo
        {
            get
            {
                if (_streamInfo == null)
                {
                    _streamInfo = new StreamInfo(this);
                }
                return _streamInfo;
            }
        }

        private AudioEffect _audioEffect;

        /// <summary>
        /// Gets the audio effect.
        /// </summary>
        /// <feature>http://tizen.org/feature/multimedia.custom_audio_effect</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 3 </since_tizen>
        public AudioEffect AudioEffect
        {
            get
            {
                if (_audioEffect == null)
                {
                    throw new NotSupportedException($"The feature({PlayerFeatures.AudioEffect}) is not supported.");
                }

                return _audioEffect;
            }
        }

        /// <summary>
        /// Gets or sets the mute state.
        /// </summary>
        /// <value>true if the player is muted; otherwise, false.</value>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public bool Muted
        {
            get
            {
                NativePlayer.IsMuted(Handle, out var value).
                    ThrowIfFailed(this, "Failed to get the mute state of the player");

                Log.Info(PlayerLog.Tag, "get mute : " + value);

                return value;
            }
            set
            {
                NativePlayer.SetMute(Handle, value).ThrowIfFailed(this, "Failed to set the mute state of the player");
            }
        }

        /// <summary>
        /// Gets or sets the current volume.
        /// </summary>
        /// <remarks>Valid volume range is from 0 to 1.0, inclusive.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="value"/> is less than zero.<br/>
        ///     -or-<br/>
        ///     <paramref name="value"/> is greater than 1.0.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public float Volume
        {
            get
            {
                float value = 0.0F;
                NativePlayer.GetVolume(Handle, out value, out value).
                    ThrowIfFailed(this, "Failed to get the volume of the player");

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
                    ThrowIfFailed(this, "Failed to set the volume of the player");
            }
        }

        /// <summary>
        /// Gets or sets the audio-only state.
        /// </summary>
        /// <value>true if the playback is audio-only mode; otherwise, false. The default value is false.</value>
        /// The <see cref="Player"/> must be in the <see cref="PlayerState.Ready"/>,
        /// <see cref="PlayerState.Playing"/>, or <see cref="PlayerState.Paused"/> state.
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <since_tizen> 5 </since_tizen>
        public bool IsAudioOnly
        {
            get
            {
                ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);
                NativePlayer.IsAudioOnly(Handle, out var value).
                    ThrowIfFailed(this, "Failed to get the audio-only state of the player");
                return value;
            }
            set
            {
                ValidateNotDisposed();
                ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);
                NativePlayer.SetAudioOnly(Handle, value).
                    ThrowIfFailed(this, "Failed to set the audio-only state of the player");
            }
        }

        private SphericalVideo _sphericalVideo;

        /// <summary>
        /// Gets the spherical video settings.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public SphericalVideo SphericalVideo
        {
            get
            {
                if (_sphericalVideo == null)
                {
                    _sphericalVideo = new SphericalVideo(this);
                }

                return _sphericalVideo;
            }
        }

        private AdaptiveVariants _adaptiveVariants;

        /// <summary>
        /// Gets the adaptive variants settings.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public AdaptiveVariants AdaptiveVariants
        {
            get
            {
                if (_adaptiveVariants == null)
                {
                    _adaptiveVariants = new AdaptiveVariants(this);
                }

                return _adaptiveVariants;
            }
        }
    }
}
