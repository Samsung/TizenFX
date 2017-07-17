using System;
using System.Collections.Generic;
using System.Text;

namespace ElmSharp.Test.TC
{
    class CheckTest1 : WearableTestCase
    {
        public override string TestName => "CheckTest1";
        public override string TestDescription => "To test basic operation of Check";

        public override void Run(Window window)
        {
            Rect square = window.GetInnerSquare();

            Background bg = new Background(window);
            bg.Color = Color.White;
            bg.Geometry = square;
            bg.Show();

            Check check = new Check(window)
            {
                Text = "This is Check",
                Style = "default",
            };

            Label label1 = new Label(window)
            {
                Text = string.Format("IsChecked ={0}, Style={1}", check.IsChecked, check.Style),
            };

            Label label2 = new Label(window);

            Label label3 = new Label(window);

            check.StateChanged += (object sender, CheckStateChangedEventArgs e) =>
            {
                check.Style = check.Style == "default" ? "on&off" : "default";
                label1.Text = string.Format("IsChecked ={0}, Style={1}", check.IsChecked, check.Style);
                label2.Text = string.Format("OldState={0}", e.OldState);
                label3.Text = string.Format("NewState={0}", e.NewState);
            };

            Rect quater = square;
            quater.Height /= 4;

            label1.Geometry = new Rect(quater.X, quater.Y, quater.Width, quater.Height);
            label1.Show();

            label2.Geometry = new Rect(quater.X, quater.Y + quater.Height, quater.Width, quater.Height);
            label2.Show();

            label3.Geometry = new Rect(quater.X, quater.Y + quater.Height * 2, quater.Width, quater.Height);
            label3.Show();

            check.Geometry = new Rect(quater.X, quater.Y + quater.Height * 3, quater.Width, quater.Height);
            check.Show();
        }
    }
}
