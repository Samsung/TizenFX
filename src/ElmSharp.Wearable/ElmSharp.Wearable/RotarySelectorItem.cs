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
using System.Text;

namespace ElmSharp.Wearable
{
    /// <summary>
    /// An instance to the Rotary Selector item is added. An item can be selected by the Rotary event or user item click.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class RotarySelectorItem
    {
        const string MainTextPartName = "selector,main_text";
        const string SubTextPartName = "selector,sub_text";
        const string IconPartName = "item,icon";
        const string BgPartName = "item,bg_image";
        const string SelectorIconPartName = "selector,icon";

        string _mainText;
        string _subText;

        Color _mainTextColor;
        Color _subTextColor;

        Image _normalIconImage;
        Image _pressedIconImage;
        Image _disabledIconImage;
        Image _selectedIconImage;

        Image _normalBgImage;
        Image _pressedBgImage;
        Image _disabledBgImage;
        Image _selectedBgImage;

        Color _normalBgColor;
        Color _pressedBgColor;
        Color _disabledBgColor;
        Color _selectedBgColor;

        Image _selectorIconImage;

        IntPtr _handle;

        /// <summary>
        /// Sets or gets the handle of a rotary selector item object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public IntPtr Handle
        {
            set
            {
                if (_handle == value) return;
                _handle = value;

                if (_handle == null) return;

                setPart(ref _mainText, MainTextPartName);
                setPart(ref _subText, SubTextPartName);
                setPart(ref _mainTextColor, MainTextPartName, ItemState.Normal);
                setPart(ref _subTextColor, SubTextPartName, ItemState.Normal);

                setPart(ref _normalIconImage, IconPartName, ItemState.Normal);
                setPart(ref _pressedIconImage, IconPartName, ItemState.Pressed);
                setPart(ref _disabledIconImage, IconPartName, ItemState.Disabled);
                setPart(ref _selectedIconImage, IconPartName, ItemState.Selected);

                setPart(ref _normalBgImage, BgPartName, ItemState.Normal);
                setPart(ref _pressedBgImage, BgPartName, ItemState.Pressed);
                setPart(ref _disabledBgImage, BgPartName, ItemState.Disabled);
                setPart(ref _selectedBgImage, BgPartName, ItemState.Selected);

                setPart(ref _normalBgColor, BgPartName, ItemState.Normal);
                setPart(ref _pressedBgColor, BgPartName, ItemState.Pressed);
                setPart(ref _disabledBgColor, BgPartName, ItemState.Disabled);
                setPart(ref _selectedBgColor, BgPartName, ItemState.Selected);

                setPart(ref _selectorIconImage, SelectorIconPartName, ItemState.Normal);
            }

            get
            {
                return _handle;
            }
        }

        void setPart(ref Image prop, string partName, ItemState state)
        {
            if (prop != null)
            {
                Interop.Eext.eext_rotary_selector_item_part_content_set(Handle, partName, (int)state, prop);
            }
        }
        void setPart(ref Color prop, string partName, ItemState state)
        {
            if (prop != default(Color))
            {
                Interop.Eext.eext_rotary_selector_item_part_color_set(Handle, partName, (int)state, prop.R, prop.G, prop.B, prop.A);
            }
        }

        void setPart(ref string prop, string partName)
        {
            if (prop != null)
            {
                Interop.Eext.eext_rotary_selector_item_part_text_set(Handle, partName, prop);
            }
        }

        void setPart(ref Image prop, string partName, ItemState state, Image img)
        {
            if (prop == img) return;
            prop = img;
            if (Handle != null)
            {
                Interop.Eext.eext_rotary_selector_item_part_content_set(Handle, partName, (int)state, img);
            }
        }

        void setPart(ref Color prop, string partName, ItemState state, Color color)
        {
            if (prop == color) return;
            prop = color;
            if (Handle != null)
            {
                Interop.Eext.eext_rotary_selector_item_part_color_set(Handle, partName, (int)state, color.R, color.G, color.B, color.A);
            }
        }

        void setPart(ref string prop, string partName, string txt)
        {
            if (prop == txt) return;
            prop = txt;
            if (Handle != null)
            {
                Interop.Eext.eext_rotary_selector_item_part_text_set(Handle, partName, txt);
            }
        }

        /// <summary>
        /// Sets or gets the main text of a rotary selector item object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public string MainText { set => setPart(ref _mainText, MainTextPartName, value); get => _mainText; }

        /// <summary>
        /// Sets or gets the subtext of a rotary selector item object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public string SubText { set => setPart(ref _subText, SubTextPartName, value); get => _subText; }

        /// <summary>
        /// Sets or gets the subtext color of a rotary selector item object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Color MainTextColor { set => setPart(ref _mainTextColor, MainTextPartName, ItemState.Normal, value); get => _mainTextColor; }

        /// <summary>
        /// Sets or gets the subtext color of a rotary selector item object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Color SubTextColor { set => setPart(ref _subTextColor, SubTextPartName, ItemState.Normal, value); get => _subTextColor; }

        /// <summary>
        /// Sets or gets the normal icon image of a rotary selector item object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Image NormalIconImage { set => setPart(ref _normalIconImage, IconPartName, ItemState.Normal, value); get => _normalIconImage; }

        /// <summary>
        /// Sets or gets the pressed icon image of a rotary selector item object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Image PressedIconImage { set => setPart(ref _pressedIconImage, IconPartName, ItemState.Pressed, value); get => _pressedIconImage; }

        /// <summary>
        /// Sets or gets the disabled icon image of a rotary selector item object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Image DisabledIconImage { set => setPart(ref _disabledIconImage, IconPartName, ItemState.Disabled, value); get => _disabledIconImage; }

        /// <summary>
        /// Sets or gets the selected icon image of a rotary selector item object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Image SelectedIconImage { set => setPart(ref _selectedIconImage, IconPartName, ItemState.Selected, value); get => _selectedIconImage; }

        /// <summary>
        /// Sets or gets the normal background image of a rotary selector item object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Image NormalBackgroundImage { set => setPart(ref _normalBgImage, BgPartName, ItemState.Normal, value); get => _normalBgImage; }

        /// <summary>
        /// Sets or gets the pressed background image of a rotary selector item object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Image PressedBackgroundImage { set => setPart(ref _pressedBgImage, BgPartName, ItemState.Pressed, value); get => _pressedBgImage; }

        /// <summary>
        /// Sets or gets the disabled background image of a rotary selector item object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Image DisabledBackgroundImage { set => setPart(ref _disabledBgImage, BgPartName, ItemState.Disabled, value); get => _disabledBgImage; }

        /// <summary>
        /// Sets or gets the selected background image of a rotary selector item object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Image SelectedBackgroundImage { set => setPart(ref _selectedBgImage, BgPartName, ItemState.Selected, value); get => _selectedBgImage; }

        /// <summary>
        /// Sets or gets the normal background color of a rotary selector item object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Color NormalBackgroundColor { set => setPart(ref _normalBgColor, BgPartName, ItemState.Normal, value); get => _normalBgColor; }

        /// <summary>
        /// Sets or gets the pressed background color of a rotary selector item object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Color PressedBackgroundColor { set => setPart(ref _pressedBgColor, BgPartName, ItemState.Pressed, value); get => _pressedBgColor; }

        /// <summary>
        /// Sets or gets the disabled background color of a rotary selector item object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Color DisabledBackgroundColor { set => setPart(ref _disabledBgColor, BgPartName, ItemState.Disabled, value); get => _disabledBgColor; }

        /// <summary>
        /// Sets or gets the selected background color of a rotary selector item object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Color SelectedBackgroundColor { set => setPart(ref _selectedBgColor, BgPartName, ItemState.Selected, value); get => _selectedBgColor; }

        /// <summary>
        /// Sets or gets the selector icon image of a rotary selector item object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Image SelectorIconImage { set => setPart(ref _selectorIconImage, SelectorIconPartName, ItemState.Normal, value); get => _selectorIconImage; }

        internal enum ItemState
        {
            Normal,
            Pressed,
            Disabled,
            Selected
        }
    }
}
