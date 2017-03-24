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
using static Tizen.Multimedia.Interop.MetadataExtractor;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Represents video metadata information.
    /// </summary>
    public class VideoMetadata
    {

        protected VideoMetadata()
        {
        }

        internal VideoMetadata(IntPtr handle)
        {
            Debug.Assert(handle != IntPtr.Zero);

            StreamCount = GetMetadata(handle, MetadataExtractorAttr.VideoStreamCount);

            if (StreamCount == null || (StreamCount != null && StreamCount.Equals("0") == false))
            {
                Bitrate = GetMetadata(handle, MetadataExtractorAttr.VideoBitrate);
                Fps = GetMetadata(handle, MetadataExtractorAttr.VideoFps);
                Width = GetMetadata(handle, MetadataExtractorAttr.VideoWidth);
                Height = GetMetadata(handle, MetadataExtractorAttr.VideoHeight);
                Codec = GetMetadata(handle, MetadataExtractorAttr.VideoCodec);
            }

            _description = new Lazy<string>(() => ObjectDescriptionBuilder.BuildWithProperties(this));
        }

        /// <summary>
        /// Gets the bitrate.
        /// </summary>
        /// <value>A string representing the bitrate, or null if the information does not exists.</value>
        public string Bitrate { get; }

        /// <summary>
        /// Gets the video FPS.
        /// </summary>
        /// <value>A string representing the fps, or null if the information does not exists.</value>
        public string Fps { get; }

        /// <summary>
        /// Gets the width of the video.
        /// </summary>
        /// <value>A string representing the width, or null if the information does not exists.</value>
        public string Width { get; }

        /// <summary>
        /// Gets the height of the video.
        /// </summary>
        /// <value>A string representing the height, or null if the information does not exists.</value>
        public string Height { get; }

        /// <summary>
        /// Get the codec type of the video.
        /// </summary>
        /// <value>A string representing the codec type, or null if the information does not exists.</value>
        public string Codec { get; }

        /// <summary>
        /// Gets the video stream count.
        /// </summary>
        /// <value>A string representing the video stream count, or null if the information does not exists.</value>
        public string StreamCount { get; }

        private Lazy<string> _description;

        public override string ToString()
        {
            return _description.Value;
        }

    }

    /// <summary>
    /// Represents audio metadata information.
    /// </summary>
    public class AudioMetadata
    {

        protected AudioMetadata()
        {
        }

        internal AudioMetadata(IntPtr handle)
        {
            Debug.Assert(handle != IntPtr.Zero);

            StreamCount = GetMetadata(handle, MetadataExtractorAttr.AudioStreamCount);

            if (StreamCount == null || (StreamCount != null && !StreamCount.Equals("0")))
            {
                Bitrate = GetMetadata(handle, MetadataExtractorAttr.AudioBitrate);
                Channels = GetMetadata(handle, MetadataExtractorAttr.AudioChannels);
                Samplerate = GetMetadata(handle, MetadataExtractorAttr.AudioSamplerate);
                BitPerSample = GetMetadata(handle, MetadataExtractorAttr.AudioBitPerSample);
                Codec = GetMetadata(handle, MetadataExtractorAttr.AudioCodec);
            }

            _description = new Lazy<string>(() => ObjectDescriptionBuilder.BuildWithProperties(this));
        }

        /// <summary>
        /// Gets the audio bitrate.
        /// </summary>
        /// <value>A string representing the bitrate, or null if the information does not exists.</value>
        public string Bitrate { get; }

        /// <summary>
        /// Gets the audio channels.
        /// </summary>
        /// <value>A string representing the audio channels, or null if the information does not exists.</value>
        public string Channels { get; }

        /// <summary>
        /// Gets the audio sample rate.
        /// </summary>
        /// <value>A string representing the sample rate, or null if the information does not exists.</value>
        public string Samplerate { get; }

        /// <summary>
        /// Gets the bit per sample of the audio.
        /// </summary>
        /// <value>A string representing the bit oer sample, or null if the information does not exists.</value>
        public string BitPerSample { get; }

        /// <summary>
        /// Gets the audio stream count.
        /// </summary>
        /// <value>A string representing the audio stream count, or null if the information does not exists.</value>
        public string StreamCount { get; }

        /// <summary>
        /// Audio codec type
        /// </summary>
        public string Codec { get; }

        private Lazy<string> _description;

        public override string ToString()
        {
            return _description.Value;
        }
    }

    /// <summary>
    /// Represents metadata information of a media.
    /// </summary>
    public class Metadata
    {

        protected Metadata()
        {
        }

        internal Metadata(IntPtr handle)
        {
            Debug.Assert(handle != IntPtr.Zero);

            Video = new VideoMetadata(handle);
            Audio = new AudioMetadata(handle);

            Duration = GetMetadata(handle, MetadataExtractorAttr.Duration);
            Artist = GetMetadata(handle, MetadataExtractorAttr.Artist);
            Title = GetMetadata(handle, MetadataExtractorAttr.Title);
            Album = GetMetadata(handle, MetadataExtractorAttr.Album);
            AlbumArtist = GetMetadata(handle, MetadataExtractorAttr.AlbumArtist);
            Genre = GetMetadata(handle, MetadataExtractorAttr.Genre);
            Author = GetMetadata(handle, MetadataExtractorAttr.Author);
            Copyright = GetMetadata(handle, MetadataExtractorAttr.Copyright);
            ReleaseDate = GetMetadata(handle, MetadataExtractorAttr.ReleaseDate);
            Description = GetMetadata(handle, MetadataExtractorAttr.Description);
            Comment = GetMetadata(handle, MetadataExtractorAttr.Comment);
            TrackNumber = GetMetadata(handle, MetadataExtractorAttr.TrackNum);
            Classification = GetMetadata(handle, MetadataExtractorAttr.Classification);
            Rating = GetMetadata(handle, MetadataExtractorAttr.Rating);
            Longitude = GetMetadata(handle, MetadataExtractorAttr.Longitude);
            Latitude = GetMetadata(handle, MetadataExtractorAttr.Latitude);
            Altitude = GetMetadata(handle, MetadataExtractorAttr.Altitude);
            Conductor = GetMetadata(handle, MetadataExtractorAttr.Conductor);
            UnsyncLyric = GetMetadata(handle, MetadataExtractorAttr.UnSyncLyrics);
            SyncLyricCount = GetMetadata(handle, MetadataExtractorAttr.SyncLyricsNum);
            RecordingDate = GetMetadata(handle, MetadataExtractorAttr.RecordingDate);
            Rotation = GetMetadata(handle, MetadataExtractorAttr.Rotate);
            Content360 = GetMetadata(handle, MetadataExtractorAttr.ContentFor360);

            _description = new Lazy<string>(() => ObjectDescriptionBuilder.BuildWithProperties(this));
        }

        /// <summary>
        /// Gets the duration of the media.
        /// </summary>
        /// <value>A string representing the duration, or null if the information does not exists.</value>
        public string Duration { get; }

        /// <summary>
        /// Gets the video metadata.
        /// </summary>
        public VideoMetadata Video { get; }

        /// <summary>
        /// Gets the audio metadata.
        /// </summary>
        public AudioMetadata Audio { get; }

        /// <summary>
        /// Gets the artist of the media.
        /// </summary>
        /// <value>A string representing the artist, or null if the information does not exists.</value>
        public string Artist { get; }

        /// <summary>
        /// Gets the title of the media.
        /// </summary>
        /// <value>A string representing the title, or null if the information does not exists.</value>
        public string Title { get; }

        /// <summary>
        /// Gets the album name of the media.
        /// </summary>
        /// <value>A string representing the album name, or null if the information does not exists.</value>
        public string Album { get; }

        /// <summary>
        /// Gets the album artist of the media.
        /// </summary>
        /// <value>A string representing the album artist, or null if the information does not exists.</value>
        public string AlbumArtist { get; }

        /// <summary>
        /// Gets the genre of the media.
        /// </summary>
        /// <value>A string representing the genre, or null if the information does not exists.</value>
        public string Genre { get; }

        /// <summary>
        /// Gets the author of the media.
        /// </summary>
        /// <value>A string representing the author, or null if the information does not exists.</value>
        public string Author { get; }

        /// <summary>
        /// Gets the copyright of the media.
        /// </summary>
        /// <value>A string representing the copyright, or null if the information does not exists.</value>
        public string Copyright { get; }

        /// <summary>
        /// Gets the release date of the media.
        /// </summary>
        /// <value>A string representing the release date, or null if the information does not exists.</value>
        public string ReleaseDate { get; }

        /// <summary>
        /// Gets the description of the media.
        /// </summary>
        /// <value>A string representing the description, or null if the information does not exists.</value>
        public string Description { get; }

        /// <summary>
        /// Gets the comment of the media.
        /// </summary>
        /// <value>A string representing the comment, or null if the information does not exists.</value>
        public string Comment { get; }

        /// <summary>
        /// Gets the track number of the media.
        /// </summary>
        /// <value>A string representing the track number, or null if the information does not exists.</value>
        public string TrackNumber { get; }

        /// <summary>
        /// Gets the classification of the media.
        /// </summary>
        /// <value>A string representing the classification, or null if the information does not exists.</value>
        public string Classification { get; }

        /// <summary>
        /// Gets the rating of the media.
        /// </summary>
        /// <value>A string representing the rating, or null if the information does not exists.</value>
        public string Rating { get; }

        /// <summary>
        /// Gets the longitude of the media.
        /// </summary>
        /// <value>A string representing the longitude, or null if the information does not exists.</value>
        public string Longitude { get; }

        /// <summary>
        /// Gets the latitude of the media.
        /// </summary>
        /// <value>A string representing the latitude, or null if the information does not exists.</value>
        public string Latitude { get; }

        /// <summary>
        /// Gets the altitude of the media.
        /// </summary>
        /// <value>A string representing the altitude, or null if the information does not exists.</value>
        public string Altitude { get; }

        /// <summary>
        /// Gets the conductor of the media.
        /// </summary>
        /// <value>A string representing the conductor, or null if the information does not exists.</value>
        public string Conductor { get; }

        /// <summary>
        /// Gets the unsynchronized lyrics of the media.
        /// </summary>
        /// <value>A string representing the unsynchronized lyrics, or null if the information does not exists.</value>
        public string UnsyncLyric { get; }

        /// <summary>
        /// Gets the number of synchronized lyrics of the media.
        /// </summary>
        /// <value>A string representing the number of the synchronized lyrics, or null if the information does not exists.</value>
        public string SyncLyricCount { get; }

        /// <summary>
        /// Gets the recording date of the media.
        /// </summary>
        /// <value>A string representing the recording date, or null if the information does not exists.</value>
        public string RecordingDate { get; }

        /// <summary>
        /// Gets the rotate(orientation) information of the media.
        /// </summary>
        /// <value>A string representing the rotation information, or null if the information does not exists.</value>
        public string Rotation { get; }

        /// <summary>
        /// Gets the information for 360 content of the media.
        /// </summary>
        /// <value>A string representing the information for 360 content, or null if the information does not exists.</value>
        public string Content360 { get; }

        private Lazy<string> _description;

        public override string ToString()
        {
            return _description.Value;
        }
    }
}
