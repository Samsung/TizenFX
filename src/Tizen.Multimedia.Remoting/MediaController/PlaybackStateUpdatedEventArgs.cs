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
using System.Diagnostics;
using Native = Interop.MediaControllerClient;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides data for the <see cref="MediaController.PlaybackStateUpdated"/> event.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class PlaybackStateUpdatedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaybackStateUpdatedEventArgs"/> class.
        /// </summary>
        /// <param name="state">The playback state.</param>
        /// <param name="position">The playback position in milliseconds.</param>
        /// <exception cref="ArgumentException"><paramref name="state"/> is invalid.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="position"/> is less than zero.</exception>
        /// <since_tizen> 4 </since_tizen>
        public PlaybackStateUpdatedEventArgs(MediaControlPlaybackState state, long position)
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlPlaybackState), state, nameof(state));

            if (position < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(position), position, "position can't be less than zero.");
            }

            State = state;
            Position = position;
        }

        /// <summary>
        /// Gets the playback state.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public MediaControlPlaybackState State { get; }

        /// <summary>
        /// Gets the playback position in milliseconds.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public long Position { get; }
    }
}