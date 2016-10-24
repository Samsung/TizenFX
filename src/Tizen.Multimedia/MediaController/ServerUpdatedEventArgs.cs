/// This File contains ServerUpdatedEventArgs class
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
	/// ServerUpdated event arguments
	/// </summary>
	/// <remarks>
	/// ServerUpdated event arguments
	/// </remarks>
	public class ServerUpdatedEventArgs : EventArgs
	{
		internal ServerInformation _serverInfo;
		internal ServerState _serverState;
		internal IntPtr _userData;

		/// <summary>
		/// Constructor.
		/// </summary>
		internal ServerUpdatedEventArgs(string name, ServerState state, IntPtr userData)
		{
			_serverInfo = new ServerInformation (name, state);
			_userData = userData;
		}

		/// <summary>
		/// Get server information.
		/// </summary>
		/// <value> 0 - 100 </value>
		public ServerInformation ServerInfo
		{
			get
			{
				return _serverInfo;
			}
		}

		/// <summary>
		/// Get userData.
		/// </summary>
		/// <value> 0 - 100 </value>
		public IntPtr userData
		{
			get
			{
				return _userData;
			}
		}
	}
}

