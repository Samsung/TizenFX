/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

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
        internal static extern void elm_colorselector_palette_item_color_set(IntPtr obj, int r, int g, int b, int a);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_colorselector_palette_item_selected_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_colorselector_palette_item_selected_set(IntPtr obj, bool selected);

    }
}
