/// Artwork
///
/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.using System;
///

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Multimedia
{
	/// <summary>
	/// Artwork image information
	/// </summary>
	/// <remarks>
	/// This class provides properties of the artwork information of the given media
	/// </remarks>
	public class Artwork
	{
		internal Artwork(byte[] artworkData, string mimeType)
		{
			ArtworkData = artworkData;
			MimeType = mimeType;
		}

		public readonly byte[] ArtworkData;
		public readonly string MimeType;
	}
}
