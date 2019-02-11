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
    internal static partial class Elementary
    {
        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_hoversel_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_hoversel_horizontal_set(IntPtr obj, bool horizontal);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_hoversel_horizontal_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_hoversel_hover_parent_set(IntPtr obj, IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_hoversel_hover_parent_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_hoversel_expanded_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_hoversel_auto_update_set(IntPtr obj, bool auto_update);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_hoversel_auto_update_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_hoversel_hover_begin(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_hoversel_clear(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_hoversel_hover_end(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_hoversel_item_add(IntPtr obj, string label, string icon_file, int icon_type, Evas.SmartCallback func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_hoversel_item_icon_set(IntPtr obj, string icon_file, string icon_group, int icon_type);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_hoversel_item_icon_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern void _elm_hoversel_item_icon_get(IntPtr obj, out IntPtr icon_file, out IntPtr icon_group, int icon_type);
        internal static void elm_hoversel_item_icon_get(IntPtr obj, out string icon_file, out string icon_group, int icon_type)
        {
            IntPtr _icon_file;
            IntPtr _icon_group;
            _elm_hoversel_item_icon_get(obj, out _icon_file, out _icon_group, icon_type);
            icon_file = Marshal.PtrToStringAnsi(_icon_file);
            icon_group = Marshal.PtrToStringAnsi(_icon_group);
        }
    }
}

