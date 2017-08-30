using ElmSharp.Wearable;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElmSharp.Test.TC
{
    public class RotaryEvent1 : TestCaseBase
    {
        public override string TestName => "Rotary Event Test 1";

        public override string TestDescription => "Wearable test for Rotary event";

        public override void Run(Window window)
        {
            Log.Debug("window id is " + window.Handle.ToString());
            Rect square = window.GetInnerSquare();

            Log.Debug(square.ToString());

            Rectangle redSquare = new Rectangle(window)
            {
                Color = Color.Red,
                Geometry = square
            };
            redSquare.Show();

            double degrees = 0;

            RotaryEventHandler handler = (args) =>
            {
                if (args.IsClockwise) degrees += 10;
                else degrees -= 10;

                if (degrees < 0) degrees = 360;
                else if (degrees > 360) degrees = 0;

                Rect rect = redSquare.Geometry;
                EvasMap map = new EvasMap(4);
                map.PopulatePoints(redSquare, 0);
                map.Rotate(degrees, rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
                redSquare.EvasMap = map;
                redSquare.IsMapEnabled = true;
            };

            RotaryEventManager.Rotated += handler;

            window.BackButtonPressed += (s, e) =>
            {
                RotaryEventManager.Rotated -= handler;
                Log.Debug("handler is Removed!!!!!!!");
            };
        }
    }
}
