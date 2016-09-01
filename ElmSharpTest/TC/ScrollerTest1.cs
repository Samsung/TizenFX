using System;
using ElmSharp;

namespace ElmSharp.Test
{
    public class ScrollerTest1 : TestCaseBase
    {
        public override string TestName => "ScrollerTest1";
        public override string TestDescription => "To test basic operation of Scroller";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Scroller scroller = new Scroller(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                ScrollBlock = ScrollBlock.None,
            };
            scroller.Show();
            conformant.SetContent(scroller);

            Box box = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
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
                    MinimumHeight = 400,
                };
                colorBox.Show();
                Console.WriteLine("Height = {0}", colorBox.Geometry.Height);
                box.PackEnd(colorBox);
            }
            scroller.Scrolled += Scroller_Scrolled;
        }

        private void Scroller_Scrolled(object sender, EventArgs e)
        {
            Console.WriteLine("Scrolled : {0}x{1}", ((Scroller)sender).CurrentRegion.X, ((Scroller)sender).CurrentRegion.Y);
        }
    }
}
