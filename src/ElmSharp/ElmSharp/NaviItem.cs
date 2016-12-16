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
    public class NaviItem : ItemObject
    {
        EvasObject _content;
        bool _isPopped;
        Color _barBackgroundColor = Color.Default;
        Interop.Elementary.Elm_Naviframe_Item_Pop_Cb _popped;

        NaviItem(IntPtr handle, EvasObject content) : base(handle)
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

        public event EventHandler Popped;

        public EvasObject Content
        {
            get { return _content; }
        }

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
                    Console.WriteLine("ItemObject instance doesn't support to set TitleBarBackgroundColor to Color.Default.");
                    //TODO. Soon we will support the "elm_object_item_color_class_del" function in EFL.
                }
                else
                {
                    SetPartColor("bg_title", value);
                    _barBackgroundColor = value;
                }
            }
        }

        protected override void OnInvalidate()
        {
            if (!_isPopped)
                Popped?.Invoke(this, EventArgs.Empty);
        }

        internal static NaviItem FromNativeHandle(IntPtr handle, EvasObject content)
        {
            return new NaviItem(handle, content);
        }
    }
}
