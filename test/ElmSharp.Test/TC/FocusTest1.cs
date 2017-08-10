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

namespace ElmSharp.Test
{
    public class FocusTest1 : TestCaseBase
    {
        public override string TestName => "FocusTest1";
        public override string TestDescription => "To test basic operation of Focus";

        Button currentButton;
        Label lbInfo;

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window);
            conformant.SetContent(box);
            box.Show();

            Box buttonBox1 = new Box(window)
            {
                IsHorizontal = true,
                AlignmentX = -1,
                AlignmentY = 0,
            };
            buttonBox1.Show();

            Box buttonBox2 = new Box(window)
            {
                IsHorizontal = true,
                AlignmentX = -1,
                AlignmentY = 0,
            };
            buttonBox2.Show();

            Box buttonBox3 = new Box(window)
            {
                IsHorizontal = true,
                AlignmentX = -1,
                AlignmentY = 0,
            };
            buttonBox3.Show();

            Button leftButton = new Button(window)
            {
                Text = "Left",
                BackgroundColor = Color.Gray,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            leftButton.Show();

            Button rightButton = new Button(window)
            {
                Text = "Right",
                BackgroundColor = Color.Gray,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            rightButton.Show();

            Button upButton = new Button(window)
            {
                Text = "Up",
                BackgroundColor = Color.Gray,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            upButton.Show();

            Button downButton = new Button(window)
            {
                Text = "Down",
                BackgroundColor = Color.Gray,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            downButton.Show();

            leftButton.Focused += Button_Focused;
            leftButton.Unfocused += Button_Unfocused;
            rightButton.Focused += Button_Focused;
            rightButton.Unfocused += Button_Unfocused;
            upButton.Focused += Button_Focused;
            upButton.Unfocused += Button_Unfocused;
            downButton.Focused += Button_Focused;
            downButton.Unfocused += Button_Unfocused;

            leftButton.AllowFocus(false);
            rightButton.AllowFocus(false);
            upButton.AllowFocus(false);
            downButton.AllowFocus(false);

            buttonBox1.PackEnd(leftButton);
            buttonBox1.PackEnd(rightButton);
            buttonBox1.PackEnd(upButton);
            buttonBox1.PackEnd(downButton);

            Button buttonA = new Button(window)
            {
                Text = "A",
                AlignmentX = 0.5,
                WeightX = 1,
                WeightY = 1
            };
            buttonA.Show();

            Button buttonB = new Button(window)
            {
                Text = "B",
                AlignmentX = 0.5,
                WeightX = 1,
                WeightY = 1
            };
            buttonB.Show();

            buttonBox2.PackEnd(buttonA);
            buttonBox2.PackEnd(buttonB);

            buttonA.Focused += Button_Focused;
            buttonA.Unfocused += Button_Unfocused;
            buttonB.Focused += Button_Focused;
            buttonB.Unfocused += Button_Unfocused;

            Button itemButton1 = new Button(window)
            {
                Text = "No.1",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            itemButton1.Show();

            Button itemButton2 = new Button(window)
            {
                Text = "No.2",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            itemButton2.Show();

            Button itemButton3 = new Button(window)
            {
                Text = "No.3",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            itemButton3.Show();

            Button itemButton4 = new Button(window) {
                Text = "No.4",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            itemButton4.Show();

            itemButton1.Focused += Button_Focused;
            itemButton1.Unfocused += Button_Unfocused;
            itemButton2.Focused += Button_Focused;
            itemButton2.Unfocused += Button_Unfocused;
            itemButton3.Focused += Button_Focused;
            itemButton3.Unfocused += Button_Unfocused;
            itemButton4.Focused += Button_Focused;
            itemButton4.Unfocused += Button_Unfocused;

            itemButton1.SetNextFocusObject(itemButton4, FocusDirection.Left);
            itemButton2.SetNextFocusObject(itemButton1, FocusDirection.Left);
            itemButton3.SetNextFocusObject(itemButton2, FocusDirection.Left);
            itemButton4.SetNextFocusObject(itemButton3, FocusDirection.Left);
            itemButton1.SetNextFocusObject(itemButton2, FocusDirection.Right);
            itemButton2.SetNextFocusObject(itemButton3, FocusDirection.Right);
            itemButton3.SetNextFocusObject(itemButton4, FocusDirection.Right);
            itemButton4.SetNextFocusObject(itemButton1, FocusDirection.Right);
            itemButton1.SetNextFocusObject(buttonA, FocusDirection.Up);
            itemButton2.SetNextFocusObject(buttonA, FocusDirection.Up);
            itemButton3.SetNextFocusObject(buttonA, FocusDirection.Up);
            itemButton4.SetNextFocusObject(buttonA, FocusDirection.Up);

            buttonA.SetNextFocusObject(buttonB, FocusDirection.Left);
            buttonB.SetNextFocusObject(buttonA, FocusDirection.Left);
            buttonA.SetNextFocusObject(buttonB, FocusDirection.Right);
            buttonB.SetNextFocusObject(buttonA, FocusDirection.Right);
            buttonA.SetNextFocusObject(itemButton1, FocusDirection.Down);
            buttonB.SetNextFocusObject(itemButton1, FocusDirection.Down);

            buttonBox3.PackEnd(itemButton1);
            buttonBox3.PackEnd(itemButton2);
            buttonBox3.PackEnd(itemButton3);
            buttonBox3.PackEnd(itemButton4);

            leftButton.Clicked += (s, e) =>
            {
                if (currentButton != null)
                {
                    currentButton.FocusNext(FocusDirection.Left);
                }
            };
            rightButton.Clicked += (s, e) =>
            {
                if (currentButton != null)
                {
                    currentButton.FocusNext(FocusDirection.Right);
                }
            };
            upButton.Clicked += (s, e) =>
            {
                if (currentButton != null)
                {
                    currentButton.FocusNext(FocusDirection.Up);
                }
            };
            downButton.Clicked += (s, e) =>
            {
                if (currentButton != null)
                {
                    currentButton.FocusNext(FocusDirection.Down);
                }
            };

            lbInfo = new Label(window) {
                Color = Color.White,
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1
            };
            lbInfo.Show();

            box.PackEnd(lbInfo);
            box.PackEnd(buttonBox1);
            box.PackEnd(buttonBox2);
            box.PackEnd(buttonBox3);
        }

        void Button_Focused(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn!=null)
            {
                btn.BackgroundColor = Color.Red;
                currentButton = btn;
                lbInfo.Text = "Focused Button : " + btn.Text;
            }
        }

        void Button_Unfocused(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                btn.BackgroundColor = Color.Default;
                currentButton = btn;
                lbInfo.Text = "";
            }
        }
    }
}
