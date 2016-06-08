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
