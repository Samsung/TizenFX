using System;

namespace ElmSharp
{
    public class DisplayedMonthChangedEventArgs : EventArgs
    {
        public int OldMonth { get; private set; }

        public int NewMonth { get; private set; }

        public DisplayedMonthChangedEventArgs(int oldMonth, int newMonth)
        {
            this.OldMonth = oldMonth;
            this.NewMonth = newMonth;
        }
    }
}
