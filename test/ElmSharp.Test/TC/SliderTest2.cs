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
    class SliderTest2 : TestCaseBase
    {
        public override string TestName => "SliderTest2";
        public override string TestDescription => "To test basic operation of Slider";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Table table = new Table(window);
            conformant.SetContent(table);
            table.Show();

            Slider sld = new Slider(window)
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

            Label lb1 = new Label(window)
            {
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1,
                Text = string.Format("IndicatorVisibleMode={0}", sld.IndicatorVisibleMode.ToString()),
            };
            lb1.EdjeObject["elm.text"].TextStyle = "DEFAULT='color=#ffffff'";

            Label lb2 = new Label(window)
            {
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1,
                Text = string.Format("IndicatorVisibleMode={0}", sld.IndicatorVisibleMode.ToString()),
            };
            lb2.EdjeObject["elm.text"].TextStyle = "DEFAULT='color=#ffffff'";

            Button btn1 = new Button(window)
            {
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1,
                Text = "Change IndicatorVisibleMode"
            };
            btn1.Clicked += (s, e) =>
            {
                sld.IndicatorVisibleMode = (SliderIndicatorVisibleMode)(((int)sld.IndicatorVisibleMode + 1) % 4);
                lb1.Text = string.Format("IndicatorVisibleMode={0}", sld.IndicatorVisibleMode.ToString());
                lb1.EdjeObject["elm.text"].TextStyle = "DEFAULT='color=#ffffff'";
            };

            Button btn2 = new Button(window)
            {
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1,
                Text = "Change IsIndicatorVisible"
            };
            btn2.Clicked += (s, e) =>
            {
                sld.IsIndicatorVisible = !sld.IsIndicatorVisible;
                lb2.Text = string.Format("IsIndicatorVisible={0}", sld.IsIndicatorVisible.ToString());
                lb2.EdjeObject["elm.text"].TextStyle = "DEFAULT='color=#ffffff'";
            };

            table.Pack(sld, 1, 1, 2, 1);
            table.Pack(lb1, 1, 2, 2, 1);
            table.Pack(lb2, 1, 3, 2, 1);
            table.Pack(btn1, 1, 4, 2, 1);
            table.Pack(btn2, 1, 5, 2, 1);

            sld.Show();
            lb1.Show();
            lb2.Show();
            btn1.Show();
            btn2.Show();

            sld.ValueChanged += (s, e) =>
            {
                lb1.Text = string.Format("IndicatorVisibleMode={0}", sld.IndicatorVisibleMode.ToString());
                lb1.EdjeObject["elm.text"].TextStyle = "DEFAULT='color=#ffffff'";

                lb2.Text = string.Format("IsIndicatorVisible={0}", sld.IsIndicatorVisible.ToString());
                lb2.EdjeObject["elm.text"].TextStyle = "DEFAULT='color=#ffffff'";
            };
        }
    }
}