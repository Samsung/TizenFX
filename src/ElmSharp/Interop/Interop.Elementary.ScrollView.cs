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
        internal static extern void elm_interface_scrollable_content_size_get (out int w, out int h);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_interface_scrollable_page_bring_in (int pagenumber_h, int pagenumber_v);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_scroller_add (IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_bounce_get(IntPtr obj, out bool h_bounce, out bool v_bounce);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_bounce_set(IntPtr obj, bool h_bounce, bool v_bounce);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_child_size_get (IntPtr obj, out int w, out int h);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_content_min_limit (IntPtr obj, bool w, bool h);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_current_page_get (IntPtr obj, out int h_pagenumber, out int v_pagenumber);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_gravity_get(IntPtr obj, out double x, out double y);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_gravity_set (IntPtr obj, double x, double y);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_last_page_get (IntPtr obj, out int h_pagenumber, out int v_pagenumber);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_loop_get(IntPtr obj, out bool loop_h, out bool loop_v);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_loop_set (IntPtr obj, bool loop_h, bool loop_v);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_scroller_movement_block_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_movement_block_set(IntPtr obj, int block);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_page_bring_in (IntPtr obj, int h_pagenumber, int v_pagenumber);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_page_relative_get (IntPtr obj, out double h_pagerel, out double v_pagerel);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_page_relative_set (IntPtr obj, double h_pagerel, double v_pagerel);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_page_show (IntPtr obj, int h_pagenumber, int v_pagenumber);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_page_size_get (IntPtr obj, out int h_pagesize, out int v_pagesize);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_page_size_set (IntPtr obj, int h_pagesize, int v_pagesize);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_page_snap_get (IntPtr obj, out bool page_h_snap, out bool page_v_snap);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_page_snap_set (IntPtr obj, bool page_h_snap, bool page_v_snap);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_policy_get(IntPtr obj, out int policy_h, out int policy_v);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_policy_get(IntPtr obj, out int policy_h, IntPtr policy_v);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_policy_get(IntPtr obj, IntPtr policy_h, out int policy_v);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_policy_set(IntPtr obj, int policy_h, int policy_v);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_region_bring_in (IntPtr obj, int x, int y, int w, int h);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_region_get (IntPtr obj, out int x, out int y, out int w, out int h);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_region_show (IntPtr obj, int x, int y, int w, int h);

        // @TODO uses Elm_Scroller_Single_Direction structure:
        // internal static extern ElmScrollerSingleDirection elm_scroller_single_direction_get(IntPtr obj);
        // internal static extern void elm_scroller_single_direction_set(IntPtr obj, ElmScrollerSingleDirection single_dir);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_step_size_get (IntPtr obj, out int x, out int y);

        [DllImportAttribute(Libraries.Elementary)]
        internal static extern void elm_scroller_step_size_set (IntPtr obj, int x, int y);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_scroller_wheel_disabled_get (IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_wheel_disabled_set (IntPtr obj, bool disabled);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_scroller_propagate_events_get (IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_propagate_events_set (IntPtr obj, bool propagation);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_page_scroll_limit_get (IntPtr obj, out int page_limit_h_, out int page_limit_v_);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_scroller_page_scroll_limit_set (IntPtr obj, int page_limit_h_, int page_limit_v_);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_scroll_lock_y_set(IntPtr obj, bool enable);
    }
}
