/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

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
        /// <since_tizen>3</since_tizen>
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
        /// <since_tizen>3</since_tizen>
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
        /// <since_tizen>3</since_tizen>
        public bool IsDisplay
        {
            get
            {
                return _isDisplay;
            }
        }
    }
}
