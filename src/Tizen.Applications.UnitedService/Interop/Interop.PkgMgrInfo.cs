/*
 * Copyright (c) 2025 Samsung Electronics Co., Ltd All Rights Reserved
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
    internal static partial class PackageManagerInfo
    {
        internal enum ErrorCode
        {
            None = 0,
            Error = -1,
            InvalidParameter = -2,
            NoSuchPackage = -3,
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int PackageInfoPackageMetadataListCallback(string key, string value, IntPtr userData);
        // int (*pkgmgrinfo_pkg_metadata_list_cb)(const char *key, const char *value, void *user_data);

        [DllImport(Libraries.PackageManager, EntryPoint = "pkgmgrinfo_pkginfo_get_pkginfo")]
        internal static extern ErrorCode PackageInfoGet(string packageId, out IntPtr handle);

        [DllImport(Libraries.PackageManager, EntryPoint = "pkgmgrinfo_pkginfo_destroy_pkginfo")]
        internal static extern ErrorCode PackageInfoDestroy(IntPtr handle);

        [DllImport(Libraries.PackageManager, EntryPoint = "pkgmgrinfo_pkginfo_get_res_type")]
        internal static extern ErrorCode PackageInfoGetResourceType(IntPtr handle, out IntPtr resourceType);

        [DllImport(Libraries.PackageManager, EntryPoint = "pkgmgrinfo_pkginfo_get_res_version")]
        internal static extern ErrorCode PackageInfoGetResourceVersion(IntPtr handle, out IntPtr resourceVersion);

        [DllImport(Libraries.PackageManager, EntryPoint = "pkgmgrinfo_pkginfo_foreach_metadata")]
        internal static extern ErrorCode PackageInfoForeachMetadata(IntPtr handle, PackageInfoPackageMetadataListCallback callback, IntPtr userData);
    }
}