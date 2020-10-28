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

namespace ElmSharp.Test.Wearable
{
    public class ImageTest2 : WearableTestCase
    {
        public override string TestName => "ImageTest2";
        public override string TestDescription => "To test basic operation of Image";

        Image image;
        Label lbInfo;

        string[] btn_names = new string[] { "Blue", "Default", "Aspect", "Rotate" };

        public override void Run(Window window)
        {
            Rect square = window.GetInnerSquare();

            Button[] btns = new Button[4];
            Size btnSize = new Size(square.Width / 4 - 2, square.Height / 4);
            for (int i = 0; i < 4; i++)
            {
                btns[i] = new Button(window)
                {
                    Text = "<span color=#ffffff font_size=12>" + btn_names[i] + "</span>",
                };
                int x = i * btnSize.Width + i * 2;
                btns[i].Geometry = new Rect(square.X + x, square.Y, btnSize.Width, btnSize.Height);
                btns[i].Show();
            }

            lbInfo = new Label(window) {
                Color = Color.White,
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1
            };
            lbInfo.Show();
            lbInfo.Geometry = new Rect(square.X, square.Y + square.Height, square.Width, 15);

            image = new Image(window) {
                IsFixedAspect = true,
                AlignmentX = -1,
                AlignmentY = -1,
            };
            image.Show();
            image.Load(Path.Combine(TestRunner.ResourceDir, "picture.png"));
            image.Geometry = new Rect(square.X, square.Y + btnSize.Height, square.Width, btnSize.Height * 3);

            image.Clicked += (s, e) =>
            {
                Console.WriteLine("Image has been clicked. (IsFixedAspect = {0}", image.IsFixedAspect);
                image.IsFixedAspect = image.IsFixedAspect == true ? false : true;
            };

            btns[0].Clicked += (s, e) => { image.BackgroundColor = Color.Blue; UpdateLabelText(image.BackgroundColor.ToString()); };
            btns[1].Clicked += (s, e) => { image.BackgroundColor = Color.Default; UpdateLabelText(image.BackgroundColor.ToString()); };
            btns[2].Clicked += (s, e) => { image.IsFixedAspect = image.IsFixedAspect == true ? false : true; };
            btns[3].Clicked += (s, e) => { image.Orientation = image.Orientation == ImageOrientation.None ? ImageOrientation.Rotate270 : ImageOrientation.None; };
        }

        void UpdateLabelText(string text)
        {
            lbInfo.Text = "<span color=#ffffff font_size=12> BackgroundColor => " + text + "</span>";
        }
    }
}
