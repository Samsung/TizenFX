using System;

namespace Tizen.Multimedia
{
	public class MediaUriSource : MediaSource
	{
		public MediaUriSource (string uri)
		{
			_uri = uri;
		}

		internal string _uri;
	}
}

