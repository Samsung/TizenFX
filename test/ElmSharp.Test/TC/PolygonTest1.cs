using System;
using ElmSharp;

namespace ElmSharp.Test
{
    class PolygonTest1 : TestCaseBase
    {
        public override string TestName => "PolygonTest1";
        public override string TestDescription => "To test basic operation of Polygon";

        public override void Run(Window window)
        {
            Background bg = new Background(window);
            bg.Color = Color.White;
            bg.Move(0, 0);
            bg.Resize(window.ScreenSize.Width, window.ScreenSize.Height);
            bg.Show();

            Polygon triangle1 = new Polygon(window);
            triangle1.Color = Color.Blue;
            triangle1.AddPoint(100, 100);
            triangle1.AddPoint(100, 500);
            triangle1.AddPoint(500, 500);
            triangle1.Show();

            Polygon triange2 = new Polygon(window);
            triange2.AddPoint(300, 300);
            triange2.AddPoint(new Point{X=600, Y=300});
            triange2.AddPoint(new Point{X=600, Y=600});
            triange2.Color = Color.Green;
            triange2.Show();

            Polygon hexagon = new Polygon(window);
            hexagon.Color = Color.Pink;
            hexagon.AddPoint(0, 0);
            hexagon.AddPoint(700, 0);
            hexagon.ClearPoints();
            for (double a=0; a < 2 * Math.PI; a += Math.PI / 3)
            {
                hexagon.AddPoint(
                    300 + (int)(120 * Math.Sin(a)),
                    580 + (int)(120 * Math.Cos(a))
                );
            }
            hexagon.Show();
        }

    }
}
