using System;

namespace Tizen.Applications.Exceptions
{
    /// <summary>
    /// The class that represents the exception which will be thrown when the application to run is not found
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
#pragma warning disable CA1032
    public class AppNotFoundException : InvalidOperationException
#pragma warning restore CA1032
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">The localized error message string</param>
        /// <since_tizen> 4 </since_tizen>
        public AppNotFoundException(string message) : base(message)
        {
        }
    }
}
