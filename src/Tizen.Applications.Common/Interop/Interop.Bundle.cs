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

using Tizen.Applications;

internal static partial class Interop
{
    internal static partial class Bundle
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void Iterator(string key, int type, IntPtr keyval, IntPtr userData);

        [DllImport(Libraries.Bundle, EntryPoint = "bundle_create")]
        internal static extern SafeBundleHandle Create();

        [DllImport(Libraries.Bundle, EntryPoint = "bundle_free")]
        internal static extern int DangerousFree(IntPtr handle);

        [DllImport(Libraries.Bundle, EntryPoint = "bundle_del")]
        internal static extern int RemoveItem(SafeBundleHandle handle, string key);

        [DllImport(Libraries.Bundle, EntryPoint = "bundle_add_str")]
        internal static extern int AddString(SafeBundleHandle handle, string key, string value);

        [DllImport(Libraries.Bundle, EntryPoint = "bundle_get_type")]
        internal static extern int GetType(SafeBundleHandle handle, string key);

        [DllImport(Libraries.Bundle, EntryPoint = "bundle_get_str")]
        internal static extern int GetString(SafeBundleHandle handle, string key, out IntPtr value);

        [DllImport(Libraries.Bundle, EntryPoint = "bundle_add_byte")]
        internal static extern unsafe int AddByte(SafeBundleHandle handle, string key, byte* value, int size);

        [DllImport(Libraries.Bundle, EntryPoint = "bundle_get_byte")]
        internal static extern int GetByte(SafeBundleHandle handle, string key, out IntPtr value, out int size);

        [DllImport(Libraries.Bundle, EntryPoint = "bundle_add_str_array")]
        internal static extern int AddStringArray(SafeBundleHandle handle, string key, string[] value, int size);

        [DllImport(Libraries.Bundle, EntryPoint = "bundle_get_str_array")]
        internal static extern IntPtr GetStringArray(SafeBundleHandle handle, string key, out int size);

        [DllImport(Libraries.Bundle, EntryPoint = "bundle_foreach")]
        internal static extern void Foreach(SafeBundleHandle handle, Iterator iterator, IntPtr userData);

        [DllImport(Libraries.Bundle, EntryPoint = "bundle_encode")]
        internal static extern void BundleEncode(SafeBundleHandle handle, out string str, out int len);

        [DllImport(Libraries.Bundle, EntryPoint = "bundle_decode")]
        internal static extern SafeBundleHandle BundleDecode(string bundleRaw, int len);

        [DllImport(Libraries.Bundle, EntryPoint = "bundle_dup")]
        internal static extern SafeBundleHandle DangerousClone(IntPtr handle);

        internal static class UnsafeCode
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
