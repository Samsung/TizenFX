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
    public class PopupTest3 : TestCaseBase
    {
        public override string TestName => "PopupTest3";
        public override string TestDescription => "To test basic operation of Popup with DateTimeSelector";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window);
            box.Show();
            Button btn = new Button(window)
            {
                AlignmentX = -1,
                WeightX = 1,
                Text = "Open"
            };
            btn.Show();

            Popup popup = new Popup(window);
            DateTimeSelector dateTime = new DateTimeSelector(window)
            {
                MinimumDateTime = new DateTime(2015, 1, 1),
                MaximumDateTime = DateTime.Now,
                DateTime = DateTime.Now
            };
            popup.SetPartContent("default", dateTime, true);

            popup.Dismissed += (s, e) =>
            {
                Console.WriteLine("Popup dismissed");
            };

            popup.ShowAnimationFinished += (s, e) =>
            {
                Console.WriteLine("Popup show animation finished");
            };

            popup.OutsideClicked += (s, e) =>
            {
                Console.WriteLine("Popup outside clicked");
            };

            popup.TimedOut += (s, e) =>
            {
                Console.WriteLine("Popup time out");
            };

            popup.BackButtonPressed += (s, e) =>
            {
                Console.WriteLine("!!! BackButtonPressed Event on Popup!!");
                popup.Hide();
            };

            btn.Clicked += (s, e) =>
            {
                popup.Show();
            };

            Button close = new Button(popup)
            {
                Text = "Close"
            };
            popup.SetPartContent("button1", close, true);

            Button ok = new Button(popup)
            {
                Text = "Ok"
            };
            popup.SetPartContent("button3", ok, true);

            close.Clicked += (s, e) =>
            {
                popup.Hide();
            };

            box.PackEnd(btn);
            conformant.SetContent(box);
        }
    }
}
