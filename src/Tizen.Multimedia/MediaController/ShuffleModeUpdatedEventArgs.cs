/// This File contains ShuffleModeUpdatedEventArgs class
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
	/// ShuffleModeUpdated event arguments
	/// </summary>
	/// <remarks>
	/// ShuffleModeUpdated event arguments
	/// </remarks>
	public class ShuffleModeUpdatedEventArgs : EventArgs
	{
		internal string _serverName;
		internal ShuffleMode _mode;
		internal IntPtr _userData;

		public ShuffleModeUpdatedEventArgs (string name, ShuffleMode mode, IntPtr userData)
		{
			_serverName = name;
			_mode = mode;
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
		/// Get shuffle mode.
		/// </summary>
		/// <value> 0 - 100 </value>
		public ShuffleMode ShuffleMode
		{
			get
			{
				return _mode;
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

