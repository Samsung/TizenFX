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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ElmSharp
{
    public class Calendar : Layout
    {
        private SmartEvent _changed;
        private DateTime _cacheSelectedDate;
        private SmartEvent _displayedMonthChanged;
        private int _cacheDisplayedMonth;

        public Calendar(EvasObject parent) : base(parent)
        {
            _changed = new SmartEvent(this, this.RealHandle, "changed");
            _changed.On += (sender, e) =>
            {
                DateTime selectedDate = SelectedDate;
                DateChanged?.Invoke(this, new DateChangedEventArgs(_cacheSelectedDate, selectedDate));
                _cacheSelectedDate = selectedDate;
            };

            _displayedMonthChanged = new SmartEvent(this, this.RealHandle, "display,changed");
            _displayedMonthChanged.On += (sender, e) =>
            {
                int currentDisplayedMonth = SelectedDate.Month;
                DisplayedMonthChanged?.Invoke(this, new DisplayedMonthChangedEventArgs(_cacheDisplayedMonth, currentDisplayedMonth));
                _cacheDisplayedMonth = currentDisplayedMonth;
            };
        }

        public event EventHandler<DateChangedEventArgs> DateChanged;

        public event EventHandler<DisplayedMonthChangedEventArgs> DisplayedMonthChanged;

        public int MinimumYear
        {
            get
            {
                int minimumYear;
                int unused;
                Interop.Elementary.elm_calendar_min_max_year_get(RealHandle, out minimumYear, out unused);
                return minimumYear;
            }
            set
            {
                int maximumYear;
                int unused;
                Interop.Elementary.elm_calendar_min_max_year_get(RealHandle, out unused, out maximumYear);
                Interop.Elementary.elm_calendar_min_max_year_set(RealHandle, value, maximumYear);
            }
        }

        public int MaximumYear
        {
            get
            {
                int maximumYear;
                int unused;
                Interop.Elementary.elm_calendar_min_max_year_get(RealHandle, out unused, out maximumYear);
                return maximumYear;
            }
            set
            {
                int minimumYear;
                int unused;
                Interop.Elementary.elm_calendar_min_max_year_get(RealHandle, out minimumYear, out unused);
                Interop.Elementary.elm_calendar_min_max_year_set(RealHandle, minimumYear, value);
            }
        }

        public DayOfWeek FirstDayOfWeek
        {
            get
            {
                return (DayOfWeek)Interop.Elementary.elm_calendar_first_day_of_week_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_calendar_first_day_of_week_set(RealHandle, (int)value);
            }
        }

        public IReadOnlyList<string> WeekDayNames
        {
            get
            {
                IntPtr stringArrayPtr = Interop.Elementary.elm_calendar_weekdays_names_get(RealHandle);
                string[] stringArray;
                IntPtrToStringArray(stringArrayPtr, 7, out stringArray);
                return stringArray;
            }
            set
            {
                if (value != null && value.Count == 7)
                {
                    Interop.Elementary.elm_calendar_weekdays_names_set(RealHandle, value.ToArray());
                }
            }
        }

        public DateTime SelectedDate
        {
            get
            {
                var tm = new Interop.Libc.SystemTime();
                Interop.Elementary.elm_calendar_selected_time_get(RealHandle, ref tm);
                return tm;
            }
            set
            {
                Interop.Libc.SystemTime tm = value;
                Interop.Elementary.elm_calendar_selected_time_set(RealHandle, ref tm);
                _cacheSelectedDate = value;
            }
        }

        public double Interval
        {
            get
            {
                return Interop.Elementary.elm_calendar_interval_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_calendar_interval_set(RealHandle, value);
            }
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = Interop.Elementary.elm_layout_add(parent.Handle);
            Interop.Elementary.elm_layout_theme_set(handle, "layout", "elm_widget", "default");

            RealHandle = Interop.Elementary.elm_calendar_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }

        static private void IntPtrToStringArray(IntPtr unmanagedArray, int size, out string[] managedArray)
        {
            managedArray = new string[size];
            IntPtr[] IntPtrArray = new IntPtr[size];

            Marshal.Copy(unmanagedArray, IntPtrArray, 0, size);

            for (int iterator = 0; iterator < size; iterator++)
            {
                managedArray[iterator] = Marshal.PtrToStringAnsi(IntPtrArray[iterator]);
            }
        }
    }
}
