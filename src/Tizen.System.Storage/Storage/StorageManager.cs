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
