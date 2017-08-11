/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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

internal static partial class Interop
{
    internal static partial class ChromiumEwk
    {
        [DllImport(Libraries.ChromiumEwk, EntryPoint = "ewk_error_url_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _ewk_error_url_get(IntPtr error);

        internal static string ewk_error_url_get(IntPtr error)
        {
            IntPtr ptr = _ewk_error_url_get(error);
            return Marshal.PtrToStringAnsi(ptr);
        }

        [DllImport(Libraries.ChromiumEwk)]
        internal static extern int ewk_error_code_get(IntPtr error);

        [DllImport(Libraries.ChromiumEwk, EntryPoint = "ewk_error_description_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _ewk_error_description_get(IntPtr error);

        internal static string ewk_error_description_get(IntPtr error)
        {
            IntPtr ptr = _ewk_error_description_get(error);
            return Marshal.PtrToStringAnsi(ptr);
        }

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_error_cancellation_get(IntPtr error);
    }
}
