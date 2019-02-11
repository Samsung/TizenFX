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
    /// The ProgressBar is a widget for visually representing the progress status of a given job or task.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class ProgressBar : Layout
    {
        SmartEvent _changed;

        /// <summary>
        /// Creates and initializes a new instance of the ProgressBar class.
        /// </summary>
        /// <param name="parent">The EvasObject to which the new ProgressBar will be attached as a child.</param>
        /// <since_tizen> preview </since_tizen>
        public ProgressBar(EvasObject parent) : base(parent)
        {
            _changed = new SmartEvent(this, this.RealHandle, "changed");
            _changed.On += (s, e) =>
            {
                ValueChanged?.Invoke(this, EventArgs.Empty);
            };
        }

        /// <summary>
        /// ValueChanged will be triggered when the value of the ProgressBar changes.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler ValueChanged;

        /// <summary>
        /// Sets or gets the value whether a given ProgressBar widget is at the "pulsing mode".
        /// </summary>
        /// <remarks>
        /// By default, progress bars display values from low to high value boundaries.
        /// There are, though, contexts in which the progress of a given task is unknown.
        /// For such cases, one can set the progress bar widget to a "pulsing state",
        /// to give the user an idea that some computation is being held,
        /// but without the exact progress values. In the default theme,
        /// it animates its bar with the contents filling in constantly and back to non-filled, in a loop.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public bool IsPulseMode
        {
            get
            {
                return Interop.Elementary.elm_progressbar_pulse_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_progressbar_pulse_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the value of the ProgressBar.
        /// </summary>
        /// <remarks>
        /// Use this property to set the progress bar levels.
        /// If you pass a value out of the specified range (0.0~1.0),
        /// it is interpreted as the closest of the boundary values in the range.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public double Value
        {
            get
            {
                return Interop.Elementary.elm_progressbar_value_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_progressbar_value_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the span value of the ProgressBar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int SpanSize
        {
            get
            {
                return Interop.Elementary.elm_progressbar_span_size_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_progressbar_span_size_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the value whether a given ProgressBar widget is horizontal.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsHorizontal
        {
            get
            {
                return Interop.Elementary.elm_progressbar_horizontal_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_progressbar_horizontal_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the value whether a given progress bar widget's displaying values are inverted.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsInverted
        {
            get
            {
                return Interop.Elementary.elm_progressbar_inverted_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_progressbar_inverted_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the format string for a given progress bar widget's units label.
        /// </summary>
        /// <remarks>
        /// If null is passed on format, it makes the object units area to be hidden completely.
        /// If not, it sets the format string for the units label's text.
        /// The units label are provided with a floating point value, so the units text displays at the most one floating point value.
        /// Note that the units label is optional. Use a format string such as "%1.2f meters" for example.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public string UnitFormat
        {
            get
            {
                return Interop.Elementary.elm_progressbar_unit_format_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_progressbar_unit_format_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Starts a given progress bar "pulsing" animation, if its under that mode.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void PlayPulse()
        {
            Interop.Elementary.elm_progressbar_pulse(RealHandle, true);
        }

        /// <summary>
        /// Stops a given progress bar "pulsing" animation, if its under that mode.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("use StopPulse instead")]
        public void StopPluse()
        {
            Interop.Elementary.elm_progressbar_pulse(RealHandle, false);
        }

        /// <summary>
        /// Stops a given progress bar "pulsing" animation, if its under that mode.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void StopPulse()
        {
            Interop.Elementary.elm_progressbar_pulse(RealHandle, false);
        }

        /// <summary>
        /// Gets the part value of a given part of the Progressbar.
        /// </summary>
        /// <param name="part">Part of the Progressbar.</param>
        /// <returns>Value range is from 0.0 to 1.0.</returns>
        /// <since_tizen> preview </since_tizen>
        public double GetPartValue(string part)
        {
            return Interop.Elementary.elm_progressbar_part_value_get(RealHandle, part);
        }

        /// <summary>
        /// Sets or gets the general or main color of the given Progressbar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public override Color Color
        {
            get
            {
                return GetPartColor("bar");
            }
            set
            {
                SetPartColor("bar", value);
            }
        }

        /// <summary>
        /// Sets the part value of a given part of the Progressbar.
        /// </summary>
        /// <param name="part">Part of the Progressbar.</param>
        /// <param name="value">Value range is from 0.0 to 1.0.</param>
        /// <since_tizen> preview </since_tizen>
        public void SetPartValue(string part, double value)
        {
            Interop.Elementary.elm_progressbar_part_value_set(RealHandle, part, value);
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

            RealHandle = Interop.Elementary.elm_progressbar_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }
    }
}