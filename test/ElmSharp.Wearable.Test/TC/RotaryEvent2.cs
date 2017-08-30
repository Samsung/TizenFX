using ElmSharp.Wearable;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElmSharp.Test.TC
{
    public class RotaryEvent2 : TestCaseBase
    {
        public override string TestName => "Rotary Event Test 2";

        public override string TestDescription => "Wearable test for Rotary object event";

        Rectangle rect;

        double degrees = 0;

        void EventHandler(RotaryEventArgs args)
        {
            if (args.IsClockwise) degrees += 10;
            else degrees -= 10;

            if (degrees < 0) degrees = 360;
            else if (degrees > 360) degrees = 0;

            Rect r = rect.Geometry;
            EvasMap map = new EvasMap(4);
            map.PopulatePoints(rect, 0);
            map.Rotate(degrees, r.X + r.Width / 2, r.Y + r.Height / 2);
            rect.EvasMap = map;
            rect.IsMapEnabled = true;
        }

        public override void Run(Window window)
        {
            Rect square = window.GetInnerSquare();

            Log.Debug(square.ToString());

            rect = new Rectangle(window)
            {
                Color = Color.Blue,
                Geometry = square
            };
            rect.Show();

            rect.AddRotaryEventHandler(EventHandler);
            rect.Activate();

            window.BackButtonPressed += (s, e) => rect.RemoveRotaryEventHandler(EventHandler);
        }
    }
}
