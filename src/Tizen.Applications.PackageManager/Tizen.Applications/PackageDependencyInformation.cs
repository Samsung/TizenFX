/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications
{
    /// <summary>
    /// This class has read-only properties to get the package dependency information.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class PackageDependencyInformation
    {
        private string _from;
        private string _to;
        private string _type;
        private string _required_version;

        public PackageDependencyInformation(string from, string to, string type, string required_version)
        {
            _from = from;
            _to = to;
            _type = type;
            _required_version = required_version;
        }

        /// <summary>
        /// The pacakge to.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string From { get { return _from; } }

        /// <summary>
        /// The package from.
        /// </summary>
        /// <since_tizen>  </since_tizen>
        public string To { get { return _to; } }

        /// <summary>
        /// The required version.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Type { get { return _type; } }

        /// <summary>
        /// The required_version of package.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string RequiredVersion { get { return _required_version; } }
    }
}