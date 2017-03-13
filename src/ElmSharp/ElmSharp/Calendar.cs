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
    /// <summary>
    /// The Calendar is a widget that helps applications to flexibly display a calender with day of the week, date, year and month.
    /// </summary>
    public class Calendar : Layout
    {
        private SmartEvent _changed;
        private DateTime _cacheSelectedDate;
        private SmartEvent _displayedMonthChanged;
        private int _cacheDisplayedMonth;

        /// <summary>
        /// Creates and initializes a new instance of the Calendar class.
        /// </summary>
        /// <param name="parent">
        /// The EvasObject to which the new Calendar will be attached as a child.
        /// </param>
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

        /// <summary>
        /// DateChanged will be triggered when the date in the calendar is changed.
        /// </summary>
        public event EventHandler<DateChangedEventArgs> DateChanged;

        /// <summary>
        /// DisplayedMonthChanged will be triggered when the current month displayed in the calendar is changed.
        /// </summary>
        public event EventHandler<DisplayedMonthChangedEventArgs> DisplayedMonthChanged;

        /// <summary>
        /// Sets or gets the minimum for year.
        /// </summary>
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

        /// <summary>
        /// Sets or gets the maximum for the year.
        /// </summary>
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

        /// <summary>
        /// Sets or gets the first day of week, who are used on Calendar.
        /// </summary>
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

        /// <summary>
        /// Sets or gets the weekdays names to be displayed by the Calendar.
        /// </summary>
        /// <remarks>
        /// The usage should be like this;
        /// List<string> weekDayNames = new List<string>() { "S", "M", "T", "W", "T", "F", "S" };
        /// Calendar.WeekDayNames = weekDayNames;
        /// </remarks>
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

        /// <summary>
        /// Sets or gets the selected date.
        /// </summary>
        /// <remarks>
        /// Selected date changes when the user goes to next/previous month or select a day pressing over it on calendar.
        /// </remarks>
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

        /// <summary>
        /// Sets or gets the interval on time updates for an user mouse button
        /// hold on calendar widgets' month/year selection.
        /// </summary>
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
