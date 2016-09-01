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
        internal static extern IntPtr elm_spinner_add(IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_spinner_min_max_set(IntPtr obj, double min, double max);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_spinner_min_max_get(IntPtr obj, out double min, IntPtr max);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_spinner_min_max_get(IntPtr obj, IntPtr min, out double max);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_spinner_step_set(IntPtr obj, double step);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_spinner_step_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_spinner_wrap_set(IntPtr obj, bool wrap);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_spinner_wrap_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_spinner_interval_set(IntPtr obj, double interval);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_spinner_interval_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_spinner_round_set(IntPtr obj, int rnd);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_spinner_round_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_spinner_editable_set(IntPtr obj, bool editable);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_spinner_editable_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_spinner_base_set(IntPtr obj, double value);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_spinner_base_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_spinner_value_set(IntPtr obj, double val);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_spinner_value_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_spinner_label_format_set(IntPtr obj, string fmt);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_spinner_label_format_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _elm_spinner_label_format_get(IntPtr obj);
        internal static string elm_spinner_label_format_get(IntPtr obj)
        {
            var text = _elm_spinner_label_format_get(obj);
            return Marshal.PtrToStringAnsi(text);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_spinner_special_value_add(IntPtr obj, double value, string label);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_spinner_special_value_del(IntPtr obj, double value);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_spinner_special_value_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _elm_spinner_special_value_get(IntPtr obj, double value);
        internal static string elm_spinner_special_value_get(IntPtr obj, double value)
        {
            var text = _elm_spinner_special_value_get(obj, value);
            return Marshal.PtrToStringAnsi(text);
        }
    }
}
