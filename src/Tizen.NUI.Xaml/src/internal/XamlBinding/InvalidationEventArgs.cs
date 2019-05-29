using System;
using Tizen.NUI.XamlBinding.Internals;

namespace Tizen.NUI.XamlBinding
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