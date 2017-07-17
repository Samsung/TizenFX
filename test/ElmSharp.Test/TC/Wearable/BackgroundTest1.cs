using System;
using System.Collections.Generic;
using System.Text;

namespace ElmSharp.Test.TC
{
    class BackgroundTest1 : WearableTestCase

    {
        public override string TestName => "BackgroundTest1";
        public override string TestDescription => "To test basic operation of Background";

        public override void Run(Window window)
        {
            Rect square = window.GetInnerSquare();

            Background bg1 = new Background(window)
            {
                Color = Color.Orange,
                Geometry = new Rect(square.X, square.Y, square.Width / 2, square.Height / 2)
            };

            Background bg2 = new Background(window)
            {
                Color = new Color(60, 128, 255, 100),
                Geometry = new Rect(square.X, square.Y + square.Height / 2, square.Width / 2, square.Height / 2)
            };

            Background bg3 = new Background(window)
            {
                File = "/home/owner/apps_rw/ElmSharpTest/res/picture.png",
                BackgroundOption = BackgroundOptions.Center,
                BackgroundColor = Color.Gray,
                Geometry = new Rect(square.X + square.Width/2, square.Y, square.Width / 2, square.Height)
            };

            bg3.SetFileLoadSize(square.Width/2, square.Height);

            bg1.Show();
            bg2.Show();
            bg3.Show();
        }
    }
}
