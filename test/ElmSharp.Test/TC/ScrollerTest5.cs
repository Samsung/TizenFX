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
    public class ScrollerTest5 : TestCaseBase
    {
        public override string TestName => "ScrollerTest5";
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

            Rectangle[] rects = new Rectangle[5];
            Random rnd = new Random();
            for(int i = 0; i < 5; i++)
            {
                rects[i] = new Rectangle(window)
                {
                    AlignmentX = -1,
                    AlignmentY = -1,
                    WeightX = 1,
                    WeightY = 1,
                    Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)),
                };
                rects[i].Show();
                rects[i].MinimumWidth = 300;
                innerBox.PackEnd(rects[i]);
            }
            innerBox.MinimumWidth = 300 * 5;
            _currentIndex = 4;


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
                innerBox.UnPack(rects[_currentIndex]);
                innerBox.MinimumWidth = 300 * _currentIndex;
                rects[_currentIndex].Hide();
                _currentIndex--;
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
            };

            btn.Show();

            outterBox.PackEnd(btn);
            outterBox.PackEnd(scroller);
            
            
        }
    }
}