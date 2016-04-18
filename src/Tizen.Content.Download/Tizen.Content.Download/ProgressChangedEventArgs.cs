using System;

namespace Tizen.Content.Download
{
    /// <summary>
    /// An extended EventArgs class which contains the size of received data in bytes.
    /// </summary>
    public class ProgressChangedEventArgs : EventArgs
    {
        private ulong _size = 0;

        internal ProgressChangedEventArgs(ulong size)
        {
            _size = size;
        }
        /// <summary>
        /// Received data size in bytes.
        /// </summary>
        public ulong ReceivedDataSize
        {
            get
            {
                return _size;
            }
        }
    }
}
