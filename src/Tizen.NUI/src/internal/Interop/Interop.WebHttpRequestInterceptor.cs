/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using global::System;
using global::System.Runtime.InteropServices;
using global::System.Runtime.InteropServices.Marshalling;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class WebHttpRequestInterceptor
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebRequestInterceptor_GetWebView", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetWebView(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebRequestInterceptor_GetUrl", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetUrl(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebRequestInterceptor_GetMethod", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetMethod(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebRequestInterceptor_GetHeaders", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetHeaders(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebRequestInterceptor_Ignore", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool Ignore(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebRequestInterceptor_SetResponseStatus", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool SetResponseStatus(IntPtr jarg1, int jarg2, string jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebRequestInterceptor_AddResponseHeader", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AddResponseHeader(IntPtr jarg1, string jarg2, string jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebRequestInterceptor_AddResponseHeaders", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AddResponseHeaders(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebRequestInterceptor_AddResponseBody", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AddResponseBody(IntPtr jarg1, string jarg2, uint jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "CSharp_Dali_WebRequestInterceptor_AddResponseBody", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AddResponseBody(IntPtr jarg1, [MarshalAs(UnmanagedType.LPArray)] byte[] jarg2, uint jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebRequestInterceptor_AddResponse", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AddResponse(IntPtr jarg1, string jarg2, string jarg3, uint jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "CSharp_Dali_WebRequestInterceptor_AddResponse", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AddResponse(IntPtr jarg1, string jarg2, [MarshalAs(UnmanagedType.LPArray)] byte[] jarg3, uint jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebRequestInterceptor_WriteResponseChunk", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool WriteResponseChunk(IntPtr jarg1, string jarg2, uint jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "CSharp_Dali_WebRequestInterceptor_WriteResponseChunk", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool WriteResponseChunk(IntPtr jarg1, [MarshalAs(UnmanagedType.LPArray)] byte[] jarg2, uint jarg3);
        }
    }
}






