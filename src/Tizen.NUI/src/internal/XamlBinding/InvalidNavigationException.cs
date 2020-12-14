using System;

namespace Tizen.NUI.Binding
{
    internal class InvalidNavigationException : Exception
    {
        public InvalidNavigationException()
        {
        }
        public InvalidNavigationException(string message) : base(message)
        {
        }
        public InvalidNavigationException(string message, Exception innerException = null) : base(message, innerException)
        {
        }
    }
}
