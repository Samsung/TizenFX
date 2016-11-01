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
        internal static extern IntPtr elm_panes_add(IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_panes_content_left_size_set(IntPtr obj, double size);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_panes_content_left_size_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_panes_content_right_size_set(IntPtr obj, double size);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_panes_content_right_size_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_panes_horizontal_set(IntPtr obj, bool horizontal);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_panes_horizontal_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_panes_fixed_set(IntPtr obj, bool fix);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_panes_fixed_get(IntPtr obj);
    }
}
