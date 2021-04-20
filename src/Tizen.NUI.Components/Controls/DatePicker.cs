/* Copyright (c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Diagnostics.CodeAnalysis;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// DateChangedEventArgs is a class to notify changed DatePicker value argument which will sent to user.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// DateChangedEventArgs default constructor.
        /// <param name="month">month value of DatePicker.</param>
        /// <param name="day">day value of DatePicker.</param>
        /// <param name="year">year value of DatePicker.</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]   
        public DateChangedEventArgs(int month, int day, int year)
        {
            Month = month;
            Day = day;
            Year = year;
        }

        /// <summary>
        /// DateChangedEventArgs default constructor.
        /// <returns>The current month value of DatePicker.</returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]   
        public int Month { get; }

        /// <summary>
        /// DateChangedEventArgs default constructor.
        /// <returns>The current day value of DatePicker.</returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]   
        public int Day { get; }

        /// <summary>
        /// DateChangedEventArgs default constructor.
        /// <returns>The current year value of DatePicker.</returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]   
        public int Year { get; }
    }

    /// <summary>
    /// DatePicker is a class which provides a function that allows the user to select 
    /// a date through a scrolling motion by expressing the specified value as a list.
    /// DatePicker expresses the current date using the locale information of the system.
    /// Year range is 1970~2038 (glibc time_t struct min, max value)
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DatePicker : Control
    {
        private int day;
        private int month;
        private int year;
        private Picker dayPicker;
        private Picker monthPicker;
        private Picker yearPicker;
        private DatePickerStyle datePickerStyle => ViewStyle as DatePickerStyle;
        
        /// <summary>
        /// Creates a new instance of DatePicker.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DatePicker()
        {
            Initialize();
        }
        
        /// <summary>
        /// Creates a new instance of DatePicker.
        /// </summary>
        /// <param name="style">Creates DatePicker by special style defined in UX.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DatePicker(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of DatePicker.
        /// </summary>
        /// <param name="datePickerStyle">Creates DatePicker by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DatePicker(DatePickerStyle datePickerStyle) : base(datePickerStyle)
        {
            Initialize();
        }


        /// <summary>
        /// Dispose DatePicker and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                Remove(monthPicker);
                Utility.Dispose(monthPicker);
                monthPicker = null;
                Remove(dayPicker);
                Utility.Dispose(dayPicker);
                dayPicker = null;
                Remove(yearPicker);
                Utility.Dispose(yearPicker);
                yearPicker = null;
            }

            base.Dispose(type);
        }

        /// <summary>
        /// An event emitted when DatePicker value changed, user can subscribe or unsubscribe to this event handler.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<DateChangedEventArgs> DateChanged;
        
        /// <summary>
        /// The month value of DatePicker.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Month
        {
            get
            {
                return month;
            }
            set
            {
                if (value < 1 || value > 12 || value == month) return;

                month = value;
                monthPicker.CurrentValue = month;
            }
        }

        /// <summary>
        /// The day value of DatePicker.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Day
        {
            get
            {
                return day;
            }
            set
            {
                if (value < 1 || value > 31 || value == day) return;

                day = value;
                dayPicker.CurrentValue = day;
            }
        }

        /// <summary>
        /// The year value of DatePicker.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                if (value < 1970 || value > 2038 || value == year) return;

                year = value;
                yearPicker.CurrentValue = year;
            }
        }

                /// <summary>
        /// Initialize TimePicker object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();

            dayPicker = new Picker()
            {
                MinValue = 1,
                MaxValue = 31,
            };
            dayPicker.ValueChanged += OnDayValueChanged;

            monthPicker = new Picker()
            {
                MinValue = 1,
                MaxValue = 12,
            };
            monthPicker.ValueChanged += OnMonthValueChanged;

            yearPicker = new Picker()
            {
                MinValue = 1970,
                MaxValue = 2038,
            };
            yearPicker.ValueChanged += OnYearValueChanged;

            //FIXME: Changes it to get current system date.
            day = 1;
            month = 1;
            year = 1970;
        }
    
        [SuppressMessage("Microsoft.Reliability",
                         "CA2000:DisposeObjectsBeforeLosingScope",
                         Justification = "The CellPadding will be dispose when the date picker disposed")]
        private void Initialize()
        {
            HeightSpecification = LayoutParamPolicies.MatchParent;

            Layout = new LinearLayout() { 
                LinearOrientation = LinearLayout.Orientation.Horizontal,
                CellPadding = new Size(datePickerStyle.CellPadding.Width, datePickerStyle.CellPadding.Height),
            };

            PickersOrderSet();
            SetMonthText();
            MaxDaySet();
        }

        private void OnDayValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (day == e.Value) return;

            day = e.Value;
            
            OnDateChanged();
        }

        private void OnMonthValueChanged(object sender, ValueChangedEventArgs e)
        { 
            if (Month == e.Value) return;

            Month = e.Value;
            MaxDaySet();

            OnDateChanged();
        }

        private void OnYearValueChanged(object sender, ValueChangedEventArgs e)
        { 
            if (Year == e.Value) return;

            Year = e.Value;

            OnDateChanged();
        }

        private void OnDateChanged()
        { 
            DateChangedEventArgs eventArgs = new DateChangedEventArgs(day, month, year);
            DateChanged?.Invoke(this, eventArgs);
        }

        private void MaxDaySet()
        {
            int maxDaysInMonth = DateTime.DaysInMonth(year, month);
            dayPicker.MaxValue = maxDaysInMonth;
            if (day > maxDaysInMonth) 
            {
                day = maxDaysInMonth;
                dayPicker.CurrentValue = day;
            }
        }

        //FIXME: There is no way to know when system locale changed in NUI.
        //       Pickers order and Month text has to be follow system locale.
        private void PickersOrderSet()
        {           
            String locale = Environment.GetEnvironmentVariable("LC_TIME");
            DateTimeFormatInfo DateFormat = new CultureInfo(locale, false ).DateTimeFormat;
            String temp = DateFormat.ShortDatePattern;
            String[] strArray = temp.Split(' ', '/');
            foreach (String format in strArray) {
                if (format.IndexOf("M") != -1|| format.IndexOf("m") != -1)  Add(monthPicker);
                else if (format.IndexOf("d") != -1 || format.IndexOf("D") != -1) Add(dayPicker);
                else if (format.IndexOf("y") != -1 || format.IndexOf("Y") != -1) Add(yearPicker);
            }
        }

        private void SetMonthText()
        {
            String locale = Environment.GetEnvironmentVariable("LC_TIME");
            CultureInfo info = new CultureInfo(locale);
            monthPicker.DisplayedValues = new ReadOnlyCollection<string>(info.DateTimeFormat.AbbreviatedMonthNames);
        }
    }
}
