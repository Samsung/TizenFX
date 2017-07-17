using System;
using System.Collections.Generic;
using System.Text;

namespace ElmSharp.Test.TC
{
    class ClipperTest1 : WearableTestCase
    {
        public override string TestName => "ClipperTest1";
        public override string TestDescription => "ClipperTest1 test";

        public override void Run(Window window)
        {
            Rect square = window.GetInnerSquare();

            Conformant conformant = new Conformant(window);
            conformant.Show();

            Naviframe navi = new Naviframe(window)
            {
                PreserveContentOnPop = true,
                DefaultBackButtonEnabled = true
            };

            Scroller scroller = new Scroller(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                ScrollBlock = ScrollBlock.None,
            };
            scroller.Show();
            Box container = new Box(window);
            scroller.SetContent(container);

            var rect1 = new Rectangle(window)
            {
                AlignmentX = -1,
                WeightX = 1,
                Color = Color.Blue,
                MinimumHeight = square.Height / 3
            };
            rect1.Show();

            var clipper = new Rectangle(window);
            clipper.Color = new Color(200, 200, 200, 200);
            clipper.Geometry = rect1.Geometry;
            rect1.Moved += (s, e) =>
            {
                clipper.Geometry = ((Rectangle)s).Geometry;
            };
            rect1.SetClip(clipper);
            clipper.Show();
            container.PackEnd(rect1);

            Color[] colors = { Color.Red, Color.Olive, Color.Green, Color.Gray, Color.Lime, Color.Maroon };
            for (int i = 0; i < 6; i++)
            {
                var rect = new Rectangle(window)
                {
                    AlignmentX = -1,
                    WeightX = 1,
                    Color = colors[i],
                    MinimumHeight = square.Height / 3
                };
                rect.Show();
                container.PackEnd(rect);
            }

            navi.Push(scroller, "Scroll Page");
            navi.Show();
            conformant.SetContent(navi);
        }
    }
}
