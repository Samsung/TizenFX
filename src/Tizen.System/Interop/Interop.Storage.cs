// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

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

        [StructLayout(LayoutKind.Sequential)]
        public struct FileSystemInfo
        {
            public uint BlockSize;
            public uint FragmentSize;
            public uint BlockCount;
            public uint FreeBlocks;
            public uint BlockAvailable;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
            public uint[] vals;
        }

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate bool StorageDeviceSupportedCallback(int storageID, StorageArea type, StorageState state, string rootDirectory, IntPtr userData);

        [DllImport(Libraries.Storage, EntryPoint = "storage_foreach_device_supported")]
        public static extern ErrorCode StorageManagerGetForeachDeviceSupported(StorageDeviceSupportedCallback callback, IntPtr userData);
    }
}
