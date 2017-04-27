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
    class SliderTest1 : TestCaseBase
    {
        public override string TestName => "SliderTest1";
        public override string TestDescription => "To test basic operation of Slider";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Table table = new Table(window);
            conformant.SetContent(table);
            table.Show();

            Slider sld1 = new Slider(window)
            {
                Text = "Slider Test",
                UnitFormat = "%1.2f meters",
                IndicatorFormat = "%1.2f meters",
                Minimum = 0.0,
                Maximum = 100.0,
                Value = 0.1,
                AlignmentX = -1,
                AlignmentY = 0.5,
                WeightX = 1,
                WeightY = 1,
                IsIndicatorFocusable = true
            };

            Button btn = new Button(window)
            {
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1,
                Text = "Set IsIndicatorFocusable"
            };
            btn.Clicked += (s, e) =>
            {
                if (sld1.IsIndicatorFocusable)
                {
                    sld1.IsIndicatorFocusable = false;
                }
                else
                {
                    sld1.IsIndicatorFocusable = true;
                }
            };

            Label lb1 = new Label(window)
            {
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1
            };

            table.Pack(sld1, 1, 1, 2, 1);
            table.Pack(btn, 1, 2, 2, 1);
            table.Pack(lb1, 1, 3, 2, 1);

            sld1.Show();
            btn.Show();
            lb1.Show();

            sld1.ValueChanged += (s, e) =>
            {
                lb1.Text = string.Format("Value Changed: {0}", sld1.Value);
                lb1.EdjeObject["elm.text"].TextStyle = "DEFAULT='color=#ffffff'";
            };
        }
    }
}