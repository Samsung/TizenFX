using System;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Argument for the event that is Audio State Changed.
    /// </summary>
    public class AudioStateChangedEventArgs : EventArgs
    {
        private readonly AudioState _previous;
        private readonly AudioState _current;
        private readonly bool _by_policy;
        /// <summary>
        /// Initializes the instance of the AudioStateChangedEventArgs class. 
        /// </summary>
        /// <param name="_prev"></param>
        /// <param name="_current"></param>
        /// <param name="by_policy"></param>
        internal AudioStateChangedEventArgs(AudioState previous, AudioState current, bool by_policy) 
        {
            this._previous = previous;
            this._current = current;
            this._by_policy = by_policy;
        }

        public AudioState Previous { get { return _previous; } }
        public AudioState Current { get { return _current; } }
        public bool Policy { get { return _by_policy; } }
    }
}
