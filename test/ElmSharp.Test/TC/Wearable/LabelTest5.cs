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


namespace ElmSharp.Test.Wearable
{
    public class LabelTest5 : WearableTestCase
    {
        public override string TestName => "LabelTest5";
        public override string TestDescription => "To test Slide Animation Speed of Label";

        public override void Run(Window window)
        {
            Rect square = window.GetInnerSquare();

            Background bg = new Background(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                Color = Color.White
            };
            bg.Geometry = square;
            bg.Show();

            Rect pieces = square;
            pieces.Height /= 4;

            Label label1 = new Label(window)
            {
                Text = "Test Slide Animaiton",
                Color = Color.Black,
                Style = "slide_long",
                SlideSpeed = 100,
                SlideMode = LabelSlideMode.Always,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };

            Button btnCurrentSpeed = new Button(window)
            {
                Text = "Current Speed : 100",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
            };

            Button btnSpeedUp = new Button(window)
            {
                Text = "Speed + 10",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
            };
            btnSpeedUp.Clicked += (s, e) =>
            {
                label1.SlideSpeed += 10;
                btnCurrentSpeed.Text = string.Format("Current Speed : {0}", label1.SlideSpeed);
                label1.PlaySlide();
            };
            Button btnSpeedDown = new Button(window)
            {
                Text = "Speed - 10",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
            };
            btnSpeedDown.Clicked += (s, e) =>
            {
                label1.SlideSpeed -= 10;
                btnCurrentSpeed.Text = string.Format("Current Speed : {0}", label1.SlideSpeed);
                label1.PlaySlide();
            };

            label1.Geometry = new Rect(pieces.X, pieces.Y, pieces.Width, pieces.Height);
            label1.Show();
            label1.PlaySlide();

            btnCurrentSpeed.Geometry = new Rect(pieces.X, pieces.Y + pieces.Height, pieces.Width, pieces.Height);
            btnCurrentSpeed.Show();

            btnSpeedUp.Geometry = new Rect(pieces.X, pieces.Y + pieces.Height*2, pieces.Width, pieces.Height);
            btnSpeedUp.Show();

            btnSpeedDown.Geometry = new Rect(pieces.X, pieces.Y + pieces.Height*3, pieces.Width, pieces.Height);
            btnSpeedDown.Show();
        }
    }
}
