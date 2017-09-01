using System;
using System.Collections.Generic;
using System.Text;

namespace ElmSharp.Wearable
{
    /// <summary>
    /// The MoreOptionItem is a item of MoreOption widget.
    /// </summary>
    public class MoreOptionItem
    {
        const string MainTextPartName = "selector,main_text";
        const string SubTextPartName = "selector,sub_text";
        const string IconPartName = "item,icon";

        string _mainText;
        string _subText;
        Image _icon;
        IntPtr _handle;

        /// <summary>
        /// Sets or gets the more option item handle.
        /// </summary>
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

        /// <summary>
        /// Creates and initializes a new instance of MoreOptionItem class.
        /// </summary>
        public MoreOptionItem()
        {
            _icon = null;
        }

        /// <summary>
        /// Sets or gets the main text of a more option object.
        /// </summary>
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

        /// <summary>
        /// Sets or gets the sub text of a more option object.
        /// </summary>
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

        /// <summary>
        /// Sets or gets the icon image
        /// </summary>
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
