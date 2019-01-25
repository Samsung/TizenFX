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
        /// <summary>
        /// Types of "Enter" keys available for different keyboard layouts.
        /// </summary>
        public enum ReturnKeyType
        {
            Default,
            Done,
            Go,
            Join,
            Login,
            Next,
            Search,
            Send,
            Signin
        }

        public enum InputPanelLayout
        {
            Normal,
            Number,
            Email,
            Url,
            PhoneNumber,
            Ip,
            Month,
            NumberOnly,
            Invalid,
            Hex,
            Terminal,
            Password,
            DateTime,
            Emoticon
        }

        internal enum WrapType
        {
            None,
            Char,
            Word,
            Mixed,
        }

        internal enum AutocapitalType
        {
            None,
            Word,
            Sentence,
            AllCharacter,
        }

        internal enum InputHints
        {
            None,
            AutoComplete,
            SensitiveData,
        }

        internal enum InputPanelLanguage
        {
            Automatic,
            Alphabet,
        }

        internal enum CopyAndPasteMode
        {
            Markup,
            NoImage,
            PlainText
        }

        internal enum TextFormat
        {
            PlainUtf8,
            MarkupUtf8
        }

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_entry_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_entry_editable_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_editable_set(IntPtr obj, bool value);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_entry_single_line_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_single_line_set(IntPtr obj, bool value);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_entry_entry_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _elm_entry_entry_get(IntPtr obj);

        internal static string elm_entry_entry_get(IntPtr obj)
        {
            var text = _elm_entry_entry_get(obj);
            return Marshal.PtrToStringAnsi(text);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_entry_set(IntPtr obj, string value);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_entry_append(IntPtr obj, string value);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_entry_insert(IntPtr obj, string value);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_entry_file_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern void _elm_entry_file_get(IntPtr obj, out IntPtr file, out TextFormat format);
        internal static void elm_entry_file_get(IntPtr obj, out string file, out TextFormat format)
        {
            IntPtr _file;
            _elm_entry_file_get(obj, out _file, out format);
            file = Marshal.PtrToStringAnsi(_file);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_file_set(IntPtr obj, string file, TextFormat format);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_file_save(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_entry_password_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_password_set(IntPtr obj, bool value);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_entry_is_empty(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_entry_cursor_next(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_entry_cursor_prev(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_entry_cursor_up(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_entry_cursor_down(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_cursor_begin_set(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_cursor_end_set(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern string elm_entry_cursor_content_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_cursor_line_begin_set(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_cursor_line_end_set(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_entry_cursor_pos_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_cursor_pos_set(IntPtr obj, int pos);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_entry_cursor_geometry_get(IntPtr obj, out int x, out int y, out int w, out int h);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_entry_cursor_is_format_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_entry_cursor_is_visible_format_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_cursor_selection_begin(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_cursor_selection_end(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern string elm_entry_markup_to_utf8(IntPtr text);

        [DllImport(Libraries.Elementary)]
        internal static extern string elm_entry_markup_to_utf8(string text);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_input_panel_show(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_input_panel_enabled_set(IntPtr obj, bool enabled);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_entry_input_panel_enabled_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_input_panel_return_key_type_set(IntPtr obj, ReturnKeyType keyType);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_input_panel_layout_set(IntPtr obj, InputPanelLayout layout);

        [DllImport(Libraries.Elementary)]
        internal static extern InputPanelLayout elm_entry_input_panel_layout_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_select_all(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_select_none(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_text_style_user_pop(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_text_style_user_push(IntPtr obj, string style);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_entry_text_style_user_peek", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _elm_entry_text_style_user_peek(IntPtr obj);

        internal static string elm_entry_text_style_user_peek(IntPtr obj)
        {
            var text = _elm_entry_text_style_user_peek(obj);
            return Marshal.PtrToStringAnsi(text);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_entry_scrollable_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_scrollable_set(IntPtr obj, bool scroll);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_input_panel_hide(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_input_panel_imdata_set(IntPtr obj, IntPtr data, int len);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_entry_input_panel_layout_variation_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_input_panel_layout_variation_set(IntPtr obj, int variation);

        [DllImport(Libraries.Elementary)]
        internal static extern WrapType elm_entry_line_wrap_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_line_wrap_set(IntPtr obj, WrapType wrap);

        [DllImport(Libraries.Elementary)]
        internal static extern AutocapitalType elm_entry_autocapital_type_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_autocapital_type_set(IntPtr obj, AutocapitalType autoCapitalType);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_entry_autosave_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_autosave_set(IntPtr obj, bool autosave);

        [DllImport(Libraries.Elementary)]
        internal static extern CopyAndPasteMode elm_entry_cnp_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_cnp_mode_set(IntPtr obj, CopyAndPasteMode mode);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_calc_force(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_entry_imf_context_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern InputHints elm_entry_input_hint_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_input_hint_set(IntPtr obj, InputHints hints);

        [DllImport(Libraries.Elementary)]
        internal static extern InputPanelLanguage elm_entry_input_panel_language_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_input_panel_language_set(IntPtr obj, InputPanelLanguage lang);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_entry_input_panel_return_key_disabled_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_input_panel_return_key_disabled_set(IntPtr obj, bool disabled);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_input_panel_return_key_autoenabled_set(IntPtr obj, bool enabled);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_entry_input_panel_show_on_demand_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_input_panel_show_on_demand_set(IntPtr obj, bool onDemand);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_markup_filter_append(IntPtr obj, Elm_Entry_Filter_Cb func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_markup_filter_prepend(IntPtr obj, Elm_Entry_Filter_Cb func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_markup_filter_remove(IntPtr obj, Elm_Entry_Filter_Cb func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_entry_prediction_allow_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_prediction_allow_set(IntPtr obj, bool prediction);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_select_allow_set(IntPtr obj, bool allow);

        [DllImport(Libraries.Elementary)]
        internal static extern string elm_entry_utf8_to_markup(string str);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void Elm_Entry_Filter_Cb(IntPtr data, IntPtr obj, ref IntPtr text);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_entry_anchor_hover_parent_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_anchor_hover_parent_set(IntPtr obj, IntPtr parent);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_anchor_hover_end(IntPtr obj);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_entry_anchor_hover_style_get")]
        internal static extern IntPtr _elm_entry_anchor_hover_style_get(IntPtr obj);

        internal static string elm_entry_anchor_hover_style_get(IntPtr obj)
        {
            return Marshal.PtrToStringAnsi(_elm_entry_anchor_hover_style_get(obj));
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_anchor_hover_style_set(IntPtr obj, string style);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_icon_visible_set(IntPtr obj, bool setting);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr Elm_Entry_Item_Provider_Cb(IntPtr data, IntPtr entry, string text);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_item_provider_append(IntPtr obj, Elm_Entry_Item_Provider_Cb func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_item_provider_prepend(IntPtr obj, Elm_Entry_Item_Provider_Cb func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_item_provider_remove(IntPtr obj, Elm_Entry_Item_Provider_Cb func, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_selection_copy(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_selection_cut(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_selection_paste(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_selection_handler_disabled_set(IntPtr obj, bool disabled);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_entry_selection_get")]
        internal static extern IntPtr _elm_entry_selection_get(IntPtr obj);

        internal static string elm_entry_selection_get(IntPtr obj)
        {
            return Marshal.PtrToStringAnsi(_elm_entry_selection_get(obj));
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_select_region_set(IntPtr obj, int start, int end);
    }
}