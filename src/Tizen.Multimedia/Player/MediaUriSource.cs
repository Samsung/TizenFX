/// Media Uri source
///
/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System;

namespace Tizen.Multimedia
{
	public class MediaUriSource : MediaSource
	{
		private string _uri;

		/// <summary>
		/// Constructor </summary>
		/// <param name="uri"> uri string </param>
		public MediaUriSource(string uri)
		{
			_uri = uri;
		}

		internal string GetUri()
		{
			return _uri;
		}

	}
}

