/// This File contains CommandReplyEventArgs class
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
	/// CustomCommandRecieved event arguments
	/// </summary>
	/// <remarks>
	/// CustomCommandRecieved event arguments
	/// </remarks>
	public class CommandReplyEventArgs : EventArgs
	{
		internal string _serverName;
		internal int _result;
		internal IntPtr _bundle;
		internal IntPtr _userData;

		public CommandReplyEventArgs (string serverName, int result, IntPtr bundle, IntPtr userData)
		{
			_serverName = serverName;
			_result = result;
			_bundle = bundle;
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
		public int Result
		{
			get
			{
				return _result;
			}
		}

		/// <summary>
		/// Get bundle data.
		/// </summary>
		/// <value> 0 - 100 </value>
		public IntPtr BundleData
		{
			get
			{
				return _bundle;
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

