/// ServerInformation
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
	/// ServerInformation represents a name and state of server application.
	/// </summary>
	public class ServerInformation
	{
		internal ServerInformation(string _name, ServerState _state)
		{
			Name = _name;
			State = _state;
		}

		/// <summary>
		/// The name of server
		/// </summary>
		public readonly string Name;

		/// <summary>
		/// The state of server
		/// </summary>
		public readonly ServerState State;
	}
}

