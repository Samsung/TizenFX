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
    /// Resource control.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class ResControl
    {
        internal ResControl(string resType, string minResVersion, string maxResVersion, bool isAutoClose)
        {
            ResType = resType;
            MinResVersion = minResVersion;
            MaxResVersion = maxResVersion;
            IsAutoClose = isAutoClose;
        }

        /// <summary>
        /// The resource type.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string ResType { get; }

        /// <summary>
        /// The minimum version of required resource package.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string MinResVersion { get; }

        /// <summary>
        /// The maximum version of required resource package.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string MaxResVersion { get; }

        /// <summary>
        /// The auto close property.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public bool IsAutoClose { get; }
    }
}
