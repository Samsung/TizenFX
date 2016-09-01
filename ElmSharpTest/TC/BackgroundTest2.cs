using System;
using ElmSharp;

namespace ElmSharp.Test
{
    public class BackgroundTest2 : TestCaseBase
    {
        public override string TestName => "BackgroundTest2";
        public override string TestDescription => "To test basic operation of Background";

        public override void Run(Window window)
        {
            Background bg1 = new Background(window)
            {
                Color = Color.Orange
            };

            Background bg2 = new Background(window)
            {
                Color = new Color(255, 255, 255, 100)
            };
            Show(bg1, 0, 0, 500, 500);
            Show(bg2, 100, 100, 500, 500);

            Console.WriteLine("bg1.Color : {0}", bg1.Color.ToString());
            Console.WriteLine("bg2.Color : {0}", bg2.Color.ToString());
        }

        void Show(Background bg, int x, int y, int w, int h)
        {
            bg.Show();
            bg.Move(x, y);
            bg.Resize(w, h);
        }
    }
}
