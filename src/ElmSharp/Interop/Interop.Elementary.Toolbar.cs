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
        internal static extern IntPtr elm_toolbar_add(IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_toolbar_shrink_mode_set(IntPtr obj, int shrink_mode);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_toolbar_shrink_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_toolbar_item_append(IntPtr obj, string icon, string label, Evas.SmartCallback func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_toolbar_item_prepend(IntPtr obj, string icon, string label, Evas.SmartCallback func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_toolbar_item_insert_before(IntPtr obj, IntPtr before, string icon, string label, Evas.SmartCallback func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_toolbar_transverse_expanded_set(IntPtr obj, bool transverse_expanded);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_toolbar_transverse_expanded_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_toolbar_select_mode_set(IntPtr obj, int mode);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_toolbar_select_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_toolbar_align_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_toolbar_align_set(IntPtr obj, double align);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_toolbar_homogeneous_set(IntPtr obj, bool homogeneous);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_toolbar_homogeneous_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_toolbar_item_icon_set(IntPtr obj, string icon);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_toolbar_item_icon_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _elm_toolbar_item_icon_get(IntPtr obj);
        internal static string elm_toolbar_item_icon_get(IntPtr obj)
        {
            var text = _elm_toolbar_item_icon_get(obj);
            return Marshal.PtrToStringAnsi(text);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_toolbar_first_item_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_toolbar_last_item_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_toolbar_item_selected_set(IntPtr obj, bool selected);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_toolbar_item_selected_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_toolbar_selected_item_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_toolbar_item_separator_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_toolbar_item_separator_set(IntPtr obj, bool separator);
    }
}
