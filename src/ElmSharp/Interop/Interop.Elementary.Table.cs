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
        internal static extern IntPtr elm_table_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_table_homogeneous_set(IntPtr obj, bool homogeneous);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_table_homogeneous_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_table_padding_set(IntPtr obj, int horizontal, int vertical);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_table_padding_get(IntPtr obj, out int horizontal, out int vertical);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_table_clear (IntPtr obj, bool clear);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_table_unpack (IntPtr obj, IntPtr subobj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_table_pack(IntPtr obj, IntPtr subobj, int column, int row, int colspan, int rowspan);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_table_pack_set(IntPtr subobj, int col, int row, int colspan, int rowspan);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_table_pack_get(IntPtr subobj, out int col, out int row, out int colspan, out int rowspan);
    }
}
