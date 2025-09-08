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

using System;

namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// Enumeration for the result of response.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API level 13")]
    public enum ResponseCode
    {
        /// <summary>
        /// Indicates the result of response for success.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Ok = 0,
        /// <summary>
        /// Indicates the result of response for some error.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Error,
        /// <summary>
        /// Indicates the result of response for created resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Created,
        /// <summary>
        /// Indicates the result of response for deleted resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Deleted,
        /// <summary>
        /// Indicates the result of response for changed resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Changed,
        /// <summary>
        /// Indicates the result of response for slow resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Slow,
        /// <summary>
        /// Indicates the result of response for accessing unauthorized resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Forbidden
    }
}
