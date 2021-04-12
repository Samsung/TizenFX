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
        public enum CacheModel
        {
            DocumentViewer,
            DocumentBrowser,
            PrimaryWebBrowser
        }

        [DllImport(Libraries.ChromiumEwk)]
        internal static extern IntPtr ewk_context_cookie_manager_get(IntPtr context);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_context_cache_model_set(IntPtr context, CacheModel model);

        [DllImport(Libraries.ChromiumEwk)]
        internal static extern CacheModel ewk_context_cache_model_get(IntPtr context);

        [DllImport(Libraries.ChromiumEwk)]
        internal static extern void ewk_context_resource_cache_clear(IntPtr context);

        [DllImport(Libraries.ChromiumEwk)]
        internal static extern void ewk_context_notify_low_memory(IntPtr context);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DownloadStartCallback(string url, IntPtr userData);

        [DllImport(Libraries.ChromiumEwk)]
        internal static extern void ewk_context_did_start_download_callback_set(IntPtr context, DownloadStartCallback callback, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void InterceptRequestCallback(IntPtr context, IntPtr request, IntPtr userData);

        [DllImport(Libraries.ChromiumEwk)]
        internal static extern void ewk_context_intercept_request_callback_set(IntPtr context, InterceptRequestCallback callback, IntPtr userData);

        [DllImport(Libraries.ChromiumEwk)]
        internal static extern uint ewk_context_inspector_server_start(IntPtr context, uint port);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_context_inspector_server_stop(IntPtr context);
    }
}
