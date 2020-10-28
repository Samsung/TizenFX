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

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides data for the <see cref="MediaController.PlaylistUpdated"/> event.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class PlaylistUpdatedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistUpdatedEventArgs"/> class.
        /// </summary>
        /// <param name="mode">A value indicating the updated repeat mode.</param>
        /// <param name="name">A value indicating the playlist name.</param>
        /// <exception cref="ArgumentException"><paramref name="mode"/> is invalid.</exception>
        /// <since_tizen> 5 </since_tizen>
        public PlaylistUpdatedEventArgs(MediaControlPlaylistMode mode, string name)
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlPlaylistMode), mode, nameof(mode));

            Mode = mode;
            Name = name;
        }

        /// <summary>
        /// Gets the updated playlist mode.
        /// </summary>
        /// <remarks>
        /// If The <see cref="Mode"/> is <see cref="MediaControlPlaylistMode.Updated"/>,
        /// Retrieves the playlist using <see cref="Name"/> and call <see cref="MediaControlPlaylist.Update"/> to keep the playlist up to date.
        /// </remarks>
        /// <value>The <see cref="MediaControlPlaylistMode"/>.</value>
        /// <since_tizen> 5 </since_tizen>
        public MediaControlPlaylistMode Mode { get; }

        /// <summary>
        /// Gets the playlist name.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string Name { get; }
    }
}
