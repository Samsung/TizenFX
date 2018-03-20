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
        internal static extern void elm_object_item_part_content_set(IntPtr obj, string part, IntPtr content);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_object_item_part_content_unset(IntPtr obj, string part);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_item_part_content_set(IntPtr obj, IntPtr part, IntPtr content);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_object_item_part_text_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _elm_object_item_part_text_get(IntPtr obj, string part);

        internal static string elm_object_item_part_text_get(IntPtr obj, string part)
        {
            var text = _elm_object_item_part_text_get(obj, part);
            return Marshal.PtrToStringAnsi(text);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_item_color_class_color_set(IntPtr it, string part, int r, int g, int b, int a);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_item_color_class_color_get(IntPtr obj, string part, out int r, out int g, out int b, out int a);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_item_color_class_del(IntPtr obj, string part);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_item_part_text_set(IntPtr obj, string part, string label);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_item_part_text_set(IntPtr obj, IntPtr part, string label);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_object_item_data_get(IntPtr it);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_item_data_set(IntPtr it, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_item_del(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_item_del_cb_set(IntPtr obj, Interop.Evas.SmartCallback callback);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_item_disabled_set(IntPtr obj, bool disable);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_object_item_disabled_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_object_item_part_content_get(IntPtr obj, string part);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_object_item_access_object_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_item_access_unregister(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_object_item_track(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_object_item_track_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_item_untrack(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_object_item_widget_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_item_signal_emit(IntPtr obj, string emission, string source);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_item_signal_callback_add(IntPtr obj, string emission, string source, Elm_Object_Item_Signal_Cb func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_object_item_signal_callback_del(IntPtr obj, string emission, string source, Elm_Object_Item_Signal_Cb func);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_item_style_set(IntPtr obj, string style);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_object_item_style_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _elm_object_item_style_get(IntPtr obj);

        internal static string elm_object_item_style_get(IntPtr obj)
        {
            var text = _elm_object_item_style_get(obj);
            return Marshal.PtrToStringAnsi(text);
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool Elm_Object_Item_Signal_Cb(IntPtr data, IntPtr item, string emission, string source);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr Elm_Tooltip_Item_Content_Cb(IntPtr data, IntPtr obj, IntPtr tooltip, IntPtr item);

        internal enum Elm_Object_Select_Mode
        {
            ELM_OBJECT_SELECT_MODE_DEFAULT,
            ELM_OBJECT_SELECT_MODE_ALWAYS,
            ELM_OBJECT_SELECT_MODE_NONE,
            ELM_OBJECT_SELECT_MODE_DISPLAY_ONLY
        }
    }
}