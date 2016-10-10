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
    /// Enumeration for storage area types.
    /// </summary>
    public enum StorageArea
    {
        /// <summary>
        /// Internal device storage (built-in storage in a device, non-removable)
        /// </summary>
        Internal = Interop.Storage.StorageArea.Internal,
        /// <summary>
        /// External storage
        /// </summary>
        External = Interop.Storage.StorageArea.External,
    }
}