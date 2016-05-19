// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class SystemInfo
    {
        internal enum ErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            IoError = Tizen.Internals.Errors.ErrorCode.IoError,
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
            NotSupported = Tizen.Internals.Errors.ErrorCode.NoSuchDevice,
        }

        internal enum SystemInfoValueType
        {
            Bool = 0,
            Int = 1,
            Double = 2,
            String = 3,
        }

        internal enum SystemInfoType
        {
            platform,
            Custom,
            None,
        }

        [DllImport(Libraries.SystemInfo, EntryPoint = "system_info_get_platform_type")]
        internal static extern ErrorCode SystemInfoGetPlatformType(string key, out SystemInfoValueType type);

        [DllImport(Libraries.SystemInfo, EntryPoint = "system_info_get_custom_type")]
        internal static extern ErrorCode SystemInfoGetCustomType(string key, out SystemInfoValueType type);

        [DllImport(Libraries.SystemInfo, EntryPoint = "system_info_get_platform_bool")]
        internal static extern ErrorCode SystemInfoGetPlatformBool(string key, out bool value);

        [DllImport(Libraries.SystemInfo, EntryPoint = "system_info_get_platform_int")]
        internal static extern ErrorCode SystemInfoGetPlatformInt(string key, out int value);

        [DllImport(Libraries.SystemInfo, EntryPoint = "system_info_get_platform_double")]
        internal static extern ErrorCode SystemInfoGetPlatformDouble(string key, out double value);

        [DllImport(Libraries.SystemInfo, EntryPoint = "system_info_get_platform_string")]
        internal static extern ErrorCode SystemInfoGetPlatformString(string key, out string value);

        [DllImport(Libraries.SystemInfo, EntryPoint = "system_info_get_custom_bool")]
        internal static extern ErrorCode SystemInfoGetCustomBool(string key, out bool value);

        [DllImport(Libraries.SystemInfo, EntryPoint = "system_info_get_custom_int")]
        internal static extern ErrorCode SystemInfoGetCustomInt(string key, out int value);

        [DllImport(Libraries.SystemInfo, EntryPoint = "system_info_get_custom_double")]
        internal static extern ErrorCode SystemInfoGetCustomDouble(string key, out double value);

        [DllImport(Libraries.SystemInfo, EntryPoint = "system_info_get_custom_string")]
        internal static extern ErrorCode SystemInfoGetCustomString(string key, out string value);
    }
}
