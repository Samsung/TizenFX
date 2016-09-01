using System;
using ElmSharp;

namespace ElmSharp.Test
{
    class NaviframeTest1 : TestCaseBase
    {
        public override string TestName => "NaviframeTest1";
        public override string TestDescription => "Naviframe test";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();

            Naviframe navi = new Naviframe(window)
            {
                PreserveContentOnPop = true,
                DefaultBackButtonEnabled = true
            };
            
            navi.Popped += (s, e) =>
            {
                Console.WriteLine("naviframe was popped : " + e.Content.GetType());
            };

            Rectangle rect1 = new Rectangle(window)
            {
                Color = Color.Red,
                Geometry = new Rect(0, 0, 200, 200)
            };

            navi.Push(rect1, "First Page");

            Rectangle rect2 = new Rectangle(window)
            {
                Color = Color.Blue,
                Geometry = new Rect(0, 0, 200, 200)
            };

            navi.Push(rect2, "Second Page");
            navi.Show();
            conformant.SetContent(navi);
        }
    }
}
