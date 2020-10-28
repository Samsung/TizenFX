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

namespace Tizen.System
{
    /// <summary>
    /// Enumeration for the storage area types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum StorageArea
    {
        /// <summary>
        /// Internal device storage (built-in storage in a device, non-removable).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Internal = Interop.Storage.StorageArea.Internal,
        /// <summary>
        /// External storage.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        External = Interop.Storage.StorageArea.External,
        /// <summary>
        /// Extended internal storage.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        ExtendedInternal = Interop.Storage.StorageArea.ExtendedInternal,
    }
}
