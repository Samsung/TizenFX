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
    class SliderTest2 : WearableTestCase
    {
        public override string TestName => "SliderTest2";
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

            Slider sld = new Slider(window)
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

            Label Emptylb = new Label(window)
            {
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1,
                Text="  "
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
                Text = string.Format("IsIndicatorVisible={0}", sld.IsIndicatorVisible.ToString()),
            };
            lb2.EdjeObject["elm.text"].TextStyle = "DEFAULT='color=#ffffff'";

            Box buttonBox = new Box(window)
            {
                IsHorizontal = true,
                AlignmentX = -1,
                AlignmentY = 0,
            };
            buttonBox.Show();

            Button btn1 = new Button(window)
            {
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1,
                Text = "IndicatorVisibleMode"
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
                Text = "IsIndicatorVisible"
            };
            btn2.Clicked += (s, e) =>
            {
                sld.IsIndicatorVisible = !sld.IsIndicatorVisible;
                lb2.Text = string.Format("IsIndicatorVisible={0}", sld.IsIndicatorVisible.ToString());
                lb2.EdjeObject["elm.text"].TextStyle = "DEFAULT='color=#ffffff'";
            };

            sld.Show();
            Emptylb.Show();
            lb1.Show();
            lb2.Show();
            btn1.Show();
            btn2.Show();

            buttonBox.PackEnd(btn1);
            buttonBox.PackEnd(btn2);

            box.PackEnd(Emptylb);
            box.PackEnd(lb1);
            box.PackEnd(lb2);
            box.PackEnd(sld);
            box.PackEnd(buttonBox);

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