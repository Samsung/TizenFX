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
    public class Layout : Widget
    {
        Interop.SmartEvent _languageChanged;
        Interop.SmartEvent _themeChanged;

        IntPtr _edjeHandle;

        public Layout(EvasObject parent) : base(parent)
        {
            _languageChanged = new Interop.SmartEvent(this, Handle, "language,changed");
            _languageChanged.On += (s, e) => {
                LanguageChanged?.Invoke(this, EventArgs.Empty);
            };

            _themeChanged = new Interop.SmartEvent(this, Handle, "theme,changed");
            _themeChanged.On += (s, e) =>
            {
                ThemeChanged?.Invoke(this, EventArgs.Empty);
            };
        }

        public event EventHandler LanguageChanged;

        public event EventHandler ThemeChanged;

        public EdjeObject EdjeObject
        {
            get
            {
                if (_edjeHandle == IntPtr.Zero)
                    _edjeHandle = Interop.Elementary.elm_layout_edje_get(Handle);
                return new EdjeObject(_edjeHandle);
            }
        }

        public void SetTheme(string klass, string group, string style)
        {
            Interop.Elementary.elm_layout_theme_set(Handle, klass, group, style);
        }

        public void SetFile(string file, string group)
        {
            Interop.Elementary.elm_layout_file_set(Handle, file, group);
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_layout_add(parent.Handle);
        }
    }
}
