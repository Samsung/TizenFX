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
    public class PanesTest1 : WearableTestCase
    {
        public override string TestName => "PanesTest1";
        public override string TestDescription => "To test basic operation of Panes";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window);
            conformant.SetContent(box);
            box.Show();

            Rectangle redBox = new Rectangle(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                Color = Color.Red,
            };
            redBox.Show();
            Rectangle blueBox = new Rectangle(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                Color = Color.Blue,
            };
            Rectangle greenBox = new Rectangle(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                Color = Color.Green,
            };
            Panes subPanes = new Panes(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                Proportion = 0.3,
                IsHorizontal = false
            };
            subPanes.Show();
            subPanes.SetPartContent("left", blueBox);
            subPanes.SetPartContent("right", greenBox);
            Panes panes = new Panes(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                Proportion = 0.1,
                IsFixed = true,
                IsHorizontal = true,
            };
            panes.SetPartContent("left", redBox);
            panes.SetPartContent("right", subPanes);
            panes.Show();
            box.PackEnd(panes);
        }

    }
}
