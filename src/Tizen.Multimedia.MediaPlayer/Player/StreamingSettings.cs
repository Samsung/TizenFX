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
using System.Diagnostics;
using static Interop;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Represents properties for streaming buffering time
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public struct StreamingBufferingTime
    {
        /// <summary>
        /// Initializes a new instance of the StreamingBufferingTime struct.
        /// </summary>
        /// <param name="preBuffMs">The buffer time to start playback.</param>
        /// <param name="reBuffMs">The buffer time during playback if player enter pause state for buffering.</param>
        /// <since_tizen> 5 </since_tizen>
        public StreamingBufferingTime(int preBuffMs, int reBuffMs)
        {
            PreBuffMs = preBuffMs;
            ReBuffMs = reBuffMs;
        }

        /// <summary>
        /// Gets or sets the buffer time to start playback.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public int PreBuffMs
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the buffer time during playback if player enter pause state for buffering.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public int ReBuffMs
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Provides the ability to control the streaming settings for <see cref="Multimedia.Player"/>.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class StreamingSettings
    {
        /// <summary>
        /// Gets the <see cref="Multimedia.Player"/> that owns this instance.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        private readonly Player Player;

        internal StreamingSettings(Player player)
        {
            Debug.Assert(player != null);
            Player = player;
        }

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
                Player.ValidatePlayerState(PlayerState.Idle);

                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Cookie can't be null.");
                }

                NativePlayer.SetStreamingCookie(Player.Handle, value, value.Length).
                    ThrowIfFailed(Player, "Failed to set the cookie to the player");

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
                Player.ValidatePlayerState(PlayerState.Idle);

                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "UserAgent can't be null.");
                }

                NativePlayer.SetStreamingUserAgent(Player.Handle, value, value.Length).
                    ThrowIfFailed(Player, "Failed to set the user agent to the player");

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
        ///     <pramref name="PreBuffMs"/> is less than 0.<br/>
        ///     -or-<br/>
        ///     <pramref name="ReBuffMs"/> is less than 0.<br/>
        /// </exception>
        /// <exception cref="ArgumentException">The value is not valid.</exception>
        /// <seealso cref="StreamingBufferingTime"/>
        /// <since_tizen> 5 </since_tizen>
        public StreamingBufferingTime BuffTime
        {
            get
            {
                Player.ValidateNotDisposed();

                NativePlayer.GetStreamingBufferingTime(Player.Handle, out var PreBuffMs, out var ReBuffMs).
                        ThrowIfFailed(Player, "Failed to get the buffering time of the player");

                return new StreamingBufferingTime(PreBuffMs, ReBuffMs);
            }
            set
            {
                Player.ValidatePlayerState(PlayerState.Idle);

                if (value.PreBuffMs < 0 || value.ReBuffMs < 0)
                {
                    throw new ArgumentOutOfRangeException("invalid range");
                }

                NativePlayer.SetStreamingBufferingTime(Player.Handle, value.PreBuffMs, value.ReBuffMs).
                    ThrowIfFailed(Player, "Failed to set the buffering time of the player");
            }
        }
    }
}
