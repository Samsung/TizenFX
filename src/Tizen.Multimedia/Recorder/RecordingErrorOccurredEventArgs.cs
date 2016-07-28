using System;

namespace Tizen.Multimedia
{
    /// <summary>
    /// An extended EventArgs class which contains details about error status and
    /// state of the recorder when it failed.
    /// </summary>
    public class RecordingErrorOccurredEventArgs : EventArgs
    {
        private RecorderErrorCode _error = RecorderErrorCode.DeviceError;
        private RecorderState _state = RecorderState.None;

        internal RecordingErrorOccurredEventArgs(RecorderErrorCode error, RecorderState state)
        {
            _error = error;
            _state = state;
        }

        /// <summary>
        /// The error code.
        /// </summary>
        public RecorderErrorCode Error {
            get {
                return _error;
            }
        }

        /// <summary>
        /// The state of the recorder.
        /// </summary>
        public RecorderState State {
            get {
                return _state;
            }
        }

    }
}
