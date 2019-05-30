using System;

namespace Tizen.NUI.XamlBinding
{
    internal class EventArg<T> : EventArgs
    {
        // Property variable

        // Constructor
        public EventArg(T data)
        {
            Data = data;
        }

        // Property for EventArgs argument
        public T Data { get; }
    }
}