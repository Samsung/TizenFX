/*
* Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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

using Tizen.System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

internal static partial class Interop
{
    internal static partial class SystemInfo
    {
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

        [LibraryImport(Libraries.SystemInfo, EntryPoint = "system_info_get_platform_type", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial InformationError SystemInfoGetPlatformType(string key, out SystemInfoValueType type);

        [LibraryImport(Libraries.SystemInfo, EntryPoint = "system_info_get_custom_type", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial InformationError SystemInfoGetCustomType(string key, out SystemInfoValueType type);

        [LibraryImport(Libraries.SystemInfo, EntryPoint = "system_info_get_platform_bool", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial InformationError SystemInfoGetPlatformBool(string key, [MarshalAs(UnmanagedType.U1)] out bool value);

        [LibraryImport(Libraries.SystemInfo, EntryPoint = "system_info_get_platform_int", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial InformationError SystemInfoGetPlatformInt(string key, out int value);

        [LibraryImport(Libraries.SystemInfo, EntryPoint = "system_info_get_platform_double", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial InformationError SystemInfoGetPlatformDouble(string key, out double value);

        [LibraryImport(Libraries.SystemInfo, EntryPoint = "system_info_get_platform_string", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial InformationError SystemInfoGetPlatformString(string key, out string value);

        [LibraryImport(Libraries.SystemInfo, EntryPoint = "system_info_get_custom_bool", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial InformationError SystemInfoGetCustomBool(string key, [MarshalAs(UnmanagedType.U1)] out bool value);

        [LibraryImport(Libraries.SystemInfo, EntryPoint = "system_info_get_custom_int", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial InformationError SystemInfoGetCustomInt(string key, out int value);

        [LibraryImport(Libraries.SystemInfo, EntryPoint = "system_info_get_custom_double", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial InformationError SystemInfoGetCustomDouble(string key, out double value);

        [LibraryImport(Libraries.SystemInfo, EntryPoint = "system_info_get_custom_string", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial InformationError SystemInfoGetCustomString(string key, out string value);
    }
}
