using System;
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    [EditorBrowsable(EditorBrowsableState.Never)]
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
