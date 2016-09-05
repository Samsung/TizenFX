// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

namespace Tizen.Applications
{
    /// <summary>
    /// Immutable class for getting information of the badge.
    /// </summary>
    public class Badge
    {
        private readonly string _appId;
        private readonly int _count;
        private readonly bool _isDisplay;

        internal Badge(string appid, int count, bool isDisplay)
        {
            _appId = appid;
            _count = count;
            _isDisplay = isDisplay;
        }

        /// <summary>
        /// Property for the count value of the badge.
        /// </summary>
        public int Count
        {
            get
            {
                return _count;
            }
        }

        /// <summary>
        /// Property for the application ID of the badge.
        /// </summary>
        public string AppId
        {
            get
            {
                return _appId;
            }
        }

        /// <summary>
        /// Property for the flag of 'display'.
        /// </summary>
        public bool IsDisplay
        {
            get
            {
                return _isDisplay;
            }
        }
    }
}
