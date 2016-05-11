/// Source Factory
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
    /// SourceFactory
    /// </summary>
    /// <remarks>
    /// Factory class for getting player source.
    /// </remarks>

    class SourceFactory
    {
        /// <summary>
        /// GetSource </summary>
        /// <param name="uri"> source uri string </param>
        /// <returns>PlayerSource</returns>
        public static PlayerSource GetSource(string uri)
        {
            return null;
        }

        /// <summary>
        /// GetSource </summary>
        /// <param name="buffer"> memory buffer </param>
        /// <returns>PlayerSource</returns>
        public static PlayerSource GetSource(byte[] buffer)
        {
            return null;
        }

        /// <summary>
        /// GetSource </summary>
        /// <param name="mediastream"> media stream</param>
        /// <returns>PlayerSource</returns>
        public static PlayerSource GetSource(MediaStream mediaStream)
        {
            return null;
        }
    }
}
