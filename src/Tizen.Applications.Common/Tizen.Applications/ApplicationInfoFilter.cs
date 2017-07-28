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
    public class ApplicationInfoFilter
    {
        /// <summary>
        ///
        /// </summary>
        public ApplicationInfoFilter()
        {
            Filter = new Dictionary<string, string>();
        }

        /// <summary>
        /// This class is a possible key to use in the InstalledApplicationFilter.
        /// </summary>
        public static class Keys
        {
            /// <summary>
            ///
            /// </summary>
            public const string Id = "PACKAGE_INFO_PROP_APP_ID";
            /// <summary>
            ///
            /// </summary>
            public const string Type = "PACKAGE_INFO_PROP_APP_TYPE";
            /// <summary>
            ///
            /// </summary>
            public const string Category = "PACKAGE_INFO_PROP_APP_CATEGORY";
            /// <summary>
            ///
            /// </summary>
            public const string NoDisplay = "PACKAGE_INFO_PROP_APP_NODISPLAY";
            /// <summary>
            ///
            /// </summary>
            public const string TaskManage = "PACKAGE_INFO_PROP_APP_TASKMANAGE";
        }

        /// <summary>
        ///
        /// </summary>
        public IDictionary<string, string> Filter
        {
            get; private set;
        }
    }
}
