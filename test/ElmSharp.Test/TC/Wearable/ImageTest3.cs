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
    public class ImageTest3 : WearableTestCase
    {
        public override string TestName => "ImageTest3";
        public override string TestDescription => "To test basic operation of Image";

        Image image;
        Label lbInfo;

        string[] btn_names = new string[] { "Blue(BG)", "Default(BG)", "Blue(FG)", "Default(FG)" };

        public override void Run(Window window)
        {

            Rect square = window.GetInnerSquare();

            Button[] btns = new Button[4];
            Size btnSize = new Size(square.Width / 2 , square.Height / 5);
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    btns[i * 2 + j] = new Button(window)
                    {
                        Text = "<span color=#ffffff font_size=15>" + btn_names[i * 2 + j] + "</span>",

                    };
                    int x = j * btnSize.Width + j * 2;
                    int y = i * btnSize.Height + i;
                    btns[i * 2 + j].Geometry = new Rect(square.X + x, square.Y + y, btnSize.Width, btnSize.Height);
                    btns[i * 2 + j].Show();
                }
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
                WeightX = 1,
                WeightY = 1
            };
            image.Show();
            image.Load(Path.Combine(TestRunner.ResourceDir, "btn_delete.png"));
            image.Geometry = new Rect(square.X, square.Y + btnSize.Height * 2 + 2, square.Width, btnSize.Height * 3 );

            image.Clicked += (s, e) =>
            {
                Console.WriteLine("Image has been clicked. (IsFixedAspect = {0}", image.IsFixedAspect);
                image.IsFixedAspect = image.IsFixedAspect == true ? false : true;
            };

            btns[0].Clicked += (s, e) => { image.BackgroundColor = Color.Blue; UpdateLabelText(image.BackgroundColor.ToString()); };
            btns[1].Clicked += (s, e) => { image.BackgroundColor = Color.Default; UpdateLabelText(image.BackgroundColor.ToString()); };
            btns[2].Clicked += (s, e) => { image.Color = Color.Blue; UpdateLabelText(image.Color.ToString(), false); };
            btns[3].Clicked += (s, e) => { image.Color = Color.Default; UpdateLabelText(image.Color.ToString(), false); };

        }

        void UpdateLabelText(string text, bool isBackground = true)
        {
            if(isBackground)
                lbInfo.Text = "<span color=#ffffff font_size=15> Background Color => " + text + "</span>";
            else
                lbInfo.Text = "<span color=#ffffff font_size=15> Foreground Color => " + text + "</span>";
        }
    }
}
