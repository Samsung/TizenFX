// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System.Collections.Generic;

namespace Tizen.Applications
{
    /// <summary>
    /// This class is a parameter of PackageManager::GetPackagesAsync method.
    /// </summary>
    public class PackageFilter
    {
        private IDictionary<string, bool> _filter;

        /// <summary>
        /// Constructor
        /// </summary>
        public PackageFilter()
        {
            _filter = new Dictionary<string, bool>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public PackageFilter(IDictionary<string, bool> filter)
        {
            _filter = filter;
        }

        /// <summary>
        /// Filters to be used in the GetPackagesAsync method.
        /// </summary>
        public IDictionary<string, bool> Filters
        {
            get
            {
                return _filter;
            }
        }

        /// <summary>
        /// This class contains possible keys for filter to be used in the GetPackagesAsync method.
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