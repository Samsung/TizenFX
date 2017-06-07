using System;
using ElmSharp;

namespace ElmSharp.Test
{
    class EvasMapTest2 : TestCaseBase
    {
        public override string TestName => "EvasMapTest2";
        public override string TestDescription => "Test EvasMap on different levels of hierarchy";

        public override void Run(Window window)
        {
            var box = new Box(window)
            {
                IsHorizontal = false,
            };
            box.SetAlignment(-1.0, -1.0);  // fill
            box.SetWeight(1.0, 1.0);  // expand
            box.Show();

            var group = new Box(box)
            {
                IsHorizontal = true,
                BackgroundColor = Color.White,
            };
            group.Show();

            var x = new Label(group)
            {
                Text = "X",
            };
            x.Show();

            var y = new Label(group)
            {
                Text = "Y",
            };
            y.Show();

            var z = new Label(group)
            {
                Text = "Z",
            };
            z.Show();
            group.PackEnd(x);
            group.PackEnd(y);
            group.PackEnd(z);

            var top = new Rectangle(box)
            {
                Color = Color.Red,
            };
            top.SetAlignment(-1.0, -1.0);  // fill
            top.SetWeight(1.0, 1.0);  // expand
            top.Show();

            var bottom = new Rectangle(box)
            {
                Color = Color.Green,
            };
            bottom.SetAlignment(-1.0, -1.0);  // fill
            bottom.SetWeight(1.0, 1.0);  // expand
            bottom.Show();

            double angle = 0.0;

            var reset = new Button(box)
            {
                Text = "Reset",
                AlignmentX = -1.0,
                WeightX = 1.0,
            };
            reset.Show();

            reset.Clicked += (object sender, EventArgs e) =>
            {
                group.IsMapEnabled = false;
                x.IsMapEnabled = false;
                angle = 0.0;
            };

            var zoom = new Button(box)
            {
                Text = "Zoom group",
                AlignmentX = -1.0,
                WeightX = 1.0,
            };
            zoom.Show();

            zoom.Clicked += (object sender, EventArgs e) =>
            {
                var map = new EvasMap(4);
                var g = group.Geometry;
                map.PopulatePoints(g, 0);
                map.Zoom(3.0, 3.0, g.X + g.Width / 2, g.Y + g.Height / 2);
                group.EvasMap = map;
                group.IsMapEnabled = true;
            };

            var rotate = new Button(box)
            {
                Text = "Rotate X",
                AlignmentX = -1.0,
                WeightX = 1.0,
            };
            rotate.Show();

            rotate.Clicked += (object sender, EventArgs e) =>
            {
                angle += 5.0;

                var map = new EvasMap(4);
                var g = x.Geometry;
                map.PopulatePoints(g, 0);
                map.Rotate3D(0, 0, angle, g.X + g.Width / 2, g.Y + g.Height / 2, 0);
                x.EvasMap = map;
                x.IsMapEnabled = true;
            };

            box.PackEnd(top);
            box.PackEnd(group);
            box.PackEnd(bottom);
            box.PackEnd(reset);
            box.PackEnd(zoom);
            box.PackEnd(rotate);

            box.Resize(window.ScreenSize.Width, window.ScreenSize.Height);
            box.Move(0, 0);
        }
    }
}