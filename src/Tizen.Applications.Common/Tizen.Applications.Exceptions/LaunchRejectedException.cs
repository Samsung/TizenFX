using System;

namespace Tizen.Applications.Exceptions
{
    /// <summary>
    /// The class that represents the exception which will be thrown when the launch request is rejected
    /// </summary>
    public class LaunchRejectedException : InvalidOperationException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">The localized error message string</param>
        public LaunchRejectedException(string message) : base(message)
        {
        }
    }
}
