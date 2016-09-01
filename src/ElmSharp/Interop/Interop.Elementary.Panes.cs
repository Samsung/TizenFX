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
        internal static extern IntPtr elm_panes_add(IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_panes_content_left_size_set(IntPtr obj, double size);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_panes_content_left_size_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_panes_content_right_size_set(IntPtr obj, double size);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_panes_content_right_size_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_panes_horizontal_set(IntPtr obj, bool horizontal);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_panes_horizontal_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_panes_fixed_set(IntPtr obj, bool fix);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_panes_fixed_get(IntPtr obj);
    }
}
