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
    public class Slider : Layout
    {
        double _minimum = 0.0;
        double _maximum = 1.0;

        SmartEvent _changed;
        SmartEvent _delayedChanged;
        SmartEvent _dragStarted;
        SmartEvent _dragStopped;

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

        public event EventHandler ValueChanged;

        public event EventHandler DelayedValueChanged;

        public event EventHandler DragStarted;

        public event EventHandler DragStopped;

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

        public string UnitFormat
        {
            get
            {
                return Interop.Elementary.elm_slider_unit_format_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_slider_unit_format_set(RealHandle, value);
            }
        }

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
