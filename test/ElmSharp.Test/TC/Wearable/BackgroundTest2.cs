using System;
using System.Collections.Generic;
using System.Text;

namespace ElmSharp.Test.TC
{
    class BackgroundTest2 : WearableTestCase
    {
        public override string TestName => "BackgroundTest2";
        public override string TestDescription => "To test basic operation of Background";

        public override void Run(Window window)
        {
            Rect square = window.GetInnerSquare();

            Conformant conformant = new Conformant(window);
            conformant.Show();

            Box box = new Box(window)
            {
                Geometry = square
            };
            box.Show();
            Background bg = new Background(window)
            {
                AlignmentY = -1,
                AlignmentX = -1,
                WeightX = 1,
                WeightY = 1,
            };
            bg.Show();
            box.PackEnd(bg);
            Slider red = new Slider(window)
            {
                Minimum = 0,
                Maximum = 255,
                Text = "Red",
                AlignmentX = -1,
                WeightX = 1
            };
            Slider green = new Slider(window)
            {
                Minimum = 0,
                Maximum = 255,
                Text = "Green",
                AlignmentX = -1,
                WeightX = 1
            };
            Slider blue = new Slider(window)
            {
                Minimum = 0,
                Maximum = 255,
                Text = "Blue",
                AlignmentX = -1,
                WeightX = 1
            };
            Slider alpha = new Slider(window)
            {
                Minimum = 0,
                Maximum = 255,
                Text = "Alpha",
                AlignmentX = -1,
                WeightX = 1
            };
            red.Show();
            green.Show();
            blue.Show();
            alpha.Show();
            box.PackEnd(red);
            box.PackEnd(green);
            box.PackEnd(blue);
            box.PackEnd(alpha);
            red.Value = 255;
            green.Value = 255;
            blue.Value = 255;
            alpha.Value = 255;

            bg.Color = new Color(255, 255, 255, 255);

            EventHandler handler = (s, e) =>
            {
                bg.Color = new Color((int)red.Value, (int)green.Value, (int)blue.Value, (int)alpha.Value);
            };

            red.ValueChanged += handler;
            green.ValueChanged += handler;
            blue.ValueChanged += handler;
            alpha.ValueChanged += handler;
        }
    }
}
