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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmSharp.Test
{
    class ProgressBarTest2 : TestCaseBase
    {
        public override string TestName => "ProgressBarTest2";
        public override string TestDescription => "To test basic operation of ProgressBar";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box table = new Box(window)
            {
                BackgroundColor = Color.White,
            };
            conformant.SetContent(table);
            table.Show();

            ProgressBar pb1 = new ProgressBar(window)
            {
                Text = "ProgressBar Test",
                Style = "process_medium",
                Value = 0.1,
                AlignmentX = 0,
                AlignmentY = 0,
                WeightX = 0,
                WeightY = 1
            };
            pb1.PlayPulse();
            Label lb1 = new Label(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };

            Button bt1 = new Button(window)
            {
                Text = "Increase Value",
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1
            };

            bt1.Clicked += (s, e) =>
            {
                Random rand = new Random(DateTime.UtcNow.Millisecond);
                pb1.Color = new Color(rand.Next(255), rand.Next(255), rand.Next(255));
                lb1.Text = pb1.Color.ToString();
            };

            Button bt2 = new Button(window)
            {
                Text = "zoom",
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1
            };

            bt2.Clicked += (s, e) =>
            {
                var map = new EvasMap(4);
                var g = pb1.Geometry;
                map.PopulatePoints(g, 0);
                map.Zoom(2, 2, g.X, g.Y);
                pb1.EvasMap = map;
                pb1.IsMapEnabled = true;
            };

            table.PackEnd(pb1);
            table.PackEnd(lb1);
            table.PackEnd(bt1);
            table.PackEnd(bt2);

            pb1.Show();
            lb1.Show();
            bt1.Show();
            bt2.Show();
        }
    }
}