using System;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.Binding
{
    internal class InvalidationEventArgs : EventArgs
    {
        public InvalidationEventArgs(InvalidationTrigger trigger)
        {
            Trigger = trigger;
        }

        public InvalidationTrigger Trigger { get; private set; }
    }
}
