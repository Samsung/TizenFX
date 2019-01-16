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
    /// <summary>
    /// The ToolbarItem is an item of the toolbar.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class ToolbarItem : ItemObject
    {
        string _icon;
        string _text;

        internal ToolbarItem(string text, string icon) : base(IntPtr.Zero)
        {
            _text = text;
            _icon = icon;
        }

        internal ToolbarItem(EvasObject parent, string text, string icon) : base(parent, IntPtr.Zero)
        {
            _text = text;
            _icon = icon;
        }

        /// <summary>
        /// Sets or gets the icon path of the item.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Sets or gets the text string of the item.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Sets or gets the enable of the item.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("Enabled is obsolete as of version v1.1.0-beta-023. Please use IsEnabled instead.")]
        public bool Enabled
        {
            get
            {
                return IsEnabled;
            }
            set
            {
                IsEnabled = value;
            }
        }

        /// <summary>
        /// Sets or gets whether displaying the item as a separator.
        /// </summary>
        /// <remarks>Items aren't set as a separator by default. If set as a separator, it displays a separator theme, so it won't display the icons or labels.</remarks>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Sets or gets whether the item is selected.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Selected will be triggered when the item is selected.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Selected;

        /// <summary>
        /// LongPressed will be triggered when the item is pressed for a long time.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler LongPressed;

        /// <summary>
        /// Clicked will be triggered when the item is clicked.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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
