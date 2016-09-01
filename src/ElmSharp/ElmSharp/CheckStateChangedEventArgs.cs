using System;

namespace ElmSharp
{
    public class CheckStateChangedEventArgs : EventArgs
    {
        public bool OldState { get; private set; }

        public bool NewState { get; private set; }

        public CheckStateChangedEventArgs(bool oldState, bool newState)
        {
            this.OldState = oldState;
            this.NewState = newState;
        }
    }
}
