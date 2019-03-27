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
using Native = Interop.MediaControllerPlaylist;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Represents metadata for media control.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class MediaControlMetadata
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaControlMetadata"/> class.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public MediaControlMetadata()
        {
        }

        internal MediaControlMetadata(IntPtr handle)
        {
            Debug.Assert(handle != IntPtr.Zero);

            Title = Native.GetMetadata(handle, MediaControllerNativeAttribute.Title);
            Artist = Native.GetMetadata(handle, MediaControllerNativeAttribute.Artist);
            Album = Native.GetMetadata(handle, MediaControllerNativeAttribute.Album);
            Author = Native.GetMetadata(handle, MediaControllerNativeAttribute.Author);
            Genre = Native.GetMetadata(handle, MediaControllerNativeAttribute.Genre);
            Duration = Native.GetMetadata(handle, MediaControllerNativeAttribute.Duration);
            Date = Native.GetMetadata(handle, MediaControllerNativeAttribute.Date);
            Copyright = Native.GetMetadata(handle, MediaControllerNativeAttribute.Copyright);
            Description = Native.GetMetadata(handle, MediaControllerNativeAttribute.Description);
            TrackNumber = Native.GetMetadata(handle, MediaControllerNativeAttribute.TrackNumber);
            AlbumArtPath = Native.GetMetadata(handle, MediaControllerNativeAttribute.Picture);

            SeasonEncoded = Native.GetMetadata(handle, MediaControllerNativeAttribute.Season);
            Season = Decode(MediaControllerNativeAttribute.Season);

            EpisodeEncoded = Native.GetMetadata(handle, MediaControllerNativeAttribute.Episode);
            Episode = Decode(MediaControllerNativeAttribute.Episode);

            ResolutionEncoded = Native.GetMetadata(handle, MediaControllerNativeAttribute.Resolution);
            Resolution = Decode();
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the artist.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Artist { get; set; }

        /// <summary>
        /// Gets or sets the album.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Album { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the genre.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Genre { get; set; }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Duration { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the copyright.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Copyright { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the track number.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string TrackNumber { get; set; }

        /// <summary>
        /// Gets or sets the path of the album art.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string AlbumArtPath { get; set; }

        /// <summary>
        /// Gets or sets the season information.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public (int number, string title) Season
        {
            get => Decode(MediaControllerNativeAttribute.Season);
            set => Encode(value.number, value.title, MediaControllerNativeAttribute.Season);
        }

        /// <summary>
        /// Gets or sets the episode information.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public (int number, string title) Episode
        {
            get => Decode(MediaControllerNativeAttribute.Episode);
            set => Encode(value.number, value.title, MediaControllerNativeAttribute.Episode);
        }

        /// <summary>
        /// Gets or sets the content resolution.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Size Resolution
        {
            get => Decode();
            set => Encode(value.Width, value.Height);
        }

        // Native CAPI used only encoded string to gets or sets season, episode, resolution.
        // But encoded string is not useful for user, so we don't offer as it is.
        // It'll be used internally.
        internal string SeasonEncoded { get; private set; } = null;
        internal string EpisodeEncoded { get; private set; } = null;
        internal string ResolutionEncoded { get; private set; } = null;

        private void Encode(int number, string title, MediaControllerNativeAttribute type)
        {
            if (type == MediaControllerNativeAttribute.Season)
            {
                Native.EncodeSeason(number, title, out string encoded).
                    ThrowIfError("Failed to encode season");
                SeasonEncoded = encoded;
            }
            else if (type == MediaControllerNativeAttribute.Episode)
            {
                Native.EncodeEpisode(number, title, out string encoded).
                    ThrowIfError("Failed to encode episode");
                EpisodeEncoded = encoded;
            }
        }

        private void Encode(int width, int height)
        {
            Native.EncodeResolution((uint)width, (uint)height, out string encoded).
                ThrowIfError("Failed to encode resolution");
            ResolutionEncoded = encoded;
        }

        private (int number, string title) Decode(MediaControllerNativeAttribute type)
        {
            int number = 0;
            string title = null;

            if (SeasonEncoded != null && type == MediaControllerNativeAttribute.Season)
            {
                Native.DecodeSeason(SeasonEncoded, out number, out title).
                    ThrowIfError("Failed to decode season");
            }
            else if (EpisodeEncoded != null && type == MediaControllerNativeAttribute.Episode)
            {
                Native.DecodeEpisode(EpisodeEncoded, out number, out title).
                    ThrowIfError("Failed to decode episode");
            }

            return (number, title);
        }

        private Size Decode()
        {
            uint width = 0, height = 0;

            if (ResolutionEncoded != null)
            {
                Native.DecodeResolution(ResolutionEncoded, out width, out height).
                ThrowIfError("Failed to decode resolution");
            }

            return new Size((int)width, (int)height);
        }
    }
}