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
    public partial class Player
    {
        private void RetrieveProperties()
        {
            NativePlayer.GetAudioLatencyMode(Handle, out _audioLatencyMode).
                ThrowIfFailed("Failed to initialize the player");

            NativePlayer.IsLooping(Handle, out _isLooping).ThrowIfFailed("Failed to initialize the player");
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
                ValidatePlayerState(PlayerState.Idle);

                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Cookie can't be null.");
                }

                NativePlayer.SetStreamingCookie(Handle, value, value.Length).
                    ThrowIfFailed("Failed to set the cookie to the player");

                _cookie = value;
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
                ValidatePlayerState(PlayerState.Idle);

                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "UserAgent can't be null.");
                }

                NativePlayer.SetStreamingUserAgent(Handle, value, value.Length).
                    ThrowIfFailed("Failed to set the user agent to the player");

                _userAgent = value;
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

                NativePlayer.GetState(Handle, out var state).ThrowIfFailed("Failed to retrieve the state of the player");

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

        /// <summary>
        /// Gets or sets the mute state.
        /// </summary>
        /// <value>true if the player is muted; otherwise, false.</value>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        public bool Muted
        {
            get
            {
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
    }
}
