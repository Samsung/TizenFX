using System;
using ElmSharp;

namespace ElmSharp.Test
{
    class BoxTest1 : TestCaseBase
    {
        public override string TestName => "BoxTest1";
        public override string TestDescription => "To test basic operation of Box";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window);
            conformant.SetContent(box);
            box.Show();

            Button button1 = new Button(window) {
                Text = "Button 1",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            Button button2 = new Button(window) {
                Text = "Button 2",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            Button button3 = new Button(window) {
                Text = "Button 3",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };

            box.PackEnd(button1);
            box.PackEnd(button2);
            box.PackEnd(button3);

            button1.Show();
            button2.Show();
            button3.Show();

            button1.Clicked += Button1_Clicked;
            button2.Clicked += Button1_Clicked;
            button3.Clicked += Button1_Clicked;
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("{0} Clicked!", ((Button)sender).Text);
        }
    }
}
