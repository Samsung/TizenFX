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

    public enum InputPanelReturnKeyType
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

    public class Entry : Layout
    {
        SmartEvent _clicked;
        SmartEvent _changedByUser;
        SmartEvent _cursorChanged;
        SmartEvent _activated;

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

        public event EventHandler Activated;

        public event EventHandler Clicked;

        public event EventHandler ChangedByUser;

        public event EventHandler CursorChanged;

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

        public bool IsEmpty
        {
            get
            {
                return Interop.Elementary.elm_entry_is_empty(RealHandle);
            }
        }

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

        public static string ConvertMarkupToUtf8(string markup)
        {
            return Interop.Elementary.elm_entry_markup_to_utf8(markup);
        }

        public bool MoveCursorNext()
        {
            return Interop.Elementary.elm_entry_cursor_next(RealHandle);
        }

        public bool MoveCursorPrev()
        {
            return Interop.Elementary.elm_entry_cursor_prev(RealHandle);
        }

        public bool MoveCursorUp()
        {
            return Interop.Elementary.elm_entry_cursor_up(RealHandle);
        }

        public bool MoveCursorDown()
        {
            return Interop.Elementary.elm_entry_cursor_down(RealHandle);
        }

        public void MoveCursorBegin()
        {
            Interop.Elementary.elm_entry_cursor_begin_set(RealHandle);
        }

        public void MoveCursorEnd()
        {
            Interop.Elementary.elm_entry_cursor_end_set(RealHandle);
        }

        public void MoveCursorLineBegin()
        {
            Interop.Elementary.elm_entry_cursor_line_begin_set(RealHandle);
        }

        public void MoveCursorLineEnd()
        {
            Interop.Elementary.elm_entry_cursor_line_end_set(RealHandle);
        }

        public void SetInputPanelLayout(InputPanelLayout layout)
        {
            Interop.Elementary.elm_entry_input_panel_layout_set(RealHandle, (Interop.Elementary.InputPanelLayout)layout);
        }

        public void SetInputPanelEnabled(bool enabled)
        {
            Interop.Elementary.elm_entry_input_panel_enabled_set(RealHandle, enabled);
        }

        public void SetInputPanelReturnKeyType(InputPanelReturnKeyType keyType)
        {
            Interop.Elementary.elm_entry_input_panel_return_key_type_set(RealHandle, (Interop.Elementary.ReturnKeyType)keyType);
        }

        public void SelectAll()
        {
            Interop.Elementary.elm_entry_select_all(RealHandle);
        }

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
