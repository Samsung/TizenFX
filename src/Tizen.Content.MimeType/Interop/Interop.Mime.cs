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

internal static partial class Interop
{
    internal static partial class Mime
    {
        [DllImport(Libraries.Mime, EntryPoint = "mime_type_get_mime_type", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetMime(
            [System.Runtime.InteropServices.InAttribute()]
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string file_extension
            , out string mime_type);

        [DllImport(Libraries.Mime, EntryPoint = "mime_type_get_file_extension", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetFile(
            [System.Runtime.InteropServices.InAttribute()]
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string mime_type
            , out System.IntPtr file_extension, out int length);
    }
}
