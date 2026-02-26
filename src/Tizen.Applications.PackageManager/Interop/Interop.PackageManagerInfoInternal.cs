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
using System.Runtime.InteropServices.Marshalling;

using CertificateType = Interop.Package.CertificateType;

internal static partial class Interop
{
    internal static partial class PackageManagerInfoInternal
    {
        [LibraryImport(Libraries.PackageManagerInfoInternal, EntryPoint = "pkgmgrinfo_pkginfo_create_certinfo", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int PkgmgrinfoPkginfoCreateCertinfo(out IntPtr handle);

        [LibraryImport(Libraries.PackageManagerInfoInternal, EntryPoint = "pkgmgrinfo_pkginfo_destroy_certinfo", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int PkgmgrinfoPkginfoDestroyCertinfo(IntPtr handle);

        [LibraryImport(Libraries.PackageManagerInfoInternal, EntryPoint = "pkgmgrinfo_pkginfo_load_certinfo", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int PkgmgrinfoPkginfoLoadCertinfo(string pkgid, IntPtr handle, int uid);

        [LibraryImport(Libraries.PackageManagerInfoInternal, EntryPoint = "pkgmgrinfo_pkginfo_get_cert_value", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int PkgmgrinfoPkginfoGetCertValue(IntPtr handle, CertificateType certType, out IntPtr value);

        [LibraryImport(Libraries.PackageManagerInfoInternal, EntryPoint = "pkgmgrinfo_pkginfo_foreach_depends_on_by_pkgid", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int PkgmgrinfoPkginfoForeachDependsOnByPkgId(string pkgid, Interop.Package.PackageInfoDependencyInfoCallback callback, IntPtr userData, int uid);

        [LibraryImport(Libraries.Libc, EntryPoint = "getuid", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetUID();
    }
}



