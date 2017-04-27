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
using System.Collections.Generic;

namespace ElmSharp.Test
{
    public class LabelTest4 : TestCaseBase
    {
        public override string TestName => "LabelTest4";
        public override string TestDescription => "To test slide Animation of Label";

        public override void Run(Window window)
        {
            Background bg = new Background(window);
            bg.Color = Color.White;
            bg.Move(0, 0);
            bg.Resize(window.ScreenSize.Width, window.ScreenSize.Height);
            bg.Show();

            Label label1 = new Label(window)
            {
                Style = "slide_long",
                SlideDuration = 3,
                SlideMode = LabelSlideMode.Always,
                Color = Color.Black,
                Text = "Lab test12345678"
            };

            label1.Show();
            label1.Resize(200, 30);
            label1.Move(0, 0);
            label1.PlaySlide();
        }
    }
}
