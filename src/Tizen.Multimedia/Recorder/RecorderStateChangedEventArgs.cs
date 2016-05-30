using System;

namespace Tizen.Multimedia
{
    /// <summary>
    /// An extended EventArgs class which contains details about previous and current state
    /// of the recorder when its state is changed.
    /// </summary>
    public class RecorderStateChangedEventArgs : EventArgs
    {
		private RecorderState _previous = RecorderState.None;
		private RecorderState _current = RecorderState.None;
		private bool _policy = false;

		internal RecorderStateChangedEventArgs(RecorderState previous, RecorderState current, bool policy)
		{
			_previous = previous;
			_current = current;
			_policy = policy;
		}

        /// <summary>
        /// Previous state of the recorder.
        /// </summary>
        public RecorderState Previous
        {
            get
			{
				return _previous;
			}
        }

        /// <summary>
        /// Current state of the recorder.
        /// </summary>
        public RecorderState Current
        {
            get
			{
				return _current;
			}
        }

        /// <summary>
        /// true if the state changed by policy, otherwise false.
        /// </summary>
        public bool ByPolicy
        {
            get
			{
				return _policy;
			}
        }
    }
}
