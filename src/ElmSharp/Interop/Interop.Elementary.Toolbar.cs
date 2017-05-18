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
        internal static extern IntPtr elm_toolbar_add(IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_toolbar_shrink_mode_set(IntPtr obj, int shrink_mode);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_toolbar_shrink_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_toolbar_item_append(IntPtr obj, string icon, string label, Evas.SmartCallback func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_toolbar_item_prepend(IntPtr obj, string icon, string label, Evas.SmartCallback func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_toolbar_item_insert_before(IntPtr obj, IntPtr before, string icon, string label, Evas.SmartCallback func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_toolbar_transverse_expanded_set(IntPtr obj, bool transverse_expanded);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_toolbar_transverse_expanded_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_toolbar_select_mode_set(IntPtr obj, int mode);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_toolbar_select_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_toolbar_align_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_toolbar_align_set(IntPtr obj, double align);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_toolbar_homogeneous_set(IntPtr obj, bool homogeneous);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_toolbar_homogeneous_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_toolbar_horizontal_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_toolbar_horizontal_set(IntPtr obj, bool horizontal);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_toolbar_icon_order_lookup_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_toolbar_icon_order_lookup_set(IntPtr obj, int order);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_toolbar_icon_size_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_toolbar_icon_size_set(IntPtr obj, int size);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_toolbar_item_icon_set(IntPtr obj, string icon);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_toolbar_item_icon_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _elm_toolbar_item_icon_get(IntPtr obj);
        internal static string elm_toolbar_item_icon_get(IntPtr obj)
        {
            var text = _elm_toolbar_item_icon_get(obj);
            return Marshal.PtrToStringAnsi(text);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_toolbar_first_item_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_toolbar_last_item_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_toolbar_item_selected_set(IntPtr obj, bool selected);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_toolbar_item_selected_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_toolbar_selected_item_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_toolbar_item_separator_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_toolbar_item_separator_set(IntPtr obj, bool separator);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_toolbar_item_find_by_label(IntPtr obj, string label);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_toolbar_item_insert_after(IntPtr obj, IntPtr after, string icon, string label, Evas_Smart_Cb func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_toolbar_items_count(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_toolbar_menu_parent_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_toolbar_menu_parent_set(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_toolbar_more_item_get(IntPtr obj);
    }
}
