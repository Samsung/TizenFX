// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;

namespace Tizen.Applications
{
    /// <summary>
    /// 
    /// </summary>
    public class RegionFormatChangedEventArgs : EventArgs
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="region"></param>
        public RegionFormatChangedEventArgs(string region)
        {
            Region = region;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Region { get; private set; }
    }
}
