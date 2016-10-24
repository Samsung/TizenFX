/// This File contains MetadataUpdatedEventArgs class
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
	/// MetadataUpdated event arguments
	/// </summary>
	/// <remarks>
	/// MetadataUpdated event arguments
	/// </remarks>
	public class MetadataUpdatedEventArgs : EventArgs
	{
		internal string _serverName;
		internal Metadata _metadata;
		internal IntPtr _userData;

		public MetadataUpdatedEventArgs (string name, IntPtr handle, IntPtr userData)
		{
			_serverName = name;
			_metadata = new Metadata (handle);
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
		public Metadata Metadata
		{
			get
			{
				return _metadata;
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

