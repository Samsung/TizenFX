using System;
using System.Collections.Generic;
using System.Text;

namespace Efl
{
    namespace Ui
    {
        namespace Wearable
        {
            public class RotaryColorPart : Efl.Object, Efl.Gfx.Color
            {
                int _r, _g, _b, _a;

                public RotaryColorPart() { _r = _g = _b = _a = -1; }

                public void SetColor(int r, int g, int b, int a)
                {
                    _r = r;
                    _g = g;
                    _b = b;
                    _a = a;
                }

                public virtual void GetColor(out int r, out int g, out int b, out int a)
                {
                    //Not Implemented
                    r = _r;
                    g = _g;
                    b = _b;
                    a = _a;
                }

                public void SetColorCode(System.String colorcode)
                {
                    //Not Implemented
                    return;
                }

                public System.String GetColorCode()
                {
                    //Not Implemented
                    return null;
                }

                public System.String GetColorClassCode(System.String color_class, Efl.Gfx.ColorClassLayer layer)
                {
                    //Not Implemented
                    return null;
                }
                public void SetColorClassCode(System.String color_class, Efl.Gfx.ColorClassLayer layer, System.String colorcode)
                {
                    //This function will be removed after interface work is done
                    return;
                }

                public System.String ColorCode
                {
                    //This function will be removed afater interface work is done
                    get { return null; }
                    set { }
                }
            }

            public class RotarySelectorItem
            {
                const string MainTextPartName = "selector,main_text";
                const string SubTextPartName = "selector,sub_text";
                const string IconPartName = "item,icon";
                const string BgPartName = "item,bg_image";
                const string SelectorIconPartName = "selector,icon";

                string _mainText;
                string _subText;
                Image _normalIconImage;
                Image _pressedIconImage;
                Image _disabledIconImage;
                Image _selectedIconImage;
                Image _normalBgImage;
                Image _pressedBgImage;
                Image _disabledBgImage;
                Image _selectedBgImage;
                Image _selectorIconImage;

                public RotaryColorPart MainTextColor;
                public RotaryColorPart SubTextColor;
                public RotaryColorPart NormalBgColor;
                public RotaryColorPart PressedBgColor;
                public RotaryColorPart DisabledBgColor;
                public RotaryColorPart SelectedBgColor;

                public IntPtr _handle;
                public IntPtr NativeHandle
                {
                    set
                    {
                        if (_handle == value) return;
                        _handle = value;

                        if (_handle == null) return;

                        
                        SetPart(MainTextPartName, _mainText);
                        SetPart(SubTextPartName, _subText);

                        SetPart(MainTextPartName, ItemState.Normal, MainTextColor);
                        SetPart(SubTextPartName, ItemState.Normal, SubTextColor);

                        SetPart(IconPartName, ItemState.Normal, _normalIconImage);
                        SetPart(IconPartName, ItemState.Pressed, _pressedIconImage);
                        SetPart(IconPartName, ItemState.Disabled, _disabledIconImage);
                        SetPart(IconPartName, ItemState.Selected, _selectedIconImage);
                        
                        SetPart(BgPartName, ItemState.Normal, _normalBgImage);
                        SetPart(BgPartName, ItemState.Pressed, _pressedBgImage);
                        SetPart(BgPartName, ItemState.Disabled, _disabledBgImage);
                        SetPart(BgPartName, ItemState.Selected, _selectedBgImage);

                        SetPart(BgPartName, ItemState.Normal, NormalBgColor);
                        SetPart(BgPartName, ItemState.Normal, PressedBgColor);
                        SetPart(BgPartName, ItemState.Normal, DisabledBgColor);
                        SetPart(BgPartName, ItemState.Normal, SelectedBgColor);

                        SetPart(SelectorIconPartName, ItemState.Normal, _selectorIconImage);
                    }
                    get
                    {
                        return _handle;
                    }
                }

                void SetPart(string partName, ItemState state, Image img)
                {
                    if (NativeHandle != null && partName != null && img != null)
                    {
                        Interop.Eext.eext_rotary_selector_item_part_content_set(NativeHandle, partName, (int)state, img.NativeHandle);
                    }
                }

                void SetPart(string partName, string text)
                {
                    if (NativeHandle != null && text != null)
                    {
                        Interop.Eext.eext_rotary_selector_item_part_text_set(NativeHandle, partName, text);
                    }
                }

                void SetPart(string partName, ItemState state, RotaryColorPart color)
                {
                    if (NativeHandle != null && partName != null && color != null)
                    {
                        int r, g, b, a;
                        color.GetColor(out r, out g, out b, out a);

                        if (r != -1 || g != -1 || b != -1 || a != -1)
                          Interop.Eext.eext_rotary_selector_item_part_color_set(NativeHandle, partName, (int)state, r, g, b, a);
                    }
                }

                public string MainText
                {
                    get { return _mainText; }
                    set
                    {
                        _mainText = value;
                        SetPart(MainTextPartName, value);
                    }
                }

                public string SubText
                {
                    get { return _subText; }
                    set
                    {
                        _subText = value;
                        SetPart(SubTextPartName, value);
                    }
                }

                public Image NormalIconImage
                {
                    get { return _normalIconImage; }
                    set
                    {
                        _normalIconImage = value;
                        SetPart(IconPartName, ItemState.Normal, value);
                    }
                }

                public Image PressedIconImage
                {
                    get { return _pressedIconImage; }
                    set
                    {
                        _pressedIconImage = value;
                        SetPart(IconPartName, ItemState.Pressed, value);
                    }
                }

                public Image DisabledIconImage
                {
                    get { return _disabledIconImage; }
                    set
                    {
                        _disabledIconImage = value;
                        SetPart(IconPartName, ItemState.Disabled, value);
                    }
                }

                public Image SelectedIconImage
                {
                    get { return _selectedIconImage; }
                    set
                    {
                        _selectedIconImage = value;
                        SetPart(IconPartName, ItemState.Selected, value);
                    }
                }

                public Image NormalBackgroundImage
                {
                    get { return _normalBgImage; }
                    set
                    {
                        _normalBgImage = value;
                        SetPart(BgPartName, ItemState.Normal, value);
                    }
                }

                public Image PressedBackgroundImage
                {
                    get { return _pressedBgImage; }
                    set
                    {
                        _pressedBgImage = value;
                        SetPart(BgPartName, ItemState.Pressed, value);
                    }
                }

                public Image DisabledBackgroundImage
                {
                    get { return _disabledBgImage; }
                    set
                    {
                        _disabledBgImage = value;
                        SetPart(BgPartName, ItemState.Disabled, value);
                    }
                }

                public Image SelectedBackgroundImage
                {
                    get { return _selectedBgImage; }
                    set
                    {
                        _selectedBgImage = value;
                        SetPart(BgPartName, ItemState.Selected, value);
                    }
                }

                public Image SelectorIconImage
                {
                    get { return _selectorIconImage; }
                    set
                    {
                        _selectorIconImage = value;
                        SetPart(SelectorIconPartName, ItemState.Normal, value);
                    }
                }

                internal enum ItemState
                {
                    Normal,
                    Pressed,
                    Disabled,
                    Selected
                }
            }
        }
    }
}
