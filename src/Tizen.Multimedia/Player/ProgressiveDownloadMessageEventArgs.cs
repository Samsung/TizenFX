/// This File contains ProgressiveDownloadMessageEventArgs class
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
    /// ProgressiveDownloadMessage event arguments
    /// </summary>
    /// <remarks>
    /// ProgressiveDownloadMessage event arguments
    /// </remarks>
	public class ProgressiveDownloadMessageEventArgs : EventArgs
    {
        /// <summary>
        /// Get Progressive download message.
        /// </summary>
        /// <value> 0 - 100 </value>
        public ProgressiveDownloadMessage Message 
        {
            get
            {
                return _message;
            }
        }

		/// <summary>
		/// Constructor
		/// </summary>
		public ProgressiveDownloadMessageEventArgs(ProgressiveDownloadMessage message)
		{
			_message = message;
		}

        internal ProgressiveDownloadMessage _message;

    }
}