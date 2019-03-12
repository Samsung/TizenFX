/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// The Check is a widget that allows for toggling a value between true and false.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class Check : Layout
    {
        private SmartEvent _changed;
        private bool _currentState;

        /// <summary>
        /// Creates and initializes a new instance of the Check class.
        /// </summary>
        /// <param name="parent">
        /// The EvasObject to which the new check will be attached as a child.
        /// </param>
        /// <since_tizen> preview </since_tizen>
        public Check(EvasObject parent) : base(parent)
        {
            _changed = new SmartEvent(this, this.RealHandle, "changed");
            _changed.On += (sender, e) =>
            {
                StateChanged?.Invoke(this, new CheckStateChangedEventArgs(_currentState, IsChecked));
            };
        }

        /// <summary>
        /// StateChanged will be triggered when the IsChecked in the check is changed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<CheckStateChangedEventArgs> StateChanged;

        /// <summary>
        /// Sets or gets whether the given check is checked or not.
        /// </summary>
        /// <remarks>
        /// When an object is checked, the value will be set to true. Conversely, will be set to false.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public bool IsChecked
        {
            get
            {
                _currentState = Interop.Elementary.elm_check_state_get(RealHandle);
                return _currentState;
            }
            set
            {
                Interop.Elementary.elm_check_state_set(RealHandle, value);
            }
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

            RealHandle = Interop.Elementary.elm_check_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }
    }
}
