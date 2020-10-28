using System;

namespace Tizen.NUI.Binding
{
    internal class InvalidNavigationException : Exception
    {
        public InvalidNavigationException(string message) : base(message)
        {
        }
    }
}