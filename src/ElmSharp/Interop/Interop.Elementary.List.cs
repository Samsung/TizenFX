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
        public enum Elm_List_Mode
        {
            ELM_LIST_COMPRESS = 0,
            ELM_LIST_SCROLL,
            ELM_LIST_LIMIT,
            ELM_LIST_EXPAND,
            ELM_LIST_LAST
        }

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_list_add(IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_list_item_append(IntPtr obj, string label, IntPtr lefticon, IntPtr righticon, Evas.SmartCallback func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_list_item_prepend(IntPtr obj, string label, IntPtr icon, IntPtr end, Evas.SmartCallback func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_list_go(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_list_mode_set(IntPtr obj, Elm_List_Mode listMode);

        [DllImport(Libraries.Elementary)]
        internal static extern Elm_List_Mode elm_list_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_list_item_selected_set(IntPtr obj, bool value);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_list_selected_item_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_list_clear(IntPtr obj);
    }
}
