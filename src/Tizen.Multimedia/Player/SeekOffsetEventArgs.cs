/// This File contains SeekOffsetEventArgs class
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
    /// SeekOffset event arguments
    /// </summary>
    /// <remarks>
    /// SeekOffset event arguments
    /// </remarks>
    public class SeekOffsetEventArgs : EventArgs
    {
		internal UInt64 _offset;

		/// <summary>
		/// Constructor.
		/// </summary>
		public SeekOffsetEventArgs(UInt64 offset)
		{
			_offset = offset;
		}

        /// <summary>
        /// Get seek offset.
        /// </summary>
        /// <value> byte position to seek  </value>
		public UInt64 Offset 
        {
            get
            {
                return _offset;
            }
        }

    }
}