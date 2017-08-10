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
        internal static extern IntPtr elm_popup_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_popup_timeout_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_popup_timeout_set(IntPtr obj, double timeout);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_popup_timeout_set(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_popup_orient_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_popup_orient_set(IntPtr obj, int orient);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_popup_orient_set(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_popup_allow_events_set(IntPtr obj, bool allow);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_popup_allow_events_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_popup_item_append(IntPtr obj, string label, IntPtr icon, Evas.SmartCallback func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_popup_dismiss(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_popup_align_set(IntPtr obj, double horizontal, double vertical);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_popup_align_get(IntPtr obj, out double horizontal, out double vertical);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_popup_align_get(IntPtr obj, IntPtr horizontal, out double vertical);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_popup_align_get(IntPtr obj, out double horizontal, IntPtr vertical);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_popup_content_text_wrap_type_set(IntPtr obj, int type);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_popup_content_text_wrap_type_get(IntPtr obj);

        internal static double GetPopupAlignX(IntPtr obj)
        {
            double x;
            elm_popup_align_get(obj, out x, IntPtr.Zero);
            return x;
        }

        internal static double GetPopupAlignY(IntPtr obj)
        {
            double y;
            elm_popup_align_get(obj, IntPtr.Zero, out y);
            return y;
        }

        internal static void SetPopupAlignX(IntPtr obj, double x)
        {
            double y = GetPopupAlignY(obj);
            elm_popup_align_set(obj, x, y);
        }

        internal static void SetPopupAlignY(IntPtr obj, double y)
        {
            double x = GetPopupAlignX(obj);
            elm_popup_align_set(obj, x, y);
        }
    }
}
