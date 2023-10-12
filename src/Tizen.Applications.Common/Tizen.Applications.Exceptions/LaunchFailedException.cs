using System;

namespace Tizen.Applications.Exceptions
{
    /// <summary>
    /// The class that represents the exception which will be thrown when the request failed to launch the application
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
#pragma warning disable CA1032
    public class LaunchFailedException : InvalidOperationException
#pragma warning restore CA1032
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
