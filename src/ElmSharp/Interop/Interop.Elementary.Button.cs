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
        internal static extern IntPtr elm_button_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_button_autorepeat_initial_timeout_set(IntPtr obj, double t);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_button_autorepeat_initial_timeout_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_button_autorepeat_gap_timeout_set(IntPtr obj, double t);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_button_autorepeat_gap_timeout_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_button_autorepeat_set(IntPtr obj, bool on);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_button_autorepeat_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_radio_add(IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_radio_group_add(IntPtr obj, IntPtr group);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_radio_state_value_set(IntPtr obj, int value);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_radio_state_value_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_radio_value_set(IntPtr obj, int value);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_radio_value_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_radio_selected_object_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_check_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_check_state_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_check_state_set(IntPtr obj, bool value);
    }
}
