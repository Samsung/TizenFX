/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Diagnostics;
using System.Collections.Generic;
using static Interop;

namespace Tizen.Multimedia
{
    /// <summary>
    /// The class that control the audio offload for <see cref="Multimedia.Player"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class AudioOffload
    {
        private IList<MediaFormatAudioMimeType> _supportedFormat;
        private Player _player { get; }

        /// <summary>
        /// Provides a means to retrieve audio offload information.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        internal AudioOffload(Player player)
        {
            Debug.Assert(player != null);
            _player = player;
        }

        private bool _enabled;
        internal void CheckDisabled()
        {
            if (_enabled)
            {
                throw new NotAvailableException("the audio offload is enabled.");
            }
        }

        /// <summary>
        /// Gets or sets whether the audio offload is enabled.
        /// </summary>
        /// <value>The value indicating whether or not audio offload is enabled. The default value is false.</value>
        /// <remarks><para>The player lets the hardware decode and render the sound if the audio offload is enabled.
        /// Audio offload can reduce the power consumption, but disable the ability to handle output PCM.
        /// Please check the below list of functions which will not work if offloading is enabled.</para>
        /// <para>If audio offload is enabled, the following functions will return <see cref="NotAvailableException"/>: <br/>
        /// <see cref="AudioEffect"/><br/>
        /// <see cref="EqualizerBand"/><br/>
        /// <see cref="PlayerTrackInfo"/><br/>
        /// <see cref="Player.EnableExportingAudioData"/><br/>
        /// <see cref="Player.AudioLatencyMode"/><br/>
        /// <see cref="Player.SetPlaybackRate"/><br/>
        /// <see cref="Player.ReplayGain"/><br/>
        /// <see cref="Player.AudioPitch"/><br/>
        /// <see cref="Player.AudioPitchEnabled"/><br/></para>
        /// <para>Although they are called before offload is enabled, they don't work normally.</para>
        /// <para>To set, the player must be in the <see cref="PlayerState.Idle"/> state.
        /// The sound stream type of the player should be <see cref="AudioStreamType.Media"/>.</para></remarks>
        /// <feature>http://tizen.org/feature/multimedia.player.audio_offload</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The player is not in the valid state.<br/>
        ///     -or-<br/>
        ///     Operation failed; internal error.
        /// </exception>
        /// <since_tizen> 6 </since_tizen>
        public bool IsEnabled
        {
            get
            {
                ValidationUtil.ValidateFeatureSupported(PlayerFeatures.AudioOffload);
                _player.ValidateNotDisposed();

                NativePlayer.IsAudioOffloadEnabled(_player.Handle, out var value).
                    ThrowIfFailed(_player, "Failed to get whether the audio offload of the player is enabled or not");
                return value;
            }

            set
            {
                ValidationUtil.ValidateFeatureSupported(PlayerFeatures.AudioOffload);
                _player.ValidateNotDisposed();
                _player.ValidatePlayerState(PlayerState.Idle);

                NativePlayer.SetAudioOffloadEnabled(_player.Handle, value).
                    ThrowIfFailed(_player, "Failed to set the audio offload of the player");
                _enabled = value;
            }
        }

        /// <summary>
        /// Get a value indication whether or not the audio offload is activated.
        /// </summary>
        /// <value>The value indicating whether or not AudioOffload is activated.</value>
        /// <remarks>
        /// Audio offload could be inactivated depending on the audio device capability even though the audio offload feature is supported.
        /// The <see cref="Player"/> that owns this instance must be in the <see cref="PlayerState.Ready"/>,
        /// <see cref="PlayerState.Playing"/>, or <see cref="PlayerState.Paused"/> state.
        /// </remarks>
        /// <feature>http://tizen.org/feature/multimedia.player.audio_offload</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The player is not in the valid state.<br/>
        ///     -or-<br/>
        ///     Operation failed; internal error.
        /// </exception>
        /// <since_tizen> 6 </since_tizen>
        public bool IsActivated
        {
            get
            {
                ValidationUtil.ValidateFeatureSupported(PlayerFeatures.AudioOffload);
                _player.ValidateNotDisposed();
                _player.ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);

                NativePlayer.IsAudioOffloadActivated(_player.Handle, out var value).
                    ThrowIfFailed(_player, "Failed to get whether the audio offload of the player is enabled or not");
                return value;
            }
        }

        /// <summary>
        /// Retrieves the supported audio formats for audio offload.
        /// </summary>
        /// <returns>
        /// It returns a list containing supported audio formats for audio offload.
        /// </returns>
        /// <remarks>The supported media format can vary depending on the device capabilities.</remarks>
        /// <feature>http://tizen.org/feature/multimedia.player.audio_offload</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="Player"/> has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">
        ///     Operation failed; internal error.
        /// </exception>
        /// <seealso cref="MediaFormatAudioMimeType"/>
        /// <since_tizen> 6 </since_tizen>
        public IEnumerable<MediaFormatAudioMimeType> SupportedFormats
        {
            get
            {
                if (_supportedFormat == null)
                {
                    _supportedFormat = GetSupportedFormats();
                }

                return _supportedFormat;
            }
        }

        private IList<MediaFormatAudioMimeType> GetSupportedFormats()
        {
            List<MediaFormatAudioMimeType> audioFormats = new List<MediaFormatAudioMimeType>();

            NativePlayer.SupportedMediaFormatCallback callback = (int format, IntPtr userData) =>
            {
                if (!Enum.IsDefined(typeof(MediaFormatAudioMimeType), format))
                {
                    Log.Warn(PlayerLog.Tag, "not supported : " + format.ToString());
                    return false;
                }

                Log.Debug(PlayerLog.Tag, "supported : " + ((MediaFormatAudioMimeType)format).ToString());
                audioFormats.Add((MediaFormatAudioMimeType)format);
                return true;
            };

            NativePlayer.SupportedAudioOffloadFormat(_player.Handle, callback, IntPtr.Zero).
                ThrowIfFailed(_player, "Failed to get the supported formats for audio offload");

            return audioFormats.AsReadOnly();
        }
    }
}
