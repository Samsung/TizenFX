using System;
using ElmSharp;

namespace ElmSharp.Test
{
    class EntryTest1 : TestCaseBase
    {
        public override string TestName => "EntryTest1";
        public override string TestDescription => "To test basic operation of Entry";

        public override void Run(Window window)
        {
            Background bg = new Background(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                Color = Color.White
            };
            bg.Show();
            window.AddResizeObject(bg);

            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window);
            conformant.SetContent(box);
            box.Show();

            Entry entry1 = new Entry(window)
            {
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1,
                IsSingleLine = true,
            };
            entry1.SetPartText("guide", "<span color=#999999>Single Line</span>");

            Entry entry2 = new Entry(window)
            {
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1,
                IsPassword = true
            };
            entry2.SetPartText("guide", "<span color=#999999>Password</span>");

            box.PackEnd(entry1);
            box.PackEnd(entry2);

            entry1.Show();
            entry2.Show();
        }
    }
}
