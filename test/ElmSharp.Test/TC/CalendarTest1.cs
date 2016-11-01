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
using ElmSharp;

namespace ElmSharp.Test
{
    class CalendarTest1 : TestCaseBase
    {
        public override string TestName => "CalendarTest1";
        public override string TestDescription => "To test basic operation of Calendar";

        public override void Run(Window window)
        {
            Background bg = new Background(window);
            bg.Color = Color.White;
            bg.Move(0, 0);
            bg.Resize(window.ScreenSize.Width, window.ScreenSize.Height);
            bg.Show();

            Calendar calendar = new Calendar(window)
            {
                FirstDayOfWeek = DayOfWeek.Monday,
                WeekDayNames = new List<string>() { "S", "M", "T", "W", "T", "F", "S" }
            };

            Label label1 = new Label(window) {
                Text = string.Format("WeekDayLabel.Count={0}", calendar.WeekDayNames.Count),
            };

            Label label2 = new Label(window) {
                Text = string.Format("WeekDayLabel.FirstDayOfWeek={0}", calendar.FirstDayOfWeek),
            };

            Label label3 = new Label(window) {
                Text = string.Format("WeekDayLabel.SelectedDate={0}", calendar.SelectedDate),
            };

            calendar.DateChanged += (object sender, DateChangedEventArgs e) =>
            {
                label1.Text = string.Format("Old.Day={0}, Month={1}, Year={2}", e.OldDate.Day, e.OldDate.Month, e.OldDate.Year);
                label2.Text = string.Format("New.Day={0}, Month={1}, Year={2}", e.NewDate.Day, e.NewDate.Month, e.NewDate.Year);
            };

            calendar.DisplayedMonthChanged += (object sender, DisplayedMonthChangedEventArgs e) =>
            {
                label3.Text = string.Format("Old Month={0}, New Month={1}", e.OldMonth, e.NewMonth);
            };

            calendar.Resize(600, 600);
            calendar.Move(0, 300);
            calendar.Show();

            label1.Resize(600, 100);
            label1.Move(0, 0);
            label1.Show();

            label2.Resize(600, 100);
            label2.Move(0, 100);
            label2.Show();

            label3.Resize(600, 100);
            label3.Move(0, 200);
            label3.Show();
        }

    }
}