using System;

namespace Tizen.Multimedia
{
    public class AudioStreamLengthChangedEventArgs : EventArgs
    {
        private readonly uint _length;

        internal AudioStreamLengthChangedEventArgs( uint length )
        {
            this._length = length;
        }
        public uint Length { get { return _length; } }
    }
}
