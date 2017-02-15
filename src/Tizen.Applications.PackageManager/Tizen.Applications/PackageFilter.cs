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

using System.Collections.Generic;

namespace Tizen.Applications
{
    /// <summary>
    /// This class is a parameter of PackageManager::GetPackages method.
    /// </summary>
    public class PackageFilter
    {
        private IDictionary<string, bool> _filter;

        /// <summary>
        /// Default constructor with empty filter list. All installed applications will satisfy this filter unless updated with more specific filters.
        /// </summary>
        public PackageFilter()
        {
            _filter = new Dictionary<string, bool>();
        }

        /// <summary>
        /// Constructor with specific filters. Using this will filter out installed packages which do not meet the criteria of the filters.
        /// </summary>
        public PackageFilter(IDictionary<string, bool> filter)
        {
            _filter = filter;
        }

        /// <summary>
        /// Filters to be used in the GetPackages method.
        /// </summary>
        public IDictionary<string, bool> Filters
        {
            get
            {
                return _filter;
            }
        }

        /// <summary>
        /// This class contains possible keys for filter to be used in the GetPackages method.
        /// </summary>
        public static class Keys
        {
            /// <summary>
            /// Key of the boolean property for filtering whether the package is removable
            /// </summary>
            public const string Removable = "PMINFO_PKGINFO_PROP_PACKAGE_REMOVABLE";
            /// <summary>
            /// Key of the boolean property for filtering whether the package is readonly.
            /// </summary>
            public const string ReadOnly = "PMINFO_PKGINFO_PROP_PACKAGE_READONLY";
            /// <summary>
            /// Key of the boolean property for filtering whether the package supports disabling.
            /// </summary>
            public const string SupportsDisable = "PMINFO_PKGINFO_PROP_PACKAGE_SUPPORT_DISABLE";
            /// <summary>
            /// Key of the boolean property for filtering whether the package is disabled.
            /// </summary>
            public const string Disable = "PMINFO_PKGINFO_PROP_PACKAGE_DISABLE";
            /// <summary>
            /// Key of the boolean property for filtering whether the package is preloaded.
            /// </summary>
            public const string Preload = "PMINFO_PKGINFO_PROP_PACKAGE_PRELOAD";
        }
    }
}
