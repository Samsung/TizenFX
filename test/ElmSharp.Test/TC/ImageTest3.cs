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
using System.IO;

namespace ElmSharp.Test
{
    public class ImageTest3 : TestCaseBase
    {
        public override string TestName => "ImageTest3";
        public override string TestDescription => "To test basic operation of Image";

        Image image;
        Label lbInfo;

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window);
            conformant.SetContent(box);
            box.Show();

            Box buttonBox1 = new Box(window) {
                IsHorizontal = true,
                AlignmentX = -1,
                AlignmentY = 0,
            };
            buttonBox1.Show();

            Box buttonBox2 = new Box(window) {
                IsHorizontal = true,
                AlignmentX = -1,
                AlignmentY = 0,
            };
            buttonBox2.Show();

            Button btnFile1 = new Button(window) {
                Text = "Blue (BG)",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            btnFile1.Show();

            Button btnFile2 = new Button(window) {
                Text = "Default (BG)",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            btnFile2.Show();

            Button btnFile3 = new Button(window) {
                Text = "Blue (FG)",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            btnFile3.Show();

            Button btnFile4 = new Button(window) {
                Text = "Default (FG)",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            btnFile4.Show();

            buttonBox1.PackEnd(btnFile1);
            buttonBox1.PackEnd(btnFile2);
            buttonBox2.PackEnd(btnFile3);
            buttonBox2.PackEnd(btnFile4);

            lbInfo = new Label(window) {
                Color = Color.White,
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1
            };
            lbInfo.Show();

            image = new Image(window) {
                IsFixedAspect = true,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            image.Show();
            image.Load(Path.Combine(TestRunner.ResourceDir, "btn_delete.png"));
            image.Clicked += (s, e) =>
            {
                Console.WriteLine("Image has been clicked. (IsFixedAspect = {0}", image.IsFixedAspect);
                image.IsFixedAspect = image.IsFixedAspect == true ? false : true;
            };

            btnFile1.Clicked += (s, e) => { image.BackgroundColor = Color.Blue; UpdateLabelText(image.BackgroundColor.ToString()); };
            btnFile2.Clicked += (s, e) => { image.BackgroundColor = Color.Default; UpdateLabelText(image.BackgroundColor.ToString()); };
            btnFile3.Clicked += (s, e) => { image.Color = Color.Blue; UpdateLabelText(image.Color.ToString(), false); };
            btnFile4.Clicked += (s, e) => { image.Color = Color.Default; UpdateLabelText(image.Color.ToString(), false); };

            box.PackEnd(buttonBox1);
            box.PackEnd(buttonBox2);
            box.PackEnd(lbInfo);
            box.PackEnd(image);
        }

        void UpdateLabelText(string text, bool isBackground = true)
        {
            if(isBackground)
                lbInfo.Text = "<span color=#ffffff font_size=20> Background Color => " + text + "</span>";
            else
                lbInfo.Text = "<span color=#ffffff font_size=20> Foreground Color => " + text + "</span>";
        }
    }
}
