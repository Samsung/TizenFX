using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        Interop.SmartEvent _clicked;
        Interop.SmartEvent _changedByUser;
        Interop.SmartEvent _cursorChanged;
        Interop.SmartEvent _activated;

        public Entry(EvasObject parent) : base(parent)
        {
            _clicked = new Interop.SmartEvent(this, Handle, "clicked");
            _clicked.On += (s, e) => Clicked?.Invoke(this, EventArgs.Empty);

            _changedByUser = new Interop.SmartEvent(this, Handle, "changed,user");
            _changedByUser.On += (s, e) => ChangedByUser?.Invoke(this, EventArgs.Empty);

            _cursorChanged = new Interop.SmartEvent(this, Handle, "cursor,changed");
            _cursorChanged.On += (s, e) => CursorChanged?.Invoke(this, EventArgs.Empty);

            _activated = new Interop.SmartEvent(this, Handle, "activated");
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
                return Interop.Elementary.elm_entry_single_line_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_entry_single_line_set(Handle, value);
            }
        }

        public bool IsPassword
        {
            get
            {
                return Interop.Elementary.elm_entry_password_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_entry_password_set(Handle, value);
            }
        }

        public bool IsEditable
        {
            get
            {
                return Interop.Elementary.elm_entry_editable_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_entry_editable_set(Handle, value);
            }
        }

        public bool IsEmpty
        {
            get
            {
                return Interop.Elementary.elm_entry_is_empty(Handle);
            }
        }

        public override string Text
        {
            get
            {
                return Interop.Elementary.elm_entry_entry_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_entry_entry_set(Handle, value);
            }
        }

        public string TextStyle
        {
            get
            {
                return Interop.Elementary.elm_entry_text_style_user_peek(Handle);
            }
            set
            {
                Interop.Elementary.elm_entry_text_style_user_push(Handle, value);
            }
        }

        public int CursorPosition
        {
            get
            {
                return Interop.Elementary.elm_entry_cursor_pos_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_entry_cursor_pos_set(Handle, value);
            }
        }

        public bool Scrollable
        {
            get
            {
                return Interop.Elementary.elm_entry_scrollable_get(Handle);
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
                Interop.Elementary.elm_entry_scrollable_set(Handle, value);
            }
        }

        public static string ConvertMarkupToUtf8(string markup)
        {
            return Interop.Elementary.elm_entry_markup_to_utf8(markup);
        }

        public bool MoveCursorNext()
        {
            return Interop.Elementary.elm_entry_cursor_next(Handle);
        }

        public bool MoveCursorPrev()
        {
            return Interop.Elementary.elm_entry_cursor_prev(Handle);
        }

        public bool MoveCursorUp()
        {
            return Interop.Elementary.elm_entry_cursor_up(Handle);
        }

        public bool MoveCursorDown()
        {
            return Interop.Elementary.elm_entry_cursor_down(Handle);
        }

        public void MoveCursorBegin()
        {
            Interop.Elementary.elm_entry_cursor_begin_set(Handle);
        }

        public void MoveCursorEnd()
        {
            Interop.Elementary.elm_entry_cursor_end_set(Handle);
        }

        public void MoveCursorLineBegin()
        {
            Interop.Elementary.elm_entry_cursor_line_begin_set(Handle);
        }

        public void MoveCursorLineEnd()
        {
            Interop.Elementary.elm_entry_cursor_line_end_set(Handle);
        }

        public void SetInputPanelLayout(InputPanelLayout layout)
        {
            Interop.Elementary.elm_entry_input_panel_layout_set(Handle, (Interop.Elementary.InputPanelLayout)layout);
        }

        public void SetInputPanelEnabled(bool enabled)
        {
            Interop.Elementary.elm_entry_input_panel_enabled_set(Handle, enabled);
        }

        public void SetInputPanelReturnKeyType(InputPanelReturnKeyType keyType)
        {
            Interop.Elementary.elm_entry_input_panel_return_key_type_set(Handle, (Interop.Elementary.ReturnKeyType)keyType);
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_entry_add(parent.Handle);
        }
    }
}
