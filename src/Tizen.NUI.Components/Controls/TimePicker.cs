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
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// TimeChangedEventArgs is a class to notify changed TimePicker value argument which will sent to user.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TimeChangedEventArgs : EventArgs
    {
        /// <summary>
        /// TimeChangedEventArgs default constructor.
        /// <param name="hour">hour value of TimePicker.</param>
        /// <param name="minute">minute value of TimePicker.</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]   
        public TimeChangedEventArgs(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }

        /// <summary>
        /// TimeChangedEventArgs default constructor.
        /// <returns>The current hour value of TimePicker.</returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]   
        public int Hour { get; }

        /// <summary>
        /// TimeChangedEventArgs default constructor.
        /// <returns>The current minute value of TimePicker.</returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]   
        public int Minute { get; }
    }

    /// <summary>
    /// TimePicker is a class which provides a function that allows the user to select 
    /// a time through a scrolling motion by expressing the specified value as a list.
    /// TimePicker expresses the current time using the locale information of the system.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TimePicker : Control
    {
        private bool isAm;
        private bool is24HourView;
        private int hour;
        private int minute;
        private String[] ampmText;
        private Picker hourPicker;
        private Picker minutePicker;
        private Picker ampmPicker;
        private TimePickerStyle timePickerStyle => ViewStyle as TimePickerStyle;

        /// <summary>
        /// Creates a new instance of TimePicker.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TimePicker()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of TimePicker.
        /// </summary>
        /// <param name="style">Creates TimePicker by special style defined in UX.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TimePicker(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of TimePicker.
        /// </summary>
        /// <param name="timePickerStyle">Creates TimePicker by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TimePicker(TimePickerStyle timePickerStyle) : base(timePickerStyle)
        {
            Initialize();
        }

        /// <summary>
        /// Dispose TimePicker and all children on it.
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
                Remove(hourPicker);
                Utility.Dispose(hourPicker);
                hourPicker = null;
                Remove(minutePicker);
                Utility.Dispose(minutePicker);
                minutePicker = null;
                Remove(ampmPicker);
                Utility.Dispose(ampmPicker);
                ampmPicker = null;
            }

            base.Dispose(type);
        }

        /// <summary>
        /// An event emitted when TimePicker value changed, user can subscribe or unsubscribe to this event handler.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<TimeChangedEventArgs> TimeChanged;

        /// <summary>
        /// The hour value of TimePicker.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Hour
        {
            get
            {
                return hour;
            }
            set
            {
                if (value < 1 || value > 24 || value == hour) return;

                hour = value;
                if (!is24HourView)
                {
                    if (hour >= 12 && hour <= 23) 
                    {
                        isAm = false;
                        if (hour == 12) hourPicker.CurrentValue = hour;
                        else hourPicker.CurrentValue = hour -= 12;
                        ampmPicker.CurrentValue = 2;
                    }
                    else 
                    {
                        isAm = true;
                        hourPicker.CurrentValue = hour;
                        ampmPicker.CurrentValue = 1;
                    }
                }
                else hourPicker.CurrentValue = hour;
            }
        }

        /// <summary>
        /// The Minute value of TimePicker.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Minute
        {
            get
            {
                return minute;
            }
            set
            {
                if (value < 1 || value > 60 || value == minute) return;

                minute = value;
                minutePicker.CurrentValue = minute;
            }
        }

        /// <summary>
        /// The is24hourview value of TimePicker.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Is24HourView
        {
            get
            {
                return is24HourView;
            }
            set
            {
                if (is24HourView == value) return;

                is24HourView = value;
                if (value == true)
                {
                    Remove(ampmPicker);
                    hourPicker.MaxValue = 24;
                }
                else 
                {
                    hourPicker.MaxValue = 12;
                    PickersOrderSet(true);
                    SetAmpmText();
                }
            }
        }

        /// <summary>
        /// Initialize TimePicker object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();

            hourPicker = new Picker()
            {
                MinValue = 1,
                MaxValue = 24,
            };
            hourPicker.ValueChanged += OnHourValueChanged;

            minutePicker = new Picker()
            {
                MinValue = 0,
                MaxValue = 59,
            };
            minutePicker.ValueChanged += OnMinuteValueChanged;

            ampmPicker = new Picker()
            {
                MinValue = 1,
                MaxValue = 2,
            };
            ampmPicker.ValueChanged += OnAmpmValueChanged;
        }

        /// <summary>
        /// Applies style to TimePicker.
        /// </summary>
        /// <param name="viewStyle">The style to apply.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            //Apply CellPadding.
            if (timePickerStyle?.CellPadding != null && Layout != null)
                ((LinearLayout)Layout).CellPadding = new Size2D(timePickerStyle.CellPadding.Width, timePickerStyle.CellPadding.Height);
            
            //Apply Internal Pickers style.
            if (timePickerStyle?.Pickers != null && hourPicker != null && minutePicker != null && ampmPicker != null)
            {
                hourPicker.ApplyStyle(timePickerStyle.Pickers);
                minutePicker.ApplyStyle(timePickerStyle.Pickers);
                ampmPicker.ApplyStyle(timePickerStyle.Pickers);
            }
        }
                
        [SuppressMessage("Microsoft.Reliability",
                         "CA2000:DisposeObjectsBeforeLosingScope",
                         Justification = "The CellPadding will be dispose when the time picker disposed")]
        private void Initialize()
        {
            HeightSpecification = LayoutParamPolicies.MatchParent;

            Layout = new LinearLayout() { 
                LinearOrientation = LinearLayout.Orientation.Horizontal,
                CellPadding = new Size(timePickerStyle.CellPadding.Width, timePickerStyle.CellPadding.Height),
            };

            is24HourView = true;

            PickersOrderSet(false);

            if (!is24HourView) 
            {
                SetAmpmText();
                hourPicker.MaxValue = 12;
            }
        }

        private void OnHourValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (hour == e.Value) return;

            if (!is24HourView)
            {
                if (isAm) 
                {
                    if (e.Value == 12) hour = 24;
                    else hour = e.Value;
                }
                else 
                {
                    if (e.Value == 12) hour = 12;
                    else hour = e.Value + 12;
                }
            }
            else
                hour = e.Value;
            
            OnTimeChanged();
        }

        private void OnMinuteValueChanged(object sender, ValueChangedEventArgs e)
        { 
            if (minute == e.Value) return;

            minute = e.Value;

            OnTimeChanged();
        }

        private void OnAmpmValueChanged(object sender, ValueChangedEventArgs e)
        { 
            if ((isAm && e.Value == 1) || (!isAm && e.Value == 2)) return;

            if (e.Value == 1)
            { //AM
                if (hour >= 12 || hour < 24)
                { 
                    if (hour == 12) hour += 12;
                    else hour -= 12;
                }
                isAm = true;
            }
            else 
            { //PM
                if (hour == 24 || hour < 12) 
                {
                     if (hour == 24) hour -= 12;
                     else hour += 12; 
                }
                isAm = false;
            }

            OnTimeChanged();
        }

        private void OnTimeChanged()
        { 
            TimeChangedEventArgs eventArgs = new TimeChangedEventArgs(hour, minute);
            TimeChanged?.Invoke(this, eventArgs);
        }

        private void PickersOrderSet(bool ampmForceSet)
        {
            //FIXME: Check the pickers located in already proper position or not.
            Remove(hourPicker);
            Remove(minutePicker);
            Remove(ampmPicker);

            //Get current system locale's time pattern
            String locale = Environment.GetEnvironmentVariable("LC_TIME");
            DateTimeFormatInfo timeFormatInfo = new CultureInfo(locale, false ).DateTimeFormat;
            String timePattern = timeFormatInfo.ShortTimePattern;
            String[] timePatternArray = timePattern.Split(' ', ':');

            foreach (String format in timePatternArray) {
                if (format.IndexOf("H") != -1|| format.IndexOf("h") != -1)  Add(hourPicker);
                else if (format.IndexOf("M") != -1 || format.IndexOf("m") != -1) Add(minutePicker);
                else if (format.IndexOf("t") != -1) 
                {
                    is24HourView = false;
                    ampmForceSet = false;
                    Add(ampmPicker);
                }
            }

            if (ampmForceSet) Add(ampmPicker);
        }

        private void SetAmpmText()
        {
            //FIXME: There is no localeChanged Event for Component now
            //       AMPM text has to update when system locale changed.
            String locale = Environment.GetEnvironmentVariable("LC_TIME");
            CultureInfo info = new CultureInfo(locale);
            ampmText = new string[] {info.DateTimeFormat.AMDesignator, info.DateTimeFormat.PMDesignator};
            ampmPicker.DisplayedValues = new ReadOnlyCollection<string>(ampmText);
        }
    }
}
