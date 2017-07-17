using System;
using ElmSharp;

namespace ElmSharp.Test
{
    class EvasMapTest1 : TestCaseBase
    {
        public override string TestName => "EvasMapTest1";
        public override string TestDescription => "Test EvasMap on different levels of hierarchy";

        public override void Run(Window window)
        {
            var box = new Box(window)
            {
                IsHorizontal = false,
            };
            box.SetAlignment(-1.0, -1.0);
            box.SetWeight(1.0, 1.0);
            box.Show();

            var text = new Label(box)
            {
                Text = "<span color=#ffffff font_size=30>Target</span>",
                AlignmentX = -1.0,
                AlignmentY = -1.0,
                WeightX = 1.0,
                WeightY = 1.0,
            };
            text.Show();

            var textBox = new Box(box)
            {
                AlignmentX = -1.0,
                WeightX = 1.0,
                WeightY = 0.7,
            };
            textBox.PackEnd(text);
            textBox.Show();

            double angle = 0.0;

            var reset = new Button(box)
            {
                Text = "Reset",
                AlignmentX = -1.0,
                WeightX = 1.0,
                WeightY = 0.1,
            };
            reset.Show();

            double zx = 1.0;
            double zy = 1.0;
            reset.Clicked += (object sender, EventArgs e) =>
            {
                text.IsMapEnabled = false;
                angle = 0.0;
                zx = 1.0;
                zy = 1.0;
            };

            var zoom = new Button(box)
            {
                Text = "Zoom Target",
                AlignmentX = -1.0,
                WeightX = 1.0,
                WeightY = 0.1,
            };
            zoom.Show();

            zoom.Clicked += (object sender, EventArgs e) =>
            {
                zx += 0.1;
                zy += 0.1;
                var map = new EvasMap(4);
                var g = text.Geometry;
                map.PopulatePoints(g, 0);
                map.Rotate3D(0, 0, angle, g.X + g.Width / 2, g.Y + g.Height / 2, 0);
                map.Zoom(zx, zy, g.X, g.Y);
                text.EvasMap = map;
                text.IsMapEnabled = true;
            };

            var rotate = new Button(box)
            {
                Text = "Rotate Target",
                AlignmentX = -1.0,
                WeightX = 1.0,
                WeightY = 0.1,
            };
            rotate.Show();

            rotate.Clicked += (object sender, EventArgs e) =>
            {
                angle += 5.0;
                var map = new EvasMap(4);
                var g = text.Geometry;
                map.PopulatePoints(g, 0);
                map.Rotate3D(0, 0, angle, g.X + g.Width / 2, g.Y + g.Height / 2, 0);
                map.Zoom(zx, zy, g.X, g.Y);
                text.EvasMap = map;
                text.IsMapEnabled = true;
            };

            box.PackEnd(textBox);
            box.PackEnd(reset);
            box.PackEnd(zoom);
            box.PackEnd(rotate);

            box.Resize(window.ScreenSize.Width, window.ScreenSize.Height);
            box.Move(0, 0);
        }
    }
}