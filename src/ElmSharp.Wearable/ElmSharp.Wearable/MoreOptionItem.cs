using System;
using System.Collections.Generic;
using System.Text;

namespace ElmSharp.Wearable
{
    public class MoreOptionItem
    {
        const string MainTextPartName = "selector,main_text";
        const string SubTextPartName = "selector,sub_text";
        const string IconPartName = "item,icon";

        string _mainText;
        string _subText;
        Image _icon;
        IntPtr _handle;

        public IntPtr Handle
        {
            get
            {
                return _handle;
            }
            set
            {
                if (_handle == value) return;
                _handle = value;
                if (_mainText != null)
                    Interop.Eext.eext_more_option_item_part_text_set(Handle, MainTextPartName, _mainText);
                if (_subText != null)
                    Interop.Eext.eext_more_option_item_part_text_set(Handle, SubTextPartName, _subText);
                if (_icon != null)
                    Interop.Eext.eext_more_option_item_part_content_set(Handle, IconPartName, _icon);
            }
        }

        public MoreOptionItem()
        {
            _icon = null;
        }

        public string MainText
        {
            set
            {
                if (_mainText == value) return;
                _mainText = value;
                if (Handle != IntPtr.Zero)
                {
                    Interop.Eext.eext_more_option_item_part_text_set(Handle, MainTextPartName, _mainText);
                }
            }

            get
            {
                return _mainText;
            }
        }

        public string SubText
        {
            set
            {
                if (_subText == value) return;
                _subText = value;
                if (Handle != IntPtr.Zero)
                {
                    Interop.Eext.eext_more_option_item_part_text_set(Handle, SubTextPartName, _subText);
                }
            }

            get
            {
                return _subText;
            }
        }

        public Image Icon
        {
            set
            {
                if (_icon == value) return;
                _icon = value;
                if (Handle != IntPtr.Zero)
                {
                    Interop.Eext.eext_more_option_item_part_content_set(Handle, IconPartName, _icon);
                }
            }
            get
            {
                return _icon;
            }
        }
    }
}
