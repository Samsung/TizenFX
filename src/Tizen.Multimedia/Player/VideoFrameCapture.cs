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
    public class VideoFrameCapture
    {
        internal byte[] _imageBuffer;
        internal int _width;
        internal int _height;
        internal uint _size;

        /// <summary>
        /// Constructor
        /// </summary>
        internal VideoFrameCapture(byte[] imageBuffer, int width, int height, uint size)
        {
            _imageBuffer = imageBuffer;
            _width = width;
            _height = height;
            _size = size;
        }


        /// <summary>
        /// Get ImageBuffer.
        /// </summary>
        /// <value> Image buffer </value>
        public byte[] ImageBuffer
        {
            get
            {
                return _imageBuffer;
            }
        }

        /// <summary>
        /// Get width.
        /// </summary>
        /// <value> Image width </value>
        public int Width
        {
            get
            {
                return _width;
            }
        }

        /// <summary>
        /// Get height.
        /// </summary>
        /// <value> Image Height </value>
        public int Height
        {
            get
            {
                return _height;
            }
        }

        /// <summary>
        /// Get Size.
        /// </summary>
        /// <value> Size of the image </value>
        public uint Size
        {
            get
            {
                return _size;
            }
        }
    }
}
