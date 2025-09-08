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
    /// Enumeration for the policy, which can be held in a resource.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API level 13")]
    public enum ResourcePolicy
    {
        /// <summary>
        /// Indicates resource uninitialized.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        NoProperty = 0,
        /// <summary>
        /// Indicates resource that is allowed to be discovered.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Discoverable = (1 << 0),
        /// <summary>
        /// Indicates resource that is allowed to be observed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Observable = (1 << 1),
        /// <summary>
        /// Indicates resource initialized and activated.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Active = (1 << 2),
        /// <summary>
        /// Indicates resource, which takes some delay to respond.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Slow = (1 << 3),
        /// <summary>
        /// Indicates secure resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Secure = (1 << 4),
        /// <summary>
        /// When this bit is set, the resource is allowed to be discovered only if discovery request contains an explicit querystring.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        ExplicitDiscoverable = (1 << 5),
    }
}
