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
    public enum ColorSelectorMode
    {
        Palette,
        Components,
        Both,
        Picker,
        Plane,
        PallettePlane,
        All
    }

    public class ColorSelector : Layout
    {
        private readonly SmartEvent<ColorChangedEventArgs> _changed;
        private Color _currentColor;

        public ColorSelector(EvasObject parent) : base(parent)
        {
            _changed = new SmartEvent<ColorChangedEventArgs>(this, "changed", (data, obj, info) =>
            {
                return new ColorChangedEventArgs(_currentColor, SelectedColor);
            });
        }

        public event EventHandler<ColorChangedEventArgs> ColorChanged
        {
            add { _changed.On += value; }
            remove { _changed.On -= value; }
        }

        public Color SelectedColor
        {
            get
            {
                int r, g, b, a;
                Interop.Elementary.elm_colorselector_color_get(Handle, out r, out g, out b, out a);
                _currentColor = new Color(r, g, b, a);
                return _currentColor;
            }
            set
            {
                Interop.Elementary.elm_colorselector_color_set(Handle, value.R, value.G, value.B, value.A);
                _currentColor = new Color(value.R, value.G, value.B, value.A);
            }
        }

        public ColorSelectorMode Mode
        {
            get
            {
                return (ColorSelectorMode) Interop.Elementary.elm_colorselector_mode_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_colorselector_mode_set(Handle, (Interop.Elementary.Elm_Colorselector_Mode)value);
            }
        }

        public string PaletteName
        {
            get
            {
                return Interop.Elementary.elm_colorselector_palette_name_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_colorselector_palette_name_set(Handle, value);
            }
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_colorselector_add(parent.Handle);
        }
    }
}
