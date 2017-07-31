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

namespace ElmSharp.Test.Wearable
{
    class ProgressBarTest1 : WearableTestCase
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

            Label lb2 = new Label(window)
            {
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1
            };

            Button bt1 = new Button(window)
            {
                Text = "Increase Value",
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1
            };

            Button bt2 = new Button(window)
            {
                Text = "Decrease Value",
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1
            };

            Button bt3 = new Button(window)
            {
                Text = "Increase PartValue",
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1
            };

            Button bt4 = new Button(window)
            {
                Text = "Decrease PartValue",
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1
            };

            string part = "elm.cur.progressbar";
            double unit = 0.1;
            double max = 1.0;
            double min = 0;

            pb1.ValueChanged += (s, e) =>
            {
                lb1.Text = string.Format("Value Changed: {0}", pb1.Value);
                lb1.EdjeObject["elm.text"].TextStyle = "DEFAULT='color=#ffffff'";

                lb2.Text = string.Format("PartValue Changed: {0}", pb1.GetPartValue(part));
                lb2.EdjeObject["elm.text"].TextStyle = "DEFAULT='color=#ffffff'";
            };

            bt1.Clicked += (s, e) =>
            {
                var val = pb1.Value + unit;
                if (val <= max)
                    pb1.Value = val;
            };

            bt2.Clicked += (s, e) =>
            {
                var val = pb1.Value - unit;
                if (val >= min)
                {
                    pb1.Value = val;
                }
            };

            bt3.Clicked += (s, e) =>
            {
                var val = pb1.GetPartValue(part) + unit;
                if (val <= max)
                    pb1.SetPartValue(part, val);
            };

            bt4.Clicked += (s, e) =>
            {
                var val = pb1.GetPartValue(part) - unit;
                if (val >= min)
                {
                    pb1.SetPartValue(part, val);
                }
            };

            table.Pack(bt1, 1, 1, 1, 1);
            table.Pack(bt2, 2, 1, 1, 1);
            table.Pack(pb1, 1, 2, 2, 1);
            table.Pack(lb1, 1, 3, 2, 1);
            table.Pack(lb2, 1, 4, 2, 1);
            table.Pack(bt3, 1, 5, 1, 1);
            table.Pack(bt4, 2, 5, 1, 1);

            pb1.Show();
            lb1.Show();
            lb2.Show();
            bt1.Show();
            bt2.Show();
            bt3.Show();
            bt4.Show();
        }
    }
}