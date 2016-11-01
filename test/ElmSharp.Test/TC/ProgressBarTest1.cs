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
    class ProgressBarTest1 : TestCaseBase
    {
        public override string TestName => "ProgressBarTest1";
        public override string TestDescription => "To test basic operation of ProgressBar";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Table table = new Table(window);
            conformant.SetContent(table);
            table.Show();

            ProgressBar pb1 = new ProgressBar(window)
            {
                Text = "ProgressBar Test",
                UnitFormat = "%.0f %%",
                Value = 0.1,
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1
            };

            Label lb1 = new Label(window)
            {
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1
            };

            Button bt1 = new Button(window)
            {
                Text = "Increase",
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1
            };

            Button bt2 = new Button(window)
            {
                Text = "Decrease",
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1
            };

            table.Pack(pb1, 1, 1, 2, 1);
            table.Pack(lb1, 1, 2, 2, 1);
            table.Pack(bt1, 1, 3, 1, 1);
            table.Pack(bt2, 2, 3, 1, 1);

            pb1.Show();
            lb1.Show();
            bt1.Show();
            bt2.Show();

            bt1.Clicked += (s, e) =>
            {
                pb1.Value += 0.1;
            };

            bt2.Clicked += (s, e) =>
            {
                pb1.Value -= 0.1;
            };

            pb1.ValueChanged += (s, e) =>
            {
                lb1.Text = string.Format("Value Changed: {0}", pb1.Value);
                lb1.EdjeObject["elm.text"].TextStyle = "DEFAULT='color=#ffffff'";
            };
        }
    }
}
