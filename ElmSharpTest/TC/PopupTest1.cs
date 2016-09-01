using System;
using ElmSharp;

namespace ElmSharp.Test
{
    public class PopupTest1 : TestCaseBase
    {
        public override string TestName => "PopupTest1";
        public override string TestDescription => "To test basic operation of Popup";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window);
            box.Show();
            Button btn = new Button(window)
            {
                AlignmentX = -1,
                WeightX = 1,
                Text = "Open"
            };
            btn.Show();
            
            Popup popup = new Popup(window)
            {
                Orientation = PopupOrientation.Bottom,
                Timeout = 5,
            };

            popup.Dismissed += (s, e) =>
            {
                Console.WriteLine("Popup dismissed");
            };

            popup.ShowAnimationFinished += (s, e) =>
            {
                Console.WriteLine("Popup show animation finished");
            };

            popup.OutsideClicked += (s, e) =>
            {
                Console.WriteLine("Popup outside clicked");
            };

            popup.TimedOut += (s, e) =>
            {
                Console.WriteLine("Popup time out");
                popup.Show();
            };

            popup.Append("Label1");
            popup.Append("Label2");
            popup.Append("Label3");

            btn.Clicked += (s, e) =>
            {
                popup.Show();
            };

            Button close = new Button(popup)
            {
                AlignmentX = -1,
                WeightX = 1,
                Text = "Close"
            };
            popup.SetPartContent("button1", close);

            close.Clicked += (s, e) =>
            {
                popup.Hide();
            };

            box.PackEnd(btn);
            conformant.SetContent(box);
        }
    }
}
