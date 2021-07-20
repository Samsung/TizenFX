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
        /// <param name="time">time value of TimePicker.</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]   
        public TimeChangedEventArgs(DateTime time)
        {
            Time = time;
        }

        /// <summary>
        /// TimeChangedEventArgs default constructor.
        /// <returns>The current time value of TimePicker.</returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]   
        public DateTime Time { get; }
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
        private DateTime currentTime;
        private String[] ampmText;
        private Picker hourPicker;
        private Picker minutePicker;
        private Picker ampmPicker;

        /// <summary>
        /// Creates a new instance of TimePicker.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TimePicker()
        {
        }

        /// <summary>
        /// Creates a new instance of TimePicker.
        /// </summary>
        /// <param name="style">Creates TimePicker by special style defined in UX.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TimePicker(string style) : base(style)
        {
        }

        /// <summary>
        /// Creates a new instance of TimePicker.
        /// </summary>
        /// <param name="timePickerStyle">Creates TimePicker by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TimePicker(TimePickerStyle timePickerStyle) : base(timePickerStyle)
        {
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
        public DateTime Time
        {
            get
            {
                return currentTime;
            }
            set
            {
                currentTime = value;
                if (!is24HourView)
                {
                    if (currentTime.Hour >= 12 && currentTime.Hour <= 23)
                    {
                        isAm = false;
                        if (currentTime.Hour == 12) hourPicker.CurrentValue = currentTime.Hour;
                        else hourPicker.CurrentValue = currentTime.Hour - 12;
                        ampmPicker.CurrentValue = 2;
                    }
                    else 
                    {
                        isAm = true;
                        hourPicker.CurrentValue = currentTime.Hour;
                        ampmPicker.CurrentValue = 1;
                    }
                }
                else hourPicker.CurrentValue = currentTime.Hour;

                minutePicker.CurrentValue = currentTime.Minute;
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

                Console.WriteLine(" Is 24 Hour View");
                is24HourView = value;
                if (value == true)
                {
                    Remove(ampmPicker);
                    hourPicker.MinValue = 0;
                    hourPicker.MaxValue = 23;
                    hourPicker.CurrentValue = currentTime.Hour;
                }
                else 
                {
                    hourPicker.MinValue = 1;
                    hourPicker.MaxValue = 12;
                    PickersOrderSet(true);
                    SetAmpmText();
                    if (currentTime.Hour > 12)
                    {
                        ampmPicker.CurrentValue = 2;
                        hourPicker.CurrentValue = currentTime.Hour - 12;
                    }
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
            SetAccessibilityConstructor(Role.DateEditor);

            hourPicker = new Picker()
            {
                MinValue = 1,
                MaxValue = 12,
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

            currentTime = DateTime.Now;
            Console.WriteLine(" Time " + currentTime.Hour + " " + currentTime.Minute);
            if (currentTime.Hour > 12)
            {
                ampmPicker.CurrentValue = 2;
                hourPicker.CurrentValue = currentTime.Hour - 12;
            }
            else
                hourPicker.CurrentValue = currentTime.Hour;

            minutePicker.CurrentValue = currentTime.Minute;

            Initialize();
        }

        /// <summary>
        /// Applies style to TimePicker.
        /// </summary>
        /// <param name="viewStyle">The style to apply.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            var timePickerStyle = viewStyle as TimePickerStyle;

            if (timePickerStyle == null) return;

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
            };
            Console.WriteLine("initialize");

            is24HourView = false;

            PickersOrderSet(false);
            SetAmpmText();
        }

        private void ChangeTime(int hour, int minute, bool hourUpdate)
        {
            if (hourUpdate)
                currentTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, hour, currentTime.Minute, 0);
            else
                currentTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, currentTime.Hour, minute, 0);
        }

        private void OnHourValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (currentTime.Hour == e.Value) return;

            if (!is24HourView)
            {
                if (isAm) 
                {
                    if (e.Value == 12) ChangeTime(12, 0, true);
                    else ChangeTime(e.Value, 0, true);
                }
                else 
                {
                    if (e.Value == 12) ChangeTime(0, 0, true);
                    else ChangeTime(e.Value + 12, 0, true);
                }
            }
            else
                ChangeTime(e.Value, 0, true);
            
            OnTimeChanged();
        }

        private void OnMinuteValueChanged(object sender, ValueChangedEventArgs e)
        { 
            if (currentTime.Minute == e.Value) return;

            ChangeTime(0, e.Value, false);

            OnTimeChanged();
        }

        private void OnAmpmValueChanged(object sender, ValueChangedEventArgs e)
        { 
            if ((isAm && e.Value == 1) || (!isAm && e.Value == 2)) return;

            if (e.Value == 1)
            { //AM
                if (currentTime.Hour > 12 || currentTime.Hour == 0)
                { 
                    if (currentTime.Hour == 0) ChangeTime(12, 0, true);
                    else ChangeTime(currentTime.Hour - 12, 0, true);
                }
                isAm = true;
            }
            else 
            { //PM
                if (currentTime.Hour > 0 && currentTime.Hour <= 12)
                {
                     if (currentTime.Hour == 12) ChangeTime(0, 0, true);
                     else ChangeTime(currentTime.Hour + 12, 0, true);
                }
                isAm = false;
            }

            OnTimeChanged();
        }

        private void OnTimeChanged()
        { 
            TimeChangedEventArgs eventArgs = new TimeChangedEventArgs(currentTime);
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
