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
        internal enum Elm_Slider_Indicator_Visible_Mode
        {
            ELM_SLIDER_INDICATOR_VISIBLE_MODE_DEFAULT, /* show indicator on mouse down or change in slider value */
            ELM_SLIDER_INDICATOR_VISIBLE_MODE_ALWAYS, /* Always show the indicator. */
            ELM_SLIDER_INDICATOR_VISIBLE_MODE_ON_FOCUS, /* Show the indicator on focus */
            ELM_SLIDER_INDICATOR_VISIBLE_MODE_NONE /* Never show the indicator */
        }

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_slider_add(IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_slider_indicator_show_set(IntPtr obj, bool show);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_slider_indicator_show_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_slider_indicator_show_on_focus_set(IntPtr obj, bool focus);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_slider_indicator_show_on_focus_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_slider_indicator_format_set(IntPtr obj, string indicator);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_slider_indicator_format_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _elm_slider_indicator_format_get(IntPtr obj);

        internal static string elm_slider_indicator_format_get(IntPtr obj)
        {
            var text = _elm_slider_indicator_format_get(obj);
            return Marshal.PtrToStringAnsi(text);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_slider_unit_format_set(IntPtr obj, string units);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_slider_unit_format_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _elm_slider_unit_format_get(IntPtr obj);

        internal static string elm_slider_unit_format_get(IntPtr obj)
        {
            var text = _elm_slider_unit_format_get(obj);
            return Marshal.PtrToStringAnsi(text);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_slider_inverted_set(IntPtr obj, bool inverted);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_slider_inverted_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_slider_horizontal_set(IntPtr obj, bool value);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_slider_horizontal_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_slider_min_max_set(IntPtr obj, double min, double max);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_slider_min_max_get(IntPtr obj, out double min, out double max);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_slider_min_max_get(IntPtr obj, out double min, IntPtr max);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_slider_min_max_get(IntPtr obj, IntPtr min, out double max);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_slider_value_set(IntPtr obj, double val);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_slider_value_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_slider_span_size_set(IntPtr obj, int size);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_slider_span_size_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_slider_step_set(IntPtr obj, double step);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_slider_step_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_slider_indicator_visible_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_slider_indicator_visible_mode_set(IntPtr obj, int mode);
    }
}