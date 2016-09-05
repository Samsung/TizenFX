using System;
using ElmSharp;

namespace ElmSharp.Test
{
    class BackgroundTest1 : TestCaseBase
    {
        public override string TestName => "BackgroundTest1";
        public override string TestDescription => "To test basic operation of Background";

        public override void Run(Window window)
        {
            Background bg1 = new Background(window)
            {
                Color = Color.Orange
            };

            Background bg2 = new Background(window) {
                File = "/opt/home/owner/res/tizen.png",
                BackgroundOption = BackgroundOptions.Tile
            };

            Show(bg1, 0, 0, 100, 100);
            Show(bg2, 100, 100, 500, 500);
        }

        void Show(Background bg, int x, int y, int w, int h)
        {
            bg.Show();
            bg.Move(x, y);
            bg.Resize(w, h);
        }
    }
}
