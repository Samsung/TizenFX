/*
 *  Copyright (c) 2016-2020 Samsung Electronics Co., Ltd All Rights Reserved
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License
 */

using System;
using System.Runtime.InteropServices;

using Tizen.Security;

internal static partial class Interop
{
    internal static partial class Privilege
    {
        internal static string LogTag = "Tizen.Security.Privilege";

        [DllImport(Libraries.Privilege, EntryPoint = "privilege_info_get_display_name")]
            internal static extern int GetDisplayName(string apiVersion, string privilege, out string displayName);

        [DllImport(Libraries.Privilege, EntryPoint = "privilege_info_get_description")]
            internal static extern int GetDescription(string apiVersion, string privilege, out string description);

        [DllImport(Libraries.Privilege, EntryPoint = "privilege_info_get_display_name_by_pkgtype")]
            internal static extern int GetDisplayNameByPkgtype(string packageType, string apiVersion, string privilege, out string displayName);

        [DllImport(Libraries.Privilege, EntryPoint = "privilege_info_get_description_by_pkgtype")]
            internal static extern int GetDescriptionByPkgtype(string packageType, string apiVersion, string privilege, out string description);

        [DllImport(Libraries.Privilege, EntryPoint = "privilege_info_get_privacy_display_name")]
            internal static extern int GetPrivacyDisplayName(string privilege, out string displayName);
    }
}
