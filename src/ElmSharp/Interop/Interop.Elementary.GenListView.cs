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
        internal enum Elm_Genlist_Item_Scrollto_Type
        {
            ELM_GENLIST_ITEM_SCROLLTO_NONE = 0,
            // Scrolls to nowhere
            ELM_GENLIST_ITEM_SCROLLTO_IN = (1 << 0),
            // Scrolls to the nearest viewport
            ELM_GENLIST_ITEM_SCROLLTO_TOP = (1 << 1),
            // Scrolls to the top of the viewport
            ELM_GENLIST_ITEM_SCROLLTO_MIDDLE = (1 << 2),
            // Scrolls to the middle of the viewport
            ELM_GENLIST_ITEM_SCROLLTO_BOTTOM = (1 << 3)
            // Scrolls to the bottom of the viewport
        }

        internal enum Elm_Object_Select_Mode
        {
            ELM_OBJECT_SELECT_MODE_DEFAULT,
            ELM_OBJECT_SELECT_MODE_ALWAYS,
            ELM_OBJECT_SELECT_MODE_NONE,
            ELM_OBJECT_SELECT_MODE_DISPLAY_ONLY
        }

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_genlist_add(IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_mode_set(IntPtr obj, int mode);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_genlist_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_select_mode_set(IntPtr obj, int mode);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_genlist_select_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_genlist_item_append(IntPtr obj, IntPtr itc, IntPtr data, IntPtr parent, int type, Evas.SmartCallback func, IntPtr func_data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_genlist_item_prepend(IntPtr obj, IntPtr itc, IntPtr data, IntPtr parent, int type, Evas.SmartCallback func, IntPtr func_data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_genlist_item_insert_before(IntPtr obj, IntPtr itc, IntPtr data, IntPtr parent, IntPtr before, int type, Evas.SmartCallback func, IntPtr func_data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_genlist_item_class_new();

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_item_class_free(IntPtr itemClass);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_block_count_set(IntPtr obj, int count);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_genlist_block_count_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_homogeneous_set(IntPtr obj, bool homogeneous);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_genlist_homogeneous_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_genlist_item_index_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_genlist_item_type_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_genlist_item_parent_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_realized_items_update(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_item_update(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_item_show(IntPtr item, Elm_Genlist_Item_Scrollto_Type type);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_item_bring_in(IntPtr item, Elm_Genlist_Item_Scrollto_Type type);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_genlist_items_count(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_genlist_first_item_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_genlist_last_item_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_genlist_item_selected_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_item_selected_set(IntPtr obj, bool selected);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_item_select_mode_set(IntPtr obj, Elm_Object_Select_Mode mode);

        [DllImport(Libraries.Elementary)]
        internal static extern Elm_Object_Select_Mode elm_genlist_item_select_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_item_item_class_update(IntPtr obj, IntPtr itc);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_genlist_clear(IntPtr obj);
    }
}
