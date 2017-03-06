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
    public class ProgressBar : Layout
    {
        SmartEvent _changed;

        public ProgressBar(EvasObject parent) : base(parent)
        {
            _changed = new SmartEvent(this, this.RealHandle, "changed");
            _changed.On += (s, e) =>
            {
                ValueChanged?.Invoke(this, EventArgs.Empty);
            };
        }

        public event EventHandler ValueChanged;

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

        public void PlayPulse()
        {
            Interop.Elementary.elm_progressbar_pulse(RealHandle, true);
        }

        [Obsolete("use StopPulse instead")]
        public void StopPluse()
        {
            Interop.Elementary.elm_progressbar_pulse(RealHandle, false);
        }

        public void StopPulse()
        {
            Interop.Elementary.elm_progressbar_pulse(RealHandle, false);
        }

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
