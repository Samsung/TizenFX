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

namespace Tizen.Applications
{
    /// <summary>
    /// PackageManagerEventArgs class. This class is an event arguments of the InstallProgressChanged, UninstallProgressChanged, and UpdateProgressChanged events.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PackageManagerEventArgs : EventArgs
    {
        private readonly PackageType _packageType;
        private readonly string _packageId;
        private readonly PackageEventState _state;
        private readonly int _progress;

        internal PackageManagerEventArgs(string packageType, string packageId, PackageEventState state, int progress)
        {
            _packageType = PackageTypeMethods.ToPackageType(packageType);
            _packageId = packageId;
            _state = state;
            _progress = progress;
        }

        /// <summary>
        /// Type of the package to be installed, uninstalled, or updated.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PackageType PackageType { get { return _packageType; } }

        /// <summary>
        /// Package ID to be installed, uninstalled, or updated.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string PackageId { get { return _packageId; } }

        /// <summary>
        /// Current state of the request to the package manager.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PackageEventState State { get { return _state; } }

        /// <summary>
        /// Progress for the request being processed by the package manager (in percent).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Progress { get { return _progress; } }
    }
}
