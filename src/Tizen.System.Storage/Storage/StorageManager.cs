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
    /// The StorageManager provides the properties or methods to access storage in the device.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public static class StorageManager
    {
        private const string LogTag = "Tizen.System";

        /// <summary>
        /// List of all storage in the device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        private static EventHandler s_ExternalStorageChangedEventHandler;
        private static EventHandler s_ExtendedInternalStorageChangedEventHandler;
        private static Interop.Storage.StorageChangedCallback s_ChangedEventCallback = (int id, Interop.Storage.StorageDevice devicetype, Interop.Storage.StorageState state, string fstype, string fsuuid, string rootDirectory, bool primary, int flags, IntPtr userData) =>
        {
            Storage storage = new Storage(id, Interop.Storage.StorageArea.External, state, rootDirectory, devicetype, fstype, fsuuid, primary, flags);

            if (devicetype == Interop.Storage.StorageDevice.ExtendedInternalStorage)
                s_ExtendedInternalStorageChangedEventHandler?.Invoke(storage, EventArgs.Empty);
            else
                s_ExternalStorageChangedEventHandler?.Invoke(storage, EventArgs.Empty);
        };

        private static void RegisterChangedEvent(StorageArea type)
        {
            Interop.Storage.ErrorCode err = Interop.Storage.StorageSetChanged((int)type, s_ChangedEventCallback, IntPtr.Zero);
            if (err != Interop.Storage.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to Register changed event callback for external storage. err = {0}", err));

                switch (err)
                {
                    case Interop.Storage.ErrorCode.NotSupported:
                        throw new NotSupportedException("Storage Not Supported");
                    default:
                        break;
                }
            }

        }

        private static void UnregisterChangedEvent(StorageArea type)
        {
            Interop.Storage.ErrorCode err = Interop.Storage.StorageUnsetChanged((int)type, s_ChangedEventCallback);
            if (err != Interop.Storage.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to Unreegister changed event callback for external storage. err = {0}", err));

                switch (err)
                {
                    case Interop.Storage.ErrorCode.NotSupported:
                        throw new NotSupportedException("Storage Not Supported");
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Registers an eventhandler for state changes of specific storage type.
        /// </summary>
        /// <param name="type">The type of the storage.</param>
        /// <param name="handler">An eventhandler to register.</param>
        /// <since_tizen> 5 </since_tizen>
        /// <feature> http://tizen.org/feature/storage.external </feature>
        /// <exception cref="NotSupportedException">Thrown when the storage is not supported.</exception>
        public static void SetChangedEvent(StorageArea type, EventHandler handler)
        {
            if (type == StorageArea.Internal)
            {
                Log.Warn(LogTag, "Internal storage state is not changed");
            }
            if (s_ExternalStorageChangedEventHandler == null && s_ExtendedInternalStorageChangedEventHandler == null)
            {
                RegisterChangedEvent(type);
            }
            if ((type == StorageArea.External && s_ExternalStorageChangedEventHandler == null) || 
                (type == StorageArea.ExtendedInternal && s_ExtendedInternalStorageChangedEventHandler == null))
            {
                RegisterChangedEvent(type);
            }
            if (type == StorageArea.External)
                s_ExternalStorageChangedEventHandler += handler;
            else if (type == StorageArea.ExtendedInternal)
                s_ExtendedInternalStorageChangedEventHandler += handler;
        }

        /// <summary>
        /// Unregisters an eventhandler for state changes of specific storage type.
        /// </summary>
        /// <param name="type">The type of the storage.</param>
        /// <param name="handler">An eventhandler to unregister.</param>
        /// <since_tizen> 5 </since_tizen>
        /// <feature> http://tizen.org/feature/storage.external </feature>
        /// <exception cref="NotSupportedException">Thrown when the storage is not supported.</exception>
        public static void UnsetChangedEvent(StorageArea type, EventHandler handler)
        {
            if (type == StorageArea.Internal)
            {
                Log.Warn(LogTag, "Internal storage state is not changed");
            }
            if (type == StorageArea.External)
                s_ExternalStorageChangedEventHandler -= handler;
            else if (type == StorageArea.ExtendedInternal)
                s_ExtendedInternalStorageChangedEventHandler -= handler;
            if ((type == StorageArea.External && s_ExternalStorageChangedEventHandler == null) ||
                (type == StorageArea.ExtendedInternal && s_ExtendedInternalStorageChangedEventHandler == null))
            {
                UnregisterChangedEvent(type);
            }
        }
    }
}
