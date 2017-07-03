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
    /// Enumeration for the state of storage devices.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum StorageState
    {
        /// <summary>
        /// Storage is present but cannot be mounted. Typically it happens if the file system of the storage is corrupted
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Unmountable = Interop.Storage.StorageState.Unmountable,
        /// <summary>
        /// Storage is not present or removed
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Removed = Interop.Storage.StorageState.Removed,
        /// <summary>
        /// Storage is mounted with read/write access
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Mounted = Interop.Storage.StorageState.Mounted,
        /// <summary>
        /// Storage is mounted with read only access
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        MountedReadOnly = Interop.Storage.StorageState.MountedReadOnly,
    }
}
