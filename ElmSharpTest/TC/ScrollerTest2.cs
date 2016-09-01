using System;
using ElmSharp;

namespace ElmSharp.Test
{
    public class ScrollerTest2 : TestCaseBase
    {
        public override string TestName => "ScrollerTest2";
        public override string TestDescription => "To test basic operation of Scroller";

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
                    MinimumWidth = window.ScreenSize.Width,
                };
                colorBox.Show();
                Console.WriteLine("Height = {0}", colorBox.Geometry.Height);
                box.PackEnd(colorBox);
            }

            conformant.SetContent(outterBox);
            outterBox.PackEnd(scroller);

            Button prev = new Button(window)
            {
                AlignmentX = -1,
                WeightX = 1,
                Text = "Prev"
            };
            Button next = new Button(window)
            {
                AlignmentX = -1,
                WeightX = 1,
                Text = "next"
            };
            prev.Clicked += (s, e) =>
            {
                scroller.ScrollTo(scroller.HorizontalPageIndex > 0 ? scroller.HorizontalPageIndex - 1: 0, scroller.VerticalPageIndex, true);
            };
            next.Clicked += (s, e) =>
            {
                scroller.ScrollTo(scroller.HorizontalPageIndex + 1, scroller.VerticalPageIndex, true);
            };
            prev.Show();
            next.Show();
            outterBox.PackEnd(prev);
            outterBox.PackEnd(next);

            scroller.DragStart += Scroller_DragStart;
            scroller.DragStop += Scroller_DragStop;
        }

        private void Scroller_DragStop(object sender, EventArgs e)
        {
            Console.WriteLine("Drag stop");
        }

        private void Scroller_DragStart(object sender, EventArgs e)
        {
            Console.WriteLine("Drag start");
        }
    }
}
