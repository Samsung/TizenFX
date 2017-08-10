using System;
using ElmSharp;

namespace ElmSharp.Test
{
    public class FlipSelectorTest : TestCaseBase
    {
        public override string TestName => "FlipSelectorTest";
        public override string TestDescription => "To test FlipSelector";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();

            Box outterBox = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                IsHorizontal = false,
            };
            outterBox.Show();

            Box box = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                IsHorizontal = true,
            };
            box.Show();

            FlipSelector flip = new FlipSelector(window)
            {
                Interval = 1.0,
            };

            flip.Append("two");
            flip.Prepend("one");

            flip.Show();
            box.PackEnd(flip);

            conformant.SetContent(outterBox);
            outterBox.PackEnd(box);

            Button prev = new Button(window)
            {
                AlignmentX = -1,
                WeightX = 1,
                Text = "Prev"
            };
            prev.Clicked += (s, e) => { flip.Prev(); };
            prev.Show();

            Button next = new Button(window)
            {
                AlignmentX = -1,
                WeightX = 1,
                Text = "next"
            };
            next.Clicked += (s, e) => { flip.Next(); };
            next.Show();

            Button prepend = new Button(window)
            {
                AlignmentX = -1,
                WeightX = 1,
                Text = "prepend"
            };
            prepend.Clicked += (s, e) => {

                var random = new Random();
                int value = random.Next(99);
                flip.Prepend(value.ToString());
            };
            prepend.Show();

            Button append = new Button(window)
            {
                AlignmentX = -1,
                WeightX = 1,
                Text = "append"
            };
            append.Clicked += (s, e) => {

                var random = new Random();
                int value = random.Next(99);
                flip.Append(value.ToString());
            };
            append.Show();

            Button remove = new Button(window)
            {
                AlignmentX = -1,
                WeightX = 1,
                Text = "remove"
            };
            remove.Clicked += (s, e) => { flip.Remove(flip.SelectedItem); };
            remove.Show();

            outterBox.PackEnd(box);
            outterBox.PackEnd(prev);
            outterBox.PackEnd(next);
            outterBox.PackEnd(append);
            outterBox.PackEnd(prepend);
            outterBox.PackEnd(remove);
        }
    }
}
