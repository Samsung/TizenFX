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
        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_settings_javascript_enabled_set(IntPtr settings, bool enable);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_settings_javascript_enabled_get(IntPtr settings);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_settings_loads_images_automatically_set(IntPtr settings, bool enable);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_settings_loads_images_automatically_get(IntPtr settings);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_settings_default_text_encoding_name_set(IntPtr settings, string encoding);

        [DllImport(Libraries.ChromiumEwk, EntryPoint = "ewk_settings_default_text_encoding_name_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _ewk_settings_default_text_encoding_name_get(IntPtr settings);

        internal static string ewk_settings_default_text_encoding_name_get(IntPtr settings)
        {
            IntPtr ptr = _ewk_settings_default_text_encoding_name_get(settings);
            return Marshal.PtrToStringAnsi(ptr);
        }

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_settings_default_font_size_set(IntPtr settings, int size);

        [DllImport(Libraries.ChromiumEwk)]
        internal static extern int ewk_settings_default_font_size_get(IntPtr settings);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_settings_scripts_can_open_windows_set(IntPtr settings, bool enable);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_settings_scripts_can_open_windows_get(IntPtr settings);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_settings_force_zoom_set(IntPtr settings, bool enable);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_settings_force_zoom_get(IntPtr settings);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_settings_text_autosizing_enabled_set(IntPtr settings, bool enable);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_settings_text_autosizing_enabled_get(IntPtr settings);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_settings_text_zoom_enabled_set(IntPtr settings, bool enable);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_settings_text_zoom_enabled_get(IntPtr settings);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_settings_uses_keypad_without_user_action_set(IntPtr settings, bool enable);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_settings_uses_keypad_without_user_action_get(IntPtr settings);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_settings_extra_feature_set(IntPtr settings, string name, bool enable);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_settings_extra_feature_get(IntPtr settings, string name);
    }
}
