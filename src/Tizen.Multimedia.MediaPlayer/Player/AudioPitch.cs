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
using static Interop;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides the ability to control a audio pitch for <see cref="Multimedia.Player"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class AudioPitch
    {
        /// <summary>
        /// Gets the <see cref="Multimedia.Player"/> that owns this instance.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Player Player { get; }

        /// <summary>
        /// Provides the means to retrieve audio pitch information.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        internal AudioPitch(Player player)
        {
            Debug.Assert(player != null);
            Player = player;
        }

        /// <summary>
        /// Gets or sets the audio pitch.
        /// </summary>
        /// <remarks>This function is used for audio content only.</remarks>
        /// <remarks>To set, the player must be in the <see cref="PlayerState.Idle"/> state.</remarks>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <since_tizen> 6 </since_tizen>
        public bool IsEnabled
        {
            get
            {
                Player.ValidateNotDisposed();
                NativePlayer.IsAudioPitchEnabled(Player.Handle, out var value).
                    ThrowIfFailed(Player, "Failed to get whether the audio pitch is enabled or not");
                return value;
            }

            set
            {
                Player.ValidateNotDisposed();
                Player.ValidatePlayerState(PlayerState.Idle);

                NativePlayer.SetAudioPitchEnabled(Player.Handle, value).
                    ThrowIfFailed(Player, "Failed to enable the audio pitch of the player");
            }
        }

        /// <summary>
        /// Gets the audio pitch value.
        /// </summary>
        /// <returns>The pitch value of an audio stream. The default value is 1.</returns>
        /// <remarks>This function is used for audio content only.</remarks>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <seealso cref="IsEnabled"/>
        /// <seealso cref="SetValue(float)"/>
        /// <since_tizen> 6 </since_tizen>
        public float GetValue()
        {
            Player.ValidateNotDisposed();

            if (Player.AudioPitch.IsEnabled == false)
                throw new InvalidOperationException("A pitch is not enabled.");

            NativePlayer.GetAudioPitch(Player.Handle, out var value).
                ThrowIfFailed(Player, "Failed to get the audio pitch");

            return value;
        }

        /// <summary>
        /// Sets the audio pitch value.
        /// </summary>
        /// <param name="value">The pitch value of an audio stream. The default value is 1.</param>
        /// <remarks>This function is used for audio content only.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <pramref name="value"/> is less than 0.5.
        ///     -or-<br/>
        ///     <paramref name="value"/> is greater than 2.0.<br/>
        /// </exception>
        /// <seealso cref="IsEnabled"/>
        /// <seealso cref="GetValue()"/>
        /// <since_tizen> 6 </since_tizen>
        public void SetValue(float value)
        {
            Player.ValidateNotDisposed();

            if (Player.AudioPitch.IsEnabled == false)
                throw new InvalidOperationException("A audio pitch is not enabled.");

            if (value < 0.5F || 2.0F < value)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, "Valid level is 1.0 to 10.0");
            }

            NativePlayer.SetAudioPitch(Player.Handle, value).ThrowIfFailed(Player, "Failed to set the audio pitch");
        }
    }
}
