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
        internal static extern IntPtr elm_panel_add(IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_panel_toggle(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_panel_hidden_set(IntPtr obj, bool hidden);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_panel_hidden_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_panel_scrollable_set(IntPtr obj, bool scrollable);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_panel_scrollable_content_size_set(IntPtr obj, double ratio);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_panel_orient_set(IntPtr obj, int orient);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_panel_orient_get(IntPtr obj);
    }
}
