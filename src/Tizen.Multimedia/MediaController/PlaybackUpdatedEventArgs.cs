/// This File contains PlaybackUpdatedEventArgs class
///
/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;

namespace Tizen.Multimedia.MediaController
{

	/// <summary>
	/// PlaybackUpdated event arguments
	/// </summary>
	/// <remarks>
	/// PlaybackUpdated event arguments
	/// </remarks>
	public class PlaybackUpdatedEventArgs : EventArgs
	{
		internal string _serverName;
		internal Playback _playback;
		internal IntPtr _userData;

		public PlaybackUpdatedEventArgs (string name, IntPtr handle, IntPtr userData)
		{
			_serverName = name;
			_playback = new Playback (handle);
			_userData = userData;
		}
		
		/// <summary>
		/// Get server name.
		/// </summary>
		/// <value> 0 - 100 </value>
		public string ServerName
		{
			get
			{
				return _serverName;
			}
		}

		/// <summary>
		/// Get playback information.
		/// </summary>
		/// <value> 0 - 100 </value>
		public Playback PlaybackInfo
		{
			get
			{
				return _playback;
			}
		}

		/// <summary>
		/// Get user data.
		/// </summary>
		/// <value> 0 - 100 </value>
		public IntPtr UserData
		{
			get
			{
				return _userData;
			}
		}
	}
}

