/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Bundle
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void Iterator(string key, int type, IntPtr keyval, IntPtr userData);

        [DllImport(Libraries.Bundle, EntryPoint = "bundle_create")]
        internal static extern IntPtr Create();

        [DllImport(Libraries.Bundle, EntryPoint = "bundle_free")]
        internal static extern int Free(IntPtr handle);

        [DllImport(Libraries.Bundle, EntryPoint = "bundle_del")]
        internal static extern int RemoveItem(IntPtr handle, string key);

        [DllImport(Libraries.Bundle, EntryPoint = "bundle_add_str")]
        internal static extern int AddString(IntPtr handle, string key, string value);

        [DllImport(Libraries.Bundle, EntryPoint = "bundle_get_type")]
        internal static extern int GetType(IntPtr handle, string key);

        [DllImport(Libraries.Bundle, EntryPoint = "bundle_get_str")]
        internal static extern int GetString(IntPtr handle, string key, out IntPtr value);

        [DllImport(Libraries.Bundle, EntryPoint = "bundle_add_byte")]
        internal static extern unsafe int AddByte(IntPtr handle, string key, byte* value, int size);

        [DllImport(Libraries.Bundle, EntryPoint = "bundle_get_byte")]
        internal static extern int GetByte(IntPtr handle, string key, out IntPtr value, out int size);

        [DllImport(Libraries.Bundle, EntryPoint = "bundle_add_str_array")]
        internal static extern int AddStringArray(IntPtr handle, string key, string[] value, int size);

        [DllImport(Libraries.Bundle, EntryPoint = "bundle_get_str_array")]
        internal static extern IntPtr GetStringArray(IntPtr handle, string key, out int size);

        [DllImport(Libraries.Bundle, EntryPoint = "bundle_foreach")]
        internal static extern void Foreach(IntPtr handle, Iterator iterator, IntPtr userData);

        internal static class UnsafeCode
        {
            internal static unsafe int AddItem(IntPtr handle, string key, byte[] value, int offset, int count)
            {
                fixed (byte* pointer = value)
                {
                    return AddByte(handle, key, pointer + offset, count);
                }
            }
        }
    }
}
