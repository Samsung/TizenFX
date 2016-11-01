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
    /// This class provides properties of the artwork information of the given media
    /// </summary>
    public class Artwork
	{
		internal Artwork(byte[] artworkData, string mimeType)
		{
            ArtworkData = artworkData;
			MimeType = mimeType;
		}
        /// <summary>
        /// The encoded artwork image
        /// </summary>
        public readonly byte[] ArtworkData;

        /// <summary>
        /// The mime type of artwork
        /// </summary>
        public readonly string MimeType;
	}
}
