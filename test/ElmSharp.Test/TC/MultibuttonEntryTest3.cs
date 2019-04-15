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
using ElmSharp;

namespace ElmSharp.Test
{
    class MultiButtonEntryTest3 : TestCaseBase
    {
        public override string TestName => "MultiButtonEntryTest3";
        public override string TestDescription => "To test basic operation of MultiButtonEntry";

        public override void Run(Window window)
        {
            Background bg = new Background(window);
            bg.Color = Color.White;
            bg.Move(0, 0);
            bg.Resize(window.ScreenSize.Width, window.ScreenSize.Height);
            bg.Show();

            MultiButtonEntry mbe = new MultiButtonEntry(window)
            {
                IsEditable = true,
                IsExpanded = true,
                Text = "To: "
            };
            mbe.Append("Append1");
            mbe.Append("Append2");
            mbe.Append("Append3");
            mbe.Append("Append4");
            mbe.Append("Append5");
            mbe.Append("Append6");
            mbe.Append("Append7");
            mbe.Append("Append8");
            mbe.Append("Append9");
            mbe.Append("Append10");
            mbe.Append("Append11");
            mbe.Append("Append12");

            Label label1 = new Label(window)
            {
                Text = "MultiButtonEntry Test",
                Color = Color.Blue
            };

            var createButton = new Button(window)
            {
                Text = "Change the status of IsExpanded",
                AlignmentX = -1,
                WeightX = 1,
            };

            var deleteButton = new Button(window)
            {
                Text = "Delete",
                AlignmentX = -1,
                WeightX = 1,
            };

            createButton.Clicked += (sender, e) =>
            {
                mbe.IsExpanded = !mbe.IsExpanded;
            };

            deleteButton.Clicked += (sender, e) =>
            {
                mbe.Unrealize();
            };

            label1.Resize(600, 100);
            label1.Move(50, 50);
            label1.Show();

            mbe.Resize(600, 600);
            mbe.Move(0, 100);
            mbe.Show();

            createButton.Resize(200, 100);
            createButton.Move(50, 700);
            createButton.Show();

            deleteButton.Resize(200, 100);
            deleteButton.Move(300, 700);
            deleteButton.Show();
        }
    }
}