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
            // If native framework return null handle,
            // it means server doesn't set metadata yet and it's not error.
            // So we need to return empty metadata instance as native framework does.
            if (handle == IntPtr.Zero)
            {
                return;
            }

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

            EncodedSeason = Native.GetMetadata(handle, MediaControllerNativeAttribute.Season);
            Season = DecodeSeason(EncodedSeason);

            EncodedEpisode = Native.GetMetadata(handle, MediaControllerNativeAttribute.Episode);
            Episode = DecodeEpisode(EncodedEpisode);

            EncodedResolution = Native.GetMetadata(handle, MediaControllerNativeAttribute.Resolution);
            Resolution = DecodeResolution(EncodedResolution);
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
            get => DecodeSeason(EncodedSeason);
            set => EncodedSeason = EncodeSeason(value);
        }

        /// <summary>
        /// Gets or sets the episode information.
        /// </summary>
        /// <seealso cref="SeriesInformation"/>
        /// <since_tizen> 6 </since_tizen>
        public SeriesInformation Episode
        {
            get => DecodeEpisode(EncodedEpisode);
            set => EncodedEpisode = EncodeEpisode(value);
        }

        /// <summary>
        /// Gets or sets the content resolution.
        /// </summary>
        /// <seealso cref="Size"/>
        /// <since_tizen> 6 </since_tizen>
        public Size Resolution
        {
            get => DecodeResolution(EncodedResolution);
            set => EncodedResolution = EncodeResolution(value.Width, value.Height);
        }

        // Developers who use Tizen Native API must encode strings to set or get metadata of media
        // such as season, episode, and resolution. It is inconvenient.
        // TizenFX supports for using normal strings and using encoded strings internally.
        internal string EncodedSeason { get; private set; }

        internal string EncodedEpisode { get; private set; }

        internal string EncodedResolution { get; private set; }

        private static string EncodeSeason(SeriesInformation information)
        {
            Native.EncodeSeason(information.Number, information.Title, out string encodedSeason).
                ThrowIfError("Failed to encode season");

            return encodedSeason;
        }

        private static string EncodeEpisode(SeriesInformation information)
        {
            Native.EncodeEpisode(information.Number, information.Title, out string encodedEpisode).
                ThrowIfError("Failed to encode episode");

            return encodedEpisode;
        }

        private static string EncodeResolution(int width, int height)
        {
            Native.EncodeResolution((uint)width, (uint)height, out string encodedResolution).
                ThrowIfError("Failed to encode resolution");

            return encodedResolution;
        }

        private static SeriesInformation DecodeSeason(string encodedSeason)
        {
            int number = 0;
            string title = null;

            if (encodedSeason != null)
            {
                Native.DecodeSeason(encodedSeason, out number, out title).
                    ThrowIfError("Failed to decode season");
            }

            return new SeriesInformation(number, title);
        }

        private static SeriesInformation DecodeEpisode(string encodedEpisode)
        {
            int number = 0;
            string title = null;

            if (encodedEpisode != null)
            {
                Native.DecodeEpisode(encodedEpisode, out number, out title).
                    ThrowIfError("Failed to decode episode");
            }

            return new SeriesInformation(number, title);
        }

        private static Size DecodeResolution(string encodedResolution)
        {
            uint width = 0, height = 0;

            if (encodedResolution != null)
            {
                Native.DecodeResolution(encodedResolution, out width, out height).
                    ThrowIfError("Failed to decode resolution");
            }

            return new Size((int)width, (int)height);
        }
    }

    /// <summary>
    /// Represents properties for the video series information.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class SeriesInformation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SeriesInformation"/> class.
        /// </summary>
        /// <param name="number">The order of this video in entire series.</param>
        /// <param name="title">The title.</param>
        /// <since_tizen> 6 </since_tizen>
        public SeriesInformation(int number, string title)
        {
            Number = number;
            Title = title;
        }

        /// <summary>
        /// Gets or sets the order of this video in entire series.
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