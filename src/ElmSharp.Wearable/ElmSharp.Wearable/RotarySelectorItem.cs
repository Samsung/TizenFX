using System;
using System.Collections.Generic;
using System.Text;

namespace ElmSharp.Wearable
{
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

        public string MainText { set => setPart(ref _mainText, MainTextPartName, value); get => _mainText; }
        public string SubText { set => setPart(ref _subText, SubTextPartName, value); get => _subText; }

        public Color MainTextColor { set => setPart(ref _mainTextColor, MainTextPartName, ItemState.Normal, value); get => _mainTextColor; }
        public Color SubextColor { set => setPart(ref _subTextColor, SubTextPartName, ItemState.Normal, value); get => _subTextColor; }

        public Image NormalIconImage { set => setPart(ref _normalIconImage, IconPartName, ItemState.Normal, value); get => _normalIconImage; }
        public Image PressedIconImage { set => setPart(ref _pressedIconImage, IconPartName, ItemState.Pressed, value); get => _pressedIconImage; }
        public Image DisabledIconImage { set => setPart(ref _disabledIconImage, IconPartName, ItemState.Disabled, value); get => _disabledIconImage; }
        public Image SelectedIconImage { set => setPart(ref _selectedIconImage, IconPartName, ItemState.Selected, value); get => _selectedIconImage; }


        public Image NormalBackgroundImage { set => setPart(ref _normalBgImage, BgPartName, ItemState.Normal, value); get => _normalBgImage; }
        public Image PressedBackgroundImage { set => setPart(ref _pressedBgImage, BgPartName, ItemState.Pressed, value); get => _pressedBgImage; }
        public Image DisabledBackgroundImage { set => setPart(ref _disabledBgImage, BgPartName, ItemState.Disabled, value); get => _disabledBgImage; }
        public Image SelectedBackgroundImage { set => setPart(ref _selectedBgImage, BgPartName, ItemState.Selected, value); get => _selectedBgImage; }

        public Color NormalBackgroundColor { set => setPart(ref _normalBgColor, BgPartName, ItemState.Normal, value); get => _normalBgColor; }
        public Color PressedBackgroundColor { set => setPart(ref _pressedBgColor, BgPartName, ItemState.Pressed, value); get => _pressedBgColor; }
        public Color DisabledBackgroundColor { set => setPart(ref _disabledBgColor, BgPartName, ItemState.Disabled, value); get => _disabledBgColor; }
        public Color SelectedBackgroundColor { set => setPart(ref _selectedBgColor, BgPartName, ItemState.Selected, value); get => _selectedBgColor; }

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
