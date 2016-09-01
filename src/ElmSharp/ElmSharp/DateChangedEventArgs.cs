using System;

namespace ElmSharp
{
    public class DateChangedEventArgs : EventArgs
    {
        public DateTime OldDate { get; private set; }

        public DateTime NewDate { get; private set; }

        public DateChangedEventArgs(DateTime oldDate, DateTime newDate)
        {
            this.OldDate = oldDate;
            this.NewDate = newDate;
        }
    }
}
