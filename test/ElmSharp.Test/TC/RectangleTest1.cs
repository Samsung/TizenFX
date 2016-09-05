using System;
using ElmSharp;

namespace ElmSharp.Test
{
    class RectangleTest1 : TestCaseBase
    {
        public override string TestName => "RectangleTest1";
        public override string TestDescription => "Add one Red Rectangle and one Orange Rectangle";

        public override void Run(Window window)
        {
            Rectangle box1 = new Rectangle(window)
            {
                Color = Color.Red
            };
            box1.Show();
            box1.Resize(100, 100);
            box1.Move(0, 0);
            Rectangle box2 = new Rectangle(window)
            {
                Color = Color.Orange
            };
            box2.Show();
            box2.Resize(100, 100);
            box2.Move(100, 100);
        }
    }
}
