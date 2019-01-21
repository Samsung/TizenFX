/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// Enumeration for the modes of ColorSelector.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum ColorSelectorMode
    {
        /// <summary>
        /// Only the color palette is displayed, by default.
        /// </summary>
        Palette,
        /// <summary>
        /// Only the color selector is displayed.
        /// </summary>
        [Obsolete("Components is obsolete as of version 1.2.3 and is no longer supported.")]
        Components,
        /// <summary>
        /// Both the palette and the selector is displayed.
        /// </summary>
        [Obsolete("Both is obsolete as of version 1.2.3 and is no longer supported.")]
        Both,
        /// <summary>
        /// Only the color picker is displayed.
        /// </summary>
        [Obsolete("Picker is obsolete as of version 1.2.3 and is no longer supported.")]
        Picker,
        /// <summary>
        /// This mode is not supported. If you use this, nothing will be shown.
        /// </summary>
        [Obsolete("Plane is obsolete as of version 1.2.3 and is no longer supported.")]
        Plane,
        /// <summary>
        /// This mode is not supported. If you use this, it will be shown same with the Palette mode.
        /// </summary>
        [Obsolete("PallettePlane is obsolete as of version 1.2.3 and is no longer supported.")]
        PallettePlane,
        /// <summary>
        /// This mode is not supported. If you use this, it will be shown same with the Palette mode.
        /// </summary>
        [Obsolete("All is obsolete as of version 1.2.3 and is no longer supported.")]
        All
    }

    /// <summary>
    /// The ColorSelector is a widget to set a series of colors.
    /// It also allows to load/save colors from/to the configuration with a unique identifier.
    /// </summary>
    /// <remarks>
    /// By default, the colors are loaded/saved from/to configuration using the "default" identifier.
    /// The colors can be picked by the user from the color set by clicking on individual
    /// color items on the palette, or by selecting it from the selector.
    /// </remarks>
    /// <since_tizen> preview </since_tizen>
    public class ColorSelector : Layout
    {
        private readonly SmartEvent<ColorChangedEventArgs> _changed;
        private Color _currentColor;

        /// <summary>
        /// Creates and initializes a new instance of the ColorSelector class.
        /// </summary>
        /// <param name="parent"></param>
        /// <since_tizen> preview </since_tizen>
        public ColorSelector(EvasObject parent) : base(parent)
        {
            _changed = new SmartEvent<ColorChangedEventArgs>(this, "changed", (data, obj, info) =>
            {
                return new ColorChangedEventArgs(_currentColor, SelectedColor);
            });
        }

        /// <summary>
        /// ColorChanged will be triggered when the SelectedColor is changed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<ColorChangedEventArgs> ColorChanged
        {
            add { _changed.On += value; }
            remove { _changed.On -= value; }
        }

        /// <summary>
        /// Gets or sets the color of colorselector.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Gets the Alpha of a default Color class (value is -1).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public override int Opacity
        {
            get
            {
                return Color.Default.A;
            }
            set
            {
                Console.WriteLine("ColorSelector instance doesn't support to set Opacity.");
            }
        }

        /// <summary>
        /// Gets or sets the Colorselector's mode.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public ColorSelectorMode Mode
        {
            get
            {
                return (ColorSelectorMode)Interop.Elementary.elm_colorselector_mode_get(Handle);
            }
            set
            {
                if (ColorSelectorMode.Palette == value)
                {
                    Interop.Elementary.elm_colorselector_mode_set(Handle, (Interop.Elementary.Elm_Colorselector_Mode)value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the current palette's name.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Adds a new color item to the palette.
        /// </summary>
        /// <param name="color">The color item to add.</param>
        /// <returns>A new color palette Item.</returns>
        /// <since_tizen> preview </since_tizen>
        public ColorSelectorItem AddPaletteColor(Color color)
        {
            ColorSelectorItem item = new ColorSelectorItem();
            item.Handle = Interop.Elementary.elm_colorselector_palette_color_add(Handle, color.R, color.G, color.B, color.A);
            return item;
        }

        /// <summary>
        /// Clears the palette items.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void ClearPalette()
        {
            Interop.Elementary.elm_colorselector_palette_clear(Handle);
        }

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject.</param>
        /// <returns>Handle IntPtr.</returns>
        /// <since_tizen> preview </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_colorselector_add(parent.Handle);
        }
    }
}
