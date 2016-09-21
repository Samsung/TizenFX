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
        internal static extern void elm_naviframe_item_pop_cb_set(IntPtr it, Elm_Naviframe_Item_Pop_Cb func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_naviframe_add(IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_naviframe_prev_btn_auto_pushed_set(IntPtr obj, bool value);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_naviframe_prev_btn_auto_pushed_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_naviframe_item_title_enabled_set(IntPtr item, bool enable, bool transition);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_naviframe_item_title_enabled_get(IntPtr item);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_naviframe_item_push(IntPtr obj, string title, IntPtr prev, IntPtr next, IntPtr content, string style);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_naviframe_item_pop(IntPtr obj);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool Elm_Naviframe_Item_Pop_Cb(IntPtr data, IntPtr item);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_naviframe_content_preserve_on_pop_set(IntPtr obj, bool preserve);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_naviframe_content_preserve_on_pop_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_naviframe_item_insert_before(IntPtr naviframe, IntPtr before, string title, IntPtr prev, IntPtr next, IntPtr content, string style);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_naviframe_item_insert_after(IntPtr naviframe, IntPtr after, string title, IntPtr prev, IntPtr next, IntPtr content, string style);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_naviframe_top_item_get(IntPtr naviframe);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_naviframe_bottom_item_get(IntPtr naviframe);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_naviframe_item_pop_to(IntPtr item);
    }
}
