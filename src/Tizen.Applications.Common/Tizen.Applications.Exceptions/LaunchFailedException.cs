using System;

namespace Tizen.Applications.Exceptions
{
    /// <summary>
    /// The class that represents the exception which will be thrown when the request failed to launch the application
    /// </summary>
    public class LaunchFailedException : InvalidOperationException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">The localized error message string</param>
        public LaunchFailedException(string message) : base(message)
        {
        }
    }
}
