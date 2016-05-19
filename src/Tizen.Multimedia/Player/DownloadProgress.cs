/// Download progress
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
    /// Contains Download progress
    /// </remarks>
	public class DownloadProgress
    {
        /// <summary>
        /// Set/Get Start position in percentage.
        /// </summary>
        /// <value> 0 to 100 </value>
        public int Start
		{
			set
			{
				_start = value;
			}
			get
			{
				return _start;
			}
		}

        /// <summary>
        /// Set/Get Current position in percentage.
        /// </summary>
        /// <value> 0 to 100 </value>
        public int Current
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

		internal DownloadProgress()
		{
		}

		internal int _start;
		internal int _current;
    }
}