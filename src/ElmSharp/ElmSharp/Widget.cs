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
using System.Collections.Generic;

namespace ElmSharp
{
    public enum FocusDirection
    {
        Previous,
        Next,
        Up,
        Down,
        Right,
        Left
    }

    public abstract class Widget : EvasObject
    {
        Dictionary<string, EvasObject> _partContents = new Dictionary<string, EvasObject>();

        SmartEvent _focused;
        SmartEvent _unfocused;

        internal Color _backgroundColor = Color.Default;
        internal int _opacity = Color.Default.A;

        protected Widget()
        {
        }

        protected Widget(EvasObject parent) : base(parent)
        {
            _focused = new SmartEvent(this, "focused");
            _focused.On += (s, e) => Focused?.Invoke(this, EventArgs.Empty);

            _unfocused = new SmartEvent(this, "unfocused");
            _unfocused.On += (s, e) => Unfocused?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler Focused;

        public event EventHandler Unfocused;

        public bool IsEnabled
        {
            get
            {
                return !Interop.Elementary.elm_object_disabled_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_object_disabled_set(RealHandle, !value);
            }
        }

        public string Style
        {
            get
            {
                return Interop.Elementary.elm_object_style_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_object_style_set(RealHandle, value);
            }
        }

        public bool IsFocused
        {
            get
            {
                return Interop.Elementary.elm_object_focus_get(RealHandle);
            }
        }

        public bool IsFocusAllowed
        {
            get
            {
                return Interop.Elementary.elm_object_focus_allow_get(RealHandle);
            }
        }

        public virtual string Text
        {
            get
            {
                return Interop.Elementary.elm_object_part_text_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_object_part_text_set(RealHandle, IntPtr.Zero, value);
            }
        }

        public virtual Color BackgroundColor
        {
            get
            {
                if (!_backgroundColor.IsDefault)
                {
                    _backgroundColor = GetPartColor("bg");
                }
                return _backgroundColor;
            }
            set
            {
                if (value.IsDefault)
                {
                    Console.WriteLine("Widget instance doesn't support to set BackgroundColor to Color.Default.");
                }
                else
                {
                    SetPartColor("bg", value);
                    _backgroundColor = value;
                }
            }
        }

        public virtual int Opacity
        {
            get
            {
                if (_opacity != Color.Default.A)
                {
                    _opacity = GetPartOpacity("opacity");
                }
                return _opacity;
            }
            set
            {
                SetPartOpacity("opacity", value);
                _opacity = value;
            }
        }

        public void SetFocus(bool isFocus)
        {
            Interop.Elementary.elm_object_focus_set(RealHandle, isFocus);
        }

        public void AllowFocus(bool isAllowFocus)
        {
            Interop.Elementary.elm_object_focus_allow_set(RealHandle, isAllowFocus);
        }

        public void FocusNext(FocusDirection direction)
        {
            Interop.Elementary.elm_object_focus_next(RealHandle, (int)direction);
        }

        public void SetNextFocusObject(EvasObject next, FocusDirection direction)
        {
            Interop.Elementary.elm_object_focus_next_object_set(RealHandle, next.RealHandle, (int)direction);
        }

        public void SetPartContent(string part, EvasObject content)
        {
            SetPartContent(part, content, false);
        }

        public void SetPartContent(string part, EvasObject content, bool preserveOldContent)
        {
            if (preserveOldContent)
            {
                Interop.Elementary.elm_object_part_content_unset(RealHandle, part);
            }
            Interop.Elementary.elm_object_part_content_set(RealHandle, part, content);

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
                Interop.Elementary.elm_object_content_unset(RealHandle);
            }

            Interop.Elementary.elm_object_content_set(RealHandle, content);
            _partContents["__default__"] = content;
        }

        public void SetPartText(string part, string text)
        {
            Interop.Elementary.elm_object_part_text_set(RealHandle, part, text);
        }

        public string GetPartText(string part)
        {
            return Interop.Elementary.elm_object_part_text_get(RealHandle, part);
        }

        public virtual void SetPartColor(string part, Color color)
        {
            Interop.Elementary.elm_object_color_class_color_set(RealHandle, part, color.R * color.A / 255,
                                                                              color.G * color.A / 255,
                                                                              color.B * color.A / 255,
                                                                              color.A);
        }

        public virtual Color GetPartColor(string part)
        {
            int r, g, b, a;
            Interop.Elementary.elm_object_color_class_color_get(RealHandle, part, out r, out g, out b, out a);
            return new Color((int)(r / (a / 255.0)), (int)(g / (a / 255.0)), (int)(b / (a / 255.0)), a);
        }

        public void SetPartOpacity(string part, int opacity)
        {
            Interop.Elementary.elm_object_color_class_color_set(Handle, part, 255, 255, 255, opacity);
        }

        public int GetPartOpacity(string part)
        {
            int r, g, b, a;
            Interop.Elementary.elm_object_color_class_color_get(Handle, part, out r, out g, out b, out a);
            return a;
        }

        internal IntPtr GetPartContent(string part)
        {
            return Interop.Elementary.elm_object_part_content_get(RealHandle, part);
        }
    }
}
