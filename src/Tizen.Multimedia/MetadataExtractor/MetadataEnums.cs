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

namespace Tizen.Multimedia
{
	public enum MetadataExtractorAttr
	{
		METADATA_DURATION,		//Duration
		METADATA_VIDEO_BITRATE,			//VideoBitrate
		METADATA_VIDEO_FPS,				//VideoFPS
		METADATA_VIDEO_WIDTH,			//VideoWidth
		METADATA_VIDEO_HEIGHT,			//VideoHeight
		METADATA_HAS_VIDEO,				//Videostreamcount
		METADATA_AUDIO_BITRATE,			//AudioBitrate
		METADATA_AUDIO_CHANNELS,		//AudioChannels
		METADATA_AUDIO_SAMPLERATE,		//AudioSamplerate
		METADATA_AUDIO_BITPERSAMPLE,		//Audiobitpersample
		METADATA_HAS_AUDIO,				//Audiostreamcount
		METADATA_ARTIST,					//Artist
		METADATA_TITLE,					//Title
		METADATA_ALBUM,					//Album
		METADATA_ALBUM_ARTIST,			//Album_Artist
		METADATA_GENRE,					//Genre
		METADATA_AUTHOR,					//Author
		METADATA_COPYRIGHT,				//Copyright
		METADATA_DATE,					//Date
		METADATA_DESCRIPTION,				//Description
		METADATA_COMMENT,				//Comment
		METADATA_TRACK_NUM,				//Tracknumberinfo
		METADATA_CLASSIFICATION,			//Classification
		METADATA_RATING,					//Rating
		METADATA_LONGITUDE,				//Longitude
		METADATA_LATITUDE,				//Latitude
		METADATA_ALTITUDE,				//Altitude
		METADATA_CONDUCTOR,				//Conductor
		METADATA_UNSYNCLYRICS,			//Unsynchronizedlyric
		METADATA_SYNCLYRICS_NUM,		//Synchronizedlyric(time/lyricset)number
		METADATA_RECDATE,				//Recordingdate
		METADATA_ROTATE,					//Rotate(Orientation)Information
		METADATA_VIDEO_CODEC,			//VideoCodec
		METADATA_AUDIO_CODEC,			//AudioCodec
		METADATA_360,						//360contentInformation
	}
}
