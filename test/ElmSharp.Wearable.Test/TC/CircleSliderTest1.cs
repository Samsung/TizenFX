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
    public class CircleSliderTest1 : TestCaseBase
    {
        public override string TestName => "CircleSliderTest1";
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
                Maximum = 100,
                Value = 25,
                Step = 5,
            };
            ((IRotaryActionWidget)circleSlider).Activate();
            circleSlider.Show();
            conformant.SetContent(circleSlider);

            Label label1 = new Label(window)
            {
                Text = string.Format("{0}", circleSlider.Value),
                Color = Color.White,
            };

            label1.Resize(window.ScreenSize.Width, window.ScreenSize.Height);
            label1.Move(170, window.ScreenSize.Height / 2 - 20);
            label1.Show();

            circleSlider.ValueChanged += (s, e) =>
            {
                label1.Text = string.Format("{0}", circleSlider.Value);
            };
        }
    }
}
