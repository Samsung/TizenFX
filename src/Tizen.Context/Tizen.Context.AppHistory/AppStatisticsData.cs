/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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

 using System;

namespace Tizen.Context.AppHistory
{
    /// <summary>
    /// The Base class which contains the application statistics query result.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    [Obsolete("Deprecated since API13, will be removed in API15.")]
    public abstract class AppStatisticsData
    {
        internal AppStatisticsData()
        {
        }

        /// <summary>
        /// Gets the application ID.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <value>The application ID.</value>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public string AppId { get; protected set; }
    }
}
