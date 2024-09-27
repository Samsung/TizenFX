/*
 * Copyright (c) 2016 - 2017 Samsung Electronics Co., Ltd. All rights reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace Tizen.Applications
{
    /// <summary>
    /// The class containing common properties of the Badge.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API12. Will be removed in API14.")]
    public class Badge
    {
        private int count = 0;

        /// <summary>
        /// Initializes a new instance of the Badge class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="appId">Application ID</param>
        /// <param name="count">Count value</param>
        /// <param name="visible">True if it should be displayed</param>
        /// <exception cref="ArgumentException">Thrown when failed because of invalid argument</exception>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
        public Badge(string appId, int count = 1, bool visible = true)
        {
            if (IsNegativeNumber(count))
            {
                throw BadgeErrorFactory.GetException(BadgeError.InvalidParameter, "The count must be positive number");
            }
            AppId = appId;
            this.count = count;
            Visible = visible;
        }

        /// <summary>
        /// Property for the count value of the badge.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="ArgumentException">Thrown when set negative number</exception>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                if (IsNegativeNumber(value))
                {
                    throw BadgeErrorFactory.GetException(BadgeError.InvalidParameter, "The count must be positive number");
                }

                count = value;
            }
        }

        /// <summary>
        /// Property for the application ID of the badge.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
        public string AppId { get; set; }

        /// <summary>
        /// Property for display visibility. True if the badge display visible, otherwise false..
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
        public bool Visible{ get; set; }

        private bool IsNegativeNumber(int number)
        {
            return number < 0;
        }
    }
}
