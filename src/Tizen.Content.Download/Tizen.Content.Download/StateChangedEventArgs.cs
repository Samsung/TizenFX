using System;

namespace Tizen.Content.Download
{
    /// <summary>
    /// An extended EventArgs class which contains the changed download state.
    /// </summary>
    public class StateChangedEventArgs : EventArgs
    {
        private DownloadState _state;

        internal StateChangedEventArgs(DownloadState downloadState)
        {
            _state = downloadState;
        }
        /// <summary>
        /// Present download state.
        /// </summary>
        public DownloadState State
        {
            get
            {
                return _state;
            }
        }
    }
}
