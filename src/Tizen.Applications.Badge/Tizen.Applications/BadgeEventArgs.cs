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
    /// Class for event arguments of the badge event
    /// </summary>
    public class BadgeEventArgs : EventArgs
    {
        /// <summary>
        /// Enumeration for badge action.
        /// </summary>
        public enum Action : int
        {
            /// <summary>
            /// Badge was added.
            /// </summary>
            Add = 0,

            /// <summary>
            /// Badge was removed.
            /// </summary>
            Remove,

            /// <summary>
            /// Badge was updated.
            /// </summary>
            Update,
        }

        /// <summary>
        /// Property for Badge object.
        /// </summary>
        public Badge Badge { get; internal set; }

        /// <summary>
        /// Property for Action value.
        /// </summary>
        public Action Reason { get; internal set; }
    }
}
