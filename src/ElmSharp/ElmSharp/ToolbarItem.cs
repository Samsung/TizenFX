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
    public class ToolbarItem : ItemObject
    {
        string _icon;
        string _text;
        internal ToolbarItem(string text, string icon) : base(IntPtr.Zero)
        {
            _text = text;
            _icon = icon;
        }

        public string Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                Interop.Elementary.elm_toolbar_item_icon_set(Handle, value);
            }
        }
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                SetPartText(null, value);
            }
        }
        public bool Enabled
        {
            get
            {
                return !Interop.Elementary.elm_object_disabled_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_object_disabled_set(Handle, !value);
            }
        }
        public bool IsSeparator
        {
            get
            {
                return Interop.Elementary.elm_toolbar_item_separator_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_toolbar_item_separator_set(Handle, value);
            }
        }
        public bool IsSelected
        {
            get
            {
                return Interop.Elementary.elm_toolbar_item_selected_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_toolbar_item_selected_set(Handle, value);
            }
        }

        public event EventHandler Selected;
        public event EventHandler LongPressed;
        public event EventHandler Clicked;

        internal void SendSelected()
        {
            Selected?.Invoke(this, EventArgs.Empty);
        }
        internal void SendLongPressed()
        {
            LongPressed?.Invoke(this, EventArgs.Empty);
        }
        internal void SendClicked()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
