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
using static Interop.MetadataExtractor;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Represents video metadata information.
    /// </summary>
    public class VideoMetadata
    {
        private VideoMetadata(int streamCount, IntPtr handle)
        {
            Debug.Assert(streamCount > 0);
            Debug.Assert(handle != IntPtr.Zero);

            StreamCount = streamCount;
            BitRate = ValueConverter.ToNullableInt(GetMetadata(handle, MetadataExtractorAttr.VideoBitrate));
            Fps = ValueConverter.ToNullableInt(GetMetadata(handle, MetadataExtractorAttr.VideoFps));
            Width = ValueConverter.ToNullableInt(GetMetadata(handle, MetadataExtractorAttr.VideoWidth));
            Height = ValueConverter.ToNullableInt(GetMetadata(handle, MetadataExtractorAttr.VideoHeight));
            Codec = GetMetadata(handle, MetadataExtractorAttr.VideoCodec);

            _description = new Lazy<string>(() => ObjectDescriptionBuilder.BuildWithProperties(this));
        }

        internal static VideoMetadata From(IntPtr handle)
        {
            var streamCount = ValueConverter.ToInt(GetMetadata(handle, MetadataExtractorAttr.VideoStreamCount));

            return streamCount > 0 ? new VideoMetadata(streamCount, handle) : null;
        }

        /// <summary>
        /// Gets the bitrate.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The bitrate value, or null if the information does not exist.</value>
        public int? BitRate { get; }

        /// <summary>
        /// Gets the video FPS.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The fps value, or null if the information does not exist.</value>
        public int? Fps { get; }

        /// <summary>
        /// Gets the width of the video.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The width value, or null if the information does not exist.</value>
        public int? Width { get; }

        /// <summary>
        /// Gets the height of the video.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The height value, or null if the information does not exist.</value>
        public int? Height { get; }

        /// <summary>
        /// Get the codec type of the video.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A string representing the codec type, or null if the information does not exist.</value>
        public string Codec { get; }

        /// <summary>
        /// Gets the video stream count.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The number of video streams.</value>
        public int StreamCount { get; }

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
        internal AudioMetadata(int streamCount, IntPtr handle)
        {
            Debug.Assert(streamCount > 0);
            Debug.Assert(handle != IntPtr.Zero);

            StreamCount = streamCount;
            BitRate = ValueConverter.ToNullableInt(GetMetadata(handle, MetadataExtractorAttr.AudioBitrate));
            Channels = ValueConverter.ToNullableInt(GetMetadata(handle, MetadataExtractorAttr.AudioChannels));
            SampleRate = ValueConverter.ToNullableInt(GetMetadata(handle, MetadataExtractorAttr.AudioSamplerate));
            BitPerSample = ValueConverter.ToNullableInt(GetMetadata(handle, MetadataExtractorAttr.AudioBitPerSample));
            Codec = GetMetadata(handle, MetadataExtractorAttr.AudioCodec);

            _description = new Lazy<string>(() => ObjectDescriptionBuilder.BuildWithProperties(this));
        }

        internal static AudioMetadata From(IntPtr handle)
        {
            var streamCount = ValueConverter.ToInt(GetMetadata(handle, MetadataExtractorAttr.AudioStreamCount));

            return streamCount > 0 ? new AudioMetadata(streamCount, handle) : null;
        }

        /// <summary>
        /// Gets the audio bitrate.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The bit rate value, or null if the information does not exist.</value>
        public int? BitRate { get; }

        /// <summary>
        /// Gets the audio channels.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The number of the audio channels, or null if the information does not exist.</value>
        public int? Channels { get; }

        /// <summary>
        /// Gets the audio sample rate.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The sample rate, or null if the information does not exist.</value>
        public int? SampleRate { get; }

        /// <summary>
        /// Gets the bit per sample of the audio.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The bit per sample, or null if the information does not exist.</value>
        public int? BitPerSample { get; }

        /// <summary>
        /// Gets the audio stream count.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The number of audio streams.</value>
        public int StreamCount { get; }

        /// <summary>
        /// Gets the audio codec type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        internal Metadata(IntPtr handle)
        {
            Debug.Assert(handle != IntPtr.Zero);

            Video = VideoMetadata.From(handle);
            Audio = AudioMetadata.From(handle);

            Duration = ValueConverter.ToNullableInt(GetMetadata(handle, MetadataExtractorAttr.Duration));
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
            Longitude = ValueConverter.ToNullableDouble(GetMetadata(handle, MetadataExtractorAttr.Longitude));
            Latitude = ValueConverter.ToNullableDouble(GetMetadata(handle, MetadataExtractorAttr.Latitude));
            Altitude = ValueConverter.ToNullableDouble(GetMetadata(handle, MetadataExtractorAttr.Altitude));
            Conductor = GetMetadata(handle, MetadataExtractorAttr.Conductor);
            UnsyncLyrics = GetMetadata(handle, MetadataExtractorAttr.UnSyncLyrics);
            SyncLyricsCount = ValueConverter.ToInt(GetMetadata(handle, MetadataExtractorAttr.SyncLyricsNum));
            DateRecorded = GetMetadata(handle, MetadataExtractorAttr.RecordingDate);
            Rotation = GetMetadata(handle, MetadataExtractorAttr.Rotate);
            Content360 = GetMetadata(handle, MetadataExtractorAttr.ContentFor360);

            _description = new Lazy<string>(() => ObjectDescriptionBuilder.BuildWithProperties(this));
        }

        /// <summary>
        /// Gets the duration of the media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The duration value, or null if the information does not exist.</value>
        public int? Duration { get; }

        /// <summary>
        /// Gets the video metadata.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The video metadata, or null if the information does not exist.</value>
        public VideoMetadata Video { get; }

        /// <summary>
        /// Gets the audio metadata.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The audio metadata, or null if the information does not exist.</value>
        public AudioMetadata Audio { get; }

        /// <summary>
        /// Gets the artist of the media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A string representing the artist, or null if the information does not exist.</value>
        public string Artist { get; }

        /// <summary>
        /// Gets the title of the media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A string representing the title, or null if the information does not exist.</value>
        public string Title { get; }

        /// <summary>
        /// Gets the album name of the media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A string representing the album name, or null if the information does not exist.</value>
        public string Album { get; }

        /// <summary>
        /// Gets the album artist of the media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A string representing the album artist, or null if the information does not exist.</value>
        public string AlbumArtist { get; }

        /// <summary>
        /// Gets the genre of the media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A string representing the genre, or null if the information does not exist.</value>
        public string Genre { get; }

        /// <summary>
        /// Gets the author of the media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A string representing the author, or null if the information does not exist.</value>
        public string Author { get; }

        /// <summary>
        /// Gets the copyright of the media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A string representing the copyright, or null if the information does not exist.</value>
        public string Copyright { get; }

        /// <summary>
        /// Gets the release date of the media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A string representing the release date, or null if the information does not exist.</value>
        public string ReleaseDate { get; }

        /// <summary>
        /// Gets the description of the media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A string representing the description, or null if the information does not exist.</value>
        public string Description { get; }

        /// <summary>
        /// Gets the comment of the media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A string representing the comment, or null if the information does not exist.</value>
        public string Comment { get; }

        /// <summary>
        /// Gets the track number of the media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A string representing the track number, or null if the information does not exist.</value>
        public string TrackNumber { get; }

        /// <summary>
        /// Gets the classification of the media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A string representing the classification, or null if the information does not exist.</value>
        public string Classification { get; }

        /// <summary>
        /// Gets the rating of the media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A string representing the rating, or null if the information does not exist.</value>
        public string Rating { get; }

        /// <summary>
        /// Gets the longitude of the media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The longitude value, or null if the information does not exist.</value>
        public double? Longitude { get; }

        /// <summary>
        /// Gets the latitude of the media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The latitude value, or null if the information does not exist.</value>
        public double? Latitude { get; }

        /// <summary>
        /// Gets the altitude of the media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The altitude value, or null if the information does not exist.</value>
        public double? Altitude { get; }

        /// <summary>
        /// Gets the conductor of the media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A string representing the conductor, or null if the information does not exist.</value>
        public string Conductor { get; }

        /// <summary>
        /// Gets the unsynchronized lyrics of the media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A string representing the unsynchronized lyrics, or null if the information does not exist.</value>
        public string UnsyncLyrics { get; }

        /// <summary>
        /// Gets the number of synchronized lyrics of the media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The number of the synchronized lyrics.</value>
        public int SyncLyricsCount { get; }

        /// <summary>
        /// Gets the recording date of the media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A string representing the recording date, or null if the information does not exist.</value>
        public string DateRecorded { get; }

        /// <summary>
        /// Gets the rotate(orientation) information of the media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A string representing the rotation information, or null if the information does not exist.</value>
        public string Rotation { get; }

        /// <summary>
        /// Gets the information for 360 content of the media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A string representing the information for 360 content, or null if the information does not exist.</value>
        public string Content360 { get; }

        private Lazy<string> _description;

        public override string ToString()
        {
            return _description.Value;
        }
    }
}
