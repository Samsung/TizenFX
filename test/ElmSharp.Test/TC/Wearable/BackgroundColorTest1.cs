using System;
using System.Collections.Generic;
using System.Text;

namespace ElmSharp.Test.TC
{
    class BackgroundColorTest : WearableTestCase
    {
        public override string TestName => "BackgroundColorTest1";
        public override string TestDescription => "To test basic operation of Widget's background Color";

        Color[] _colors = new Color[] {
            Color.Red,
            new Color(125,200,255, 150),
            new Color(125, 200, 255, 10),
            Color.Default
        };

        public override void Run(Window window)
        {
            Rect square = window.GetInnerSquare();

            Button colorButton = new Button(window);
            colorButton.Geometry = square;
            Log.Debug(colorButton.Geometry.ToString());
            colorButton.Text = colorButton.BackgroundColor.ToString();
            colorButton.Show();

            int colorIndex = 0;
            colorButton.Clicked += (s, e) =>
            {
                colorButton.BackgroundColor = _colors[colorIndex++];
                colorButton.Text = colorButton.BackgroundColor.ToString();
                if (colorIndex == _colors.Length) colorIndex = 0;
            };
        }
    }
}
