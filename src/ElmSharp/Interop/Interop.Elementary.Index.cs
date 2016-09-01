// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Elementary
    {
        internal delegate void EventCallback(IntPtr data, IntPtr obj, IntPtr info);

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
    }
}
