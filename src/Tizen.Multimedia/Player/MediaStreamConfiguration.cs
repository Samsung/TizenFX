/// Media Stream configuration
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
    /// MediaStream configuration
    /// </summary>
    /// <remarks>
    /// MediaStreamConfiguration class for media stream configuration.
    /// </remarks>

    public class MediaStreamConfiguration
    {

        /// <summary>
        /// BufferStatusChanged event is raised when buffer underrun or overflow occurs. 
        /// </summary>
        public event EventHandler<BufferStatusEventArgs> BufferStatusChanged;

        /// <summary>
        /// SeekOffsetChanged event is raised when seeking occurs. 
        /// </summary>
        public event EventHandler<SeekOffsetEventArgs> SeekOffsetChanged;



        /// <summary>
        /// max size bytes of buffer </summary>
        /// <value> Max size in bytes </value>
        public ulong BufferMaxSize { get; set; }

        /// <summary>
        /// Min threshold </summary>
        /// <value> min threshold in bytes </value>
        public uint BufferMinThreshold { get; set; }

    }
}
