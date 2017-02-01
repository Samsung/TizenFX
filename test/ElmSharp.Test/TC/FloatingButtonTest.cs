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
    class FloatingButtonTest : TestCaseBase
    {
        public override string TestName => "FloatingButtonTest";
        public override string TestDescription => "To test FloatingButton";

        Button _RedButton = null;
        Button _GreenButton = null;

        public Button CreateButton(Window window, string text)
        {
            return new Button(window)
            {
                Text = text,
                AlignmentY = -1,
                AlignmentX = -1,
            };
        }

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window)
            {
                AlignmentY = -1,
                AlignmentX = -1,
                WeightX = 1,
                WeightY = 1,
            };
            box.Show();
            conformant.SetContent(box);

            FloatingButton floatingButton = new FloatingButton(window)
            {
                Mode = FloatingButton.FloatingButtonMode.All,
                AlignmentY = -1,
                AlignmentX = -1,
                WeightX = 1,
                WeightY = 1,
            };
            floatingButton.Show();
            floatingButton.Resize(700, 700);
            floatingButton.Move(0, 400);

            Box backGround = new Box(window)
            {
                AlignmentY = -1,
                AlignmentX = -1,
                WeightX = 1,
                WeightY = 1,
            };
            backGround.Show();

            Button button1 = CreateButton(window, "Mode change to LeftRightOnly");
            button1.Clicked += (s, e) => {
                if (floatingButton.Mode == FloatingButton.FloatingButtonMode.All)
                {
                    floatingButton.Mode = FloatingButton.FloatingButtonMode.LeftRightOnly;
                    button1.Text = "Mode change to All";
                }
                else
                {
                    floatingButton.Mode = FloatingButton.FloatingButtonMode.All;
                    button1.Text = "Mode change to LeftRightOnly";
                }
            };
            button1.Show();

            Button button2 = CreateButton(window, "MovementBlock Set");
            button2.Clicked += (s, e) => {
                floatingButton.MovementBlock = !floatingButton.MovementBlock;
                if (floatingButton.MovementBlock) button2.Text = "MovementBlock Unset";
                else button2.Text = "MovementBlock Set";
            };
            button2.Show();

            Button button3 = CreateButton(window, "RedButton Set");
            button3.Clicked += (s, e) => {
                if (_RedButton == null)
                {
                    _RedButton = CreateButton(window, "RedButton");
                    _RedButton.BackgroundColor = Color.Red;
                    floatingButton.SetPartContent("button1", _RedButton, true);
                    button3.Text = "RedButton Unset";
                }
                else
                {
                    _RedButton.Unrealize();
                    _RedButton = null;
                    floatingButton.SetPartContent("button1", _RedButton, true);
                    button3.Text = "RedButton Set";
                }
            };
            button3.Show();

            Button button4 = CreateButton(window, "GreenButton Set");
            button4.Clicked += (s, e) => {
                if (_GreenButton == null)
                {
                    _GreenButton = CreateButton(window, "GreenButton");
                    _GreenButton.BackgroundColor = Color.Green;
                    floatingButton.SetPartContent("button2", _GreenButton, true);
                    button4.Text = "GreenButton Unset";
                }
                else
                {
                    _GreenButton.Unrealize();
                    _GreenButton = null;
                    floatingButton.SetPartContent("button2", _GreenButton, true);
                    button4.Text = "GreenButton Unset";
                }
            };
            button4.Show();

            box.PackEnd(backGround);
            box.PackEnd(button1);
            box.PackEnd(button2);
            box.PackEnd(button3);
            box.PackEnd(button4);
        }
    }
}