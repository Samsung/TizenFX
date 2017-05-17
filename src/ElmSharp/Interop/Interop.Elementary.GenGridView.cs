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
        internal static extern IntPtr elm_gengrid_add(IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gengrid_align_set(IntPtr obj, double align_x, double align_y);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gengrid_align_get(IntPtr obj, out double align_x, out double align_y);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gengrid_align_get(IntPtr obj, IntPtr align_x, out double align_y);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gengrid_align_get(IntPtr obj, out double align_x, IntPtr align_y);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gengrid_horizontal_set(IntPtr obj, bool horizontal);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_gengrid_horizontal_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gengrid_multi_select_set(IntPtr obj, bool multi);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_gengrid_multi_select_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_gengrid_item_append(IntPtr obj, IntPtr itc, IntPtr data, Evas.SmartCallback func, IntPtr func_data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_gengrid_item_prepend(IntPtr obj, IntPtr itc, IntPtr data, Evas.SmartCallback func, IntPtr func_data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_gengrid_item_insert_before(IntPtr obj, IntPtr itc, IntPtr data, IntPtr before, Evas.SmartCallback func, IntPtr func_data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_gengrid_item_class_new();

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gengrid_item_size_set(IntPtr obj, int w, int h);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gengrid_item_size_get(IntPtr obj, out int w, out int h);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gengrid_item_size_get(IntPtr obj, IntPtr w, out int h);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gengrid_item_size_get(IntPtr obj, out int w, IntPtr h);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gengrid_filled_set(IntPtr obj, bool fill);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_gengrid_filled_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_gengrid_item_index_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gengrid_clear(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gengrid_item_selected_set(IntPtr obj, bool selected);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_gengrid_item_selected_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern uint elm_gengrid_items_count(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gengrid_highlight_mode_set(IntPtr obj, bool highlight);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_gengrid_highlight_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gengrid_item_show(IntPtr obj, int type);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gengrid_item_bring_in(IntPtr obj, int type);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gengrid_item_select_mode_set(IntPtr it, int mode);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_gengrid_item_select_mode_get(IntPtr it);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gengrid_select_mode_set(IntPtr it, int mode);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_gengrid_select_mode_get(IntPtr it);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gengrid_realized_items_update(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gengrid_item_update(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_gengrid_at_xy_item_get(IntPtr obj, int x, int y, out int xposret, out int yposret);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_gengrid_selected_item_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_gengrid_first_item_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_gengrid_item_class_free(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_gengrid_last_item_get(IntPtr obj);
    }
}