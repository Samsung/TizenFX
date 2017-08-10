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
    public class FocusAutoScrollModeTest : TestCaseBase
    {
        public override string TestName => "FocusAutoScrollModeTest";
        public override string TestDescription => "To test basic operation of Elementary.FocusAutoScrollMode";

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

            GenGridItem firstitem = null;
            GenGridItem lastitem = null;

            var rnd = new Random();
            for (int i = 0; i < 102; i++)
            {
                int r = rnd.Next(255);
                int g = rnd.Next(255);
                int b = rnd.Next(255);
                Color color = Color.FromRgb(r, g, b);
                var item = grid.Append(defaultClass, color);
                if (i == 0)
                    firstitem = item;
                if (i == 101)
                    lastitem = item;
            }
            grid.Show();
            Box box = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            box.Show();
            conformant.SetContent(box);

            box.PackEnd(grid);

            Button show = new Button(window)
            {
                Text = "Show",
                AlignmentX = -1,
                WeightX = 1,
            };
            Button none = new Button(window)
            {
                Text = "None",
                AlignmentX = -1,
                WeightX = 1,
            };
            Button bringIn = new Button(window)
            {
                Text = "BringIn",
                AlignmentX = -1,
                WeightX = 1,
            };

            show.Clicked += (s, e) =>
            {
                Elementary.FocusAutoScrollMode = FocusAutoScrollMode.Show;
                Console.WriteLine("FocusAutoScrollMode : {0}", Elementary.FocusAutoScrollMode);
            };
            none.Clicked += (s, e) =>
            {
                Elementary.FocusAutoScrollMode = FocusAutoScrollMode.None;
                Console.WriteLine("FocusAutoScrollMode : {0}", Elementary.FocusAutoScrollMode);
            };
            bringIn.Clicked += (s, e) =>
            {
                Elementary.FocusAutoScrollMode = FocusAutoScrollMode.BringIn;
                Console.WriteLine("FocusAutoScrollMode : {0}", Elementary.FocusAutoScrollMode);
            };

            show.Show();
            none.Show();
            bringIn.Show();

            box.PackEnd(show);
            box.PackEnd(none);
            box.PackEnd(bringIn);

            grid.ItemActivated += Grid_ItemActivated;
            grid.ItemSelected += Grid_ItemSelected;
            grid.ItemUnselected += Grid_ItemUnselected;
            grid.ItemRealized += Grid_ItemRealized;
            grid.ItemUnrealized += Grid_ItemUnrealized;
            grid.ItemPressed += Grid_ItemPressed;
            grid.ItemReleased += Grid_ItemReleased;
            grid.ItemLongPressed += Grid_ItemLongPressed;
            grid.ItemDoubleClicked += Grid_ItemDoubleClicked;
        }

        private void Grid_ItemDoubleClicked(object sender, GenGridItemEventArgs e)
        {
            Color color = (Color)e.Item.Data;
            Console.WriteLine("#{0:X}{1:X}{2:X} is Double clicked", color.R, color.G, color.B);
        }

        private void Grid_ItemLongPressed(object sender, GenGridItemEventArgs e)
        {
            Color color = (Color)e.Item.Data;
            Console.WriteLine("#{0:X}{1:X}{2:X} is LongPressed", color.R, color.G, color.B);
        }

        private void Grid_ItemReleased(object sender, GenGridItemEventArgs e)
        {
            Color color = (Color)e.Item.Data;
            Console.WriteLine("#{0:X}{1:X}{2:X} is Released", color.R, color.G, color.B);
        }

        private void Grid_ItemPressed(object sender, GenGridItemEventArgs e)
        {
            Color color = (Color)e.Item.Data;
            Console.WriteLine("#{0:X}{1:X}{2:X} is Pressed", color.R, color.G, color.B);
        }

        private void Grid_ItemUnselected(object sender, GenGridItemEventArgs e)
        {
            Color color = (Color)e.Item.Data;
            Console.WriteLine("#{0:X}{1:X}{2:X} is Unselected", color.R, color.G, color.B);
        }

        private void Grid_ItemRealized(object sender, GenGridItemEventArgs e)
        {
            Color color = (Color)e.Item.Data;
            Console.WriteLine("#{0:X}{1:X}{2:X} is Realized", color.R, color.G, color.B);
        }

        private void Grid_ItemUnrealized(object sender, GenGridItemEventArgs e)
        {
            Color color = (Color)e.Item.Data;
            Console.WriteLine("#{0:X}{1:X}{2:X} is Unrealized", color.R, color.G, color.B);
        }

        private void Grid_ItemSelected(object sender, GenGridItemEventArgs e)
        {
            Color color = (Color)e.Item.Data;
            Console.WriteLine("#{0:X}{1:X}{2:X} is Selected", color.R, color.G, color.B);
        }

        private void Grid_ItemActivated(object sender, GenGridItemEventArgs e)
        {
            Color color = (Color)e.Item.Data;
            Console.WriteLine("#{0:X}{1:X}{2:X} is Activated", color.R, color.G, color.B);
        }
    }
}
