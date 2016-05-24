using System;

namespace Tizen.Multimedia
{
	public class MediaUriSource : MediaSource
	{
		public MediaUriSource(string uri)
		{
			_uri = uri;
		}

		internal string GetUri()
		{
			return _uri;
		}

		private string _uri;
	}
}

