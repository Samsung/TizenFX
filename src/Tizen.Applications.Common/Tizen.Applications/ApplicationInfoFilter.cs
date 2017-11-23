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
using System.Collections.Generic;

namespace Tizen.Applications
{
    /// <summary>
    /// This class is a parameter of the GetInstalledApplicationsAsync method.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ApplicationInfoFilter
    {
        /// <summary>
        /// A constructor of ApplicationInfoFilter class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ApplicationInfoFilter()
        {
            Filter = new Dictionary<string, string>();
        }

        /// <summary>
        /// This class is a possible key to use in the InstalledApplicationFilter.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static class Keys
        {
            /// <summary>
            /// A key to filter by application id.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public const string Id = "PACKAGE_INFO_PROP_APP_ID";
            /// <summary>
            /// A key to filter by application type.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public const string Type = "PACKAGE_INFO_PROP_APP_TYPE";
            /// <summary>
            /// A key to filter by application category.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public const string Category = "PACKAGE_INFO_PROP_APP_CATEGORY";
            /// <summary>
            /// A key to filter by nodisplay attribute.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public const string NoDisplay = "PACKAGE_INFO_PROP_APP_NODISPLAY";
            /// <summary>
            /// A key to filter by taskmanage attribute.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public const string TaskManage = "PACKAGE_INFO_PROP_APP_TASKMANAGE";
        }

        /// <summary>
        /// A dictionary to store keys and values of filter.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public IDictionary<string, string> Filter
        {
            get; private set;
        }
    }
}
