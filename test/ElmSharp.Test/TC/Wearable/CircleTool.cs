using System;
using System.Collections.Generic;
using System.Text;

namespace ElmSharp.Test.TC
{
    public static class CircleTool
    {
        static Rect _inSquare;
        public static Rect GetInnerSquare(this Window window)
        {
            Size screenSize = window.ScreenSize;
            int min = Math.Min(screenSize.Height, screenSize.Width);
            int width = (int)(min * Math.Cos(Math.PI / 4));
            int x = screenSize.Width / 2 - width / 2;
            int y = screenSize.Height / 2 - width / 2;

            return _inSquare == default(Rect) ? (_inSquare = new Rect(x, y, width, width)) : _inSquare;
        }
    }
}
