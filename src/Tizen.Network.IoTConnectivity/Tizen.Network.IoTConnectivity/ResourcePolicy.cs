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
    /// Enumeration for policy which can be held in a resource.
    /// </summary>
    public enum ResourcePolicy
    {
        /// <summary>
        /// Indicates resource uninitialized
        /// </summary>
        NoProperty = 0,
        /// <summary>
        /// Indicates resource that is allowed to be discovered
        /// </summary>
        Discoverable = (1 << 0),
        /// <summary>
        /// Indicates resource that is allowed to be observed
        /// </summary>
        Observable = (1 << 1),
        /// <summary>
        /// Indicates resource initialized and activated
        /// </summary>
        Active = (1 << 2),
        /// <summary>
        /// Indicates resource which takes some delay to respond
        /// </summary>
        Slow = (1 << 3),
        /// <summary>
        /// Indicates secure resource
        /// </summary>
        Secure = (1 << 4),
        /// <summary>
        /// When this bit is set, the resource is allowed to be discovered only if discovery request contains an explicit querystring.
        /// </summary>
        ExplicitDiscoverable = (1 << 5),
    }
}
