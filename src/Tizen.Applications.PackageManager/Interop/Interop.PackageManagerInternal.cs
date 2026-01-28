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

using ErrorCode = Interop.PackageManager.ErrorCode;

internal static partial class Interop
{
    internal static partial class PackageManagerInternal
    {
        [DllImport(Libraries.PackageManager, EntryPoint = "pkgmgr_client_new")]
        internal static extern IntPtr PkgmgrClientNew(int type);

        [DllImport(Libraries.PackageManager, EntryPoint = "pkgmgr_client_free")]
        internal static extern ErrorCode PkgmgrClientFree(IntPtr clientHandle);

        [DllImport(Libraries.PackageManager, EntryPoint = "pkgmgr_client_activate")]
        internal static extern ErrorCode PkgmgrClientActivate(IntPtr clientHandle, string pkgType, string pkgId);

        [DllImport(Libraries.PackageManager, EntryPoint = "pkgmgr_client_deactivate")]
        internal static extern ErrorCode PkgmgrClientDeactivate(IntPtr clientHandle, string pkgType, string pkgId);
    }
}
