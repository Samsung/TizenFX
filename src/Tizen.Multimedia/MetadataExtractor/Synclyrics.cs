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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Multimedia
{
	/// <summary>
	/// Synchronized lyrics information
	/// </summary>
	/// <remarks>
	/// This class provides properties of the synchronized lyrics information of the given media
	/// </remarks>
	public class Synclyrics
	{
		internal Synclyrics(string lyrics, uint timestamp)
		{
			Lyrics = lyrics;
			Timestamp = timestamp;
		}
		public readonly string Lyrics;
		public readonly uint Timestamp;
	}
}
