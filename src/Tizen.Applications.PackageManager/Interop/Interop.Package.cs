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

        [DllImport(Libraries.PackageManager, EntryPoint = "package_info_foreach_app_from_package")]
        internal static extern ErrorCode PackageInfoForeachAppInfo(IntPtr handle, AppType appType, PackageInfoAppInfoCallback callback, IntPtr userData);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_info_foreach_cert_info")]
        internal static extern ErrorCode PackageInfoForeachCertificateInfo(IntPtr handle, PackageInfoCertificateInfoCallback callback, IntPtr user_data);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_info_foreach_privilege_info")]
        internal static extern ErrorCode PackageInfoForeachPrivilegeInfo(IntPtr handle, PackageInfoPrivilegeInfoCallback callback, IntPtr userData);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_info_create")]
        internal static extern ErrorCode PackageInfoCreate(string packageId, out IntPtr handle);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_info_destroy")]
        internal static extern ErrorCode PackageInfoDestroy(IntPtr handle);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_info_get_package")]
        internal static extern ErrorCode PackageInfoGetPackage(IntPtr handle, out string packageId);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_info_get_main_app_id")]
        internal static extern ErrorCode PackageInfoGetMainAppId(IntPtr handle, out string mainAppId);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_info_get_label")]
        internal static extern ErrorCode PackageInfoGetLabel(IntPtr handle, out string label);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_info_get_icon")]
        internal static extern ErrorCode PackageInfoGetIconPath(IntPtr handle, out string path);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_info_get_version")]
        internal static extern ErrorCode PackageInfoGetVersion(IntPtr handle, out string version);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_info_get_type")]
        internal static extern ErrorCode PackageInfoGetType(IntPtr handle, out string type);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_info_get_installed_storage")]
        internal static extern ErrorCode PackageInfoGetInstalledStorage(IntPtr handle, out StorageType storage);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_info_get_root_path")]
        internal static extern ErrorCode PackageInfoGetRootPath(IntPtr handle, out string path);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_info_get_tep_name")]
        internal static extern ErrorCode PackageInfoGetTepName(IntPtr handle, out string name);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_info_is_system_package")]
        internal static extern ErrorCode PackageInfoIsSystemPackage(IntPtr handle, out bool system);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_info_is_removable_package")]
        internal static extern ErrorCode PackageInfoIsRemovablePackage(IntPtr handle, out bool removable);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_info_is_preload_package")]
        internal static extern ErrorCode PackageInfoIsPreloadPackage(IntPtr handle, out bool preload);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_info_is_accessible")]
        internal static extern ErrorCode PackageInfoIsAccessible(IntPtr handle, out bool accessible);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_info_get_installed_time")]
        internal static extern ErrorCode PackageInfoGetInstalledTime(IntPtr handle, out int installedTime);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_manager_compare_package_cert_info")]
        internal static extern ErrorCode PackageCompareCertInfo(string lhsPackageId, string rhsPackageId, out CertCompareResultType result);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_info_foreach_dependency_info")]
        internal static extern ErrorCode PackageInfoForeachDependencyInfo(IntPtr handle, PackageInfoDependencyInfoCallback callback, IntPtr userData);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_info_foreach_dependency_info_depends_on")]
        internal static extern ErrorCode PackageInfoForeachDependencyInfoDependsOn(IntPtr handle, PackageInfoDependencyInfoCallback callback, IntPtr userData);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_info_foreach_res_allowed_package")]
        internal static extern ErrorCode PackageInfoForeachResAllowedPackage(IntPtr handle, PackageInfoResAllowedPackageCallback callback, IntPtr user_data);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_info_foreach_required_privilege")]
        internal static extern ErrorCode PackageInfoForeachRequiredPrivilege(IntPtr privilegeHandle, PackageInfoPrivilegeInfoCallback callback, IntPtr user_data);
    }
}
