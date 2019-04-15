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
    class RectangleTest1 : WearableTestCase
    {
        public override string TestName => "RectangleTest1";
        public override string TestDescription => "Add one Red Rectangle and one Orange Rectangle";

        public override void Run(Window window)
        {
            Rect square = window.GetInnerSquare();
            Rectangle box1 = new Rectangle(window)
            {
                Color = Color.Red
            };
            box1.Show();
            box1.Resize(square.Width / 2, square.Height / 2);
            box1.Move(square.X, square.Y);
            Rectangle box2 = new Rectangle(window)
            {
                Color = Color.Orange
            };
            box2.Show();
            box2.Resize(square.Width / 2, square.Height / 2);
            box2.Move(square.X + square.Width / 2, square.Y + square.Height / 2);
        }
    }
}
