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
    class MultiButtonEntryTest2 : TestCaseBase
    {
        public override string TestName => "MultiButtonEntryTest2";
        public override string TestDescription => "To test basic operation of MultiButtonEntry";

        bool _setCallback = false;

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

            var expandButton = new Button(window)
            {
                Text = "IsExpanded",
                AlignmentX = -1,
                WeightX = 1,
            };

            var formatButton = new Button(window)
            {
                Text = "format",
                AlignmentX = -1,
                WeightX = 1,
            };

            expandButton.Clicked += (sender, e) =>
            {
                mbe.IsExpanded = !mbe.IsExpanded;
            };

            formatButton.Clicked += (sender, e) =>
            {
                if (_setCallback)
                {
                    mbe.SetFormatCallback(null);
                    _setCallback = false;
                }
                else
                {
                    mbe.SetFormatCallback((count) => { return "(" + count + ")"; });
                    _setCallback = true;
                }
            };

            label1.Resize(600, 100);
            label1.Move(50, 50);
            label1.Show();

            mbe.Resize(600, 600);
            mbe.Move(0, 100);
            mbe.Show();

            expandButton.Resize(200, 100);
            expandButton.Move(50, 700);
            expandButton.Show();

            formatButton.Resize(200, 100);
            formatButton.Move(300, 700);
            formatButton.Show();
        }
    }
}