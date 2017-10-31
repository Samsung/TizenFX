using System;

namespace Tizen.Applications.Exceptions
{
    /// <summary>
    /// The class that represents the exception which will be thrown when the request failed to launch the application
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class LaunchFailedException : InvalidOperationException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">The localized error message string</param>
        /// <since_tizen> 4 </since_tizen>
        public LaunchFailedException(string message) : base(message)
        {
        }
    }
}
