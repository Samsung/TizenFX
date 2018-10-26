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
using ElmSharp.Accessible;

namespace ElmSharp
{
    /// <summary>
    /// Enumeration for the focus direction.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum FocusDirection
    {
        /// <summary>
        /// Previous direction.
        /// </summary>
        Previous,

        /// <summary>
        /// Next direction.
        /// </summary>
        Next,

        /// <summary>
        /// Up direction.
        /// </summary>
        Up,

        /// <summary>
        /// Down direction.
        /// </summary>
        Down,

        /// <summary>
        /// Right direction.
        /// </summary>
        Right,

        /// <summary>
        /// Left direction.
        /// </summary>
        Left
    }

    /// <summary>
    /// The Widget is an abstract class and the parent of other widgets.
    /// Inherits from <see cref="EvasObject"/>.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public abstract class Widget : AccessibleObject
    {
        Dictionary<string, EvasObject> _partContents = new Dictionary<string, EvasObject>();

        SmartEvent _focused;
        SmartEvent _unfocused;

        internal Color _backgroundColor = Color.Default;
        internal int _opacity = Color.Default.A;

        /// <summary>
        /// Creates and initializes a new instance of the Widget class.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        protected Widget()
        {
        }

        /// <summary>
        /// Creates and initializes a new instance of the Widget class.
        /// </summary>
        /// <param name="parent">The parent of the new Widget instance.</param>
        /// <since_tizen> preview </since_tizen>
        protected Widget(EvasObject parent) : base(parent)
        {
        }

        /// <summary>
        /// Updates the part contents.
        /// </summary>
        /// <param name="content">The content which is put into the part.</param>
        /// <param name="part">The updated part.</param>
        /// <since_tizen> preview </since_tizen>
        protected void UpdatePartContents(EvasObject content, string part = "__default__")
        {
            _partContents[part] = content;
        }

        /// <summary>
        /// Focused will be triggered when the widget is focused.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Focused;

        /// <summary>
        /// Unfocused will be triggered when the widget is unfocused.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Unfocused;

        /// <summary>
        /// Sets or gets the state of the widget, which might be enabled or disabled.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public virtual bool IsEnabled
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

        /// <summary>
        /// Sets or gets the style of the widget.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Gets whether this widget is focused.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsFocused
        {
            get
            {
                return Interop.Elementary.elm_object_focus_get(RealHandle);
            }
        }

        /// <summary>
        /// Gets whether a widget is focusable or not.
        /// </summary>
        /// <remarks>Widgets which are meant to be interacted with by input events, are created able to be focused by default.</remarks>
        /// <since_tizen> preview </since_tizen>
        public bool IsFocusAllowed
        {
            get
            {
                return Interop.Elementary.elm_object_focus_allow_get(RealHandle);
            }
        }

        /// <summary>
        /// Sets or gets the text of the widget.
        /// </summary>
        /// <remarks>It could be overridden by special child class.</remarks>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Sets or gets the background color of the widget.
        /// </summary>
        /// <remarks>It could be overridden by special child class.</remarks>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Sets or gets the opacity of the widget.
        /// </summary>
        /// <remarks>It could be overridden by special child class.</remarks>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Sets or gets whether a widget and its children are focusable or not.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool AllowTreeFocus
        {
            get
            {
                return Interop.Elementary.elm_object_tree_focus_allow_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_object_tree_focus_allow_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the widget's mirrored mode.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsMirroredMode
        {
            get
            {
                return Interop.Elementary.elm_object_mirrored_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_object_mirrored_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the widget's mirrored mode setting.
        /// When widget is set to automatic mode(true), it follows the system mirrored mode.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsAutoMirroredMode
        {
            get
            {
                return Interop.Elementary.elm_object_mirrored_automatic_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_object_mirrored_automatic_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets the widget to be focused or not.
        /// </summary>
        /// <param name="isFocus">Whether be focused.</param>
        /// <since_tizen> preview </since_tizen>
        public void SetFocus(bool isFocus)
        {
            if (isFocus)
            {
                Interop.Elementary.elm_object_focus_set(RealHandle, isFocus);
            }
            else
            {
                Interop.Elementary.elm_object_focused_clear(RealHandle);
            }
        }

        /// <summary>
        /// Sets the ability for a widget to be focused.
        /// </summary>
        /// <param name="isAllowFocus">true if the object can be focused, false if not(and on errors).</param>
        /// <since_tizen> preview </since_tizen>
        public void AllowFocus(bool isAllowFocus)
        {
            Interop.Elementary.elm_object_focus_allow_set(RealHandle, isAllowFocus);
        }

        /// <summary>
        /// Gives focus to the next widget in the widget tree.
        /// </summary>
        /// <param name="direction">Direction to move the focus.</param>
        /// <since_tizen> preview </since_tizen>
        public void FocusNext(FocusDirection direction)
        {
            Interop.Elementary.elm_object_focus_next(RealHandle, (int)direction);
        }

        /// <summary>
        /// Sets the next widget with specific focus direction.
        /// </summary>
        /// <param name="next">Focus next widget.</param>
        /// <param name="direction">Focus direction.</param>
        /// <since_tizen> preview </since_tizen>
        public void SetNextFocusObject(EvasObject next, FocusDirection direction)
        {
            Interop.Elementary.elm_object_focus_next_object_set(RealHandle, next?.RealHandle ?? IntPtr.Zero, (int)direction);
        }

        /// <summary>
        /// Sets content to the particular part of the widget, and the preserve old content will not be unset.
        /// </summary>
        /// <param name="part">The name of the particular part.</param>
        /// <param name="content">The content.</param>
        /// <seealso cref="SetPartContent(string, EvasObject, bool)"/>
        /// <since_tizen> preview </since_tizen>
        public virtual bool SetPartContent(string part, EvasObject content)
        {
            return SetPartContent(part, content, false);
        }

        /// <summary>
        /// Sets content to the particular part of the widget.
        /// </summary>
        /// <param name="part">The name of the particular part.</param>
        /// <param name="content">The content.</param>
        /// <param name="preserveOldContent">true, preserve old content will be unset. false, preserve old content will not be unset.</param>
        /// <seealso cref="SetPartContent(string, EvasObject)"/>
        /// <since_tizen> preview </since_tizen>
        public virtual bool SetPartContent(string part, EvasObject content, bool preserveOldContent)
        {
            if (preserveOldContent)
            {
                Interop.Elementary.elm_object_part_content_unset(RealHandle, part);
            }
            Interop.Elementary.elm_object_part_content_set(RealHandle, part, content);
            UpdatePartContents(content, part);
            return true;
        }

        /// <summary>
        /// Sets content to the widget, and the preserve old content will not be unset.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <seealso cref="SetContent(EvasObject, bool)"/>
        /// <since_tizen> preview </since_tizen>
        public void SetContent(EvasObject content)
        {
            SetContent(content, false);
        }

        /// <summary>
        /// Sets content to the widget.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="preserveOldContent">true, preserve old content will be unset. false, preserve old content will not be unset.</param>
        /// <seealso cref="SetContent(EvasObject)"/>
        /// <since_tizen> preview </since_tizen>
        public void SetContent(EvasObject content, bool preserveOldContent)
        {
            if (preserveOldContent)
            {
                Interop.Elementary.elm_object_content_unset(RealHandle);
            }

            Interop.Elementary.elm_object_content_set(RealHandle, content);
            UpdatePartContents(content);
        }

        /// <summary>
        /// Sets text to the particular part of the widget.
        /// </summary>
        /// <param name="part">The name of the particular part.</param>
        /// <param name="text">The text.</param>
        /// <since_tizen> preview </since_tizen>
        public virtual bool SetPartText(string part, string text)
        {
            Interop.Elementary.elm_object_part_text_set(RealHandle, part, text);
            return true;
        }

        /// <summary>
        /// Gets text of a particular part of the widget.
        /// </summary>
        /// <param name="part">The name of the particular part.</param>
        /// <returns>Text of the particular part of the widget.</returns>
        /// <since_tizen> preview </since_tizen>
        public virtual string GetPartText(string part)
        {
            return Interop.Elementary.elm_object_part_text_get(RealHandle, part);
        }

        /// <summary>
        /// Sets color of a particular part of the widget.
        /// </summary>
        /// <param name="part">The name of the particular part.</param>
        /// <param name="color">The color to be set to the widget.</param>
        /// <remarks>This method is a virtual method, it could be overridden by special child class.</remarks>
        /// <since_tizen> preview </since_tizen>
        public virtual void SetPartColor(string part, Color color)
        {
            Interop.Elementary.elm_object_color_class_color_set(RealHandle, part, color.R * color.A / 255,
                                                                              color.G * color.A / 255,
                                                                              color.B * color.A / 255,
                                                                              color.A);
        }

        /// <summary>
        /// Gets color of the particular part of the widget.
        /// </summary>
        /// <param name="part">The name of the particular part.</param>
        /// <returns>The color of the particular part.</returns>
        /// <remarks>This method is a virtual method, it could be overridden by special child class.</remarks>
        /// <since_tizen> preview </since_tizen>
        public virtual Color GetPartColor(string part)
        {
            int r, g, b, a;
            Interop.Elementary.elm_object_color_class_color_get(RealHandle, part, out r, out g, out b, out a);
            return new Color((int)(r / (a / 255.0)), (int)(g / (a / 255.0)), (int)(b / (a / 255.0)), a);
        }

        /// <summary>
        /// Sets opacity of the particular part of the widget.
        /// </summary>
        /// <param name="part">The name of the particular part.</param>
        /// <param name="opacity">The opacity of the particular part.</param>
        /// <since_tizen> preview </since_tizen>
        public void SetPartOpacity(string part, int opacity)
        {
            Interop.Elementary.elm_object_color_class_color_set(Handle, part, 255, 255, 255, opacity);
        }

        /// <summary>
        /// Gets opacity of the particular part of the widget.
        /// </summary>
        /// <param name="part">The name of the particular part.</param>
        /// <returns>Opacity value of the particular part.</returns>
        /// <since_tizen> preview </since_tizen>
        public int GetPartOpacity(string part)
        {
            int r, g, b, a;
            Interop.Elementary.elm_object_color_class_color_get(Handle, part, out r, out g, out b, out a);
            return a;
        }

	/// <summary>
        /// Sends a signal to the edje object of the widget.
        /// </summary>
        /// <param name="emission">The signal's name.</param>
        /// <param name="source">The signal's source.</param>
        /// <since_tizen> preview </since_tizen>
        public void SignalEmit(string emission, string source)
        {
            Interop.Elementary.elm_object_signal_emit(Handle, emission, source);
        }

        /// <summary>
        /// The callback of the Realized event.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        protected override void OnRealized()
        {
            base.OnRealized();
            _focused = new SmartEvent(this, "focused");
            _focused.On += (s, e) => Focused?.Invoke(this, EventArgs.Empty);

            _unfocused = new SmartEvent(this, "unfocused");
            _unfocused.On += (s, e) => Unfocused?.Invoke(this, EventArgs.Empty);
        }

        internal IntPtr GetPartContent(string part)
        {
            return Interop.Elementary.elm_object_part_content_get(RealHandle, part);
        }
    }
}