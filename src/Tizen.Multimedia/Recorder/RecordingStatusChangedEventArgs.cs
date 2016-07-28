using System;

namespace Tizen.Multimedia
{
    /// <summary>
    /// An extened EventArgs class which contain the details of current recording status.
    /// </summary>
    public class RecordingStatusChangedEventArgs : EventArgs
    {
        private ulong _time = 0;
        private ulong _fileSize = 0;

        internal RecordingStatusChangedEventArgs(ulong time, ulong fileSize)
        {
            _time = time;
            _fileSize = fileSize;
        }

        /// <summary>
        /// The time of recording in milliseconds.
        /// </summary>
        public ulong ElapsedTime {
            get {
                return _time;
            }
        }

        /// <summary>
        /// The size of the recording file in Kilobyte.
        /// </summary>
        public ulong FileSize {
            get { 
                return _fileSize;
            }
        }
    }
}
