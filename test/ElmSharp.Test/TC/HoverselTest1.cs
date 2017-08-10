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
    public class HoverselTest1 : TestCaseBase
    {
        public override string TestName => "HoverselTest1";
        public override string TestDescription => "To test basic operation of Hoversel";

        public override void Run(Window window)
        {
            Background bg = new Background(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                Color = Color.White
            };
            bg.Show();
            window.AddResizeObject(bg);

            Hoversel hoversel = new Hoversel(window)
            {
                IsHorizontal = false,
                HoverParent = window,
                Text = "Hoversel"
            };
            hoversel.ItemSelected += (s, e) =>
            {
                Console.WriteLine("ItemSelected : " + e.Item.Label);
            };
            hoversel.Dismissed += (s, e) =>
            {
                Console.WriteLine("Hoversel is dismissed");
            };
            hoversel.Clicked += (s, e) =>
            {
                Console.WriteLine("Hoversel is Clicked");
            };
            hoversel.Expanded += (s, e) =>
            {
                Console.WriteLine("Hoversel is Expanded");
            };

            HoverselItem item1 = hoversel.AddItem("item1");
            HoverselItem item2 = hoversel.AddItem("item2");
            HoverselItem item3 = hoversel.AddItem("item3");

            EventHandler handler = (s, e) =>
            {
                var item = s as HoverselItem;
                Console.WriteLine($"{item?.Label} is selected");
            };
            item1.ItemSelected += handler;
            item2.ItemSelected += handler;
            item3.ItemSelected += handler;

            hoversel.Resize(200, 100);
            hoversel.Move(100, 100);
            hoversel.Show();

            Button beginButton = new Button(window)
            {
                Text = "Begin"
            };
            beginButton.Clicked += (s, e) =>
            {
                hoversel.HoverBegin();
            };
            beginButton.Resize(200, 100);
            beginButton.Move(100, 500);
            beginButton.Show();
        }
    }
}
