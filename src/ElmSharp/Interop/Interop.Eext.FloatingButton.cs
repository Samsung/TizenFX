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
    internal static partial class Eext
    {
        [DllImport(Libraries.Eext)]
        internal static extern IntPtr eext_floatingbutton_add(IntPtr parent);

        [DllImport(Libraries.Eext)]
        internal static extern int eext_floatingbutton_mode_get(IntPtr floatingButton);

        [DllImport(Libraries.Eext)]
        internal static extern void eext_floatingbutton_mode_set(IntPtr floatingButton, int mode);

        [DllImport(Libraries.Eext)]
        internal static extern int eext_floatingbutton_pos_get(IntPtr floatingButton);

        [DllImport(Libraries.Eext)]
        internal static extern bool eext_floatingbutton_pos_set(IntPtr floatingButton, int position);

        [DllImport(Libraries.Eext)]
        internal static extern bool eext_floatingbutton_movement_block_get(IntPtr floatingButton);

        [DllImport(Libraries.Eext)]
        internal static extern void eext_floatingbutton_movement_block_set(IntPtr floatingButton, bool block);

        [DllImport(Libraries.Eext)]
        internal static extern bool eext_floatingbutton_pos_bring_in(IntPtr floatingButton, int posposition);
    }
}