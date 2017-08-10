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
    class CheckTest1 : TestCaseBase
    {
        public override string TestName => "CheckTest1";
        public override string TestDescription => "To test basic operation of Check";

        public override void Run(Window window)
        {
            Background bg = new Background(window);
            bg.Color = Color.White;
            bg.Move(0, 0);
            bg.Resize(window.ScreenSize.Width, window.ScreenSize.Height);
            bg.Show();

            Check check = new Check(window)
            {
                Text = "This is Check",
                Style = "default",
            };

            Label label1 = new Label(window) {
                Text = string.Format("IsChecked ={0}, Style={1}", check.IsChecked, check.Style),
            };

            Label label2 = new Label(window);

            Label label3 = new Label(window);

            check.StateChanged += (object sender, CheckStateChangedEventArgs e) =>
            {
                check.Style = check.Style == "default" ? "on&off": "default";
                label1.Text = string.Format("IsChecked ={0}, Style={1}", check.IsChecked, check.Style);
                label2.Text = string.Format("OldState={0}", e.OldState);
                label3.Text = string.Format("NewState={0}", e.NewState);
            };

            check.Resize(600, 100);
            check.Move(0, 300);
            check.Show();

            label1.Resize(600, 100);
            label1.Move(0, 0);
            label1.Show();

            label2.Resize(600, 100);
            label2.Move(0, 100);
            label2.Show();

            label3.Resize(600, 100);
            label3.Move(0, 200);
            label3.Show();
        }
    }
}