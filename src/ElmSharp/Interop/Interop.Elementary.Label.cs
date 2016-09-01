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
        internal static extern IntPtr elm_label_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_label_slide_mode_set(IntPtr obj, int mode);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_label_slide_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_label_slide_duration_set(IntPtr obj, double duration);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_label_slide_duration_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_label_slide_go(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_label_line_wrap_set(IntPtr obj, int wrap);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_label_line_wrap_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_label_wrap_width_set(IntPtr obj, int w);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_label_wrap_width_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_label_ellipsis_set(IntPtr obj, bool ellipsis);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_label_ellipsis_get(IntPtr obj);
    }
}
