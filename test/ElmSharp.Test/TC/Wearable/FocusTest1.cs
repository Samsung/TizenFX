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

namespace ElmSharp.Test.Wearable
{
    public class FocusTest1 : WearableTestCase
    {
        public override string TestName => "FocusTest1";
        public override string TestDescription => "To test basic operation of Focus";

        string[] btn_names = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
        string previous;

        Button current;

        public override void Run(Window window)
        {
            var square = window.GetInnerSquare();

            Button[] btns = new Button[9];

            Size btnSize = new Size(square.Width / 3 - 2, square.Height / 4 - 2);
            for (int i=0; i<3; i++)
            {
                for (int j=0; j<3; j++)
                {
                    btns[i*3+j] = new Button(window) { Text = btn_names[i * 3 + j] };
                    int x = i * btnSize.Width + i * 2;
                    int y = j * btnSize.Height + j*2;
                    btns[i*3+j].Geometry = new Rect(square.X + x, square.Y + y, btnSize.Width, btnSize.Height);

                    btns[i * 3 + j].Focused += Button_Focused;
                    btns[i * 3 + j].Unfocused += Button_Unfocused;
                    btns[i * 3 + j].Show();
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j=0; j<3; j++)
                {
                    if (j > 0)
                    {
                        btns[i * 3 + j].SetNextFocusObject(btns[i * 3 + (j - 1)], FocusDirection.Up);
                    }
                    if (i > 0)
                    {
                        btns[i * 3 + j].SetNextFocusObject(btns[(i - 1) * 3 + j], FocusDirection.Left);
                    }
                    if (j < 2)
                    {
                        btns[i * 3 + j].SetNextFocusObject(btns[i * 3 + (j + 1)], FocusDirection.Down);
                    }
                    if (i < 2)
                    {
                        btns[i * 3 + j].SetNextFocusObject(btns[(i + 1) * 3 + j], FocusDirection.Right);
                    }
                }
            }

            Size arrowSize = new Size(square.Width / 4, square.Height / 4);

            Button left= new Button(window) { Text = "&lt;", Geometry = new Rect(square.X, square.Y + square.Height * 3 / 4, arrowSize.Width, arrowSize.Height) };
            Button right = new Button(window) { Text = ">", Geometry = new Rect(square.X + arrowSize.Width, square.Y + square.Height * 3 / 4, arrowSize.Width, arrowSize.Height) };
            Button up = new Button(window) { Text = "^", Geometry = new Rect(square.X + arrowSize.Width*2, square.Y + square.Height * 3 / 4, arrowSize.Width, arrowSize.Height) };
            Button down = new Button(window) { Text = "v", Geometry = new Rect(square.X + arrowSize.Width*3, square.Y + square.Height * 3 / 4, arrowSize.Width, arrowSize.Height) };

            current = btns[0];
            previous = current.Text;

            current.Text = "X";

            left.Clicked += (s, e) => current.FocusNext(FocusDirection.Left);
            right.Clicked += (s, e) => current.FocusNext(FocusDirection.Right);
            up.Clicked += (s, e) => current.FocusNext(FocusDirection.Up);
            down.Clicked += (s, e) => current.FocusNext(FocusDirection.Down);

            left.AllowFocus(false);
            right.AllowFocus(false);
            up.AllowFocus(false);
            down.AllowFocus(false);

            left.Show();
            right.Show();
            up.Show();
            down.Show();
        }

        void Button_Focused(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                btn.BackgroundColor = Color.Red;
                current = btn;
                previous = btn.Text;
                btn.Text = "X";
            }
        }

        void Button_Unfocused(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                btn.BackgroundColor = Color.Default;
                current = btn;
                btn.Text = previous;
                previous = "";
            }
        }
    }
}
