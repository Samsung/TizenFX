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
    class EcoreTimerTest1 : WearableTestCase
    {
        public override string TestName => "EcoreTimerTest1";
        public override string TestDescription => "To timer operation of EcoreMainLoop";

        public override void Run(Window window)
        {
            var square = window.GetInnerSquare();

            Background bg = new Background(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                Color = Color.Gray
            };
            bg.Show();
            window.AddResizeObject(bg);

            Conformant conformant = new Conformant(window);
            conformant.Show();


            int number = 0;
            bool bReturn = true;
            Label label1 = new Label(window);
            label1.Geometry = new Rect(square.X, square.Y, square.Width, square.Height / 2);

            Button btnTimerSwitch = new Button(window);
            btnTimerSwitch.Text = "Timer : On";
            btnTimerSwitch.Geometry = new Rect(square.X, square.Y + square.Height / 2, square.Width, square.Height / 2);

            Func<bool> handler = () =>
            {
                label1.Text = (++number).ToString();
                label1.EdjeObject["elm.text"].TextStyle = "DEFAULT='color=#000000 font_size=64 align=left valign=bottom wrap=word'";
                return bReturn;
            };
            IntPtr prevId = EcoreMainloop.AddTimer(1.0, handler);
            btnTimerSwitch.Clicked += (s, e) =>
            {
                if (bReturn)
                {
                    bReturn = false;
                    btnTimerSwitch.Text = "Timer : Off";
                }
                else
                {
                    bReturn = true;
                    btnTimerSwitch.Text = "Timer : On";
                    EcoreMainloop.RemoveTimer(prevId);
                    prevId = EcoreMainloop.AddTimer(1.0, handler);
                }
            };

            window.BackButtonPressed += (s, e) =>
            {
                EcoreMainloop.RemoveTimer(prevId);
            };

            label1.Show();
            btnTimerSwitch.Show();
        }
    }
}
