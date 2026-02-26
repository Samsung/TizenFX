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

using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

using Tizen.Applications;

internal static partial class Interop
{
    internal static partial class Bundle
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void Iterator(string key, int type, IntPtr keyval, IntPtr userData);

        [LibraryImport(Libraries.Bundle, EntryPoint = "bundle_create", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial SafeBundleHandle Create();

        [LibraryImport(Libraries.Bundle, EntryPoint = "bundle_free", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int DangerousFree(IntPtr handle);

        [LibraryImport(Libraries.Bundle, EntryPoint = "bundle_del", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int RemoveItem(SafeBundleHandle handle, string key);

        [LibraryImport(Libraries.Bundle, EntryPoint = "bundle_add_str", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int AddString(SafeBundleHandle handle, string key, string value);

        [LibraryImport(Libraries.Bundle, EntryPoint = "bundle_get_type", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetType(SafeBundleHandle handle, string key);

        [LibraryImport(Libraries.Bundle, EntryPoint = "bundle_get_str", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetString(SafeBundleHandle handle, string key, out IntPtr value);

        [LibraryImport(Libraries.Bundle, EntryPoint = "bundle_add_byte", StringMarshalling = StringMarshalling.Utf8)]
        internal static unsafe partial int AddByte(SafeBundleHandle handle, string key, byte* value, int size);

        [LibraryImport(Libraries.Bundle, EntryPoint = "bundle_get_byte", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetByte(SafeBundleHandle handle, string key, out IntPtr value, out int size);

        [LibraryImport(Libraries.Bundle, EntryPoint = "bundle_add_str_array", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int AddStringArray(SafeBundleHandle handle, string key, string[] value, int size);

        [LibraryImport(Libraries.Bundle, EntryPoint = "bundle_get_str_array", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial IntPtr GetStringArray(SafeBundleHandle handle, string key, out int size);

        [LibraryImport(Libraries.Bundle, EntryPoint = "bundle_foreach", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial void Foreach(SafeBundleHandle handle, Iterator iterator, IntPtr userData);

        [LibraryImport(Libraries.Bundle, EntryPoint = "bundle_encode", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial void BundleEncode(SafeBundleHandle handle, out string str, out int len);

        [LibraryImport(Libraries.Bundle, EntryPoint = "bundle_decode", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial SafeBundleHandle BundleDecode(string bundleRaw, int len);

        [LibraryImport(Libraries.Bundle, EntryPoint = "bundle_dup", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial SafeBundleHandle DangerousClone(IntPtr handle);

        [LibraryImport(Libraries.Bundle, EntryPoint = "bundle_import_from_argv", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial SafeBundleHandle ImportFromArgv(int argc, string[] argv);

        internal static partial class UnsafeCode
        {
            internal static unsafe int AddItem(SafeBundleHandle handle, string key, byte[] value, int offset, int count)
            {
                fixed (byte* pointer = value)
                {
                    return AddByte(handle, key, pointer + offset, count);
                }
            }
        }
    }
}



