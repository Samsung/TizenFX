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
    public class ScrollerTest4 : TestCaseBase
    {
        public override string TestName => "ScrollerTest4";
        public override string TestDescription => "To test basic operation of Scroller";

        public override void Run(Window window)
        {
            //Conformant conformant = new Conformant(window);
            //conformant.Show();
            Box outterBox = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                IsHorizontal = false,
            };
            outterBox.Show();

            var button = new Button(window)
            {
                Text = "Button1",
                Color = Color.White,
            };
            button.Show();
            button.Resize(200, 100);
            button.Move(300, 100);

            var button2 = new Button(window)
            {
                Text = "Button2",
                Color = Color.White,
            };
            button2.Show();
            button2.Resize(200, 100);
            button2.Move(300, 300);

            var button3 = new Button(window)
            {
                Text = "Button3",
                Color = Color.White,
            };
            button3.Show();
            button3.Resize(200, 100);
            button3.Move(300, 500);

            Scroller scroller = new Scroller(window);
            scroller.Show();
            scroller.Resize(200, 400);
            scroller.Move(100, 600);

            Box box = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            box.Show();
            scroller.SetContent(box);

            var rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                int r = rnd.Next(255);
                int g = rnd.Next(255);
                int b = rnd.Next(255);
                Color color = Color.FromRgb(r, g, b);
                var colorBox1 = new Label(window)
                {
                    Text = "Label" + i.ToString(),
                    BackgroundColor = color,
                    MinimumHeight = 40,
                };
                colorBox1.Show();
                box.PackEnd(colorBox1);
            }

            Scroller scroller2 = new Scroller(window);
            scroller2.Show();
            scroller2.Resize(200, 400);
            scroller2.Move(700, 600);

            Box box2 = new Box(window)
            {
                MinimumWidth = 400,
                MinimumHeight = 200,
            };
            box2.BackgroundColor = Color.White;
            box2.Show();
            scroller2.SetContent(box2);

            rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                int r = rnd.Next(255);
                int g = rnd.Next(255);
                int b = rnd.Next(255);
                Color color = Color.FromRgb(r, g, b);
                var colorBox2 = new Label(scroller2)
                {
                    BackgroundColor = color,
                    MinimumHeight = 40,
                    Text = "GOGOGO"
                };
                colorBox2.Show();
                box2.PackEnd(colorBox2);
            }

            //conformant.SetContent(outterBox);
            //outterBox.PackEnd(button);
            //outterBox.PackEnd(button2);
            //outterBox.PackEnd(button3);
            //outterBox.PackEnd(scroller);
            //outterBox.PackEnd(scroller2);

            //outterBox.SetLayoutCallback(() =>
            //{
            //    scroller.Move(100, 800);
            //    button.Move(300, 100);
            //    button2.Move(300, 300);
            //    button3.Move(300, 500);
            //    scroller2.Move(700, 800);
            //});
        }
    }
}