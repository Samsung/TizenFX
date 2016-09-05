using System;
using ElmSharp;

namespace ElmSharp.Test
{
    class LabelTest1 : TestCaseBase
    {
        public override string TestName => "LabelTest1";
        public override string TestDescription => "To test basic operation of Label";

        public override void Run(Window window)
        {
            Background bg = new Background(window);
            bg.Color = Color.White;
            bg.Move(0, 0);
            bg.Resize(window.ScreenSize.Width, window.ScreenSize.Height);
            bg.Show();

            Label label1 = new Label(window);
            label1.Text = "Label Test!!!";

            label1.Show();
            label1.Resize(200, 30);
            label1.Move(0, 0);
        }

    }
}
