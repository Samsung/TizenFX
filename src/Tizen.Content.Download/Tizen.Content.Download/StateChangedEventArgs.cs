// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

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
