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

namespace Tizen.Applications
{
    using System;

    /// <summary>
    /// The class for event arguments of the badge event.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API12. Will be removed in API14.")]
    public class BadgeEventArgs : EventArgs
    {
        internal BadgeEventArgs()
        {
        }

        /// <summary>
        /// Enumeration for the badge action.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
        public enum Action : int
        {
            /// <summary>
            /// The badge was added.
            /// </summary>
            Add = 0,

            /// <summary>
            /// The badge was removed.
            /// </summary>
            Remove,

            /// <summary>
            /// The badge was updated.
            /// </summary>
            Update,
        }

        /// <summary>
        /// The property for the badge object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
        public Badge Badge { get; internal set; }

        /// <summary>
        /// The property for the action value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
        public Action Reason { get; internal set; }
    }
}
