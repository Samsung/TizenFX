using System;
using System.Collections.Generic;
using System.Text;

namespace ElmSharp.Test.TC
{
    class ButtonTest2 : WearableTestCase
    {
        public override string TestName => "ButtonTest2";
        public override string TestDescription => "To Test Wearable Circular Buttons";

        public override void Run(Window window)
        {
            Background bg = new Background(window);
            bg.Color = Color.Black;
            bg.Show();

            Button btn_bottom = new Button(window)
            {
                Style = "bottom",
                Text = "Down",
                Geometry = new Rect((window.ScreenSize.Width - 360) / 2, (window.ScreenSize.Height - 100), 360, 100)
            };
            btn_bottom.Show();

            Button btn_left = new Button(window)
            {
                Style = "popup/circle/left",
                Text = "Left",
                Geometry = new Rect(0, 0, 64, 360)
            };
            btn_left.Show();

            Button btn_right = new Button(window)
            {
                Style = "popup/circle/right",
                Text = "Right",
                Geometry = new Rect(window.ScreenSize.Width - 64, 0, 64, 360)
            };
            btn_right.Show();
        }
    }
}
