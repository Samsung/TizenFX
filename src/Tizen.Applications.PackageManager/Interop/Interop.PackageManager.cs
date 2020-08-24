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

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void PackageManagerRequestEventCallback(int requestId, string type, string packageId, EventType eventType, PackageEventState eventState, int progress, ErrorCode error, IntPtr userData);

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
            Uninstall = 0x02,
            Upgrade = 0x04,
            Move = 0x08,
            ClearData = 0x10,
            Progress = 0x20,
        }

        internal enum EventType
        {
            Install = 0,
            Uninstall = 1,
            Update = 2,
            Move = 3,
            ClearData = 4
        }

        internal enum CertCompareResultType
        {
            Match = 0,
            Mismatch,
            LhsNoCert,
            RhsNoCert,
            BothNoCert
        }

        internal enum PackageManagerPermissionType
        {
            Normal = 0,
            Signature,
            Privilege
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
        internal static extern ErrorCode PackageManagerSetEventStatus(SafePackageManagerHandle managerHandle, EventStatus eventStatus);

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
        internal static extern ErrorCode PackageManagerGetPackageIdByAppId(string app_id, out string package_id);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_get_package_info")]
        internal static extern ErrorCode PackageManagerGetPackageInfo(string packageId, out IntPtr packageInfoHandle);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_clear_cache_dir")]
        internal static extern ErrorCode PackageManagerClearCacheDir(string packageId);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_clear_all_cache_dir")]
        internal static extern ErrorCode PackageManagerClearAllCacheDir();

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_clear_data_dir")]
        internal static extern ErrorCode PackageManagerClearDataDir(string packageId);

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
        internal static extern ErrorCode PackageManagerRequestCreate(out SafePackageManagerRequestHandle requestHandle);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_request_destroy")]
        internal static extern ErrorCode PackageManagerRequestDestroy(IntPtr requestHandle);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_request_set_type")]
        internal static extern ErrorCode PackageManagerRequestSetType(SafePackageManagerRequestHandle requestHandle, string type);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_request_set_tep")]
        internal static extern ErrorCode PackageManagerRequestSetTepPath(SafePackageManagerRequestHandle requestHandle, string tepPath);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_request_install")]
        internal static extern ErrorCode PackageManagerRequestInstall(SafePackageManagerRequestHandle requestHandle, string path, out int id);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_request_mount_install")]
        internal static extern ErrorCode PackageManagerRequestMountInstall(SafePackageManagerRequestHandle requestHandle, string path, out int id);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_request_uninstall")]
        internal static extern ErrorCode PackageManagerRequestUninstall(SafePackageManagerRequestHandle requestHandle, string name, out int id);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_request_move")]
        internal static extern ErrorCode PackageManagerRequestMove(SafePackageManagerRequestHandle requestHandle, string name, StorageType moveToStorageType);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_compare_package_cert_info")]
        internal static extern ErrorCode PackageManagerCompareCertInfo(string lhsPackageId, string rhsPackageId, out CertCompareResultType CompareResult);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_compare_app_cert_info")]
        internal static extern ErrorCode PackageManagerCompareCertInfoByApplicationId(string lhsPackageId, string rhsPackageId, out CertCompareResultType CompareResult);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_is_preload_package_by_app_id")]
        internal static extern ErrorCode PackageManagerIsPreloadPackageByApplicationId(string ApplicationId, out bool IsPreload);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_get_permission_type")]
        internal static extern ErrorCode PackageManagerGetPermissionType(string ApplicationId, out PackageManagerPermissionType PermissionType);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_drm_generate_license_request")]
        internal static extern ErrorCode PackageManagerDrmGenerateLicenseRequest(string responseData, out string requestData, out string licenseUrl);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_drm_register_license")]
        internal static extern ErrorCode PackageManagerDrmRegisterLicense(string responseData);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_drm_decrypt_package")]
        internal static extern ErrorCode PackageManagerDrmDecryptPackage(string drmFilePath, string decryptedFilePath);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_request_install_with_cb")]
        internal static extern ErrorCode PackageManagerRequestInstallWithCB(SafePackageManagerRequestHandle requestHandle, string path, PackageManagerRequestEventCallback callback, IntPtr userData, out int id);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_request_mount_install_with_cb")]
        internal static extern ErrorCode PackageManagerRequestMountInstallWithCB(SafePackageManagerRequestHandle requestHandle, string path, PackageManagerRequestEventCallback callback, IntPtr userData, out int id);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_request_uninstall_with_cb")]
        internal static extern ErrorCode PackageManagerRequestUninstallWithCB(SafePackageManagerRequestHandle requestHandle, string name, PackageManagerRequestEventCallback callback, IntPtr userData, out int id);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_request_move_with_cb")]
        internal static extern ErrorCode PackageManagerRequestMoveWithCB(SafePackageManagerRequestHandle requestHandle, string name, StorageType moveToStorageType, PackageManagerRequestEventCallback callback, IntPtr userData, out int id);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_request_install_packages")]
        internal static extern ErrorCode PackageManagerRequestInstallPackages(SafePackageManagerRequestHandle requestHandle, string[] paths, int paths_count, out int id);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_request_install_packages_with_cb")]
        internal static extern ErrorCode PackageManagerRequestInstallPackagesWithCb(SafePackageManagerRequestHandle requestHandle, string[] paths, int paths_count, PackageManagerRequestEventCallback callback, IntPtr userData, out int id);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_request_mount_install_packages")]
        internal static extern ErrorCode PackageManagerRequestMountInstallPackages(SafePackageManagerRequestHandle requestHandle, string[] paths, int pathsCount, out int id);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_request_mount_install_packages_with_cb")]
        internal static extern ErrorCode PackageManagerRequestMountInstallPackagesWithCb(SafePackageManagerRequestHandle requestHandle, string[] paths, int pathsCount, PackageManagerRequestEventCallback callback, IntPtr userData, out int id);

    }
}
