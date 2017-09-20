using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.Exceptions
{
    /// <summary>
    /// The class that represents the exception which will be thrown when the memory is insufficient
    /// </summary>
    public class OutOfMemoryException : InvalidOperationException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">The localized error message string</param>
        public OutOfMemoryException(string message) : base(message)
        {
        }
    }
}
