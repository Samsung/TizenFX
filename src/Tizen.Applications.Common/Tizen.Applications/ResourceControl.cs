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

using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents the resource control information.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class ResourceControl
    {
        internal ResourceControl(string resourceType, string minResourceVersion, string maxResourceVersion, bool isAutoClose)
        {
            ResourceType = resourceType;
            MinResourceVersion = minResourceVersion ?? null;
            MaxResourceVersion = maxResourceVersion ?? null;
            IsAutoClose = isAutoClose;
        }

        /// <summary>
        /// The resource type.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string ResourceType { get; }

        /// <summary>
        /// The minimum version of required resource package.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string MinResourceVersion { get; }

        /// <summary>
        /// The maximum version of required resource package.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string MaxResourceVersion { get; }

        /// <summary>
        /// The auto close property.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public bool IsAutoClose { get; }
    }
}
