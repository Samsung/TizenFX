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
    class CircleDateTimeSelectorTest4 : TestCaseBase
    {
        public override string TestName => "CircleDateTimeSelectorTest4";
        public override string TestDescription => "To display a date time selector with circle UI";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();

            var naviframe = new Naviframe(window);

            conformant.SetContent(naviframe);
            Layout layout = new Layout(naviframe);
            layout.SetTheme("layout", "circle", "datetime");

            var surface = new CircleSurface(conformant);

            DateTimeSelector datetime = new CircleDateTimeSelector(naviframe, surface)
            {
                DateTime = DateTime.Now,
                Style = "timepicker/circle",
                MarkerLineWidth = 40,
                MarkerColor = Color.Pink,
                MarkerRadius = 100,
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

            naviframe.Push(layout, null, "empty");

            datetime.DateTimeChanged += (object sender, DateChangedEventArgs e) =>
            {
                Log.Debug(TestName, "Old DateTime={0}", e.OldDate.ToString());
                Log.Debug(TestName, "New DateTime={0}", e.NewDate.ToString());
                Log.Debug(TestName,"Current DateTime={0}", datetime.DateTime.ToString());
            };
        }
    }
}