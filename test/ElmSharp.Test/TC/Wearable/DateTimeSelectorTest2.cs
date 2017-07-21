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
using System.Text;

namespace ElmSharp.Test.Wearable
{
    class DateTimeSelectorTest2 : WearableTestCase
    {
        public override string TestName => "DateTimeSelectorTest2";
        public override string TestDescription => "To test basic operation of DateTimeSelector";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();

            Background bg = new Background(window);
            bg.Color = Color.Black;
            bg.Show();
            conformant.SetContent(bg);

            DateTimeSelector dateTime = new DateTimeSelector(window)
            {
                DateTime = DateTime.Today,
                Style = "time_layout",
                Format = "%I:%M %p"
            };

            dateTime.Geometry = new Rect(0, 0, window.ScreenSize.Width, window.ScreenSize.Height);
            dateTime.Show();

            dateTime.DateTimeChanged += (object sender, DateChangedEventArgs e) =>
            {
                Log.Debug($"Old DateTime={e.OldDate}");
                Log.Debug($"New DateTime={e.NewDate}");
                Log.Debug($"Current DateTime={dateTime.DateTime}");
            };
        }
    }
}
