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
using System.Runtime.InteropServices;

namespace ElmSharp.Test
{

    static class InteropAPI
    {
        [DllImport("libelementary.so.1")]
        public static extern void elm_genlist_realization_mode_set(IntPtr handle, bool enable);
    }

    public class ScrollerTest7 : TestCaseBase
    {
        public override TargetProfile TargetProfile => TargetProfile.Wearable | TargetProfile.Tv | TargetProfile.Mobile;
        public override string TestName => "ScrollerTest7";
        public override string TestDescription => "To test basic operation of Scroller";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box outerBox = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            outerBox.Show();
            outerBox.IsHorizontal = true;
            conformant.SetContent(outerBox);
            
            Scroller scroller = new Scroller(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                ScrollBlock = ScrollBlock.None,
            };
            scroller.Show();
            outerBox.PackEnd(scroller);

            Box box = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            box.Show();
            scroller.SetContent(box);

            scroller.VerticalBounce = true;

            var rnd = new Random();
            for (int i = 0; i < 102; i++)
            {
                int r = rnd.Next(255);
                int g = rnd.Next(255);
                int b = rnd.Next(255);
                Color color = Color.FromRgb(r, g, b);
                Rectangle colorBox = new Rectangle(window)
                {
                    AlignmentX = -1,
                    AlignmentY = -1,
                    WeightX = 1,
                    WeightY = 1,
                    Color = color,
                    MinimumHeight = 400,
                };
                colorBox.Show();
                Console.WriteLine("Height = {0}", colorBox.Geometry.Height);
                box.PackEnd(colorBox);
            }

            Scroller scroller2 = new Scroller(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                ScrollBlock = ScrollBlock.None,
            };
            scroller2.Show();
            outerBox.PackEnd(scroller2);

            Box box2 = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            box2.Show();
            scroller2.SetContent(box2);
            
            for (int i = 0; i < 102; i++)
            {
                int r = rnd.Next(255);
                int g = rnd.Next(255);
                int b = rnd.Next(255);
                Color color = Color.FromRgb(r, g, b);
                Background colorBox = new Background(window)
                {
                    AlignmentX = -1,
                    AlignmentY = -1,
                    WeightX = 1,
                    WeightY = 1,
                    Color = color,
                    MinimumHeight = 400,
                };
                colorBox.Show();
                Console.WriteLine("Height = {0}", colorBox.Geometry.Height);
                box2.PackEnd(colorBox);
            }

            GenItemClass fullyCustomizeClass = new GenItemClass("full")
            {
                GetContentHandler = (obj, part) =>
                {
                    int r = rnd.Next(255);
                    int g = rnd.Next(255);
                    int b = rnd.Next(255);
                    Color color = Color.FromRgb(r, g, b);
                    Background colorBox = new Background(window)
                    {
                        AlignmentX = -1,
                        AlignmentY = -1,
                        WeightX = 1,
                        WeightY = 1,
                        Color = color,
                        MinimumHeight = 400,
                    };
                    colorBox.Show();
                    return colorBox;
                },
            };
            GenList list = new GenList(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            list.Show();
            for (int i = 0; i < 102; i++)
            {
                list.Append(fullyCustomizeClass, string.Format("Data #", i));
            }
            InteropAPI.elm_genlist_realization_mode_set(list, true);

            outerBox.PackEnd(list);
        }

        private void Scroller_Scrolled(object sender, EventArgs e)
        {
            Console.WriteLine("Scrolled : {0}x{1}", ((Scroller)sender).CurrentRegion.X, ((Scroller)sender).CurrentRegion.Y);
        }
    }
}
