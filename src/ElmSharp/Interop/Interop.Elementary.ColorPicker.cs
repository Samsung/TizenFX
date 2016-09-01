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

        internal enum Elm_Colorselector_Mode
        {
            ELM_COLORSELECTOR_PALETTE = 0, /* Only color palette is displayed. */
            ELM_COLORSELECTOR_COMPONENTS, /* Only color selector is displayed. */
            ELM_COLORSELECTOR_BOTH, /* Both Palette and selector is displayed, default.*/
            ELM_COLORSELECTOR_PICKER, /* Only color picker is displayed. */
            ELM_COLORSELECTOR_ALL /* All possible color selector is displayed. */
        };

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_colorselector_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_colorselector_color_set(IntPtr obj, int r, int g, int b, int a);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_colorselector_color_get(IntPtr obj, out int r, out int g, out int b, out int a);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_colorselector_palette_name_set(IntPtr obj, string name);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_colorselector_palette_name_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _elm_colorselector_palette_name_get(IntPtr obj);
        internal static string elm_colorselector_palette_name_get(IntPtr obj)
        {
            var text = _elm_colorselector_palette_name_get(obj);
            return Marshal.PtrToStringAnsi(text);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_colorselector_mode_set(IntPtr obj, Elm_Colorselector_Mode mode);

        [DllImport(Libraries.Elementary)]
        internal static extern Elm_Colorselector_Mode elm_colorselector_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_colorselector_palette_color_add(IntPtr obj, int r, int g, int b, int a);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_colorselector_palette_clear(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_colorselector_palette_selected_item_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_colorselector_palette_item_color_get(IntPtr obj, out int r, out int g, out int b, out int a);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_colorselector_palette_item_color_set(IntPtr obj, int r, int g, int b, int a);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_colorselector_palette_item_selected_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_colorselector_palette_item_selected_set(IntPtr obj, bool selected);

    }
}
