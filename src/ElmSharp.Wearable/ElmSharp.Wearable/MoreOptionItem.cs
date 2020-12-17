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
    /// The MoreOptionItem is an item of the MoreOption widget.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
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
        /// <since_tizen> preview </since_tizen>
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
        /// Creates and initializes a new instance of the MoreOptionItem class.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public MoreOptionItem()
        {
            _icon = null;
        }

        /// <summary>
        /// Sets or gets the main text of the more option object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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
        /// Sets or gets the subtext of the more option object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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
        /// Sets or gets the icon image.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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
