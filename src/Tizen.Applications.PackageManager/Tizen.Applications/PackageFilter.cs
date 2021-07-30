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
    /// This class is a parameter of the PackageManager::GetPackages method.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PackageFilter
    {
        private IDictionary<string, bool> _filter;
        private IDictionary<string, string> _stringFilter;

        /// <summary>
        /// The default constructor with an empty filter list. All the installed applications will satisfy this filter unless updated with more specific filters.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PackageFilter()
        {
            _filter = new Dictionary<string, bool>();
            _stringFilter = new Dictionary<string, string>();
        }

        /// <summary>
        /// The constructor with specific filters. Using this will filter out the installed packages which do not meet the filter criteria.
        /// </summary>
        /// <param name="filter">Package filters.</param>
        /// <since_tizen> 3 </since_tizen>
        public PackageFilter(IDictionary<string, bool> filter)
        {
            _filter = filter;
        }

        /// <summary>
        /// The constructor with specific filters. Using this will filter out the installed packages which do not meet the filter criteria.
        /// </summary>
        /// <param name="stringFilter">Package filters using string values.</param>
        /// <since_tizen> 9 </since_tizen>
        public PackageFilter(IDictionary<string, string> stringFilter)
        {
            _stringFilter = stringFilter;
        }

        /// <summary>
        /// The constructor with specific filters. Using this will filter out the installed packages which do not meet the filter criteria.
        /// </summary>
        /// <param name="filter">Package filters.</param>
        /// <param name="stringFilter">Package filters using string values.</param>
        /// <since_tizen> 9 </since_tizen>
        public PackageFilter(IDictionary<string, bool> filter, IDictionary<string, string> stringFilter)
        {
            _filter = filter;
            _stringFilter = stringFilter;
        }

        /// <summary>
        /// Filters to be used in the GetPackages method.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public IDictionary<string, bool> Filters
        {
            get
            {
                return _filter;
            }
        }

        /// <summary>
        /// String filters to be used in the GetPackages method.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public IDictionary<string, string> StringFilters
        {
            get
            {
                return _stringFilter;
            }
        }

        /// <summary>
        /// This class contains possible keys for the filter to be used in the GetPackages method.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static class Keys
        {
            /// <summary>
            /// Key of the boolean property for filtering if the package is removable.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public const string Removable = "PMINFO_PKGINFO_PROP_PACKAGE_REMOVABLE";
            /// <summary>
            /// Key of the boolean property for filtering if the package is read-only.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public const string ReadOnly = "PMINFO_PKGINFO_PROP_PACKAGE_READONLY";
            /// <summary>
            /// Key of the boolean property for filtering if the package supports disabling.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public const string SupportsDisable = "PMINFO_PKGINFO_PROP_PACKAGE_SUPPORT_DISABLE";
            /// <summary>
            /// Key of the boolean property for filtering if the package is disabled.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public const string Disable = "PMINFO_PKGINFO_PROP_PACKAGE_DISABLE";
            /// <summary>
            /// Key of the boolean property for filtering if the package is preloaded.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public const string Preload = "PMINFO_PKGINFO_PROP_PACKAGE_PRELOAD";

            /// <summary>
            /// Key of the string property for filtering the resource type of the package.
            /// </summary>
            /// <since_tizen> 9 </since_tizen>
            public const string ResourceType = "PMINFO_PKGINFO_PROP_PACKAGE_RES_TYPE";
        }
    }
}
