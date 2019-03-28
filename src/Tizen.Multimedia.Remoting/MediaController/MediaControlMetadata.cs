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
        /// <seealso cref="SeriesInformation"/>
        /// <since_tizen> 6 </since_tizen>
        public SeriesInformation Season
        {
            get => Decode(MediaControllerNativeAttribute.Season);
            set => SeasonEncoded = Encode(value, MediaControllerNativeAttribute.Season);
        }

        /// <summary>
        /// Gets or sets the episode information.
        /// </summary>
        /// <seealso cref="SeriesInformation"/>
        /// <since_tizen> 6 </since_tizen>
        public SeriesInformation Episode
        {
            get => Decode(MediaControllerNativeAttribute.Episode);
            set => EpisodeEncoded = Encode(value, MediaControllerNativeAttribute.Episode);
        }

        /// <summary>
        /// Gets or sets the content resolution.
        /// </summary>
        /// <seealso cref="Size"/>
        /// <since_tizen> 6 </since_tizen>
        public Size Resolution
        {
            get => Decode();
            set => ResolutionEncoded = Encode(value.Width, value.Height);
        }

        // Native CAPI used only encoded string to gets or sets Season, Episode, Resolution.
        // But encoded string is not useful for user, so we don't offer as it is.
        // It'll be used internally.
        internal string SeasonEncoded { get; private set; }

        internal string EpisodeEncoded { get; private set; }

        internal string ResolutionEncoded { get; private set; }

        private string Encode(SeriesInformation information, MediaControllerNativeAttribute type)
        {
            string encoded = null;

            if (type == MediaControllerNativeAttribute.Season)
            {
                Native.EncodeSeason(information.Number, information.Title, out encoded).
                    ThrowIfError("Failed to encode season");
            }
            else if (type == MediaControllerNativeAttribute.Episode)
            {
                Native.EncodeEpisode(information.Number, information.Title, out encoded).
                    ThrowIfError("Failed to encode episode");
            }

            return encoded;
        }

        private string Encode(int width, int height)
        {
            Native.EncodeResolution((uint)width, (uint)height, out string encoded).
                ThrowIfError("Failed to encode resolution");

            return encoded;
        }

        private SeriesInformation Decode(MediaControllerNativeAttribute type)
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

            return new SeriesInformation(number, title);
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

    /// <summary>
    /// Represents properties for the video series information.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public struct SeriesInformation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaControlPlaylist"/> struct.
        /// </summary>
        /// <param name="number">The number of this video of all series.</param>
        /// <param name="title">The title.</param>
        /// <since_tizen> 6 </since_tizen>
        public SeriesInformation(int number, string title)
        {
            Number = number;
            Title = title;
        }

        /// <summary>
        /// Gets or sets the number of this video of all series.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int Number { get; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Title { get; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <since_tizen> 6 </since_tizen>
        public override string ToString() => $"Number={Number.ToString()}, Title={Title}";
    }
}