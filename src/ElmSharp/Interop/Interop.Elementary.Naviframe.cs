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
        internal static extern void elm_naviframe_item_pop_cb_set(IntPtr it, Elm_Naviframe_Item_Pop_Cb func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_naviframe_add(IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_naviframe_event_enabled_set(IntPtr obj, bool enabled);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_naviframe_prev_btn_auto_pushed_set(IntPtr obj, bool value);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_naviframe_prev_btn_auto_pushed_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_naviframe_item_title_enabled_set(IntPtr item, bool enable, bool transition);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_naviframe_item_title_enabled_get(IntPtr item);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_naviframe_item_push(IntPtr obj, string title, IntPtr prev, IntPtr next, IntPtr content, string style);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_naviframe_item_pop(IntPtr obj);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool Elm_Naviframe_Item_Pop_Cb(IntPtr data, IntPtr item);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_naviframe_content_preserve_on_pop_set(IntPtr obj, bool preserve);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_naviframe_content_preserve_on_pop_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_naviframe_item_insert_before(IntPtr naviframe, IntPtr before, string title, IntPtr prev, IntPtr next, IntPtr content, string style);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_naviframe_item_insert_after(IntPtr naviframe, IntPtr after, string title, IntPtr prev, IntPtr next, IntPtr content, string style);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_naviframe_top_item_get(IntPtr naviframe);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_naviframe_bottom_item_get(IntPtr naviframe);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_naviframe_item_pop_to(IntPtr item);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_naviframe_item_style_set(IntPtr item, string style);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_naviframe_item_style_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _elm_naviframe_item_style_get(IntPtr item);

        internal static string elm_naviframe_item_style_get(IntPtr item)
        {
            var text = _elm_naviframe_item_style_get(item);
            return Marshal.PtrToStringAnsi(text);
        }
    }
}