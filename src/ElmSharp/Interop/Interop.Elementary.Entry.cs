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
        /// <summary>
        /// Types of "Enter" keys available for different keyboards layout
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
        internal static extern void elm_entry_cursor_line_begin_set(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_cursor_line_end_set(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_entry_cursor_pos_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_cursor_pos_set(IntPtr obj, int pos);

        [DllImport(Libraries.Elementary)]
        internal static extern string elm_entry_markup_to_utf8(IntPtr text);

        [DllImport(Libraries.Elementary)]
        internal static extern string elm_entry_markup_to_utf8(string text);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_input_panel_show(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_input_panel_enabled_set(IntPtr obj, bool enabled);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_input_panel_return_key_type_set(IntPtr obj, ReturnKeyType keyType);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_input_panel_layout_set(IntPtr obj, InputPanelLayout layout);

        [DllImport(Libraries.Elementary)]
        internal static extern InputPanelLayout elm_entry_input_panel_layout_get(IntPtr obj);


        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_text_style_user_pop(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_text_style_user_push(IntPtr obj, string style);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_entry_text_style_user_peek", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _elm_entry_text_style_user_peek(IntPtr obj);

        internal static string elm_entry_text_style_user_peek(IntPtr obj)
        {
            var text = _elm_entry_entry_get(obj);
            return Marshal.PtrToStringAnsi(text);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_entry_scrollable_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_entry_scrollable_set(IntPtr obj, bool scroll);
    }
}

