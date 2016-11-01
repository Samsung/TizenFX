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
    public class Check : Layout
    {
        private Interop.SmartEvent _changed;
        private bool _currentState;

        public Check(EvasObject parent) : base(parent)
        {
            _changed = new Interop.SmartEvent(this, Handle, "changed");
            _changed.On += (sender, e) =>
            {
                StateChanged?.Invoke(this, new CheckStateChangedEventArgs(_currentState, IsChecked));
            };
        }

        public event EventHandler<CheckStateChangedEventArgs> StateChanged;

        public bool IsChecked
        {
            get
            {
                _currentState = Interop.Elementary.elm_check_state_get(Handle);
                return _currentState;
            }
            set
            {
                Interop.Elementary.elm_check_state_set(Handle, value);
            }
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_check_add(parent.Handle);
        }
    }
}
