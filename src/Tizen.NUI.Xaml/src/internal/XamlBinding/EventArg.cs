using System;

namespace Tizen.NUI.Binding
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