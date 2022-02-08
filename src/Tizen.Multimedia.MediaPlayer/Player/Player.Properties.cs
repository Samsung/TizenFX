/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// Represents properties for streaming buffering time.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public struct PlayerBufferingTime
    {
        /// <summary>
        /// Initializes a new instance of the PlayerBufferingTime struct.
        /// </summary>
        /// <param name="preBufferMillisecond">A duration of buffering data that must be prerolled to start playback.</param>
        /// Except 0 and -1, setting at least 1000 milliseconds is recommended to ensure the normal buffering operation.
        /// 0 : use platform default value which could be different depending on the streaming type and network status. (the initial value)
        /// -1 : use current value. (since 5.5)
        /// <param name="reBufferMillisecond">A duration of buffering data that must be prerolled to resume playback,
        /// when player is internally paused for buffering.
        /// Except 0 and -1, setting at least 1000 milliseconds is recommended to ensure the normal buffering operation.
        /// 0 : use platform default value, which depends on the streaming type and network status. It is set as the initial value of this parameter.
        /// If the player state is <see cref="PlayerState.Playing"/> or <see cref="PlayerState.Paused"/>,
        /// this function will return correct time value instead of 0. (since 5.5)
        /// -1 : use current value. (since 5.5)</param>
        /// <since_tizen> 5 </since_tizen>
        public PlayerBufferingTime(int preBufferMillisecond = -1, int reBufferMillisecond = -1)
        {
            PreBufferMillisecond = preBufferMillisecond;
            ReBufferMillisecond = reBufferMillisecond;
        }

        /// <summary>
        /// Gets or sets the duration of buffering data that must be prerolled to start playback.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public int PreBufferMillisecond
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the duration of buffering data that must be prerolled to resume playback
        /// if player enters pause state for buffering.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public int ReBufferMillisecond
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
        private const int MinBufferingTime = -1;

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
        ///     <pramref name="PreBufferMillisecond"/> is less than -1.<br/>
        ///     -or-<br/>
        ///     <pramref name="ReBufferMillisecond"/> is less than -1.<br/>
        /// </exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <seealso cref="PlayerBufferingTime"/>
        /// <since_tizen> 5 </since_tizen>
        public PlayerBufferingTime BufferingTime
        {
            get
            {
                ValidateNotDisposed();

                NativePlayer.GetStreamingBufferingTime(Handle, out var PreBuffMillisecond, out var ReBuffMillisecond).
                        ThrowIfFailed(this, "Failed to get the buffering time of the player");

                return new PlayerBufferingTime(PreBuffMillisecond, ReBuffMillisecond);
            }
            set
            {
                ValidatePlayerState(PlayerState.Idle);

                if (value.PreBufferMillisecond < MinBufferingTime || value.ReBufferMillisecond < MinBufferingTime)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        $"invalid range, got { value.PreBufferMillisecond }, { value.ReBufferMillisecond }.");
                }

                NativePlayer.SetStreamingBufferingTime(Handle, value.PreBufferMillisecond, value.ReBufferMillisecond).
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
        /// <exception cref="NotAvailableException">
        ///     If audio offload is enabled by calling <see cref="AudioOffload.IsEnabled"/>. (Since tizen 6.0)
        /// </exception>
        /// <seealso cref="AudioOffload"/>
        /// <since_tizen> 3 </since_tizen>
        public AudioLatencyMode AudioLatencyMode
        {
            get
            {
                AudioOffload.CheckDisabled();

                NativePlayer.GetAudioLatencyMode(Handle, out var value).
                    ThrowIfFailed(this, "Failed to get the audio latency mode of the player");

                return value;
            }
            set
            {
                ValidateNotDisposed();
                AudioOffload.CheckDisabled();

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

        private bool _uiSync;

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
        ///     the display is created with <see cref="MediaView"/>.<br/>
        ///     If a user wants to use video and UI sync mode, please use <see cref="Tizen.Multimedia.Display(NUI.Window, bool)"/>.(Since tizen 6.5)<br/>
        ///     But <see cref="Tizen.Multimedia.Player.DisplaySettings"/> is not supported in UI sync mode.
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

                _uiSync = value?.UiSync ?? false;

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

            return NativeDisplay.SetEcoreDisplay(Handle,
                _uiSync ? PlayerDisplayType.OverlayUISync : PlayerDisplayType.Overlay, windowHandle);
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

        /// <summary>
        /// Gets or sets the player's replaygain state.
        /// </summary>
        /// <value>If the replaygain status is true, replaygain is applied (if contents has a replaygain tag);
        /// otherwise, the replaygain is not affected by tag and properties.</value>
        /// <remarks>This function could be unavailable depending on the audio codec type.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The player is not in the valid state.
        /// </exception>
        /// <exception cref="NotAvailableException">If audio offload is enabled by calling <see cref="AudioOffload.IsEnabled"/>. (Since tizen 6.0)
        ///     -or-<br/>
        ///     The function is not available depending on the audio codec type. (Since tizen 6.0)
        /// </exception>
        /// <seealso cref="AudioOffload"/>
        /// <seealso cref="AudioCodecType"/>
        /// <since_tizen> 5 </since_tizen>
        public bool ReplayGain
        {
            get
            {
                ValidateNotDisposed();
                AudioOffload.CheckDisabled();

                NativePlayer.IsReplayGain(Handle, out var value).
                    ThrowIfFailed(this, "Failed to get the replaygain of the player");
                return value;
            }
            set
            {
                ValidateNotDisposed();
                AudioOffload.CheckDisabled();

                NativePlayer.SetReplayGain(Handle, value).
                    ThrowIfFailed(this, "Failed to set the replaygain of the player");
            }
        }

        /// <summary>
        /// Enables or disables controlling the pitch of audio.
        /// Gets the status of controlling the pitch of audio.
        /// </summary>
        /// <value>The value indicating whether or not AudioPitch is enabled. The default is false.</value>
        /// <remarks>This function is used for audio content only.
        /// To set, the player must be in the <see cref="PlayerState.Idle"/> state.
        /// This function could be unavailable depending on the audio codec type.</remarks>
        /// <exception cref="InvalidOperationException">
        ///     The player is not in the valid state.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="NotAvailableException">If audio offload is enabled by calling <see cref="AudioOffload.IsEnabled"/>. (Since tizen 6.0)
        ///     -or-<br/>
        ///     The function is not available depending on the audio codec type. (Since tizen 6.0)
        /// </exception>
        /// <seealso cref="AudioPitch"/>
        /// <seealso cref="AudioOffload"/>
        /// <seealso cref="AudioCodecType"/>
        /// <since_tizen> 6 </since_tizen>
        public bool AudioPitchEnabled
        {
            get
            {
                ValidateNotDisposed();
                AudioOffload.CheckDisabled();

                NativePlayer.IsAudioPitchEnabled(Handle, out var value).
                    ThrowIfFailed(this, "Failed to get whether the audio pitch is enabled or not");
                return value;
            }

            set
            {
                ValidateNotDisposed();
                AudioOffload.CheckDisabled();
                ValidatePlayerState(PlayerState.Idle);

                NativePlayer.SetAudioPitchEnabled(Handle, value).
                    ThrowIfFailed(this, "Failed to enable the audio pitch of the player");
            }
        }

        /// <summary>
        /// Gets or sets the pitch of audio.
        /// </summary>
        /// <value>The audio stream pitch value. The default is 1.</value>
        /// <remarks>Enabling pitch control could increase the CPU usage on some devices.
        /// This function is used for audio content only.
        /// This function could be unavailable depending on the audio codec type.</remarks>
        /// <exception cref="InvalidOperationException">
        ///     A pitch is not enabled.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     value is less than 0.5.
        ///     -or-<br/>
        ///     value is greater than 2.0.
        /// </exception>
        /// <exception cref="NotAvailableException">If audio offload is enabled by calling <see cref="AudioOffload.IsEnabled"/>. (Since tizen 6.0)
        ///     -or-<br/>
        ///     The function is not available depending on the audio codec type. (Since tizen 6.0)
        /// </exception>
        /// <seealso cref="AudioPitchEnabled"/>
        /// <seealso cref="AudioOffload"/>
        /// <seealso cref="AudioCodecType"/>
        /// <since_tizen> 6 </since_tizen>
        public float AudioPitch
        {
            get
            {
                ValidateNotDisposed();
                AudioOffload.CheckDisabled();

                if (AudioPitchEnabled == false)
                {
                    throw new InvalidOperationException("An audio pitch is not enabled.");
                }

                NativePlayer.GetAudioPitch(Handle, out var value).
                    ThrowIfFailed(this, "Failed to get the audio pitch");

                return value;
            }

            set
            {
                ValidateNotDisposed();
                AudioOffload.CheckDisabled();

                if (AudioPitchEnabled == false)
                {
                    throw new InvalidOperationException("An audio pitch is not enabled.");
                }

                if (value < 0.5F || 2.0F < value)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Valid value is 0.5 to 2.0");
                }

                NativePlayer.SetAudioPitch(Handle, value).ThrowIfFailed(this, "Failed to set the audio pitch");
            }
        }

        /// <summary>
        /// Gets or sets the default codec type of the audio decoder.
        /// </summary>
        /// <value>A <see cref="CodecType"/> specifies the type.
        /// The default codec type could be different depending on the device capability.</value>
        /// <remarks>
        /// <para>To set, the player must be in the <see cref="PlayerState.Idle"/> state.</para>
        /// <para>If H/W audio codec type is not supported in some cases, S/W audio codec type could be used instead.</para>
        /// <para>The availability could be changed depending on the codec capability.
        /// If an application wants to use the H/W audio codec type as default,
        /// The following functions should be called after the codec type is set. :<br/>
        /// <see cref="AudioEffect.IsAvailable"/><br/>
        /// <see cref="EnableExportingAudioData"/><br/>
        /// <see cref="DisableExportingAudioData"/><br/>
        /// <see cref="ReplayGain"/><br/>
        /// <see cref="AudioPitch"/><br/>
        /// <see cref="AudioPitchEnabled"/><br/></para>
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="ArgumentException">The value is not valid.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The player is not in the valid state.
        ///     -or-<br/>
        ///     Operation failed; internal error.
        /// </exception>
        /// <exception cref="CodecNotSupportedException">The selected codec is not supported.</exception>
        /// <since_tizen> 6 </since_tizen>
        public CodecType AudioCodecType
        {
            get
            {
                ValidateNotDisposed();

                NativePlayer.GetAudioCodecType(Handle, out var value).
                    ThrowIfFailed(this, "Failed to get the type of the audio codec");

                return value;
            }
            set
            {
                ValidateNotDisposed();
                ValidatePlayerState(PlayerState.Idle);

                ValidationUtil.ValidateEnum(typeof(CodecType), value, nameof(value));

                NativePlayer.SetAudioCodecType(Handle, value).
                    ThrowIfFailed(this, "Failed to set the type of the audio codec");
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

        private AudioOffload _audioOffload;

        /// <summary>
        /// Gets the setting for audio offload.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public AudioOffload AudioOffload
        {
            get
            {
                if (_audioOffload == null)
                {
                    _audioOffload = new AudioOffload(this);
                }

                return _audioOffload;
            }
        }
    }
}
