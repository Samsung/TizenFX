﻿/* Copyright (c) 2021 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// DateChangedEventArgs is a class to notify changed DatePicker value argument which will sent to user.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class DateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// DateChangedEventArgs default constructor.
        /// <param name="date">date value of DatePicker.</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateChangedEventArgs(DateTime date)
        {
            Date = date;
        }

        /// <summary>
        /// DateChangedEventArgs default constructor.
        /// <returns>The current date value of DatePicker.</returns>
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public DateTime Date { get; }
    }

    /// <summary>
    /// DatePicker is a class which provides a function that allows the user to select
    /// a date through a scrolling motion by expressing the specified value as a list.
    /// DatePicker expresses the current date using the locale information of the system.
    /// Year range is 1970~2038 (glibc time_t struct min, max value)
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class DatePicker : Control
    {
        /// <summary>
        /// DateProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DateProperty = BindableProperty.Create(nameof(Date), typeof(DateTime), typeof(DatePicker), default(DateTime), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (DatePicker)bindable;
            if (newValue != null)
            {
                instance.InternalDate = (DateTime)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (DatePicker)bindable;
            return instance.InternalDate;
        });

        private DateTime currentDate;
        private Picker dayPicker;
        private Picker monthPicker;
        private Picker yearPicker;

        /// <summary>
        /// Creates a new instance of DatePicker.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public DatePicker()
        {
            SetKeyboardNavigationSupport(true);
        }

        /// <summary>
        /// Creates a new instance of DatePicker.
        /// </summary>
        /// <param name="style">Creates DatePicker by special style defined in UX.</param>
        /// <since_tizen> 9 </since_tizen>
        public DatePicker(string style) : base(style)
        {
            SetKeyboardNavigationSupport(true);
        }

        /// <summary>
        /// Creates a new instance of DatePicker.
        /// </summary>
        /// <param name="datePickerStyle">Creates DatePicker by style customized by user.</param>
        /// <since_tizen> 9 </since_tizen>
        public DatePicker(DatePickerStyle datePickerStyle) : base(datePickerStyle)
        {
            SetKeyboardNavigationSupport(true);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnEnabled(bool enabled)
        {
            base.OnEnabled(enabled);

            dayPicker.IsEnabled = enabled;
            monthPicker.IsEnabled = enabled;
            yearPicker.IsEnabled = enabled;
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
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<DateChangedEventArgs> DateChanged;

        /// <summary>
        /// The Date value of DatePicker.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public DateTime Date
        {
            get
            {
                return (DateTime)GetValue(DateProperty);
            }
            set
            {
                SetValue(DateProperty, value);
                NotifyPropertyChanged();
            }
        }
        private DateTime InternalDate
        {
            get
            {
                return currentDate;
            }
            set
            {
                currentDate = value;
                dayPicker.CurrentValue = currentDate.Day;
                monthPicker.CurrentValue = currentDate.Month;
                yearPicker.CurrentValue = currentDate.Year;
            }
        }

        /// <summary>
        /// Initialize TimePicker object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();
            AccessibilityRole = Role.DateEditor;

            dayPicker = new Picker()
            {
                MinValue = 1,
                MaxValue = 31,
                Focusable = true,
            };
            dayPicker.ValueChanged += OnDayValueChanged;

            monthPicker = new Picker()
            {
                MinValue = 1,
                MaxValue = 12,
                Focusable = true,
            };
            monthPicker.ValueChanged += OnMonthValueChanged;

            yearPicker = new Picker()
            {
                MinValue = 1970,
                MaxValue = 2100,
                Focusable = true,
            };
            yearPicker.ValueChanged += OnYearValueChanged;

            currentDate = DateTime.Now;
            dayPicker.CurrentValue = currentDate.Day;
            monthPicker.CurrentValue = currentDate.Month;
            yearPicker.CurrentValue = currentDate.Year;

            Initialize();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [SuppressMessage("Microsoft.Reliability",
                         "CA2000:DisposeObjectsBeforeLosingScope",
                         Justification = "The CellPadding will be dispose when the date picker disposed")]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            if (viewStyle is DatePickerStyle datePickerStyle && Layout is LinearLayout linearLayout)
            {
                linearLayout.CellPadding = new Size(datePickerStyle.CellPadding.Width, datePickerStyle.CellPadding.Height);

                yearPicker.ApplyStyle(datePickerStyle.Pickers);
                monthPicker.ApplyStyle(datePickerStyle.Pickers);
                dayPicker.ApplyStyle(datePickerStyle.Pickers);
            }
        }

        /// <summary>
        /// ToDo : only key navigation is enabled, and value editing is added as an very simple operation. by toggling enter key, it switches edit mode.
        /// ToDo : this should be fixed and changed properly by owner. (And UX SPEC should be referenced also)
        /// </summary>
        /// <param name="currentFocusedView"></param>
        /// <param name="direction"></param>
        /// <param name="loopEnabled"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override View GetNextFocusableView(View currentFocusedView, View.FocusDirection direction, bool loopEnabled)
        {
            if (currentFocusedView == yearPicker)
            {
                if (direction == View.FocusDirection.Right)
                {
                    return monthPicker;
                }
            }
            else if (currentFocusedView == monthPicker)
            {
                if (direction == View.FocusDirection.Right)
                {
                    return dayPicker;
                }
                else if (direction == View.FocusDirection.Left)
                {
                    return yearPicker;
                }
            }
            else if (currentFocusedView == dayPicker)
            {
                if (direction == View.FocusDirection.Left)
                {
                    return monthPicker;
                }
            }
            return null;
        }

        private void Initialize()
        {
            Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Horizontal,
            };

            PickersOrderSet();
            SetMonthText();
            MaxDaySet(currentDate.Year, currentDate.Month);
        }

        private void OnDayValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (currentDate.Day == e.Value) return;

            currentDate = new DateTime(currentDate.Year, currentDate.Month, e.Value);

            OnDateChanged();
        }

        private void OnMonthValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (currentDate.Month == e.Value) return;

            MaxDaySet(currentDate.Year, e.Value);

            OnDateChanged();
        }

        private void OnYearValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (currentDate.Year == e.Value) return;

            MaxDaySet(e.Value, currentDate.Month);

            OnDateChanged();
        }

        private void OnDateChanged()
        {
            DateChangedEventArgs eventArgs = new DateChangedEventArgs(currentDate);
            DateChanged?.Invoke(this, eventArgs);
        }

        private void MaxDaySet(int year, int month)
        {
            int maxDaysInMonth = DateTime.DaysInMonth(year, month);
            dayPicker.MaxValue = maxDaysInMonth;
            if (currentDate.Day > maxDaysInMonth)
            {
                currentDate = new DateTime(year, month, maxDaysInMonth);
                dayPicker.CurrentValue = maxDaysInMonth;
                return;
            }
            currentDate = new DateTime(year, month, currentDate.Day);
        }

        //FIXME: There is no way to know when system locale changed in NUI.
        //       Pickers order and Month text has to be follow system locale.
        private void PickersOrderSet()
        {
            DateTimeFormatInfo DateFormat = CultureInfo.CurrentCulture.DateTimeFormat;
            String temp = DateFormat.ShortDatePattern;
            String[] strArray = temp.Split(' ', '/');
            foreach (String format in strArray)
            {
                if (format.IndexOf("M") != -1 || format.IndexOf("m") != -1) Add(monthPicker);
                else if (format.IndexOf("d") != -1 || format.IndexOf("D") != -1) Add(dayPicker);
                else if (format.IndexOf("y") != -1 || format.IndexOf("Y") != -1) Add(yearPicker);
            }
        }

        private void SetMonthText()
        {
            CultureInfo info = CultureInfo.CurrentCulture;
            monthPicker.DisplayedValues = new ReadOnlyCollection<string>(info.DateTimeFormat.AbbreviatedMonthNames);
        }
    }
}
