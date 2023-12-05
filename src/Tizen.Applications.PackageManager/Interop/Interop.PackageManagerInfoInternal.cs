/*
 * Copyright (c) 2023 Samsung Electronics Co., Ltd All Rights Reserved
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

using CertificateType = Interop.Package.CertificateType;

internal static partial class Interop
{
    internal static partial class PackageManagerInfoInternal
    {
        [DllImport(Libraries.PackageManagerInfoInternal, EntryPoint = "pkgmgrinfo_pkginfo_create_certinfo")]
        internal static extern int PkgmgrinfoPkginfoCreateCertinfo(out IntPtr handle);

        [DllImport(Libraries.PackageManagerInfoInternal, EntryPoint = "pkgmgrinfo_pkginfo_destroy_certinfo")]
        internal static extern int PkgmgrinfoPkginfoDestroyCertinfo(IntPtr handle);

        [DllImport(Libraries.PackageManagerInfoInternal, EntryPoint = "pkgmgrinfo_pkginfo_load_certinfo")]
        internal static extern int PkgmgrinfoPkginfoLoadCertinfo(string pkgid, IntPtr handle, int uid);

        [DllImport(Libraries.PackageManagerInfoInternal, EntryPoint = "pkgmgrinfo_pkginfo_get_cert_value")]
        internal static extern int PkgmgrinfoPkginfoGetCertValue(IntPtr handle, CertificateType certType, out IntPtr value);

        [DllImport(Libraries.PackageManagerInfoInternal, EntryPoint = "pkgmgrinfo_pkginfo_foreach_depends_on_by_pkgid")]
        internal static extern int PkgmgrinfoPkginfoForeachDependsOnByPkgId(string pkgid, Interop.Package.PackageInfoDependencyInfoCallback callback, IntPtr userData, int uid);

        [DllImport(Libraries.Libc, EntryPoint = "getuid")]
        internal static extern int GetUID();
    }
}
