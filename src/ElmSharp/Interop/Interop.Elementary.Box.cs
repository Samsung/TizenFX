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
        public delegate void BoxLayoutCallback(IntPtr obj, IntPtr priv, IntPtr userData);
        public delegate void BoxDataFreeCallback(IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_box_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_box_horizontal_set(IntPtr obj, bool horizontal);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_box_horizontal_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_box_pack_start(IntPtr obj, IntPtr subobj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_box_pack_end(IntPtr obj, IntPtr subobj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_box_pack_after(IntPtr obj, IntPtr subobj, IntPtr after);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_box_unpack(IntPtr obj, IntPtr subobj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_box_unpack_all(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_box_align_set(IntPtr obj, double horizontal, double vertical);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_box_align_get(IntPtr obj, out double horizontal, out double vertical);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_box_align_get(IntPtr obj, IntPtr horizontal, out double vertical);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_box_align_get(IntPtr obj, out double horizontal, IntPtr vertical);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_box_children_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_box_clear(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_box_padding_set(IntPtr obj, int horizontal, int vertical);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_box_padding_get(IntPtr obj, out int horizontal, out int vertical);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_box_layout_set(IntPtr obj, BoxLayoutCallback cb, IntPtr data, BoxDataFreeCallback dataFreeCb);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_box_layout_set(IntPtr obj, BoxLayoutCallback cb, IntPtr data, IntPtr dataFreeCb);
    }
}

