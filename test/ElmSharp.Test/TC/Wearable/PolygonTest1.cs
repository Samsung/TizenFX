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

namespace ElmSharp.Test.Wearable
{
    class PolygonTest1 : WearableTestCase
    {
        public override string TestName => "PolygonTest1";
        public override string TestDescription => "To test basic operation of Polygon";

        public override void Run(Window window)
        {
            var square = window.GetInnerSquare();
            Background bg = new Background(window);
            bg.Color = Color.White;
            bg.Move(0, 0);
            bg.Resize(window.ScreenSize.Width, window.ScreenSize.Height);
            bg.Show();

            Polygon triangle1 = new Polygon(window);
            triangle1.Color = Color.Blue;
            triangle1.AddPoint(square.X, square.Y + square.Height/6);
            triangle1.AddPoint(square.X, square.Y + square.Height/3);
            triangle1.AddPoint(square.X + square.Width/2, square.Y + square.Height/5);
            triangle1.Show();

            Polygon triange2 = new Polygon(window);
            triange2.AddPoint(square.X + square.Width/2, square.Y + square.Height/5);
            triange2.AddPoint(new Point{X= square.X + square.Width, Y= square.Y + square.Height/5 });
            triange2.AddPoint(new Point{X= square.X + square.Width, Y= square.Y + square.Height/3 });
            triange2.Color = Color.Green;
            triange2.Show();

            Polygon hexagon = new Polygon(window);
            hexagon.Color = Color.Pink;
            hexagon.AddPoint(square.X, square.Y);
            hexagon.AddPoint(square.X + square.Width, square.Y);
            hexagon.ClearPoints();
            for (double a=0; a < 2 * Math.PI; a += Math.PI / 3)
            {
                hexagon.AddPoint(
                    square.X + square.Width/2 + (int)(120 * Math.Sin(a)),
                    square.Y + square.Height/2+square.Height/6 + (int)(120 * Math.Cos(a))
                );
            }
            hexagon.Show();
        }

    }
}
