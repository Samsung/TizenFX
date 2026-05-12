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

using ErrorCode = Interop.PackageManager.ErrorCode;
using StorageType = Interop.PackageManager.StorageType;
using CertCompareResultType = Interop.PackageManager.CertCompareResultType;

internal static partial class Interop
{
    internal static partial class Package
    {
        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate bool PackageInfoAppInfoCallback(AppType appType, string appId, IntPtr userData);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate bool PackageInfoCertificateInfoCallback(IntPtr handle, CertificateType certType, string certValue, IntPtr userData);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate bool PackageInfoPrivilegeInfoCallback(string privilege, IntPtr userData);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate bool PackageInfoDependencyInfoCallback(string from, string to, string type, string requiredVersion, IntPtr userData);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate bool PackageInfoResAllowedPackageCallback(string allowedPackage, IntPtr requiredPrivileges, IntPtr userData);

        // Any change here might require changes in Tizen.Applications.AppType enum
        internal enum AppType
        {
            All = 0,
            Ui = 1,
            Service = 2
        }

        internal enum CertificateType
        {
            AuthorRootCertificate = 0,
            AuthorIntermediateCertificate = 1,
            AuthorSignerCertificate = 2,
            DistributorRootCertificate = 3,
            DistributorIntermediateCertificate = 4,
            DistributorSignerCertificate = 5,
            Distributor2RootCertificate = 6,
            Distributor2IntermediateCertificate = 7,
            Distributor2SignerCertificate = 8
        }

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_info_foreach_app_from_package")]
        internal static partial ErrorCode PackageInfoForeachAppInfo(IntPtr handle, AppType appType, PackageInfoAppInfoCallback callback, IntPtr userData);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_info_foreach_privilege_info")]
        internal static partial ErrorCode PackageInfoForeachPrivilegeInfo(IntPtr handle, PackageInfoPrivilegeInfoCallback callback, IntPtr userData);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_info_create", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageInfoCreate(string packageId, out IntPtr handle);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_info_destroy")]
        internal static partial ErrorCode PackageInfoDestroy(IntPtr handle);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_info_get_package", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageInfoGetPackage(IntPtr handle, out string packageId);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_info_get_main_app_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageInfoGetMainAppId(IntPtr handle, out string mainAppId);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_info_get_label", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageInfoGetLabel(IntPtr handle, out string label);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_info_get_icon", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageInfoGetIconPath(IntPtr handle, out string path);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_info_get_version", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageInfoGetVersion(IntPtr handle, out string version);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_info_get_type", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageInfoGetType(IntPtr handle, out string type);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_info_get_installed_storage")]
        internal static partial ErrorCode PackageInfoGetInstalledStorage(IntPtr handle, out StorageType storage);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_info_get_root_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageInfoGetRootPath(IntPtr handle, out string path);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_info_get_tep_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageInfoGetTepName(IntPtr handle, out string name);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_info_is_system_package")]
        internal static partial ErrorCode PackageInfoIsSystemPackage(IntPtr handle, [MarshalAs(UnmanagedType.U1)] out bool system);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_info_is_removable_package")]
        internal static partial ErrorCode PackageInfoIsRemovablePackage(IntPtr handle, [MarshalAs(UnmanagedType.U1)] out bool removable);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_info_is_preload_package")]
        internal static partial ErrorCode PackageInfoIsPreloadPackage(IntPtr handle, [MarshalAs(UnmanagedType.U1)] out bool preload);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_info_is_update_package")]
        internal static partial ErrorCode PackageInfoIsUpdatePackage(IntPtr handle, [MarshalAs(UnmanagedType.U1)] out bool update);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_info_is_accessible")]
        internal static partial ErrorCode PackageInfoIsAccessible(IntPtr handle, [MarshalAs(UnmanagedType.U1)] out bool accessible);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_info_get_first_installed_time")]
        internal static partial ErrorCode PackageInfoGetFirstInstalledTime(IntPtr handle, out long firstinstalledTime);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_info_get_installed_time")]
        internal static partial ErrorCode PackageInfoGetInstalledTime(IntPtr handle, out int installedTime);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_manager_compare_package_cert_info", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageCompareCertInfo(string lhsPackageId, string rhsPackageId, out CertCompareResultType result);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_info_foreach_dependency_info")]
        internal static partial ErrorCode PackageInfoForeachDependencyInfo(IntPtr handle, PackageInfoDependencyInfoCallback callback, IntPtr userData);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_info_foreach_dependency_info_depends_on")]
        internal static partial ErrorCode PackageInfoForeachDependencyInfoDependsOn(IntPtr handle, PackageInfoDependencyInfoCallback callback, IntPtr userData);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_info_foreach_res_allowed_package")]
        internal static partial ErrorCode PackageInfoForeachResAllowedPackage(IntPtr handle, PackageInfoResAllowedPackageCallback callback, IntPtr user_data);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "package_info_foreach_required_privilege")]
        internal static partial ErrorCode PackageInfoForeachRequiredPrivilege(IntPtr privilegeHandle, PackageInfoPrivilegeInfoCallback callback, IntPtr user_data);
    }
}




