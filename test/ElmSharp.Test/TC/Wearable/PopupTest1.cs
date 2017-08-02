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

namespace ElmSharp.Test.Wearable
{
    public class PopupTest1 : WearableTestCase
    {
        public override string TestName => "PopupTest1";
        public override string TestDescription => "To test basic operation of Popup";

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

            Popup popup = new Popup(window)
            {
                Orientation = PopupOrientation.Bottom,
                Timeout = 5,
            };

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

            popup.Append("Label1");
            popup.Append("Label2");
            popup.Append("Label3");

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
                AlignmentX = -1,
                WeightX = 1,
                Text = "Close"
            };
            popup.SetPartContent("button1", close);

            close.Clicked += (s, e) =>
            {
                popup.Hide();
            };

            box.PackEnd(btn);
            conformant.SetContent(box);
        }
    }
}
