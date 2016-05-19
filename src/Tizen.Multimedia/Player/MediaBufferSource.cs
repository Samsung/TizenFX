using System;

namespace Tizen.Multimedia
{
	public class MediaBufferSource : MediaSource
	{
		public MediaBufferSource (byte[] buffer)
		{
			_buffer = buffer;
		}

		internal byte[] _buffer;
	}
}

