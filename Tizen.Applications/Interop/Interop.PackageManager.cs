// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;
using Tizen.Applications;

internal static partial class Interop
{
    internal static partial class PackageManager
    {
        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void PackageManagerEventCallback(string type, string packageId, EventType eventType, PackageEventState eventState, int progress, ErrorCode error, IntPtr userData);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate bool PackageManagerPackageInfoCallback(IntPtr handle, IntPtr userData);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void PackageManagerSizeInfoCallback(string packageId, IntPtr sizeInfoHandle, IntPtr userData);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void PackageManagerTotalSizeInfoCallback(IntPtr sizeInfoHandle, IntPtr userData);

        // Any change here might require changes in Tizen.Applications.PackageManagerEventError enum
        internal enum ErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            IoError = Tizen.Internals.Errors.ErrorCode.IoError,
            NoSuchPackage = -0x01150000 | 0x71,
            SystemError = -0x01150000 | 0x72,
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied
        }

        // Any change here might require changes in Tizen.Applications.PackageEventState enum
        internal enum PackageEventState
        {
            Started = 0,
            Processing = 1,
            Completed = 2,
            Failed = 3
        }

        [Flags]
        internal enum EventStatus
        {
            All = 0x00,
            Install = 0x01,
            Unstall = 0x02,
            Upgrade = 0x24,
        }

        internal enum EventType
        {
            Install = 0,
            Uninstall = 1,
            Update = 2
        }

        // Any change here might require changes in Tizen.Applications.StorageType enum
        internal enum StorageType
        {
            Internal = 0,
            External = 1
        }

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_create")]
        internal static extern ErrorCode PackageManagerCreate(out SafePackageManagerHandle managerHandle);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_destroy")]
        internal static extern ErrorCode PackageManagerDestroy(IntPtr managerHandle);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_set_event_status")]
        internal static extern ErrorCode PackageManagerSetEvenStatus(SafePackageManagerHandle managerHandle, EventStatus eventStatus);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_set_event_cb")]
        internal static extern ErrorCode PackageManagerSetEvent(SafePackageManagerHandle managerHandle, PackageManagerEventCallback callback, IntPtr userData);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_unset_event_cb")]
        internal static extern ErrorCode PackageManagerUnsetEvent(SafePackageManagerHandle managerHandle);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_foreach_package_info")]
        internal static extern ErrorCode PackageManagerForeachPackageInfo(PackageManagerPackageInfoCallback callback, IntPtr userData);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_get_package_size_info")]
        internal static extern ErrorCode PackageManagerGetSizeInfo(string packageId, PackageManagerSizeInfoCallback callback, IntPtr userData);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_get_total_package_size_info")]
        internal static extern ErrorCode PackageManagerGetTotalSizeInfo(PackageManagerTotalSizeInfoCallback callback, IntPtr userData);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_get_package_id_by_app_id")]
        internal static extern ErrorCode PackageManageGetPackageIdByAppId(string app_id, out string package_id);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_get_package_info")]
        internal static extern ErrorCode PackageManagerGetPackageInfo(string packageId, out IntPtr packageInfoHandle);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_clear_cache_dir")]
        internal static extern ErrorCode PackageManagerClearCacheDir(string packageId);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_clear_all_cache_dir")]
        internal static extern ErrorCode PackageManagerClearAllCacheDir();

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_filter_create")]
        internal static extern ErrorCode PackageManagerFilterCreate(out IntPtr handle);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_filter_destroy")]
        internal static extern ErrorCode PackageManagerFilterDestroy(IntPtr handle);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_filter_add_bool")]
        internal static extern ErrorCode PackageManagerFilterAdd(IntPtr handle, string property, bool value);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_filter_foreach_package_info")]
        internal static extern ErrorCode PackageManagerFilterForeachPackageInfo(IntPtr handle, PackageManagerPackageInfoCallback callback, IntPtr userData);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_size_info_get_data_size")]
        internal static extern ErrorCode PackageSizeInfoGetDataSize(IntPtr handle, out long dataSize);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_size_info_get_cache_size")]
        internal static extern ErrorCode PackageSizeInfoGetCacheSize(IntPtr handle, out long cacheSize);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_size_info_get_app_size")]
        internal static extern ErrorCode PackageSizeInfoGetAppSize(IntPtr handle, out long appSize);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_size_info_get_external_data_size")]
        internal static extern ErrorCode PackageSizeInfoGetExtDataSize(IntPtr handle, out long extDataSize);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_size_info_get_external_cache_size")]
        internal static extern ErrorCode PackageSizeInfoGetExtCacheSize(IntPtr handle, out long extCacheSize);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_size_info_get_external_app_size")]
        internal static extern ErrorCode PackageSizeInfoGetExtAppSize(IntPtr handle, out long extAppSize);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_request_create")]
        internal static extern ErrorCode PackageManagerRequestCreate(out IntPtr request);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_request_destroy")]
        internal static extern ErrorCode PackageManagerRequestDestroy(IntPtr request);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_request_set_type")]
        internal static extern ErrorCode PackageManagerRequestSetType(IntPtr request, string type);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_request_set_tep")]
        internal static extern ErrorCode PackageManagerRequestSetTepPath(IntPtr request, string tepPath);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_request_install")]
        internal static extern ErrorCode PackageManagerRequestInstall(IntPtr request, string path, out int id);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_request_uninstall")]
        internal static extern ErrorCode PackageManagerRequestUninstall(IntPtr request, string name, out int id);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_request_move")]
        internal static extern ErrorCode PackageManagerRequestMove(IntPtr request, string name, StorageType moveToStorageType);
    }
}
