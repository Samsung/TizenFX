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
    /// This class is an event arguments of the PreferenceChanged events.
    /// </summary>
    public class PreferenceChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The key of the preference whose value is changed.
        /// </summary>
        public string Key { get; internal set; }
    }
}
