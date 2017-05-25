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
        public delegate bool MultiButtonEntryItemFilterCallback(IntPtr obj, string label, IntPtr itemData, IntPtr data);

        public delegate string MultiButtonEntryFormatCallback(int count, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_multibuttonentry_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_multibuttonentry_entry_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_multibuttonentry_expanded_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_multibuttonentry_expanded_set(IntPtr obj, bool expanded);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_multibuttonentry_editable_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_multibuttonentry_editable_set(IntPtr obj, bool editable);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_multibuttonentry_item_prepend(IntPtr obj, string label, Evas.SmartCallback func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_multibuttonentry_item_append(IntPtr obj, string label, Evas.SmartCallback func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_multibuttonentry_item_insert_before(IntPtr obj, IntPtr before, string label, Evas.SmartCallback func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_multibuttonentry_item_insert_after(IntPtr obj, IntPtr after, string label, Evas.SmartCallback func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_multibuttonentry_first_item_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_multibuttonentry_last_item_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_multibuttonentry_selected_item_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_multibuttonentry_item_selected_set(IntPtr obj, bool selected);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_multibuttonentry_item_selected_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_multibuttonentry_clear(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_multibuttonentry_item_prev_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_multibuttonentry_item_next_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_multibuttonentry_format_function_set(IntPtr obj, MultiButtonEntryFormatCallback callback, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_multibuttonentry_item_filter_append(IntPtr obj, MultiButtonEntryItemFilterCallback callback, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_multibuttonentry_item_filter_prepend(IntPtr obj, MultiButtonEntryItemFilterCallback callback, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_multibuttonentry_item_filter_remove(IntPtr obj, MultiButtonEntryItemFilterCallback callback, IntPtr data);
    }
}