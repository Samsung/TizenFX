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
using System.Collections.Generic;
using Native = Interop.MediaControllerClient;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Represents playlist for media control.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public abstract class Playlist
    {
        internal Playlist() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Playlist"/> class.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        internal Playlist(string name, string index, ulong position)
        {
            Index = index ?? throw new ArgumentNullException("Playlist index is not valid to convert number.");
            if (!Int32.TryParse(index, out int result))
            {
                throw new ArgumentException("Playlist index is not vaild to convert to number.");
            }

            Name = name ?? throw new ArgumentNullException("Playlist name is not set.");
            Position = position;
        }

        /// <summary>
        /// Gets or sets the index of the media in the playist.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string Index { get; protected set; }

        /// <summary>
        /// Gets or sets the name of playist.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string Name { get; protected set; }

        /// <summary>
        /// Gets or sets the playing position of the media indicated by <see cref="Index"/>.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public ulong Position { get; protected set; }

        /// <summary>
        /// Gets the total number of media in the playlist.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public virtual int TotalCount { get; } = 1;

        /// <summary>
        /// Creates an object of the MediaControlPlaylist with the specified name, index, position.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="index"></param>
        /// <param name="position"></param>
        /// <returns>A <see cref="MediaControlSimplePlaylist"/> instance.</returns>
        /// <exception cref="ArgumentException"><paramref name="index"/> cannot be converted to number.</exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="name"/> or <paramref name="index"/> is not set.
        /// </exception>
        /// <since_tizen> 5 </since_tizen>
        public static MediaControlSimplePlaylist Create(string name, string index, ulong position)
        {
            return new MediaControlSimplePlaylist(name, index, position);
        }

        /// <summary>
        /// Creates an object of the MediaControlPlaylist with the specified name, index.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="index"></param>
        /// <returns>A <see cref="MediaControlSimplePlaylist"/> instance.</returns>
        /// <exception cref="ArgumentException"><paramref name="index"/> cannot be converted to number.</exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="name"/> or <paramref name="index"/> is not set.
        /// </exception>
        /// <since_tizen> 5 </since_tizen>
        public static MediaControlSimplePlaylist Create(string name, string index)
        {
            return new MediaControlSimplePlaylist(name, index, 0);
        }
    }


    /// <summary>
    /// Represents simple playlist for media control.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class MediaControlSimplePlaylist : Playlist
    {
        internal MediaControlSimplePlaylist(string name, string index, ulong position)
            : base(name, index, position)
        { }
    }
}
