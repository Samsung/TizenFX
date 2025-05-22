/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.Components;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NUITizenGallery
{
    public partial class TimePickerTestPage : ContentPage
    {
        private DateTime time;
        private TimePicker timePicker;
        private bool is24hr = false;

        private void timeButtonClicked(object sender, ClickedEventArgs e)
        {
            timePicker = new TimePicker()
            {
                //Should give a size to picker for content of AlertDialog
                Size = new Size(600, 339),
                Time = time,
            };
            timePicker.Is24HourView = is24hr;
            if (is24hr)
                timePicker.Size = new Size(380, 339);

            var btn1 = new Button() { Text = "Set", };
            btn1.Clicked += (object s, ClickedEventArgs a) =>
            {
                time = timePicker.Time;
                text1.Text=timePicker.Time.Hour + ":" + timePicker.Time.Minute;
                Navigator?.Pop();
            };

            var btn2 = new Button() { Text = "Cancel", };
            btn2.Clicked += (object s, ClickedEventArgs a) =>
            {
                Navigator?.Pop();
            };

            View[] actions = {btn1, btn2};
            var dialogPage = new DialogPage()
            {
                Content = new AlertDialog()
                {
                    Title = "Set Date",
                    Content = timePicker,
                    Actions =  actions,
                },
            };

            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(dialogPage);
        }

        private void setNowButtonClicked(object sender, ClickedEventArgs e)
        {
            time = DateTime.Now;
            text1.Text= time.Hour + ":" + time.Minute;
        }

        private void changePickerStyleButtonClicked(object sender, ClickedEventArgs e)
        {
            if (is24hr== false)
                is24hr= true;
            else
                is24hr= false;
        }

        public TimePickerTestPage()
        {
            InitializeComponent();
            time = DateTime.Now;
            text1.Text= time.Hour + ":" + time.Minute;
            timeButton.Clicked += timeButtonClicked;
            setNowButton.Clicked += setNowButtonClicked;
            changePickerStyleButton.Clicked += changePickerStyleButtonClicked;
        }
    }
}
