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
            _changed = new SmartEvent(this, "changed");
            _changed.On += (s, e) => ValueChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler ValueChanged;

        public int StateValue
        {
            get
            {
                return Interop.Elementary.elm_radio_state_value_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_radio_state_value_set(Handle, value);
            }
        }

        public int GroupValue
        {
            get
            {
                return Interop.Elementary.elm_radio_value_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_radio_value_set(Handle, value);
            }
        }

        public void SetGroup(Radio group)
        {
            if (group == null)
            {
                throw new ArgumentNullException("group");
            }
            Interop.Elementary.elm_radio_group_add(Handle, group.Handle);
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_radio_add(parent);
        }
    }
}
