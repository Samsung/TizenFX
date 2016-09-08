// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Elementary
    {
        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_config_accel_preference_set(string preference);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_tree_dump(IntPtr top);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_object_disabled_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_disabled_set(IntPtr obj, bool disabled);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_init(int argc, string[] argv);

        [DllImport(Libraries.Elementary)]
        internal static extern bool ecore_main_loop_glib_integrate();

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_run();

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_exit();

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_shutdown();

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_app_base_scale_set(double base_scale);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_conformant_add(IntPtr obj);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_object_part_text_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _elm_object_part_text_get(IntPtr obj, IntPtr part);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_object_part_text_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _elm_object_part_text_get(IntPtr obj, string part);

        internal static string elm_object_part_text_get(IntPtr obj, string part)
        {
            var text = _elm_object_part_text_get(obj, part);
            return Marshal.PtrToStringAnsi(text);
        }

        internal static string elm_object_part_text_get(IntPtr obj)
        {
            var text = _elm_object_part_text_get(obj, IntPtr.Zero);
            return Marshal.PtrToStringAnsi(text);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_item_part_content_set(IntPtr obj, string part, IntPtr content);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_object_item_part_content_unset(IntPtr obj, string part);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_item_part_content_set(IntPtr obj, IntPtr part, IntPtr content);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_object_part_content_get(IntPtr obj, string part);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_part_content_set(IntPtr obj, string part, IntPtr content);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_part_content_set(IntPtr obj, IntPtr part, IntPtr content);

        internal static void elm_object_content_set(IntPtr obj, IntPtr content)
        {
            elm_object_part_content_set(obj, IntPtr.Zero, content);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_part_content_unset(IntPtr obj, string part);

        internal static void elm_object_content_unset(IntPtr obj)
        {
            elm_object_part_content_unset(obj, null);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_layout_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_layout_content_get(IntPtr obj, string swallow);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_layout_content_set(IntPtr obj, string swallow, IntPtr content);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_layout_content_unset(IntPtr obj, string swallow);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_layout_text_set(IntPtr obj, string part, string text);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_layout_text_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _elm_layout_text_get(IntPtr obj, string part);

        internal static string elm_layout_text_get(IntPtr obj, string part)
        {
            var text = _elm_layout_text_get(obj, part);
            return Marshal.PtrToStringAnsi(text);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_layout_theme_set(IntPtr obj, string klass, string group, string style);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_layout_file_set(IntPtr obj, string file, string group);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_object_style_set(IntPtr obj, string style);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_object_style_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _elm_object_style_get(IntPtr obj);

        internal static string elm_object_style_get(IntPtr obj)
        {
            var text = _elm_object_style_get(obj);
            return Marshal.PtrToStringAnsi(text);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_part_color_set(IntPtr obj, string part, int r, int g, int b, int a);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_part_text_set(IntPtr obj, string part, string text);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_part_text_set(IntPtr obj, IntPtr part, string text);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_object_item_part_text_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _elm_object_item_part_text_get(IntPtr obj, string part);

        internal static string elm_object_item_part_text_get(IntPtr obj, string part)
        {
            var text = _elm_object_item_part_text_get(obj, part);
            return Marshal.PtrToStringAnsi(text);
        }

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
        internal static extern bool elm_object_focus_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_focus_set(IntPtr obj, bool focus);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_theme_extension_add(IntPtr obj, string path);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_theme_new();

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_theme_set(IntPtr obj, IntPtr theme);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_layout_edje_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void edje_object_color_class_del(IntPtr obj, string colorClass);

        [DllImport(Libraries.Elementary)]
        internal static extern bool edje_object_part_exists(IntPtr obj, string part);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr edje_object_part_object_get(IntPtr obj, string part);

        [DllImport(Libraries.Elementary)]
        internal static extern bool edje_object_part_geometry_get(IntPtr obj, string part, out int x, out int y, out int w, out int h);

        [DllImport(Libraries.Elementary)]
        internal static extern bool edje_object_part_text_set(IntPtr obj, string part, string text);

        [DllImport(Libraries.Elementary, EntryPoint = "edje_object_part_text_get", CharSet = CharSet.Ansi)]
        internal static extern IntPtr _edje_object_part_text_get(IntPtr obj, string part);

        internal static string edje_object_part_text_get(IntPtr obj, string part)
        {
            var text = _edje_object_part_text_get(obj, part);
            return Marshal.PtrToStringAnsi(text);
        }

        [DllImport(Libraries.Elementary, EntryPoint = "edje_object_part_text_style_user_peek", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _edje_object_part_text_style_user_peek(IntPtr obj, string part);

        internal static string edje_object_part_text_style_user_peek(IntPtr obj, string part)
        {
            var text = _edje_object_part_text_style_user_peek(obj, part);
            return Marshal.PtrToStringAnsi(text);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void edje_object_part_text_style_user_push(IntPtr obj, string part, string style);

        [DllImport(Libraries.Elementary)]
        internal static extern void edje_object_part_text_style_user_pop(IntPtr obj, string part);

        [DllImport(Libraries.Elementary)]
        internal static extern void edje_object_signal_emit(IntPtr obj, string emission, string source);

        internal static void SetObjectText(IntPtr obj, string text)
        {
            elm_object_part_text_set(obj, IntPtr.Zero, text);
        }
    }
}
