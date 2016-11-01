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

namespace ElmSharp.Test
{
    public class GenGridTest1 : TestCaseBase
    {
        public override string TestName => "GenGridTest1";
        public override string TestDescription => "To test basic operation of GenGrid";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            GenGrid grid = new GenGrid(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                ItemAlignmentX = -1,
                ItemAlignmentY = -1,
                ItemWidth = window.ScreenSize.Width / 3,
                ItemHeight = window.ScreenSize.Width / 3,
            };

            GenItemClass defaultClass = new GenItemClass("default")
            {
                GetTextHandler = (obj, part) =>
                {
                    Color item = (Color)obj;
                    return String.Format("#{0:X}{1:X}{2:X}", item.R, item.G, item.B);
                },
                GetContentHandler = (obj, part) =>
                {
                    Color item = (Color)obj;
                    Console.WriteLine("{0} part create requested", part);
                    if (part == "elm.swallow.icon")
                    {
                        var colorbox = new Rectangle(window)
                        {
                            Color = item
                        };
                        return colorbox;
                    }
                    return null;
                }

            };

            var rnd = new Random();
            for (int i = 0; i < 102; i++)
            {
                int r = rnd.Next(255);
                int g = rnd.Next(255);
                int b = rnd.Next(255);
                Color color = Color.FromRgb(r, g, b);
                grid.Append(defaultClass, color);
            }
            grid.Show();
            conformant.SetContent(grid);
        }

        private void List_ItemSelected(object sender, GenListItemEventArgs e)
        {
            Console.WriteLine("{0} Item was selected", (string)(e.Item.Data));
        }
    }
}
