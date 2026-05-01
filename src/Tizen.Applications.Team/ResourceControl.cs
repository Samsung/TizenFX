/*
 * Copyright (c) 2026 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.ComponentModel;
using System.Text;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents the resource control information for a Team application.
    /// </summary>
    /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// Gets the resource type.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ResourceType { get; }

        /// <summary>
        /// Gets the minimum version of the required resource package.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string MinResourceVersion { get; }

        /// <summary>
        /// Gets the maximum version of the required resource package.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string MaxResourceVersion { get; }

        /// <summary>
        /// Gets a value indicating whether the resource is auto-closed.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsAutoClose { get; }
    }
}
