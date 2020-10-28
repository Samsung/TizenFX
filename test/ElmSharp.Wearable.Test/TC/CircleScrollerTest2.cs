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
    public class CircleScrollerTest2 : TestCaseBase
    {
        public override string TestName => "CircleScrollerTest2";
        public override string TestDescription => "To test basic operation of CircleScroller";

        public override void Run(Window window)
        {
            Layout layout = new Layout(window);
            layout.Show();
            layout.Move(0, 0);
            layout.Resize(360, 360);

            var surface = new CircleSurface(layout);
            CircleScroller circleScroller = new CircleScroller(layout, surface)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                VerticalScrollBarVisiblePolicy = ScrollBarVisiblePolicy.Invisible,
                HorizontalScrollBarVisiblePolicy = ScrollBarVisiblePolicy.Auto,
            };
            ((IRotaryActionWidget)circleScroller).Activate();
            circleScroller.Show();
            circleScroller.Move(0, 0);
            circleScroller.Resize(360, 360);
            circleScroller.Lower();

            Box box = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                IsHorizontal = true,
            };
            box.Show();
            circleScroller.SetContent(box);

            var rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                int r = rnd.Next(255);
                int g = rnd.Next(255);
                int b = rnd.Next(255);
                Color color = Color.FromRgb(r, g, b);
                Rectangle colorBox = new Rectangle(window)
                {
                    AlignmentX = -1,
                    AlignmentY = -1,
                    WeightX = 1,
                    WeightY = 1,
                    Color = color,
                    MinimumWidth = window.ScreenSize.Width,
                };
                colorBox.Show();
                box.PackEnd(colorBox);
            }
            circleScroller.Scrolled += (s, e) => Log.Debug(TestName, "Horizental Circle Scroll Scrolled");
        }
    }
}
