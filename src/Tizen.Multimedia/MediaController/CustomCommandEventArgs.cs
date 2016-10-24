/// This File contains CustomCommandEventArgs class
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
	public class CustomCommandEventArgs : EventArgs
	{
		internal string _clientName;
		internal string _command;
		internal IntPtr _bundle;
		internal IntPtr _userData;

		public CustomCommandEventArgs (string name, string command, IntPtr bundle, IntPtr userData)
		{
			_clientName = name;
			_command = command;
			_bundle = bundle;
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
		/// Get custom command.
		/// </summary>
		/// <value> 0 - 100 </value>
		public string Command
		{
			get
			{
				return _command;
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

