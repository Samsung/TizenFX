/// Media buffer source
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
    /// The MediaBufferSource class used to set source to the player.
    /// </summary>
    /// <remarks>
    /// MediaBufferSource object is created using buffer containing
    /// media content. Then the object is set to the player as source.
    /// </remarks>
    public class MediaBufferSource : MediaSource
    {
        internal byte[] _buffer;

        /// <summary>
        /// Constructor - sets media buffer </summary>
        /// <param name="buffer"> source buffer </param>
        public MediaBufferSource(byte[] buffer)
        {
            _buffer = buffer;
        }

    }
}

