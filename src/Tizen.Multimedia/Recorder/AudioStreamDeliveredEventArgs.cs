using System;

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
        private uint _recordingTime = 0;

        internal AudioStreamDeliveredEventArgs(byte[] stream, AudioSampleType type, int channel, uint recordingTime)
        {
            _stream = stream;
            _type = type;
            _channel = channel;
            _recordingTime = recordingTime;
        }

        /// <summary>
        /// The audio stream data.
        /// </summary>
        public byte[] Stream {
            get {
                return _stream;
            }
        }

        /// <summary>
        /// The audio format type.
        /// </summary>
        public AudioSampleType Type {
            get {
                return _type;
            }
        }

        /// <summary>
        /// The number of channels.
        /// </summary>
        public int Channel {
            get {
                return _channel;
            }
        }

        /// <summary>
        /// The recording time of the stream buffer in milliseconds.
        /// </summary>
        public uint RecordingTime {
            get {
                return _recordingTime;
            }
        }
    }
}
