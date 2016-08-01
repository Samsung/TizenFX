// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;

using Tizen.Security;

internal static partial class Interop
{
    internal static partial class Privilege
    {
        [DllImport(Libraries.Privilege, EntryPoint = "privilege_info_get_display_name")]
            internal static extern int GetDisplayName(string apiVersion, string privilege, out string displayName);

        [DllImport(Libraries.Privilege, EntryPoint = "privilege_info_get_description")]
            internal static extern int GetDescription(string apiVersion, string privilege, out string description);

        [DllImport(Libraries.Privilege, EntryPoint = "privilege_info_get_display_name_by_pkgtype")]
            internal static extern int GetDisplayNameByPkgtype(string packageType, string apiVersion, string privilege, out string displayName);

        [DllImport(Libraries.Privilege, EntryPoint = "privilege_info_get_description_by_pkgtype")]
            internal static extern int GetDescriptionByPkgtype(string packageType, string apiVersion, string privilege, out string description);
    }
}
