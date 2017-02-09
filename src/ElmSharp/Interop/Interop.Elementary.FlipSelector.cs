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
        internal static extern IntPtr elm_flipselector_add(IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_flipselector_first_interval_get(IntPtr flipSelector);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_flipselector_first_interval_set(IntPtr flipSelector, double interval);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_flipselector_item_append(IntPtr flipSelector, string text, Evas.SmartCallback func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_flipselector_item_prepend(IntPtr flipSelector, string text, Evas.SmartCallback func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_flipselector_flip_next(IntPtr flipSelector);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_flipselector_flip_prev(IntPtr flipSelector);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_flipselector_selected_item_get(IntPtr flipSelector);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_flipselector_first_item_get(IntPtr flipSelector);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_flipselector_last_item_get(IntPtr flipSelector);
    }
}
