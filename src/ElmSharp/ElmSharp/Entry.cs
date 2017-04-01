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

namespace ElmSharp
{
    /// <summary>
    /// Enumeration for describing InputPanel layout type.
    /// </summary>
    public enum InputPanelLayout
    {
        /// <summary>
        /// InputPanel layout type default.
        /// </summary>
        Normal,

        /// <summary>
        /// InputPanel layout type number.
        /// </summary>
        Number,

        /// <summary>
        /// InputPanel layout type email.
        /// </summary>
        Email,

        /// <summary>
        /// InputPanel layout type url.
        /// </summary>
        Url,

        /// <summary>
        /// InputPanel layout type phone.
        /// </summary>
        PhoneNumber,

        /// <summary>
        /// InputPanel layout type ip.
        /// </summary>
        Ip,

        /// <summary>
        /// InputPanel layout type month.
        /// </summary>
        Month,

        /// <summary>
        /// InputPanel layout type number.
        /// </summary>
        NumberOnly,

        /// <summary>
        /// InputPanel layout type error type. Do not use it directly!
        /// </summary>
        Invalid,

        /// <summary>
        /// InputPanel layout type hexadecimal.
        /// </summary>
        Hex,

        /// <summary>
        /// InputPanel layout type terminal type, esc, alt, ctrl, etc.
        /// </summary>
        Terminal,

        /// <summary>
        /// InputPanel layout type password.
        /// </summary>
        Password,

        /// <summary>
        /// Keyboard layout type date and time.
        /// </summary>
        DateTime,

        /// <summary>
        /// InputPanel layout type emoticons.
        /// </summary>
        Emoticon
    }

    /// <summary>
    /// Enumeration that defines the "Return" key types on the input panel (virtual keyboard).
    /// </summary>
    public enum InputPanelReturnKeyType
    {
        /// <summary>
        /// Default key type
        /// </summary>
        Default,
        /// <summary>
        /// Done key type
        /// </summary>
        Done,
        /// <summary>
        /// Go key type
        /// </summary>
        Go,
        /// <summary>
        /// Join key type
        /// </summary>
        Join,
        /// <summary>
        /// Login key type
        /// </summary>
        Login,
        /// <summary>
        /// Next key type
        /// </summary>
        Next,
        /// <summary>
        /// Search string or magnifier icon key type
        /// </summary>
        Search,
        /// <summary>
        /// Send key type
        /// </summary>
        Send,
        /// <summary>
        /// Sign-in key type
        /// </summary>
        Signin
    }

    /// <summary>
    /// The entry is a convenience widget that shows a box in which the user can enter text.
    /// </summary>
    public class Entry : Layout
    {
        SmartEvent _clicked;
        SmartEvent _changedByUser;
        SmartEvent _cursorChanged;
        SmartEvent _activated;

        /// <summary>
        /// Creates and initializes a new instance of the Entry class.
        /// </summary>
        /// <param name="parent">The EvasObject to which the new Entry will be attached as a child.</param>
        public Entry(EvasObject parent) : base(parent)
        {
            _clicked = new SmartEvent(this, this.RealHandle, "clicked");
            _clicked.On += (s, e) => Clicked?.Invoke(this, EventArgs.Empty);

            _changedByUser = new SmartEvent(this, this.RealHandle, "changed,user");
            _changedByUser.On += (s, e) => ChangedByUser?.Invoke(this, EventArgs.Empty);

            _cursorChanged = new SmartEvent(this, this.RealHandle, "cursor,changed");
            _cursorChanged.On += (s, e) => CursorChanged?.Invoke(this, EventArgs.Empty);

            _activated = new SmartEvent(this, this.RealHandle, "activated");
            _activated.On += (s, e) => Activated?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Activated will be triggered when the entry in Activated stated.
        /// </summary>
        public event EventHandler Activated;

        /// <summary>
        /// Clicked will be triggered when the entry is clicked.
        /// </summary>
        public event EventHandler Clicked;

        /// <summary>
        /// ChangedByUser will be triggered when the entry changed by user.
        /// </summary>
        public event EventHandler ChangedByUser;

        /// <summary>
        /// CursorChanged will be triggered when the Cursor in the entry is changed.
        /// </summary>
        public event EventHandler CursorChanged;

        /// <summary>
        /// Sets or gets the entry to the single line mode.
        /// </summary>
        public bool IsSingleLine
        {
            get
            {
                return Interop.Elementary.elm_entry_single_line_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_single_line_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the entry to the password mode.
        /// </summary>
        public bool IsPassword
        {
            get
            {
                return Interop.Elementary.elm_entry_password_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_password_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets whether the entry is editable.
        /// </summary>
        public bool IsEditable
        {
            get
            {
                return Interop.Elementary.elm_entry_editable_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_editable_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets whether the entry is empty.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return Interop.Elementary.elm_entry_is_empty(RealHandle);
            }
        }
        /// <summary>
        /// Sets or gets text currently shown in the object entry.
        /// </summary>
        public override string Text
        {
            get
            {
                return Interop.Elementary.elm_entry_entry_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_entry_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the style on the top of the user style stack.
        /// </summary>
        /// <remarks>If there is styles in the user style stack, the properties in the top style of user style stack will replace the properties in current theme. The input style is specified in format tag='property=value' (i.e. DEFAULT='font=Sans font_size=60'hilight=' + font_weight=Bold').</remarks>
        public string TextStyle
        {
            get
            {
                return Interop.Elementary.elm_entry_text_style_user_peek(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_text_style_user_push(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the current position of the cursor in the entry.
        /// </summary>
        public int CursorPosition
        {
            get
            {
                return Interop.Elementary.elm_entry_cursor_pos_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_cursor_pos_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the scrollable state of the entry.
        /// </summary>
        public bool Scrollable
        {
            get
            {
                return Interop.Elementary.elm_entry_scrollable_get(RealHandle);
            }
            set
            {
                // HACK: Enabling the scrollable property of an entry causes its internal
                //       hierarchy to change, making the internal edje object inaccessible.
                //       Access it before the property is set, to cache the edje object's handle.
                if (value)
                {
                    var dummy = EdjeObject;
                }
                Interop.Elementary.elm_entry_scrollable_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Converts a markup (HTML-like) string into UTF-8.
        /// </summary>
        /// <param name="markup">The string (in markup) to be converted</param>
        /// <returns>The converted string (in UTF-8) </returns>
        public static string ConvertMarkupToUtf8(string markup)
        {
            return Interop.Elementary.elm_entry_markup_to_utf8(markup);
        }

        /// <summary>
        /// Moves the cursor by one position to the right within the entry.
        /// </summary>
        /// <returns></returns>
        public bool MoveCursorNext()
        {
            return Interop.Elementary.elm_entry_cursor_next(RealHandle);
        }

        /// <summary>
        /// Moves the cursor one place to the left within the entry.
        /// </summary>
        /// <returns>TRUE on success, otherwise FALSE on failure</returns>
        public bool MoveCursorPrev()
        {
            return Interop.Elementary.elm_entry_cursor_prev(RealHandle);
        }

        /// <summary>
        /// Moves the cursor one line up within the entry.
        /// </summary>
        /// <returns>TRUE on success, otherwise FALSE on failure</returns>
        public bool MoveCursorUp()
        {
            return Interop.Elementary.elm_entry_cursor_up(RealHandle);
        }

        /// <summary>
        /// Moves the cursor one line down within the entry.
        /// </summary>
        /// <returns>TRUE on success, otherwise FALSE on failure</returns>
        public bool MoveCursorDown()
        {
            return Interop.Elementary.elm_entry_cursor_down(RealHandle);
        }

        /// <summary>
        /// Moves the cursor to the beginning of the entry.
        /// </summary>
        public void MoveCursorBegin()
        {
            Interop.Elementary.elm_entry_cursor_begin_set(RealHandle);
        }

        /// <summary>
        /// Moves the cursor to the end of the entry.
        /// </summary>
        public void MoveCursorEnd()
        {
            Interop.Elementary.elm_entry_cursor_end_set(RealHandle);
        }

        /// <summary>
        /// Moves the cursor to the beginning of the current line.
        /// </summary>
        public void MoveCursorLineBegin()
        {
            Interop.Elementary.elm_entry_cursor_line_begin_set(RealHandle);
        }

        /// <summary>
        /// Moves the cursor to the end of the current line.
        /// </summary>
        public void MoveCursorLineEnd()
        {
            Interop.Elementary.elm_entry_cursor_line_end_set(RealHandle);
        }

        /// <summary>
        /// Sets the input panel layout of the entry.
        /// </summary>
        /// <param name="layout">The layout type</param>
        public void SetInputPanelLayout(InputPanelLayout layout)
        {
            Interop.Elementary.elm_entry_input_panel_layout_set(RealHandle, (Interop.Elementary.InputPanelLayout)layout);
        }

        /// <summary>
        /// Sets the attribute to show the input panel automatically.
        /// </summary>
        /// <param name="enabled">If true the input panel appears when the entry is clicked or has focus, otherwise false</param>
        public void SetInputPanelEnabled(bool enabled)
        {
            Interop.Elementary.elm_entry_input_panel_enabled_set(RealHandle, enabled);
        }

        /// <summary>
        /// Sets the "return" key type. This type is used to set the string or icon on the "return" key of the input panel.
        /// </summary>
        /// <param name="keyType">The type of "return" key on the input panel</param>
        public void SetInputPanelReturnKeyType(InputPanelReturnKeyType keyType)
        {
            Interop.Elementary.elm_entry_input_panel_return_key_type_set(RealHandle, (Interop.Elementary.ReturnKeyType)keyType);
        }

        /// <summary>
        /// Selects all the text within the entry.
        /// </summary>
        public void SelectAll()
        {
            Interop.Elementary.elm_entry_select_all(RealHandle);
        }

        /// <summary>
        /// Drops any existing text selection within the entry.
        /// </summary>
        public void SelectNone()
        {
            Interop.Elementary.elm_entry_select_none(RealHandle);
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            //TODO: Fix this to use layout
            return Interop.Elementary.elm_entry_add(parent.Handle);
        }
    }
}
