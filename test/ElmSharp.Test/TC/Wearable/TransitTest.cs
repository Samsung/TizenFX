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
    class TransitTest : WearableTestCase
    {
        public override string TestName => "TransitTest";
        public override string TestDescription => "To test basic operation of Transit";

        Transit CreateTransit()
        {
            Transit transit = new Transit();
            transit.Deleted += (s, e) => { Console.WriteLine("Transit Deleted"); };
            transit.Repeat = 1;
            transit.AutoReverse = true;
            transit.Duration = 1;
            return transit;
        }

        public override void Run(Window window)
        {
            Rect square = window.GetInnerSquare();
            Button button1 = new Button(window) {
                Text = "Effect",
            };
            button1.Move(square.X, square.Y);
            button1.Resize(square.Width / 2, square.Height / 2);
            button1.Show();

            Button button2 = new Button(window)
            {
                Text = "Chain Effect",
            };
            button2.Move(square.X + square.Width / 2, square.Y + square.Height / 2);
            button2.Resize(square.Width / 2, square.Height / 2);
            button2.Show();

            Point begin = new Point();
            begin.X = begin.Y = 0;
            Point end = new Point();
            end.X = end.Y = square.Height / 2;
            TranslationEffect translation = new TranslationEffect(begin, end);
            translation.EffectEnded += (s, e) => { Console.WriteLine("Translation Effect Ended"); };

            RotationEffect rotation = new RotationEffect(0, 180);
            rotation.EffectEnded += (s, e) => { Console.WriteLine("Rotation Effect Ended"); };

            button1.Clicked += (s, e) => {
                Transit transit1 = CreateTransit();
                transit1.Objects.Add(button1);
                transit1.Objects.Add(button2);
                transit1.AddEffect(translation);
                transit1.AddEffect(rotation);
                transit1.Go();
            };

            button2.Clicked += (s, e) => {
                Transit transit1 = CreateTransit();
                transit1.Objects.Add(button1);
                transit1.AddEffect(translation);
                transit1.AddEffect(rotation);

                Transit transit2 = CreateTransit();
                transit2.Objects.Add(button2);
                transit2.AddEffect(translation);
                transit2.AddEffect(rotation);

                transit1.Chains.Add(transit2);
                transit1.Go();
            };
        }
    }
}