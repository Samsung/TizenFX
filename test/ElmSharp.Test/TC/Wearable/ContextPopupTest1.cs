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
    class ContextPopupTest1 : WearableTestCase
    {
        public override string TestName => "ContextPopupTest1";
        public override string TestDescription => "To test basic operation of ContextPopup";
        private int _count = 0;
        public override void Run(Window window)
        {
            Rect square = window.GetInnerSquare();

            Background bg = new Background(window);
            bg.Color = Color.Olive;
            bg.Move(0, 0);
            bg.Resize(window.ScreenSize.Width, window.ScreenSize.Height);
            bg.Show();

            ContextPopup ctxPopup = new ContextPopup(bg)
            {
                IsHorizontal = false,
                AutoHide = false,
            };

            for (int i = 0; i < 5; i++)
            {
                ctxPopup.Append(string.Format("{0} item", _count++));
            }

            ctxPopup.Dismissed += (e, o) => {
                Console.WriteLine("Dismissed");
            };
            ctxPopup.Geometry = new Rect(square.X, square.Y, square.Width / 4, square.Height);
            ctxPopup.Show();

            bool ctxPopupVisible = true;
            string dismissCaption = "Dismiss ContextPopup!";
            string showCaption = "Show ContextPopup!";

            Button button = new Button(window)
            {
                Text = dismissCaption
            };
            button.Clicked += (E, o) =>
            {
                if (ctxPopupVisible)
                {
                    ctxPopup.Dismiss();
                }
                else
                {
                    ctxPopup.Show();
                }
                ctxPopupVisible = !ctxPopupVisible;
                button.Text = ctxPopupVisible ? dismissCaption : showCaption;
            };

            button.Geometry = new Rect(square.X + square.Width/2, square.Y, square.Width / 2, square.Height);
            button.Show();
        }
    }
}
