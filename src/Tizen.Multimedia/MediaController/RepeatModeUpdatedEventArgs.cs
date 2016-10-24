/// This File contains RepeatModeUpdatedEventArgs class
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
	/// RepeatModeUpdated event arguments
	/// </summary>
	/// <remarks>
	/// RepeatModeUpdated event arguments
	/// </remarks>
	public class RepeatModeUpdatedEventArgs : EventArgs
	{
		internal string _serverName;
		internal RepeatMode _mode;
		internal IntPtr _userData;

		public RepeatModeUpdatedEventArgs (string name, RepeatMode mode, IntPtr userData)
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
		/// Get repeat mode.
		/// </summary>
		/// <value> 0 - 100 </value>
		public RepeatMode RepeatMode
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

