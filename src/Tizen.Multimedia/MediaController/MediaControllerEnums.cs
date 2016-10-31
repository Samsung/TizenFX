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

namespace Tizen.Multimedia.MediaController
{
	/// <summary>
	/// Enumeration for server state
	/// </summary>
	public enum ServerState
	{
		/// <summary>
		/// Server state is unknown 
		/// </summary>
		None,

		/// <summary>
		/// Server is activated 
		/// </summary>
		Activated,

		/// <summary>
		/// Server is deactivated 
		/// </summary>
		Deactivated,
	}

	/// <summary>
	/// Enumeration for playback state
	/// </summary>
	public enum PlaybackState
	{
		/// <summary>
		/// Playback state is unknown 
		/// </summary>
		None,

		/// <summary>
		/// Playback is playing 
		/// </summary>
		Play,

		/// <summary>
		/// Playback is paused 
		/// </summary>
		Pause,

		/// <summary>
		/// Playback is next 
		/// </summary>
		Next,

		/// <summary>
		/// Playback is prev 
		/// </summary>
		Prev,

		/// <summary>
		/// Playback is fastforward 
		/// </summary>
		FastForward,

		/// <summary>
		/// Playback is rewind 
		/// </summary>
		Rewind,
	}

	/// <summary>
	/// Enumeration for shuffle mode
	/// </summary>
	public enum ShuffleMode
	{
		/// <summary>
		/// Shuffle mode is On
		/// </summary>
		On,

		/// <summary>
		/// Shuffle mode is Off
		/// </summary>
		Off,
	}

	/// <summary>
	/// Enumeration for repeat mode
	/// </summary>
	public enum RepeatMode
	{
		/// <summary>
		/// Repeat mode is On
		/// </summary>
		On,

		/// <summary>
		/// Repeat mode is Off
		/// </summary>
		Off,
	}

	/// <summary>
	/// Enumeration for repeat mode
	/// </summary>
	public enum SubscriptionType
	{
		/// <summary>
		/// Repeat mode is Off
		/// </summary>
		ServerState,

		/// <summary>
		/// Repeat mode is Off
		/// </summary>
		Playback,

		/// <summary>
		/// Repeat mode is Off
		/// </summary>
		Metadata,

		/// <summary>
		/// Repeat mode is Off
		/// </summary>
		ShuffleMode,

		/// <summary>
		/// Repeat mode is Off
		/// </summary>
		RepeatMode,
	}

	/// <summary>
	/// Enumeration for metadata attributes
	/// </summary>
	internal enum Attributes
	{
		/// <summary>
		/// Attribute is title
		/// </summary>
		Title,

		/// <summary>
		/// Attribute is artist
		/// </summary>
		Artist,

		/// <summary>
		/// Attribute is album
		/// </summary>
		Album,

		/// <summary>
		/// Attribute is author
		/// </summary>
		Author,

		/// <summary>
		/// Attribute is duration
		/// </summary>
		Duration,

		/// <summary>
		/// Attribute is date
		/// </summary>
		Date,

		/// <summary>
		/// Attribute is copyright
		/// </summary>
		Copyright,

		/// <summary>
		/// Attribute is description
		/// </summary>
		Description,

		/// <summary>
		/// Attribute is track number
		/// </summary>
		TrackNumber,

		/// <summary>
		/// Attribute is picture
		/// </summary>
		Picture,
	}
}

