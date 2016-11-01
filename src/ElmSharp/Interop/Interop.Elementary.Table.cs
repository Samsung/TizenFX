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
        internal static extern IntPtr elm_table_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_table_homogeneous_set(IntPtr obj, bool homogeneous);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_table_homogeneous_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_table_padding_set(IntPtr obj, int horizontal, int vertical);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_table_padding_get(IntPtr obj, out int horizontal, out int vertical);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_table_clear (IntPtr obj, bool clear);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_table_unpack (IntPtr obj, IntPtr subobj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_table_pack(IntPtr obj, IntPtr subobj, int column, int row, int colspan, int rowspan);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_table_pack_set(IntPtr subobj, int col, int row, int colspan, int rowspan);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_table_pack_get(IntPtr subobj, out int col, out int row, out int colspan, out int rowspan);
    }
}
