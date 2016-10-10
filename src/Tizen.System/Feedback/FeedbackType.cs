// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

namespace Tizen.System
{
    /// <summary>
    /// Enumeration for feedback device types.
    /// </summary>
    public enum FeedbackType
    {
        /// <summary>
        ///  Sound and Vibration
        /// </summary>
        All = 0,
        /// <summary>
        /// Sound feedback
        /// </summary>
        Sound = Interop.Feedback.FeedbackType.Sound,
        /// <summary>
        /// Vibration
        /// /// </summary>
        Vibration = Interop.Feedback.FeedbackType.Vibration,
    }
}
