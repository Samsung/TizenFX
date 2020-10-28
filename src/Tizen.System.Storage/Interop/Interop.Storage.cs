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
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Storage
    {
        internal enum ErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            NotSupported = Tizen.Internals.Errors.ErrorCode.NoSuchDevice,
            OperationFailed = -0x00020000 | 0x12,
        }

        // Any change here might require changes in Tizen.System.StorageArea enum
        internal enum StorageArea
        {
            Internal = 0,
            External = 1,
            ExtendedInternal = 2,
        }

        // Any change here might require changes in Tizen.System.StorageState enum
        internal enum StorageState
        {
            Unmountable = -2,
            Removed = -1,
            Mounted = 0,
            MountedReadOnly = 1,
        }

        // Any change here might require changes in Tizen.System.directoryType enum
        internal enum DirectoryType
        {
            Images = 0,
            Sounds = 1,
            Videos = 2,
            Camera = 3,
            Downloads = 4,
            Music = 5,
            Documents = 6,
            Others = 7,
            Ringtones = 8,
        }

        // Any change here might require changes in Tizen.System.StorageDevice enum
        internal enum StorageDevice
        {
            ExternalSDCard = 1001,
            ExternalUSBMassStorage = 1002,
            ExtendedInternalStorage = 1003,
        }

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void StorageChangedCallback(int id, StorageDevice devicetype, StorageState state, string fstype, string fsuuid, string mountpath, bool primary, int flags, IntPtr userData);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void StorageStateChangedCallback(int id, StorageState state, IntPtr userData);

        [DllImport(Libraries.Storage, EntryPoint = "storage_get_root_directory")]
        internal static extern ErrorCode StorageGetRootDirectory(int id, out string path);

        [DllImport(Libraries.Storage, EntryPoint = "storage_get_directory")]
        internal static extern ErrorCode StorageGetAbsoluteDirectory(int id, DirectoryType type, out string path);

        [DllImport(Libraries.Storage, EntryPoint = "storage_get_state")]
        internal static extern ErrorCode StorageGetState(int id, out StorageState state);

        [DllImport(Libraries.Storage, EntryPoint = "storage_get_type")]
        internal static extern ErrorCode StorageGetType(int id, out StorageArea type);

        [DllImport(Libraries.Storage, EntryPoint = "storage_set_state_changed_cb")]
        internal static extern ErrorCode StorageSetStateChanged(int id, StorageStateChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Storage, EntryPoint = "storage_unset_state_changed_cb")]
        internal static extern ErrorCode StorageUnsetStateChanged(int id, StorageStateChangedCallback callback);

        [DllImport(Libraries.Storage, EntryPoint = "storage_get_total_space")]
        internal static extern ErrorCode StorageGetTotalSpace(int id, out ulong bytes);

        [DllImport(Libraries.Storage, EntryPoint = "storage_get_available_space")]
        internal static extern ErrorCode StorageGetAvailableSpace(int id, out ulong bytes);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate bool StorageDeviceSupportedCallback(int storageID, StorageArea type, StorageState state, string rootDirectory, IntPtr userData);

        [DllImport(Libraries.Storage, EntryPoint = "storage_foreach_device_supported")]
        public static extern ErrorCode StorageManagerGetForeachDeviceSupported(StorageDeviceSupportedCallback callback, IntPtr userData);

        [DllImport(Libraries.Storage, EntryPoint = "storage_set_changed_cb")]
        internal static extern ErrorCode StorageSetChanged(int id, StorageChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Storage, EntryPoint = "storage_unset_changed_cb")]
        internal static extern ErrorCode StorageUnsetChanged(int id, StorageChangedCallback callback);

        [DllImport(Libraries.Storage, EntryPoint = "storage_get_type_dev")]
        internal static extern ErrorCode StorageGetTypeDev(int id, out StorageArea type, out StorageDevice devicetype);
    }
}
