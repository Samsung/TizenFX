// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Collections.Generic;

namespace Tizen.System
{
    /// <summary>
    /// Storage Manager, provides properties/ methods to access storage in the device.
    /// </summary>
    public static class StorageManager
    {
        private const string LogTag = "Tizen.System";

        /// <summary>
        /// List of all storage in the device
        /// </summary>
        public static IEnumerable<Storage> Storages
        {
            get
            {
                List<Storage> storageList = new List<Storage>();
                Interop.Storage.StorageDeviceSupportedCallback cb = (int storageID, Interop.Storage.StorageArea type, Interop.Storage.StorageState state, string rootDirectory, IntPtr userData) =>
                {
                    storageList.Add(new Storage(storageID, type, state, rootDirectory));
                    return true;
                };

                Interop.Storage.ErrorCode err = Interop.Storage.StorageManagerGetForeachDeviceSupported(cb, IntPtr.Zero);
                if (err != Interop.Storage.ErrorCode.None)
                {
                    Log.Warn(LogTag, string.Format("Failed to get storage list. err = {0}", err));
                }
                return storageList;
            }
        }
    }
}
