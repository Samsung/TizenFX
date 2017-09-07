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

namespace Tizen.Content.MediaContent
{
    internal static class InteropHelper
    {
        internal delegate MediaContentError GetStringFunc<T>(T handle, out IntPtr value);

        internal static string GetString<T>(T handle, GetStringFunc<T> func, bool nullable = false)
        {
            IntPtr val = IntPtr.Zero;
            try
            {
                func(handle, out val).ThrowIfError("Failed to get value");

                if (val == IntPtr.Zero)
                {
                    return nullable ? null : string.Empty;
                }

                return Marshal.PtrToStringAnsi(val);
            }
            finally
            {
                Interop.Libc.Free(val);
            }
        }

        internal delegate MediaContentError GetValueFunc<T, TValue>(T handle, out TValue value);

        internal static TValue GetValue<T, TValue>(T handle, GetValueFunc<T, TValue> func)
        {
            func(handle, out var val).ThrowIfError("Failed to get value");

            return val;
        }

        internal static TValue GetValue<TValue>(IntPtr handle, GetValueFunc<IntPtr, TValue> func)
        {
            func(handle, out var val).ThrowIfError("Failed to get value");

            return val;
        }

        internal static TValue GetValue<TValue>(Interop.MediaInfoHandle handle,
            GetValueFunc<Interop.MediaInfoHandle, TValue> func)
        {
            func(handle, out var val).ThrowIfError("Failed to get value");

            return val;
        }

        internal static DateTimeOffset GetDateTime<T>(T handle,
            GetValueFunc<T, IntPtr> func)
        {
            IntPtr time = IntPtr.Zero;

            func(handle, out time).ThrowIfError("Failed to get value");

            return DateTimeOffset.FromUnixTimeSeconds(time.ToInt64());
        }
    }
}
