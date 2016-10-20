using System;
using System.Collections.Generic;

namespace ElmSharp
{
    public abstract class Widget : EvasObject
    {
        Dictionary<string, EvasObject> _partContents = new Dictionary<string, EvasObject>();

        Interop.SmartEvent _focused;
        Interop.SmartEvent _unfocused;

        protected Widget()
        {
        }

        protected Widget(EvasObject parent) : base(parent)
        {
            _focused = new Interop.SmartEvent(this, Handle, "focused");
            _focused.On += (s, e) => Focused?.Invoke(this, EventArgs.Empty);

            _unfocused = new Interop.SmartEvent(this, Handle, "unfocused");
            _unfocused.On += (s, e) => Unfocused?.Invoke(this, EventArgs.Empty);

        }

        public event EventHandler Focused;

        public event EventHandler Unfocused;

        public bool IsEnabled
        {
            get
            {
                return !Interop.Elementary.elm_object_disabled_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_object_disabled_set(Handle, !value);
            }
        }

        public string Style
        {
            get
            {
                return Interop.Elementary.elm_object_style_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_object_style_set(Handle, value);
            }
        }

        public bool IsFocused
        {
            get
            {
                return Interop.Elementary.elm_object_focus_get(Handle);
            }
        }

        public virtual string Text
        {
            get
            {
                return Interop.Elementary.elm_object_part_text_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_object_part_text_set(Handle, IntPtr.Zero, value);
            }
        }

        public void SetFocus(bool isFocus)
        {
            Interop.Elementary.elm_object_focus_set(Handle, isFocus);
        }

        public void SetPartContent(string part, EvasObject content)
        {
            SetPartContent(part, content, false);
        }

        public void SetPartContent(string part, EvasObject content, bool preserveOldContent)
        {
            if (preserveOldContent)
            {
                Interop.Elementary.elm_object_part_content_unset(Handle, part);
            }
            Interop.Elementary.elm_object_part_content_set(Handle, part, content);

            _partContents[part ?? "__default__"] = content;
        }

        public void SetContent(EvasObject content)
        {
            SetContent(content, false);
        }

        public void SetContent(EvasObject content, bool preserveOldContent)
        {
            if (preserveOldContent)
            {
                Interop.Elementary.elm_object_content_unset(Handle);
            }

            Interop.Elementary.elm_object_content_set(Handle, content);
            _partContents["___default__"] = content;
        }

        public void SetPartText(string part, string text)
        {
            Interop.Elementary.elm_object_part_text_set(Handle, part, text);
        }

        public string GetPartText(string part)
        {
            return Interop.Elementary.elm_object_part_text_get(Handle, part);
        }

        public void SetPartColor(string part, Color color)
        {
            Interop.Elementary.elm_object_color_class_color_set(Handle, part, color.R * color.A / 255,
                                                                              color.G * color.A / 255,
                                                                              color.B * color.A / 255,
                                                                              color.A);
        }

        internal IntPtr GetPartContent(string part)
        {
            return Interop.Elementary.elm_object_part_content_get(Handle, part);
        }
    }
}
