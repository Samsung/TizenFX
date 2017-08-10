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

namespace ElmSharp.Test.Wearable
{
    public class ScrollerTest3 : WearableTestCase
    {
        public override string TestName => "ScrollerTest3";
        public override string TestDescription => "To test ScrollTo operation of Scroller";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box outterBox = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                IsHorizontal = false,
            };
            outterBox.Show();
            Scroller scroller = new Scroller(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                ScrollBlock = ScrollBlock.Vertical,
                HorizontalPageScrollLimit = 1,
            };
            scroller.SetPageSize(1.0, 1.0);
            scroller.Show();

            Box box = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            box.Show();
            scroller.SetContent(box);

            for (int i = 0; i < 30; i++)
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
            outterBox.PackEnd(scroller);

            Box buttonBox = new Box(window)
            {
                IsHorizontal = true,
                AlignmentX = -1,
                AlignmentY = 0,
            };
            buttonBox.Show();

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
            prev.Clicked += (s, e) =>
            {
                Rect region = new Rect(0, 0, scroller.Geometry.Width, scroller.Geometry.Width);
                Console.WriteLine("{0} {1}\n", scroller.Geometry.Width, scroller.Geometry.Width);
                scroller.ScrollTo(region, true);
            };
            next.Clicked += (s, e) =>
            {
                Rect region = new Rect(0, scroller.Geometry.Height, scroller.Geometry.Width, scroller.Geometry.Height);
                Console.WriteLine("{0} {1}\n", scroller.Geometry.Width, scroller.Geometry.Width);
                scroller.ScrollTo(region, true);
            };
            prev.Show();
            next.Show();
            buttonBox.PackEnd(prev);
            buttonBox.PackEnd(next);
            outterBox.PackEnd(buttonBox);

            scroller.DragStart += Scroller_DragStart;
            scroller.DragStop += Scroller_DragStop;
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
