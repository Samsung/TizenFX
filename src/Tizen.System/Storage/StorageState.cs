// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

namespace Tizen.System
{
    /// <summary>
    /// Enumeration for the state of storage devices.
    /// </summary>
    public enum StorageState
    {
        /// <summary>
        /// Storage is present but cannot be mounted. Typically it happens if the file system of the storage is corrupted
        /// </summary>
        Unmountable = Interop.Storage.StorageState.Unmountable,
        /// <summary>
        /// Storage is not present or removed
        /// </summary>
        Removed = Interop.Storage.StorageState.Removed,
        /// <summary>
        /// Storage is mounted with read/write access
        /// </summary>
        Mounted = Interop.Storage.StorageState.Mounted,
        /// <summary>
        /// Storage is mounted with read only access
        /// </summary>
        MountedReadOnly = Interop.Storage.StorageState.MountedReadOnly,
    }
}