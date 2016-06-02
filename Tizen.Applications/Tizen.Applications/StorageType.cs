// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

namespace Tizen.Applications
{
    /// <summary>
    /// Enumeration for storage type.
    /// </summary>
    public enum StorageType
    {
        /// <summary>
        /// Internal storage.
        /// </summary>
        Internal = Interop.PackageManager.StorageType.Internal,
        /// <summary>
        /// External storage.
        /// </summary>
        External = Interop.PackageManager.StorageType.External
    }
}