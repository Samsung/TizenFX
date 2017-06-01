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
    /// This is a container widget that takes a standard Edje design file and wraps it very thinly in a widget.
    /// Inherits Widget
    /// </summary>
    public class Layout : Widget
    {
        SmartEvent _languageChanged;
        SmartEvent _themeChanged;

        IntPtr _edjeHandle;

        /// <summary>
        /// Creates and initializes a new instance of Layout class.
        /// </summary>
        /// <param name="parent">The parent is a given container which will be attached by Layout as a child. It's <see cref="EvasObject"/> type.</param>
        public Layout(EvasObject parent) : base(parent)
        {
            _languageChanged = new SmartEvent(this, this.RealHandle, "language,changed");
            _languageChanged.On += (s, e) =>
            {
                LanguageChanged?.Invoke(this, EventArgs.Empty);
            };

            _themeChanged = new SmartEvent(this, this.RealHandle, "theme,changed");
            _themeChanged.On += (s, e) =>
            {
                ThemeChanged?.Invoke(this, EventArgs.Empty);
            };
        }

        /// <summary>
        /// LanguageChanged will be triggered when the program's language is changed.
        /// </summary>
        public event EventHandler LanguageChanged;

        /// <summary>
        /// ThemeChanged will be triggered when the theme is changed.
        /// </summary>
        public event EventHandler ThemeChanged;

        /// <summary>
        /// Gets the edje layout.
        /// </summary>
        public EdjeObject EdjeObject
        {
            get
            {
                if (_edjeHandle == IntPtr.Zero)
                    _edjeHandle = Interop.Elementary.elm_layout_edje_get(RealHandle);
                return new EdjeObject(_edjeHandle);
            }
        }

        /// <summary>
        /// Sets the edje group from the elementary theme that is used as a layout.
        /// </summary>
        /// <param name="klass">The class of the group</param>
        /// <param name="group">The group</param>
        /// <param name="style">The style to use</param>
        public void SetTheme(string klass, string group, string style)
        {
            Interop.Elementary.elm_layout_theme_set(RealHandle, klass, group, style);
        }

        /// <summary>
        /// Sets the file that is used as a layout.
        /// </summary>
        /// <param name="file">The path to the file (edj) that is used as a layout</param>
        /// <param name="group">The group that the layout belongs to in the edje file</param>
        public void SetFile(string file, string group)
        {
            Interop.Elementary.elm_layout_file_set(RealHandle, file, group);
        }

        /// <summary>
        /// Sets the back ground color of layout
        /// </summary>
        public override Color BackgroundColor
        {
            set
            {
                if (value.IsDefault)
                {
                    string part = ClassName.ToLower().Replace("elm_", "") + "/" + "bg";
                    EdjeObject.DeleteColorClass(part);
                }
                else
                {
                    SetPartColor("bg", value);
                }
                _backgroundColor = value;
            }
        }

        /// <summary>
        /// Sets the vertical text alignment of layout's text part
        /// </summary>
        /// <remarks>
        /// API, elm_layout_text_valign_set, is an internal API only in Tizen. Avalilable since Tizen_4.0.
        /// </remarks>
        public virtual void SetVerticalTextAlignment(string part, double valign)
        {
            Interop.Elementary.elm_layout_text_valign_set(RealHandle, part, valign);
        }

        /// <summary>
        /// Gets the vertical text alignment of layout's text part
        /// </summary>
        /// <remarks>
        /// API, elm_layout_text_valign_get, is internal API only in Tizen. Avalilable since Tizen_4.0.
        /// </remarks>
        public virtual double GetVerticalTextAlignment(string part)
        {
            return Interop.Elementary.elm_layout_text_valign_get(RealHandle, part);
        }

        /// <summary>
        /// Sets the content at a part of a given container widget.
        /// </summary>
        /// <param name="parent">The parent is a given container which will be attached by Layout as a child. It's <see cref="EvasObject"/> type.</param>
        /// <returns>The new object, otherwise null if it cannot be created</returns>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_layout_add(parent.Handle);
        }
    }
}
