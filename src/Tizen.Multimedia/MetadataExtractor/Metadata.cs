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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Multimedia
{
    /// <summary>
    /// This class provides properties of the metadata information of the given media
    /// </summary>
    public class Metadata
	{
		internal Metadata(MetadataBundle metadata)
		{
			Duration = metadata.Duration;
			VideoBitrate = metadata.VideoBitrate;
			VideoFPS = metadata.VideoFPS;
			VideoWidth = metadata.VideoWidth;
			VideoHeight = metadata.VideoHeight;
			VideoStreamCount = metadata.Videostreamcount;
			AudioBitrate = metadata.AudioBitrate;
			AudioChannels = metadata.AudioChannels;
			AudioSamplerate = metadata.AudioSamplerate;
			AudioBitPerSample = metadata.Audiobitpersample;
			AudioStreamCount = metadata.Audiostreamcount;
			Artist = metadata.Artist;
			Title = metadata.Title;
			Album = metadata.Album;
			AlbumArtist = metadata.AlbumArtist;
			Genre = metadata.Genre;
			Author = metadata.Author;
			Copyright = metadata.Copyright;
			Date = metadata.Date;
			Description = metadata.Description;
			Comment = metadata.Comment;
			TrackNumber = metadata.Tracknumber;
			Classification = metadata.Classification;
			Rating = metadata.Rating;
			Longitude = metadata.Longitude;
			Latitude = metadata.Latitude;
			Altitude = metadata.Altitude;
			Conductor = metadata.Conductor;
			Unsynclyric = metadata.Unsynclyric;
			SyncLyricNumber = metadata.SyncLyricNumber;
			RecordingDate = metadata.Recordingdate;
			Rotate = metadata.Rotate;
			VideoCodec = metadata.VideoCodec;
			AudioCodec = metadata.AudioCodec;
			Content360 = metadata.content360;
		}
        /// <summary>
        /// Duration
        /// </summary>
        public readonly string Duration;
        /// <summary>
        /// Video bitrate
        /// </summary>
		public readonly string VideoBitrate;
        /// <summary>
        /// Video FPS
        /// </summary>
		public readonly string VideoFPS;
        /// <summary>
        /// Video width
        /// </summary>
		public readonly string VideoWidth;
        /// <summary>
        /// Video height
        /// </summary>
		public readonly string VideoHeight;
        /// <summary>
        /// Video stream existence
        /// </summary>
		public readonly string VideoStreamCount;
        /// <summary>
        /// Audio bitrate
        /// </summary>
		public readonly string AudioBitrate;
        /// <summary>
        /// Audio channels
        /// </summary>
		public readonly string AudioChannels;
        /// <summary>
        /// Audio samplerate
        /// </summary>
		public readonly string AudioSamplerate;
        /// <summary>
        /// Audio bit per sample
        /// </summary>
		public readonly string AudioBitPerSample;
        /// <summary>
        /// Audio stream existence
        /// </summary>
		public readonly string AudioStreamCount;
        /// <summary>
        /// Artist
        /// </summary>
		public readonly string Artist;
        /// <summary>
        /// Title
        /// </summary>
		public readonly string Title;
        /// <summary>
        /// Album name
        /// </summary>
		public readonly string Album;
        /// <summary>
        /// Album artist
        /// </summary>
		public readonly string AlbumArtist;
        /// <summary>
        /// Genre
        /// </summary>
		public readonly string Genre;
        /// <summary>
        /// Author
        /// </summary>
		public readonly string Author;
        /// <summary>
        /// Copyright
        /// </summary>
		public readonly string Copyright;
        /// <summary>
        /// Release date
        /// </summary>
		public readonly string Date;
        /// <summary>
        /// Description
        /// </summary>
		public readonly string Description;
        /// <summary>
        /// Comment
        /// </summary>
		public readonly string Comment;
        /// <summary>
        /// Track number information
        /// </summary>
		public readonly string TrackNumber;
        /// <summary>
        /// Classification
        /// </summary>
		public readonly string Classification;
        /// <summary>
        /// Rating
        /// </summary>
		public readonly string Rating;
        /// <summary>
        /// Longitude
        /// </summary>
		public readonly string Longitude;
        /// <summary>
        /// Latitude
        /// </summary>
		public readonly string Latitude;
        /// <summary>
        /// Altitude
        /// </summary>
		public readonly string Altitude;
        /// <summary>
        /// Conductor
        /// </summary>
		public readonly string Conductor;
        /// <summary>
        /// Unsynchronized lyrics
        /// </summary>
		public readonly string Unsynclyric;
        /// <summary>
        /// Synchronized lyrics number
        /// </summary>
		public readonly string SyncLyricNumber;
        /// <summary>
        /// Recording date
        /// </summary>
		public readonly string RecordingDate;
        /// <summary>
        /// Rotate(orientation) information
        /// </summary>
		public readonly string Rotate;
        /// <summary>
        /// Video codec type
        /// </summary>
		public readonly string VideoCodec;
        /// <summary>
        /// Audio codec type
        /// </summary>
		public readonly string AudioCodec;
        /// <summary>
        /// 360 content information
        /// </summary>
		public readonly string Content360;
	}

	internal class MetadataBundle
	{
		internal string Duration;
		internal string VideoBitrate;
		internal string VideoFPS;
		internal string VideoWidth;
		internal string VideoHeight;
		internal string Videostreamcount;
		internal string AudioBitrate;
		internal string AudioChannels;
		internal string AudioSamplerate;
		internal string Audiobitpersample;
		internal string Audiostreamcount;
		internal string Artist;
		internal string Title;
		internal string Album;
		internal string AlbumArtist;
		internal string Genre;
		internal string Author;
		internal string Copyright;
		internal string Date;
		internal string Description;
		internal string Comment;
		internal string Tracknumber;
		internal string Classification;
		internal string Rating;
		internal string Longitude;
		internal string Latitude;
		internal string Altitude;
		internal string Conductor;
		internal string Unsynclyric;
		internal string SyncLyricNumber;
		internal string Recordingdate;
		internal string Rotate;
		internal string VideoCodec;
		internal string AudioCodec;
		internal string content360;
	}
}
