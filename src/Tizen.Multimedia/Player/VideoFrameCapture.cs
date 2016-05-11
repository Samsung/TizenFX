/// VideoFrameCapture
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
    /// VideoFrameCapture
    /// </summary>
    /// <remarks>
    /// VideoSize class provides properties of a captured video frame
    /// </remarks>
    class VideoFrameCapture
    {

        /// <summary>
        /// Get/Set ImageBuffer.
        /// </summary>
        /// <value> Image buffer </value>
        public byte[] ImageBuffer { set; get; }

        /// <summary>
        /// Get/Set width.
        /// </summary>
        /// <value> Image width </value>
        public int Width { set; get; }

        /// <summary>
        /// Get/Set height.
        /// </summary>
        /// <value> Image Height </value>
        public int Height { set; get; }

        /// <summary>
        /// Get/Set Size.
        /// </summary>
        /// <value> Size of the image </value>
        public uint Size { set; get; }
    }
}
