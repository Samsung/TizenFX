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
    class SpinnerTest1 : WearableTestCase
    {
        public override string TestName => "SpinnerTest1";
        public override string TestDescription => "To test basic operation of Spinner";

        public override void Run(Window window)
        {
            Rect square = window.GetInnerSquare();

            Spinner spn1 = new Spinner(window)
            {
                Text = "Slider Test",
                LabelFormat = "%1.2f Value",
                Minimum = 1,
                Maximum = 12,
                Value = 1.5,
                Step = 0.5,
                Interval = 0.5,
                AlignmentX = -1,
                AlignmentY = 0.5,
                WeightX = 1,
                WeightY = 1
            };
            spn1.AddSpecialValue(5, "Five !!!!");

            Label lb1 = new Label(window)
            {
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1
            };

            spn1.Geometry = new Rect(square.X, square.Y, square.Width , square.Height / 4);
            spn1.Show();

            lb1.Geometry = new Rect(square.X, square.Y + square.Width * 2 / 4 , square.Width, square.Height / 4);
            lb1.Show();

            spn1.ValueChanged += (s, e) =>
            {
                lb1.Text = string.Format("Value Changed: {0}", spn1.Value);
                lb1.EdjeObject["elm.text"].TextStyle = "DEFAULT='color=#ffffff'";
            };
        }
    }
}
