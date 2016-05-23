using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Multimedia
{
    /// <summary>
    /// An extended EventArgs class containing details of audio stream.
    /// </summary>
    public class AudioStreamDeliveredEventArgs : EventArgs
    {
		private byte[] _stream = null;
		private AudioSampleType _type = AudioSampleType.S16Le;
		private int _channel = 0;
		private uint _timeStamp = 0;

		internal AudioStreamDeliveredEventArgs(byte[] stream, AudioSampleType type, int channel, uint timeStamp)
		{
			_stream = stream;
			_type = type;
			_channel = channel;
			_timeStamp = timeStamp;
		}

        /// <summary>
        /// The audio stream data.
        /// </summary>
        public byte[] Stream
        {
            get
			{
				return _stream;
			}
        }

        /// <summary>
        /// The audio format type.
        /// </summary>
        public AudioSampleType Type
        {
            get
			{
				return _type;
			}
        }

        /// <summary>
        /// The number of channels.
        /// </summary>
        public int Channel
        {
            get
			{
				return _channel;
			}
        }

        /// <summary>
        /// The timestamp of the stream buffer in milliseconds.
        /// </summary>
        public uint TimeStamp
        {
            get
			{
				return _timeStamp;
			}
        }
    }
}
