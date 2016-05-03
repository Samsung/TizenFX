// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;

using ErrorCode = Interop.PackageManager.ErrorCode;
using StorageType = Interop.PackageManager.StorageType;

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
    }
}
