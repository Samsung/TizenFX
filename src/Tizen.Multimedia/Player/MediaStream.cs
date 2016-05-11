/// Media Stream
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
    /// MediaStream
    /// </summary>
    /// <remarks>
    /// MediaStream class for media stream configuration.
    /// </remarks>

    class MediaStream
    {
        /// <summary>
        /// Get/Set Audio Media format.
        /// </summary>
        /// <value> MediaFormat </value>
        //public MediaFormat AudioMediaFormat { get; set; }

        /// <summary>
        /// Get/Set Video Media format.
        /// </summary>
        /// <value> MediaFormat </value>
        //public MediaFormat VideoMediaFormat { get; set; }

        /// <summary>
        /// Get/Set Audio configuration.
        /// </summary>
        /// <value> MediaStreamConfiguration </value>
        public MediaStreamConfiguration AudioConfiguration 
        {
            get
            {
                return _audioConfiguration;
            }
        }

        /// <summary>
        /// Get/Set Video configuration.
        /// </summary>
        /// <value> MediaStreamConfiguration </value>
        public MediaStreamConfiguration VideoConfiguration 
        {
            get
            {
                return _videoConfiguration;
            }
        }

        /// <summary>
        /// Get/Set Video Media format.
        /// </summary>
        /// <value> MediaFormat </value>
        //public MediaFormat VideoMediaFormat { get; set; }


        /// <summary>
        /// Push Media stream </summary>
        /// <param name="packet"> media packet</param>
        //public void PushMediaStream(MediaPacket packet);


        internal MediaStreamConfiguration _audioConfiguration;
        internal MediaStreamConfiguration _videoConfiguration;
    }
}
