/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// Enumeration for payload result code.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public enum PayloadAsyncResultCode
    {
        /// <summary>
        /// Fail to get the result code.
        /// </summary>
        Error = -1,
        /// <summary>
        /// The async request result is not yet received.
        /// </summary>
        Pending = 0,
        /// <summary>
        /// The async request result is success.
        /// </summary>
        Success,
        /// <summary>
        /// The async request result is fail.
        /// </summary>
        Fail,
    }
}
