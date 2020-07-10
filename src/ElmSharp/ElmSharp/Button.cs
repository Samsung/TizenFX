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
    /// The Button is a widget that works as a clickable input element to trigger events.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class Button : Layout
    {
        private SmartEvent _clicked;
        private SmartEvent _repeated;
        private SmartEvent _pressed;
        private SmartEvent _released;

        private int _notUsedForTest;

        /// <summary>
        /// Creates and initializes a new instance of the Button class.
        /// </summary>
        /// <param name="parent">
        /// The EvasObject to which the new Button will be attached as a child.
        /// </param>
        /// <since_tizen> preview </since_tizen>
        public Button(EvasObject parent) : base(parent)
        {
            _clicked = new SmartEvent(this, this.RealHandle, "clicked");
            _repeated = new SmartEvent(this, this.RealHandle, "repeated");
            _pressed = new SmartEvent(this, this.RealHandle, "pressed");
            _released = new SmartEvent(this, this.RealHandle, "unpressed");

            _clicked.On += (sender, e) =>
            {
                Clicked?.Invoke(this, EventArgs.Empty);
            };

            _repeated.On += (sender, e) =>
            {
                Repeated?.Invoke(this, EventArgs.Empty);
            };

            _pressed.On += (sender, e) =>
            {
                Pressed?.Invoke(this, EventArgs.Empty);
            };

            _released.On += (sender, e) =>
            {
                Released?.Invoke(this, EventArgs.Empty);
            };
        }

        /// <summary>
        /// Clicked will be triggered when the button is clicked.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Clicked;

        /// <summary>
        /// Repeated will be triggered when the button is pressed without releasing it.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Repeated;

        /// <summary>
        /// Pressed will be triggered when the button is pressed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Pressed;

        /// <summary>
        /// Released will be triggered when the button is released after being pressed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Released;

        public bool NoCommentForTest { get; set; }

        /// <summary>
        /// Sets or gets the autorepeat feature of a given Bbutton.
        /// </summary>
        /// <remarks>
        /// Autorepeat feature means the autorepeat event is generated when the button is kept pressed.
        /// When set to false, no autorepeat is performed and the buttons will trigger the Clicked event when they are clicked.
        /// When set to true, keeping a button pressed continuously will trigger the Repeated event until the button is released.
        /// The time it takes until it starts triggering, repeated is given by AutoRepeatInitialTime,
        /// and the time between each new emission is given by AutoRepeatGapTimeout.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public bool AutoRepeat
        {
            get
            {
                return Interop.Elementary.elm_button_autorepeat_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_button_autorepeat_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the initial timeout before the Repeat event is generated.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double AutoRepeatInitialTime
        {
            get
            {
                return Interop.Elementary.elm_button_autorepeat_initial_timeout_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_button_autorepeat_initial_timeout_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the interval between each generated Repeat event.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double AutoRepeatGapTimeout
        {
            get
            {
                return Interop.Elementary.elm_button_autorepeat_gap_timeout_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_button_autorepeat_gap_timeout_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Deletes the object Color class.
        /// </summary>
        /// <param name="part">The Color class to be deleted.</param>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("DeleteColorClass is obsolete, please use EdjeObject.DeleteColorClass(string)")]
        public void DeleteColorClass(string part)
        {
            Interop.Elementary.edje_object_color_class_del(Handle, part);
        }

        /// <summary>
        /// Sets or gets the BackgroundColor of a given button in the normal and pressed status.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public override Color BackgroundColor
        {
            set
            {
                if (value.IsDefault)
                {
                    EdjeObject.DeleteColorClass("button/bg");
                    EdjeObject.DeleteColorClass("button/bg_pressed");
                    EdjeObject.DeleteColorClass("button/bg_disabled");
                }
                else
                {
                    SetPartColor("bg", value);
                    SetPartColor("bg_pressed", value);
                    SetPartColor("bg_disabled", value);
                }
                _backgroundColor = value;
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
            return Interop.Elementary.elm_button_add(parent.Handle);
        }
    }
}
