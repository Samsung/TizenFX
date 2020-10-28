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
    internal static partial class Elementary
    {
        internal enum Edje_Message_Type
        {
            EDJE_MESSAGE_NONE = 0,

            // A message with a string as value. Use #Edje_Message_String structs as message body, for this type.
            EDJE_MESSAGE_STRING = 2,

            // A message with an integer number as value. Use #Edje_Message_Int structs as message body, for this type.
            EDJE_MESSAGE_INT = 3,

            // A message with a floating pointer number as value. Use #Edje_Message_Float structs as message body, for this type.
            EDJE_MESSAGE_FLOAT = 4,

            // A message with a list of strings as value. Use #Edje_Message_String_Set structs as message body, for this type.
            EDJE_MESSAGE_STRING_SET = 5,

            // A message with a list of integer numbers as value. Use #Edje_Message_Int_Set structs as message body, for this type.
            EDJE_MESSAGE_INT_SET = 6,

            // A message with a list of floating point numbers as value. Use #Edje_Message_Float_Set structs as message body, for this type.
            EDJE_MESSAGE_FLOAT_SET = 7,

            // A message with a struct containing a string and an integer number as value. Use #Edje_Message_String_Int structs as message body, for this type.
            EDJE_MESSAGE_STRING_INT = 8,

            // A message with a struct containing a string and a floating point number as value. Use #Edje_Message_String_Float structs as message body, for this type.
            EDJE_MESSAGE_STRING_FLOAT = 9,

            // A message with a struct containing a string and list of integer numbers as value. Use #Edje_Message_String_Int_Set structs as message body, for this type.
            EDJE_MESSAGE_STRING_INT_SET = 10,

            // A message with a struct containing a string and list of floating point numbers as value. Use #Edje_Message_String_Float_Set structs as message body, for this type.
            EDJE_MESSAGE_STRING_FLOAT_SET = 11
        }
        internal enum Elm_Focus_Autoscroll_Mode
        {
            ELM_FOCUS_AUTOSCROLL_MODE_SHOW,
            ELM_FOCUS_AUTOSCROLL_MODE_NONE,
            ELM_FOCUS_AUTOSCROLL_MODE_BRING_IN
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_config_scroll_bring_in_scroll_friction_set(double time);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_config_scroll_bring_in_scroll_friction_get();

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_config_focus_autoscroll_mode_set(Elm_Focus_Autoscroll_Mode mode);

        [DllImport(Libraries.Elementary)]
        internal static extern Elm_Focus_Autoscroll_Mode elm_config_focus_autoscroll_mode_get();

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_config_accel_preference_set(string preference);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_config_scale_set(double scale);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_config_scale_get();

        [DllImport(Libraries.Elementary, EntryPoint = "elm_config_profile_get")]
        internal static extern IntPtr _elm_config_profile_get();

        internal static string elm_config_profile_get()
        {
            return Marshal.PtrToStringAnsi(_elm_config_profile_get());
        }

        internal static void elm_object_focused_clear(IntPtr handle)
        {
            if (elm_widget_is(handle))
            {
                efl_ui_widget_focused_object_clear(handle);
            }
            else
            {
                Evas.evas_object_focus_set(handle, false);
            }

            IntPtr win = elm_widget_top_get(handle);
            if (win != IntPtr.Zero && Eo.efl_class_name_get(Eo.efl_class_get(win)) == "Efl.Ui.Win")
            {
                Evas.evas_object_focus_set(win, true);
            }
        }

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_widget_top_get(IntPtr handle);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_widget_is(IntPtr handle);

        [DllImport(Libraries.Elementary)]
        internal static extern void efl_ui_widget_focused_object_clear(IntPtr handle);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_config_preferred_engine_set(string name);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_config_longpress_timeout_get();

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_config_reload();

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_config_all_flush();

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_config_finger_size_set(int size);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_config_finger_size_get();

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_config_mirrored_get();

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_config_mirrored_set(bool mirrored);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_object_mirrored_automatic_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_mirrored_automatic_set(IntPtr obj, bool automatic);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_object_mirrored_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_mirrored_set(IntPtr obj, bool mirrored);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_grid_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_grid_pack(IntPtr obj, IntPtr subObj, int x, int y, int w, int h);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_grid_pack_get(IntPtr subObj, out int x, out int y, out int w, out int h);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_grid_pack_set(IntPtr subObj, int x, int y, int w, int h);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_grid_size_set(IntPtr obj, int w, int h);

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
        internal static extern double elm_app_base_scale_get();

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_conformant_add(IntPtr obj);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_object_part_text_get")]
        internal static extern IntPtr _elm_object_part_text_get(IntPtr obj, IntPtr part);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_object_part_text_get")]
        internal static extern IntPtr _elm_object_part_text_get(IntPtr obj, string part);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_tooltip_text_set(IntPtr obj, string text);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_tooltip_unset(IntPtr obj);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_object_tooltip_style_get")]
        internal static extern IntPtr _elm_object_tooltip_style_get(IntPtr obj);

        internal static string elm_object_tooltip_style_get(IntPtr obj)
        {
            return Marshal.PtrToStringAnsi(_elm_object_tooltip_style_get(obj));
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_tooltip_style_set(IntPtr obj, string style);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_object_tooltip_window_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_object_tooltip_window_mode_set(IntPtr obj, bool disable);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_tooltip_move_freeze_push(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_tooltip_move_freeze_pop(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_object_tooltip_move_freeze_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_tooltip_show(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_tooltip_hide(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_tooltip_orient_set(IntPtr obj, int orient);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_object_tooltip_orient_get(IntPtr obj);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr Elm_Tooltip_Content_Cb(IntPtr data, IntPtr obj, IntPtr tooltip);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_tooltip_content_cb_set(IntPtr obj, Elm_Tooltip_Content_Cb func, IntPtr data, Interop.Evas.SmartCallback del);

        internal static string elm_object_part_text_get(IntPtr obj, string part)
        {
            return Marshal.PtrToStringAnsi(_elm_object_part_text_get(obj, part));
        }

        internal static string elm_object_part_text_get(IntPtr obj)
        {
            return Marshal.PtrToStringAnsi(_elm_object_part_text_get(obj, IntPtr.Zero));
        }

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
        internal static extern IntPtr elm_object_part_content_unset(IntPtr obj, string part);

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

        [DllImport(Libraries.Elementary, EntryPoint = "elm_layout_text_get")]
        internal static extern IntPtr _elm_layout_text_get(IntPtr obj, string part);

        internal static string elm_layout_text_get(IntPtr obj, string part)
        {
            return Marshal.PtrToStringAnsi(_elm_layout_text_get(obj, part));
        }

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_layout_theme_set(IntPtr obj, string klass, string group, string style);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_layout_file_get(IntPtr obj, IntPtr file, IntPtr group);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_layout_file_set(IntPtr obj, string file, string group);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_layout_signal_emit(IntPtr obj, string emission, string source);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_layout_signal_callback_add(IntPtr obj, string emission, string source, Edje_Signal_Cb func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_layout_signal_callback_del(IntPtr obj, string emission, string source, Edje_Signal_Cb func);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void Edje_Signal_Cb(IntPtr data, IntPtr obj, string emission, string source);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_layout_box_append(IntPtr obj, string part, IntPtr child);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_layout_box_prepend(IntPtr obj, string part, IntPtr child);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_layout_box_remove(IntPtr obj, string part, IntPtr child);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_layout_box_remove_all(IntPtr obj, string part, bool clear);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_layout_data_get")]
        internal static extern IntPtr _elm_layout_data_get(IntPtr obj, string key);

        internal static string elm_layout_data_get(IntPtr obj, string key)
        {
            return Marshal.PtrToStringAnsi(_elm_layout_data_get(obj, key));
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_layout_text_valign_set(IntPtr obj, string part, double valign);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_layout_text_valign_get(IntPtr obj, string part);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_notify_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_notify_align_set(IntPtr obj, double horizontal, double vertical);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_notify_timeout_set(IntPtr obj, double timeout);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_object_scale_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_scale_set(IntPtr obj, double scale);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_signal_emit(IntPtr obj, string emission, string source);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_object_signal_callback_del(IntPtr obj, string emission, string source, Edje_Signal_Cb func);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_signal_callback_add(IntPtr obj, string emission, string source, Edje_Signal_Cb func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_object_style_set(IntPtr obj, string style);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_object_style_get")]
        internal static extern IntPtr _elm_object_style_get(IntPtr obj);

        internal static string elm_object_style_get(IntPtr obj)
        {
            return Marshal.PtrToStringAnsi(_elm_object_style_get(obj));
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_color_class_color_get(IntPtr obj, string colorClass, out int r, out int g, out int b, out int a);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_color_class_color_set(IntPtr obj, string colorClass, int r, int g, int b, int a);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_color_class_del(IntPtr obj, string colorClass);
        
        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_part_text_set(IntPtr obj, string part, string text);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_part_text_set(IntPtr obj, IntPtr part, string text);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_config_focus_highlight_animate_set(bool animate);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_config_focus_highlight_animate_get();

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_config_focus_highlight_enabled_set(bool enable);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_config_focus_highlight_enabled_get();

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_tree_focus_allow_set(IntPtr obj, bool focusable);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_object_tree_focus_allow_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_object_focus_next_object_get(IntPtr obj, int dir);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_object_focused_object_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_object_focus_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_focus_set(IntPtr obj, bool focus);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_object_focus_allow_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_focus_allow_set(IntPtr obj, bool enable);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_focus_next(IntPtr obj, int direction);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_focus_next_object_set(IntPtr obj, IntPtr next, int direction);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_focus_next_item_set(IntPtr obj, IntPtr nextItem, int direction);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_theme_extension_add(IntPtr theme, string path);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_theme_overlay_add(IntPtr theme, string path);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_language_set(string lang);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_policy_set(uint policy, int value);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_theme_new();

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_theme_free(IntPtr theme);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_theme_ref_set(IntPtr theme, IntPtr themeRef);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_theme_extension_del(IntPtr theme, string item);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_theme_overlay_del(IntPtr theme, string item);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_theme_set(IntPtr obj, string theme);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_theme_flush(IntPtr theme);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_theme_full_flush();

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_theme_set(IntPtr obj, IntPtr theme);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_layout_edje_get(IntPtr obj);

        internal static void SetObjectText(IntPtr obj, string text)
        {
            elm_object_part_text_set(obj, IntPtr.Zero, text);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_cache_all_flush();

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_object_domain_translatable_part_text_set(IntPtr obj, string part, string domain, string text);

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

        [DllImport(Libraries.Elementary)]
        internal static extern void edje_object_mirrored_set(IntPtr obj, bool rtl);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr edje_object_add(IntPtr evas);

        [DllImport(Libraries.Elementary)]
        internal static extern bool edje_object_file_set(IntPtr obj, string file, string group);

        [DllImport(Libraries.Elementary)]
        internal static extern bool edje_object_part_box_append(IntPtr obj, string part, IntPtr child);

        [DllImport(Libraries.Elementary)]
        internal static extern bool edje_object_part_box_prepend(IntPtr obj, string part, IntPtr child);

        [DllImport(Libraries.Elementary, EntryPoint = "edje_object_part_state_get")]
        internal static extern IntPtr _edje_object_part_state_get(IntPtr obj, string part, out double value);

        internal static string edje_object_part_state_get(IntPtr obj, string part, out double value)
        {
            return Marshal.PtrToStringAnsi(_edje_object_part_state_get(obj, part, out value));
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void edje_object_signal_callback_add(IntPtr obj, string emission, string source, Edje_Signal_Cb func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr edje_object_signal_callback_del(IntPtr obj, string emission, string source, Edje_Signal_Cb func);

        [DllImport(Libraries.Elementary)]
        internal static extern void edje_object_signal_callback_del_full(IntPtr obj, string emission, string source, Edje_Signal_Cb func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern bool edje_color_class_set(string colorClass, int r, int g, int b, int a, int r2, int g2, int b2, int a2, int r3, int g3, int b3, int a3);

        [DllImport(Libraries.Elementary)]
        internal static extern bool edje_color_class_get(string colorClass, out int r, out int g, out int b, out int a, out int r2, out int g2, out int b2, out int a2,
            out int r3, out int g3, out int b3, out int a3);

        [DllImport(Libraries.Elementary)]
        internal static extern bool edje_object_color_class_set(IntPtr obj, string colorClass, int r, int g, int b, int a, int r2, int g2, int b2, int a2, int r3, int g3, int b3, int a3);

        [DllImport(Libraries.Elementary)]
        internal static extern bool edje_object_color_class_get(IntPtr obj, string colorClass, out int r, out int g, out int b, out int a, out int r2, out int g2, out int b2, out int a2,
            out int r3, out int g3, out int b3, out int a3);

        [DllImport(Libraries.Elementary)]
        internal static extern void edje_message_signal_process();

        [DllImport(Libraries.Elementary)]
        internal static extern void edje_object_message_handler_set(IntPtr obj, Edje_Message_Handler_Cb func, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void Edje_Message_Handler_Cb(IntPtr data, IntPtr obj, Edje_Message_Type type, int id, IntPtr msg);

        [DllImport(Libraries.Elementary)]
        internal static extern void edje_object_message_send(IntPtr obj, Edje_Message_Type type, int id, IntPtr msg);

        [DllImport(Libraries.Elementary)]
        internal static extern void edje_object_message_signal_process(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool edje_object_text_class_set(IntPtr obj, string textClass, string font, int size);

        [DllImport(Libraries.Elementary, EntryPoint = "edje_object_text_class_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern bool _edje_object_text_class_get(IntPtr obj, string textClass, out IntPtr font, out int size);
        internal static bool edje_object_text_class_get(IntPtr obj, string textClass, out string font, out int size)
        {
            IntPtr _font;
            var ret = _edje_object_text_class_get(obj, textClass, out _font, out size);
            font = Marshal.PtrToStringAnsi(_font);
            return ret;
        }

        [DllImport(Libraries.Elementary)]
        internal static extern bool edje_text_class_set(string textClass, string font, int size);

        [DllImport(Libraries.Elementary, EntryPoint = "edje_text_class_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern bool _edje_text_class_get(string textClass, out IntPtr font, out int size);
        internal static bool edje_text_class_get(string textClass, out string font, out int size)
        {
            IntPtr _font;
            var ret = _edje_text_class_get(textClass, out _font, out size);
            font = Marshal.PtrToStringAnsi(_font);
            return ret;
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void edje_text_class_del(string textClass);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_transit_add();

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_transit_del(IntPtr transit);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_transit_object_add(IntPtr transit, IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_transit_effect_translation_add(IntPtr transit, int fromDx, int fromDy, int toDx, int toDy);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_transit_objects_final_state_keep_set(IntPtr transit, bool stateKeep);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_transit_tween_mode_set(IntPtr transit, int tweenMode);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_transit_repeat_times_set(IntPtr transit, int repeat);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_transit_duration_set(IntPtr transit, double duration);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_transit_go(IntPtr transit);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_transit_effect_zoom_add(IntPtr transit, float fromRate, float toRate);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_transit_effect_color_add(IntPtr transit, int fromR, int fromG, int fromB, int fromA, int toR, int toG, int toB, int toA);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_transit_auto_reverse_set(IntPtr transit, bool reverse);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_transit_effect_add(IntPtr transit, Elm_Transit_Effect_Transition_Cb transitionCb, IntPtr effect, Elm_Transit_Effect_End_Cb endCb);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_transit_effect_fade_add(IntPtr transit);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_transit_effect_resizing_add(IntPtr transit, int fromW, int fromH, int toW, int toH);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_transit_event_enabled_set(IntPtr transit, bool enabled);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_transit_smooth_set(IntPtr transit, bool enabled);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_transit_effect_del(IntPtr transit, Elm_Transit_Effect_Transition_Cb transitionCb, IntPtr effect);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_transit_object_remove(IntPtr transit, IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_transit_objects_final_state_keep_get(IntPtr transit);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_transit_event_enabled_get(IntPtr transit);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_transit_del_cb_set(IntPtr transit, Elm_Transit_Del_Cb cb, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_transit_auto_reverse_get(IntPtr transit);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_transit_repeat_times_get(IntPtr transit);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_transit_tween_mode_get(IntPtr transit);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_transit_tween_mode_factor_set(IntPtr transit, double v1, double v2);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_transit_tween_mode_factor_get(IntPtr transit, out double v1, out double v2);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_transit_tween_mode_factor_n_set(IntPtr transit, int vSize, out double v);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_transit_duration_get(IntPtr transit);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_transit_go_in(IntPtr transit, double interval);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_transit_paused_set(IntPtr transit, bool paused);

        [DllImport(Libraries.Elementary)]
        [return : MarshalAs(UnmanagedType.U1)]
        internal static extern bool elm_transit_paused_get(IntPtr transit);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_transit_progress_value_get(IntPtr transit);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_transit_chain_transit_add(IntPtr transit, IntPtr chainTransit);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_transit_chain_transit_del(IntPtr transit, IntPtr chainTransit);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_transit_chain_transits_get(IntPtr transit);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_transit_smooth_get(IntPtr transit);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_transit_effect_flip_add(IntPtr transit, int axis, bool cw);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_transit_effect_resizable_flip_add(IntPtr transit, int axis, bool cw);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_transit_effect_wipe_add(IntPtr transit, int type, int dir);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_transit_effect_blend_add(IntPtr transit);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_transit_effect_rotation_add(IntPtr transit, float fromDegree, float toDegree);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_transit_effect_image_animation_add(IntPtr transit, IntPtr images);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int Eina_Compare_Cb(IntPtr data1, IntPtr data2);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void Elm_Transit_Effect_Transition_Cb(IntPtr effect, IntPtr transit, double progress);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void Elm_Transit_Effect_End_Cb(IntPtr effect, IntPtr transit);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void Elm_Transit_Del_Cb(IntPtr data, IntPtr transit);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_layout_box_insert_at(IntPtr obj, string part, IntPtr child, uint pos);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_layout_box_insert_before(IntPtr obj, string part, IntPtr child, IntPtr reference);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_layout_edje_object_can_access_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_layout_edje_object_can_access_set(IntPtr obj, bool canAccess);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_layout_freeze(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_layout_part_cursor_engine_only_get(IntPtr obj, string part);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_layout_part_cursor_engine_only_set(IntPtr obj, string part, bool engineOnly);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_layout_part_cursor_get")]
        internal static extern IntPtr _elm_layout_part_cursor_get(IntPtr obj, string part);

        internal static string elm_layout_part_cursor_get(IntPtr obj, string part)
        {
            return Marshal.PtrToStringAnsi(_elm_layout_part_cursor_get(obj, part));
        }

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_layout_part_cursor_set(IntPtr obj, string part, string cursor);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_layout_part_cursor_style_get")]
        internal static extern IntPtr _elm_layout_part_cursor_style_get(IntPtr obj, string part);

        internal static string elm_layout_part_cursor_style_get(IntPtr obj, string part)
        {
            return Marshal.PtrToStringAnsi(_elm_layout_part_cursor_style_get(obj, part));
        }

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_layout_part_cursor_style_set(IntPtr obj, string part, string style);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_layout_part_cursor_unset(IntPtr obj, string part);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_layout_sizing_eval(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_layout_sizing_restricted_eval(IntPtr obj, bool width, bool height);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_layout_thaw(IntPtr obj);
    }
}
