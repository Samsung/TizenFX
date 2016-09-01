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
        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_ctxpopup_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_ctxpopup_horizontal_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_ctxpopup_horizontal_set(IntPtr obj, bool horizontal);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_ctxpopup_auto_hide_disabled_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_ctxpopup_auto_hide_disabled_set(IntPtr obj, bool disabled);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_ctxpopup_hover_parent_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_ctxpopup_hover_parent_set(IntPtr obj, IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_ctxpopup_direction_available_get(IntPtr obj, int direction);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_ctxpopup_direction_priority_set(IntPtr obj, int first, int second, int third, int fourth);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_ctxpopup_direction_priority_get(IntPtr obj, out int first, out int second, out int third, out int fourth);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_ctxpopup_direction_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_ctxpopup_dismiss(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_ctxpopup_clear(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_ctxpopup_item_append(IntPtr obj, string label, IntPtr icon, Evas.SmartCallback func, IntPtr data);
    }
}
