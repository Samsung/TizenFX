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
using System.Collections.Generic;

namespace ElmSharp.Test
{
    public class ScrollerTest6 : TestCaseBase
    {
        public override string TestName => "ScrollerTest6";
        public override string TestDescription => "To test basic operation of Scroller";

        int _currentIndex = 0;

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
            conformant.SetContent(outterBox);

            Scroller scroller = new Scroller(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                ScrollBlock = ScrollBlock.Vertical
            };
            scroller.Show();


            Box innerBox = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                IsHorizontal = true,
            };
            innerBox.Show();
            scroller.SetContent(innerBox);

            var rects = new List<Rectangle>();
            Random rnd = new Random();
            for(int i = 0; i < 30; i++)
            {
                var rect = new Rectangle(window)
                {
                    AlignmentX = -1,
                    AlignmentY = -1,
                    WeightX = 1,
                    WeightY = 1,
                    Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)),
                };
                rect.Show();
                innerBox.PackEnd(rect);
                rects.Add(rect);
            };

            innerBox.SetLayoutCallback(() =>
            {
                System.Console.WriteLine("!!!! update layout");
                System.Console.WriteLine("MinimumWith = {0}", innerBox.MinimumWidth);

            });
            for (int i = 0; i < rects.Count; i++)
            {
                rects[i].Geometry = new Rect(i / 3 * 400 + innerBox.Geometry.X, i % 3 * 400 + innerBox.Geometry.Y, 400, 400);
            }
            innerBox.MinimumWidth = (int)Math.Ceiling(rects.Count / 3.0) * 400;

            Button btn = new Button(window)
            {
                AlignmentX = -1,
                WeightX = 1,
                Text = "Remove"
            };
            btn.Clicked += (s, e) =>
            {
                System.Console.WriteLine("current index {0}", _currentIndex);
                System.Console.WriteLine("Before Current Region : {0}", scroller.CurrentRegion);
                int last = rects.Count - 1;
                innerBox.UnPack(rects[last]);
                rects[last].Hide();
                rects.RemoveAt(last);

                System.Console.WriteLine(" innerBox MinimumWith = {0}", innerBox.MinimumWidth);
                System.Console.WriteLine("After Current Region : {0}", scroller.CurrentRegion);

                EcoreMainloop.Post(() =>
                {
                    System.Console.WriteLine("On idler Current Region : {0}", scroller.CurrentRegion);
                });

                EcoreMainloop.AddTimer(0, () =>
                {
                    System.Console.WriteLine("After 0 sec Current Region : {0}", scroller.CurrentRegion);
                    return false;
                });
            };
            scroller.Scrolled += (s, e) =>
            {
                System.Console.WriteLine("Scrolled to {0}", scroller.CurrentRegion);
                System.Console.WriteLine("in scrolling MinimumWith = {0}", innerBox.MinimumWidth);
            };

            btn.Show();

            outterBox.PackEnd(btn);
            outterBox.PackEnd(scroller);
            
            
        }
    }
}