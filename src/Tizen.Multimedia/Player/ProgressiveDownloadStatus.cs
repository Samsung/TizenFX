/// Progressive Download Status
///
/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;

namespace Tizen.Multimedia
{

    /// <summary>
    /// DownloadProgress
    /// </summary>
    /// <remarks>
    /// Contains Progressive download status
    /// </remarks>
	public class ProgressiveDownloadStatus
    {
        /// <summary>
        /// Get current download position (bytes) 
        /// </summary>
        /// <value> current download position </value>
        public ulong Current
		{
			set
			{
				_current = value;
			}
			get
			{
				return _current;
			}
		}

        /// <summary>
        /// Get total size of the file (bytes) 
        /// </summary>
        /// <value> Total size of file (bytes) </value>
        public ulong TotalSize
		{
			set
			{
				_totalSize = value;
			}
			get
			{
				return _totalSize;
			}
		}

		internal ulong _current;
		internal ulong _totalSize;
    }
}