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
        internal static extern void elm_progressbar_part_value_set(IntPtr obj, string part, double val);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_progressbar_part_value_get(IntPtr obj, string part);

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