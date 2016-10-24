/// This File contains PlaybackStateCommandEventArgs class
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
	/// PlaybackStateCommand event arguments
	/// </summary>
	/// <remarks>
	/// PlaybackStateCommand event arguments
	/// </remarks>
	public class PlaybackStateCommandEventArgs : EventArgs
	{
		internal string _clientName;
		internal PlaybackState _state;
		internal IntPtr _userData;

		public PlaybackStateCommandEventArgs (string name, PlaybackState state, IntPtr userData)
		{
			_clientName = name;
			_state = state;
			_userData = userData;
		}

		/// <summary>
		/// Get client name.
		/// </summary>
		/// <value> 0 - 100 </value>
		public string ClientName
		{
			get
			{
				return _clientName;
			}
		}

		/// <summary>
		/// Get playback state.
		/// </summary>
		/// <value> 0 - 100 </value>
		public PlaybackState State
		{
			get
			{
				return _state;
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

