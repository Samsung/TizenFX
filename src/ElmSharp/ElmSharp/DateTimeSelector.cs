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
    public enum DateTimeFieldType
    {
        Year,
        Month,
        Date,
        Hour,
        Minute,
        AmPm
    }

    public class DateTimeSelector : Layout
    {
        SmartEvent _changed;
        DateTime _cacheDateTime;

        public DateTimeSelector(EvasObject parent) : base(parent)
        {
            _changed = new SmartEvent(this, this.RealHandle, "changed");
            _changed.On += (s, e) =>
            {
                DateTime newDateTime = DateTime;
                DateTimeChanged?.Invoke(this, new DateChangedEventArgs(_cacheDateTime, newDateTime));
                DateTime = newDateTime;
            };
        }

        public event EventHandler<DateChangedEventArgs> DateTimeChanged;

        public string Format
        {
            get
            {
                return Interop.Elementary.elm_datetime_format_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_datetime_format_set(RealHandle, value);
            }
        }

        public DateTime MaximumDateTime
        {
            get
            {
                var tm = new Interop.Libc.SystemTime();
                Interop.Elementary.elm_datetime_value_max_get(RealHandle, ref tm);
                return tm;
            }
            set
            {
                Interop.Libc.SystemTime tm = value;
                Interop.Elementary.elm_datetime_value_max_set(RealHandle, ref tm);
            }
        }

        public DateTime MinimumDateTime
        {
            get
            {
                var tm = new Interop.Libc.SystemTime();
                Interop.Elementary.elm_datetime_value_min_get(RealHandle, ref tm);
                return tm;
            }
            set
            {
                Interop.Libc.SystemTime tm = value;
                Interop.Elementary.elm_datetime_value_min_set(RealHandle, ref tm);
            }
        }

        public DateTime DateTime
        {
            get
            {
                var tm = new Interop.Libc.SystemTime();
                Interop.Elementary.elm_datetime_value_get(RealHandle, ref tm);
                return tm;
            }
            set
            {
                Interop.Libc.SystemTime tm = value;
                Interop.Elementary.elm_datetime_value_set(RealHandle, ref tm);
                _cacheDateTime = value;
            }
        }

        public bool IsFieldVisible(DateTimeFieldType type)
        {
            return Interop.Elementary.elm_datetime_field_visible_get(RealHandle, (int)type);
        }

        public void SetFieldLimit(DateTimeFieldType type, int minimum, int maximum)
        {
            Interop.Elementary.elm_datetime_field_limit_set(RealHandle, (int)type, minimum, maximum);
        }

        public void SetFieldVisible(DateTimeFieldType type, bool visible)
        {
            Interop.Elementary.elm_datetime_field_visible_set(RealHandle, (int)type, visible);
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = Interop.Elementary.elm_layout_add(parent.Handle);
            Interop.Elementary.elm_layout_theme_set(handle, "layout", "elm_widget", "default");

            RealHandle = Interop.Elementary.elm_datetime_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }
    }
}
