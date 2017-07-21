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
using System.Text;

namespace ElmSharp.Test.Wearable
{
    class BackgroundColorTest : WearableTestCase
    {
        public override string TestName => "BackgroundColorTest1";
        public override string TestDescription => "To test basic operation of Widget's background Color";

        Color[] _colors = new Color[] {
            Color.Red,
            new Color(125,200,255, 150),
            new Color(125, 200, 255, 10),
            Color.Default
        };

        public override void Run(Window window)
        {
            Rect square = window.GetInnerSquare();

            Button colorButton = new Button(window);
            colorButton.Geometry = square;
            Log.Debug(colorButton.Geometry.ToString());
            colorButton.Text = colorButton.BackgroundColor.ToString();
            colorButton.Show();

            int colorIndex = 0;
            colorButton.Clicked += (s, e) =>
            {
                colorButton.BackgroundColor = _colors[colorIndex++];
                colorButton.Text = colorButton.BackgroundColor.ToString();
                if (colorIndex == _colors.Length) colorIndex = 0;
            };
        }
    }
}
