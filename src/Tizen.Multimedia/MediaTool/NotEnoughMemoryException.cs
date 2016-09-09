using System;

namespace Tizen.Multimedia
{
    /// <summary>
    /// The exception that is thrown when there is no memory to allocate a new buffer for the packet.
    /// </summary>
    public class NotEnoughMemoryException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the NotEnoughMemoryException class with a specified error message.
        /// </summary>
        /// <param name="message">Error description.</param>
        public NotEnoughMemoryException(string message) : base(message)
        {
        }
    }
}
