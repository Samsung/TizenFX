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
    class EvasMapTest1 : WearableTestCase
    {
        public override string TestName => "EvasMapTest1";
        public override string TestDescription => "Test EvasMap on different levels of hierarchy";

        public override void Run(Window window)
        {
            var square = window.GetInnerSquare();

            var box = new Box(window)
            {
                Geometry = new Rect(square.X, square.Y, square.Width, square.Height / 2),
                BackgroundColor = Color.Gray
            };
            box.Show();

            var text = new Label(box)
            {
                Text = "<span color=#ffffff font_size=30>Target</span>",
                AlignmentX = -1.0,
                AlignmentY = -1.0,
                WeightX = 1.0,
                WeightY = 1.0,
            };
            text.Show();

            box.PackEnd(text);

            double angle = 0.0;

            var reset = new Button(box)
            {
                Text = "Reset",
                Geometry = new Rect(square.X, square.Y + square.Height / 2, square.Width, square.Height / 6)
            };
            reset.Show();

            double zx = 1.0;
            double zy = 1.0;
            reset.Clicked += (object sender, EventArgs e) =>
            {
                text.IsMapEnabled = false;
                angle = 0.0;
                zx = 1.0;
                zy = 1.0;
            };

            var zoom = new Button(box)
            {
                Text = "Zoom Target",
                Geometry = new Rect(square.X, square.Y + square.Height / 2 + square.Height / 6, square.Width, square.Height / 6)
            };
            zoom.Show();

            zoom.Clicked += (object sender, EventArgs e) =>
            {
                zx += 0.1;
                zy += 0.1;
                var map = new EvasMap(4);
                var g = text.Geometry;
                map.PopulatePoints(g, 0);
                map.Rotate3D(0, 0, angle, g.X + g.Width / 2, g.Y + g.Height / 2, 0);
                map.Zoom(zx, zy, g.X, g.Y);
                text.EvasMap = map;
                text.IsMapEnabled = true;
            };

            var rotate = new Button(box)
            {
                Text = "Rotate Target",
                Geometry = new Rect(square.X, square.Y + square.Height / 2 + square.Height * 2 / 6, square.Width, square.Height / 6)
            };
            rotate.Show();

            rotate.Clicked += (object sender, EventArgs e) =>
            {
                angle += 5.0;
                var map = new EvasMap(4);
                var g = text.Geometry;
                map.PopulatePoints(g, 0);
                map.Rotate3D(0, 0, angle, g.X + g.Width / 2, g.Y + g.Height / 2, 0);
                map.Zoom(zx, zy, g.X, g.Y);
                text.EvasMap = map;
                text.IsMapEnabled = true;
            };
        }
    }
}