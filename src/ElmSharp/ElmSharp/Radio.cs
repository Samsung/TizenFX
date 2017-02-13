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
    public class Radio : Layout
    {
        SmartEvent _changed;

        public Radio(EvasObject parent) : base(parent)
        {
            _changed = new SmartEvent(this, this.RealHandle, "changed");
            _changed.On += (s, e) => ValueChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler ValueChanged;

        public int StateValue
        {
            get
            {
                return Interop.Elementary.elm_radio_state_value_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_radio_state_value_set(RealHandle, value);
            }
        }

        public int GroupValue
        {
            get
            {
                return Interop.Elementary.elm_radio_value_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_radio_value_set(RealHandle, value);
            }
        }

        public void SetGroup(Radio group)
        {
            if (group == null)
            {
                throw new ArgumentNullException("group");
            }
            Interop.Elementary.elm_radio_group_add(RealHandle, group.RealHandle);
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = Interop.Elementary.elm_layout_add(parent.Handle);
            Interop.Elementary.elm_layout_theme_set(handle, "layout", "elm_widget", "default");

            RealHandle = Interop.Elementary.elm_radio_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }
    }
}
