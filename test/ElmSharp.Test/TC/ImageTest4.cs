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
using System.Diagnostics;
using System.IO;

namespace ElmSharp.Test
{
    public class ImageTest4 : TestCaseBase
    {
        public override string TestName => "ImageTest4";
        public override string TestDescription => "To test border operation of Image";

        Image image, image2;

        public override void Run(Window window)
        {
            Background bg = new Background(window);
            bg.Color = Color.White;
            bg.Move(0, 0);
            bg.Resize(window.ScreenSize.Width, window.ScreenSize.Height);
            bg.Show();

            Button btnBorder = new Button(window)
            {
                Text = "Border Set : off",
            };
            btnBorder.Move(10, 10);
            btnBorder.Resize(300, 100);
            btnBorder.Show();

            Button btnBorderCenterFillMode = new Button(window)
            {
                Text = "BoderCenterFillMode",
            };
            btnBorderCenterFillMode.Move(310, 10);
            btnBorderCenterFillMode.Resize(300, 100);
            btnBorderCenterFillMode.Show();

            image2 = new Image(window);
            image2.Load(Path.Combine(TestRunner.ResourceDir, "TED/large/a.jpg"));
            image2.MinimumWidth = 300; 
            image2.MinimumHeight = 300;
            image2.Move(50, 500);
            image2.Resize(600, 500);
            image2.Show();

            image = new Image(window);
            image.Load(Path.Combine(TestRunner.ResourceDir, "picture.png"));
            image.MinimumWidth = image.ObjectSize.Width;
            image.MinimumHeight = image.ObjectSize.Height;
            image.Move(100, 600);
            image.Resize(image.ObjectSize.Width, image.ObjectSize.Height);
            image.Show();


            btnBorder.Clicked += (s, e) =>
            {
                int nX = image.ObjectSize.Width / 6;
                int nY = image.ObjectSize.Height / 6;
                image.SetBorder(nX, nX, nY, nY);
                btnBorder.Text = "Border Set : on";
            };

            btnBorderCenterFillMode.Clicked += (s, e) =>
            {
                image.BorderCenterFillMode = ((ImageBorderFillMode)Enum.ToObject(typeof(ImageBorderFillMode), ((int)image.BorderCenterFillMode + 1) % Enum.GetValues(typeof(ImageBorderFillMode)).Length));
                btnBorderCenterFillMode.Text = image.BorderCenterFillMode.ToString();
            };
        }
    }
}