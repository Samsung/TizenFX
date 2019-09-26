using System;

namespace Tizen.Applications.ComponentBased.Common
{
    /// <summary>
    /// Interface for window information
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public interface IWindowInfo : IDisposable
    {
        /// <summary>
        /// Gets window resource ID
        /// </summary>
        /// <returns></returns>
        int ResourceId { get; }
    }
}
