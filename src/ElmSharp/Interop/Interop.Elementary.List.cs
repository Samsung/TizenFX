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
        public enum Elm_List_Mode
        {
            ELM_LIST_COMPRESS = 0,
            ELM_LIST_SCROLL,
            ELM_LIST_LIMIT,
            ELM_LIST_EXPAND,
            ELM_LIST_LAST
        }

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_list_add(IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_list_item_append(IntPtr obj, string label, IntPtr lefticon, IntPtr righticon, Evas.SmartCallback func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_list_item_prepend(IntPtr obj, string label, IntPtr icon, IntPtr end, Evas.SmartCallback func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_list_go(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_list_mode_set(IntPtr obj, Elm_List_Mode listMode);

        [DllImport(Libraries.Elementary)]
        internal static extern Elm_List_Mode elm_list_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_list_item_selected_set(IntPtr obj, bool value);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_list_selected_item_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_list_clear(IntPtr obj);
    }
}
