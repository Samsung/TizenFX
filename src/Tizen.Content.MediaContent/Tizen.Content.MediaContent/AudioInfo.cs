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

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// Represents the audio media information.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class AudioInfo : MediaInfo
    {
        internal AudioInfo(Interop.MediaInfoHandle handle) : base(handle)
        {
            IntPtr audioHandle = IntPtr.Zero;

            try
            {
                Interop.MediaInfo.GetAudio(handle, out audioHandle).ThrowIfError("Failed to retrieve data");

                Debug.Assert(audioHandle != IntPtr.Zero);

                Album = InteropHelper.GetString(audioHandle, Interop.AudioInfo.GetAlbum);
                Artist = InteropHelper.GetString(audioHandle, Interop.AudioInfo.GetArtist);
                AlbumArtist = InteropHelper.GetString(audioHandle, Interop.AudioInfo.GetAlbumArtist);
                Genre = InteropHelper.GetString(audioHandle, Interop.AudioInfo.GetGenre);
                Year = InteropHelper.GetString(audioHandle, Interop.AudioInfo.GetYear);
                TrackNumber = InteropHelper.GetString(audioHandle, Interop.AudioInfo.GetTrackNum);
            }
            finally
            {
                Interop.AudioInfo.Destroy(audioHandle);
            }
        }

        /// <summary>
        /// Gets the album name.
        /// </summary>
        /// <value>The album from the metadata.</value>
        /// <since_tizen> 4 </since_tizen>
        public string Album { get; }

        /// <summary>
        /// Gets the artist name.
        /// </summary>
        /// <value>The artist from the metadata.</value>
        /// <since_tizen> 4 </since_tizen>
        public string Artist { get; }

        /// <summary>
        /// Gets the album artist name.
        /// </summary>
        /// <value>The album artist from the metadata.</value>
        /// <since_tizen> 4 </since_tizen>
        public string AlbumArtist { get; }

        /// <summary>
        /// Gets the genre.
        /// </summary>
        /// <value>The genre from the metadata.</value>
        /// <since_tizen> 4 </since_tizen>
        public string Genre { get; }

        /// <summary>
        /// Gets the year.
        /// </summary>
        /// <value>The year from the metadata.</value>
        /// <since_tizen> 4 </since_tizen>
        public string Year { get; }

        /// <summary>
        /// Gets the track number.
        /// </summary>
        /// <value>The track number from the metadata.</value>
        /// <since_tizen> 4 </since_tizen>
        public string TrackNumber { get; }
    }
}
