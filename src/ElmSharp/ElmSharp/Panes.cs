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
    public class Panes : Layout
    {
        Interop.SmartEvent _press;
        Interop.SmartEvent _unpressed;
        public Panes(EvasObject parent) : base(parent)
        {
            _press = new Interop.SmartEvent(this, Handle, "press");
            _unpressed = new Interop.SmartEvent(this, Handle, "unpressed");

            _press.On += (s, e) => Pressed?.Invoke(this, e);
            _unpressed.On += (s, e) => Unpressed?.Invoke(this, e);
        }

        public event EventHandler Pressed;
        public event EventHandler Unpressed;
        public bool IsFixed
        {
            get
            {
                return Interop.Elementary.elm_panes_fixed_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_panes_fixed_set(Handle, value);
            }
        }

        public double Proportion
        {
            get
            {
                return Interop.Elementary.elm_panes_content_left_size_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_panes_content_left_size_set(Handle, value);
            }
        }

        public bool IsHorizontal
        {
            get
            {
                return Interop.Elementary.elm_panes_horizontal_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_panes_horizontal_set(Handle, value);
            }
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_panes_add(parent);
        }
    }
}
