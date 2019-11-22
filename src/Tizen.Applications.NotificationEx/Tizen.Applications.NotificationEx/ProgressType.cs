/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications.NotificationEx
{
    /// <summary>
    /// Enumeration for progress item type.
    /// </summary>
    /// <since_tizen> 7 </since_tizen>
    public enum ProgressType
    {
        /// <summary>
        /// The default progress type
        /// </summary>
        Default,
        
        /// <summary>
        /// The time progress type
        /// </summary>
        Time,

        /// <summary>
        /// The percentage progress type
        /// </summary>
        Percent,

        /// <summary>
        /// The pending progress type
        /// </summary>
        Pending
    }
}
