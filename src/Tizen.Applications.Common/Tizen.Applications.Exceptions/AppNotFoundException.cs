using System;

namespace Tizen.Applications.Exceptions
{
    /// <summary>
    /// The class that represents the exception which will be thrown when the application to run is not found
    /// </summary>
    public class AppNotFoundException : InvalidOperationException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">The localized error message string</param>
        public AppNotFoundException(string message) : base(message)
        {
        }
    }
}
