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


using ElmSharp.Wearable;

namespace ElmSharp.Test.TC
{
    public class CircleProgressBarTest1 : TestCaseBase
    {
        public override string TestName => "CircleProgressBarTest1";
        public override string TestDescription => "To test basic operation of CircleProgressBar";

        public override void Run(Window window)
        {
            Log.Debug(TestName, "CircleProgressBar run");
            Conformant conformant = new Conformant(window);
            conformant.Show();

            CircleProgressBar pb1 = new CircleProgressBar(conformant)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,

                // default
                Value = 20,
                Maximum = 100,
                Minimum = 0,
                BarRadius = 80,
                BarLineWidth = 6,

                // background
                BackgroundRadius = 80,
                BackgroundLineWidth = 6,
            };
            pb1.Show();
            conformant.SetContent(pb1);
            Label lb1 = new Label(window)
            {
                Text = string.Format("{0} %", pb1.Value),
            };

            lb1.Resize(window.ScreenSize.Width, window.ScreenSize.Height);
            lb1.Move(170, window.ScreenSize.Height / 2 - 20);
            lb1.Show();

            EcoreMainloop.AddTimer(0.05, () =>
            {
                pb1.Value += 1;
                lb1.Text = string.Format("{0} %", pb1.Value);

                return true;
            });
        }
    }
}
