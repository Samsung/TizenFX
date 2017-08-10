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
        internal enum Elm_Genlist_Item_Scrollto_Type
        {
            ELM_GENLIST_ITEM_SCROLLTO_NONE = 0,

            // Scrolls to nowhere
            ELM_GENLIST_ITEM_SCROLLTO_IN = (1 << 0),

            // Scrolls to the nearest viewport
            ELM_GENLIST_ITEM_SCROLLTO_TOP = (1 << 1),

            // Scrolls to the top of the viewport
            ELM_GENLIST_ITEM_SCROLLTO_MIDDLE = (1 << 2),

            // Scrolls to the middle of the viewport
            ELM_GENLIST_ITEM_SCROLLTO_BOTTOM = (1 << 3)

            // Scrolls to the bottom of the viewport
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void Evas_Smart_Cb(IntPtr data, IntPtr obj, IntPtr eventInfo);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_genlist_add(IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_mode_set(IntPtr obj, int mode);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_genlist_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_select_mode_set(IntPtr obj, int mode);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_genlist_select_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_genlist_item_append(IntPtr obj, IntPtr itc, IntPtr data, IntPtr parent, int type, Evas.SmartCallback func, IntPtr func_data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_genlist_item_prepend(IntPtr obj, IntPtr itc, IntPtr data, IntPtr parent, int type, Evas.SmartCallback func, IntPtr func_data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_genlist_item_insert_before(IntPtr obj, IntPtr itc, IntPtr data, IntPtr parent, IntPtr before, int type, Evas.SmartCallback func, IntPtr func_data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_genlist_item_class_new();

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_item_class_free(IntPtr itemClass);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_block_count_set(IntPtr obj, int count);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_genlist_block_count_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_homogeneous_set(IntPtr obj, bool homogeneous);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_genlist_homogeneous_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_genlist_item_index_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_genlist_item_type_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_genlist_item_parent_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_realized_items_update(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_item_update(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_item_show(IntPtr item, Elm_Genlist_Item_Scrollto_Type type);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_item_bring_in(IntPtr item, Elm_Genlist_Item_Scrollto_Type type);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_genlist_items_count(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_genlist_first_item_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_genlist_last_item_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_genlist_item_next_get(IntPtr item);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_genlist_item_prev_get(IntPtr item);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_genlist_item_selected_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_item_selected_set(IntPtr obj, bool selected);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_item_select_mode_set(IntPtr obj, Elm_Object_Select_Mode mode);

        [DllImport(Libraries.Elementary)]
        internal static extern Elm_Object_Select_Mode elm_genlist_item_select_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_item_item_class_update(IntPtr obj, IntPtr itc);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_clear(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_item_fields_update(IntPtr item, string part, uint type);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_reorder_mode_set(IntPtr obj, bool mode);

        [DllImport(Libraries.Elementary)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool elm_genlist_reorder_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern void elm_genlist_item_expanded_set(IntPtr obj, bool isExpanded);

        [DllImport(Libraries.Elementary)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool elm_genlist_item_expanded_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_genlist_highlight_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_highlight_mode_set(IntPtr obj, bool highlight);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_genlist_at_xy_item_get(IntPtr obj, int x, int y, out int posret);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_genlist_item_insert_after(IntPtr obj, IntPtr itc, IntPtr data, IntPtr parent, IntPtr after, int type, Evas.SmartCallback func, IntPtr func_data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_genlist_item_item_class_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_genlist_longpress_timeout_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_longpress_timeout_set(IntPtr obj, double timeout);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_genlist_multi_select_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_multi_select_set(IntPtr obj, bool multi);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_genlist_nth_item_get(IntPtr obj, int nth);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_genlist_selected_item_get(IntPtr obj);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_genlist_item_cursor_get")]
        internal static extern IntPtr _elm_genlist_item_cursor_get(IntPtr obj);

        internal static string elm_genlist_item_cursor_get(IntPtr obj)
        {
            return Marshal.PtrToStringAnsi(_elm_genlist_item_cursor_get(obj));
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_item_cursor_set(IntPtr obj, string cursor);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_item_cursor_unset(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_genlist_item_cursor_engine_only_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_item_cursor_engine_only_set(IntPtr obj, bool engineOnly);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_genlist_item_cursor_style_get")]
        internal static extern IntPtr _elm_genlist_item_cursor_style_get(IntPtr obj);

        internal static string elm_genlist_item_cursor_style_get(IntPtr obj)
        {
            return Marshal.PtrToStringAnsi(_elm_genlist_item_cursor_style_get(obj));
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_item_cursor_style_set(IntPtr obj, string style);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_item_demote(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_genlist_item_expanded_depth_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_item_subitems_clear(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_item_tooltip_text_set(IntPtr obj, string text);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_item_tooltip_unset(IntPtr obj);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_genlist_item_tooltip_style_get")]
        internal static extern IntPtr _elm_genlist_item_tooltip_style_get(IntPtr obj);

        internal static string elm_genlist_item_tooltip_style_get(IntPtr obj)
        {
            return Marshal.PtrToStringAnsi(_elm_genlist_item_tooltip_style_get(obj));
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_item_tooltip_style_set(IntPtr obj, string style);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_genlist_item_tooltip_window_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_genlist_item_tooltip_window_mode_set(IntPtr obj, bool disable);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_genlist_item_sorted_insert(IntPtr obj, IntPtr itc, IntPtr data, IntPtr parent, int type, Eina_Compare_Cb compare, Evas.SmartCallback func, IntPtr funcData);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_item_tooltip_content_cb_set(IntPtr obj, Elm_Tooltip_Item_Content_Cb func, IntPtr funcData, Evas.SmartCallback deleteFunc);
    }
}