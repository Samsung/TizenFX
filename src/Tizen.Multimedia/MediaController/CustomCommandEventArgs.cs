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
using Tizen.Applications;

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
		internal Bundle _bundle;

		public CustomCommandEventArgs (string name, string command, Bundle bundle)
		{
			_clientName = name;
			_command = command;
			_bundle = bundle;
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
		public Bundle BundleData
		{
			get
			{
				return _bundle;
			}
		}
	}
}

