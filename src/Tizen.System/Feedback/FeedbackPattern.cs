// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

namespace Tizen.System.Feedback
{
    /// <summary>
    /// String and Enumeration for feedback patterns.
    /// </summary>
    internal struct FeedbackPattern
    {
        internal int PatternNumber;
        internal string PatternString;

        internal FeedbackPattern(int n, string s)
        {
            PatternNumber = n;
            PatternString = s;
        }
    }
}
