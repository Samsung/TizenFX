using System;

namespace Tizen.Applications.Exceptions
{
    /// <summary>
    /// The class that represents the exception which will be thrown when the permission is denied
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class PermissionDeniedException : InvalidOperationException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">The localized error message string</param>
        /// <since_tizen> 4 </since_tizen>
        public PermissionDeniedException(string message) : base(message)
        {
        }
    }
}
