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

using ElmSharp.Wearable;

namespace ElmSharp.Test.TC
{
    class CircleSpinnerTest4 : TestCaseBase
    {
        public override string TestName => "CircleSpinnerTest4";
        public override string TestDescription => "To test advanced operation of Circle Spinner with AngleRatio";

        CircleSpinner spn1;
        CircleSpinner spn2;

        public override void Run(Window window)
        {
            Log.Debug(TestName, "CircleSpinnerTest run");

            Rect square = window.GetInnerSquare();

            Conformant conformant = new Conformant(window);
            conformant.Show();

            var surface = new CircleSurface(conformant);
            spn1 = new CircleSpinner(window, surface) {
                Text = "Spinner Test",
                LabelFormat = "%d Ratio",
                Style = "circle",
                Minimum = 0,
                Maximum = 100,
                Value = 0.0,
                Step = 10,
                Interval = 0.5,
                AlignmentX = -1,
                AlignmentY = 0.5,
                WeightX = 1,
                WeightY = 1
            };
            spn1.Geometry = new Rect(square.X, square.Y, square.Width, square.Height / 4);
            spn1.Show();

            spn2 = new CircleSpinner(window, surface) {
                Text = "Spinner Test",
                LabelFormat = "%d Value",
                Style = "circle",
                MarkerColor = Color.Red,
                Minimum = 0,
                Maximum = 100,
                Value = 0,
                Interval = 0.5,
                AlignmentX = -1,
                AlignmentY = 0.5,
                WeightX = 1,
                WeightY = 1
            };
            spn2.Geometry = new Rect(square.X, square.Y+ square.Width * 2 / 4, square.Width, square.Height / 4);
            spn2.Show();

            spn1.Focused += Spn1_Focused;
            spn2.Focused += Spn2_Focused;
            spn1.ValueChanged += Spn1_ValueChanged;
        }

        private void Spn1_ValueChanged(object sender, System.EventArgs e)
        {
            spn2.AngleRatio = spn1.Value;
        }

        private void Spn2_Focused(object sender, System.EventArgs e)
        {
            ((IRotaryActionWidget)spn2).Activate();
        }

        private void Spn1_Focused(object sender, System.EventArgs e)
        {
            ((IRotaryActionWidget)spn1).Activate();
        }
    }
}
