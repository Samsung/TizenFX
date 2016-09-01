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
        internal static extern IntPtr elm_progressbar_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_progressbar_pulse_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_progressbar_pulse_set(IntPtr obj, bool pulse);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_progressbar_horizontal_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_progressbar_horizontal_set(IntPtr obj, bool horizontal);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_progressbar_inverted_set(IntPtr obj, bool inverted);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_progressbar_inverted_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_progressbar_value_set(IntPtr obj, double val);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_progressbar_value_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_progressbar_span_size_set(IntPtr obj, int size);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_progressbar_span_size_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_progressbar_pulse(IntPtr obj, bool state);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_progressbar_unit_format_set(IntPtr obj, string format);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr _elm_progressbar_unit_format_get(IntPtr obj);

        internal static string elm_progressbar_unit_format_get(IntPtr obj)
        {
            var format = _elm_progressbar_unit_format_get(obj);
            return Marshal.PtrToStringAnsi(format);
        }
    }
}
