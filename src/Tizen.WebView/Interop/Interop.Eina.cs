/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
    internal static partial class Eina
    {
        [DllImport(Libraries.Eina)]
        internal static extern IntPtr eina_hash_string_small_new(IntPtr dataFreeCb);

        [DllImport(Libraries.Eina)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool eina_hash_add(IntPtr hash, IntPtr Key, IntPtr Value);

        [DllImport(Libraries.Eina)]
        internal static extern IntPtr eina_list_iterator_new(IntPtr list);

        [DllImport(Libraries.Eina)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool eina_iterator_next(IntPtr iterator, out IntPtr data);

        [DllImport(Libraries.Eina)]
        internal static extern void eina_iterator_free(IntPtr list);

        [DllImport(Libraries.Eina)]
        internal static extern IntPtr eina_list_free(IntPtr list);
    }
}
