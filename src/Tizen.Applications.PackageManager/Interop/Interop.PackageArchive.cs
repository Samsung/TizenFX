/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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

internal static partial class Interop
{
    internal static partial class PackageArchive
    {

        [DllImport(Libraries.PackageManager, EntryPoint = "package_archive_info_create")]
        internal static extern ErrorCode PackageArchiveInfoCreate(string path, out IntPtr handle);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_archive_info_destroy")]
        internal static extern ErrorCode PackageArchiveInfoDestroy(IntPtr handle);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_archive_info_get_package")]
        internal static extern ErrorCode PackageArchiveInfoGetPackage(IntPtr handle, out string package);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_archive_info_get_type")]
        internal static extern ErrorCode PackageArchiveInfoGetType(IntPtr handle, out string type);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_archive_info_get_version")]
        internal static extern ErrorCode PackageArchiveInfoGetVersion(IntPtr handle, out string version);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_archive_info_get_api_version")]
        internal static extern ErrorCode PackageArchiveInfoGetApiVersion(IntPtr handle, out string apiVersion);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_archive_info_get_description")]
        internal static extern ErrorCode PackageArchiveInfoGetDescription(IntPtr handle, out string description);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_archive_info_get_label")]
        internal static extern ErrorCode PackageArchiveInfoGetLabel(IntPtr handle, out string label);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_archive_info_get_author")]
        internal static extern ErrorCode PackageArchiveInfoGetAuthor(IntPtr handle, out string author);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_archive_info_get_icon")]
        internal static extern ErrorCode PackageArchiveInfoGetIcon(IntPtr handle, out IntPtr icon, out int iconSize);

        [DllImport(Libraries.PackageManager, EntryPoint = "package_archive_info_foreach_direct_dependency")]
        internal static extern ErrorCode PackageArchiveInfoForeachDirectDependency(IntPtr handle, Package.PackageInfoDependencyInfoCallback callback, IntPtr userData);
    }
}
