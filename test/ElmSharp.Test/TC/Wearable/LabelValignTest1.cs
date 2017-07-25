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
    public class LabelValignTest1 : WearableTestCase
    {
        public override string TestName => "LabelValignTest1";
        public override string TestDescription => "To test Vertical align of Label";

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
                Text = "Align Test",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            label1.TextStyle = "DEFAULT = 'color=#000000FF font_size=30 align=center wrap=word'";
            label1.Geometry = new Rect(pieces.X, pieces.Y, pieces.Width, pieces.Height);
            label1.Show();

            Button top = new Button(window)
            {
                Text = "Top",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
            };

            Button middle = new Button(window)
            {
                Text = "Middle",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
            };
            Button bottom = new Button(window)
            {
                Text = "bottom",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
            };

            top.Clicked += (s, e) =>
            {
                label1.SetVerticalTextAlignment("elm.text", 0);
            };

            middle.Clicked += (s, e) =>
            {
                label1.SetVerticalTextAlignment("elm.text", 0.5);
            };

            bottom.Clicked += (s, e) =>
            {
                label1.SetVerticalTextAlignment("elm.text", 1.0);
            };

            top.Geometry = new Rect(pieces.X, pieces.Y + pieces.Height, pieces.Width, pieces.Height);
            top.Show();

            middle.Geometry = new Rect(pieces.X, pieces.Y + pieces.Height*2, pieces.Width, pieces.Height);
            middle.Show();

            bottom.Geometry = new Rect(pieces.X, pieces.Y + pieces.Height*3, pieces.Width, pieces.Height);
            bottom.Show();
        }
    }
}
