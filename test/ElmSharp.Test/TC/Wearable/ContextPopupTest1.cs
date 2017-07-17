using System;
using System.Collections.Generic;
using System.Text;

namespace ElmSharp.Test.TC
{
    class ContextPopupTest1 : WearableTestCase
    {
        public override string TestName => "ContextPopupTest1";
        public override string TestDescription => "To test basic operation of ContextPopup";
        private int _count = 0;
        public override void Run(Window window)
        {
            Rect square = window.GetInnerSquare();

            Background bg = new Background(window);
            bg.Color = Color.White;
            bg.Move(0, 0);
            bg.Resize(window.ScreenSize.Width, window.ScreenSize.Height);
            bg.Show();

            ContextPopup ctxPopup = new ContextPopup(bg)
            {
                IsHorizontal = false,
                AutoHide = false,
            };

            for (int i = 0; i < 5; i++)
            {
                ctxPopup.Append(string.Format("{0} item", _count++));
            }

            ctxPopup.Dismissed += (e, o) => {
                Console.WriteLine("Dismissed");
            };
            ctxPopup.Geometry = new Rect(square.X, square.Y, square.Width / 4, square.Height);
            ctxPopup.Show();

            bool ctxPopupVisible = true;
            string dismissCaption = "Dismiss ContextPopup!";
            string showCaption = "Show ContextPopup!";

            Button button = new Button(window)
            {
                Text = dismissCaption
            };
            button.Clicked += (E, o) =>
            {
                if (ctxPopupVisible)
                {
                    ctxPopup.Dismiss();
                }
                else
                {
                    ctxPopup.Show();
                }
                ctxPopupVisible = !ctxPopupVisible;
                button.Text = ctxPopupVisible ? dismissCaption : showCaption;
            };

            button.Geometry = new Rect(square.X + square.Width/2, square.Y, square.Width / 2, square.Height);
            button.Show();
        }
    }
}
