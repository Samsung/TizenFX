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
    /// The Spinner is a widget that increases or decreases the numeric values using arrow buttons, or edit values directly.
    /// Inherits <see cref="Layout"/>.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class Spinner : Layout
    {
        double _minimum = 0.0;
        double _maximum = 100.0;

        SmartEvent _changed;
        SmartEvent _delayedChanged;

        /// <summary>
        /// Creates and initializes a new instance of the Spinner class.
        /// </summary>
        /// <param name="parent">The parent of new Spinner instance</param>
        /// <since_tizen> preview </since_tizen>
        public Spinner(EvasObject parent) : base(parent)
        {
            if (Elementary.GetProfile() == "tv")
            {
                Style = "vertical";
            }
        }

        /// <summary>
        /// Creates and initializes a new instance of the Layout class.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        protected Spinner() : base()
        {
        }

        /// <summary>
        /// ValueChanged will be triggered whenever the spinner value is changed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler ValueChanged;

        /// <summary>
        /// DelayedValueChanged will be triggered after a short time when the value is changed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler DelayedValueChanged;

        /// <summary>
        /// Sets or gets the label format of the spinner.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public string LabelFormat
        {
            get
            {
                return Interop.Elementary.elm_spinner_label_format_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_spinner_label_format_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the minimum value for the spinner.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Minimum
        {
            get
            {
                return _minimum;
            }
            set
            {
                _minimum = value;
                Interop.Elementary.elm_spinner_min_max_set(RealHandle, _minimum, _maximum);
            }
        }

        /// <summary>
        /// Sets or gets the maximum value for the spinner.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Maximum
        {
            get
            {
                return _maximum;
            }
            set
            {
                _maximum = value;
                Interop.Elementary.elm_spinner_min_max_set(RealHandle, _minimum, _maximum);
            }
        }

        /// <summary>
        /// Sets or gets the step that is used to increment or decrement the spinner value.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Step
        {
            get
            {
                return Interop.Elementary.elm_spinner_step_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_spinner_step_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the value displayed by the spinner.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Value
        {
            get
            {
                return Interop.Elementary.elm_spinner_value_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_spinner_value_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the interval on time updates for a user mouse button to hold on the spinner widgets' arrows.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Interval
        {
            get
            {
                return Interop.Elementary.elm_spinner_interval_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_spinner_interval_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the base for rounding.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double RoundBase
        {
            get
            {
                return Interop.Elementary.elm_spinner_base_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_spinner_base_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the round value for rounding.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int RoundValue
        {
            get
            {
                return Interop.Elementary.elm_spinner_round_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_spinner_round_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the wrap of a given spinner widget.
        /// </summary>
        /// <remarks>
        /// If wrap is disabled when the user tries to increment the value, but the displayed value plus step value is bigger than the maximum value, then the new value will be the maximum value.
        /// If wrap is enabled when the user tries to increment the value, but the displayed value plus step value is bigger than the maximum value, then the new value will be the minimum value.
        /// By default, it's disabled.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public bool IsWrapEnabled
        {
            get
            {
                return Interop.Elementary.elm_spinner_wrap_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_spinner_wrap_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets whether the spinner can be directly edited by the user or not.
        /// </summary>
        /// <remarks>By default, it is enabled.</remarks>
        /// <since_tizen> preview </since_tizen>
        public bool IsEditable
        {
            get
            {
                return Interop.Elementary.elm_spinner_editable_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_spinner_editable_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets a special string to display in the place of the numerical value.
        /// </summary>
        /// <param name="value">The numerical value to be replaced</param>
        /// <param name="label">The label to be used</param>
        /// <since_tizen> preview </since_tizen>
        public void AddSpecialValue(double value, string label)
        {
            Interop.Elementary.elm_spinner_special_value_add(RealHandle, value, label);
        }

        /// <summary>
        /// Removes a previously added special value. After this, the spinner will display the value itself instead of a label.
        /// </summary>
        /// <param name="value">The replaced numerical value.</param>
        /// <since_tizen> preview </since_tizen>
        public void RemoveSpecialValue(double value)
        {
            Interop.Elementary.elm_spinner_special_value_del(RealHandle, value);
        }

        /// <summary>
        /// Gets the special string display in the place of the numerical value.
        /// </summary>
        /// <param name="value">The replaced numerical value.</param>
        /// <returns>The value of the spinner, which replaced the numerical value with a special string.</returns>
        /// <since_tizen> preview </since_tizen>
        public string GetSpecialValue(double value)
        {
            return Interop.Elementary.elm_spinner_special_value_get(RealHandle, value);
        }

        /// <summary>
        /// The callback of the Realized event.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        protected override void OnRealized()
        {
            base.OnRealized();
            _changed = new SmartEvent(this, this.RealHandle, "changed");
            _changed.On += (s, e) => ValueChanged?.Invoke(this, EventArgs.Empty);

            _delayedChanged = new SmartEvent(this, this.RealHandle, "delay,changed");
            _delayedChanged.On += (s, e) => DelayedValueChanged?.Invoke(this, EventArgs.Empty);
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

            RealHandle = Interop.Elementary.elm_spinner_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }
    }
}
