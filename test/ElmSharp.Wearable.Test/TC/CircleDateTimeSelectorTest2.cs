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
using ElmSharp.Wearable;

namespace ElmSharp.Test.TC
{
    class CircleDateTimeSelectorTest2 : TestCaseBase
    {
        public override string TestName => "CircleDateTimeSelectorTest2";
        public override string TestDescription => "To display a date time selector with circle UI";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();

            Layout layout = new Layout(window);

            layout.SetTheme("layout", "circle", "datetime");

            conformant.SetContent(layout);

            var surface = new CircleSurface(conformant);

            var datetime = new CircleDateTimeSelector(conformant, surface)
            {
                DateTime = DateTime.Now,
                Style = "timepicker/circle"
            };
            ((IRotaryActionWidget)datetime).Activate();
            layout.SetContent(datetime);

            Button btn = new Button(layout)
            {
                Text = "OK",
                Style = "bottom",
            };

            layout.SetPartContent("elm.swallow.btn", btn);

            layout.SetPartText("elm.text", "Set time");

            datetime.DateTimeChanged += (object sender, DateChangedEventArgs e) =>
            {
                Log.Debug(TestName, "Old DateTime={0}", e.OldDate.ToString());
                Log.Debug(TestName, "New DateTime={0}", e.NewDate.ToString());
                Log.Debug(TestName, "Current DateTime={0}", datetime.DateTime.ToString());
            };
        }
    }
}