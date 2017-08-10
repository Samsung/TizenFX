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
        internal static extern IntPtr elm_panel_add(IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_panel_toggle(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_panel_hidden_set(IntPtr obj, bool hidden);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_panel_hidden_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_panel_scrollable_set(IntPtr obj, bool scrollable);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_panel_scrollable_content_size_set(IntPtr obj, double ratio);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_panel_orient_set(IntPtr obj, int orient);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_panel_orient_get(IntPtr obj);
    }
}
