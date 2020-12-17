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
    class SliderTest1 : WearableTestCase
    {
        public override string TestName => "SliderTest1";
        public override string TestDescription => "To test basic operation of Slider";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                IsHorizontal = false,
            };
            box.Show();
            conformant.SetContent(box);

            Slider sld1 = new Slider(window)
            {
                Text = "Slider Test",
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
                AlignmentY = 1,
                WeightX = 1,
                WeightY = 1
            };

            Label lb2 = new Label(window)
            {
                AlignmentX = -1,
                AlignmentY = 1,
                WeightX = 1,
                WeightY = 1,
                Text = string.Format("IsIndicatorFocusable : {0}", sld1.IsIndicatorFocusable.ToString()),
            };

            Label lb3 = new Label(window)
            {
                AlignmentX = -1,
                AlignmentY = 1,
                WeightX = 1,
                WeightY = 1,
                Text = string.Format("IndicatorVisibleMode : {0}", sld1.IndicatorVisibleMode.ToString()),
            };

            Box buttonBox = new Box(window)
            {
                IsHorizontal = true,
                AlignmentX = -1,
                AlignmentY = 0,
            };
            buttonBox.Show();

            Button btn = new Button(window)
            {
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1,
                Text = "IsIndicatorFocusable"
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
                lb2.Text = string.Format("IsIndicatorFocusable : {0}", sld1.IsIndicatorFocusable.ToString());
                lb2.EdjeObject["elm.text"].TextStyle = "DEFAULT='color=#ffffff'";
            };

            Button btn2 = new Button(window)
            {
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1,
                Text = "IndicatorVisibleMode"
            };
            btn2.Clicked += (s, e) =>
            {
                if (sld1.IndicatorVisibleMode == SliderIndicatorVisibleMode.Default)
                {
                    sld1.IndicatorVisibleMode = SliderIndicatorVisibleMode.Always;
                }
                else if (sld1.IndicatorVisibleMode == SliderIndicatorVisibleMode.Always)
                {
                    sld1.IndicatorVisibleMode = SliderIndicatorVisibleMode.OnFocus;
                }
                else if (sld1.IndicatorVisibleMode == SliderIndicatorVisibleMode.OnFocus)
                {
                    sld1.IndicatorVisibleMode = SliderIndicatorVisibleMode.None;
                }
                else
                {
                    sld1.IndicatorVisibleMode = SliderIndicatorVisibleMode.Default;
                }

                lb3.Text = string.Format("IndicatorVisibleMode : {0}", sld1.IndicatorVisibleMode.ToString());
                lb3.EdjeObject["elm.text"].TextStyle = "DEFAULT='color=#ffffff'";
            };

            sld1.Show();
            lb1.Show();
            lb2.Show();
            lb3.Show();
            btn.Show();
            btn2.Show();

            buttonBox.PackEnd(btn);
            buttonBox.PackEnd(btn2);

            box.PackEnd(lb1);
            box.PackEnd(lb2);
            box.PackEnd(lb3);
            box.PackEnd(sld1);
            box.PackEnd(buttonBox);

            lb2.EdjeObject["elm.text"].TextStyle = "DEFAULT='color=#ffffff'";
            lb3.EdjeObject["elm.text"].TextStyle = "DEFAULT='color=#ffffff'";

            sld1.ValueChanged += (s, e) =>
            {
                lb1.Text = string.Format("Value Changed: {0}", sld1.Value);
                lb1.EdjeObject["elm.text"].TextStyle = "DEFAULT='color=#ffffff'";
            };
        }
    }
}