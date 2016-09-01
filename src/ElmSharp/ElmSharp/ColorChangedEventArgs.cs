using System;

namespace ElmSharp
{
    public class ColorChangedEventArgs : EventArgs
    {
        public Color OldColor { get; private set; }

        public Color NewColor { get; private set; }

        public ColorChangedEventArgs(Color oldColor, Color newColor)
        {
            this.OldColor = oldColor;
            this.NewColor = newColor;
        }
    }
}
