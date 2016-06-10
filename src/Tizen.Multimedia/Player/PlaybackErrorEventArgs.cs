/// This File contains PlaybackErrorEventArgs class
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
    /// PlaybackError event arguments
    /// </summary>
    /// <remarks>
    /// PlaybackError event arguments
    /// </remarks>
    public class PlaybackErrorEventArgs : EventArgs
    {
		internal int _errorCode;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="errocode"> Playback error code </param>
		public PlaybackErrorEventArgs(int errorCode)
		{
			_errorCode = errorCode;
		}

        /// <summary>
        /// Get the error code.
        /// </summary>
        /// <value> integer error code</value>
        public int ErrorCode 
        {
            get
            {
                return _errorCode;
            }
        }
    }
}