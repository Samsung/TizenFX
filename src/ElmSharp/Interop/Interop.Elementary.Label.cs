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
        internal static extern IntPtr elm_label_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_label_slide_mode_set(IntPtr obj, int mode);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_label_slide_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_label_slide_duration_set(IntPtr obj, double duration);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_label_slide_duration_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_label_slide_speed_set(IntPtr obj, double speed);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_label_slide_speed_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_label_slide_go(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_label_line_wrap_set(IntPtr obj, int wrap);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_label_line_wrap_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_label_wrap_width_set(IntPtr obj, int w);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_label_wrap_width_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_label_ellipsis_set(IntPtr obj, bool ellipsis);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_label_ellipsis_get(IntPtr obj);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_label_text_style_user_peek", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _elm_label_text_style_user_peek(IntPtr obj);
        internal static string elm_label_text_style_user_peek(IntPtr obj)
        {
            var text = _elm_label_text_style_user_peek(obj);
            return Marshal.PtrToStringAnsi(text);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_label_text_style_user_push(IntPtr obj, string style);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_label_text_style_user_pop(IntPtr obj);
    }
}