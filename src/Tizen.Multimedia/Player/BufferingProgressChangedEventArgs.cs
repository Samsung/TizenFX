/// This File contains BufferingProgressChangedEventArgs class
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
    /// BufferingProgress event arguments
    /// </summary>
    /// <remarks>
    /// BufferingProgress event arguments
    /// </remarks>
    public class BufferingProgressEventArgs : EventArgs
    {
        /// <summary>
        /// Get buffering percentage.
        /// </summary>
        /// <value> 0 - 100 </value>
        public int Percent 
        {
            get
            {
                return _percent;
            }
        }

        internal int _percent;

    }
}