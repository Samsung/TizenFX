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
using System.Text;

namespace ElmSharp.Test.Wearable
{
    class BackgroundTest1 : WearableTestCase

    {
        public override string TestName => "BackgroundTest1";
        public override string TestDescription => "To test basic operation of Background";

        public override void Run(Window window)
        {
            Rect square = window.GetInnerSquare();

            Background bg1 = new Background(window)
            {
                Color = Color.Orange,
                Geometry = new Rect(square.X, square.Y, square.Width / 2, square.Height / 2)
            };

            Background bg2 = new Background(window)
            {
                Color = new Color(60, 128, 255, 100),
                Geometry = new Rect(square.X, square.Y + square.Height / 2, square.Width / 2, square.Height / 2)
            };

            Background bg3 = new Background(window)
            {
                File = "/home/owner/apps_rw/ElmSharpTest/res/picture.png",
                BackgroundOption = BackgroundOptions.Center,
                BackgroundColor = Color.Gray,
                Geometry = new Rect(square.X + square.Width/2, square.Y, square.Width / 2, square.Height)
            };

            bg3.SetFileLoadSize(square.Width/2, square.Height);

            bg1.Show();
            bg2.Show();
            bg3.Show();
        }
    }
}
