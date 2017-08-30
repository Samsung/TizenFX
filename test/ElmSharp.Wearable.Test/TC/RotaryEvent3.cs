using ElmSharp.Wearable;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElmSharp.Test.TC
{
    public class RotaryEvent3 : TestCaseBase
    {
        public override string TestName => "Rotary Event Test 3";

        public override string TestDescription => "Multiple wearable test for Rotary event";

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

            Rectangle blueSquare = new Rectangle(window)
            {
                Color = Color.Blue,
                Geometry = new Rect(square.X + square.Width / 4, square.Y + square.Height / 4, square.Width / 2, square.Height / 2)
            };
            blueSquare.Show();

            double degrees = 0;
            double degrees2 = 0;

            RotaryEventHandler handler1 = (args) =>
            {
                Log.Debug((args.IsClockwise ? "CW" : "CCW") + " : " + args.Timestamp);
                if (args.IsClockwise) degrees2 += 10;
                else degrees2 -= 10;

                if (degrees2 < 0) degrees2 = 360;
                else if (degrees2 > 360) degrees2 = 0;

                Rect rect = blueSquare.Geometry;
                EvasMap map = new EvasMap(4);
                map.PopulatePoints(blueSquare, 0);
                map.Rotate(degrees2, rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
                blueSquare.EvasMap = map;
                blueSquare.IsMapEnabled = true;
            };

            RotaryEventHandler handler2 = (args) =>
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

            RotaryEventManager.Rotated += handler1;
            RotaryEventManager.Rotated += handler2;

            window.BackButtonPressed += (s, e) =>
            {
                RotaryEventManager.Rotated -= handler1;
                RotaryEventManager.Rotated -= handler2;
                Log.Debug("handler is Removed!!!!!!!");
            };
        }
    }
}
