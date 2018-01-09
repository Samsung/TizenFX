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
    /// The Radio is a widget that allows for 1 or more options to be displayed, and have the user choose only 1 of them.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class Radio : Layout
    {
        SmartEvent _changed;

        /// <summary>
        /// Creates and initializes a new instance of the Radio class.
        /// </summary>
        /// <param name="parent">The EvasObject to which the new Radio will be attached as a child.</param>
        /// <since_tizen> preview </since_tizen>
        public Radio(EvasObject parent) : base(parent)
        {
            _changed = new SmartEvent(this, this.RealHandle, "changed");
            _changed.On += (s, e) => ValueChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// ValueChanged will be triggered when value of the radio changes.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler ValueChanged;

        /// <summary>
        /// Sets or gets a unique value to each radio button.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Sets or gets the value of the radio group.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Adds this radio to a group of other radio objects.
        /// </summary>
        /// <param name="group">Group which add radio in.</param>
        /// <since_tizen> preview </since_tizen>
        public void SetGroup(Radio group)
        {
            if (group == null)
            {
                throw new ArgumentNullException("group");
            }
            Interop.Elementary.elm_radio_group_add(RealHandle, group.RealHandle);
        }

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject.</param>
        /// <returns>Handle IntPtr.</returns>
        /// <since_tizen> preview </since_tizen>
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
