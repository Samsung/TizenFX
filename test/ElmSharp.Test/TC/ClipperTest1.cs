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
    public class ClipperTest1 : TestCaseBase
    {
        public override string TestName => "ClipperTest1";
        public override string TestDescription => "ClipperTest1 test";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();

            Naviframe navi = new Naviframe(window)
            {
                PreserveContentOnPop = true,
                DefaultBackButtonEnabled = true
            };

            Scroller scroller = new Scroller(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                ScrollBlock = ScrollBlock.None,
            };
            scroller.Show();
            Box container = new Box(window);
            scroller.SetContent(container);

            var rect1 = new Rectangle(window)
            {
                AlignmentX = -1,
                WeightX = 1,
                Color = Color.Blue,
                MinimumHeight = 500
            };
            rect1.Show();

            var clipper = new Rectangle(window);
            clipper.Color = new ElmSharp.Color(200, 200, 200, 200);
            clipper.Geometry = rect1.Geometry;
            rect1.Moved += (s, e) =>
            {
                clipper.Geometry = ((Rectangle)s).Geometry;
            };
            rect1.SetClip(clipper);
            clipper.Show();
            container.PackEnd(rect1);

            Color[] colors = { Color.Red, Color.Olive, Color.Green, Color.Gray, Color.Lime, Color.Maroon };
            for (int i = 0; i < 6; i++)
            {
                var rect = new Rectangle(window)
                {
                    AlignmentX = -1,
                    WeightX = 1,
                    Color = colors[i],
                    MinimumHeight = 500
                };
                rect.Show();
                container.PackEnd(rect);
            }

            navi.Push(scroller, "Scroll Page");
            navi.Show();
            conformant.SetContent(navi);
        }
    }
}
