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
    /// Represents a video media information.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class VideoInfo : MediaInfo
    {
        internal VideoInfo(Interop.MediaInfoHandle handle) : base(handle)
        {
            IntPtr videoHandle = IntPtr.Zero;

            try
            {
                Interop.MediaInfo.GetVideo(handle, out videoHandle).ThrowIfError("Failed to retrieve data");

                Debug.Assert(videoHandle != IntPtr.Zero);

                Album = InteropHelper.GetString(videoHandle, Interop.VideoInfo.GetAlbum); // Deprecated since API12
                Artist = InteropHelper.GetString(videoHandle, Interop.VideoInfo.GetArtist); // Deprecated since API12
                AlbumArtist = InteropHelper.GetString(videoHandle, Interop.VideoInfo.GetAlbumArtist); // Deprecated since API12
                Genre = InteropHelper.GetString(videoHandle, Interop.VideoInfo.GetGenre); // Deprecated since API12
                Composer = InteropHelper.GetString(videoHandle, Interop.VideoInfo.GetComposer); // Deprecated since API12
                Year = InteropHelper.GetString(videoHandle, Interop.VideoInfo.GetYear); // Deprecated since API12
                DateRecorded = InteropHelper.GetString(videoHandle, Interop.VideoInfo.GetRecordedDate); // Deprecated since API12
                Copyright = InteropHelper.GetString(videoHandle, Interop.VideoInfo.GetCopyright); // Deprecated since API12
                TrackNumber = InteropHelper.GetString(videoHandle, Interop.VideoInfo.GetTrackNum); // Deprecated since API12

                BitRate = InteropHelper.GetValue<int>(videoHandle, Interop.VideoInfo.GetBitRate); // Deprecated since API12
                Duration = InteropHelper.GetValue<int>(videoHandle, Interop.VideoInfo.GetDuration); // Deprecated since API12
                Width = InteropHelper.GetValue<int>(videoHandle, Interop.VideoInfo.GetWidth);
                Height = InteropHelper.GetValue<int>(videoHandle, Interop.VideoInfo.GetHeight);
            }
            finally
            {
                Interop.VideoInfo.Destroy(videoHandle);
            }
        }

        /// <summary>
        /// Gets the album name.
        /// </summary>
        /// <value>The album name from the metadata.</value>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        public string Album { get; }

        /// <summary>
        /// Gets the artist name.
        /// </summary>
        /// <value>The artist name from the metadata.</value>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        public string Artist { get; }

        /// <summary>
        /// Gets the album artist name.
        /// </summary>
        /// <value>The album artist name from the metadata.</value>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        public string AlbumArtist { get; }

        /// <summary>
        /// Gets the genre.
        /// </summary>
        /// <value>The genre name from the metadata.</value>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        public string Genre { get; }

        /// <summary>
        /// Gets the composer name.
        /// </summary>
        /// <value>The composer name from the metadata.</value>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        public string Composer { get; }

        /// <summary>
        /// Gets the year.
        /// </summary>
        /// <value>The year from the metadata.</value>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        public string Year { get; }

        /// <summary>
        /// Gets the recorded date.
        /// </summary>
        /// <value>The recorded date information from the metadata if exists; otherwise, the modified date of the file.</value>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        public string DateRecorded { get; }

        /// <summary>
        /// Gets the copyright notice.
        /// </summary>
        /// <value>The copyright notice from the metadata.</value>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        public string Copyright { get; }

        /// <summary>
        /// Gets the track number.
        /// </summary>
        /// <value>The track number from the metadata.</value>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        public string TrackNumber { get; }

        /// <summary>
        /// Gets the bitrate in bit per second.
        /// </summary>
        /// <value>The bit rate of the video.</value>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        public int BitRate { get; }

        /// <summary>
        /// Gets the track duration in milliseconds.
        /// </summary>
        /// <value>The track duration of the video in milliseconds.</value>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        public int Duration { get; }

        /// <summary>
        /// Gets the video width in pixels.
        /// </summary>
        /// <value>The width of the video in pixels.</value>
        /// <since_tizen> 4 </since_tizen>
        public int Width { get; }

        /// <summary>
        /// Gets the video height in pixels.
        /// </summary>
        /// <value>The height of the video in pixels.</value>
        /// <since_tizen> 4 </since_tizen>
        public int Height { get; }

    }
}
