using System;

namespace Tizen.Applications.Exceptions
{
    /// <summary>
    /// The class that represents the exception which will be thrown when the launch request is rejected
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class LaunchRejectedException : InvalidOperationException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">The localized error message string</param>
        /// <since_tizen> 4 </since_tizen>
        public LaunchRejectedException(string message) : base(message)
        {
        }
    }
}
