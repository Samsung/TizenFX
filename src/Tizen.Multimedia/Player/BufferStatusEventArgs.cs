/// This File contains BufferStatusEventArgs class
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
    /// BufferStatus event arguments
    /// </summary>
    /// <remarks>
    /// BufferStatus event arguments
    /// </remarks>
    public class BufferStatusEventArgs : EventArgs
    {
		internal StreamingBufferStatus _status;
		internal StreamType _streamType;

		/// <summary>
		/// Constructor.
		/// </summary>
		internal BufferStatusEventArgs(StreamingBufferStatus status, StreamType type)
		{
			_status = status;
			_streamType = type;
		}

        /// <summary>
        /// Get stream type.
        /// </summary>
        /// <value> Audio, Video, Text </value>
        public StreamType StreamType
        {
            get
            {
                return _streamType;
            }
        }
        
        /// <summary>
        /// Get buffering status.
        /// </summary>
        /// <value> Underrun, Overflow </value>
        public StreamingBufferStatus Status 
        {
            get
            {
                return _status;
            }
        }
    }
}