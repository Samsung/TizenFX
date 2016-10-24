/// Metadata
///
/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.using System;
///

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Multimedia
{
	/// <summary>
	/// Metadata information
	/// </summary>
	/// <remarks>
	/// This class provides properties of the metadata information of the given media
	/// </remarks>
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
		public readonly string Duration;
		public readonly string VideoBitrate;
		public readonly string VideoFPS;
		public readonly string VideoWidth;
		public readonly string VideoHeight;
		public readonly string VideoStreamCount;
		public readonly string AudioBitrate;
		public readonly string AudioChannels;
		public readonly string AudioSamplerate;
		public readonly string AudioBitPerSample;
		public readonly string AudioStreamCount;
		public readonly string Artist;
		public readonly string Title;
		public readonly string Album;
		public readonly string AlbumArtist;
		public readonly string Genre;
		public readonly string Author;
		public readonly string Copyright;
		public readonly string Date;
		public readonly string Description;
		public readonly string Comment;
		public readonly string TrackNumber;
		public readonly string Classification;
		public readonly string Rating;
		public readonly string Longitude;
		public readonly string Latitude;
		public readonly string Altitude;
		public readonly string Conductor;
		public readonly string Unsynclyric;
		public readonly string SyncLyricNumber;
		public readonly string RecordingDate;
		public readonly string Rotate;
		public readonly string VideoCodec;
		public readonly string AudioCodec;
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
