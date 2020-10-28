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
    public class CircleSliderTest2 : TestCaseBase
    {
        public override string TestName => "CircleSliderTest2";
        public override string TestDescription => "To test basic operation of CircleSlider";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();

            var surface = new CircleSurface(conformant);
            CircleSlider circleSlider = new CircleSlider(conformant, surface)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                Minimum = 0,
                Maximum = 15,
                BarColor = Color.Purple,
                BackgroundColor = Color.Red,
                BarRadius = 160,
                BackgroundRadius = 160,
                BarLineWidth = 15,
                BackgroundLineWidth = 15,
                BackgroundAngleOffset = 90,
                BackgroundAngle = 270,
                BarAngleOffset = 90.0,
                BarAngleMinimum = 0.0,
                BarAngleMaximum = 270.0,
                Value = 3,
                Step = 0.5,
            };
            ((IRotaryActionWidget)circleSlider).Activate();
            circleSlider.Show();
            conformant.SetContent(circleSlider);
            Label label1 = new Label(window)
            {
                Text = string.Format("{0:F1}", circleSlider.Value),
                Color = Color.White,
            };

            label1.Resize(window.ScreenSize.Width, window.ScreenSize.Height);
            label1.Move(170, window.ScreenSize.Height / 2 - 30);
            label1.Show();

            Label label2 = new Label(window)
            {
                Text = string.Format("min:{0},max{1}", circleSlider.Minimum, circleSlider.Maximum),
                Color = Color.White,
            };

            label2.Resize(window.ScreenSize.Width, window.ScreenSize.Height);
            label2.Move(110, window.ScreenSize.Height / 2 + 10);
            label2.Show();

            Log.Debug(TestName, "CircleSliderTest2 step:" + circleSlider.Step);

            circleSlider.ValueChanged += (s, e) =>
            {
                label1.Text = string.Format("{0:F1}", circleSlider.Value);
            };
        }
    }
}
