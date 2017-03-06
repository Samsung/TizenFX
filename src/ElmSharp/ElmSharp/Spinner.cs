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
    public class Spinner : Layout
    {
        double _minimum = 0.0;
        double _maximum = 100.0;

        SmartEvent _changed;
        SmartEvent _delayedChanged;

        public Spinner(EvasObject parent) : base(parent)
        {
            _changed = new SmartEvent(this, this.RealHandle, "changed");
            _changed.On += (s, e) => ValueChanged?.Invoke(this, EventArgs.Empty);

            _delayedChanged = new SmartEvent(this, this.RealHandle, "delay,changed");
            _delayedChanged.On += (s, e) => DelayedValueChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler ValueChanged;

        public event EventHandler DelayedValueChanged;

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


        public void AddSpecialValue(double value, string label)
        {
            Interop.Elementary.elm_spinner_special_value_add(RealHandle, value, label);
        }

        public void RemoveSpecialValue(double value)
        {
            Interop.Elementary.elm_spinner_special_value_del(RealHandle, value);
        }

        public string GetSpecialValue(double value)
        {
            return Interop.Elementary.elm_spinner_special_value_get(RealHandle, value);
        }

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
