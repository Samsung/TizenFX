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
    class CheckTest1 : WearableTestCase
    {
        public override string TestName => "CheckTest1";
        public override string TestDescription => "To test basic operation of Check";

        public override void Run(Window window)
        {
            Rect square = window.GetInnerSquare();

            Background bg = new Background(window);
            bg.Color = Color.Black;
            bg.Geometry = square;
            bg.Show();

            Check check = new Check(window)
            {
                Text = "This is Check",
                Style = "default"
            };

            Check onoff = new Check(window)
            {
                Text = "On or Off",
                Style = "on&off"
            };

            Label label1 = new Label(window);
            Label label2 = new Label(window);
            Label label3 = new Label(window);
            Label label4 = new Label(window);

            EventHandler<CheckStateChangedEventArgs> update = (s, e) =>
            {
                Check c = s as Check;
                label1.Text = string.Format("IsChecked ={0}", c.IsChecked);
                label2.Text = string.Format("Style={0}", c.Style);
                if (e != null)
                {
                    label3.Text = string.Format("OldState={0}", e.OldState);
                    label4.Text = string.Format("NewState={0}", e.NewState);
                }
            };

            check.StateChanged += (s, e) => update(s, e);

            onoff.StateChanged += (s, e) => update(s, e);

            Rect pieces = square;
            pieces.Height /= 5;

            label1.Geometry = new Rect(pieces.X, pieces.Y, pieces.Width, pieces.Height);
            label1.Show();

            label2.Geometry = new Rect(pieces.X, pieces.Y + pieces.Height, pieces.Width, pieces.Height);
            label2.Show();

            label3.Geometry = new Rect(pieces.X, pieces.Y + pieces.Height * 2, pieces.Width, pieces.Height);
            label3.Show();

            label4.Geometry = new Rect(pieces.X, pieces.Y + pieces.Height * 3, pieces.Width, pieces.Height);
            label4.Show();

            check.Geometry = new Rect(pieces.X, pieces.Y + pieces.Height * 4, pieces.Width/2, pieces.Height);
            check.Show();

            onoff.Geometry = new Rect(pieces.X + pieces.Width/2, pieces.Y + pieces.Height * 4, pieces.Width / 2, pieces.Height);
            onoff.Show();
        }
    }
}
