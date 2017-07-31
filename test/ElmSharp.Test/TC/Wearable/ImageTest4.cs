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
    public class ImageTest4 : WearableTestCase
    {
        public override string TestName => "ImageTest4";
        public override string TestDescription => "To test border operation of Image";

        Image image;

        public override void Run(Window window)
        {
            Rect square = window.GetInnerSquare();
            Log.Debug(square.ToString());

            Button btnBorder = new Button(window)
            {
                Text = "Set : off",
            };
            btnBorder.Resize(square.Width / 2, square.Height / 4);
            btnBorder.Move(square.X, square.Y);
            btnBorder.Show();

            Button btnBorderCenterFillMode = new Button(window)
            {
                Text = "FillMode",
            };
            btnBorderCenterFillMode.Resize(square.Width / 2, square.Height / 4);
            btnBorderCenterFillMode.Move(square.X + square.Width / 2 , square.Y);
            btnBorderCenterFillMode.Show();

            image = new Image(window);
            image.Load(Path.Combine(TestRunner.ResourceDir, "picture.png"));
            image.MinimumWidth = square.Width;
            image.MinimumHeight = square.Height * 3 / 4;
            image.Move(square.X, square.Y + square.Height / 4);
            image.Resize(square.Width, square.Height * 3 / 4);
            image.Show();


            btnBorder.Clicked += (s, e) =>
            {
                int nX = square.Width / 6;
                int nY = square.Height / 8;
                Log.Debug("image.Width" + image.ObjectSize.Width.ToString());
                Log.Debug("image.Height" + image.ObjectSize.Height.ToString());
                Log.Debug("nX :" + nX + ", nY :" + nY);
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