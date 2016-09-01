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
        internal static extern IntPtr elm_slider_add(IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_slider_indicator_show_set(IntPtr obj, bool show);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_slider_indicator_show_get(IntPtr obj);

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
    }
}
