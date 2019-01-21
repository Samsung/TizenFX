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
    /// Enumeration for the application control result.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum AppControlReplyResult
    {
        /// <summary>
        /// The callee application launched actually.
        /// </summary>
        AppStarted = 1,

        /// <summary>
        /// The operation succeeded.
        /// </summary>
        Succeeded = 0,

        /// <summary>
        /// The operation failed by the callee.
        /// </summary>
        Failed = -1,

        /// <summary>
        /// The operation canceled by the platform.
        /// </summary>
        Canceled = -2,
    }
}
