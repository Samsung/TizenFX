/*
 * Copyright (c) 2022 Samsung Electronics Co., Ltd All Rights Reserved
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
    internal static partial class LibIniParser
    {
        [LibraryImport(Libraries.IniParser, EntryPoint = "iniparser_getstring", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial IntPtr GetString(IntPtr d, string key, IntPtr def);

        [LibraryImport(Libraries.IniParser, EntryPoint = "iniparser_load", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial IntPtr Load(string iniName);

        [LibraryImport(Libraries.IniParser, EntryPoint = "iniparser_freedict")]
        internal static partial void FreeDict(IntPtr d);
    }
}


