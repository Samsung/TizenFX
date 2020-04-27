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
using Tizen.WebView;

internal static partial class Interop
{
    internal static partial class ChromiumEwk
    {
        [DllImport(Libraries.ChromiumEwk)]
        internal static extern IntPtr ewk_view_add(IntPtr evas);

        [DllImport(Libraries.ChromiumEwk)]
        internal static extern IntPtr ewk_view_context_get(IntPtr obj);

        [DllImport(Libraries.ChromiumEwk)]
        internal static extern IntPtr ewk_view_settings_get(IntPtr obj);

        [DllImport(Libraries.ChromiumEwk)]
        internal static extern IntPtr ewk_view_back_forward_list_get(IntPtr obj);

        [DllImport(Libraries.ChromiumEwk)]
        internal static extern void ewk_view_back_forward_list_clear(IntPtr obj);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_view_url_set(IntPtr obj, string url);

        [DllImport(Libraries.ChromiumEwk, EntryPoint = "ewk_view_url_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _ewk_view_url_get(IntPtr obj);

        internal static string ewk_view_url_get(IntPtr obj)
        {
            IntPtr ptr = _ewk_view_url_get(obj);
            return Marshal.PtrToStringAnsi(ptr);
        }

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_view_html_string_load(IntPtr obj, string html, string baseUrl, string unreachableUrl);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_view_reload(IntPtr obj);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_view_stop(IntPtr obj);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_view_back(IntPtr obj);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_view_forward(IntPtr obj);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_view_back_possible(IntPtr obj);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_view_forward_possible(IntPtr obj);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void ScriptExcuteCallback(IntPtr obj, IntPtr returnValue, IntPtr userData);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_view_script_execute(IntPtr obj, string script, ScriptExcuteCallback callback, IntPtr userData);

        [DllImport(Libraries.ChromiumEwk, EntryPoint = "ewk_view_title_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _ewk_view_title_get(IntPtr obj);

        internal static string ewk_view_title_get(IntPtr obj)
        {
            IntPtr ptr = _ewk_view_title_get(obj);
            return Marshal.PtrToStringAnsi(ptr);
        }

        [DllImport(Libraries.ChromiumEwk, EntryPoint = "ewk_view_user_agent_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _ewk_view_user_agent_get(IntPtr obj);

        internal static string ewk_view_user_agent_get(IntPtr obj)
        {
            IntPtr ptr = _ewk_view_user_agent_get(obj);
            return Marshal.PtrToStringAnsi(ptr);
        }

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_view_user_agent_set(IntPtr obj, string userAgent);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_view_focus_set(IntPtr obj, bool focused);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_view_focus_get(IntPtr obj);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_view_contents_size_get(IntPtr obj, out int width, out int height);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_view_fullscreen_exit(IntPtr obj);

        [DllImport(Libraries.ChromiumEwk)]
        internal static extern double ewk_view_load_progress_get(IntPtr obj);

        [DllImport(Libraries.ChromiumEwk)]
        internal static extern void ewk_view_orientation_send(IntPtr obj, Orientation orientation);

        [DllImport(Libraries.ChromiumEwk)]
        internal static extern void ewk_view_suspend(IntPtr obj);

        [DllImport(Libraries.ChromiumEwk)]
        internal static extern void ewk_view_resume(IntPtr obj);

        [DllImport(Libraries.ChromiumEwk)]
        internal static extern double ewk_view_scale_get(IntPtr obj);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_view_scale_set(IntPtr obj, double scaleFactor, int cX, int cY);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_view_visibility_set(IntPtr obj, bool enable);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_view_scroll_pos_get(IntPtr obj, out int X, out int Y);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_view_scroll_set(IntPtr obj, int X, int Y);

        [DllImport(Libraries.ChromiumEwk)]
        internal static extern void ewk_view_scroll_by(IntPtr obj, int X, int Y);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_view_text_find(IntPtr obj, string text, FindOption option, int maxMatchCount);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_view_url_request_set(IntPtr obj, string url, HttpMethod method, IntPtr headers, string body);

        [StructLayout(LayoutKind.Sequential, CharSet =CharSet.Ansi)]
        internal struct ScriptMessage
        {
            public IntPtr name;
            public IntPtr body;
        }

        internal delegate void ScriptMessageCallback(IntPtr obj, ScriptMessage message);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_view_javascript_message_handler_add(IntPtr obj, ScriptMessageCallback callback, string name);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_view_evaluate_javascript(IntPtr obj, string name, string result);
    }
}
