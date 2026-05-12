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
using System.Runtime.InteropServices.Marshalling;

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

        [LibraryImport(Libraries.PackageManager, EntryPoint = "pkgmgrinfo_pkginfo_get_pkginfo", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode PackageInfoGet(string packageId, out IntPtr handle);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "pkgmgrinfo_pkginfo_destroy_pkginfo")]
        internal static partial ErrorCode PackageInfoDestroy(IntPtr handle);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "pkgmgrinfo_pkginfo_get_res_type")]
        internal static partial ErrorCode PackageInfoGetResourceType(IntPtr handle, out IntPtr resourceType);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "pkgmgrinfo_pkginfo_get_res_version")]
        internal static partial ErrorCode PackageInfoGetResourceVersion(IntPtr handle, out IntPtr resourceVersion);

        [LibraryImport(Libraries.PackageManager, EntryPoint = "pkgmgrinfo_pkginfo_foreach_metadata")]
        internal static partial ErrorCode PackageInfoForeachMetadata(IntPtr handle, PackageInfoPackageMetadataListCallback callback, IntPtr userData);
    }
}



