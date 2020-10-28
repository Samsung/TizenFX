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
        internal static extern IntPtr elm_ctxpopup_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_ctxpopup_horizontal_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_ctxpopup_horizontal_set(IntPtr obj, bool horizontal);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_ctxpopup_auto_hide_disabled_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_ctxpopup_auto_hide_disabled_set(IntPtr obj, bool disabled);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_ctxpopup_hover_parent_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_ctxpopup_hover_parent_set(IntPtr obj, IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_ctxpopup_direction_priority_set(IntPtr obj, int first, int second, int third, int fourth);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_ctxpopup_direction_priority_get(IntPtr obj, out int first, out int second, out int third, out int fourth);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_ctxpopup_direction_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_ctxpopup_dismiss(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_ctxpopup_clear(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_ctxpopup_item_append(IntPtr obj, string label, IntPtr icon, Evas.SmartCallback func, IntPtr data);
    }
}
