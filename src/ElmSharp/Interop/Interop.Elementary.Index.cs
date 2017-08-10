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
        internal delegate void EventCallback(IntPtr data, IntPtr obj, IntPtr info);

        internal delegate void SmartCallback(IntPtr data, IntPtr obj, IntPtr info);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_index_add(IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_index_autohide_disabled_get(IntPtr index);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_index_autohide_disabled_set(IntPtr index, bool disabled);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_index_horizontal_get(IntPtr index);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_index_horizontal_set(IntPtr index, bool horizontal);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_index_item_append(IntPtr index, string text, EventCallback callback, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_index_item_prepend(IntPtr index, string text, EventCallback callback, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_index_selected_item_get(IntPtr index, int level);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_index_item_selected_set(IntPtr item, bool selected);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_index_level_go(IntPtr index, int level);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_index_indicator_disabled_get(IntPtr index);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_index_indicator_disabled_set(IntPtr index, bool disabled);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_index_omit_enabled_get(IntPtr index);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_index_omit_enabled_set(IntPtr index, bool enabled);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_index_item_insert_before(IntPtr obj, IntPtr before, string letter, EventCallback func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_index_item_sorted_insert(IntPtr obj, string letter, Evas_Smart_Cb func, IntPtr data, Eina_Compare_Cb cmpFunc, Eina_Compare_Cb cmpDataFunc);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_index_delay_change_time_set(IntPtr obj, double time);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_index_delay_change_time_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_index_item_clear(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_index_item_find(IntPtr obj, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_index_item_insert_after(IntPtr obj, IntPtr after, string letter, SmartCallback func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_index_item_level_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_index_item_level_set(IntPtr obj, int level);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_index_standard_priority_set(IntPtr obj, int priority);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_index_standard_priority_get(IntPtr obj);
    }
}