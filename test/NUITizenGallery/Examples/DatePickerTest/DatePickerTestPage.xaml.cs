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
    public partial class DatePickerTestPage : ContentPage
    {
        private DateTime date;
        private DatePicker datePicker;

        private void dateButtonClicked(object sender, ClickedEventArgs e)
        {
            datePicker = new DatePicker()
            {
                Size = new Size(600, 339),
                Date = date,
            };

            var btn1 = new Button() { Text = "Set", };
            btn1.Clicked += (object s, ClickedEventArgs a) =>
            {
                date = datePicker.Date;
                text1.Text=datePicker.Date.Year + "/" + datePicker.Date.Month + "/" + datePicker.Date.Day;
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
                    Content = datePicker,
                    Actions =  actions,
                },
            };

            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(dialogPage);
        }

        private void setMinButtonClicked(object sender, ClickedEventArgs e)
        {
            text1.Text="1970/1/1";
            date = new DateTime(1970, 1, 1);
        }

        private void setMaxButtonClicked(object sender, ClickedEventArgs e)
        {
            text1.Text="2100/12/31";
            date = new DateTime(2100, 12, 31);
        }

        public DatePickerTestPage()
        {
            InitializeComponent();
            date = DateTime.Now;
            text1.Text= date.Year + "/" + date.Month + "/" + date.Day;
            dateButton.Clicked += dateButtonClicked;
            setMinButton.Clicked += setMinButtonClicked;
            setMaxButton.Clicked += setMaxButtonClicked;
        }
    }
}
