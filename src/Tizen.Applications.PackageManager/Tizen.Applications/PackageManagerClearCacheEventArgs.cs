/*
 * Copyright (c) 2024 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.ComponentModel;

namespace Tizen.Applications
{
    /// <summary>
    /// PackageManagerClearCacheEventArgs class. This class is an event arguments of the ClearCacheProgressChanged events.
    /// </summary>
    /// <since_tizen> 12 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PackageManagerClearCacheEventArgs : EventArgs
    {
        private readonly string _packageId;
        private readonly PackageEventState _state;

        internal PackageManagerClearCacheEventArgs(string packageId, PackageEventState state)
        {
            _packageId = packageId;
            _state = state;
        }

        /// <summary>
        /// Package ID, Target of clear cache event.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        public string PackageId { get { return _packageId; } }

        /// <summary>
        /// Current state of the request to the package manager.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        public PackageEventState State { get { return _state; } }
    }
}
