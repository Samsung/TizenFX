using System;

namespace Tizen.Applications.Exceptions
{
    /// <summary>
    /// The class that represents the exception which will be thrown when the permission is denied
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
#pragma warning disable CA1032
    public class PermissionDeniedException : InvalidOperationException
#pragma warning restore CA1032
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
