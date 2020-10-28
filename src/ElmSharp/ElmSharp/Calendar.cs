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
    /// Enumeration for event periodicity, used to define if a mark should be repeated beyond the event's day. It's set when a mark is added.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum CalendarMarkRepeatType
    {
        /// <summary>
        /// Default value. Marks will be displayed only on the event day.
        /// </summary>
        Unique,

        /// <summary>
        /// Marks will be displayed every day after the event day.
        /// </summary>
        Daily,

        /// <summary>
        /// Marks will be displayed every week after the event day.
        /// </summary>
        Weekly,

        /// <summary>
        /// Marks will be displayed every month that coincides to the event day.
        /// </summary>
        Monthly,

        /// <summary>
        /// Marks will be displayed every year that coincides to the event day.
        /// </summary>
        Annually,

        /// <summary>
        /// Marks will be displayed every last day of month after the event day.
        /// </summary>
        LastDayOfMonth
    }

    /// <summary>
    /// Enumeration for the mode, which determines how a user could select a day.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum CalendarSelectMode
    {
        /// <summary>
        /// Default value. A day is always selected.
        /// </summary>
        Default,

        /// <summary>
        /// A day is always selected.
        /// </summary>
        Always,

        /// <summary>
        /// None of the days can be selected.
        /// </summary>
        None,

        /// <summary>
        /// User may have selected a day.
        /// </summary>
        OnDemand
    }

    /// <summary>
    /// Enumeration for defining which fields of a tm struct will be taken into account.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    [Flags]
    public enum CalendarSelectable
    {
        /// <summary>
        /// None will be taken into account.
        /// </summary>
        None = 0,
        /// <summary>
        /// Year will be taken into account.
        /// </summary>
        Year = 1 << 0,
        /// <summary>
        /// Month will be taken into account.
        /// </summary>
        Month = 1 << 1,
        /// <summary>
        /// Day will be taken into account.
        /// </summary>
        Day = 1 << 2
    }

    /// <summary>
    /// The CalendarMark is an item for marking a Calendar's type, date, and repeat type.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class CalendarMark
    {
        internal IntPtr Handle;

        /// <summary>
        /// A string used to define the type of mark.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public string Type;

        /// <summary>
        /// A time struct to represent the date of inclusion of the mark.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public DateTime Date;

        /// <summary>
        /// Repeats the event following this periodicity.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public CalendarMarkRepeatType Repeat;

        /// <summary>
        /// Creates and initializes a new instance of the CalendarMark class.
        /// </summary>
        /// <param name="type">Type of mark.</param>
        /// <param name="date">Date of inclusion of the mark.</param>
        /// <param name="repeat">Repeat type.</param>
        /// <since_tizen> preview </since_tizen>
        public CalendarMark(string type, DateTime date, CalendarMarkRepeatType repeat)
        {
            Handle = IntPtr.Zero;
            Type = type;
            Date = date;
            Repeat = repeat;
        }
    }

    /// <summary>
    /// The Calendar is a widget that helps applications to flexibly display a calender with day of the week, date, year, and month.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class Calendar : Layout
    {
        SmartEvent _changed;
        DateTime _cacheSelectedDate;
        SmartEvent _displayedMonthChanged;
        int _cacheDisplayedMonth;

        Interop.Elementary.Elm_Calendar_Format_Cb _calendarFormat;
        DateFormatDelegate _dateFormatDelegate = null;

        /// <summary>
        /// Creates and initializes a new instance of the Calendar class.
        /// </summary>
        /// <param name="parent">
        /// The EvasObject to which the new calendar will be attached as a child.
        /// </param>
        /// <since_tizen> preview </since_tizen>
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
                int currentDisplayedMonth = DisplayedTime.Month;
                DisplayedMonthChanged?.Invoke(this, new DisplayedMonthChangedEventArgs(_cacheDisplayedMonth, currentDisplayedMonth));
                _cacheDisplayedMonth = currentDisplayedMonth;
            };

            _calendarFormat = (ref Interop.Libc.SystemTime t) => { return _dateFormatDelegate(t); };
        }

        /// <summary>
        /// DateChanged will be triggered when the date in the calendar is changed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<DateChangedEventArgs> DateChanged;

        /// <summary>
        /// DisplayedMonthChanged will be triggered when the current month displayed in the calendar is changed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<DisplayedMonthChangedEventArgs> DisplayedMonthChanged;

        /// <summary>
        /// This delegate type is used to format the string that will be used to display month and year.
        /// </summary>
        /// <param name="time">DateTime</param>
        /// <returns></returns>
        /// <since_tizen> preview </since_tizen>
        public delegate string DateFormatDelegate(DateTime time);

        /// <summary>
        /// Sets or gets the minimum for year.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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
                if (maximumYear < 1902)
                {
                    maximumYear = DateTime.MaxValue.Year;
                }
                Interop.Elementary.elm_calendar_min_max_year_set(RealHandle, value, maximumYear);
            }
        }

        /// <summary>
        /// Sets or gets the maximum for the year.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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
        /// Sets or gets the first day of the week, which is used on the calendar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public DateTime DisplayedTime
        {
            get
            {
                Interop.Elementary.elm_calendar_displayed_time_get(RealHandle, out Interop.Libc.SystemTime tm);
                // TODO
                // If the defect is fixed, it will be removed.
                var daysInMonth = DateTime.DaysInMonth(tm.tm_year + 1900, tm.tm_mon + 1);
                var day = tm.tm_mday;

                if (day > daysInMonth)
                {
                    day = daysInMonth;
                }

                DateTime date = new DateTime(tm.tm_year + 1900, tm.tm_mon + 1, day, tm.tm_hour, tm.tm_min, tm.tm_sec);

                return date;
            }
        }

        /// <summary>
        /// Sets or gets the first day of the week, which is used on the calendar.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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
        /// Sets or gets the weekdays name to be displayed by the calendar.
        /// </summary>
        /// <remarks>
        /// The usage should be like this:
        /// <![CDATA[List<string> weekDayNames = new List<string>() { "S", "M", "T", "W", "T", "F", "S" };]]>
        /// Calendar.WeekDayNames = weekDayNames;
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
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
        /// The selected date changes when the user goes to the next/previous month or selects a day pressing over it on the calendar.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public DateTime SelectedDate
        {
            get
            {
                var tm = new Interop.Libc.SystemTime();
                Interop.Elementary.elm_calendar_selected_time_get(RealHandle, ref tm);
                if (tm.tm_year == 0 && tm.tm_mon == 0 && tm.tm_mday == 0)
                {
                    return DateTime.Now;
                }
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
        /// Sets or gets the interval on time updates for a user mouse button
        /// hold, on the calendar widgets' month/year selection.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Gets or sets the select day mode used.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public CalendarSelectMode SelectMode
        {
            get
            {
                return (CalendarSelectMode)Interop.Elementary.elm_calendar_select_mode_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_calendar_select_mode_set(RealHandle, (Interop.Elementary.Elm_Calendar_Select_Mode)value);
            }
        }

        /// <summary>
        /// Gets or sets the fields of a datetime that will be taken into account, when SelectedDate set is invoked.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public CalendarSelectable Selectable
        {
            get
            {
                return (CalendarSelectable)Interop.Elementary.elm_calendar_selectable_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_calendar_selectable_set(RealHandle, (int)value);
            }
        }

        /// <summary>
        /// Gets or sets the date format of the string that will be used to display month and year.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public DateFormatDelegate DateFormat
        {
            get
            {
                return _dateFormatDelegate;
            }
            set
            {
                _dateFormatDelegate = value;
                if (value != null)
                {
                    Interop.Elementary.elm_calendar_format_function_set(RealHandle, _calendarFormat);
                }
                else
                {
                    Interop.Elementary.elm_calendar_format_function_set(RealHandle, null);
                }
            }
        }

        /// <summary>
        /// Adds a new mark to the calendar.
        /// </summary>
        /// <param name="type">A string used to define the type of mark. It will be emitted to the theme that should display a related modification on these day's representation.</param>
        /// <param name="date">A time struct to represent the date of inclusion of the mark. For marks that repeat, it will just be displayed after the inclusion date in the calendar.</param>
        /// <param name="repeat">Repeat the event following this periodicity. Can be a unique mark (that doesn't repeat), daily, weekly, monthly, or annually.</param>
        /// <returns>Item for a calendar mark.</returns>
        /// <since_tizen> preview </since_tizen>
        public CalendarMark AddMark(string type, DateTime date, CalendarMarkRepeatType repeat)
        {
            CalendarMark mark = new CalendarMark(type, date, repeat);
            Interop.Libc.SystemTime tm = date;
            IntPtr nativeHandle = Interop.Elementary.elm_calendar_mark_add(RealHandle, type, ref tm, (Interop.Elementary.Elm_Calendar_Mark_Repeat_Type)repeat);
            mark.Handle = nativeHandle;

            return mark;
        }

        /// <summary>
        /// Deletes a mark from the calendar.
        /// </summary>
        /// <param name="mark">Item for a calendar mark.</param>
        /// <since_tizen> preview </since_tizen>
        public void DeleteMark(CalendarMark mark)
        {
            Interop.Elementary.elm_calendar_mark_del(mark.Handle);
        }

        /// <summary>
        /// Draws the calendar marks.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void DrawMarks()
        {
            Interop.Elementary.elm_calendar_marks_draw(RealHandle);
        }

        /// <summary>
        /// Removes all the calendar's marks.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void ClearMarks()
        {
            Interop.Elementary.elm_calendar_marks_clear(RealHandle);
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

            RealHandle = Interop.Elementary.elm_calendar_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }

        static void IntPtrToStringArray(IntPtr unmanagedArray, int size, out string[] managedArray)
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