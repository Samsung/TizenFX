using System;
using ElmSharp;
using System.Collections.Generic;

namespace ElmSharp.Test
{
    public class ToolbarTest1 : TestCaseBase
    {
        Dictionary<ToolbarItem, int> _itemTable = new Dictionary<ToolbarItem, int>();
        Dictionary<int, ToolbarItem> _reverseItemTable = new Dictionary<int, ToolbarItem>();
        int currentItemIndex = 0;
        public override string TestName => "ToolbarTest1";
        public override string TestDescription => "To test basic operation of Toolbar";
        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box outterBox = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                IsHorizontal = false,
            };
            outterBox.Show();

            Toolbar toolbar = new Toolbar(window)
            {
                AlignmentX = -1,
                WeightX = 1,
                ShrinkMode = ToolbarShrinkMode.Scroll
            };

            toolbar.Show();
            outterBox.PackEnd(toolbar);


            Scroller scroller = new Scroller(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                ScrollBlock = ScrollBlock.Vertical,
                HorizontalPageScrollLimit = 1,
            };
            scroller.SetPageSize(1.0, 1.0);
            scroller.Show();

            Box box = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                IsHorizontal = true,
            };
            box.Show();
            scroller.SetContent(box);

            var rnd = new Random();
            for (int i = 0; i < 5; i++)
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
                    MinimumWidth = window.ScreenSize.Width,
                };
                colorBox.Show();
                box.PackEnd(colorBox);
                ToolbarItem item = toolbar.Append(string.Format("{0} Item", i), "home");
                _itemTable[item] = i;
                _reverseItemTable[i] = item;
                item.Selected += (s, e) =>
                {
                    scroller.ScrollTo(_itemTable[(ToolbarItem)s], 0, true);
                };
            }
            scroller.Scrolled += (s, e) =>
            {
                if (scroller.HorizontalPageIndex != currentItemIndex)
                {
                    currentItemIndex = scroller.HorizontalPageIndex;
                    _reverseItemTable[currentItemIndex].IsSelected = true;
                }
            };
            conformant.SetContent(outterBox);
            outterBox.PackEnd(scroller);
        }
    }
}
