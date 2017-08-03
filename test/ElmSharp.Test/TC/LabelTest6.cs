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
    public class LabelTest6 : TestCaseBase
    {
        public override string TestName => "LabelTest6";
        public override string TestDescription => "To test Horizontal align of Label";

        int count = 0;
        public override void Run(Window window)
        {

            Background bg = new Background(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                Color = Color.White
            };
            bg.Show();
            window.AddResizeObject(bg);

            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window);
            box.Show();
            conformant.SetContent(box);

            box.Resize(window.ScreenSize.Width, window.ScreenSize.Height);

            var label = new Label(window);
            var label2 = new Label(window);
            var button = new Button(window);

            box.SetLayoutCallback(() =>
            {
                label.Geometry = new Rect(10, box.Geometry.Y, box.Geometry.Width - 20, 100);
                label2.Geometry = new Rect(10, label.Geometry.Y + 120, box.Geometry.Width - 20, 100);
                button.Geometry = new Rect(0, box.Geometry.Y + 300, box.Geometry.Width, 200);
            });


            label.BackgroundColor = Color.Aqua;
            label.LineWrapType = WrapType.Word;
            label.IsEllipsis = false;
            label.TextStyle = "DEFAULT = 'align=left'";

            label2.BackgroundColor = Color.Aqua;
            label2.LineWrapType = WrapType.None;
            label2.IsEllipsis = false;
            label2.TextStyle = "DEFAULT = 'align=left'";

            label.Show();
            label2.Show();
            box.PackEnd(label);
            box.PackEnd(label2);

            
            button.SetAlignment(-1, -1);
            button.SetWeight(1, 1);
            button.Text = "Append";
            button.Show();
            box.PackEnd(button);


            button.Clicked += (s, e) =>
            {
                string alpahbat = "ABCDEFGHIJKLMOPQRSTUVWXYZ";
                label.Text += alpahbat[count % alpahbat.Length];
                label.Text += alpahbat[count % alpahbat.Length];
                label2.Text += alpahbat[count % alpahbat.Length];
                label2.Text += alpahbat[count % alpahbat.Length];
                count++;
            };

        }
    }
}
