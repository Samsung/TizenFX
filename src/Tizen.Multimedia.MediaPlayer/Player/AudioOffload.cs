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
    /// Provides the ability to control the audio offload for <see cref="Multimedia.Player"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class AudioOffload
    {
        private IList<MediaFormatAudioMimeType> _supportedFormat;

        /// <summary>
        /// Gets the <see cref="Multimedia.Player"/> that owns this instance.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Player Player { get; }

        /// <summary>
        /// Provides a means to retrieve audio offload information.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        internal AudioOffload(Player player)
        {
            Debug.Assert(player != null);
            Player = player;
        }

        internal void CheckDisabled()
        {
            if (Features.IsSupported(PlayerFeatures.AudioOffload) && Player.AudioOffload.IsEnabled)
            {
                throw new InvalidOperationException("the audio offload is enabled.");
            }
        }

        /// <summary>
        /// Enables or disables the audio offload.
        /// </summary>
        /// <feature>http://tizen.org/feature/multimedia.player.audio_offload</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">
        ///     Operation failed; internal error.
        /// </exception>
        /// <since_tizen> 6 </since_tizen>
        public bool IsEnabled
        {
            get
            {
                ValidationUtil.ValidateFeatureSupported(PlayerFeatures.AudioOffload);
                Player.ValidateNotDisposed();

                NativePlayer.IsAudioOffloadEnabled(Player.Handle, out var value).
                    ThrowIfFailed(Player, "Failed to get whether the audio offload of the player is enabled or not");
                return value;
            }

            set
            {
                ValidationUtil.ValidateFeatureSupported(PlayerFeatures.AudioOffload);
                Player.ValidateNotDisposed();

                NativePlayer.SetAudioOffloadEnabled(Player.Handle, value).
                    ThrowIfFailed(Player, "Failed to set the audio offload of the player");
            }
        }

        /// <summary>
        /// Get a state whether or not the audio offload is activated.
        /// </summary>
        /// <feature>http://tizen.org/feature/multimedia.player.audio_offload</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">
        ///     Operation failed; internal error.
        /// </exception>
        /// <since_tizen> 6 </since_tizen>
        public bool IsActivated
        {
            get
            {
                ValidationUtil.ValidateFeatureSupported(PlayerFeatures.AudioOffload);
                Player.ValidateNotDisposed();

                NativePlayer.IsAudioOffloadActivated(Player.Handle, out var value).
                    ThrowIfFailed(Player, "Failed to get whether the audio offload of the player is enabled or not");
                return value;
            }
        }

        /// <summary>
        /// Retrieves all formats for audio offload.
        /// </summary>
        /// <returns>
        /// It returns a list contained all formats for audio offload.
        /// </returns>
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

            NativePlayer.SupportedAudioOffloadFormat(Player.Handle, callback, IntPtr.Zero).
                ThrowIfFailed(Player, "Failed to get the supported formats for audio offload");

            return audioFormats.AsReadOnly();
        }
    }
}
