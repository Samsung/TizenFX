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
using System.Runtime.InteropServices.Marshalling;
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
            ClearCache = 0x800,
        }

        internal enum EventType
        {
            Install = 0,
            Uninstall = 1,
            Update = 2,
            Move = 3,
            ClearData = 4,
            ClearCache = 1000,
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

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_create")]
        internal static partial ErrorCode PackageManagerCreate(out SafePackageManagerHandle managerHandle);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_destroy")]
        internal static partial ErrorCode PackageManagerDestroy(IntPtr managerHandle);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_set_event_status")]
        internal static partial ErrorCode PackageManagerSetEventStatus(SafePackageManagerHandle managerHandle, EventStatus eventStatus);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_set_event_cb")]
        internal static partial ErrorCode PackageManagerSetEvent(SafePackageManagerHandle managerHandle, PackageManagerEventCallback callback, IntPtr userData);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_unset_event_cb")]
        internal static partial ErrorCode PackageManagerUnsetEvent(SafePackageManagerHandle managerHandle);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_foreach_package_info")]
        internal static partial ErrorCode PackageManagerForeachPackageInfo(PackageManagerPackageInfoCallback callback, IntPtr userData);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_get_package_size_info", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerGetSizeInfo(string packageId, PackageManagerSizeInfoCallback callback, IntPtr userData);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_get_total_package_size_info")]
        internal static partial ErrorCode PackageManagerGetTotalSizeInfo(PackageManagerTotalSizeInfoCallback callback, IntPtr userData);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_get_package_id_by_app_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerGetPackageIdByAppId(string app_id, out string package_id);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_get_package_info", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerGetPackageInfo(string packageId, out IntPtr packageInfoHandle);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_clear_cache_dir", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerClearCacheDir(string packageId);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_clear_all_cache_dir")]
        internal static partial ErrorCode PackageManagerClearAllCacheDir();

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_clear_data_dir", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerClearDataDir(string packageId);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_clear_user_data_with_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerClearUserDataWithPath(string packageId, String filePath);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_filter_create")]
        internal static partial ErrorCode PackageManagerFilterCreate(out IntPtr handle);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_filter_destroy")]
        internal static partial ErrorCode PackageManagerFilterDestroy(IntPtr handle);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_filter_add_bool", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerFilterAdd(IntPtr handle, string property, [MarshalAs(UnmanagedType.U1)] bool value);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_filter_add_string", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerFilterAdd(IntPtr handle, string property, string value);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_filter_foreach_package_info")]
        internal static partial ErrorCode PackageManagerFilterForeachPackageInfo(IntPtr handle, PackageManagerPackageInfoCallback callback, IntPtr userData);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_size_info_get_data_size")]
        internal static partial ErrorCode PackageSizeInfoGetDataSize(IntPtr handle, out long dataSize);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_size_info_get_cache_size")]
        internal static partial ErrorCode PackageSizeInfoGetCacheSize(IntPtr handle, out long cacheSize);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_size_info_get_app_size")]
        internal static partial ErrorCode PackageSizeInfoGetAppSize(IntPtr handle, out long appSize);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_size_info_get_external_data_size")]
        internal static partial ErrorCode PackageSizeInfoGetExtDataSize(IntPtr handle, out long extDataSize);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_size_info_get_external_cache_size")]
        internal static partial ErrorCode PackageSizeInfoGetExtCacheSize(IntPtr handle, out long extCacheSize);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_size_info_get_external_app_size")]
        internal static partial ErrorCode PackageSizeInfoGetExtAppSize(IntPtr handle, out long extAppSize);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_request_create")]
        internal static partial ErrorCode PackageManagerRequestCreate(out SafePackageManagerRequestHandle requestHandle);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_request_destroy")]
        internal static partial ErrorCode PackageManagerRequestDestroy(IntPtr requestHandle);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_request_set_type", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerRequestSetType(SafePackageManagerRequestHandle requestHandle, string type);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_request_set_tep", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerRequestSetTepPath(SafePackageManagerRequestHandle requestHandle, string tepPath);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_request_install", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerRequestInstall(SafePackageManagerRequestHandle requestHandle, string path, out int id);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_request_mount_install", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerRequestMountInstall(SafePackageManagerRequestHandle requestHandle, string path, out int id);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_request_uninstall", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerRequestUninstall(SafePackageManagerRequestHandle requestHandle, string name, out int id);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_request_move", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerRequestMove(SafePackageManagerRequestHandle requestHandle, string name, StorageType moveToStorageType);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_compare_package_cert_info", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerCompareCertInfo(string lhsPackageId, string rhsPackageId, out CertCompareResultType CompareResult);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_compare_app_cert_info", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerCompareCertInfoByApplicationId(string lhsPackageId, string rhsPackageId, out CertCompareResultType CompareResult);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_is_preload_package_by_app_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerIsPreloadPackageByApplicationId(string ApplicationId, [MarshalAs(UnmanagedType.U1)] out bool IsPreload);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_get_permission_type", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerGetPermissionType(string ApplicationId, out PackageManagerPermissionType PermissionType);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_drm_generate_license_request", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerDrmGenerateLicenseRequest(string responseData, out string requestData, out string licenseUrl);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_drm_register_license", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerDrmRegisterLicense(string responseData);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_drm_decrypt_package", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerDrmDecryptPackage(string drmFilePath, string decryptedFilePath);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_request_install_with_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerRequestInstallWithCB(SafePackageManagerRequestHandle requestHandle, string path, PackageManagerRequestEventCallback callback, IntPtr userData, out int id);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_request_mount_install_with_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerRequestMountInstallWithCB(SafePackageManagerRequestHandle requestHandle, string path, PackageManagerRequestEventCallback callback, IntPtr userData, out int id);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_request_uninstall_with_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerRequestUninstallWithCB(SafePackageManagerRequestHandle requestHandle, string name, PackageManagerRequestEventCallback callback, IntPtr userData, out int id);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_request_move_with_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerRequestMoveWithCB(SafePackageManagerRequestHandle requestHandle, string name, StorageType moveToStorageType, PackageManagerRequestEventCallback callback, IntPtr userData, out int id);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_request_install_packages", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerRequestInstallPackages(SafePackageManagerRequestHandle requestHandle, string[] paths, int paths_count, out int id);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_request_install_packages_with_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerRequestInstallPackagesWithCb(SafePackageManagerRequestHandle requestHandle, string[] paths, int paths_count, PackageManagerRequestEventCallback callback, IntPtr userData, out int id);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_request_mount_install_packages", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerRequestMountInstallPackages(SafePackageManagerRequestHandle requestHandle, string[] paths, int pathsCount, out int id);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_request_mount_install_packages_with_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageManagerRequestMountInstallPackagesWithCb(SafePackageManagerRequestHandle requestHandle, string[] paths, int pathsCount, PackageManagerRequestEventCallback callback, IntPtr userData, out int id);

    }
}




