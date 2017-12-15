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
using ElmSharp;

namespace ElmSharp.Test
{
    public class ScrollerTest3 : TestCaseBase
    {
        public override string TestName => "ScrollerTest3";
        public override string TestDescription => "To test ScrollTo operation of Scroller";
        Scroller _scroller;

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box outterBox = new Box(window)
            {
                BackgroundColor = Color.Gray,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                IsHorizontal = false,
            };
            outterBox.Show();
            _scroller = new Scroller(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                HorizontalPageScrollLimit = 1,
            };
            _scroller.SetPageSize(1.0, 1.0);
            _scroller.Show();

            Box box = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            box.Show();
            _scroller.SetContent(box);

            for (int i = 0; i < 150; i++)
            {
                Label addlabel = new Label(window)
                {
                    Text = i + " Label Test",
                    AlignmentX = -1,
                    AlignmentY = -1,
                    WeightX = 1,
                    WeightY = 1,
                };
                addlabel.Show();
                box.PackEnd(addlabel);
            }

            conformant.SetContent(outterBox);
            outterBox.PackEnd(_scroller);

            Button prev = new Button(window)
            {
                AlignmentX = -1,
                WeightX = 1,
                Text = "Prev"
            };
            Button next = new Button(window)
            {
                AlignmentX = -1,
                WeightX = 1,
                Text = "next"
            };

            int index = 0;

            prev.Clicked += (s, e) =>
            {
                Rect region = new Rect(0, _scroller.Geometry.Height * --index, _scroller.Geometry.Width * index, _scroller.Geometry.Height);
                Console.WriteLine("index : {0} [{1}, {2}]\n", index, _scroller.Geometry.Width, _scroller.Geometry.Height);
                _scroller.ScrollTo(region, false);
            };

            next.Clicked += (s, e) =>
            {
                Rect region = new Rect(0, _scroller.Geometry.Height * ++index, _scroller.Geometry.Width, _scroller.Geometry.Height);
                Console.WriteLine("index : {0} [{1}, {2}]\n", index, _scroller.Geometry.Width, _scroller.Geometry.Height);
                _scroller.ScrollTo(region, false);
            };
            prev.Show();
            next.Show();

            Button prev2 = new Button(window)
            {
                AlignmentX = -1,
                WeightX = 1,
                Text = "animation Prev"
            };
            Button next2 = new Button(window)
            {
                AlignmentX = -1,
                WeightX = 1,
                Text = "animation next"
            };

            prev2.Clicked += (s, e) =>
            {
                Rect region = new Rect(0, _scroller.Geometry.Height * --index, _scroller.Geometry.Width * index, _scroller.Geometry.Height);
                Console.WriteLine("animation index : {0} [{1}, {2}]\n", index, _scroller.Geometry.Width, _scroller.Geometry.Height);
                _scroller.ScrollTo(region, true);
            };

            next2.Clicked += (s, e) =>
            {
                Rect region = new Rect(0, _scroller.Geometry.Height * ++index, _scroller.Geometry.Width, _scroller.Geometry.Height);
                Console.WriteLine("animation index : {0} [{1}, {2}]\n", index, _scroller.Geometry.Width, _scroller.Geometry.Height);
                _scroller.ScrollTo(region, true);
            };
            prev2.Show();
            next2.Show();

            outterBox.PackEnd(prev);
            outterBox.PackEnd(next);
            outterBox.PackEnd(prev2);
            outterBox.PackEnd(next2);

            _scroller.DragStart += Scroller_DragStart;
            _scroller.DragStop += Scroller_DragStop;
            _scroller.ScrollAnimationStarted += Scroller_ScrollStart;
            _scroller.ScrollAnimationStopped += Scroller_ScrollStop;
            _scroller.Scrolled += Scroller_Scrolled;
        }

        private void Scroller_Scrolled(object sender, EventArgs e)
        {
            Console.WriteLine($"scrolled : {_scroller.CurrentRegion}");
        }

        private void Scroller_ScrollStop(object sender, EventArgs e)
        {
            Console.WriteLine("scroll animation stop");
        }

        private void Scroller_ScrollStart(object sender, EventArgs e)
        {
             Console.WriteLine("scroll animation start");
        }

        private void Scroller_DragStop(object sender, EventArgs e)
        {
            Console.WriteLine("Drag stop");
        }

        private void Scroller_DragStart(object sender, EventArgs e)
        {
            Console.WriteLine("Drag start");
        }
    }
}
