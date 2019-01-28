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
    /// The NaviItem is a widget that contain the contents to show in Naviframe.
    /// Inherits ItemObject
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class NaviItem : ItemObject
    {
        EvasObject _content;
        bool _isPopped;
        Color _barBackgroundColor = Color.Default;
        Interop.Elementary.Elm_Naviframe_Item_Pop_Cb _popped;        

        NaviItem(IntPtr handle, EvasObject content) : base(handle)
        {
            InitializeItem(handle, content);
        }

        NaviItem(IntPtr handle, EvasObject content, EvasObject parent) : base(handle, parent)
        {
            InitializeItem(handle, content);
        }

        void InitializeItem(IntPtr handle, EvasObject content)
        {
            _isPopped = false;
            _content = content;
            _popped = (d, i) =>
            {
                _isPopped = true;
                Popped?.Invoke(this, EventArgs.Empty);
                return true;
            };
            Interop.Elementary.elm_naviframe_item_pop_cb_set(handle, _popped, IntPtr.Zero);
        }

        /// <summary>
        /// Popped will be triggered when NaviItem is removed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Popped;

        /// <summary>
        /// Gets the content object. The name of the content part is "elm.swallow.content".
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public EvasObject Content
        {
            get { return _content; }
        }

        /// <summary>
        /// Sets or gets a value whether the title area is enabled or not.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool TitleBarVisible
        {
            get
            {
                return Interop.Elementary.elm_naviframe_item_title_enabled_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_naviframe_item_title_enabled_set(Handle, value, false);
            }
        }

        /// <summary>
        ///  Sets or gets the title bar background color.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Color TitleBarBackgroundColor
        {
            get
            {
                return _barBackgroundColor;
            }
            set
            {
                if (value.IsDefault)
                {
                    Interop.Elementary.elm_object_item_color_class_del(Handle, "bg_title");
                }
                else
                {
                    SetPartColor("bg_title", value);
                    _barBackgroundColor = value;
                }
            }
        }

        /// <summary>
        /// Sets or gets an item style.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public override string Style
        {
            get
            {
                return Interop.Elementary.elm_naviframe_item_style_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_naviframe_item_style_set(Handle, value);
            }
        }

        /// <summary>
        /// Invalidates the EventArgs if _isPopped is false.
        /// The method should be overridden in the children class.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        protected override void OnInvalidate()
        {
            if (!_isPopped)
                Popped?.Invoke(this, EventArgs.Empty);
        }

        internal static NaviItem FromNativeHandle(IntPtr handle, EvasObject content, EvasObject parent)
        {
            return new NaviItem(handle, content);
        }
    }
}
