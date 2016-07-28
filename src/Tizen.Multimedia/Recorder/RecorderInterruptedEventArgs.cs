using System;
using System.Collections.Generic;

namespace Tizen.Multimedia
{
    /// <summary>
    /// An extended Eventargs class which contains interrupted policy details, previous and current
    /// state of the recorder.
    /// </summary>
    public class RecorderInterruptedEventArgs : EventArgs
    {
        private RecorderPolicy _policy = RecorderPolicy.None;
        private RecorderState _previous = RecorderState.None;
        private RecorderState _current = RecorderState.None;

        internal RecorderInterruptedEventArgs(RecorderPolicy policy, RecorderState previous, RecorderState current)
        {
            _policy = policy;
            _previous = previous;
            _current = current;
        }

        /// <summary>
        /// The policy that interrupted the recorder.
        /// </summary>
        public RecorderPolicy Policy {
            get {
                return _policy;
            }
        }

        /// <summary>
        /// The previous state of the recorder.
        /// </summary>
        public RecorderState Previous {
            get {
                return _previous;
            }
        }

        /// <summary>
        /// The current state of the recorder.
        /// </summary>
        public RecorderState Current {
            get {
                return _current;
            }
        }
    }
}
