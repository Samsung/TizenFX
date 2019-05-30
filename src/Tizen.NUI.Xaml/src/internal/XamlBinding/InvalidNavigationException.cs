using System;

namespace Tizen.NUI.XamlBinding
{
    internal class InvalidNavigationException : Exception
    {
        public InvalidNavigationException(string message) : base(message)
        {
        }
    }
}