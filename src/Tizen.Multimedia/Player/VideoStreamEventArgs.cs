/// This File contains VideoStreamEventArgs class
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
    /// VideoStreamEventArgs event arguments
    /// </summary>
    /// <remarks>
    /// VideoStreamEventArgs event arguments
    /// </remarks>
	public class VideoStreamEventArgs : EventArgs
    {
		internal int _height;
		internal int _width;
		internal int _fps;
		internal int _bitrate;

		/// <summary>
		/// Constructor.
		/// </summary>
		internal VideoStreamEventArgs(int height, int width, int fps, int bitrate)
		{
			_height = height;
			_width = width;
			_fps = fps;
			_bitrate = bitrate;
		}

        /// <summary>
        /// Get Video Height.
        /// </summary>
        /// <value> video height </value>
        public int Height 
        {
            get
            {
                return _height;
            }
        }

        /// <summary>
        /// Get Video Width.
        /// </summary>
        /// <value> video width </value>
        public int Width 
        {
            get
            {
                return _width;
            }
        }
        
        /// <summary>
        /// FPS
        /// </summary>
        /// <value> int Frames per second</value>
        public int Fps 
        {
            get
            {
                return _fps;
            }
        }

        /// <summary>
        /// Bit rate.
        /// </summary>
        /// <value> bit rate [Hz] </value>
        public int BitRate 
        {
            get
            {
                return _bitrate;
            }
        }

    }
}