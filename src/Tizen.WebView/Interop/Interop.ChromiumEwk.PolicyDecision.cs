/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
        public enum PolicyDecisionType {
            Use,
            Download,
            Ignore
        };

        [DllImport(Libraries.ChromiumEwk, EntryPoint = "ewk_policy_decision_url_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _ewk_policy_decision_url_get(IntPtr policydecision);
        internal static string ewk_policy_decision_url_get(IntPtr policydecision)
        {
            IntPtr ptr = _ewk_policy_decision_url_get(policydecision);
            return Marshal.PtrToStringAnsi(ptr);
        }

        [DllImport(Libraries.ChromiumEwk, EntryPoint = "ewk_policy_decision_scheme_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _ewk_policy_decision_scheme_get(IntPtr policydecision);
        internal static string ewk_policy_decision_scheme_get(IntPtr policydecision)
        {
            IntPtr ptr = _ewk_policy_decision_scheme_get(policydecision);
            return Marshal.PtrToStringAnsi(ptr);
        }

        [DllImport(Libraries.ChromiumEwk, EntryPoint = "ewk_policy_decision_cookie_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _ewk_policy_decision_cookie_get(IntPtr policydecision);
        internal static string ewk_policy_decision_cookie_get(IntPtr policydecision)
        {
            IntPtr ptr = _ewk_policy_decision_cookie_get(policydecision);
            return Marshal.PtrToStringAnsi(ptr);
        }

        [DllImport(Libraries.ChromiumEwk)]
        internal static extern NavigationType ewk_policy_decision_navigation_type_get(IntPtr policydecision);

        [DllImport(Libraries.ChromiumEwk)]
        internal static extern PolicyDecisionType ewk_policy_decision_type_get(IntPtr policydecision);

        [DllImport(Libraries.ChromiumEwk)]
        internal static extern int ewk_policy_decision_response_status_code_get(IntPtr policydecision);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_policy_decision_is_main_frame(IntPtr policydecision);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_policy_decision_ignore(IntPtr policydecision);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_policy_decision_use(IntPtr policydecision);
    }
}
