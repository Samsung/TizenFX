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
    class EvasMapTest2 : WearableTestCase
    {
        public override string TestName => "EvasMapTest2";
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

            var group = new Box(box)
            {
                IsHorizontal = true,
                BackgroundColor = Color.White,
            };
            group.Show();

            var x = new Label(group)
            {
                Text = "X",
            };
            x.Show();

            var y = new Label(group)
            {
                Text = "Y",
            };
            y.Show();

            var z = new Label(group)
            {
                Text = "Z",
            };
            z.Show();
            group.PackEnd(x);
            group.PackEnd(y);
            group.PackEnd(z);

            var top = new Rectangle(box)
            {
                Color = Color.Red,
            };
            top.SetAlignment(-1.0, -1.0);  // fill
            top.SetWeight(1.0, 1.0);  // expand
            top.Show();

            var bottom = new Rectangle(box)
            {
                Color = Color.Green,
            };
            bottom.SetAlignment(-1.0, -1.0);  // fill
            bottom.SetWeight(1.0, 1.0);  // expand
            bottom.Show();

            double angle = 0.0;

            var reset = new Button(box)
            {
                Text = "Reset",
                Geometry = new Rect(square.X, square.Y + square.Height / 2, square.Width, square.Height / 6)
            };
            reset.Show();

            reset.Clicked += (object sender, EventArgs e) =>
            {
                group.IsMapEnabled = false;
                x.IsMapEnabled = false;
                angle = 0.0;
            };

            var zoom = new Button(box)
            {
                Text = "Zoom group",
                Geometry = new Rect(square.X, square.Y + square.Height / 2 + square.Height / 6, square.Width, square.Height / 6)
            };
            zoom.Show();

            zoom.Clicked += (object sender, EventArgs e) =>
            {
                var map = new EvasMap(4);
                var g = group.Geometry;
                map.PopulatePoints(g, 0);
                map.Zoom(3.0, 3.0, g.X + g.Width / 2, g.Y + g.Height / 2);
                group.EvasMap = map;
                group.IsMapEnabled = true;
            };

            var rotate = new Button(box)
            {
                Text = "Rotate X",
                Geometry = new Rect(square.X, square.Y + square.Height / 2 + square.Height * 2 / 6, square.Width, square.Height / 6)
            };
            rotate.Show();

            rotate.Clicked += (object sender, EventArgs e) =>
            {
                angle += 5.0;

                var map = new EvasMap(4);
                var g = x.Geometry;
                map.PopulatePoints(g, 0);
                map.Rotate3D(0, 0, angle, g.X + g.Width / 2, g.Y + g.Height / 2, 0);
                x.EvasMap = map;
                x.IsMapEnabled = true;
            };

            box.PackEnd(top);
            box.PackEnd(group);
            box.PackEnd(bottom);
        }
    }
}