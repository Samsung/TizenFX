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
using ElmSharp;

namespace ElmSharp.Test
{
    class BackgroundTest1 : TestCaseBase
    {
        public override string TestName => "BackgroundTest1";
        public override string TestDescription => "To test basic operation of Background";

        public override void Run(Window window)
        {
            Background bg1 = new Background(window)
            {
                Color = Color.Orange
            };

            Background bg2 = new Background(window)
            {
                File = "/home/owner/apps_rw/ElmSharpTest/res/picture.png",
                BackgroundOption = BackgroundOptions.Center,
                BackgroundColor = Color.Gray
            };

            bg2.SetFileLoadSize(50, 50);

            Show(bg1, 0, 0, 100, 100);
            Show(bg2, 0, 100, 700, 700);
        }

        void Show(Background bg, int x, int y, int w, int h)
        {
            bg.Show();
            bg.Move(x, y);
            bg.Resize(w, h);
        }
    }
}