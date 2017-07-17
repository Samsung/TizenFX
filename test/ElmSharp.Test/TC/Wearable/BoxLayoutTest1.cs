using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElmSharp.Test.TC
{
    // under construct
    class BoxLayoutTest1 : WearableTestCase
    {
        public override string TestName => "BoxLayoutTest1";
        public override string TestDescription => "Box Layout callback test";

        Naviframe _navi;
        int _sequence = 0;
        Rect _square;

        public override void Run(Window window)
        {
            _square = window.GetInnerSquare();

            Conformant conformant = new Conformant(window);
            conformant.Show();

            Naviframe navi = new Naviframe(window)
            {
                PreserveContentOnPop = true,
                DefaultBackButtonEnabled = true
            };
            _navi = navi;

            navi.Popped += (s, e) =>
            {
                Console.WriteLine("----- Naviframe was popped {0:x} ", (int)(IntPtr)e.Content);
            };

            navi.Push(CreatePage(window));
            navi.Show();
            //navi.Geometry = _square;
            conformant.SetContent(navi);
        }

        EvasObject CreatePage(Window parent)
        {
            Box box = new Box(parent);
            box.Show();
            box.BackgroundColor = Color.Gray;

            Label label = new Label(parent)
            {
                Text = string.Format("{0} Page", _sequence++),
                WeightX = 1,
                AlignmentX = -1,
            };
            Button push = new Button(parent)
            {
                Text = "Push",
                WeightX = 1,
                AlignmentX = -1,
            };
            Button pop = new Button(parent)
            {
                Text = "pop",
                WeightX = 1,
                AlignmentX = -1,
            };

            label.Show();
            push.Show();
            pop.Show();

            push.Clicked += (s, e) =>
            {
                _navi.Push(CreatePage(parent));
            };

            pop.Clicked += (s, e) =>
            {
                var item = _navi.NavigationStack.LastOrDefault();
                int nativePointer = (int)(IntPtr)(item.Content);
                Console.WriteLine("----- Before Call _navi.Pop() {0:x} ", nativePointer);
                _navi.Pop();
                Console.WriteLine("----- After Call _navi.Pop() {0:x} ", nativePointer);
            };

            push.Resize(_square.Width, _square.Height / 6);
            pop.Resize(_square.Width, _square.Height / 6);
            label.Resize(_square.Width, _square.Height / 6);
            box.SetLayoutCallback(() =>
            {
                Console.WriteLine("Layout callback with : {0}", _square);
                var rect = box.Geometry;
                label.Move(_square.X, rect.Y);
                push.Move(_square.X, rect.Y + _square.Height / 6 + 5);
                pop.Move(_square.X, rect.Y + _square.Height / 3 + 10);
            });

            box.PackEnd(label);
            box.PackEnd(push);
            box.PackEnd(pop);
            return box;
        }
    }
}
