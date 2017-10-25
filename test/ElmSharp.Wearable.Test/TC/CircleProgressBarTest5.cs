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
    public class CircleProgressBarTest5 : TestCaseBase
    {
        public override string TestName => "CircleProgressBarTest5";
        public override string TestDescription => "To test Disabled property of CircleProgressBar";

        public override void Run(Window window)
        {
            Log.Debug(TestName, "CircleProgressBar run");
            Conformant conformant = new Conformant(window);
            conformant.Show();

            Naviframe naviframe = new Naviframe(window);
            naviframe.Show();
            conformant.SetContent(naviframe);

            var surface = new CircleSurface(conformant);
            CircleProgressBar pb1 = new CircleProgressBar(naviframe, surface)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                Value = 0,
                Maximum = 100,
                Minimum = 0,
            };
            pb1.Show();
            naviframe.Push(pb1, null, "empty");

            Label lb1 = new Label(window)
            {
                Text = string.Format("S {0} %", pb1.Value),
            };

            lb1.Resize(window.ScreenSize.Width, window.ScreenSize.Height);
            lb1.Move(160, window.ScreenSize.Height / 2 - 40);
            lb1.Show();

            EcoreMainloop.AddTimer(0.05, () =>
            {
                if (pb1.Value == pb1.Maximum/2)
                {
                    // Test purpose : set disable
                    pb1.IsEnabled = false;
                }

                if (pb1.Value == pb1.Maximum)
                {
                    EcoreMainloop.RemoveTimer(pb1);
                }

                pb1.Value += 1;
                lb1.Text = string.Format("S {0} %", pb1.Value);

                return true;
            });
        }
    }
}
