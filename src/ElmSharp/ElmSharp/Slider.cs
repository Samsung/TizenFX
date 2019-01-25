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
    /// Enumeration for the Slider's indicator visiblity mode.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum SliderIndicatorVisibleMode
    {
        /// <summary>
        /// Shows the indicator on mouse down or change in the slider value.
        /// </summary>
        Default,

        /// <summary>
        /// Always show the indicator.
        /// </summary>
        Always,

        /// <summary>
        /// Show the indicator on focus.
        /// </summary>
        OnFocus,

        /// <summary>
        /// Never show the indicator.
        /// </summary>
        None,
    }

    /// <summary>
    /// The Slider is a widget that adds a draggable slider widget for selecting the value of something within a range.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class Slider : Layout
    {
        double _minimum = 0.0;
        double _maximum = 1.0;

        SmartEvent _changed;
        SmartEvent _delayedChanged;
        SmartEvent _dragStarted;
        SmartEvent _dragStopped;

        /// <summary>
        /// Creates and initializes a new instance of the Slider class.
        /// </summary>
        /// <param name="parent">The <see cref="EvasObject"/> to which the new slider will be attached as a child.</param>
        /// <since_tizen> preview </since_tizen>
        public Slider(EvasObject parent) : base(parent)
        {
            _changed = new SmartEvent(this, this.RealHandle, "changed");
            _changed.On += (s, e) => ValueChanged?.Invoke(this, EventArgs.Empty);

            _delayedChanged = new SmartEvent(this, this.RealHandle, "delay,changed");
            _delayedChanged.On += (s, e) => DelayedValueChanged?.Invoke(this, EventArgs.Empty);

            _dragStarted = new SmartEvent(this, this.RealHandle, "slider,drag,start");
            _dragStarted.On += (s, e) => DragStarted?.Invoke(this, EventArgs.Empty);

            _dragStopped = new SmartEvent(this, this.RealHandle, "slider,drag,stop");
            _dragStopped.On += (s, e) => DragStopped?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// ValueChanged will be triggered when the Slider value is changed by the user.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler ValueChanged;

        /// <summary>
        /// DelayedValueChanged will be triggered when a short time after the value is changed by the user.
        /// This will be called only when the user stops dragging for a very short period or when they release their finger/mouse,
        /// so it avoids possibly expensive reactions to the value change.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler DelayedValueChanged;

        /// <summary>
        /// DragStarted will be triggered when dragging the Slider indicator around has started.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler DragStarted;

        /// <summary>
        /// DragStopped will be triggered when dragging the Slider indicator around has stopped.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler DragStopped;

        /// <summary>
        /// Sets or gets the (exact) length of the bar region of a given Slider widget.
        /// </summary>
        /// <remarks>
        /// This sets the minimum width (when in the horizontal mode) or height (when in the vertical mode)
        /// of the actual bar area of the slider object. This in turn affects the object's minimum size.
        /// Use this when you're not setting other size hints expanding on the given direction
        /// (like weight and alignment hints), and you would like it to have a specific size.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public int SpanSize
        {
            get
            {
                return Interop.Elementary.elm_slider_span_size_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_slider_span_size_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the format string for the indicator label.
        /// </summary>
        /// <remarks>
        /// The slider may display its value somewhere other than the unit label,
        /// for example, above the slider knob that is dragged around. This function sets the format string
        /// used for this. If null, the indicator label won't be visible. If not, it sets the format string
        /// for the label text. For the label text floating point value is provided, so the label text can
        /// display up to 1 floating point value. Note that this is optional. Use a format string
        /// such as "%1.2f meters" for example, and it displays values like: "3.14 meters" for a value
        /// equal to 3.14159. By default, the indicator label is disabled.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public string IndicatorFormat
        {
            get
            {
                return Interop.Elementary.elm_slider_indicator_format_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_slider_indicator_format_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the orientation of a given slider widget.
        /// </summary>
        /// <remarks>
        /// The orientation may be vertical or horizontal. By default, it's displayed horizontally.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public bool IsHorizontal
        {
            get
            {
                return Interop.Elementary.elm_slider_horizontal_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_slider_horizontal_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the minimum values for the slider.
        /// </summary>
        /// <remarks>
        /// This defines the allowed minimum values to be selected by the user.
        /// If the actual value is less than min, it is updated to min.
        /// Actual value can be obtained with value. By default, the minimum is equal to 0.0.
        /// </remarks>
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
                Interop.Elementary.elm_slider_min_max_set(RealHandle, _minimum, _maximum);
            }
        }

        /// <summary>
        /// Sets or gets the maximum values for the slider.
        /// </summary>
        /// <remarks>
        /// This defines the allowed maximum values to be selected by the user.
        /// If the actual value is bigger then max, it is updated to max.
        /// Actual value can be obtained with value. By default, minimum is equal to 0.0 and maximum is equal to 1.0.
        /// Maximum must be greater than minimum, otherwise the behavior is undefined.
        /// </remarks>
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
                Interop.Elementary.elm_slider_min_max_set(RealHandle, _minimum, _maximum);
            }
        }

        /// <summary>
        /// Gets or sets the value displayed by the slider.
        /// </summary>
        /// <remarks>
        /// Value will be presented on the unit label following format specified with UnitFormat and
        /// on indicator with IndicatorFormat. The value must be between minimum and maximum values.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public double Value
        {
            get
            {
                return Interop.Elementary.elm_slider_value_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_slider_value_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the step by which the slider indicator moves.
        /// </summary>
        /// <remarks>
        /// This value is used when the draggable object is moved automatically i.e.,
        /// in case of a key event when up/down/left/right key is pressed or in case accessibility
        /// is set and the flick event is used to increase or decrease the slider values.
        /// By default, the step value is equal to 0.05.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public double Step
        {
            get
            {
                return Interop.Elementary.elm_slider_step_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_slider_step_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets or sets whether a given slider widget's displaying values are inverted.
        /// </summary>
        /// <remarks>
        /// A slider may be inverted, in which case it gets its values inverted,
        /// with high values being on the left or top, and low values on the right or bottom,
        /// as opposed to normally have the low values on the former and high values on the latter,
        /// respectively, for the horizontal and vertical modes.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public bool IsInverted
        {
            get
            {
                return Interop.Elementary.elm_slider_inverted_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_slider_inverted_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets whether to enlarge the slider indicator (augmented knob).
        /// </summary>
        /// <remarks>
        /// By default, the indicator is bigger when dragged by the user.
        /// It won't display the values set with IndicatorFormat if you disable the indicator.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public bool IsIndicatorVisible
        {
            get
            {
                return Interop.Elementary.elm_slider_indicator_show_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_slider_indicator_show_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the visible mode of the slider indicator.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public SliderIndicatorVisibleMode IndicatorVisibleMode
        {
            get
            {
                return (SliderIndicatorVisibleMode)Interop.Elementary.elm_slider_indicator_visible_mode_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_slider_indicator_visible_mode_set(RealHandle, (int)value);
            }
        }

        /// <summary>
        /// Sets or gets whether to show the indicator of a slider on focus.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsIndicatorFocusable
        {
            get
            {
                return Interop.Elementary.elm_slider_indicator_show_on_focus_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_slider_indicator_show_on_focus_set(RealHandle, value);
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

            RealHandle = Interop.Elementary.elm_slider_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }
    }
}